using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeData : MonoBehaviour
{
    [SerializeField] int DayInNumber; //max = 30
    [SerializeField] int MonthInNumber; //max = 12
    [SerializeField] int hour; //max = 24
    [SerializeField] int minute; //max = 60

    string[] DayOfWeek = { "空之日", "炎之日", "天之日", "魂之日", "龙之日", "月之日", "阳之日" };
    string[] Month = { "白霜月", "落寒月", "早春月", "逢雨月", "花盛月", "白露月", "夏至月", "大暑月", "落暑月", "立秋月", "至冬月", "天寒月" };

    // Update is called once per frame
    void Update()
    {
        timeCalculate();
    }

    void timeCalculate() //时间计算器，用于修正时间的跳跃
    {
        if (MonthInNumber > 12)//纠正月份
        {
            MonthInNumber = MonthInNumber - 12;
        }

        if (DayInNumber > 30)//纠正天数
        {
            DayInNumber = DayInNumber - 30;
            MonthInNumber += 1;
        }

        if (hour > 24)//纠正小时
        {
            hour = hour - 24;
            DayInNumber += 1;
        }

        if (minute > 60)//纠正分钟
        {
            minute = minute - 60;
            hour += 1;
        }
    }
    public void addMinute(int value) //增加时间秒
    {
        minute += value;
    }
    public void addHour(int value) //增加时间小时
    {
        hour += value;
    }
    public void addDay(int value) //增加时间天
    {
        DayInNumber += value;
    }
    public void addMonth(int value) //增加时间月
    {
        MonthInNumber += value;
    }

    public int getMonth_inNumber() //返回数字的月份
    {
        return MonthInNumber;
    }
    public string getMonth_inName() //返回月份的名字
    {
        return Month[MonthInNumber];
    }
    public int getDay_inNumber()  //返回天的数字
    {
        return DayInNumber;
    }
    public string getDay_inName() //返回天的名字
    {
        return DayOfWeek[DayInNumber];
    }
    public int getHour() //返回小时
    {
        return hour;
    }
    public int getMinute() //返回分钟
    {
        return minute;
    }
}
