using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LightJson;
using MVCFrame;
using ModuleCellSpace;
namespace ProxySpace
{
    public class LoginProxy :Proxy
    {
        public LoginProxy()
        {
            //ѡ��ע��һ�� loginModule,ÿ��ģ����Լ���������Ϣ
            RegisterModule(new LoginModule()); 
        } 
    }
}
