using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb2d;
    private SoundController sound;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sound = GetComponentInChildren<SoundController>();

        rb2d.velocity = new Vector2(0, speed);
        sound.PlayStart();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().Hurt();
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
