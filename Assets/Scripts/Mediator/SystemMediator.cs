using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using LayerSpace;
using ProxySpace;
using System;
namespace MediatorSpace
{
    public class SystemMediator : BaseMediator
    { 
        public SystemMediator()
<<<<<<< HEAD
        {  
            InitBaseNotify("OepnSystemMainUI", "CloseSystemMainUI");
            AddHandle("RefreshSystemMainUI",RefreshLayer);
        }
        protected override void OepnLayer(Notifycation param)
=======
        { 
            AddHandle("OepnSystemMainUI",   OepnLayer);
            AddHandle("CloseSystemMainUI",  CloseLayer);
            AddHandle("RefreshSystemMainUI",RefreshLayer);
        }
        protected override void OepnLayer(Notifycation param, params object[] paramList)
>>>>>>> b23e7a4f415aa4e1e531cb8433c539ec3ab83bb1
        {
            if (Window)
                return;
            Transform resource = Resources.Load<Transform>("UIResource/CanvasPrefab/SystemChooseLayer/SystemChooseLayer");//Ѱ��һ���ڵ�
            if (!resource) return;
            Window = UnityEngine.Object.Instantiate<Transform>(resource);
<<<<<<< HEAD
            Sys.GetFacade().NotifyObserver("AdditionCanvasObject", this, Window, CanvasNodeIndex.CENTER);//����һ�����Window��֪ͨ��Ϣ 
        } 
        protected override void RefreshLayer(Notifycation param)
        { 
            if (Window == null)
                return;  
            LayerBase Script = Window.GetComponent<LayerBase>();
            Script.RefreshAssignLayer(0, param.GetData<string>(1));
=======
            Script = Window.GetComponent<LayerBase>();
            Sys.GetFacade().NotifyObserver("AdditionCanvasObject", new AddTypeStruct(CanvasNodeIndex.CENTER, Window));//����һ�����Window��֪ͨ��Ϣ
        } 
        protected override void RefreshLayer(Notifycation param, params object[] paramList)
        { 
            if (Window == null)
                return; 
            SystemLayer SystemLayerScript = Window.gameObject.GetComponent<SystemLayer>();//��ȡ�� ��¼���� 
            SystemLayerScript.RefreshLayer();
>>>>>>> b23e7a4f415aa4e1e531cb8433c539ec3ab83bb1
        }
    }
}