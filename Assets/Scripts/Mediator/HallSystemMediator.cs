using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using LayerSpace;
using ProxySpace;
namespace MediatorSpace
{
<<<<<<< HEAD
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
=======
    public class HallSystemMediator : Mediator
    {
        Transform MajorWindow;
        MainWindowProxy MajorWindowScript;
        public HallSystemMediator()
        {
            AddHandle("OepnTipsWindowLayerUI", OepnLayer);
            AddHandle("CloseTipsWindowLayerUI", CloseLayer);
            AddHandle("RefreshTipsWindowLayerUI", RefreshLayer);
            AddHandle("MouseState", MouseChangeHandle);
            AddHandle("KeyState", KeyChangeHandle);
        }

        protected void OepnLayer(Notifycation param, params object[] list)
        {
            if (MajorWindow)
                return;
            Transform majorWindow = Resources.Load<Transform>("UIResource/CanvasPrefab/WindowBaseLayer/WindowBase");//Ѱ��һ���ڵ�
            if (!majorWindow) return;
            MajorWindow = UnityEngine.Object.Instantiate<Transform>(majorWindow);
            MajorWindowScript = MajorWindow.GetComponent<MainWindowProxy>();
            MajorWindowScript.InitLayer("UIResource/CanvasPrefab/TipsPopWindow/TipsPopWindow", list);
            Sys.GetFacade().NotifyObserver("AdditionCanvasObject", new AddTypeStruct(CanvasNodeIndex.CENTER, MajorWindow));//����һ�����Window��֪ͨ��Ϣ
        }
        protected void KeyChangeHandle(Notifycation param, params object[] list)
        {
            if (!MajorWindow)
                return;
        }
        protected void MouseChangeHandle(Notifycation param, params object[] list)
        {
            if (!MajorWindow)
                return;
        }

        protected void CloseLayer(Notifycation param, params object[] paramList)
        {
            if (!MajorWindow)
                return;
            GameObject.Destroy(MajorWindow.gameObject);//���ٶ���
            MajorWindow = null;
            MajorWindowScript = null;
        }
        protected void RefreshLayer(Notifycation param, params object[] paramList)
        {
            if (MajorWindow == null)
                return;
            MajorWindowScript.RefreshAssignLayer(0, param.GetData<string>());
>>>>>>> b23e7a4f415aa4e1e531cb8433c539ec3ab83bb1
        }

    }
}