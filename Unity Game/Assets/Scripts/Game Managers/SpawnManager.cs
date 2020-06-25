using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public MasterController Master;
    public GameObject PipePrefab;
    public List<ObstacleScript> MyPipes = new List<ObstacleScript>();
    public int MaxVisiblePipes;

    public float SpawnDelay;
    public float UniversalPipeSpeed;
    private float f_timer;

    void Awake()
    {
        //spawn all the pipes you will need during the game
        for (var i = 0; i < MaxVisiblePipes; i++)
        {
            GameObject g = Instantiate(PipePrefab, Vector3.one * 30, Quaternion.Euler(Vector3.zero), this.transform);
            MyPipes.Add(g.GetComponent<ObstacleScript>());
            MyPipes[i].Spawner = this;
            MyPipes[i].Speed = UniversalPipeSpeed;
            g.SetActive(false);
        }
    }
    
    void Update()
    {
        //while the game is playing, space the spawning of obstacles out by Spawn delay
        if (Master.PlayState)
        {
            f_timer += Time.fixedDeltaTime;
            if (f_timer >= SpawnDelay)
            {
                f_timer = 0;
                //re-enable the required pipe, randomise its y position and place it just outside the cameras view
                ObstacleScript _pipe = MyPipes[0];
                _pipe.gameObject.SetActive(true);

                float _rando = Random.Range(-0.5f, 3.5f);
                
                _pipe.transform.position = new Vector3(Master.MyPlayer.transform.position.x + 5, _rando);

                MyPipes.RemoveAt(0);
                MyPipes.Add(_pipe);

            }
        }
    }

    //when restarting, disable every pipe and reset the spawn timer
    public void Restart()
    {
        f_timer = 0;
        for (var i = 0; i < MyPipes.Count; i++)
        {
            //reset all the pipes
            MyPipes[i].Restart();
        }
    }
}
