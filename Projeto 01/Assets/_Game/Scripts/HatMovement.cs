using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatMovement : MonoBehaviour
{
    // Serialize field faz com que a variavel mesmo privada apareça no Inspecter do Unity.
    [SerializeField] private float speed;

    private GameController gameController;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        DragTouch();
    }

    private void DragTouch()
    {
        //Verificando se o toque na tela é maior que zero E toque na tela é do tipo movimento & se o jogo esta iniciado e dentro do timer.
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && gameController.gameStarted)
        {
            //passando a posição do dedo na tela
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            //passamos o movimento para o eixo X, passando o valor float 0 para eixo Y e Z.
            //Time.deltaTime normaliza o movimento independente da taxa de frames de um aparelho para o outro.
            transform.Translate(touchDeltaPosition.x * speed * Time.deltaTime, 0f, 0f);
        }
    }
}
