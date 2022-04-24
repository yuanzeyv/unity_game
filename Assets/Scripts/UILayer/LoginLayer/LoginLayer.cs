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
    public InputField AccountInputText;//获取到当前界面的 账号文本框
    public InputField PassWordInputText;//获取到当前账号的 密码文本框
    public Button LoginButton;//获取到当前界面的 登录按钮
    public Text NetConnectText;//获取到下方的     服务器链接状态文本框 
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
                     Sys.GetFacade().NotifyObserver("CloseLoginUI");//关闭登录界面 
                     string subID = resultList[1];
                     string DoAuth = string.Format("{0}@{1}#{2}:{3}", Base64Encoder.Encoder.GetEncoded(uid), Base64Encoder.Encoder.GetEncoded("sample"), subID, 1);
                     Sys.GetFacade().NotifyObserver("LoginSuccess", DoAuth);
                 } 
                
           // });  
        }


        private void LoginTipsShow(int status)
        {
            Dictionary<int, string> StatusMapping = new Dictionary<int, string>();
            StatusMapping[0] = "账号登录成功!";
            StatusMapping[-100] = "传入账号为空。";
            StatusMapping[-101] = "传入密码为空。";
            StatusMapping[-102] = "用户验证失败。";
            StatusMapping[-103] = "用户不存在（账号）。";
            StatusMapping[-104] = "用户密码错误。";
            StatusMapping[-105] = "服务器不存在。";
            StatusMapping[-106] = "用户已经登录了。";
            StatusMapping[-107] = "未选择区服。";
            if (!StatusMapping.ContainsKey(status))
            {
                Sys.GetFacade().NotifyObserver("RefreshTipsLayerUI","未知的错误!");
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

