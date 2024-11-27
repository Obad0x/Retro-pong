using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int Player1Score = 0;
    public int Player2Score = 0;

    public void ScorePoint(int PlayerNumber){
        if(PlayerNumber == 1){
            Player2Score++;
        }else{
            Player1Score++;
        }
        UpdateScoreDisplay();
        ResetBall();
    }

    private void UpdateScoreDisplay(){
        Debug.Log($"Player 1: {Player1Score} - Player 2: {Player2Score}");
    }

    private void ResetBall(){
        GameObject Ball = GameObject.FindWithTag("Ball");
        if(Ball != null){
            BallMovent ballController = Ball.GetComponent<BallMovent>();
            if(ballController!= null){
                ballController.ResetBall();
            }
        }
    }
   
}
