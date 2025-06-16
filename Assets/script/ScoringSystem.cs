using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class ScoringSystem : MonoBehaviour
{
    public SOsavedData savedData;
    public int Level;
    public handlepause handlepause;
    public bool PuzzleEnabled;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OpenPuzzle()
    {
        handlepause.CloseDialogue();
        Camera MainCamera = Camera.main;
        if (MainCamera != null)
        {
            MainCamera.enabled = false;
        }
        SceneManager.LoadScene("puzzle", LoadSceneMode.Additive);
        GameObject.Find("PuzzleController").GetComponent<PuzzleController>().level = Level;
        PuzzleEnabled = true;
    }

    public void AddScore(int index)
    {
        savedData.lvlScores[Level].quizPoint[index] = true;
        int score = 0;
        for (int i = 0; i < savedData.lvlScores[Level].quizPoint.Length; i++) 
        {
            if (savedData.lvlScores[Level].quizPoint[i])
            {
                score++;
                if (score==savedData.lvlScores[Level].quizPoint.Length)
                {
                    OpenPuzzle();
                }
            }
        }
    }
}
