using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerData : MonoBehaviour
{


    // player physical property
    [SerializeField] string name_player;
    [SerializeField] string gender; //male / female / neither
    [SerializeField] int age;
    [SerializeField] int height; // in cm
    [SerializeField] string[] race = new string[2]; //��һ���������壬�ڶ���������
    [SerializeField] float body_Size; // max = 100 mid = 50 //�������ģ����ݵģ���ϸ�ģ������ģ���׼�ģ����ģ������ģ����ֵģ�Բ������//�ñ�����Ҫ�����������״
    [SerializeField] float femininity; //max = 100//�������ŵģ��ǳ�����ζ�ģ�����ζ�ģ����ԣ�Ů�ԣ�Ů��ζ�ģ��ǳ�Ů��ζ�ģ�����Ů��������//�ñ�������������������Ի���Ů��
    [SerializeField] float Mature; //middle = 50, max = 20 = domineering, 0 = loli //for male����̫�����꣬���У����У� for female: ��Ů��������Ů������
    [SerializeField] float muscleDef; //max = 100 //��������ģ������ģ� �����ģ�����ģ������ģ����µģ���ʵ�ģ���׳�ģ������ģ�����������
    [SerializeField] float appearance; //max = 100, normal = 40-50 //�����徵ģ���ª�ģ�����ģ�����ģ�Ѱ���ģ����ڵģ����˾�̾�ģ������ģ���ǵģ�����//

    //ͷ��
    //ͷ�� //һ��2index���飬���û����Ⱦ����color in index1 = index0����Ⱦ��//����Ⱦ��������Ⱦ��������Ⱦ���ߵ�Ⱦ���ͽ���Ⱦ���߽���Ⱦ������Ⱦ�����Ⱦ����������Ⱦ
    [SerializeField] hairProperties hairProperties;



}
