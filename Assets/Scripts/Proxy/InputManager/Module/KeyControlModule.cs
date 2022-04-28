using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
public class KeyStruct {
    public KeyCode KeyListen;
    public float SustainTime;//����ʱ��
    public bool Press;//����
    public KeyStruct(KeyCode key)
    {
        KeyListen = key;
        SustainTime = 0;
        Press = Input.GetKey(KeyListen);
    }
}

public class KeyControlModule : ModuleCell
{
    Dictionary<KeyCode, KeyStruct> KeyPressList = new Dictionary<KeyCode, KeyStruct>();
    public KeyControlModule()
    {
        InitModule();
    }
    public void  InitModule( )
    {
        RegisterKey(KeyCode.Mouse0);
        RegisterKey(KeyCode.Mouse1);
        RegisterKey(KeyCode.Mouse2);
    }
    public void  RegisterKey(KeyCode key)
    {
        KeyPressList[key] = new KeyStruct(key);
    }
    public override void OnInit()
    {
        base.OnInit();
    }
    public void Tick()
<<<<<<< HEAD
    { 
        var pushList = new Dictionary<KeyCode,float>();//����
        var releaseList = new Dictionary<KeyCode, float>();//̧�� 
        foreach (var item in KeyPressList)
        {
            bool press = Input.GetKey(item.Key);//��ȡ����ǰ��
            if(press == item.Value.Press) 
                item.Value.SustainTime += Time.deltaTime;//״̬δ�䶯 
            else
            { 
                if (press) 
                    pushList[item.Key] = item.Value.SustainTime;//�����ɿ���ʱ��
                else 
                    releaseList[item.Key] = item.Value.SustainTime; //���水�µ�ʱ��
                item.Value.SustainTime = 0;
                item.Value.Press = press;
            }
        }
        if(pushList.Count > 0 )
            Sys.GetFacade().NotifyObserver("PuskKey", pushList);//����һ�����Window��֪ͨ��Ϣ
        if (releaseList.Count > 0)
            Sys.GetFacade().NotifyObserver("ReleaseKey",releaseList);//����һ�����Window��֪ͨ��Ϣ 
=======
    {
        List<List<KeyCode>> gatherList = new List<List<KeyCode>>();
        gatherList.Add(new List<KeyCode>());//����
        gatherList.Add(new List<KeyCode>()); //̧�� 
        foreach (var item in KeyPressList)
        {
            bool press = Input.GetKey(item.Key);
            if(press == item.Value.Press)
            {
                item.Value.SustainTime += Time.deltaTime;
            } else {
                if (press)
                    gatherList[0].Add(item.Key);
                else
                    gatherList[1].Add(item.Key);
            } 
        } 
        Sys.GetFacade().NotifyObserver("KeyState", gatherList);//����һ�����Window��֪ͨ��Ϣ
        for(int i = 0; i < gatherList.Count; i++) 
        { 
            foreach (var cell in gatherList[i])
            {
                KeyPressList[cell].SustainTime = 0;
                KeyPressList[cell].Press = !KeyPressList[cell].Press; 
            }
        }
>>>>>>> b23e7a4f415aa4e1e531cb8433c539ec3ab83bb1
    }
}