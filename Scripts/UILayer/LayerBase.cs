using UnityEngine;

public class LayerBase : MonoBehaviour
{ 
    //更新整个界面
    virtual public void RefreshLayer(object param = null)
    {

    }
    //更新局部界面 
    virtual public void RefreshAssignLayer(int index,object param = null)
    {
        
    }

}
