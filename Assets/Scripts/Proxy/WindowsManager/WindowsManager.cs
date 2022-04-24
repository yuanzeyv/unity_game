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
            RegisterModule(new WindowsManagerModule());//添加一个窗口管理模块  
        }
    }
}
