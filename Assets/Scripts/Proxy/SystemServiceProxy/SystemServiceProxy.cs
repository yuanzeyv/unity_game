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
                RegisterModule(new SystemModule());//���һ������ģ��  
            } 
        } 
}
