using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ModuleCellSpace;
using MVCFrame;

public class CapacityImage:MonoBehaviour
{ 
    private Image Image;
    public string LoadImagePath = null;
    public string LoadPath { get { return LoadImagePath; } }
    private ImageControlModule ImageControlObj;
    void Start()
    {
        LoadImagePath = LoadImagePath == "" ? null:LoadImagePath;
        InitData();
        InitImage();//找到Image 
        LoadImage(LoadImagePath);//加载一张图片
    }
    public void OnDestroy()
    {
        ImageControlObj.CleanLoadData(this);
    }
    private void InitData()
    {
        ImageControlObj =  Sys.GetFacade().RetrieveModule<ImageControlModule>("ImageControlProxy"); 
    }
    //查询到图片信息
    public void InitImage()
    {
        Image = this.transform.GetComponent<Image>();
        if (!Image)
            Image = this.gameObject.AddComponent<Image>();//先加入一个图片 
    }
    public void LoadImage(string path)
    {
        LoadImagePath = path;//加载路径
        ImageControlObj.LoadImage(this);
    }
    public void SetSprite(Sprite sprite)
    {
        Image.sprite = sprite;
    }
}
