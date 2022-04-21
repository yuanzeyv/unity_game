using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;

public class MouseStruct
{
    public Vector3 MousePosition;//���ĵ�ǰλ��
    public Vector3 OffsetPosition;//����һ֡��ƫ��
}

public class MouseControlModule : ModuleCell
{ 
    public Vector3 FrontMousePosition;//���ĵ�ǰλ��
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
        Sys.GetFacade().NotifyObserver("MouseState", MouseData);//����һ�����Window��֪ͨ��Ϣ
    }
}