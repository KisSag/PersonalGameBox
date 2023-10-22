using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeUIDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TimeUI;
    [SerializeField] TimeData timedata;

    // Update is called once per frame
    void Update()
    {
        string uitext = timedata.getMonth_inName() + " " + timedata.getDay_inName() + " " + timedata.getHour() + ":" + timedata.getMinute();
        TimeUI.text = uitext;
    }
}
