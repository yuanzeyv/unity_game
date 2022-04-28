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
            RegisterModule(new MouseControlModule());//���һ������ģ��  
            RegisterModule(new KeyControlModule());//���һ������ģ��  
        }
    }
}