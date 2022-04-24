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
        //获取到指定ID的界面数据
        public JsonValue GetHallCellInfo(int id )
        {
            if (!HallInfoMap.ContainsKey(id))
                return JsonValue.Null;
            return HallInfoMap[id];
        }
        //请求一下当前的大厅界面
        public void RequestHallList()
        {
            NetModule netModule = Sys.GetFacade().RetrieveModule<NetModule>("NetWorkProxy");
            netModule.NetUtil.SendMessage("Net_Request_HallList"); 
        }
        //请求一下当前的大厅界面
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
            //首先获取到网络模块
            netModule.RegisterNetHandle("Net_Request_HallList", Net_Request_HallList_Handle);
            netModule.RegisterNetHandle("Net_EnterHall", Net_Enter_Hall_Handle);
            netModule.RegisterNetHandle("Net_LeaveHall", Net_Leave_Hall_Handle);
            netModule.RegisterNetHandle("Net_Request_HallInfo", Net_Request_HallInfo_Handle);//请求大厅下的所有桌子信息 
            netModule.RegisterNetHandle("Net_EnterTable", Net_Enter_Table_Handle);
            netModule.RegisterNetHandle("Net_LeaveTable", Net_Leave_Table_Handle);
            netModule.RegisterNetHandle("Net_PlayerUnready", Net_Player_SitDown_Handle);//当收到网络消息的时候会执行 这个函数
            netModule.RegisterNetHandle("Net_PlayerStand", Net_Player_StandUP_Handle);//当收到网络消息的时候会执行 这个函数
            netModule.RegisterNetHandle("Net_PlayerReady", Net_Player_Ready_Handle);//当收到网络消息的时候会执行 这个函数  
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
            Sys.GetFacade().NotifyObserver("RefreashBambooHallChooseLayer");//发送一个添加Window的通知消息
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
            Sys.GetFacade().NotifyObserver("RefreashBambooHallLayer");//发送一个添加Window的通知消息
        }
        public void Net_Enter_Hall_Handle(MessageStruct data)
        {
            if (data.param1 == -1)
            {
                MonoBehaviour.print("没有找到指定的大厅");
                return;
            }
            else if (data.param1 == -2)
            {
                MonoBehaviour.print("玩家已经进入过大厅了");
                return;
            }
            else if (data.param1 == -500)
            {
                MonoBehaviour.print("玩家很早以前就已经进入了大厅"); 
            }
            Sys.GetFacade().NotifyObserver("OepnBambooHallLayer");//发送一个添加Window的通知消息
            RequestHallInfo();//请求一下大厅数据
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