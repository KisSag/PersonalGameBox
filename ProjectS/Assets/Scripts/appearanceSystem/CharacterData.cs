using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData
{


    // player physical property
    public string chara_Name;
    public string gender; //male / female / neither
    public int age;
    public int height; // in cm
    public RACE Race;//��һ���������壬�ڶ���������

    
    public float femininity; //middle = 50, max = 100 //for male����̫�����꣬���У����У� for female: ��Ů��������Ů������
    public float faceAppearance; //max = 100, normal = 40-50 //�����徵ģ���ª�ģ�����ģ�����ģ�Ѱ���ģ����ڵģ����˾�̾�ģ������ģ���ǵģ�����//

    

    //ͷ��
    public headProperties headProperties = new headProperties();
    //�ز�
    public breastProperties breastProperties = new breastProperties();
    //����



}
