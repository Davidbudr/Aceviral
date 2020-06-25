using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterController : MonoBehaviour
{
    public bool PlayState;

    public PlayerScript MyPlayer;
    public ScrollingBackground MyBackground;
    public SpawnManager Spawner;
    public PointManager Scoreboard;
    public UIManager Interface;
    public SoundfxManager Effects;

    private void Awake()
    {
        Spawner.Master = this;
        MyPlayer.Master = this;
        MyBackground.Master = this;
        Interface.Master = this;
    }
    //when resetting the game, make sure the reset is also called in all the important referenced objects
    public void ResetGame()
    {
        MyPlayer.Restart();
        Effects.Restart();
        Spawner.Restart();
        Scoreboard.Restart();
        PlayState = true;
    }
}
