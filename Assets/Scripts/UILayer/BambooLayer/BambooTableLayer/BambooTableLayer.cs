using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ProxySpace;
using ModuleCellSpace;
using MVCFrame;
using LightJson;
public class BambooTableLayer : WindowBaseLayer
{
    BambooModule BambooModule; 

    // Start is called before the first frame update
    void Start()
    {
        InitLyaerData();
    }
    public override void CloseLayer()
    {
        Sys.GetFacade().NotifyObserver("CloseBambooHallLayer");//发送一个添加Window的通知消息  
    }
    void InitLyaerData()
    {
        BambooModule = Sys.GetFacade().RetrieveModule<BambooModule>("BambooProxy");
        BambooModule.RequestTableAllInfo();
    }  
    //更新整个界面
    override public void RefreshLayer(object param = null)
    {  
    }
}
