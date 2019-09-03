using UnityEngine;

public class Bug : Enemy
{
    public float frequency;
    public float magnitude;

    private float randomTimeSeed;

    private void Awake() {
        randomTimeSeed = Random.Range(1.0f, 10.0f) + Time.deltaTime;
    }

    private void Update()
    { 
        Vector2 vert = Vector2.down * Time.deltaTime * speed;
        Vector2 hor = Vector2.right * Mathf.Sin(Time.time * frequency + randomTimeSeed) * magnitude * Time.deltaTime;
		transform.Translate(vert + hor);
    }
}
