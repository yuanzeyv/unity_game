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
        private LoginNetModule loginVerifyObj;//针对登录模块的的网络组件
        public LoginModule()
        {
        }
        public override void OnInit()
        {
            base.OnInit();
            loginVerifyObj = new LoginNetModule(8888, "39.103.201.92");//创建网络组件对象
        }
        public string VerifyLogin(string account, string password)
        {
            string retValue = loginVerifyObj.Verify("sample", account, password); 
            return retValue;
        }
    }
}  