using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class selectionManager : MonoBehaviour
{
    public SOsavedData gamedata;
    public GameObject buttonCollections;
    private Button[] buttons;

    private void Start()
    {
        for (int i = 0; i < gamedata.lvlScores.Count; i++)
        {
            Debug.Log(gamedata.lvlScores[i].name);
            if (i < buttons.Length) // Ensure index is within bounds
            {
                buttons[i+1].interactable = gamedata.lvlScores[i].isGameFinished;
                int index = i; // Capture index safely for the lambda function
                buttons[i].onClick.AddListener(() => SceneManager.LoadScene(gamedata.lvlScores[index].name));
                buttons[0].interactable = true;
            }
        }
    }

    private void Awake()
    {
        buttons = buttonCollections.GetComponentsInChildren<Button>();
    }
}
