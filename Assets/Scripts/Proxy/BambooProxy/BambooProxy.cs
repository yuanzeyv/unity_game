using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using ModuleCellSpace;
namespace ProxySpace
{
    public class BambooProxy : Proxy
    {

        public BambooProxy()
        {
            //选择注册一个 loginModule,每个模块可以监听网络消息
            RegisterModule(new BambooModule());
        } 
    }
}