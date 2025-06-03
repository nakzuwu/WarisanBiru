using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class interect : MonoBehaviour
{
    public float radius = 0.2f;
    public Button interactButton;
    public dialogController dialogController;
    public int playerID;
    private bool hasDetectedPlayer = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
    }

    void DetectPlayer()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, LayerMask.GetMask("player"));
    
        if (hit != null && hit.CompareTag("Player") && !hasDetectedPlayer)
        {
            interactButton.interactable = true;
            interactButton.onClick.AddListener(() => dialogController.OnDialogueTrigger(playerID));
            hasDetectedPlayer = true;
        }
        else if (hit == null && hasDetectedPlayer)
        {
            interactButton.interactable = false;
            interactButton.onClick.RemoveListener(() => dialogController.OnDialogueTrigger(playerID));
            hasDetectedPlayer = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
