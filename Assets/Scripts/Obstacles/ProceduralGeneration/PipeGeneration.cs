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

    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.Find("Obstacles");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.parent && collision.gameObject.transform.parent.gameObject.tag == "Obstacle") {
            float x = transform.position.x + xOffset + Random.Range(0, xPadding);
            float y = transform.position.y + Random.Range(-yPadding, yPadding);
            Vector3 position = new Vector3(x, y, -15f);

            Instantiate(pipe, position, Quaternion.identity, parent.transform);
        }
    }
}
