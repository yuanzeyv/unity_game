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
        //用于存储系统列表的小玩意
        private Dictionary<int, string> SystemList = new Dictionary<int, string>();
        public Dictionary<int, string> SysList{get{return SystemList;}}  
        public SystemModule()
        {
        }
        public override void OnInit()
        {
            NetModule NetModule = Sys.GetFacade().RetrieveModule<NetModule>("NetWorkProxy"); 
            NetModule.RegisterNetHandle("Net_RequestSystem_S_C", NetMsgExecuteHandle);//当收到网络消息的时候会执行 这个函数 
            NetModule.RegisterNetHandle("Net_LoginSystem_S_C", Net_LoginSystem_Handle);//当收到网络消息的时候会执行 这个函数  
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
            //收到这条消息后，打开系统主界面  
            Sys.GetFacade().NotifyObserver("RefreshSystemMainUI");
        }
        public void Net_LoginSystem_Handle(MessageStruct data)
        {
            int status = data.param1;
            int systemID = data.param2;
            if (status != 0 )
            {
                if (status == -1){
                    MonoBehaviour.print("角色要登入的系统不存在:" + systemID);
                } else if (status == -4)  { 
                    MonoBehaviour.print("重复登入系统:" + systemID);
                } else {
                    MonoBehaviour.print("登入失败");
                }
                return;
            }
            MonoBehaviour.print("进入了系统" + systemID);
            //收到这条消息后，打开系统主界面
            Sys.GetFacade().NotifyObserver(SystemJoinNotify.GetSystemMsg[systemID]);
            //关闭当前系统窗口
            Sys.GetFacade().NotifyObserver("CloseSystemMainUI"); 
        }


    }
} 