using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitLine : MonoBehaviour
{
    public GameManager gameManager;
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag != this.transform.tag)
        {
            if (collision.transform.tag == "Player1")
            {
                gameManager.UpdateScore(0);
                Destroy(collision.gameObject);
            }else if(collision.transform.tag == "Player2")
            {
                gameManager.UpdateScore(1);
                Destroy(collision.gameObject);
            }
        }
        if (collision.transform.tag == this.transform.tag)
        {
            Destroy(collision.gameObject);
        }
    }

}
