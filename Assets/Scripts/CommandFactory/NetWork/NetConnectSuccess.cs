using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
namespace CommandSpace
{  
    public class NetConnectSuccess : Command
    {
        public override void Excute(Notifycation data)
        { 
            //Sys.GetFacade().NotifyObserver("OepnSystemMainUI");
            //SystemServiceProxy SystemServiceProxy = Sys.GetFacade().RetrieveProxy<SystemServiceProxy>();
            //SystemServiceProxy.RetrieveModule<SystemModule>().RequestSystemInfo();
        }
    } 
}