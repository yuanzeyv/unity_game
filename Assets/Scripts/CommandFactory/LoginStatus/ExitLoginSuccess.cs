using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using ProxySpace;
using ModuleCellSpace;
using UnityEngine.Events;
namespace CommandSpace
{
    public class ExitLoginSuccess : Command
    {
        public override void Excute(Notifycation data)
        {
            //���յ���������Ϣ��˵�������Ѿ�������˳�������
            MonoBehaviour.print("ZZZZZZZ Exit");
        }
    }
}
