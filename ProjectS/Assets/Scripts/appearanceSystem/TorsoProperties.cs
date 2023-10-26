using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorsoProperties
{
    public int skinType; //min = 0 ²Ò¾øÈËå¾£¬´Ö²Ú£¬Æ½Õû£¬¹â»¬£¬Ë¿³ñ°ã
    public float TorsoWidth;//min = 10, max = 100
    public float muscle;// min = 10£¬ max = 100

    public int legRatio; // min = 1, max = 5


}

public class Wings
{
    public RACE wingsType;
    public int wingSize; //min = 1, max = 5

    public int wingsNum; //in pairs
}

public class tails
{
    public RACE tailType;
    public int tailSize;
    public int tailNum;
    public bool isFur;

}