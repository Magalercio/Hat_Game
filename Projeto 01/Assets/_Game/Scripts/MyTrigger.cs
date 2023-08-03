using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MtTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Destroyer"))
        {
            Destroy(this.gameObject);
        }
    }
}
