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
    public class SystemModule : ModuleCell
    {
        //���ڴ洢ϵͳ�б��С����
        private JsonArray SystemList = new JsonArray();
        public JsonArray SysList {get{ return SystemList; }}  
        public SystemModule()
        {
        }
        public override void OnInit()
        {
            NetModule NetModule = Sys.GetFacade().RetrieveModule<NetModule>("NetWorkProxy"); 
            NetModule.RegisterNetHandle("Net_RequestSystemList", Net_RequestSystemListHandle);//���յ�������Ϣ��ʱ���ִ�� ������� 
            NetModule.RegisterNetHandle("Net_LoginSystem", Net_LoginSystem_Handle);//���յ�������Ϣ��ʱ���ִ�� �������   
        }

        public void RequestSystemInfo()
        {
            NetModule NetModule = Sys.GetFacade().RetrieveModule<NetModule>("NetWorkProxy");
            NetModule.NetUtil.SendMessage("Net_RequestSystemList");
        } 
        public void EnterSystem(int id)
        {
            NetModule NetModule = Sys.GetFacade().RetrieveModule<NetModule>("NetWorkProxy");
            NetModule.NetUtil.SendMessage("Net_LoginSystem", id);
        }

        public void Net_Heartbeat_Handle(MessageStruct data)
        { 
            DateTime systemTime = new DateTime(1970, 1, 1,6,0,0 ).AddMilliseconds(data.param4);
            long differenceValue = ((DateTime.Now.Ticks - new DateTime(1970, 1, 1, 8, 0, 0).Ticks) / 10000) - data.param4;
            MonoBehaviour.print(differenceValue);
            Sys.GetFacade().NotifyObserver("SystemTimeDifferenceValue", differenceValue);
        }   
            public void Net_RequestSystemListHandle(MessageStruct data)
        { 
            JsonValue hallInfo = LightJson.Serialization.JsonReader.Parse(data.data); 
            if (!hallInfo.IsJsonArray)
            {
                Debug.LogWarning("Net_RequestSystemListHandle ��Ϣ���ݴ�����");
                return;
            }
            SystemList = hallInfo.AsJsonArray; 
            //foreach(var cell in jsonCell)
            //{
            //   SystemList.Add(cell["id"].AsInteger, cell);
            //}
            //�յ�������Ϣ�󣬴�ϵͳ������  
            Sys.GetFacade().NotifyObserver("RefreshSystemMainUI");
        }
       
        public void Net_LoginSystem_Handle(MessageStruct data)
        {
            int status = data.param1;
            int systemID = data.param2;
            if (status != 0 )
            {
                if (status == -1){
                    MonoBehaviour.print("��ɫҪ�����ϵͳ������:" + systemID);
                    return;
                } else if (status == -4)  { 
                    MonoBehaviour.print("�ظ�����ϵͳ:" + systemID);
                } else {
                    MonoBehaviour.print("����ʧ��");
                    return;
                }
            }
            MonoBehaviour.print("������ϵͳ" + systemID);
            //�յ�������Ϣ�󣬴�ϵͳ������
            Sys.GetFacade().NotifyObserver(SystemJoinNotify.GetSystemMsg[systemID]);
        }


    }
} 