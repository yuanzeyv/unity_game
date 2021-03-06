using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ProxySpace;
using ModuleCellSpace;
using MVCFrame;
using LightJson;
public class BambooChooseLayer : WindowBaseLayer
{
    BambooModule BambooModule;
    public Text Name_Text;
    public Transform ListView_Content; 
    public Transform HallCell_Node; 

    // Start is called before the first frame update
    void Start()
    {
        InitLyaerData();
    }
    public override  void CloseLayer()
    {
        Sys.GetFacade().NotifyObserver("CloseBambooHallChooseLayer");//发送一个添加Window的通知消息  
    }
    void InitLyaerData()
    {
        BambooModule = Sys.GetFacade().RetrieveModule<BambooModule>("BambooProxy");
        BambooModule.RequestHallList();//打开界面前，先拉一下消息
        RefreshLayer();
    }
    Transform CreateSystemCell(int key)
    {
        Transform trans = UnityEngine.Object.Instantiate<Transform>(HallCell_Node);
        trans.gameObject.SetActive(true);
        trans.transform.SetParent(ListView_Content,false);
        trans.GetComponent<BambooChooseHallCellLayer>().InitCellData(key);
        return trans;
    }
    public void CleanListView()
    {
        //首先删除所有子节点
        for (int i = 0; i < ListView_Content.childCount; i++)
        {
            Transform child = ListView_Content.GetChild(i);
            GameObject.Destroy(child.gameObject);
        }
    }

    //更新整个界面
    override public void RefreshLayer(object param = null)
    {
        CleanListView();
        //首先获取到当前所有的 系统信息 
        Dictionary<int,JsonValue > SystemList = BambooModule.GetHallInfoMap;
        foreach (var item in SystemList)
        {
            CreateSystemCell(item.Key);
        }
    } 
}
