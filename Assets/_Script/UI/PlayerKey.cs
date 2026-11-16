using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKey : MonoBehaviour
{
    [SerializeField] private GameObject keyIcon;
    private bool hasKey = false;
    private void Start()
    {
        UpdateIcon();
    }
    public bool AddKey()
    {
        if (hasKey) return false;
        hasKey = true;
        UpdateIcon();
        return true;
    }
    public bool UseKey()
    {
        if (!hasKey) return false;
        hasKey = false;
        UpdateIcon();
        return true;
    }
    private void UpdateIcon()
    {
        keyIcon.SetActive(hasKey);
    }
}
