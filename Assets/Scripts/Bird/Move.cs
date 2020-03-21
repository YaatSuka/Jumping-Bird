using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float jumpSpeed = 6.0f;
    public float introTime = 0.5f;

    private Rigidbody2D rb;
    private AudioSource audioSource;
    private bool dead = false;
    private bool started = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        Invoke("PlayIntro", introTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (started && !dead && (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))) {
            rb.velocity = Vector2.up * jumpSpeed;
            if (AudioSettings.Sound) {
                audioSource.Play();
            }
        }   
    }

    public void GameOver()
    {
        dead = true;
    }

    void PlayIntro()
    {
        started = true;
        rb.constraints = RigidbodyConstraints2D.None;
    }
}
