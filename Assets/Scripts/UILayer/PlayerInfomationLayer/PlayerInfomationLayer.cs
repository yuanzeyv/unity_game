using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MVCFrame;
using LightJson;
using ModuleCellSpace;

public class PlayerInfomationLayer : LayerBase
{
    public Image PlayerHead_Image;
    public Text PlayerName_Text;
    public Text PlayerDesc_Text;
    public Text PlayerID_Text;
    public Image Goods1_Image;
    public Text Goods1_Image_GoodNum_Text;
    public Image Goods2_Image;
    public Text Goods2_Image_GoodNum_Text;
    private PlayerInfoModule PlayerInfoModule; 
    public void Awake()
    { 
        PlayerInfoModule = Sys.GetFacade().RetrieveModule<PlayerInfoModule>("PlayerInfoProxy");
        RefreshLayer();
    } 
    public void Start()
    { 
    }
    //更新整个界面
    override public void RefreshLayer(object param = null)
    {
        JsonValue data = PlayerInfoModule.CheckPlayerInfo; 
        PlayerName_Text.text = data["account"];
        PlayerDesc_Text.text = data["name"];
        PlayerID_Text.text = data["user_id"];
        Goods1_Image_GoodNum_Text.text = "99999";
        Goods2_Image_GoodNum_Text.text = "98999";
    }
    //更新局部界面 
    override public void RefreshAssignLayer(int index, object param)
    {

    }
}
