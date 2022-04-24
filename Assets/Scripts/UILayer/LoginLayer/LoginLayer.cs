using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MVCFrame; 
using Tool;
using Config.Program;
using ProxySpace;
using ModuleCellSpace; 
namespace LayerSpace { 
public class LoginLayer:LayerBase
{ 
    public InputField AccountInputText;//��ȡ����ǰ����� �˺��ı���
    public InputField PassWordInputText;//��ȡ����ǰ�˺ŵ� �����ı���
    public Button LoginButton;//��ȡ����ǰ����� ��¼��ť
    public Text NetConnectText;//��ȡ���·���     ����������״̬�ı��� 
    public Sprite sprite;
        public void Start()
        {
            //LoginButton.onClick.AddListener(delegate() 
           // {
                 LoginProxy LoginProxy = Sys.GetFacade().RetrieveProxy<LoginProxy>();
                 string uid = "yuan";  // AccountInputText.text;// 
                 string password = "123";  // PassWordInputText.text;//
                 string retStatus = LoginProxy.RetrieveModule<LoginModule>().VerifyLogin(uid, password);
                 string[] resultList = retStatus.Split(' ');
                 int ret = int.Parse(resultList[0]);
                 LoginTipsShow(ret);
                 if (ret == 0)
                 {
                     Sys.GetFacade().NotifyObserver("CloseLoginUI");//�رյ�¼���� 
                     string subID = resultList[1];
                     string DoAuth = string.Format("{0}@{1}#{2}:{3}", Base64Encoder.Encoder.GetEncoded(uid), Base64Encoder.Encoder.GetEncoded("sample"), subID, 1);
                     Sys.GetFacade().NotifyObserver("LoginSuccess", DoAuth);
                 } 
                
           // });  
        }


        private void LoginTipsShow(int status)
        {
            Dictionary<int, string> StatusMapping = new Dictionary<int, string>();
            StatusMapping[0] = "�˺ŵ�¼�ɹ�!";
            StatusMapping[-100] = "�����˺�Ϊ�ա�";
            StatusMapping[-101] = "��������Ϊ�ա�";
            StatusMapping[-102] = "�û���֤ʧ�ܡ�";
            StatusMapping[-103] = "�û������ڣ��˺ţ���";
            StatusMapping[-104] = "�û��������";
            StatusMapping[-105] = "�����������ڡ�";
            StatusMapping[-106] = "�û��Ѿ���¼�ˡ�";
            StatusMapping[-107] = "δѡ��������";
            if (!StatusMapping.ContainsKey(status))
            {
                Sys.GetFacade().NotifyObserver("RefreshTipsLayerUI","δ֪�Ĵ���!");
            }
            else
            {
                Sys.GetFacade().NotifyObserver("RefreshTipsLayerUI", StatusMapping[status]);
            }
        } 

    // Update is called once per frame
      void Update()
        {
        }
    }
}

