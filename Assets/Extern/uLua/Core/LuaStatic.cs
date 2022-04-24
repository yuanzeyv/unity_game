using System;
using UnityEngine;

namespace LuaInterface
{
    public delegate byte[] ReadLuaFile(string name);

    public static class LuaStatic
    {
        public static ReadLuaFile Load = null;

        static LuaStatic()
        {
            Load = DefaultLoader;
        }

        static byte[] DefaultLoader(string name)
        {
            byte[] str = null;
            string luapath = Util.LuaResourcePath(name);
            TextAsset luaCode = Resources.Load<TextAsset>(luapath);
            if (luaCode != null) str = luaCode.bytes;
            return str;
        }

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int panic(IntPtr L)
        {
            string reason = String.Format("unprotected error in call to Lua API ({0})", LuaAPI.lua_tostring(L, -1));
            LuaAPI.lua_pop(L, 1);
            throw new LuaException(reason);
        }

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int traceback(IntPtr L)
        {
            LuaAPI.lua_getglobal(L, "debug");
            LuaAPI.lua_getfield(L, -1, "traceback");
            LuaAPI.lua_pushvalue(L, 1);
            LuaAPI.lua_pushnumber(L, 2);
            LuaAPI.lua_pcall(L, 2, 1, 0);
            return 1;
        }

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int print(IntPtr L)
        {
            int n = LuaAPI.lua_gettop(L);
            string s = String.Empty;

            LuaAPI.lua_getglobal(L, "tostring");
            for (int i = 1; i <= n; i++)
            {
                LuaAPI.lua_pushvalue(L, -1);  /* function to be called */
                LuaAPI.lua_pushvalue(L, i);   /* value to print */
                if (0 != LuaAPI.lua_pcall(L, 1, 1, 0))
                {
                    return LuaAPI.lua_error(L);
                }
                s += LuaAPI.lua_tostring(L, -1);

                if (i != n) s += "\t";

                LuaAPI.lua_pop(L, 1);
            }
            UnityEngine.Debug.Log("LUA: " + s);
            return 0;
        }

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int loader(IntPtr L)
        {
            string fileName = string.Empty;
            fileName = LuaAPI.lua_tostring(L, 1);

            string lowerName = fileName.ToLower();
            if (lowerName.EndsWith(".lua"))
            {
                int index = fileName.LastIndexOf('.');
                fileName = fileName.Substring(0, index);
            }
            fileName = fileName.Replace('.', '/');
            int oldTop = LuaAPI.lua_gettop(L);
            LuaAPI.lua_pushstdcallcfunction(L, LuaStatic.traceback);

            byte[] text = LuaStatic.Load(fileName);
            if (text == null)
            {
                LuaAPI.lua_pop(L, 1);
                return 0;
            }
            if (LuaAPI.luaL_loadbuffer(L, text, text.Length, fileName) != 0)
            {
                LuaScriptMgr mgr = LuaScriptMgr.GetMgrFromLuaState(L);
                if (mgr != null) mgr.lua.ThrowExceptionFromError(oldTop + 1);
                LuaAPI.lua_pop(L, 1);
            }
            return 1;
        }

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int dofile(IntPtr L)
        {
            string fileName = String.Empty;
            fileName = LuaAPI.lua_tostring(L, 1);

            string lowerName = fileName.ToLower();
            if (lowerName.EndsWith(".lua"))
            {
                int index = fileName.LastIndexOf('.');
                fileName = fileName.Substring(0, index);
            }
            fileName = fileName.Replace('.', '/') + ".lua";

            int n = LuaAPI.lua_gettop(L);
            byte[] text = Load(fileName);
            if (text == null)
            {
                return LuaAPI.lua_gettop(L) - n;
            }
            if (LuaAPI.luaL_loadbuffer(L, text, text.Length, fileName) == 0)
            {
                LuaAPI.lua_pcall(L, 0, -1, 0);
            }
            return LuaAPI.lua_gettop(L) - n;
        }

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int loadfile(IntPtr L)
        {
            return loader(L);
        }

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int importWrap(IntPtr L)
        {
            string fileName = String.Empty;
            fileName = LuaAPI.lua_tostring(L, 1);
            fileName = fileName.Replace('.', '_');
            if (!string.IsNullOrEmpty(fileName))
            {
                LuaBinder.Bind(L, fileName);
            }
            return 0;
        }

        [MonoPInvokeCallback(typeof(LuaCSFunction))]
        public static int LoadLuaProfobuf(IntPtr L)
        {
            return LuaAPI.luaopen_pb(L);
        }

        [MonoPInvokeCallback(typeof(LuaCSFunction))]
        internal static int LoadBuiltinLib(IntPtr L)
        {
            LuaAPI.lua_pushstdcallcfunction(L, LoadLuaProfobuf);
            return 1;
        }
    }
}