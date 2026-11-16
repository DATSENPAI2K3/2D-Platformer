using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    private float elapsedTime;
    private void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateText();
    }
    private void UpdateText()
    {
        int minutes = (int)(elapsedTime / 60f);
        float seconds = elapsedTime % 60f;
        timerText.text = string.Format("{0:00}:{1:00.00}", minutes, seconds);
    }
}
