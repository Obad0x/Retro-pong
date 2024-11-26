using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovent : MonoBehaviour
{
    // initial launch force
    public float initialForce = 10f;

    // randomness to initial direction
    public float randomness = 30f;

    private Rigidbody2D rb;
    private bool isGameStarted = false;


    // Start is called before the first frame update
     private void Start()
    {
            rb = GetComponent<Rigidbody2D>();

            gameObject.tag = "Ball" ;
    }

    // Update is called once per frame
    private void Update()
    {
      if (!isGameStarted && Input.GetKeyDown("space")) {
        LaunchBall();
      }
    }


         private void LaunchBall(){

    if(rb == null) return;

    // Generate a random angle within a range

    float randomAngle = Random.Range(-randomness , randomness);

    // create a direction vector with the random angle
    Vector2 launchdirection = Quaternion.Euler(0, 0 , randomAngle) * Vector2.right;

    // Randomize initial direction (left or right)
    if (Random.Range(0, 2) == 0){
        launchdirection = -launchdirection;
    }

    // apply the force to launch the ball 
    rb.velocity = launchdirection * initialForce;

    // Mark the game as started 
    isGameStarted = true ;
}


}


