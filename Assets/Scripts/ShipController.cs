using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private float speed;
    private float dir;
    private bool lockShot;
    public GameObject laserPrefab;

    private void Awake()
    {
        speed = 1f;
        dir = 0;
        lockShot = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get the direction
        dir = Input.GetAxis("Horizontal");

        //get the shot
        if(Input.GetAxis("Jump") > 0 && !lockShot){
            Shoot();
        }

        //move the ship, according the player
        transform.position += Vector3.right * speed * dir * Time.fixedDeltaTime;

        //if the to the boundaries, clamp
        if (transform.position.x <= -9)
        {
            transform.position = new Vector3(-9, transform.position.y, transform.position.z);
        }
        if (transform.position.x >= 9)
        {
            transform.position = new Vector3(9, transform.position.y, transform.position.z);
        }
    }

    //shoot!
    private void Shoot()
    {
        //lock the shoot for a while
        lockShot = true;

        //instantiante the laser at the position of the ship
        Instantiate(laserPrefab, transform);

        //unlock shoots again after x seconds
        StartCoroutine(UnlockShoot(1));
    }

    //function to reset shoots
    IEnumerator UnlockShoot(int x)
    {
        //wait for x seconds
        yield return new WaitForSeconds(x);
        //code here will execute after x seconds
        lockShot = false;
    }
}
