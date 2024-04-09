using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    bool flapInputDetected = false;
    public double deadZone = -14;



    //immortal
    private double immortalZone = 25;
    private float timer = 0f;
    private bool addScore = true;

    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)
                    || Input.GetKeyDown(KeyCode.UpArrow)
                             || Input.GetMouseButtonDown(0))
        {
            flapInputDetected = true;
        }

        if (flapInputDetected && birdIsAlive)
        {
            audioManager.PlayFSX(audioManager.roll);
            myRigidbody.velocity = Vector2.up * flapStrength;
            transform.Rotate(new Vector3(0, 0, -45));
            flapInputDetected = false;
        }

        if (transform.position.y < deadZone)
        {
            if (birdIsAlive)
            {
                audioManager.PlayFSX(audioManager.death);
            }
            logic.gameOver();
            birdIsAlive = false;
            Destroy(gameObject);
        }



        timer += Time.deltaTime;
        if (transform.position.y >= immortalZone)
        {
            if (!addScore)
            {
                logic.addScore(1);
                addScore = true;
            }
            if (timer >= 2f)
            {
                timer -= 2f;
                addScore = false;
            }
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (birdIsAlive)
        {
            audioManager.PlayFSX(audioManager.death);
        }
        logic.gameOver();
        birdIsAlive = false;
    }
}

