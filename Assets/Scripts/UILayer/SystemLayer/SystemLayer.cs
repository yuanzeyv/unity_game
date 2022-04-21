using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MVCFrame;
using ProxySpace;
using ModuleCellSpace;
namespace LayerSpace{
    public class SystemLayer : LayerBase
    {
        public Transform NormalModel;
        public Transform HallModel;
        public Transform SystemChoose_Image;
        public Transform SystemListView;
        public Transform SystemListView_Content;
        SystemModule SystemModule;

        Dictionary<int, Transform> SystemObjList = new Dictionary<int, Transform>();
        public void Awake()
        {
            //打开界面的时候，发送一个消息给服务器 
            SystemModule = Sys.GetFacade().RetrieveModule<SystemModule>("SystemServiceProxy");
            SystemModule.RequestSystemInfo();
        }
            // Start is called before the first frame update
        void Start()
        {
        }
        //刷新Listview信息
        private void RefreshListViewNode()
        {
            var sysList = SystemModule.SysList;
            Dictionary<int, bool> sysKeyList = new Dictionary<int, bool>();
            foreach (var item in SystemObjList)
                sysKeyList[item.Key] = true;
            foreach (var item in sysList)
            {
                int id = item["id"].AsInteger;
                string name = item["name"].AsString;
                if(!SystemObjList.ContainsKey(id))
                {  //创建一个对象
                   Transform trans = GameObject.Instantiate(NormalModel, SystemListView_Content);
                   trans.GetComponent<SystemCellLayer>().InitCellData(id,name);
                   SystemObjList[id] = trans;
                }
                if (sysKeyList.ContainsKey(id))
                    sysKeyList.Remove(id);
            }
            foreach(var item in sysKeyList)
            {
                GameObject.Destroy(SystemObjList[item.Key].gameObject);
                SystemObjList.Remove(item.Key);
            }

        }
        //更新整个界面
        override public void RefreshLayer(object param = null)
        { 
            RefreshListViewNode();//刷新列表
        } 
    }
}
