using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    public BirdScript bird;
    
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        //bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
        GameObject birdObject = GameObject.FindGameObjectWithTag("Bird");
        if (birdObject != null)
        {
            bird = birdObject.GetComponent<BirdScript>();
        }
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 3 && bird != null && bird.birdIsAlive) 
        {
            logic.addScore(1);
        }
    }
}
