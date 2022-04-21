using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using MVCFrame;
using ProxySpace;
using ModuleCellSpace;
public class BambooChooseHallCellLayer : MonoBehaviour
{
    Button OkButton;
    BambooProxy BambooProxy;
    Transform HallName_Text; 
    int HallIndex;
    string HallName;
    // Start is called before the first frame update
    void Start()
    {
        BambooProxy = Sys.GetFacade().RetrieveProxy<BambooProxy>(); 
        OkButton = this.GetComponent<Button>();
        HallName_Text = transform.Find("HallName");
        OkButton.onClick.AddListener(() =>
        {
            //开始请求界面信息
            BambooProxy.RetrieveModule<BambooModule>().RequestEnterHall(HallIndex);
        });
        HallName_Text.GetComponent<Text>().text = HallName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InitCellData(int id,string name)
    {
        HallIndex = id;
        HallName = name;
    }
}
