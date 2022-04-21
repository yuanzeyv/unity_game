using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using ProxySpace;
using ModuleCellSpace;
namespace CommandSpace
{
    public class LoginSuccess : Command
    {
        public override void Excute(Notifycation data)
        {
            NetModule netModule = Sys.GetFacade().RetrieveModule<NetModule>("NetWorkProxy"); 
            string userName = data.GetData<string>();
            bool isSucces = netModule.ConnectSocket(8889, "39.103.201.92",userName);//连接并且我需要一个连接的返回
            if (!isSucces)
            {
                Sys.GetFacade().NotifyObserver("RefreshTipsLayerUI", "连接服务器失败了");
                return;
            } 
            Sys.GetFacade().NotifyObserver("NetConnectSuccess");  
        }
    }
}
