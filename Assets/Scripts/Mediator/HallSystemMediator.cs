using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using LayerSpace;
using ProxySpace;
namespace MediatorSpace
{
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
        }

    }
}