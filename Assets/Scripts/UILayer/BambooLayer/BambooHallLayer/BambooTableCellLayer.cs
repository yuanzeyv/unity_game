using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ModuleCellSpace;
using MVCFrame; 
public class BambooTableCellLayer : MonoBehaviour
{
    public Text TableName_Text;
    public Text TableAroundNumber_Text;
    public Text TableSitDownNumber_Text;
    public Image Player1Status_Image;
    public Image Player2Status_Image;
    public Button TableCell_Button;
    BambooModule BambooModule;
    private int ID;
    // Start is called before the first frame update
    void Start()
    {
        TableCell_Button.onClick.AddListener(() =>
        {
            BambooModule.RequestEnterTable(ID);
        });
    }
    public void InitCellData(int key)
    {
        BambooModule = Sys.GetFacade().RetrieveModule<BambooModule>("BambooProxy");
        ID = key;
        RefreshLayer();
    }
    public void RefreshLayer()
    {
        var data = BambooModule.GetTableInfoMap[ID];
        TableName_Text.text = "×À×Ó:" + ID;
    }

}
