using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame; 
using ModuleCellSpace;
namespace ProxySpace
{ 
        public class PlayerInfoProxy : Proxy
        {
            public PlayerInfoProxy()
            {
                RegisterModule(new PlayerInfoModule());//���һ������ģ��  
            } 
        } 
}
