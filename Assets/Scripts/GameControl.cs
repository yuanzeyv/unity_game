using UnityEngine;
using MVCFrame;
using ProxySpace;
<<<<<<< HEAD
=======
using System;
using Config.Program;
>>>>>>> b23e7a4f415aa4e1e531cb8433c539ec3ab83bb1
using ModuleCellSpace;
using UnityEngine.EventSystems;
public class GameControl : MonoBehaviour
<<<<<<< HEAD
{  
=======
{
>>>>>>> b23e7a4f415aa4e1e531cb8433c539ec3ab83bb1
    NetModule NetModuleGrid; 
    MouseControlModule MouseModuleGrid;
    KeyControlModule KeyModuleGrid;
    SyncNotifyModule SyncNotifyModuleGrid;
<<<<<<< HEAD
    TimeModule TimeModuleGrid; 
    void Awake()
	{
		Sys.GetFacade().RegisterProxy(new InitPorxy());//ע���ʼ������
        InitData();
    } 
    //��ʼ����ǰ������
    private void InitData()
    {
        //NetModuleGrid = Sys.GetFacade().RetrieveModule<NetModule>("NetWorkProxy");
        //MouseModuleGrid = Sys.GetFacade().RetrieveModule<MouseControlModule>("InputManagerProxy");
        //KeyModuleGrid = Sys.GetFacade().RetrieveModule<KeyControlModule>("InputManagerProxy");
        //SyncNotifyModuleGrid = Sys.GetFacade().RetrieveModule<SyncNotifyModule>("SyncNotifyContorlProxy");
        //TimeModuleGrid = Sys.GetFacade().RetrieveModule<TimeModule>("SystemServiceProxy");
=======
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
>>>>>>> b23e7a4f415aa4e1e531cb8433c539ec3ab83bb1
    }

    // Update is called once per frame
    void Update()
    {
        double tick = Time.deltaTime;
<<<<<<< HEAD
        //if (NetModuleGrid != null) NetModuleGrid.NetMsgExecuteStepHandle();  //������Ϣ����
       // if (SyncNotifyModuleGrid != null) SyncNotifyModuleGrid.Tick();  //�첽֪ͨ��Ϣ����
       // if (MouseModuleGrid != null) MouseModuleGrid.Tick();  //������Ϣ����
        //if (KeyModuleGrid != null) KeyModuleGrid.Tick();  //������Ϣ���� 
        //if (TimeModuleGrid != null) TimeModuleGrid.Tick(tick);  //������Ϣ����  
=======
        if (NetModuleGrid != null) NetModuleGrid.NetMsgExecuteStepHandle();  //������Ϣ����
        if (SyncNotifyModuleGrid != null) SyncNotifyModuleGrid.Tick();  //�첽֪ͨ��Ϣ����
        if (MouseModuleGrid != null) MouseModuleGrid.Tick();  //������Ϣ����
        if (KeyModuleGrid != null) KeyModuleGrid.Tick();  //������Ϣ���� 
        if (TimeModuleGrid != null) TimeModuleGrid.Tick(tick);  //������Ϣ����  
>>>>>>> b23e7a4f415aa4e1e531cb8433c539ec3ab83bb1
    }
};  
