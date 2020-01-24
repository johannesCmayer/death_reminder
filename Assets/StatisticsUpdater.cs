using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StatisticsUpdater : MonoBehaviour
{
    public TextMeshProUGUI percentLived;
    public TextMeshProUGUI precentLeft;
    public Slider timeSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        percentLived.text = SetTimeLeft.timer.PercentLived.ToString("F8");
        precentLeft.text = (100 - SetTimeLeft.timer.PercentLived).ToString("F8");
        timeSlider.value = (float)(SetTimeLeft.timer.PercentLived) / 100;
    }
}
