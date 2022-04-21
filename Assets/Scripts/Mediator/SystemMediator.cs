using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using LayerSpace;
using ProxySpace;
namespace MediatorSpace
{
    public class SystemMediator : BaseMediator
    { 
        public SystemMediator()
        { 
            AddHandle("OepnSystemMainUI", OepnSystemMainUIHandle);
            AddHandle("CloseSystemMainUI", CloseSystemMainUIIHandle);
            AddHandle("RefreshSystemMainUI", RefreshSystemMainUIHandle);
        }
        public virtual void OepnSystemMainUIHandle(Notifycation param)
        {   //获取到UICOntrolProxy的代理
           //UIControlProxy UIControlProxy = Sys.GetFacade().RetrieveProxy<UIControlProxy>();
           //Window = UIControlProxy.LoadLayer("SystemLayer/SystemLayer");//代理可以加载UI界面 
           //Script = Window.GetComponent<LayerBase>();
           //Sys.GetFacade().NotifyObserver("AdditionWindow", Window);//发送一个添加Window的通知消息
        }

        public virtual void CloseSystemMainUIIHandle(Notifycation param)
        {
            //关闭了当前的界面信息
            Sys.GetFacade().NotifyObserver("DeleteWindow", this.Name);//发送一个添加Window的通知消息
        }
        public virtual void RefreshSystemMainUIHandle(Notifycation param)
        {
            if (Window == null)
                return;
            SystemLayer SystemLayerScript = Window.gameObject.GetComponent<SystemLayer>();//获取到 登录代理 
            SystemLayerScript.UpdateLayer();
        }

    }
}