using UnityEngine;
using MVCFrame; 
using ProxySpace; 
using Config.Program;
using ModuleCellSpace;
public class GameControl : MonoBehaviour
{
    NetModule NetModuleGrid;
    //获取到网络模块
    void Awake() 
	{
		Sys.GetFacade().RegisterProxy(new InitPorxy());
        InitData();
        //Sys.GetFacade().NotifyObserver("OpenPlayerInfomationLayer");//发送一个添加Window的通知消息
        //Sys.GetFacade().NotifyObserver("OepnTimeLayer");//发送一个添加Window的通知消息 
    }
    //初始化当前的数据
    private void InitData()
    {
        NetModuleGrid = Sys.GetFacade().RetrieveModule<NetModule>("NetWorkProxy"); 
    }

    // Update is called once per frame
    void Update()
    {  
        if(NetModuleGrid != null) NetModuleGrid.NetMsgExecuteStepHandle();  //网络消息处理 
    }
};  
