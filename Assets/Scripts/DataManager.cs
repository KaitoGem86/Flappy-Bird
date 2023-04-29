using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    public static int Points
    {
        get => PlayerPrefs.GetInt("Point", 0);
        set => PlayerPrefs.SetInt("Point", value);
    }

    public static int HighestPoint
    {
        get => PlayerPrefs.GetInt("Highest-Point", 0);
        set => PlayerPrefs.SetInt("Highest-Point", value);
    }
}
