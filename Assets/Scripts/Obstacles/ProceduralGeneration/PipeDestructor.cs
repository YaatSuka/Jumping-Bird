using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeDestructor : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.parent && collision.gameObject.transform.parent.gameObject.tag == "Obstacle") {
            Destroy(collision.gameObject.transform.parent.gameObject);
        }
    }
}
