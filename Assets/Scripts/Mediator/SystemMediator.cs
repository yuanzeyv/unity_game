using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using LayerSpace;
using ProxySpace;
using System;
namespace MediatorSpace
{
    public class SystemMediator : BaseMediator
    { 
        public SystemMediator()
<<<<<<< HEAD
        {  
            InitBaseNotify("OepnSystemMainUI", "CloseSystemMainUI");
            AddHandle("RefreshSystemMainUI",RefreshLayer);
        }
        protected override void OepnLayer(Notifycation param)
=======
        { 
            AddHandle("OepnSystemMainUI",   OepnLayer);
            AddHandle("CloseSystemMainUI",  CloseLayer);
            AddHandle("RefreshSystemMainUI",RefreshLayer);
        }
        protected override void OepnLayer(Notifycation param, params object[] paramList)
>>>>>>> b23e7a4f415aa4e1e531cb8433c539ec3ab83bb1
        {
            if (Window)
                return;
            Transform resource = Resources.Load<Transform>("UIResource/CanvasPrefab/SystemChooseLayer/SystemChooseLayer");//寻找一个节点
            if (!resource) return;
            Window = UnityEngine.Object.Instantiate<Transform>(resource);
<<<<<<< HEAD
            Sys.GetFacade().NotifyObserver("AdditionCanvasObject", this, Window, CanvasNodeIndex.CENTER);//发送一个添加Window的通知消息 
        } 
        protected override void RefreshLayer(Notifycation param)
        { 
            if (Window == null)
                return;  
            LayerBase Script = Window.GetComponent<LayerBase>();
            Script.RefreshAssignLayer(0, param.GetData<string>(1));
=======
            Script = Window.GetComponent<LayerBase>();
            Sys.GetFacade().NotifyObserver("AdditionCanvasObject", new AddTypeStruct(CanvasNodeIndex.CENTER, Window));//发送一个添加Window的通知消息
        } 
        protected override void RefreshLayer(Notifycation param, params object[] paramList)
        { 
            if (Window == null)
                return; 
            SystemLayer SystemLayerScript = Window.gameObject.GetComponent<SystemLayer>();//获取到 登录代理 
            SystemLayerScript.RefreshLayer();
>>>>>>> b23e7a4f415aa4e1e531cb8433c539ec3ab83bb1
        }
    }
}