using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public SpawnManager Spawner;
    public float Speed = 0.01f;
    private bool b_scored;

    void Update()
    {
            //make sure the game is not paused or ended
            if (Spawner.Master.PlayState)
            {
                this.transform.Translate(Vector3.left * Speed);
                if (this.transform.position.x < Spawner.Master.MyPlayer.transform.position.x && !b_scored)
                {
                    Spawner.Master.Effects.PlayScore();
                    Spawner.Master.Scoreboard.Score++;
                    b_scored = true;
                }
            }

        //deactive the object if 
        if (this.transform.position.x < (Camera.main.orthographicSize * -Camera.main.aspect)-1)
        {
            //reset the object once its outside the camera
            Restart();
        }
    }
    public void Restart()
    {
        b_scored = false;
        this.transform.position = Vector3.one * 30;
        this.gameObject.SetActive(false);
    }
}
