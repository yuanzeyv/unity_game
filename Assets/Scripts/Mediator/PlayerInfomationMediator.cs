using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using LayerSpace;
using ProxySpace;
namespace MediatorSpace
{
    public class PlayerInfomationMediator : BaseMediator
    { 
        public PlayerInfomationMediator()
        {
            AddHandle("OpenPlayerInfomationLayer", OepnLayer);
            AddHandle("ClosePlayerInfomationLayer", CloseLayer);
            AddHandle("RefreshPlayerInfomationLayer", RefreshLayer);
        }
        protected override void OepnLayer(Notifycation param)
        { 
            Transform resource = Resources.Load<Transform>("UIResource/CanvasPrefab/PlayerInfomationPanel/PlayerInfomationPanel");//Ѱ��һ���ڵ�
            if (!resource) return;
            Window = UnityEngine.Object.Instantiate<Transform>(resource);
            Script = Window.GetComponent<LayerBase>();
            Sys.GetFacade().NotifyObserver("AdditionCanvasObject", new AddTypeStruct(CanvasNodeIndex.LEFT_TOP, Window));//����һ�����Window��֪ͨ��Ϣ
        } 
        protected override void RefreshLayer(Notifycation param)
        {
            if (Window == null)
                return;
            SystemLayer SystemLayerScript = Window.gameObject.GetComponent<SystemLayer>();//��ȡ�� ��¼���� 
            SystemLayerScript.UpdateLayer();
        }

    }
}