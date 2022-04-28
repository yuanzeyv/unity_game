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
                MonoBehaviour.print("松开的时长 " + KeyMap[KeyCode.Mouse0]);
                //Sys.GetFacade().NotifyObserver("ExitLoginSuccess");
            }
        }
        protected override void OepnLayer(Notifycation param, params object[] paramList)
        { 
            Transform resource = Resources.Load<Transform>("UIResource/CanvasPrefab/PlayerInfomationPanel/PlayerInfomationPanel");//寻找一个节点
            if (!resource) return;
            Window = UnityEngine.Object.Instantiate<Transform>(resource);
            Sys.GetFacade().NotifyObserver("AdditionCanvasObject",this,Window,CanvasNodeIndex.LEFT_TOP);//发送一个添加Window的通知消息
        } 
        protected override void RefreshLayer(Notifycation param, params object[] paramList)
        {
            if (Window == null)
                return;
<<<<<<< HEAD
            //PlayerInfomationLayer SystemLayerScript = Window.gameObject.GetComponent<PlayerInfomationLayer>();//获取到 登录代理 
            //SystemLayerScript.RefreshLayer();
            LayerBase Script = Window.GetComponent<LayerBase>();
            Script.RefreshAssignLayer(0, param.GetData<string>(1));
=======
            PlayerInfomationLayer SystemLayerScript = Window.gameObject.GetComponent<PlayerInfomationLayer>();//获取到 登录代理 
            SystemLayerScript.RefreshLayer();
>>>>>>> b23e7a4f415aa4e1e531cb8433c539ec3ab83bb1
        }

    }
}