using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public int health = 3;
    public float shotInterval;

    private float horizontalInput;
    private bool shooting;
    private float shotTimer;
    private Rigidbody2D rb2d;
    private Animator anim;
    private bool ignoreEnemyCollision;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        shotTimer = 0;
        ignoreEnemyCollision = false;
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.Space)) { shooting = true; }
        else { shooting = false; }
    }

    private void FixedUpdate()
    {
        shotTimer += Time.fixedDeltaTime;

        if (shooting && shotTimer > shotInterval)
        {
            Instantiate(Resources.Load("Bullet"), transform.position, transform.rotation);
            shotTimer = 0;
        }

        rb2d.velocity = new Vector2(horizontalInput, 0) * speed;
        //transform.Translate(new Vector3(horizontalInput, 0) * speed * Time.unscaledDeltaTime);
    }

    private void Die() 
    {
        Instantiate(Resources.Load("ParticleSystem"), transform.position, transform.rotation);
        GameController.gameControllerInstance.GameOver();
        Destroy(gameObject);
    }

    public void Hurt()
    {
        anim.SetTrigger("Hurt");
        health--;

        if (health <= 0) {
            Die();
        }
    }

    public void ToggleEnemyCollision() 
    {
        ignoreEnemyCollision = !ignoreEnemyCollision;
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Enemy"), ignoreEnemyCollision);
    }
}
