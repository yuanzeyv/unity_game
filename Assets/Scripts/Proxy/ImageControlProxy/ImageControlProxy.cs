using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame; 
using ModuleCellSpace;
namespace ProxySpace
{ 
        public class ImageControlProxy : Proxy
        {
            public ImageControlProxy()
            {
                RegisterModule(new ImageControlModule());//���һ������ģ��  
            } 
        } 
}
