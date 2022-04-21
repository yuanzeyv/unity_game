using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using LayerSpace;
using ProxySpace;
namespace MediatorSpace
{ 
    public class LoginMediator : BaseMediator
    { 
        public LoginMediator()
        {
            AddHandle("OpenLoginUI", OepnLayer);
            AddHandle("CloseLoginUI", CloseLayer);
        }
        protected override void OepnLayer(Notifycation param)
        {
            Transform resource = Resources.Load<Transform>("UIResource/CanvasPrefab/LoginLayer/LoginLayer");//Ѱ��һ���ڵ�
            if (!resource) return;
            Window = UnityEngine.Object.Instantiate<Transform>(resource);
            Script = Window.GetComponent<LayerBase>();
            Sys.GetFacade().NotifyObserver("AdditionCanvasObject", new AddTypeStruct(CanvasNodeIndex.CENTER, Window));//����һ�����Window��֪ͨ��Ϣ
        } 
    }
}