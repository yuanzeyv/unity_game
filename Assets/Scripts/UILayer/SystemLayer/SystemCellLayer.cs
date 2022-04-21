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
        public Transform Name_Text;
        public Transform ID_Text;
        public Transform Start_Button;

        int SystemID;
        string SystemName;
        // Start is called before the first frame update
        void Start()
        { 
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
            SystemModule SystemModule = Sys.GetFacade().RetrieveModule<SystemModule>("SystemServiceProxy");
            SystemModule.EnterSystem(SystemID);
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