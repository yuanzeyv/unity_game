using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using MVCFrame;
using ProxySpace;
using Config.Program;
using LightJson;
namespace ModuleCellSpace
{ 
    //用于管理当前系统中多有窗口方便后期拓展
    public class WindowsManagerModule : ModuleCell
    {
        //Transform WindowBase = null;
        //List<MainWindowProxy> WindowBaseLayerList;//维护所有的当前打开的窗口

        //创建一个基础容器窗口
       // public MainWindowProxy CreateWindowBaseLayer()
       // {
       //     Transform WindowBase = UnityEngine.Object.Instantiate<Transform>(WindowBase);
       //     MainWindowProxy WindowScript = WindowBase.GetComponent<MainWindowProxy>();
       //     MainWindowProxy WindowScript.InitLayer("UIResource/CanvasPrefab/Bamboo/Hall/HallPanelLayer", list);
       //     Sys.GetFacade().NotifyObserver("AdditionCanvasObject", new AddTypeStruct(CanvasNodeIndex.CENTER, MajorWindow));//发送一个添加Window的通知消息
       // } 
       // public WindowsManagerModule()
       // {
       // } 
       // public override void OnInit()
       // {
       //     base.OnInit();
       //     WindowBase = Resources.Load<Transform>("UIResource/CanvasPrefab/WindowBaseLayer/WindowBase");//寻找一个节点 
       // }  
    }
}  