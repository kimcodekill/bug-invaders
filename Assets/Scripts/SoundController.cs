using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip startSound;
    public AudioClip loopingSound;
    public AudioClip hurtSound;
    public AudioClip deathSound;
    public AudioClip triggerSound;

    public bool randomPitch;
    public bool looping;

    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();

        if (randomPitch)
        {
            source.pitch = Random.Range(.9f, 1.1f);
        }
    }

    private void Update()
    {
        if (looping && !source.isPlaying)
        {
            source.PlayOneShot(loopingSound);
        }
    }

    public void PlayStart()
    {
        source.PlayOneShot(startSound);
    }

    public void PlayHurt()
    {
        source.PlayOneShot(hurtSound);
    }

    public void PlayDeath()
    {
        source.PlayOneShot(deathSound);
    }

    public void PlayTrigger()
    {
        source.PlayOneShot(triggerSound);
    }

    public bool isPlaying { get { return source.isPlaying; } }
}