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

            //InitProxy.GetInstance().LoginInProxy();//��ʼ��ʼ������ 
            //InitMediator.GetInstance().LoginInMediator();//��ʼ������login 
            //InitCommand.GetInstance().LoginInCommand();//��ʼ�����е�����  
            //Sys.GetFacade().NotifyObserver("SystemInitComplete");
        }
        override public void OnRemove()
        {
        }
    }
}