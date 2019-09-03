using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float speed;

    private GameObject parent;
    private Vector2 spawnArea;

    private void Start() {
        parent = transform.parent.gameObject;
        spawnArea = parent.GetComponent<BoxCollider2D>().size;
    }

    public void Hurt()
    {
        health--;

        if (health <= 0)
        {
            Die(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerController>().Hurt();
            Die(true);
        }
    }

    public void Die(bool hurtPlayer)
    {
        if (hurtPlayer) {GameController.gameControllerInstance.Reset(); }
        else { GameController.gameControllerInstance.DecreaseTimerLimit(); }

        Instantiate(Resources.Load("ParticleSystem"), transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        transform.position = parent.transform.position + new Vector3(Random.Range(-spawnArea.x / 2, spawnArea.x / 2), 0);
        
        if(speed < 4)
            speed += 0.5f;
    }

}
