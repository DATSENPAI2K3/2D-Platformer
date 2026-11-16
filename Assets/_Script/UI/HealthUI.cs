using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite halfHeart;
    [SerializeField] private Sprite emptyHeart;
    public void UpdateHearts(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            int heartValue = currentHealth - i * 2;
            if (heartValue >= 2) hearts[i].sprite = fullHeart;
            else if (heartValue == 1) hearts[i].sprite = halfHeart;
            else hearts[i].sprite = emptyHeart;
        }
    }
}
