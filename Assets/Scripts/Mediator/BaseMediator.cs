using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
public class BaseMediator : Mediator
{
    public Transform Window;
<<<<<<< HEAD

    public string OpenLayerNotifyName;
    public string CloseLayerNotifyName;
    protected void InitBaseNotify(string openNotiry, string closeNotify)
    {
        OpenLayerNotifyName = openNotiry;
        CloseLayerNotifyName = closeNotify; 
        AddHandle(OpenLayerNotifyName, OepnLayer);
        AddHandle(CloseLayerNotifyName, CloseLayer); 
    }
    protected virtual void OepnLayer(Notifycation param)
    { 
    }
    //param中的数据是关闭类型
    protected virtual void CloseLayer(Notifycation param)
=======
    public LayerBase Script;
    protected virtual void OepnLayer(Notifycation param, params object[] paramList)
    { 
    }

    protected virtual void CloseLayer(Notifycation param, params object[] paramList)
>>>>>>> b23e7a4f415aa4e1e531cb8433c539ec3ab83bb1
    {
        if (!Window)
            return;
        GameObject.Destroy(Window.gameObject);//销毁对象
        Window = null; 
    }
    protected virtual void RefreshLayer(Notifycation param, params object[] paramList)
    { 
    }
}
