using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
namespace CommandSpace
{
    public class NetDisconnectSuccess : Command
    {
        public override void Excute(Notifycation data)
        {
            MonoBehaviour.print("与服务器断开连接");
            Sys.GetFacade().NotifyObserver("RefreshTipsLayerUI", "与服务器断开连接");
        }
    }
} 
