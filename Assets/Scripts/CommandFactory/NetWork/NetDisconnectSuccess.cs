using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
namespace CommandSpace
{
    public class NetDisconnectSuccess : Command
    {
        public override void Excute(Notifycation data)
        {
            MonoBehaviour.print("��������Ͽ�����");
            Sys.GetFacade().NotifyObserver("RefreshTipsLayerUI", "��������Ͽ�����");
        }
    }
} 
