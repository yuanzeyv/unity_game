using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LightJson;
using MVCFrame;
using ModuleCellSpace;
namespace ProxySpace
{
    public class NetWorkProxy : Proxy
    {
        public NetWorkProxy()
        {
        }
        public override void OnRigister()
        {
            base.OnRigister();
            RegisterModule(new NetModule());//添加一个网络模块 
        }
    }
}