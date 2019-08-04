using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /* My Stuff
    public float speed;
    float xPos;
    */

    // Config
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;

    // State
    bool isAlive = true;

    // Cached component references
    Rigidbody2D myRigidBody;
    Animator myAnimator;

    // Messages then messages
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /* This was my attempt which worked well
        xPos = Input.GetAxis("Horizontal") * speed;
        this.transform.Translate(xPos * Time.deltaTime, 0, 0);
        */

        Run();
        Jump();
        FlipSprite();
    }

    private void Run()
    {
        float controlThow = Input.GetAxis("Horizontal") * runSpeed; // value is between -1 and +1
        Vector2 playerVelocity = new Vector2(controlThow, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;

        /* my way to change the idle animation
        if (playerVelocity.x == 0f)
        {
            myAnimator.SetBool("Running", false);
        }
        else
        {
            myAnimator.SetBool("Running", true);
        }
        */
        // Better way!
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", playerHasHorizontalSpeed);
        
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            /* My way
            float xScale = Mathf.Sign(Input.GetAxis("Horizontal"));
            transform.localScale = new Vector3(xScale, 1f, 1f);
            */

            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity += jumpVelocityToAdd;
        }
    }
}
