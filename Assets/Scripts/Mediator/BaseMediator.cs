using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
public class BaseMediator : Mediator
{
    public Transform Window;

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
    //param�е������ǹر�����
    protected virtual void CloseLayer(Notifycation param)
    {
        if (!Window)
            return;
        GameObject.Destroy(Window.gameObject);//���ٶ���
        Window = null; 
    }
    protected virtual void RefreshLayer(Notifycation param)
    { 
    }
}
