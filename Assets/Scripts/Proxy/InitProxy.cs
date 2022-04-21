using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using MVCFrame;
using Config.Program;
using ProxySpace;

class InitProxy
{
    private static InitProxy InstanceObj;
    public static InitProxy GetInstance()
    {
        if (InstanceObj == null)
            InstanceObj = new InitProxy();
        return InstanceObj;
    }
    private InitProxy()
    {
    }
    public void LoginInProxy()
    {
        Sys.GetFacade().RegisterProxy(new NetWorkProxy());//����һ������ģ��
        Sys.GetFacade().RegisterProxy(new LoginProxy());//���һ����¼ģ��
        Sys.GetFacade().RegisterProxy(new PlayerInfoProxy());//���һ����¼ģ��
        //Sys.GetFacade().RegisterProxy(new BambooProxy());//���һ������͵�ģ��
        Sys.GetFacade().RegisterProxy(new SystemServiceProxy());//����һ������ģ��   
    }
}

