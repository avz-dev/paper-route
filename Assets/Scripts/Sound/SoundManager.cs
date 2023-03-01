using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSrc;
    public AudioClip[] sounds; // 0: Hit, 1: Low, 2: Med, 3: High, 4: Pause
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void PlaySound(int soundIndex) {
        audioSrc.clip = sounds[soundIndex];
        audioSrc.Play();
    }


}
