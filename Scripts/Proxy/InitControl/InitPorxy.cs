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
            RegisterModule(new InitLoginModule());//ע���¼ģ��
            RegisterModule(new InitSystemModule());//ע��ϵͳģ��

            //InitProxy.GetInstance().LoginInProxy();//��ʼ��ʼ������ 
            //InitMediator.GetInstance().LoginInMediator();//��ʼ������login 
            //InitCommand.GetInstance().LoginInCommand();//��ʼ�����е�����  

        }
    } 
}