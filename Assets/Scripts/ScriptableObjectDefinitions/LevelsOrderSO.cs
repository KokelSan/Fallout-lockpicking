using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Fallout Lockpicking/New Levels Order", fileName = "_LevelsOrderSO")]
public class LevelsOrderSO : ScriptableObject
{
    public List<DifficultyDefinitionSO> Levels;
}