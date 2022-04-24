using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
public class BaseMediator : Mediator
{
    public Transform Window;
    public LayerBase Script;
    protected virtual void OepnLayer(Notifycation param, params object[] paramList)
    { 
    }

    protected virtual void CloseLayer(Notifycation param, params object[] paramList)
    {
        if (!Window)
            return;
        GameObject.Destroy(Window.gameObject);//Ïú»Ù¶ÔÏó
        Window = null;
        Script = null;
    }
    protected virtual void RefreshLayer(Notifycation param, params object[] paramList)
    { 
    }
}
