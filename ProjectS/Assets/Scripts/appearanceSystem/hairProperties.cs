using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hairProperties
{
    
    //��
    public hairComponments backHair = new hairComponments();
    //ǰ��/����
    public hairComponments foreHair = new hairComponments();

}

public class hairComponments
{
    public string hairStyle;
    //һ��2index���飬���û����Ⱦ����color in index1 = index0����Ⱦ��//����Ⱦ��������Ⱦ��������Ⱦ���ߵ�Ⱦ���ͽ���Ⱦ���߽���Ⱦ������Ⱦ�����Ⱦ����������Ⱦ
    public Color[] topHairColor = new Color[2];
    public Color[] mainHairColor = new Color[2];
    public Color[] bottomHairColor = new Color[2];
    public string patternType;
    public int hairLength;//in cm
}
