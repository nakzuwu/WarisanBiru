using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOSavedData", menuName = "SOSavedData")]
public class SOsavedData : ScriptableObject
{
    public List<lvlScore> lvlScores = new();
}

[Serializable]
public struct lvlScore
{
    public string name;
    public bool isGameFinished;
    public bool[] quizPoint;
}