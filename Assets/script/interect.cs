using UnityEngine;
using UnityEngine.UI;

public class interect : MonoBehaviour
{
    public float radius = 0.2f;
    public Button interactButton;
    public dialogController dialogController;
    public int playerID;
    public ScoringSystem scoreSystem;
    private bool hasDetectedPlayer;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        DetectPlayer();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void ButtonInteract()
    {
        dialogController.OnDialogueTrigger(playerID);
        interactButton.interactable = false;
    }

    private void DetectPlayer()
    {
        var hit = Physics2D.OverlapCircle(transform.position, radius, LayerMask.GetMask("player"));

        if (hit != null && hit.CompareTag("Player") && !hasDetectedPlayer)
        {
            if (!scoreSystem.savedData.lvlScores[scoreSystem.Level].quizPoint[playerID])
            {
                interactButton.interactable = true;
                interactButton.onClick.AddListener(() => ButtonInteract());
                hasDetectedPlayer = true;
            }
        }
        else if (hit == null && hasDetectedPlayer)
        {
            interactButton.interactable = false;
            interactButton.onClick.RemoveListener(() => dialogController.OnDialogueTrigger(playerID));
            hasDetectedPlayer = false;
        }
    }
}