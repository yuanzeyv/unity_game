using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LightJson;
using MVCFrame;
using ModuleCellSpace;
namespace ProxySpace
{
    public class LoginProxy :Proxy
    {
        public LoginProxy()
        {
            //选择注册一个 loginModule,每个模块可以监听网络消息
            RegisterModule(new LoginModule()); 
        } 
    }
}
