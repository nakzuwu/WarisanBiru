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
    public Button buttonReset;
    private Button[] buttons;
    

    private void Start()
    {
        RefreshUI();
        // buttonReset.onClick.AddListener(() => ResetData());
    }

    private void Awake()
    {
        SaveLoadData.JsonLoad(gamedata); //woi json
        buttons = buttonCollections.GetComponentsInChildren<Button>();
    }

    public void ResetData()
    {
        Debug.Log("woi json");
        SaveLoadData.ResetAll();
        SaveLoadData.JsonLoad(gamedata);
        SaveLoadData.JsonSave(gamedata);
        RefreshUI();
    }

    private void RefreshUI()
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
}
