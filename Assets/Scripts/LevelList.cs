using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level")]
public class LevelList : ScriptableObject
{
    public LevelData[] levels;
}
