using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AnalysisObjFactory
{
    public static AnalysisObj CreateNetWorkObj()
    {
        AnalysisObj ret = null; 
        ret = new AnalysisObj();
        return ret;
    }
} 