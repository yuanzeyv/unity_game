using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MVCFrame;
using ProxySpace;
using ModuleCellSpace;
namespace LayerSpace{ 
    public class SystemCellLayer : MonoBehaviour
    {
        Transform Name_Text;
        Transform ID_Text;
        Transform Start_Button;

        int SystemID;
        string SystemName;
        // Start is called before the first frame update
        void Start()
        {
            Name_Text = transform.Find("Name_Text/text");
            ID_Text = transform.Find("ID_Text/text");
            Start_Button = transform.Find("Start_Button");//获取到按钮信息
            InitLayer();
        }
        public void InitCellData(int id, string name)
        {
            SystemID = id;
            SystemName = name;
        }

        void StartButtonHandle()
        {
            //发送向服务器请求加入系统的消息  
            SystemServiceProxy SystemServiceProxy = Sys.GetFacade().RetrieveProxy<SystemServiceProxy>();//获取到系统代理
            SystemServiceProxy.RetrieveModule<SystemModule>().EnterSystem(SystemID);
        }
        void InitLayer()
        {
            Name_Text.GetComponent<Text>().text = SystemName;
            ID_Text.GetComponent<Text>().text = SystemID.ToString();
            Start_Button.GetComponent<Button>().onClick.AddListener(StartButtonHandle);
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}