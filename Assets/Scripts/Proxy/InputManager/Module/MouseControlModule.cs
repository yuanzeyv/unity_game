using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;

public class MouseStruct
{
    public Vector3 MousePosition;//鼠标的当前位置
    public Vector3 OffsetPosition;//与上一帧的偏差
}

public class MouseControlModule : ModuleCell
{ 
    public Vector3 FrontMousePosition;//鼠标的当前位置
    MouseStruct MouseData = new MouseStruct();
    public MouseControlModule()
    {
        MouseData.MousePosition = Input.mousePosition;
    }
    public override void OnInit()
    {
        base.OnInit();
    }
    public void Tick()
    { 
        FrontMousePosition = MouseData.MousePosition; 
        MouseData.MousePosition = Input.mousePosition;
        MouseData.OffsetPosition = MouseData.MousePosition - FrontMousePosition; 
        Sys.GetFacade().NotifyObserver("MouseState", MouseData);//发送一个添加Window的通知消息
    }
}