using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using LayerSpace;
using ProxySpace;
namespace MediatorSpace
{
    public class BambooHallMediator : Mediator
    {
        Transform MajorWindow;
        MainWindowProxy MajorWindowScript;
        public BambooHallMediator()
        {
            AddHandle("OepnBambooHallLayer", OepnLayer);
            AddHandle("CloseBambooHallLayer", CloseLayer);
            AddHandle("RefreashBambooHallLayer", RefreshLayer);
        }

        protected void OepnLayer(Notifycation param, params object[] list)
        {
            if (MajorWindow)
                return;
            Transform majorWindow = Resources.Load<Transform>("UIResource/CanvasPrefab/WindowBaseLayer/WindowBase");//寻找一个节点
            if (!majorWindow) return;
            MajorWindow = UnityEngine.Object.Instantiate<Transform>(majorWindow);
            MajorWindowScript = MajorWindow.GetComponent<MainWindowProxy>(); 
            MajorWindowScript.InitLayer("UIResource/CanvasPrefab/Bamboo/Hall/HallPanelLayer", list);
            Sys.GetFacade().NotifyObserver("AdditionCanvasObject", new AddTypeStruct(CanvasNodeIndex.CENTER, MajorWindow));//发送一个添加Window的通知消息
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
            GameObject.Destroy(MajorWindow.gameObject);//销毁对象
            MajorWindow = null;
            MajorWindowScript = null;
        }
        protected void RefreshLayer(Notifycation param, params object[] paramList)
        {
            if (MajorWindow == null)
                return;
            MajorWindowScript.RefreshLayer(paramList);
        }

    }
}