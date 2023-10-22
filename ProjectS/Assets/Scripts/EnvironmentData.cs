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

    public void setBrightness(float value) //���û�������
    {
        Brightness = value;
    }
    public void setTemprature(float value) //���û����¶�
    {
        temperature = value;
    }
    public void setWeather(string value) //��������
    {
        weather = value;
    }

    public float getEnvironmentBrightness() //���ػ�������
    {
        return Brightness;
    }
    public float getEnvironmentTemperature() //���ػ����¶�
    {
        return temperature;
    }
    public string getWeather() //��������
    {
        return weather;
    }

}
