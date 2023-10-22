using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnvironmentData : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float Brightness;
    [SerializeField] float temperature;
    [SerializeField] string weather;

    public void setBrightness(float value) //设置环境亮度
    {
        Brightness = value;
    }
    public void setTemprature(float value) //设置环境温度
    {
        temperature = value;
    }
    public void setWeather(string value) //设置天气
    {
        weather = value;
    }

    public float getEnvironmentBrightness() //返回环境亮度
    {
        return Brightness;
    }
    public float getEnvironmentTemperature() //返回环境温度
    {
        return temperature;
    }
    public string getWeather() //返回天气
    {
        return weather;
    }

}
