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
        // for (int i = 0; i < puzzleContainer.transform.childCount; i++)
        // {
        //     puzzleContainer.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = puzzleAsset.puzzleAssets[level].pieces[i];
        //     puzzleBackground.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = puzzleAsset.puzzleAssets[level].background[i];
        // }
        RandomizeTarget();
    }

    void Update()
    {
        if (point >= pointToWin && !isGameOver)
        {
            isGameOver = true;
            lvlScore score = savedData.lvlScores[level];
            score.isGameFinished = true;
            savedData.lvlScores[level] = score;
            SaveLoadData.JsonSave(savedData);
            SceneManager.LoadScene("levelselection");
        }
    }
    private void RandomizeTarget()
    {
        var count = puzzleContainer.transform.childCount;

        var indices = new List<int>();
        for (var i = 0; i < count; i++)
            indices.Add(i);

        for (var i = 0; i < count; i++)
        {
            var temp = indices[i];
            var randIndex = Random.Range(i, count);
            indices[i] = indices[randIndex];
            indices[randIndex] = temp;
        }

        for (var i = 0; i < count; i++)
        {
            var targetIndex = indices[i];
            var child = puzzleContainer.transform.GetChild(targetIndex);
            var sprite = puzzleAsset.puzzleAssets[level].pieces[i];
            child.GetComponent<SpriteRenderer>().sprite = sprite;
            child.GetComponent<PuzzlePiece>().objectTarget = puzzleBackground.transform.GetChild(i).transform;
            puzzleBackground.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite =
                puzzleAsset.puzzleAssets[level].background[i];
        }
    }


    public void AddPoint()
    {
        point++;
    }
}
