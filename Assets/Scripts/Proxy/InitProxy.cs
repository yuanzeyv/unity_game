using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using MVCFrame;
using Config.Program;
using ProxySpace;

class InitProxy
{
    private static InitProxy InstanceObj;
    public static InitProxy GetInstance()
    {
        if (InstanceObj == null)
            InstanceObj = new InitProxy();
        return InstanceObj;
    }
    private InitProxy()
    {
    }
    public void LoginInProxy()
    {
        Sys.GetFacade().RegisterProxy(new NetWorkProxy());//创建一个网络模块
        Sys.GetFacade().RegisterProxy(new LoginProxy());//添加一个登录模块
        Sys.GetFacade().RegisterProxy(new PlayerInfoProxy());//添加一个登录模块
        //Sys.GetFacade().RegisterProxy(new BambooProxy());//添加一个接竹竿的模块
        Sys.GetFacade().RegisterProxy(new SystemServiceProxy());//创建一个网络模块   
    }
}

