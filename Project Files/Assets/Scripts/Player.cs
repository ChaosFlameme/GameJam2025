using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int id;

    //------------------Knock knock are you awake?-------------
    // SpriteRenderer playerSprite;
    public bool isFreezing;
    //public Color freezeColor = Color.blue;
    // Color originColor;

    //-------------------------Ball----------------------------
    //We need to identify the player for the ball to know it belongs to who and the properties
    [SerializeField] bool readyToLaunch;
    Ball waitingBall;
    public int damage = 1; //Damage that the ball of the player can create 
    public GameObject ballPrefab;
    // private Ball[] current_balls; //This should be list

    //----------------Car or plate...or whatever it is------------------------
    public float moveSpeed = 10f;
    public float inertia = 0.9f;

    private Rigidbody2D rb;
    float moveInput;
    Vector2 currentVelocity;
    float borderLeft = -22f;
    float borderRight = 22f;

    //----------------EcoSystem, guess we can put it in the player, yeah? Since it's sperate for each---------------
    [SerializeField] private int golds = 0;

    public int Golds
    {
        get { return golds; }
        set { golds = value; }
    }


    void Start()
    {
        // playerSprite = GetComponent<SpriteRenderer>();
        // originColor = playerSprite.color;
        rb = GetComponent<Rigidbody2D>();
        isFreezing = false;
        
        CreateBall();

        StartCoroutine(AddGoldOverTime());
    }

    //--------------------Updates--------------------------------
    void Update()
    {
        if (!isFreezing)
        {
            moveInput = Input.GetAxisRaw("Horizontal" + id);

            LaunchBall();//Don't worry, itself will check if launchball is needed or not
        }


    }

    void FixedUpdate()
    {
        currentVelocity.x *= inertia;

        if (moveInput != 0)
        {
            currentVelocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }
        rb.velocity = currentVelocity;

        Vector2 clampedPosition = rb.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, borderLeft, borderRight);
        rb.position = clampedPosition;
    }


    //----------------------Instantiates---------------------------
    public bool CreateBall()
    {
        float ball_offset = 1f;
        if (id == 2)
        {
            ball_offset = -1f;
        }

        if (ballPrefab != null && readyToLaunch == false)
        {
            //Debug.Log(transform.position+new Vector3(0,ball_offset,0));
            Vector3 ballPosition = transform.position + new Vector3(0, ball_offset, 0);
            GameObject ballInstance = Instantiate(ballPrefab, ballPosition, Quaternion.identity);
            ballInstance.transform.parent = this.transform;
            ballInstance.GetComponent<Rigidbody2D>().isKinematic = true;
            waitingBall = ballInstance.GetComponent<Ball>();
            waitingBall.SetOwner(this);
            readyToLaunch = true;
            return true;
        }
        return false;
    }

    public void LaunchBall()
    {
        if (readyToLaunch)
        {
            if (Input.GetButtonDown("LaunchBall" + id))
            {
                waitingBall.LaunchSelf();
                waitingBall = null;
                readyToLaunch = false;
            }

        }
    }

    private IEnumerator AddGoldOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Golds += 5;
            //Debug.Log("Golds: " + Golds);
        }
    }

}
