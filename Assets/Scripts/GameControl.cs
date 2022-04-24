using UnityEngine;
using MVCFrame;
using ProxySpace;
using System;
using Config.Program;
using ModuleCellSpace;
using UnityEngine.EventSystems;
public class GameControl : MonoBehaviour
{
    NetModule NetModuleGrid; 
    MouseControlModule MouseModuleGrid;
    KeyControlModule KeyModuleGrid;
    SyncNotifyModule SyncNotifyModuleGrid;
    TimeModule TimeModuleGrid;
    //获取到网络模块
    void Awake()
	{
		Sys.GetFacade().RegisterProxy(new InitPorxy());
        InitData(); 
    }
    //初始化当前的数据
    private void InitData()
    {
        NetModuleGrid = Sys.GetFacade().RetrieveModule<NetModule>("NetWorkProxy");
        MouseModuleGrid = Sys.GetFacade().RetrieveModule<MouseControlModule>("InputManagerProxy");
        KeyModuleGrid = Sys.GetFacade().RetrieveModule<KeyControlModule>("InputManagerProxy");
        SyncNotifyModuleGrid = Sys.GetFacade().RetrieveModule<SyncNotifyModule>("SyncNotifyContorlProxy");
        TimeModuleGrid = Sys.GetFacade().RetrieveModule<TimeModule>("SystemServiceProxy");
    }

    // Update is called once per frame
    void Update()
    {
        double tick = Time.deltaTime;
        if (NetModuleGrid != null) NetModuleGrid.NetMsgExecuteStepHandle();  //网络消息处理
        if (SyncNotifyModuleGrid != null) SyncNotifyModuleGrid.Tick();  //异步通知消息处理
        if (MouseModuleGrid != null) MouseModuleGrid.Tick();  //网络消息处理
        if (KeyModuleGrid != null) KeyModuleGrid.Tick();  //网络消息处理 
        if (TimeModuleGrid != null) TimeModuleGrid.Tick(tick);  //网络消息处理  
    }
};  
