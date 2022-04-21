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
    }
}