using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGeneration : MonoBehaviour
{
    public GameObject pipe;
    public float xPadding = 3f;
    public float yPadding = 1.2f;
    public float xOffset =  4.5f;

    private GameObject parent;
    private float timer = 0f;

    private IDictionary<float, int> movingVerticalRates = new Dictionary<float, int>();
    private IDictionary<float, int> movingHorizontalRates = new Dictionary<float, int>();

    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.Find("Obstacles");

        movingVerticalRates[0f] = 10;
        movingVerticalRates[20f] = 8;
        movingVerticalRates[30f] = 5;
        movingVerticalRates[60f] = 2;

        movingHorizontalRates[0f] = 30;
        movingHorizontalRates[20f] = 10;
        movingHorizontalRates[45f] = 8;
        movingHorizontalRates[60f] = 5;
    }

    void Update()
    {
        timer += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.parent && collision.gameObject.transform.parent.gameObject.tag == "Obstacle") {
            float x = transform.position.x + xOffset + Random.Range(0, xPadding);
            float y = transform.position.y + Random.Range(-yPadding, yPadding);
            Vector3 position = new Vector3(x, y, -15f);

            GameObject obstacle = Instantiate(pipe, position, Quaternion.identity, parent.transform);

            // Vertical move
            float i = 0f;
            foreach(KeyValuePair<float, int> rate in movingVerticalRates) {
                if (timer >= rate.Key) {
                    i = rate.Key;
                }
            }

            int moveVertically = Random.Range(0, movingVerticalRates[i] + 1);
            if (moveVertically == 0) {
                obstacle.GetComponent<ObstaclesMoving>().isMovingVertically = true;
            }

            // Horizontal move
            float j = 0f;
            foreach(KeyValuePair<float, int> rate in movingHorizontalRates) {
                if (timer >= rate.Key) {
                    j = rate.Key;
                }
            }

            int moveHorizontally = Random.Range(0, movingHorizontalRates[j] + 1);
            if (moveHorizontally == 0) {
                obstacle.GetComponent<ObstaclesMoving>().isMovingHorizontally = true;
            }
        }
    }
}
