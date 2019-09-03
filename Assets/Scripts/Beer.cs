using System.Collections;
using UnityEngine;

public class Beer : Pickup 
{
    public float timeScale = .75f;

    protected override IEnumerator Effect(GameObject player)
    {
        HideObject();

        float t = 0;
        
        do 
        {
            Time.timeScale = Mathf.Lerp(Time.timeScale, timeScale, t);
            t += 0.5f * Time.deltaTime;
            yield return null;
        } while (Time.timeScale > timeScale);

        yield return new WaitForSeconds(duration);

        t = 0;
        do 
        {
            Time.timeScale = Mathf.Lerp(Time.timeScale, 1, t);
            t +=  0.5f * Time.deltaTime;
            yield return null;
        } while (Time.timeScale < 1);
        
        Destroy(gameObject);
    }
}
