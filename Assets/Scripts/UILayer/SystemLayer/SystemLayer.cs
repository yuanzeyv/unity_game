using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MVCFrame;
using ProxySpace;
using ModuleCellSpace;
namespace LayerSpace{ 
    public class SystemLayer : MonoBehaviour
    {
        public Transform SysCellPre;
        private Transform ListView;
        // Start is called before the first frame update
        void Start()
        {
            ListView = this.transform.Find("SystemList/Viewport/Content"); 
        }
        Transform CreateSystemCell(int key,string systemName)
        {
            Transform trans = UnityEngine.Object.Instantiate<Transform>(SysCellPre);
            trans.transform.SetParent( ListView);
            trans.GetComponent<SystemCellLayer>().InitCellData(key, systemName);
            return trans;
        }
        public void UpdateLayer()
        {
            //首先获取到当前所有的 系统信息 
            SystemServiceProxy SystemServiceProxy = Sys.GetFacade().RetrieveProxy<SystemServiceProxy>();
            Dictionary<int, string> SystemList = SystemServiceProxy.RetrieveModule<SystemModule>().SysList;
            foreach( var item in SystemList ){
                CreateSystemCell(item.Key, item.Value);
            }
        }
    } 
}
