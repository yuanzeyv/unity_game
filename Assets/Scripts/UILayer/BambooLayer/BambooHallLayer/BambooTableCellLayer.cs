using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
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

=======

public class BambooTableCellLayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
>>>>>>> b23e7a4f415aa4e1e531cb8433c539ec3ab83bb1
}
