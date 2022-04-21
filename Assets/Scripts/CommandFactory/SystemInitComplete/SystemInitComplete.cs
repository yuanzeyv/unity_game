using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
namespace CommandSpace
{
    public class SystemInitComplete : Command
    {
        public override void Excute(Notifycation data)
        {
            Sys.GetFacade().UnRegisterProxy("InitPorxy");//初始化完毕后删除当前代理 
            //打开登录界面 
            Sys.GetFacade().NotifyObserver("OepnTipsLayerUI");//发送一个添加Window的通知消息
            Sys.GetFacade().NotifyObserver("OpenLoginUI");//发送一个添加Window的通知消息
        }
    }
} 
