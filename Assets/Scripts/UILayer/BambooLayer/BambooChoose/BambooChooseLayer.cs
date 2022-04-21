using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProxySpace;
using ModuleCellSpace;
using MVCFrame;

public class BambooChooseLayer : MonoBehaviour
{
    BambooProxy BambooProxy;
    public Transform SysCellPre;
    private Transform ListView;
    // Start is called before the first frame update
    void Start()
    {
        InitLyaerData();
    }
    void InitLyaerData()
    {
        BambooProxy = Sys.GetFacade().RetrieveProxy<BambooProxy>();
        ListView = this.transform.Find("HallList/Viewport/Content");
        //开始请求界面信息
        BambooProxy.RetrieveModule<BambooModule>().RequestHallList();
    }
    Transform CreateSystemCell(int key, string systemName)
    {
        Transform trans = UnityEngine.Object.Instantiate<Transform>(SysCellPre);
        trans.transform.SetParent(ListView);
        trans.GetComponent<BambooChooseHallCellLayer>().InitCellData(key, systemName);
        return trans;
    }
    public void UpdateLayer()
    { 
        for(int i = 0; i < ListView.childCount; i++)
        {
            Transform child = ListView.GetChild(i);
            GameObject.Destroy(child.gameObject);
        }
        //首先获取到当前所有的 系统信息 
        BambooProxy SystemServiceProxy = Sys.GetFacade().RetrieveProxy<BambooProxy>();
        Dictionary<int, string> SystemList = SystemServiceProxy.RetrieveModule<BambooModule>().GetHallInfoMap;
        foreach (var item in SystemList){
            CreateSystemCell(item.Key, item.Value);
        }
    }
    // Update is called once per frame 
    void Update()
    {
        
    }
}
