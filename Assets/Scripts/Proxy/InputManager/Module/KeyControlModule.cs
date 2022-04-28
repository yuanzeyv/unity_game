using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
public class KeyStruct {
    public KeyCode KeyListen;
    public float SustainTime;//持续时间
    public bool Press;//按下
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
        var pushList = new Dictionary<KeyCode,float>();//按下
        var releaseList = new Dictionary<KeyCode, float>();//抬起 
        foreach (var item in KeyPressList)
        {
            bool press = Input.GetKey(item.Key);//获取到当前的
            if(press == item.Value.Press) 
                item.Value.SustainTime += Time.deltaTime;//状态未变动 
            else
            { 
                if (press) 
                    pushList[item.Key] = item.Value.SustainTime;//保存松开的时长
                else 
                    releaseList[item.Key] = item.Value.SustainTime; //保存按下的时长
                item.Value.SustainTime = 0;
                item.Value.Press = press;
            }
        }
        if(pushList.Count > 0 )
            Sys.GetFacade().NotifyObserver("PuskKey", pushList);//发送一个添加Window的通知消息
        if (releaseList.Count > 0)
            Sys.GetFacade().NotifyObserver("ReleaseKey",releaseList);//发送一个添加Window的通知消息 
=======
    {
        List<List<KeyCode>> gatherList = new List<List<KeyCode>>();
        gatherList.Add(new List<KeyCode>());//按下
        gatherList.Add(new List<KeyCode>()); //抬起 
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
        Sys.GetFacade().NotifyObserver("KeyState", gatherList);//发送一个添加Window的通知消息
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