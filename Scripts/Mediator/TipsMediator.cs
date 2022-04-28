using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using LayerSpace;
using ProxySpace;
namespace MediatorSpace
{
    public class TipsMediator : BaseMediator
    {
        public TipsMediator()
        {
            InitBaseNotify("OepnTipsLayerUI", "CloseTipsLayerUI");
            AddHandle("RefreshTipsLayerUI", RefreshLayer);
        }
        protected override void OepnLayer(Notifycation param)
        {
            Transform resource = Resources.Load<Transform>("UIResource/CanvasPrefab/TipsLayer/TipsLayer");//Ѱ��һ���ڵ�
            if (!resource) return;
            Window = UnityEngine.Object.Instantiate<Transform>(resource);
            Sys.GetFacade().NotifyObserver("AdditionCanvasObject",this, Window, CanvasNodeIndex.CENTER);//����һ�����Window��֪ͨ��Ϣ 
        }
         
        protected override void CloseLayer(Notifycation param)
        {  
            GameObject.Destroy(Window);//���ٶ���
            Window = null; 
        }
        protected override void RefreshLayer(Notifycation param)
        {
            if (Window == null)
                return;
            LayerBase Script  = Window.GetComponent<LayerBase>();
            Script.RefreshAssignLayer(0,param.GetData<string>(1));
        }

    }
}