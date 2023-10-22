using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeData : MonoBehaviour
{
    [SerializeField] int DayInNumber; //max = 30
    [SerializeField] int MonthInNumber; //max = 12
    [SerializeField] int hour; //max = 24
    [SerializeField] int minute; //max = 60

    string[] DayOfWeek = { "��֮��", "��֮��", "��֮��", "��֮��", "��֮��", "��֮��", "��֮��" };
    string[] Month = { "��˪��", "�亮��", "�紺��", "������", "��ʢ��", "��¶��", "������", "������", "������", "������", "������", "�캮��" };

    // Update is called once per frame
    void Update()
    {
        timeCalculate();
    }

    void timeCalculate() //ʱ�����������������ʱ�����Ծ
    {
        if (MonthInNumber > 12)//�����·�
        {
            MonthInNumber = MonthInNumber - 12;
        }

        if (DayInNumber > 30)//��������
        {
            DayInNumber = DayInNumber - 30;
            MonthInNumber += 1;
        }

        if (hour > 24)//����Сʱ
        {
            hour = hour - 24;
            DayInNumber += 1;
        }

        if (minute > 60)//��������
        {
            minute = minute - 60;
            hour += 1;
        }
    }
    public void addMinute(int value) //����ʱ����
    {
        minute += value;
    }
    public void addHour(int value) //����ʱ��Сʱ
    {
        hour += value;
    }
    public void addDay(int value) //����ʱ����
    {
        DayInNumber += value;
    }
    public void addMonth(int value) //����ʱ����
    {
        MonthInNumber += value;
    }

    public int getMonth_inNumber() //�������ֵ��·�
    {
        return MonthInNumber;
    }
    public string getMonth_inName() //�����·ݵ�����
    {
        return Month[MonthInNumber];
    }
    public int getDay_inNumber()  //�����������
    {
        return DayInNumber;
    }
    public string getDay_inName() //�����������
    {
        return DayOfWeek[DayInNumber];
    }
    public int getHour() //����Сʱ
    {
        return hour;
    }
    public int getMinute() //���ط���
    {
        return minute;
    }
}
