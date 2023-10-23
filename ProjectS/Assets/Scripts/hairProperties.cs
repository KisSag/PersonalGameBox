using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hairProperties : MonoBehaviour
{

    //头发 //一个2index数组，如果没有挑染，则color in index1 = index0，挑染：//无挑染，横条纹染，竖条纹染，斑点染，低渐层染，高渐层染，内挑染，混合染，独立发束染
    //后发
    public Color32[] BackHairColor_main = new Color32[2];
    public string PatternType_BackHairMain;
    public Color32[] BackHairColor_top = new Color32[2];
    public string PatternType_BackHairTop;
    public Color32[] BackHairColor_down = new Color32[2];
    public string PatternType_BackHairDown;
    public Color32[] BackHairColor_inner = new Color32[2];
    public string PatternType_BackHairInner;
    public int BackHairLength; //in cm
    public string BackHairStyle; //后发发型
    //前发/刘海
    public Color32[] FrontHairColor_main = new Color32[2];
    public string PatternType_FronHairMain;
    public Color32[] FronHairColor_top = new Color32[2];
    public string PatternType_FronHairTop;
    public Color32[] FronHairColor_down = new Color32[2];
    public string PatternType_FronHairDown;
    public Color32[] FronHairColor_inner = new Color32[2];
    public string PatternType_FronHairInner;
    public int FrontHairLength; //in cm
    public string FrontHairStyle; //后发发型

}
