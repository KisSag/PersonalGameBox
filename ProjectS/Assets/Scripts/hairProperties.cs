using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hairProperties : MonoBehaviour
{

    //ͷ�� //һ��2index���飬���û����Ⱦ����color in index1 = index0����Ⱦ��//����Ⱦ��������Ⱦ��������Ⱦ���ߵ�Ⱦ���ͽ���Ⱦ���߽���Ⱦ������Ⱦ�����Ⱦ����������Ⱦ
    //��
    public Color32[] BackHairColor_main = new Color32[2];
    public string PatternType_BackHairMain;
    public Color32[] BackHairColor_top = new Color32[2];
    public string PatternType_BackHairTop;
    public Color32[] BackHairColor_down = new Color32[2];
    public string PatternType_BackHairDown;
    public Color32[] BackHairColor_inner = new Color32[2];
    public string PatternType_BackHairInner;
    public int BackHairLength; //in cm
    public string BackHairStyle; //�󷢷���
    //ǰ��/����
    public Color32[] FrontHairColor_main = new Color32[2];
    public string PatternType_FronHairMain;
    public Color32[] FronHairColor_top = new Color32[2];
    public string PatternType_FronHairTop;
    public Color32[] FronHairColor_down = new Color32[2];
    public string PatternType_FronHairDown;
    public Color32[] FronHairColor_inner = new Color32[2];
    public string PatternType_FronHairInner;
    public int FrontHairLength; //in cm
    public string FrontHairStyle; //�󷢷���

}
