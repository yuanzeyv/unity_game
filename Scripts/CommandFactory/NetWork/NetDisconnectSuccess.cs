using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using UnityEngine.Events;
using ModuleCellSpace;
namespace CommandSpace
{
    public class NetDisconnectSuccess : Command
    {
        public override void Excute(Notifycation data)
        {

            UnityAction func = new UnityAction(() => {
                NetModule netModule = Sys.GetFacade().RetrieveModule<NetModule>("NetWorkProxy");
                netModule.Connect();
            }); 
            Sys.GetFacade().NotifyObserver("OepnTipsWindowLayerUI", "已经与服务器断开了连接，是否重连？", "重新连接", func);//发送一个添加Window的通知消息   
        }
    }
} 
