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
            //当收到了这条消息，说明程序已经点击了退出按键了
            MonoBehaviour.print("ZZZZZZZ Exit");
        }
    }
}
