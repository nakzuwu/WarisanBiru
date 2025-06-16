using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    public SOsavedData savedData;
    public int Level;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
                    Debug.Log("Game Finished");
                }
            }
        }
    }
}
