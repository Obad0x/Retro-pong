using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour
{
    // Reference to the ball
    public GameObject ball;

    // Difficulty settings
    public enum AIDifficulty
    {
        Easy,
        Medium,
        Hard
    }
    public AIDifficulty difficulty = AIDifficulty.Medium;

    // Movement parameters
    public float moveSpeed = 5f;
    public float paddleHeight = 2f;

    // Screen bounds
    public float minY = -4f;
    public float maxY = 4f;

    // Prediction and error variables
    private float predictionAccuracy = 1f;
    private float trackingSmoothing = 1f;

    private void Update()
    {
        if (ball == null) return;

        // Different AI strategies based on difficulty
        switch (difficulty)
        {
            case AIDifficulty.Easy:
                MovePaddleEasy();
                break;
            case AIDifficulty.Medium:
                MovePaddleMedium();
                break;
            case AIDifficulty.Hard:
                MovePaddleHard();
                break;
        }
    }

    private void MovePaddleEasy()
    {
        // Simple vertical tracking with some randomness
        float targetY = Mathf.Lerp(transform.position.y, ball.transform.position.y, 0.5f);
        targetY += Random.Range(-1f, 1f); // Add some randomness
        MoveTowardsTarget(targetY);
    }

    private void MovePaddleMedium()
    {
        // More accurate tracking with slight prediction
        Vector2 ballVelocity = ball.GetComponent<Rigidbody2D>().velocity;
        float predictedY = ball.transform.position.y + (ballVelocity.y * predictionAccuracy);
        
        // Smooth movement towards predicted position
        float targetY = Mathf.Lerp(transform.position.y, predictedY, trackingSmoothing * Time.deltaTime);
        MoveTowardsTarget(targetY);
    }

    private void MovePaddleHard()
    {
        // Precise tracking with full ball prediction
        Rigidbody2D ballRigidbody = ball.GetComponent<Rigidbody2D>();
        Vector2 ballVelocity = ballRigidbody.velocity;
        
        // Predict exact intersection point
        float timeToReach = Mathf.Abs((transform.position.x - ball.transform.position.x) / ballVelocity.x);
        float predictedY = ball.transform.position.y + (ballVelocity.y * timeToReach);
        
        MoveTowardsTarget(predictedY);
    }

    private void MoveTowardsTarget(float targetY)
    {
        // Clamp the target position within screen bounds
        targetY = Mathf.Clamp(targetY, minY, maxY);

        // Calculate movement direction
        float moveDirection = Mathf.Sign(targetY - transform.position.y);
        
        // Calculate new position
        Vector3 newPosition = transform.position + Vector3.up * moveDirection * moveSpeed * Time.deltaTime;
        
        // Clamp the new position
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        
        // Update paddle position
        transform.position = newPosition;
    }

    // Optional: Method to dynamically change difficulty
    public void SetDifficulty(AIDifficulty newDifficulty)
    {
        difficulty = newDifficulty;
        
        // Adjust parameters based on difficulty
        switch (newDifficulty)
        {
            case AIDifficulty.Easy:
                moveSpeed = 3f;
                predictionAccuracy = 0.5f;
                trackingSmoothing = 0.5f;
                break;
            case AIDifficulty.Medium:
                moveSpeed = 5f;
                predictionAccuracy = 0.8f;
                trackingSmoothing = 1f;
                break;
            case AIDifficulty.Hard:
                moveSpeed = 7f;
                predictionAccuracy = 1f;
                trackingSmoothing = 2f;
                break;
        }
    }
}
