using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScrolling : MonoBehaviour
{
    public bool isIndependant = false;
    public float speed = 0.05f;
    public GameObject obstacleObj;

    private Material material;
    private ObstaclesScrolling obstacles;
    private Vector2 offset;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
        if (!isIndependant) {
            obstacles = obstacleObj.GetComponent<ObstaclesScrolling>();
            offset = new Vector2(obstacles.speed / 13, 0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isIndependant) {
            material.mainTextureOffset += new Vector2(speed, 0) * Time.deltaTime;
        } else {
            material.mainTextureOffset += offset * Time.deltaTime;
        }
    }

    public void updateSpeed()
    {
        if (!isIndependant) {
            offset = new Vector2(obstacles.speed / 13, 0);
        }
    }
}
