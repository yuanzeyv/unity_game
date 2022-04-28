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
            InitBaseNotify("OpenLoginUI", "CloseLoginUI");
        }
<<<<<<< HEAD
        protected override void OepnLayer(Notifycation param)
=======
        protected override void OepnLayer(Notifycation param, params object[] paramList)
>>>>>>> b23e7a4f415aa4e1e531cb8433c539ec3ab83bb1
        { 
            Transform resource = Resources.Load<Transform>("UIResource/CanvasPrefab/LoginLayer/LoginLayer");//Ѱ��һ���ڵ�
            if (!resource) return;
            Window = UnityEngine.Object.Instantiate<Transform>(resource);
            Sys.GetFacade().NotifyObserver("AdditionCanvasObject",  this, Window, CanvasNodeIndex.CENTER);//����һ�����Window��֪ͨ��Ϣ 
        } 
    }
}