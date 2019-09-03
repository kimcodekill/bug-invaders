using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public float speed;

    private Vector3 spawnPosition;
    private ParticleSystem particleSystem;
    private SoundController sound;

    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
        sound = GetComponentInChildren<SoundController>();

        spawnPosition = new Vector3(-transform.position.x, transform.position.y, 0);

        if (transform.position.x > 0) { spawnPosition.x += 1; }
        else { spawnPosition.x -= 1; }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, speed) * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Teleport(other.gameObject);
            particleSystem.Play();
            sound.PlayTrigger();
        }
    }

    private void Teleport(GameObject gameObject)
    {
        gameObject.transform.position = spawnPosition;
    }
}
