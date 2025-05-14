using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interect : MonoBehaviour
{
    public float radius = 0.2f;
    public Button interactButton;
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
        if (hit != null && hit.CompareTag("Player"))
        {
            interactButton.interactable = true;
        }
        else
        {
            interactButton.interactable = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
