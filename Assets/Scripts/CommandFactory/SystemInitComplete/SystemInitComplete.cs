using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
namespace CommandSpace
{
    public class SystemInitComplete : Command
    {
        public override void Excute(Notifycation data)
        {
            Sys.GetFacade().UnRegisterProxy("InitPorxy");//��ʼ����Ϻ�ɾ����ǰ���� 
            //�򿪵�¼���� 
            Sys.GetFacade().NotifyObserver("OepnTipsLayerUI");//����һ�����Window��֪ͨ��Ϣ
            Sys.GetFacade().NotifyObserver("OpenLoginUI");//����һ�����Window��֪ͨ��Ϣ
        }
    }
} 
