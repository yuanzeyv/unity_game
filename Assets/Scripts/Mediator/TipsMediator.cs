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
        protected override void OepnLayer(Notifycation param, params object[] paramList)
        {
            Transform resource = Resources.Load<Transform>("UIResource/CanvasPrefab/TipsLayer/TipsLayer");//Ѱ��һ���ڵ�
            if (!resource) return;
            Window = UnityEngine.Object.Instantiate<Transform>(resource);
            Sys.GetFacade().NotifyObserver("AdditionCanvasObject",this, Window, CanvasNodeIndex.CENTER);//����һ�����Window��֪ͨ��Ϣ 
        }

<<<<<<< HEAD
        protected override void CloseLayer(Notifycation param)
        { 
=======
        protected override void CloseLayer(Notifycation param, params object[] paramList)
        {
>>>>>>> b23e7a4f415aa4e1e531cb8433c539ec3ab83bb1
            GameObject.Destroy(Window);//���ٶ���
            Window = null; 
        }
        protected override void RefreshLayer(Notifycation param, params object[] paramList)
        {
            if (Window == null)
                return;
            LayerBase Script  = Window.GetComponent<LayerBase>();
            Script.RefreshAssignLayer(0,param.GetData<string>(1));
        }

    }
}