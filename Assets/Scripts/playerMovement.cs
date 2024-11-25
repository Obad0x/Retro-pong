using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
   public float moveSpeed = 10f;

   public float minY =-2.7f;
   public float maxY = 2.7f;

        public GameObject ball;

    // Update is called once per frame
   private void Update()
    {
        // Move the player up and down
            float verticalInput = Input.GetAxis("Vertical");

            // calculate new position
            Vector3 newposition = transform.position + Vector3.up * verticalInput * moveSpeed * Time.deltaTime;

            // clamp the position of the paddle to stay within screen at all times
        newposition.y = Mathf.Clamp(newposition.y, minY , maxY);

            // update paddle position
        transform.position = newposition;
    }

    // private void OnCollisionEnter2D(Collision2D other) {
    //     if(collision.gameObject.compareTag("Ball")){
            
    //         Rigidbody2D ballRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

    //         if(ballRigidbody != null){
    //             float hitFactor = (collision.transform.position.y - transform.position.y);

    //             Vector2 reflectedDirection = Vector2.Reflect(ballRigidbody.velocity , collision.contacts[0].normal);

    //             reflectedDirection.y += hitfactor * 2f;

    //             ballRigidbody.velocity = reflectedDirection.normalized * ballRigidbody.velocity.magnitude;
    //         }
    //     }


    // }
}
