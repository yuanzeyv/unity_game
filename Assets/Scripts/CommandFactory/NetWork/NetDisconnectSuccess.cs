using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using UnityEngine.Events;
using ModuleCellSpace;
namespace CommandSpace
{
    public class NetDisconnectSuccess : Command
    {
        public override void Excute(Notifycation data)
        {

            UnityAction func = new UnityAction(() => {
                NetModule netModule = Sys.GetFacade().RetrieveModule<NetModule>("NetWorkProxy");
                netModule.Connect();
            });
            Sys.GetFacade().NotifyObserver("OepnTipsWindowLayerUI", "�Ѿ���������Ͽ������ӣ��Ƿ�������", "��������", func);//����һ�����Window��֪ͨ��Ϣ  
        }
    }
} 
