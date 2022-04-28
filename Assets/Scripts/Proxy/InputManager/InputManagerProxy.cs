using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using MVCFrame;


namespace ProxySpace
{
    public class InputManagerProxy : Proxy
    {
        public InputManagerProxy()
        {
            RegisterModule(new MouseControlModule());//添加一个网络模块  
            RegisterModule(new KeyControlModule());//添加一个网络模块  
        }
    }
}