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
        Coroutine RotateCoroutine;//תȦЯ�̵ľ��
        Sprite DefaultSprite;//Ĭ�ϵ�ͼƬ 
        Sprite LoadingSprite;//���ص�ͼƬ��ͼƬ 
        public Dictionary<string, Sprite> ImageList = new Dictionary<string, Sprite>();

        private Dictionary<CapacityImage, string> LoadImageObjList = new Dictionary<CapacityImage, string>();//ÿ��ͼƬ��ӦҪ���ص�·��
        private Dictionary<CapacityImage, Transform> LoadImageTransList = new Dictionary<CapacityImage, Transform>();//���еĵȴ�ͼƬ�� Transfrom
        private Dictionary<string, List<CapacityImage>> LoadImagePathList = new Dictionary<string, List<CapacityImage>>();//�ж���ͼƬ�ȴ���� ·�� �������

        //��ͼƬ���뵽����
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
                    if (AuthLoadImage(item.Key))//����Ѿ��ҵ��� �������ǰͼƬ�ļ�������
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
            DefaultSprite = Resources.Load<Sprite>("Image/public/default");//��ʼ��Ĭ�ϵ�ͼƬ
            LoadingSprite = Resources.Load<Sprite>("Image/public/loading");//��ʼ��Ĭ�ϵ�ͼƬ
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
        //ɾ��������Ϣ
        public void CleanLoadData(CapacityImage capacityImage)
        {
            LoadImageObjList.Remove(capacityImage);
            LoadImageTransList.Remove(capacityImage);
            if (LoadImagePathList.ContainsKey(capacityImage.LoadPath))
            {
                LoadImagePathList[capacityImage.LoadPath].Remove(capacityImage);
                if (LoadImagePathList.Count == 0)
                    LoadImagePathList[capacityImage.LoadPath] = null;//ɾ����ǰ���б� 
            }
        }
        //׼������һ��ͼƬ
        public void LoadImage(CapacityImage capacityImage)
        {
            string FrontName = null;
            if (LoadImageObjList.ContainsKey(capacityImage))//�����ǰ�ǵ�һ�����
                FrontName = LoadImageObjList[capacityImage];
            if (FrontName == null && capacityImage.LoadPath == null) //��һ��û�м��� ���� ��һ��Ҳ�������
            {
                capacityImage.SetSprite(DefaultSprite);
                return;
            }
            if (FrontName == capacityImage.LoadPath) //ǰһ�μ�������һ�μ�����ͬ
                return;
            if ((FrontName != null && capacityImage.LoadPath == null) || AuthLoadImage(capacityImage)) //��һ���м��� ��һ�β��������
            {
                Sprite sprite = DefaultSprite;
                if (AuthLoadImage(capacityImage)) 
                    sprite = ImageList[capacityImage.LoadPath];
                capacityImage.SetSprite(sprite);
                CleanLoadData(capacityImage);
                return;
            } 
            if (FrontName != null)//ǰһ���м��� ��һ�����滻
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