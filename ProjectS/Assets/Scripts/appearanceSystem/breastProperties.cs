using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breastProperties
{
    public int breastSize = 0; //max = 1000 min = 20 20-50:微小的，51-125：微微隆起的， 126-250AAA 251-300AA 301-380A 381-450B 451-550C 551-650D 651-750E 751-850F >851超巨大
    public string breastShape; //风铃型, 外扩型，泪珠型，苗条型，浑圆型，丰满型，狭长型

    public int softness;

    public int nippleLength; //min = 0, max = 5//平的，短的，中等的，明显的，突出的，长的
    public int nippleSize; //min=0 ma = 5//微小的，小的，中等，大的，巨大的

    public Color milkColor;
    public string milkFlavor;

}
