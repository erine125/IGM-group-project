using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float closedGravity = 1.5f;
    public float openGravity = 0.4f;
    public float moveSpeed = 4;
    public float jumpHeight = 0.5f;

    private Rigidbody2D _rigidbody;
    private float moveLimiter = 0.7f;

    bool canJump;
    bool isOpen = true;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.X)) {
            isOpen = !isOpen; //flip bool to toggle open
            print(isOpen);

            if (isOpen) {
                _rigidbody.gravityScale = openGravity;
            }
            else {
                _rigidbody.gravityScale = closedGravity;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump == true) {
            if (isOpen) {
                _rigidbody.gravityScale = 1;
            } // TODO: FIX GRAVITY SCALE DURING JUMP - variable height jump during open state, not during closed state!! 
            
            _rigidbody.velocity = Vector2.up * jumpHeight;
        }


        // left right movement control
        if (Input.GetKey(KeyCode.LeftArrow)) {
            _rigidbody.velocity = new Vector2(-moveSpeed, _rigidbody.velocity.y);
        }

        else if (Input.GetKey(KeyCode.RightArrow)) {
            _rigidbody.velocity = new Vector2(+moveSpeed, _rigidbody.velocity.y);
        }
        else {
            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
        }

        print(_rigidbody.gravityScale);

    }


    private void OnCollisionEnter2D(Collision2D collision) {
        //If we collide with an object tagged "ground" then our jump resets and we can now jump.
        if (collision.gameObject.tag == "ground") {
            canJump = true;

            print("canjump");
            //print statements print to the Console panel in Unity. 
            //This will print the value of onGround, which is a boolean, so either True or False.
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        //If we exit our collision with the "ground" object, then we are unable to jump.
        if (collision.gameObject.tag == "ground") {
            canJump = false;
        }
    }

}
