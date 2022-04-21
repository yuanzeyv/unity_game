using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using LayerSpace;
using ProxySpace;
namespace MediatorSpace
{
    public class PlayerInfomationMediator : BaseMediator
    { 
        public PlayerInfomationMediator()
        {
            AddHandle("OpenPlayerInfomationLayer",    OepnLayer);
            AddHandle("ClosePlayerInfomationLayer",   CloseLayer);
            AddHandle("RefreshPlayerInfomationLayer", RefreshLayer);
        }
        protected override void OepnLayer(Notifycation param, params object[] paramList)
        { 
            Transform resource = Resources.Load<Transform>("UIResource/CanvasPrefab/PlayerInfomationPanel/PlayerInfomationPanel");//寻找一个节点
            if (!resource) return;
            Window = UnityEngine.Object.Instantiate<Transform>(resource);
            Script = Window.GetComponent<LayerBase>();
            Sys.GetFacade().NotifyObserver("AdditionCanvasObject", new AddTypeStruct(CanvasNodeIndex.LEFT_TOP, Window));//发送一个添加Window的通知消息
        } 
        protected override void RefreshLayer(Notifycation param, params object[] paramList)
        {
            if (Window == null)
                return;
            PlayerInfomationLayer SystemLayerScript = Window.gameObject.GetComponent<PlayerInfomationLayer>();//获取到 登录代理 
            SystemLayerScript.RefreshLayer();
        }

    }
}