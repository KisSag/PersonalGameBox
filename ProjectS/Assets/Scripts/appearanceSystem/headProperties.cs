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

    public string mole; //����룬Բ���룬������,��
    public string mole_Location;
    public bool isFreckle;
}

//eyes
public class eyesProperties
{
    public eye leftEye = new eye();
    public eye rightEye = new eye();

    public float isNightVision; //�Ƿ����ҹ������������У��� = 1, else = 0
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

    public bool isEnchated;//�Ƿ񷢹⣬��ħ
}

//ears
public class earsProperties
{
    public RACE earsType;
    public Color earsColor;
    public bool isfurry;

    public bool isEnchated;//�Ƿ񷢹⣬��ħ

    public float earSize; //max = 10(�޴�);
}

//horns
public class hornsProperties
{
    public RACE hornsType;
    public Color hornsColor;

    public float hornSize; //max = 60����ͨ��С13-20�� С�� 8-12�� 3-7΢С�ģ�1-2�������ɼ��ģ�21-30��ģ�31-40�޴�ģ�50-60�Ӵ��
    public bool isEnchated;
}

//lip
public class lipProperties
{
    public float lipSize; //min = 1 max = 10�� ��ϸ�ģ�ӣ��С���ģ�С������ģ����µģ������ģ������ģ���ʵ��
    public Color lipColor;
    public bool isEnchated;
}

//����
public class throatProperties
{
    public SexHoleProperties hole = new SexHoleProperties();
    public Color throatColor;
    public bool isEnchated;
}

//��ͷ
public class tongueProperties
{
    public RACE tongueType;
    public Color tongueColor;
    public bool isEnchated;
    public float tongueLength; //normal = 10cm; max = 60cm
}



