using UnityEngine;
using MVCFrame; 
using ProxySpace; 
using Config.Program;
using ModuleCellSpace;
public class GameControl : MonoBehaviour
{
    NetModule NetModuleGrid;
    //��ȡ������ģ��
    void Awake() 
	{
		Sys.GetFacade().RegisterProxy(new InitPorxy());
        InitData();
        //Sys.GetFacade().NotifyObserver("OpenPlayerInfomationLayer");//����һ�����Window��֪ͨ��Ϣ
        //Sys.GetFacade().NotifyObserver("OepnTimeLayer");//����һ�����Window��֪ͨ��Ϣ 
    }
    //��ʼ����ǰ������
    private void InitData()
    {
        NetModuleGrid = Sys.GetFacade().RetrieveModule<NetModule>("NetWorkProxy"); 
    }

    // Update is called once per frame
    void Update()
    {  
        if(NetModuleGrid != null) NetModuleGrid.NetMsgExecuteStepHandle();  //������Ϣ���� 
    }
};  
