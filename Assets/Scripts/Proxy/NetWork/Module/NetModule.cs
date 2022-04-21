using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LightJson;
using MVCFrame;
using Config.Program;
namespace ModuleCellSpace
{
    public class NetModule : ModuleCell
    {
        public delegate void NexExecuteHandle(MessageStruct param);
        public NetWorkUtil NetUtil = new NetWorkUtil();//一个网络工具类 
        public Dictionary<uint, NexExecuteHandle> MsgHandleMap = new Dictionary<uint, NexExecuteHandle>();   
        //开始连接网络
        public bool ConnectSocket(int port,string addr,string name)
        {
            return NetUtil.ConnectSocket(port,addr,name);
        }
        public void RegisterNetHandle(string cmd, NexExecuteHandle handle)
        {
            if (!NetMsg.MsgDef.ContainsKey(cmd))
            {
                Debug.LogWarning(string.Format("注册监听消息({0})执行失败,原因是消息不存在于网络消息列表中", cmd));
                return;
            }
            uint MsgID = NetMsg.MsgDef[cmd];//获取到消息的数字ID
            if (MsgHandleMap.ContainsKey(MsgID))
            {
                Debug.LogWarning(string.Format("网络消息({0})重复注册,请检查逻辑", cmd)); 
            }
            MsgHandleMap[MsgID] = handle;
        }
        public void UnregisterNetHandle(string cmd)
        { 
            if (!NetMsg.MsgDef.ContainsKey(cmd))
            {
                Debug.LogWarning(string.Format("反注册监听消息({0})执行失败,原因是消息不存在于网络消息列表中",cmd));
                return;
            }
            uint MsgID = NetMsg.MsgDef[cmd];//获取到消息的数字ID
            if (!MsgHandleMap.ContainsKey(MsgID))
            {
                Debug.LogWarning(string.Format("反注册监听消息({0})执行失败,原因是消息未注册在网络代理下", cmd));
                return;
            }
            MsgHandleMap.Remove(MsgID);
        }
        //在外部有一个每秒 60次的时钟，进行调用本函数 
        public void NetMsgExecuteStepHandle()
        {
            if (NetUtil == null) //如果当前的工具类还没有初始化 
                return;
            if (!NetUtil.TryGetMsg())//判断当前是否存在数据信息 
                return; 
            List<MessageStruct> msgList = NetUtil.GetNetWorkMsg();//获取到网络消息列表 
            Facade facade = Sys.GetFacade();
            NetMsg netObj = NetMsg.Instance();
            foreach (var msg in msgList)
            { 
                if (NetMsg.NetIDDef.ContainsKey(msg.msgID))
                { 
                    MsgHandleMap[msg.msgID](msg);
                }
                else 
                    MonoBehaviour.print("消息没有被实现" + msg.msgID); 
            }
        }
    }
} 