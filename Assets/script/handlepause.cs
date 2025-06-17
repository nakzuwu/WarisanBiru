using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handlepause : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject pauseMenu;
    public GameObject dialogBox;
    public GameObject playerControl;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Paused()
    {
        playerControl.SetActive(false);
        pauseButton.SetActive(false);
        //dialogBox.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void Unpaused()
    {
        playerControl.SetActive(true);
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void OpenDialogue()
    {
        for (int i = 0; i < playerControl.transform.childCount; i++)
        {
            playerControl.transform.GetChild(i).gameObject.SetActive(false);
        }
        dialogBox.SetActive(true);
    }

    public void CloseDialogue()
    {
        for (int i = 0; i < playerControl.transform.childCount; i++)
        {
            playerControl.transform.GetChild(i).gameObject.SetActive(true);
        }
        dialogBox.SetActive(false);
    }
}
