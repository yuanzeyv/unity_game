using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using ModuleCellSpace;
namespace ProxySpace
{
    public class WindowsManagerProxy : Proxy
    {
        public WindowsManagerProxy()
        {
            RegisterModule(new WindowsManagerModule());//���һ�����ڹ���ģ��  
        }
    }
}
