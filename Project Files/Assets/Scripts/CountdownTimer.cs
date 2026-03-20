using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 10f;
    public TMP_Text countdownText;
    private float currentTime;

    void Start()
    {
        // Initialize the current time
        currentTime = countdownTime;
        UpdateTimerText();
    }

    void Update()
    {
        // Decrease the current time
        currentTime -= Time.deltaTime;

        // Clamp the current time to zero
        if (currentTime < 0)
        {
            currentTime = 0;
        }

        // Update the timer text
        UpdateTimerText();

        // Optionally, trigger some event when the countdown reaches zero
        if (currentTime == 0)
        {
            OnCountdownEnd();
        }
    }

    void UpdateTimerText()
    {
        // Format the time as minutes and seconds
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        // Update the text element
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void OnCountdownEnd()
    {
        // This function is called when the countdown reaches zero
        // Add any end-of-countdown logic here
        Debug.Log("Countdown ended");
    }
}
