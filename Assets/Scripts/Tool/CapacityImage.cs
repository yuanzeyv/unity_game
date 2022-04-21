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
        InitImage();//�ҵ�Image 
        LoadImage(LoadImagePath);//����һ��ͼƬ
    }
    public void OnDestroy()
    {
        ImageControlObj.CleanLoadData(this);
    }
    private void InitData()
    {
        ImageControlObj =  Sys.GetFacade().RetrieveModule<ImageControlModule>("ImageControlProxy"); 
    }
    //��ѯ��ͼƬ��Ϣ
    public void InitImage()
    {
        Image = this.transform.GetComponent<Image>();
        if (!Image)
            Image = this.gameObject.AddComponent<Image>();//�ȼ���һ��ͼƬ 
    }
    public void LoadImage(string path)
    {
        LoadImagePath = path;//����·��
        ImageControlObj.LoadImage(this);
    }
    public void SetSprite(Sprite sprite)
    {
        Image.sprite = sprite;
    }
}
