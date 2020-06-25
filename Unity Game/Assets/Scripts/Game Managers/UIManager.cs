using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public MasterController Master;
    public Text ScoreText;

    public GameObject StartScreen;
    public GameObject EndScreen;
    public Text HighscoreText;

    private bool b_endstate = true;

    void Update()
    {
        //display the score in the UI
        ScoreText.text = Master.Scoreboard.Score.ToString();
        //disable the endscreen while the game is in Play mode
        if (Master.PlayState)
        {
            if (b_endstate)
            {
                b_endstate = false;
                EndScreen.SetActive(false);
                StartScreen.SetActive(false);
            }

        }
        else
        {
            //when the game is not in play mode enable the end screen and set the text on it to display current score and highscore
            if (!b_endstate)
            {
                b_endstate = true;
                EndScreen.SetActive(true);
                HighscoreText.text = Master.Scoreboard.Score.ToString() + "\n";
                Master.Scoreboard.LoadScore();
                HighscoreText.text += (Master.Scoreboard.Score > Master.Scoreboard.HighScore) ? "New Highscore!" : "Highscore: " + Master.Scoreboard.HighScore;
            }
        }
    }
}
