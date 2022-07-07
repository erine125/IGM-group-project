using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float closedGravity = 0.9f;
    public float openGravity = 0.4f;
    public float moveSpeed = 4;
    public float jumpHeight = 2;

    private Rigidbody2D _rigidbody;

    public bool isOpen = true;

    float jumpForce;

    bool isGrounded;
    bool isJumping;
    bool jumpKeyHeld;
    Vector2 counterJumpForce = new Vector2(0, -1f);



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

            if (isOpen) {
                _rigidbody.gravityScale = openGravity;
                print("Open");
            }
            else {
                _rigidbody.gravityScale = closedGravity;
                print("Closed");
            }
        }


        // jump control
        if (Input.GetKeyDown(KeyCode.Space)) {
            jumpKeyHeld = true;
            if (isGrounded) {
                isJumping = true;
                jumpForce = CalculateJumpForce(Physics2D.gravity.magnitude, 0.6f);
                _rigidbody.AddForce(Vector2.up * jumpForce * _rigidbody.mass, ForceMode2D.Impulse);
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space)) {
            jumpKeyHeld = false;
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


    }

    private void FixedUpdate() {
        if (isJumping) {
            if (!jumpKeyHeld && Vector2.Dot(_rigidbody.velocity, Vector2.up) > 0) {
                _rigidbody.AddForce(counterJumpForce * _rigidbody.mass);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        //If we collide with an object tagged "ground" then our jump resets and we can now jump.
        if (collision.gameObject.tag == "ground") {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        //If we exit our collision with the "ground" object, then we are unable to jump.
        if (collision.gameObject.tag == "ground") {
            isGrounded = false;
        }
    }

    public static float CalculateJumpForce(float gravityStrength, float jumpHeight) {
        return Mathf.Sqrt(2 * gravityStrength * jumpHeight);
    }

}
