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
        Sys.GetFacade().NotifyObserver("CloseTipsWindowLayerUI");//����һ�����Window��֪ͨ��Ϣ  
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
    //������������
    public override void RefreshLayer(object param = null)
    { 
    }
    //���¾ֲ����� 
    public override void RefreshAssignLayer(int index, object param = null)
    {
    }
    public override void InitLayer(params object[] list)
    {
        string desc = list[0] as string;
        string buttonDesc = list[1] as string;
        UnityEngine.Events.UnityAction buttonHandle = list[2] as UnityEngine.Events.UnityAction;
        
        TipsText.text = desc;
        ExecButton_Text.text = buttonDesc; 
        ExecButton.onClick.AddListener(buttonHandle); 
    }
}
