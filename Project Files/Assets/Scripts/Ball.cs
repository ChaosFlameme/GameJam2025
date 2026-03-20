using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //We need to know the ball belongs to which player
    public Player player;

    Rigidbody2D rb;

    public float minSpeed = 20f;
    public float maxSpeed = 40f;
    public float debugForce = 0f;
    public Vector2 launchForce = new Vector2(0f, 20f);
    Vector2 defaultForce;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0, debugForce), ForceMode2D.Impulse);
        defaultForce = new Vector2(0, 20 * 2 * (player.id - 1) - 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Block block = collision.gameObject.GetComponent<Block>();
        if (block != null)
        {
            block.OnHit(player);
        }
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        if (velocity.magnitude < minSpeed)
        {
            rb.velocity = velocity.normalized * minSpeed;
        }
        if (velocity.magnitude > maxSpeed)
        {
            rb.velocity = velocity.normalized * maxSpeed;
        }
    }


    public void SetOwner(Player player)
    {
        this.player = player;
    }

    public void LaunchSelf()
    {
        rb.isKinematic = false;
        rb.AddForce(launchForce, ForceMode2D.Impulse);
    }
}
