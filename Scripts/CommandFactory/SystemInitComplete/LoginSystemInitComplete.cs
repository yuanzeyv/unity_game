using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
namespace CommandSpace
{
    public class LoginSystemInitComplete : Command
    {
        public override void Excute(Notifycation data)
        {
            Sys.GetFacade().NotifyObserver("OepnTipsLayerUI");//发送一个添加Window的通知消息
            Sys.GetFacade().NotifyObserver("OpenLoginUI");//发送一个添加Window的通知消息
        }
    }
} 
