using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    private float speed;

    private void Awake()
    {
        //speed of the laser
        speed = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        //for each tick, the laser goes up
        transform.position += Vector3.up * speed * 1 * Time.fixedDeltaTime;

        //check collisions
        CheckCollision();
    }

    //check the collisions
    private void CheckCollision()
    {
        //get the collisions
        Collider[] collisions = Physics.OverlapSphere(transform.position, transform.localScale.y / 2);

        //for each collision found
        foreach (Collider col in collisions)
        {
            //if hits the bottom barrier, destroy the asteroid
            if (col.gameObject.tag == "Barrier")
            {
                Destroy(gameObject);
            }
        }
    }
}
