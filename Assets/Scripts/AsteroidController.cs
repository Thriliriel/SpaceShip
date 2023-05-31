using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    private float speed;
    private GameController gc;

    private void Awake()
    {
        //speed of the asteroid (we can change it for each object, to make slower and faster asteroids)
        speed = 0.5f;
        //find the gamecontroller
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //define the starting position
        transform.position = new Vector3(UnityEngine.Random.Range(-9,9), 5, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //for each tick, the asteroid falls
        transform.position += Vector3.up * speed * -1 * Time.fixedDeltaTime;

        //check collisions
        CheckCollision();
    }

    //check the collisions
    private void CheckCollision()
    {
        //get the collisions
        Collider[] collisions = Physics.OverlapSphere(transform.position, transform.localScale.y / 2);

        //for each collision found
        foreach(Collider col in collisions)
        {
            //if hits the bottom barrier, destroy the asteroid
            if(col.gameObject.tag == "Barrier")
            {
                //destroy asteroid
                Destroy(gameObject);
            }
            else //if hits a laser, destroy both and update the points
            if (col.gameObject.tag == "Laser")
            {
                //update points
                gc.UpdateScore(10);

                //destroy laser
                Destroy(col.gameObject);

                //destroy asteroid
                Destroy(gameObject);
            }
            else //if hits the ship, game over
            if (col.gameObject.name == "Ship")
            {
                //destroy laser
                Destroy(col.gameObject);

                //game over
                gc.GameOver();
            }
        }
    }
}
