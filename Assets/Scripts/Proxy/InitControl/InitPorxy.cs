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
            InitProxy.GetInstance().LoginInProxy();//��ʼ��ʼ������ 
            InitMediator.GetInstance().LoginInMediator();//��ʼ������login 
            InitCommand.GetInstance().LoginInCommand();//��ʼ�����е����� 

            Sys.GetFacade().NotifyObserver("SystemInitComplete");

        }
    }
}