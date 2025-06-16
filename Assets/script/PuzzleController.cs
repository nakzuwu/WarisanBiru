using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleController : MonoBehaviour
{
    public SOpuzzleAssets puzzleAsset;
    public GameObject puzzleContainer;
    public GameObject puzzleBackground;
    public SOsavedData savedData;
    public int level;
    private bool isGameOver;
    private int point;
    private int pointToWin;

    void Start()
    {
        pointToWin = puzzleContainer.transform.childCount;
        for (int i = 0; i < puzzleContainer.transform.childCount; i++)
        {
            puzzleContainer.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = puzzleAsset.puzzleAssets[level].pieces[i];
            puzzleBackground.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = puzzleAsset.puzzleAssets[level].background[i];
        }
    }

    void Update()
    {
        if (point >= pointToWin && !isGameOver)
        {
            isGameOver = true;
            lvlScore score = savedData.lvlScores[level]; // Copy struct
            score.isGameFinished = true;
            savedData.lvlScores[level] = score;
            SceneManager.LoadScene("levelselection");
        }
    }

    public void AddPoint()
    {
        point++;
    }
}
