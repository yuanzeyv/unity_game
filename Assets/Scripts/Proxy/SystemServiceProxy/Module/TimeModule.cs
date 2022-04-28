using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LightJson;
using MVCFrame;
using System;
using Config.Program;
using ProxySpace;
namespace ModuleCellSpace
{
    public class TimeModule : ModuleCell
    {
        double HeartbeatTime = 5;//每五秒钟发送一次心跳
        double DisConnectHeartbeatTime = 0;//收消息多少秒后，就会掉线
        bool CanSendHeartbeat = true;
        double HeartbeatInterval = 10;//心跳时间 
        NetModule NetModuleGrid = null;

        long ServerTimeDifference = 0;
        public DateTime ServerTime
        {
            get { 
                return DateTime.Now.AddTicks(ServerTimeDifference);
            }
        }//获取到当前的系统时间
        public TimeModule()
        {

        }
        public override void OnInit()
        {
            NetModule NetModule = Sys.GetFacade().RetrieveModule<NetModule>("NetWorkProxy");
            NetModuleGrid  = Sys.GetFacade().RetrieveModule<NetModule>("NetWorkProxy");
            NetModule.RegisterNetHandle("Net_Heartbeat", Net_Heartbeat_Handle);//当收到网络消息的时候会执行 这个函数  
        } 
        public void RequestOne()
        {
            NetModule NetModule = Sys.GetFacade().RetrieveModule<NetModule>("NetWorkProxy");
            NetModule.NetUtil.SendMessage("Net_Heartbeat");
        } 
        public void ReConnect()
        {
            ResetHeartbeatData();
        }
        public void Net_Heartbeat_Handle(MessageStruct data)
        {
            ServerTimeDifference = data.param4 * 10000 - (DateTime.Now.Ticks - new DateTime(1970, 1, 1, 8, 0, 0).Ticks)  ;
            ResetHeartbeatData();
            //MonoBehaviour.print(DateTime.Now.Ticks / 10000  + " Receive "  + ServerTimeDifference / 10000);
        }    
        public void ResetHeartbeatData()
        {
            HeartbeatInterval = 10;//重置心跳间隔
            CanSendHeartbeat = true;
        }
        public void Tick(double tick)
        {
            if (!NetModuleGrid.IsConnect())
                return;
            //网络必须连接才会进行发送

            HeartbeatInterval -= tick;
            if( HeartbeatInterval <= HeartbeatTime && CanSendHeartbeat)
            {
                CanSendHeartbeat = false;
                RequestOne();//发送心跳包  
                //MonoBehaviour.print(DateTime.Now.Ticks / 10000 + " Send");
            }
            else if(HeartbeatInterval <= DisConnectHeartbeatTime)
            { 
               NetModuleGrid.DisConnect();//直接断开网络 
            } 
        }

    }
} 