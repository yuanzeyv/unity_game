using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;  

namespace ProxySpace
{
    public class InitPorxy : Proxy
    {
        public InitPorxy()
        {
        }
        public override void OnRigister()
        {    
            InitProxy.GetInstance().LoginInProxy();//开始初始化代理 
            InitMediator.GetInstance().LoginInMediator();//初始化所有login 
            InitCommand.GetInstance().LoginInCommand();//初始化所有的命令 

            Sys.GetFacade().NotifyObserver("SystemInitComplete");

        }
    }
}