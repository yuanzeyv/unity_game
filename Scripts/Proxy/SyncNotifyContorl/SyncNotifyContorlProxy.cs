using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using ModuleCellSpace;
namespace ProxySpace
{
    public class SyncNotifyContorlProxy : Proxy
    {
        public SyncNotifyContorlProxy()
        {
            RegisterModule(new SyncNotifyModule());//���һ������ģ��  
        }
    }
}
