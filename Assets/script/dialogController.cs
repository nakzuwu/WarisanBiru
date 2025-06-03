using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class dialogController : MonoBehaviour
{
    [Header("Settings")]
    public TextMeshProUGUI dialogBox;
    public TextMeshProUGUI npcName;
    public Button[] options;
    public GameObject playerController;

    [Header("Dialogue")]
    public List<DialogContainer> DialogContainers;
    
    private int currentDialog = 0;
    private int dialogIndex = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDialogueTrigger(int id)
    {
        dialogIndex = id;
        currentDialog = 0;
        npcName.text = DialogContainers[dialogIndex].namaNPC;
        dialogBox.text = DialogContainers[dialogIndex].dialogContent[currentDialog];
        for (int i = 0; i < options.Length; i++)
        {
            options[i].gameObject.SetActive(false);
        }
    }

    public void NextLine()
    {
        if (currentDialog < DialogContainers[dialogIndex].dialogContent.Length -1)
        {
            currentDialog++;
            dialogBox.text = DialogContainers[dialogIndex].dialogContent[currentDialog];
        }

        if (currentDialog == DialogContainers[dialogIndex].dialogContent.Length -1)
        {
            for (int i = 0; i < options.Length; i++)
            {
                options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = DialogContainers[dialogIndex].answer[i];
                options[i].gameObject.SetActive(true);
            }
        }
    }

    public void Corrections(int choiceOption)
    {
        if (DialogContainers[dialogIndex].option == choiceOption)
        {
            Debug.Log("benar yey");
            for (int i = 0; i < playerController.transform.childCount; i++)
            {
                playerController.transform.GetChild(i).gameObject.SetActive(true);
            }
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("tetot");
        }
    }
}

[System.Serializable]
public struct DialogContainer
{
    public string namaNPC;
    public string[] dialogContent;
    public int option;
    public string[] answer;
}
