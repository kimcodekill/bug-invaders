using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : Pickup
{
    public float shotIntervalScale = .5f;

    protected override IEnumerator Effect(GameObject player) 
    {
        HideObject();

        player.GetComponent<PlayerController>().shotInterval *= shotIntervalScale;

        yield return new WaitForSeconds(duration);

        player.GetComponent<PlayerController>().shotInterval /= shotIntervalScale;
        
        Destroy(gameObject);
    }
}
