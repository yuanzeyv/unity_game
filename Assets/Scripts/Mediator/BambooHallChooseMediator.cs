using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using LayerSpace;
using ProxySpace;
namespace MediatorSpace
{
    public class BambooHallChooseMediator : BaseMediator
    { 
        public BambooHallChooseMediator()
        {
            InitBaseNotify("OepnBambooHallChooseLayer", "CloseBambooHallChooseLayer");
            AddHandle("RefreashBambooHallChooseLayer", RefreshLayer); 

        } 
        protected override void OepnLayer(Notifycation param)
        {
            if (Window)
                return;
            Transform WindowPrototype = Resources.Load<Transform>("UIResource/CanvasPrefab/WindowBaseLayer/WindowBase");//Ѱ��һ���ڵ�
            if (!WindowPrototype) return;
            Window = UnityEngine.Object.Instantiate<Transform>(WindowPrototype);
            MainWindowProxy WindowScript = Window.GetComponent<MainWindowProxy>();
            WindowScript.InitLayer("UIResource/CanvasPrefab/Bamboo/System/BambooSystem", param);
            Sys.GetFacade().NotifyObserver("AdditionCanvasObject", this, Window, CanvasNodeIndex.CENTER);//����һ�����Window��֪ͨ��Ϣ  
        }
        protected void KeyChangeHandle(Notifycation param, params object[] list)
        {
            if (!Window)
                return;
        }
        protected void MouseChangeHandle(Notifycation param, params object[] list)
        {
            if (!Window)
                return;
        }

        protected override void CloseLayer(Notifycation param)
        {
            if (!Window)
                return;
            GameObject.Destroy(Window.gameObject);//���ٶ���
            Window = null; 
        } 
        protected override void RefreshLayer(Notifycation param )
        {
            if (Window == null)
                return;
            MainWindowProxy WindowScript = Window.GetComponent<MainWindowProxy>();
            WindowScript.RefreshLayer(param);
        }
    }
}