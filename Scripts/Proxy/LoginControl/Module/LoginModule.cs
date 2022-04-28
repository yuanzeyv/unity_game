using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LightJson;
using MVCFrame;
using ProxySpace;
 
namespace ModuleCellSpace
{
    public class LoginModule : ModuleCell
    {
        private LoginNetModule loginVerifyObj;//��Ե�¼ģ��ĵ��������
        public LoginModule()
        {
        }
        public override void OnInit()
        {
            base.OnInit();
            loginVerifyObj = new LoginNetModule(8888, "39.103.201.92");//���������������
        }
        public string VerifyLogin(string account, string password)
        {
            string retValue = loginVerifyObj.Verify("sample", account, password); 
            return retValue;
        }
    }
}  