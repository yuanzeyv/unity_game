using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using ProxySpace;
using Config.Program;
using LightJson;
namespace ModuleCellSpace
{
    public class InitSystemModule : ModuleCell
    {
        override public void OnInit()
        {

            //InitProxy.GetInstance().LoginInProxy();//开始初始化代理 
            //InitMediator.GetInstance().LoginInMediator();//初始化所有login 
            //InitCommand.GetInstance().LoginInCommand();//初始化所有的命令  
            //Sys.GetFacade().NotifyObserver("SystemInitComplete");
        }
        override public void OnRemove()
        {
        }
    }
}