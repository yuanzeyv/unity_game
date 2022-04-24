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
    //��ȡ������ģ��
    void Awake()
	{
		Sys.GetFacade().RegisterProxy(new InitPorxy());
        InitData(); 
    }
    //��ʼ����ǰ������
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
        if (NetModuleGrid != null) NetModuleGrid.NetMsgExecuteStepHandle();  //������Ϣ����
        if (SyncNotifyModuleGrid != null) SyncNotifyModuleGrid.Tick();  //�첽֪ͨ��Ϣ����
        if (MouseModuleGrid != null) MouseModuleGrid.Tick();  //������Ϣ����
        if (KeyModuleGrid != null) KeyModuleGrid.Tick();  //������Ϣ���� 
        if (TimeModuleGrid != null) TimeModuleGrid.Tick(tick);  //������Ϣ����  
    }
};  
