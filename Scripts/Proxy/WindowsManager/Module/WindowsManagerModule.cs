using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using MVCFrame;
using ProxySpace;
using Config.Program;
using LightJson;
namespace ModuleCellSpace
{ 
    //���ڹ���ǰϵͳ�ж��д��ڷ��������չ
    public class WindowsManagerModule : ModuleCell
    {
        //Transform WindowBase = null;
        //List<MainWindowProxy> WindowBaseLayerList;//ά�����еĵ�ǰ�򿪵Ĵ���

        //����һ��������������
       // public MainWindowProxy CreateWindowBaseLayer()
       // {
       //     Transform WindowBase = UnityEngine.Object.Instantiate<Transform>(WindowBase);
       //     MainWindowProxy WindowScript = WindowBase.GetComponent<MainWindowProxy>();
       //     MainWindowProxy WindowScript.InitLayer("UIResource/CanvasPrefab/Bamboo/Hall/HallPanelLayer", list);
       //     Sys.GetFacade().NotifyObserver("AdditionCanvasObject", new AddTypeStruct(CanvasNodeIndex.CENTER, MajorWindow));//����һ�����Window��֪ͨ��Ϣ
       // } 
       // public WindowsManagerModule()
       // {
       // } 
       // public override void OnInit()
       // {
       //     base.OnInit();
       //     WindowBase = Resources.Load<Transform>("UIResource/CanvasPrefab/WindowBaseLayer/WindowBase");//Ѱ��һ���ڵ� 
       // }  
    }
}  