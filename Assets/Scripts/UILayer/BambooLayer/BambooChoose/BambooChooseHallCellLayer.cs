using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using MVCFrame;
using ProxySpace;
using ModuleCellSpace;
using LightJson;
public class BambooChooseHallCellLayer : MonoBehaviour
{
    BambooModule BambooModule;

    public Button ChooseButton;
    public Text HallName_Text;
    public Text HallPlayerCount_Text;

    int HallIndex; 
    // Start is called before the first frame update
    void Start()
    {
        ChooseButton.onClick.AddListener(() =>
        {
            //开始请求界面信息
            BambooModule.RequestEnterHall(HallIndex);
        });
        BambooModule = Sys.GetFacade().RetrieveModule<BambooModule>("BambooProxy");
        //BambooModule
        JsonValue cellInfo = BambooModule.GetHallCellInfo(this.HallIndex);

        HallName_Text.text = cellInfo["hallName"].AsString;
        HallPlayerCount_Text.text = string.Format("在线玩家:{0}/{1}", cellInfo["nowPlayer"].AsString, cellInfo["maxPlayer"]);
        //HallPlayerCount_Text.text = "123";
    } 
    public void InitCellData(int id)
    {
        HallIndex = id;
    }
}
