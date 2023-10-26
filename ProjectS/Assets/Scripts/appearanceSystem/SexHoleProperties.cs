using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SexHoleProperties //这个文件时是为任何可以插入的位置的一个综合属性
{
    public float capacity; //最大插入尺寸（非拉伸）
    public float deeps; //最长插入尺寸（非拉伸）

    public int wetness; //湿度（平常）

    public int elasticity; //normal = 3, max = 5, min = 1

    public float capacity_pain;
    public float deeps_pain;

}
