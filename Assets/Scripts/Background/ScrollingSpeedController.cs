using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingSpeedController : MonoBehaviour
{
    public GameObject background;
    public GameObject obtacles;
    public GameObject ground;

    private BackgroundScrolling backgroundScrolling;
    private ObstaclesScrolling obtaclesScrolling;
    private GroundScrolling groundScrolling;
    private float timer = 15f;
    private int idx = 1;
    private bool frozen = false;

    private IDictionary<int, float> dict = new Dictionary<int, float>();

    // Start is called before the first frame update
    void Start()
    {
        backgroundScrolling = background.GetComponent<BackgroundScrolling>();
        obtaclesScrolling = obtacles.GetComponent<ObstaclesScrolling>();
        groundScrolling = ground.GetComponent<GroundScrolling>();

        dict[0] = 3f;
        dict[1] = 3.5f;
        dict[2] = 4f;
        dict[3] = 4.5f;
        dict[4] = 5f;
        dict[5] = 5.5f;
        dict[6] = 6f;
        dict[7] = 6.5f;

        obtaclesScrolling.speed = dict[0];
        groundScrolling.updateSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0 && !frozen) {
            obtaclesScrolling.speed = dict[idx];
            groundScrolling.updateSpeed();

            if (idx + 1 < dict.Count) {
                idx++;
            }
            timer = 5f;
        }

        timer -= Time.deltaTime;
    }

    public void Freeze()
    {
        frozen = true;
        backgroundScrolling.updateSpeed(0f);
        obtaclesScrolling.speed = 0f;
        groundScrolling.updateSpeed();
    }
}
