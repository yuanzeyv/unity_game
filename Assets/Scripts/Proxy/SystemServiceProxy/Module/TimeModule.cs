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
        double HeartbeatTime = 5;//ÿ�����ӷ���һ������
        double DisConnectHeartbeatTime = 0;//����Ϣ������󣬾ͻ����
        bool CanSendHeartbeat = true;
        double HeartbeatInterval = 10;//����ʱ�� 
        NetModule NetModuleGrid = null;

        long ServerTimeDifference = 0;
        public DateTime ServerTime
        {
            get { 
                return DateTime.Now.AddTicks(ServerTimeDifference);
            }
        }//��ȡ����ǰ��ϵͳʱ��
        public TimeModule()
        {

        }
        public override void OnInit()
        {
            NetModule NetModule = Sys.GetFacade().RetrieveModule<NetModule>("NetWorkProxy");
            NetModuleGrid  = Sys.GetFacade().RetrieveModule<NetModule>("NetWorkProxy");
            NetModule.RegisterNetHandle("Net_Heartbeat", Net_Heartbeat_Handle);//���յ�������Ϣ��ʱ���ִ�� �������  
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
            HeartbeatInterval = 10;//�����������
            CanSendHeartbeat = true;
        }
        public void Tick(double tick)
        {
            if (!NetModuleGrid.IsConnect())
                return;
            //����������ӲŻ���з���

            HeartbeatInterval -= tick;
            if( HeartbeatInterval <= HeartbeatTime && CanSendHeartbeat)
            {
                CanSendHeartbeat = false;
                RequestOne();//����������  
                //MonoBehaviour.print(DateTime.Now.Ticks / 10000 + " Send");
            }
            else if(HeartbeatInterval <= DisConnectHeartbeatTime)
            { 
               NetModuleGrid.DisConnect();//ֱ�ӶϿ����� 
            } 
        }

    }
} 