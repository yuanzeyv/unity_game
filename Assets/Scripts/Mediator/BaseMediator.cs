using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
public class BaseMediator : Mediator
{
    public Transform Window;
    public LayerBase Script;
    protected virtual void OepnLayer(Notifycation param)
    { 
    }

    protected virtual void CloseLayer(Notifycation param)
    {
        if (!Window)
            return;
        GameObject.Destroy(Window.gameObject);//���ٶ���
        Window = null;
        Script = null;
    }
    protected virtual void RefreshLayer(Notifycation param)
    { 
    }
}
