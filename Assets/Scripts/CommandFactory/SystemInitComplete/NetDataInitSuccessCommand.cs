using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
namespace CommandSpace
{
    public class NetDataInitSuccessCommand : Command
    { 
        public override void Excute(Notifycation data)
        {
            //���û���Ϣ���� 
            Sys.GetFacade().NotifyObserver("OpenPlayerInfomationLayer");//�������Ϣ����
            Sys.GetFacade().NotifyObserver("OepnTimeLayer");//��ʱ��
            Sys.GetFacade().NotifyObserver("OepnSystemMainUI");//����һ�����Window��֪ͨ��Ϣ  
        }
    }
}
