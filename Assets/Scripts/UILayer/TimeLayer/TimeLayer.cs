using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLayer : LayerBase
{
    private Transform Time_Image;
    private Transform Time_Text;
    private Transform Date_Text; 
    void Awake()
    {
        Time_Image = this.transform.Find("Time_Image");
        Time_Text = this.transform.Find("Time_Text");
        Date_Text = this.transform.Find("Date_Text");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
