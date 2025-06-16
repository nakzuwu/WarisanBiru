using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOpuzzleAssets", menuName = "SOpuzzleAssets")]
public class SOpuzzleAssets : ScriptableObject
{
    public List<PuzzleAssets> puzzleAssets = new List<PuzzleAssets>();
}

[Serializable]
public struct PuzzleAssets
{
    public Sprite[] pieces;
    public Sprite[] background;
}
