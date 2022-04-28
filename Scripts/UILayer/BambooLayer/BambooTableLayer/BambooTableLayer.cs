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
        Sys.GetFacade().NotifyObserver("CloseBambooHallLayer");//����һ�����Window��֪ͨ��Ϣ  
    }
    void InitLyaerData()
    {
        BambooModule = Sys.GetFacade().RetrieveModule<BambooModule>("BambooProxy");
        BambooModule.RequestTableAllInfo();
    }  
    //������������
    override public void RefreshLayer(object param = null)
    {  
    }
}
