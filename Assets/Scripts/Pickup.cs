using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class Pickup : MonoBehaviour
{
    public GameObject PickupEffect;
    public float duration;
    public float fallingSpeed;
    public float rotationSpeed;

    private Rigidbody2D rb2d;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = Vector3.down * fallingSpeed;
        rb2d.angularVelocity = rotationSpeed;
    }

    protected virtual IEnumerator Effect(GameObject player)
    {
        Debug.Log("Effect not implemented");

        HideObject();

        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) 
        {
            StartCoroutine(Effect(other.gameObject));
        }
    }

    protected void HideObject() 
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponentInChildren<UnityEngine.Experimental.Rendering.Universal.Light2D>().enabled = false;
    }
}