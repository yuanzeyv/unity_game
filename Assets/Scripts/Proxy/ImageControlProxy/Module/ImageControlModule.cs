using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LightJson;
using MVCFrame;
using Config.Program;
using ProxySpace;
using UnityEngine.UI;
namespace ModuleCellSpace
{
    public class ImageControlModule : ModuleCell
    {
        GameControl GameControlObj; 
        Coroutine RotateCoroutine;//转圈携程的句柄
        Sprite DefaultSprite;//默认的图片 
        Sprite LoadingSprite;//加载的图片的图片 
        public Dictionary<string, Sprite> ImageList = new Dictionary<string, Sprite>();

        private Dictionary<CapacityImage, string> LoadImageObjList = new Dictionary<CapacityImage, string>();//每个图片对应要加载的路径
        private Dictionary<CapacityImage, Transform> LoadImageTransList = new Dictionary<CapacityImage, Transform>();//所有的等待图片的 Transfrom
        private Dictionary<string, List<CapacityImage>> LoadImagePathList = new Dictionary<string, List<CapacityImage>>();//有多少图片等待这个 路径 加载完成

        //将图片加入到其中
        public ImageControlModule()
        {
        }
        IEnumerator RotateCoroutineHandle()
        {
            while (true)
            { 
                yield return new WaitForFixedUpdate();
                List<CapacityImage> otherList = new List<CapacityImage>(); 
                foreach (var item in LoadImageTransList)
                { 
                    if (AuthLoadImage(item.Key))//如果已经找到了 ，清除当前图片的加载数据
                    {
                        item.Key.SetSprite(ImageList[item.Key.LoadPath]); 
                        otherList.Add(item.Key);
                    }
                    item.Value.Rotate(new Vector3(0, 0, 1), -100 * Time.deltaTime);
                }
                foreach (var item in otherList)
                {
                    CleanLoadData(item);
                }
            }
        }
        public override void OnInit()
        {
            GameControlObj = GameObject.Find("GameControl").transform.GetComponent<GameControl>();
            DefaultSprite = Resources.Load<Sprite>("Image/public/default");//初始化默认的图片
            LoadingSprite = Resources.Load<Sprite>("Image/public/loading");//初始化默认的图片
            RotateCoroutine = GameControlObj.StartCoroutine(RotateCoroutineHandle()); 
            NetModule NetModule = Sys.GetFacade().RetrieveModule<NetModule>("NetWorkProxy");  
        }  
        private bool AuthLoadImage(CapacityImage capacityImage)
        {
            if (!LoadImageObjList.ContainsKey(capacityImage))
                return false;
            string imagePath = LoadImageObjList[capacityImage];
            return ImageList.ContainsKey(imagePath); 
        }
        //删除加载信息
        public void CleanLoadData(CapacityImage capacityImage)
        {
            LoadImageObjList.Remove(capacityImage);
            LoadImageTransList.Remove(capacityImage);
            if (LoadImagePathList.ContainsKey(capacityImage.LoadPath))
            {
                LoadImagePathList[capacityImage.LoadPath].Remove(capacityImage);
                if (LoadImagePathList.Count == 0)
                    LoadImagePathList[capacityImage.LoadPath] = null;//删除当前的列表 
            }
        }
        //准备加载一张图片
        public void LoadImage(CapacityImage capacityImage)
        {
            string FrontName = null;
            if (LoadImageObjList.ContainsKey(capacityImage))//如果当前是第一次添加
                FrontName = LoadImageObjList[capacityImage];
            if (FrontName == null && capacityImage.LoadPath == null) //上一次没有加载 并且 这一次也不想加载
            {
                capacityImage.SetSprite(DefaultSprite);
                return;
            }
            if (FrontName == capacityImage.LoadPath) //前一次加载与这一次加载相同
                return;
            if ((FrontName != null && capacityImage.LoadPath == null) || AuthLoadImage(capacityImage)) //上一次有加载 这一次不想加载了
            {
                Sprite sprite = DefaultSprite;
                if (AuthLoadImage(capacityImage)) 
                    sprite = ImageList[capacityImage.LoadPath];
                capacityImage.SetSprite(sprite);
                CleanLoadData(capacityImage);
                return;
            } 
            if (FrontName != null)//前一次有加载 这一次想替换
            {
                CleanLoadData(capacityImage);
            } 
            capacityImage.SetSprite(LoadingSprite);
            LoadImageObjList[capacityImage] = capacityImage.LoadPath;
            LoadImageTransList[capacityImage] = capacityImage.transform;
            if (!LoadImagePathList.ContainsKey(capacityImage.LoadPath))
                LoadImagePathList[capacityImage.LoadPath] = new List<CapacityImage>();
            LoadImagePathList[capacityImage.LoadPath].Add(capacityImage); 
        }
    }
} 