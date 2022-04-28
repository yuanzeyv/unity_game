using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using LayerSpace;
using ProxySpace;
namespace MediatorSpace
{
    public class TipsMediator : BaseMediator
    {
        public TipsMediator()
        {
            InitBaseNotify("OepnTipsLayerUI", "CloseTipsLayerUI");
            AddHandle("RefreshTipsLayerUI", RefreshLayer);
        }
        protected override void OepnLayer(Notifycation param)
        {
            Transform resource = Resources.Load<Transform>("UIResource/CanvasPrefab/TipsLayer/TipsLayer");//寻找一个节点
            if (!resource) return;
            Window = UnityEngine.Object.Instantiate<Transform>(resource);
            Sys.GetFacade().NotifyObserver("AdditionCanvasObject",this, Window, CanvasNodeIndex.CENTER);//发送一个添加Window的通知消息 
        }
         
        protected override void CloseLayer(Notifycation param)
        {  
            GameObject.Destroy(Window);//销毁对象
            Window = null; 
        }
        protected override void RefreshLayer(Notifycation param)
        {
            if (Window == null)
                return;
            LayerBase Script  = Window.GetComponent<LayerBase>();
            Script.RefreshAssignLayer(0,param.GetData<string>(1));
        }

    }
}