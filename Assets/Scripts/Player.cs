using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /* My Stuff
    public float speed;
    float xPos;
    */
    [SerializeField] float runSpeed = 5f;
    Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /* This was my attempt which worked well
        xPos = Input.GetAxis("Horizontal") * speed;
        this.transform.Translate(xPos * Time.deltaTime, 0, 0);
        */
    }

    private void Run()
    {
        float controlThow = Input.GetAxis("Horizontal") * runSpeed; // value is between -1 and +1
        Vector2 playerVelocity = new Vector2(controlThow, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;
    }
}
