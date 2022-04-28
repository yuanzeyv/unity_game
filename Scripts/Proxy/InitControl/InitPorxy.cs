using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using ModuleCellSpace;
namespace ProxySpace
{
    public class InitPorxy : Proxy
    { 
        public override void OnRigister()
        { 
            RegisterModule(new InitLoginModule());//注册登录模块
            RegisterModule(new InitSystemModule());//注册系统模块

            //InitProxy.GetInstance().LoginInProxy();//开始初始化代理 
            //InitMediator.GetInstance().LoginInMediator();//初始化所有login 
            //InitCommand.GetInstance().LoginInCommand();//初始化所有的命令  

        }
    } 
}