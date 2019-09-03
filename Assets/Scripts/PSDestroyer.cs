using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSDestroyer : MonoBehaviour
{
    ParticleSystem system;
    SoundController sound;

    private void Awake()
    {
        system = GetComponent<ParticleSystem>();
        sound = GetComponentInChildren<SoundController>();
    }

    private void Start()
    {
        sound.PlayStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (!system.isPlaying && !sound.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
