using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using ProxySpace;
using ModuleCellSpace;
using UnityEngine.Events;
namespace CommandSpace
{
    public class LoginSuccess : Command
    {
        public override void Excute(Notifycation data)
        {
            //ɾ����¼��Ϣ
            //NetModule netModule = Sys.GetFacade().RetrieveModule<NetModule>("NetWorkProxy");
            //string userName = data.GetData<string>();
            //netModule.InitSocketPort(8889, "39.103.201.92", userName);
            //bool isSucces = netModule.Connect();//���Ӳ�������Ҫһ�����ӵķ���
            //if (!isSucces)
            //{
            //    UnityAction func = new UnityAction(() => {
            //        NetModule netModule = Sys.GetFacade().RetrieveModule<NetModule>("NetWorkProxy");
            //        netModule.Connect();
            //    });
            //    Sys.GetFacade().NotifyObserver("OepnTipsWindowLayerUI", "���ӷ�����ʧ���ˣ��Ƿ��������ӣ�", "��������", func);//����һ�����Window��֪ͨ��Ϣ   
            //    return;
            //}
        }
    }
}
