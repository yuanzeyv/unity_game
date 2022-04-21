using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame; 
using ModuleCellSpace;
namespace ProxySpace
{ 
        public class SystemServiceProxy :Proxy
        {
            public SystemServiceProxy()
            {
                RegisterModule(new SystemModule());//添加一个网络模块  
            } 
        } 
}
