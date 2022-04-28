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
<<<<<<< HEAD
        { 
            InitBaseNotify("OpenPlayerInfomationLayer", "ClosePlayerInfomationLayer");
=======
        {
            AddHandle("OpenPlayerInfomationLayer",    OepnLayer);
            AddHandle("ClosePlayerInfomationLayer",   CloseLayer);
>>>>>>> b23e7a4f415aa4e1e531cb8433c539ec3ab83bb1
            AddHandle("RefreshPlayerInfomationLayer", RefreshLayer);
            AddHandle("PuskKey", KeyChangeHandle);
        }
        protected void KeyChangeHandle(Notifycation param)
        { 
            var KeyMap = param.GetData<Dictionary<KeyCode, float>>(1);
            if (KeyMap.ContainsKey(KeyCode.Mouse0))
            {
                MonoBehaviour.print("�ɿ���ʱ�� " + KeyMap[KeyCode.Mouse0]);
                //Sys.GetFacade().NotifyObserver("ExitLoginSuccess");
            }
        }
        protected override void OepnLayer(Notifycation param, params object[] paramList)
        { 
            Transform resource = Resources.Load<Transform>("UIResource/CanvasPrefab/PlayerInfomationPanel/PlayerInfomationPanel");//Ѱ��һ���ڵ�
            if (!resource) return;
            Window = UnityEngine.Object.Instantiate<Transform>(resource);
            Sys.GetFacade().NotifyObserver("AdditionCanvasObject",this,Window,CanvasNodeIndex.LEFT_TOP);//����һ�����Window��֪ͨ��Ϣ
        } 
        protected override void RefreshLayer(Notifycation param, params object[] paramList)
        {
            if (Window == null)
                return;
<<<<<<< HEAD
            //PlayerInfomationLayer SystemLayerScript = Window.gameObject.GetComponent<PlayerInfomationLayer>();//��ȡ�� ��¼���� 
            //SystemLayerScript.RefreshLayer();
            LayerBase Script = Window.GetComponent<LayerBase>();
            Script.RefreshAssignLayer(0, param.GetData<string>(1));
=======
            PlayerInfomationLayer SystemLayerScript = Window.gameObject.GetComponent<PlayerInfomationLayer>();//��ȡ�� ��¼���� 
            SystemLayerScript.RefreshLayer();
>>>>>>> b23e7a4f415aa4e1e531cb8433c539ec3ab83bb1
        }

    }
}