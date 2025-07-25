using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class ScoringSystem : MonoBehaviour
{
    public SOsavedData savedData;
    public int Level;
    public handlepause handlepause;
    public bool PuzzleEnabled;
    public TextMeshProUGUI ScoreText;
    public GameObject Controller;
    
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = 0 + "/" + savedData.lvlScores[Level].quizPoint.Length.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OpenPuzzle()
    {
        Controller.SetActive(false);
        handlepause.CloseDialogue();
        Camera MainCamera = Camera.main;
        if (MainCamera != null)
        {
            MainCamera.enabled = false;
        }
        SceneManager.LoadScene("puzzle", LoadSceneMode.Additive);
        PuzzleEnabled = true;
        StartCoroutine(ApplyLevel());
    }

    private IEnumerator ApplyLevel()
    {
        yield return new WaitForSeconds(1f);
        GameObject.Find("PuzzleController").GetComponent<PuzzleController>().level = Level;
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
                ScoreText.text = score.ToString() + "/" + savedData.lvlScores[Level].quizPoint.Length.ToString();
                if (score<=savedData.lvlScores[Level].quizPoint.Length -1)SaveLoadData.JsonSave(savedData);
                if (score==savedData.lvlScores[Level].quizPoint.Length)
                {
                    OpenPuzzle();
                }
            }
        }
    }
}
