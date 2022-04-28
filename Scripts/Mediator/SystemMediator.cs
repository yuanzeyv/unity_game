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
            InitBaseNotify("OepnSystemMainUI", "CloseSystemMainUI");
            AddHandle("RefreshSystemMainUI",RefreshLayer);
        }
        protected override void OepnLayer(Notifycation param) 
        {
            if (Window)
                return;
            Transform resource = Resources.Load<Transform>("UIResource/CanvasPrefab/SystemChooseLayer/SystemChooseLayer");//寻找一个节点
            if (!resource) return;
            Window = UnityEngine.Object.Instantiate<Transform>(resource); 
            Sys.GetFacade().NotifyObserver("AdditionCanvasObject", this, Window, CanvasNodeIndex.CENTER);//发送一个添加Window的通知消息 
        } 
        protected override void RefreshLayer(Notifycation param)
        { 
            if (Window == null)
                return;  
            LayerBase Script = Window.GetComponent<LayerBase>();
            Script.RefreshAssignLayer(0, param.GetData<string>(1)); 
        }
    }
}