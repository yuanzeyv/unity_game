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
            //ѡ��ע��һ�� loginModule,ÿ��ģ����Լ���������Ϣ
            RegisterModule(new BambooModule());
        } 
    }
}