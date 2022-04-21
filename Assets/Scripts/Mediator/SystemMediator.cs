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
        { 
            AddHandle("OepnSystemMainUI",   OepnLayer);
            AddHandle("CloseSystemMainUI",  CloseLayer);
            AddHandle("RefreshSystemMainUI",RefreshLayer);
        }
        protected override void OepnLayer(Notifycation param, params object[] paramList)
        {
            if (Window)
                return;
            Transform resource = Resources.Load<Transform>("UIResource/CanvasPrefab/SystemChooseLayer/SystemChooseLayer");//Ѱ��һ���ڵ�
            if (!resource) return;
            Window = UnityEngine.Object.Instantiate<Transform>(resource);
            Script = Window.GetComponent<LayerBase>();
            Sys.GetFacade().NotifyObserver("AdditionCanvasObject", new AddTypeStruct(CanvasNodeIndex.CENTER, Window));//����һ�����Window��֪ͨ��Ϣ
        } 
        protected override void RefreshLayer(Notifycation param, params object[] paramList)
        { 
            if (Window == null)
                return; 
            SystemLayer SystemLayerScript = Window.gameObject.GetComponent<SystemLayer>();//��ȡ�� ��¼���� 
            SystemLayerScript.RefreshLayer();
        }
    }
}