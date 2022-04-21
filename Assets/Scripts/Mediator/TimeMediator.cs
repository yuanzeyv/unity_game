using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using LayerSpace;
using ProxySpace;
namespace MediatorSpace
{
    public class TimeMediator : BaseMediator
    { 
        public TimeMediator()
        {
            AddHandle("OepnTimeLayer", OepnLayer);
            AddHandle("CloseTimeLayer", CloseLayer);
            AddHandle("RefreshTimeLayer", RefreshLayer);
        }
        protected override void OepnLayer(Notifycation param)
        {
            Transform resource = Resources.Load<Transform>("UIResource/CanvasPrefab/TimeLayer/TimeLayer");//Ѱ��һ���ڵ�
            if (!resource) return;
            Window = UnityEngine.Object.Instantiate<Transform>(resource);
            Script = Window.GetComponent<LayerBase>();
            Sys.GetFacade().NotifyObserver("AdditionCanvasObject", new AddTypeStruct(CanvasNodeIndex.RIGHT_TOP, Window));//����һ�����Window��֪ͨ��Ϣ
        }

        protected override void CloseLayer(Notifycation param)
        {
            GameObject.Destroy(Window);//���ٶ���
            Window = null;
            Script = null;
        }
        protected override void RefreshLayer(Notifycation param)
        {
            if (Window == null)
                return;
            Script.RefreshLayer(param); 
        }

    }
}