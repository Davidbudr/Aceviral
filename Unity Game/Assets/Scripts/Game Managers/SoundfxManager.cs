using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundfxManager : MonoBehaviour
{
    public AudioSource ScoringAudioSource;
    public AudioSource FlappingAudioSource;
    public AudioClip LoseClip;
    public AudioClip PointClip;
    public AudioClip FlapClip;

   public void PlayScore()
    {
        ScoringAudioSource.clip = PointClip;
        ScoringAudioSource.Play();
    }
    public void PlayFlap()
    {
        FlappingAudioSource.clip = FlapClip;
        FlappingAudioSource.Play();
    }
    public void PlayLoss()
    {
        ScoringAudioSource.clip = LoseClip;
        ScoringAudioSource.Play();
    }

    public void Restart()
    {
        ScoringAudioSource.Stop();
        FlappingAudioSource.Stop();
    }
}
