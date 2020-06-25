using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public int Score;
    public int HighScore;

    public void LoadScore()
    {
        //only attempt to load a previous highscore if there is save data
        if (File.Exists(Application.persistentDataPath + "/Highscore.save"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Highscore.save", FileMode.Open);
            Save save = (Save)formatter.Deserialize(file);
            file.Close();

            HighScore = save.Score;
        }
        else
        {
            //all fresh runs are a new highscore
            HighScore = 0;
        }

        //Save the current score as the Highscore if its bigger than the old one
        if (HighScore < Score)
        {
            Save save = new Save(Score);
            
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/Highscore.save");
            formatter.Serialize(file, save);
            file.Close();
        }
    }
    //on restart, reset the score
    public void Restart()
    {
        Score = 0;
    }

}

[Serializable]
public class Save
{
    [SerializeField]
    public int Score;

    public Save(int score)
    {
        Score = score;
    }
    public Save()
    {
        Score = 0;
    }
}
