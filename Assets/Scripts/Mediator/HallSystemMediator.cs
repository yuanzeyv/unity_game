using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using LayerSpace;
using ProxySpace;
namespace MediatorSpace
{
    public class HallSystemMediator : BaseMediator
    {  
        public HallSystemMediator()
        {
            InitBaseNotify("OepnTipsWindowLayerUI", "CloseTipsWindowLayerUI");
            AddHandle("RefreshTipsWindowLayerUI", RefreshLayer); 
        }

        override protected void OepnLayer(Notifycation param)
        {
            if (Window)
                return;
            Transform WindowPrototype = Resources.Load<Transform>("UIResource/CanvasPrefab/WindowBaseLayer/WindowBase");//Ѱ��һ���ڵ�
            if (!WindowPrototype) return;
            Window = UnityEngine.Object.Instantiate<Transform>(WindowPrototype);
            MainWindowProxy WindowScript = Window.GetComponent<MainWindowProxy>();
            WindowScript.InitLayer("UIResource/CanvasPrefab/TipsPopWindow/TipsPopWindow", param);
            Sys.GetFacade().NotifyObserver("AdditionCanvasObject",  this, Window, CanvasNodeIndex.CENTER);//����һ�����Window��֪ͨ��Ϣ 
        }
        protected void MouseChangeHandle(Notifycation param)
        {
            if (!Window)
                return;
        }

       override protected void CloseLayer(Notifycation param)
        {
            if (!Window)
                return;
            GameObject.Destroy(Window.gameObject);//���ٶ���
            Window = null;
        }
        override protected void RefreshLayer(Notifycation param)
        {
            if (Window == null)
                return;
            MainWindowProxy WindowScript = Window.GetComponent<MainWindowProxy>();
            WindowScript.RefreshAssignLayer(0, param.GetData<string>(1));
        }

    }
}