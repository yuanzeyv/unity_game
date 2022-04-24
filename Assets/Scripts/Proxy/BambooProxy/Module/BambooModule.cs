using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using MVCFrame;
using ProxySpace;
using Config.Program;
using LightJson;
namespace ModuleCellSpace
{ 
    public class BambooModule : ModuleCell
    {
        public Dictionary<int, JsonValue> HallInfoMap = new Dictionary<int, JsonValue>();
        public Dictionary<int, JsonValue> GetHallInfoMap { get { return HallInfoMap; } }

        public Dictionary<int, JsonValue> TableInfoMap = new Dictionary<int, JsonValue>();
        public Dictionary<int, JsonValue> GetTableInfoMap { get { return TableInfoMap; } }
        public BambooModule()
        {
        }
        //��ȡ��ָ��ID�Ľ�������
        public JsonValue GetHallCellInfo(int id )
        {
            if (!HallInfoMap.ContainsKey(id))
                return JsonValue.Null;
            return HallInfoMap[id];
        }
        //����һ�µ�ǰ�Ĵ�������
        public void RequestHallList()
        {
            NetModule netModule = Sys.GetFacade().RetrieveModule<NetModule>("NetWorkProxy");
            netModule.NetUtil.SendMessage("Net_Request_HallList"); 
        }
        //����һ�µ�ǰ�Ĵ�������
        public void RequestEnterHall(int hallIndex)
        {
            NetModule netModule = Sys.GetFacade().RetrieveModule<NetModule>("NetWorkProxy");
            netModule.NetUtil.SendMessage("Net_EnterHall", hallIndex);
        }
        public void RequestHallInfo()
        {
            NetModule netModule = Sys.GetFacade().RetrieveModule<NetModule>("NetWorkProxy");
            netModule.NetUtil.SendMessage("Net_Request_HallInfo");
        } 
        
        public override void OnInit()
        {
            base.OnInit();
            NetModule netModule = Sys.GetFacade().RetrieveModule<NetModule>("NetWorkProxy");
            //���Ȼ�ȡ������ģ��
            netModule.RegisterNetHandle("Net_Request_HallList", Net_Request_HallList_Handle);
            netModule.RegisterNetHandle("Net_EnterHall", Net_Enter_Hall_Handle);
            netModule.RegisterNetHandle("Net_LeaveHall", Net_Leave_Hall_Handle);
            netModule.RegisterNetHandle("Net_Request_HallInfo", Net_Request_HallInfo_Handle);//��������µ�����������Ϣ 
            netModule.RegisterNetHandle("Net_EnterTable", Net_Enter_Table_Handle);
            netModule.RegisterNetHandle("Net_LeaveTable", Net_Leave_Table_Handle);
            netModule.RegisterNetHandle("Net_PlayerUnready", Net_Player_SitDown_Handle);//���յ�������Ϣ��ʱ���ִ�� �������
            netModule.RegisterNetHandle("Net_PlayerStand", Net_Player_StandUP_Handle);//���յ�������Ϣ��ʱ���ִ�� �������
            netModule.RegisterNetHandle("Net_PlayerReady", Net_Player_Ready_Handle);//���յ�������Ϣ��ʱ���ִ�� �������  
        }
        public void Net_Request_HallList_Handle(MessageStruct data)
        {
            JsonValue hallInfo = LightJson.Serialization.JsonReader.Parse(data.data);
            var jsonCell = hallInfo.AsJsonArray;
            foreach (var cell in jsonCell)
            {
                var hallID = cell["hallID"].AsInteger;
                HallInfoMap[hallID] = cell;
            }
            Sys.GetFacade().NotifyObserver("RefreashBambooHallChooseLayer");//����һ�����Window��֪ͨ��Ϣ
        }
        public void Net_Request_HallInfo_Handle(MessageStruct data)
        {
            JsonValue hallInfo = LightJson.Serialization.JsonReader.Parse(data.data);
            var jsonCell = hallInfo.AsJsonArray;
            foreach (var cell in jsonCell)
            {
                var tableID = cell.AsJsonArray[4];
                TableInfoMap[tableID] = cell;
            }
            Sys.GetFacade().NotifyObserver("RefreashBambooHallLayer");//����һ�����Window��֪ͨ��Ϣ
        }
        public void Net_Enter_Hall_Handle(MessageStruct data)
        {
            if (data.param1 == -1)
            {
                MonoBehaviour.print("û���ҵ�ָ���Ĵ���");
                return;
            }
            else if (data.param1 == -2)
            {
                MonoBehaviour.print("����Ѿ������������");
                return;
            }
            else if (data.param1 == -500)
            {
                MonoBehaviour.print("��Һ�����ǰ���Ѿ������˴���"); 
            }
            Sys.GetFacade().NotifyObserver("OepnBambooHallLayer");//����һ�����Window��֪ͨ��Ϣ
            RequestHallInfo();//����һ�´�������
        }
        public void Net_Leave_Hall_Handle(MessageStruct data)
        {
        }
        public void Net_Enter_Table_Handle(MessageStruct data)
        {
        }
        public void Net_Leave_Table_Handle(MessageStruct data)
        {
        }
        public void Net_Player_SitDown_Handle(MessageStruct data)
        {
        }
        public void Net_Player_StandUP_Handle(MessageStruct data)
        {
        }
        public void Net_Player_Ready_Handle(MessageStruct data)
        {
        }
    }
}  