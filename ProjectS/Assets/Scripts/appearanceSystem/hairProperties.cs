using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hairProperties
{
    
    //后发
    public hairComponments backHair = new hairComponments();
    //前发/刘海
    public hairComponments foreHair = new hairComponments();

}

public class hairComponments
{
    public string hairStyle;
    //一个2index数组，如果没有挑染，则color in index1 = index0，挑染：//无挑染，横条纹染，竖条纹染，斑点染，低渐层染，高渐层染，内挑染，混合染，独立发束染
    public Color[] topHairColor = new Color[2];
    public Color[] mainHairColor = new Color[2];
    public Color[] bottomHairColor = new Color[2];
    public string patternType;
    public int hairLength;//in cm
}
