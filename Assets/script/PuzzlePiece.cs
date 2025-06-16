using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public PuzzleController puzzleController;
    public Transform objectTarget;
    SpriteRenderer spriteRenderer;
    Vector2 initialPosition;
    float deltaX,deltaY;
    private bool locked;
    

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialPosition = transform.position;
    }

    void Update()
    {
        if (Input.touchCount > 0 && !locked)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>()==Physics2D.OverlapPoint(touchPosition))          
                    {
                        spriteRenderer.sortingOrder = 10;
                        deltaX = touchPosition.x - transform.position.x;
                        deltaY = touchPosition.y - transform.position.y;
                    }
                    break;
                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPosition))
                    {
                        transform.position = new Vector2(touchPosition.x - deltaX, touchPosition.y - deltaY);
                    }
                    else
                    {
                        transform.position = new Vector2(initialPosition.x, initialPosition.y);
                    }
                    break;
                case TouchPhase.Ended:
                    if (Mathf.Abs(transform.position.x - objectTarget.position.x) <= 0.2f &&
                        Mathf.Abs(transform.position.y - objectTarget.position.y) <= 0.2f)
                    {
                        transform.position = new Vector2(objectTarget.position.x, objectTarget.position.y);
                        locked = true;
                        spriteRenderer.sortingOrder = 9;
                        puzzleController.AddPoint();
                    }
                    else
                    {
                        transform.position = new Vector2(initialPosition.x, initialPosition.y);
                    }
                    break; 
            }
        }
    }
}
