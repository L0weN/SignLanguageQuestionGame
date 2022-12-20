using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoSingleton<TimeController>
{
    void Update()
    {
        UIManager.Instance.timeSlider.value -= Time.deltaTime;
        if (UIManager.Instance.timeSlider.value <= 0)
        {
            ScoreController.Instance.SaveHighScore();
        }
    }

    public void AddTime()
    {
        UIManager.Instance.timeSlider.value += 3;
    }
}
