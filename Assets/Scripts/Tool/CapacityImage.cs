using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CapacityImage:MonoBehaviour
{
    public Sprite DefaultImage;
    public Image image;
    public bool IsLoad=false; 
    void Awake()
    { 
        if(image.sprite == null )
        {
            if (DefaultImage)
            {
                image.sprite = DefaultImage;
            }
            IsLoad = true;
        }
    }
    public void LoadTexture()
    { 
    }
    public void Update()
    { 
        if(IsLoad)
            this.transform.Rotate(new Vector3(0, 0, 1), -50 * Time.deltaTime);
    }
}
