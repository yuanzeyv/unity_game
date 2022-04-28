using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using MVCFrame;

public class MainWindowProxy : MonoBehaviour
{
    public Transform ResizeBoard;
    public Button TopButton;
    public Button DownButton;
    public Button LeftButton;
    public Button RightButton;
    public Button DragButton;
    public Button MinSizeButton;
    public Button MaxSizeButton;
    public Button CloseButton;
    public Button IconButton;
    public Text WindowText;
    public Transform ContentPlane; 
    public Vector3 DragOffset;

    private RectTransform WindowObj;//被代理的对象
    private WindowBaseLayer WindowLayer;
    public void InitLayer(string minorWindowPath, Notifycation param)
    { 
        RectTransform windowObj = Resources.Load<RectTransform>(minorWindowPath);//寻找一个节点
        if (!windowObj) return;
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(windowObj.rect.width + 2 , windowObj.rect.height + 27 ); 
        WindowObj = UnityEngine.Object.Instantiate<RectTransform>(windowObj);
        WindowLayer = WindowObj.GetComponent<WindowBaseLayer>();
        if (WindowLayer)
            WindowLayer.InitLayer(param);
        WindowObj.SetParent(ContentPlane, false);
    }
    void CloseClick()
    {
        if (!WindowLayer) return;
        WindowLayer.CloseLayer();
    }
    void MinSizeClick()
    {
        if (!WindowLayer) return;
        WindowLayer.MinSizeLayer();
    }
    void MaxSizeClick()
    {
        if (!WindowLayer) return; 

        WindowLayer.MaxSizeLayer();
    }
    void IconClick()
    { 
        if (!WindowLayer) return;
        WindowLayer.IconLayerClick();
    }

    //更新整个界面
    public void RefreshLayer(object param = null)
    { 
        if (!WindowLayer) return;  
        WindowLayer.RefreshLayer(param);
    }
    //更新局部界面 
    public void RefreshAssignLayer(int index, object param = null)
    {
        if (!WindowLayer) return;
        WindowLayer.RefreshAssignLayer(index, param);
    }
    //拖动窗口顶部可以移动窗口 
    public void OnDrgeTopButton(object eventData)
    {
        if (DragOffset.z == 1) return;
        PointerEventData mesObj = eventData as PointerEventData; 
        Vector2 toVec2 = new Vector2(0, 0);
        this.transform.position = new Vector3(mesObj.position.x, mesObj.position.y, 0) + DragOffset; 
    } 
    public void OnMouseDownButton(object eventData)
    {
        PointerEventData mesObj = eventData as PointerEventData;
        DragOffset = this.transform.position - new Vector3(mesObj.pressPosition.x, mesObj.pressPosition.y); 
    }
    public void OnMouseUpButton(object eventData)
    {
        PointerEventData mesObj = eventData as PointerEventData;
        DragOffset.z = 1; 
    }
    // Start is called before the first frame update
    void Start()
    {
        CloseButton.onClick.AddListener(CloseClick);
        MaxSizeButton.onClick.AddListener(MaxSizeClick);
        MinSizeButton.onClick.AddListener(MinSizeClick);
        IconButton.onClick.AddListener(IconClick); 
    }
     
}
