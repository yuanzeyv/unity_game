using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ProxySpace;
using ModuleCellSpace;
using MVCFrame;
using LightJson;
public class BambooHallLayer : WindowBaseLayer
{
    BambooModule BambooModule;
    public Text HallName_Text;
    public Transform ListView_Content; 
    public Transform TableCell_Node; 

    // Start is called before the first frame update
    void Start()
    {
        InitLyaerData();
    }
    public override  void CloseLayer()
    { 
        Sys.GetFacade().NotifyObserver("CloseBambooHallLayer");//����һ�����Window��֪ͨ��Ϣ   
    }
    void InitLyaerData()
    {
        BambooModule = Sys.GetFacade().RetrieveModule<BambooModule>("BambooProxy"); 
        RefreshLayer();
    }
    Transform CreateSystemCell(int key)
    {
        Transform trans = UnityEngine.Object.Instantiate<Transform>(TableCell_Node);
        trans.gameObject.SetActive(true);
        trans.transform.SetParent(ListView_Content); 
        trans.GetComponent<BambooTableCellLayer>().InitCellData(key); 
        return trans;
    }
    public void CleanListView()
    {
        //����ɾ�������ӽڵ�
        for (int i = 0; i < ListView_Content.childCount; i++)
        {
            Transform child = ListView_Content.GetChild(i);
            GameObject.Destroy(child.gameObject);
        }
    }

    //������������
    override public void RefreshLayer(object param = null)
    {
        CleanListView();
        //���Ȼ�ȡ����ǰ���е� ϵͳ��Ϣ 
        Dictionary<int,JsonValue > TableList = BambooModule.GetTableInfoMap;
        foreach (var item in TableList)
        {
            CreateSystemCell(item.Key);
        }
    } 
}
