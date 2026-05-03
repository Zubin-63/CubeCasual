using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static SoundManagerScript instance;
    [SerializeField]
    private AudioSource soundFX;
    [SerializeField]
    private AudioClip landClip, DeathClip, IceBreakClip, GameOverClip;
    private void Awake()
    {
        if (instance == null)
        instance = this; 
    }
    public void LandSound()
    {
        soundFX.clip = landClip;
        soundFX.Play();
    }
    public void IceBreakSound()
    {
        soundFX.clip = IceBreakClip;
        soundFX.Play();
    }
    public void DeathSound()
    {
        soundFX.clip = DeathClip;
        soundFX.Play();
    }
    public void GameOverSound()
    {
        soundFX.clip = GameOverClip;
        soundFX.Play();
    }
}
