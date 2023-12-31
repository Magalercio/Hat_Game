using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MtTrigger : MonoBehaviour
{
    private GameController gameController;
    private UIController uiController;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
        uiController = FindObjectOfType<UIController>();
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Destroyer"))
        {
            Destroy(this.gameObject);
        }
        else if (target.gameObject.CompareTag("point"))
        {
            gameController.score++;
            uiController.txtScore.text = gameController.score.ToString();
            Destroy(this.gameObject);
        }
    }
}
