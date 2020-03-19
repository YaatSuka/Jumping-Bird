using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesScoreController : MonoBehaviour
{
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            gameController.IncreaseScore(1);
        }
    }
}
