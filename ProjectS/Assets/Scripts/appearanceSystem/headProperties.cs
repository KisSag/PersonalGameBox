using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headProperties
{
    public eyesProperties eyesProperties = new eyesProperties();
    public earsProperties earsProperties = new earsProperties();
    public hornsProperties hornsProperties = new hornsProperties();
    public lipProperties lipProperties = new lipProperties();
    public throatProperties throatProperties = new throatProperties();
    public tongueProperties tongueProperties = new tongueProperties();
    public hairProperties hairProperties = new hairProperties();

    public string mole; //泪滴痣，圆形痣，心形痣,无
    public string mole_Location;
    public bool isFreckle;
}

//eyes
public class eyesProperties
{
    public eye leftEye = new eye();
    public eye rightEye = new eye();

    public float isNightVision; //是否具有夜视能力，如果有，则 = 1, else = 0
    public float visualAcuity; //1 is standard min = 0 = blind, max = 2


}

public class eye
{
    public string eyeShape;

    public string irisShape;
    public Color irisColor;
    public string pupilShape;
    public Color pupilColor;
    public Color scleraColor;

    public bool isEnchated;//是否发光，附魔
}

//ears
public class earsProperties
{
    public RACE earsType;
    public Color earsColor;
    public bool isfurry;

    public bool isEnchated;//是否发光，附魔

    public float earSize; //max = 10(巨大);
}

//horns
public class hornsProperties
{
    public RACE hornsType;
    public Color hornsColor;

    public float hornSize; //max = 60，普通大小13-20， 小的 8-12， 3-7微小的，1-2几乎不可见的，21-30大的，31-40巨大的，50-60庞大的
    public bool isEnchated;
}

//lip
public class lipProperties
{
    public float lipSize; //min = 1 max = 10， 纤细的，樱桃小嘴般的，小巧玲珑的，标致的，饱满的，丰满的，厚实的
    public Color lipColor;
    public bool isEnchated;
}

//喉咙
public class throatProperties
{
    public SexHoleProperties hole = new SexHoleProperties();
    public Color throatColor;
    public bool isEnchated;
}

//舌头
public class tongueProperties
{
    public RACE tongueType;
    public Color tongueColor;
    public bool isEnchated;
    public float tongueLength; //normal = 10cm; max = 60cm
}



