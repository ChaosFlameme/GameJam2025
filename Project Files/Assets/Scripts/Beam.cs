using System.Collections;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public float freezeDuration = 0.5f;
    public Color freezeColor = Color.blue;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        StartCoroutine(Freeze(collider.gameObject));
    }

    IEnumerator Freeze(GameObject thing)
    {
        Player player = thing.GetComponent<Player>();
        Rigidbody2D rb = thing.GetComponent<Rigidbody2D>();
        if (player != null)
        {
            player.isFreezing = true;
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
                rb.isKinematic = true;
            }
        }

        yield return new WaitForSeconds(freezeDuration);

        if (player != null)
        {
            player.isFreezing = false;
            if (rb != null)
            {
                rb.isKinematic = false;
            }
        }

    }
}


