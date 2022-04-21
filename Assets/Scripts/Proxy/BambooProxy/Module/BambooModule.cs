using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using MVCFrame;
using ProxySpace;
using Config.Program;
using LightJson;
namespace ModuleCellSpace
{
    public class BambooPlayer
    {
        public string UserID;
        public int HallAction;
        public int TableAction;
        public int GameStatus;
        public BambooTable TableInfo;
    }
    public class BambooSimplePlayer
    {
        public string UserID;
        public int HallAction;
        public int TableAction;
        public int GameStatus;
        public BambooTable TableInfo;
    }

    public class BambooTable
    {
        public int MaxPlayerCount;
        public int MaxGameCount;
        public int NeedPlayerToStartGame;
        public Dictionary<string, BambooPlayer> SitPlayerMap;
        public Dictionary<string, BambooPlayer> LookPlayerMap;
        public int IsStartGame;//�Ƿ��Ѿ���ʼ����Ϸ
    }
    public class BambooSimpleTable
    {
        public Dictionary<string, BambooPlayer> SitPlayerMap;
        public int IsStartGame;//�Ƿ��Ѿ���ʼ����Ϸ
    }

    public class BambooHall
    {
        public int HallID;
        public string HallName;
        public Dictionary<int, BambooSimpleTable> TableList; 
    } 

    public class BambooModule : ModuleCell
    {
        public Dictionary<int, string> HallInfoMap = new Dictionary<int, string>();
        public Dictionary<int, string> GetHallInfoMap { get{ return HallInfoMap ; } }
        public BambooModule()
        {
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
        public override void OnInit()
        {
            base.OnInit();
            NetModule netModule = Sys.GetFacade().RetrieveModule<NetModule>("NetWorkProxy");
            //���Ȼ�ȡ������ģ��
            netModule.RegisterNetHandle("Net_Request_HallList", Net_Request_HallList_Handle);//���յ�������Ϣ��ʱ���ִ�� �������
            netModule.RegisterNetHandle("Net_EnterHall", Net_Enter_Hall_Handle);//���յ�������Ϣ��ʱ���ִ�� �������
            netModule.RegisterNetHandle("Net_LeaveHall", Net_Leave_Hall_Handle);//���յ�������Ϣ��ʱ���ִ�� �������
            netModule.RegisterNetHandle("Net_EnterTable", Net_Enter_Table_Handle);//���յ�������Ϣ��ʱ���ִ�� �������
            netModule.RegisterNetHandle("Net_LeaveTable", Net_Leave_Table_Handle);//���յ�������Ϣ��ʱ���ִ�� �������
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
                var hallName = cell["hallName"].AsString; 
                HallInfoMap[hallID] = hallName;
            }
            Sys.GetFacade().NotifyObserver("RefreashBambooHallChooseLayer");//����һ�����Window��֪ͨ��Ϣ
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