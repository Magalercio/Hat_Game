using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLimits : MonoBehaviour
{

    private float minX, maxX;
    [SerializeField] private float minDistance, maxDistance;


    // Start is called before the first frame update
    void Start()
    {
        SetMinAndMaxX();  
    }

    // Update is called once per frame
    void Update()
    {
        SetPlayerPosition();
    }

    private void SetMinAndMaxX()
    {
        // pegando a largura da área segura e passando para bound atravez da camera que foi transformada em um ponto na tela do mundo da Unity.
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.safeArea.width, 0f, 0f));
        maxX = bounds.x - maxDistance;
        minX = -bounds.x + minDistance;
    }

    private void SetPlayerPosition()
    {
        if(transform.position.x < minX)
        {
            // verificação lado esquerdo:
            Vector3 temp = transform.position;
            temp.x = minX;
            transform.position = temp;
        }

        else if (transform.position.x > maxX)
        {
            // verificação lado direito:
            Vector3 temp = transform.position;
            temp.x = maxX;
            transform.position = temp;
        }
    }
}
