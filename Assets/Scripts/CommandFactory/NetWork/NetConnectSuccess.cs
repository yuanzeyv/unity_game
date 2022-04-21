using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using ModuleCellSpace;
namespace CommandSpace
{  
    public class NetConnectSuccess : Command
    {
        public override void Excute(Notifycation data)
        {

            Sys.GetFacade().RetrieveModule<TimeModule>("SystemServiceProxy").ReConnect(); 
            Sys.GetFacade().NotifyObserver("CloseTipsWindowLayerUI"); //关闭所有提示面板 
        }
    } 
}