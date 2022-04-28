using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;
using MVCFrame;

public class TipsPopWindowLayer : WindowBaseLayer
{
    public Text TipsText;
    public Button ExecButton;
    public Text ExecButton_Text; 
    public override void CloseLayer()
    {
        Sys.GetFacade().NotifyObserver("CloseTipsWindowLayerUI");//发送一个添加Window的通知消息  
    }
    public override void MinSizeLayer()
    {
    }
    public override void MaxSizeLayer()
    {
    }
    public override void IconLayerClick()
    {
    }
    //更新整个界面
    public override void RefreshLayer(object param = null)
    { 
    }
    //更新局部界面 
    public override void RefreshAssignLayer(int index, object param = null)
    {
    }
<<<<<<< HEAD
    public override void InitLayer(Notifycation param)
    {
        string desc = param.GetData<string>(1);
        string buttonDesc = param.GetData<string>(2);
        UnityEngine.Events.UnityAction buttonHandle = param.GetData< UnityEngine.Events.UnityAction>(3); 
=======
    public override void InitLayer(params object[] list)
    {
        string desc = list[0] as string;
        string buttonDesc = list[1] as string;
        UnityEngine.Events.UnityAction buttonHandle = list[2] as UnityEngine.Events.UnityAction;
>>>>>>> b23e7a4f415aa4e1e531cb8433c539ec3ab83bb1
        
        TipsText.text = desc;
        ExecButton_Text.text = buttonDesc; 
        ExecButton.onClick.AddListener(buttonHandle); 
    }
}
