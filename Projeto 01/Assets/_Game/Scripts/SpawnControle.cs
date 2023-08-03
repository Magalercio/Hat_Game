using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControle : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float topDistance, lateralMargin;

    private Vector2 screenWidth;

    private GameController gameController;


    //O que acontece no metodo Awake acontecem antes do Start
    private void Awake()
    {
        Initialize();
    }

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeting faz repetir um metodo apos o start (string nome metodo, tempo para acontecer assim que for chamado o metodo, tempo para repeticao)
        InvokeRepeating("SpawnInvoke", 2.0f, Random.Range(2.0f, 4.0f));
    }

    // Update is called once per frame
   
    private void Initialize()
    {
        screenWidth = Camera.main.ScreenToWorldPoint(new Vector2(Screen.safeArea.width, Screen.safeArea.height));
        Vector2 heightPosition = new Vector2(transform.position.x, Camera.main.orthographicSize + topDistance);
        transform.position = heightPosition;
        gameController = FindObjectOfType<GameController>();
    }


    private void SpawnInvoke()
    {
        StartCoroutine(Spawn());
    }

    //metodos com retorno IEnumerator acontecem depois de um tempo como um span.
    private IEnumerator Spawn()
    {
        if (gameController.gameStarted)
        {
            // o que estiver antes do yield return vai acontecer instantaneo
            yield return new WaitForSeconds(0f);
            //oq estiver aqui em baixo vai acontecer depois do tempo
            transform.position = new Vector2(Random.Range(-screenWidth.x + lateralMargin, screenWidth.x - lateralMargin), transform.position.y);
            // criando a instancia da bola de boliche (objeto, posicao, rotacao)
            GameObject tempBallPrefab = Instantiate(ballPrefab, transform.position, Quaternion.identity) as GameObject;
        }
        else
        {
            yield return null;
        }
    }
}
