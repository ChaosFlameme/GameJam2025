using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int scoreValue = 100;
    public int goalScore = 1000;
    public int[] scores = { 0, 0 };

    public GameObject endScreenCanvas;
    public TMP_Text winningMessage;

    public TMP_Text text_score_P1;
    public TMP_Text text_score_P2;
    

    private void Start() {
        endScreenCanvas.SetActive(false);
    }

    public void UpdateScore(int player_index)
    {
        scores[player_index] += scoreValue;
        Debug.Log(scores[0]+scores[1]);
        text_score_P1.text = string.Format("Score: {0}", scores[0]);
        text_score_P2.text = string.Format("Score: {0}", scores[1]);
        GameEndCheck();
    }


    void GameEndCheck(){
        if (scores[0]>= goalScore)
        {
            Debug.Log("Player 1 wins1");
            EndScreen(1);
        }
        if (scores[1] >= goalScore)
        {
            Debug.Log("Player 2 wins!");
            EndScreen(2);
        }
    }

    void EndScreen(int playerId){
        winningMessage.text = string.Format("Player {0} wins!", playerId);
        endScreenCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void ReplayGame(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
