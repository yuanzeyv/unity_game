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
            bool isSucces = netModule.ConnectSocket(8889, "39.103.201.92",userName);//���Ӳ�������Ҫһ�����ӵķ���
            if (!isSucces)
            {
                Sys.GetFacade().NotifyObserver("RefreshTipsLayerUI", "���ӷ�����ʧ����");
                return;
            } 
            Sys.GetFacade().NotifyObserver("NetConnectSuccess");  
        }
    }
}
