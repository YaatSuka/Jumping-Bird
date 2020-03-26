using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesMoving : MonoBehaviour
{
    public bool isMovingVertically = false;
    public bool isMovingHorizontally = false;
    public float yMin = - 2f;
    public float yMax = 2f;
    public float xMargin = 3.5f;

    private int sens = 1;
    private GameObject player;
    private Transform nextPipe = null;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        StartCoroutine("SetNextPipe");
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingVertically) {
            MoveVertically();
        }
        else if (isMovingHorizontally) {
            MoveHorizontally();
        }
    }

    private void MoveVertically()
    {
        if (transform.localPosition.y <= yMin || transform.localPosition.y >= yMax) {
            sens *= -1;
        }

        if (sens == 1) {
            transform.Translate(Vector2.up * Time.deltaTime, Space.World);
        } else {
            transform.Translate(Vector2.down * Time.deltaTime, Space.World);
        }
    }

    private void MoveHorizontally()
    {
        if (!nextPipe) {
            return;
        }

        if (transform.position.x >= nextPipe.position.x - xMargin) {
            isMovingHorizontally = false;
        }
        else if (transform.position.x <= player.transform.position.x) {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
    }

    private IEnumerator SetNextPipe() {
        while (!(nextPipe = GetNextPipe())) {
            yield return new WaitForSeconds(0.5f);
        }
        yield return null;
    }

    private Transform GetNextPipe()
    {
        Transform self = transform;
        Transform parent = self.parent;
        for (int i = 0; i < parent.childCount - 1; i++) {
            if (parent.GetChild(i) == self && parent.GetChild(i + 1)) {
                return parent.GetChild(i + 1);
            }
        }
        return null;
    }
}
