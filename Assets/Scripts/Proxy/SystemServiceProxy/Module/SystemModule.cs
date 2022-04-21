using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LightJson;
using MVCFrame;
using Config.Program;
using ProxySpace;
namespace ModuleCellSpace
{
    public class SystemModule : ModuleCell
    {
        //���ڴ洢ϵͳ�б��С����
        private Dictionary<int, string> SystemList = new Dictionary<int, string>();
        public Dictionary<int, string> SysList{get{return SystemList;}}  
        public SystemModule()
        {
        }
        public override void OnInit()
        {
            NetModule NetModule = Sys.GetFacade().RetrieveModule<NetModule>("NetWorkProxy"); 
            NetModule.RegisterNetHandle("Net_RequestSystem_S_C", NetMsgExecuteHandle);//���յ�������Ϣ��ʱ���ִ�� ������� 
            NetModule.RegisterNetHandle("Net_LoginSystem_S_C", Net_LoginSystem_Handle);//���յ�������Ϣ��ʱ���ִ�� �������  
        }

        public void RequestSystemInfo()
        { 
            NetModule NetModule = Sys.GetFacade().RetrieveModule<NetModule>("NetWorkProxy");
            NetModule.NetUtil.SendMessage("Net_RequestSystem");
        }
        public void EnterSystem(int id)
        {
            NetModule NetModule = Sys.GetFacade().RetrieveModule<NetModule>("NetWorkProxy");
            NetModule.NetUtil.SendMessage("Net_LoginSystem", id);
        }

        public void NetMsgExecuteHandle(MessageStruct data)
        { 
            JsonValue hallInfo = LightJson.Serialization.JsonReader.Parse(data.data);
            var jsonCell = hallInfo.AsJsonArray;
            foreach (var cell in jsonCell)
            {
                SystemList.Add(cell["id"].AsInteger, cell["name"]);
            }
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
                } else if (status == -4)  { 
                    MonoBehaviour.print("�ظ�����ϵͳ:" + systemID);
                } else {
                    MonoBehaviour.print("����ʧ��");
                }
                return;
            }
            MonoBehaviour.print("������ϵͳ" + systemID);
            //�յ�������Ϣ�󣬴�ϵͳ������
            Sys.GetFacade().NotifyObserver(SystemJoinNotify.GetSystemMsg[systemID]);
            //�رյ�ǰϵͳ����
            Sys.GetFacade().NotifyObserver("CloseSystemMainUI"); 
        }


    }
} 