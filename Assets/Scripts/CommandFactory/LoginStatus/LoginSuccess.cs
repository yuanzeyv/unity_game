using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using ProxySpace;
using ModuleCellSpace;
using UnityEngine.Events;
namespace CommandSpace
{
    public class LoginSuccess : Command
    {
        public override void Excute(Notifycation data)
        {
            //删除登录信息
            //NetModule netModule = Sys.GetFacade().RetrieveModule<NetModule>("NetWorkProxy");
            //string userName = data.GetData<string>();
            //netModule.InitSocketPort(8889, "39.103.201.92", userName);
            //bool isSucces = netModule.Connect();//连接并且我需要一个连接的返回
            //if (!isSucces)
            //{
            //    UnityAction func = new UnityAction(() => {
            //        NetModule netModule = Sys.GetFacade().RetrieveModule<NetModule>("NetWorkProxy");
            //        netModule.Connect();
            //    });
            //    Sys.GetFacade().NotifyObserver("OepnTipsWindowLayerUI", "连接服务器失败了，是否重新连接？", "重新连接", func);//发送一个添加Window的通知消息   
            //    return;
            //}
        }
    }
}
