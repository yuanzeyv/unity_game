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
<<<<<<< HEAD
            Sys.GetFacade().NotifyObserver("OepnTipsWindowLayerUI", "�Ѿ���������Ͽ������ӣ��Ƿ�������", "��������", func);//����һ�����Window��֪ͨ��Ϣ  
=======
            Sys.GetFacade().NotifyObserver("OepnTipsWindowLayerUI", null, "�Ѿ���������Ͽ������ӣ��Ƿ�������", "��������", func);//����һ�����Window��֪ͨ��Ϣ  
>>>>>>> b23e7a4f415aa4e1e531cb8433c539ec3ab83bb1
        }
    }
} 
