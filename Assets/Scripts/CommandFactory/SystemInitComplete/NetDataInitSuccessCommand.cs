using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
namespace CommandSpace
{
    public class NetDataInitSuccessCommand : Command
    { 
        public override void Excute(Notifycation data)
        {
            //打开用户信息界面 
            Sys.GetFacade().NotifyObserver("OpenPlayerInfomationLayer");//打开玩家信息界面
            Sys.GetFacade().NotifyObserver("OepnTimeLayer");//打开时间
            Sys.GetFacade().NotifyObserver("OepnSystemMainUI");//发送一个添加Window的通知消息  
        }
    }
}
