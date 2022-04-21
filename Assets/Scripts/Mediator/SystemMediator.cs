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
        { 
            AddHandle("OepnSystemMainUI",   OepnLayer);
            AddHandle("CloseSystemMainUI",  CloseLayer);
            AddHandle("RefreshSystemMainUI",RefreshLayer);
        }
        protected override void OepnLayer(Notifycation param, params object[] paramList)
        {
            if (Window)
                return;
            Transform resource = Resources.Load<Transform>("UIResource/CanvasPrefab/SystemChooseLayer/SystemChooseLayer");//寻找一个节点
            if (!resource) return;
            Window = UnityEngine.Object.Instantiate<Transform>(resource);
            Script = Window.GetComponent<LayerBase>();
            Sys.GetFacade().NotifyObserver("AdditionCanvasObject", new AddTypeStruct(CanvasNodeIndex.CENTER, Window));//发送一个添加Window的通知消息
        } 
        protected override void RefreshLayer(Notifycation param, params object[] paramList)
        { 
            if (Window == null)
                return; 
            SystemLayer SystemLayerScript = Window.gameObject.GetComponent<SystemLayer>();//获取到 登录代理 
            SystemLayerScript.RefreshLayer();
        }
    }
}