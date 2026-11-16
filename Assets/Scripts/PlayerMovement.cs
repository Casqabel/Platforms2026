using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;





public class PlayerMovement : MonoBehaviour
{
    [Header("Velocity")]
    [SerializeField] float speed;
    [SerializeField] float smoothTime;
    Vector2 targetVelocity;
    Vector2 dampVelocity;

    [Header("Jump")]
    [SerializeField] float jumpForce;
    [SerializeField] float fallDamage;
    bool jumpPressed;

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sp;
    float h;
    [Header("Raycast")]
    [SerializeField] Transform rayPosition;
    [SerializeField] float rayLen;
    [SerializeField] LayerMask groundLayer;
    bool isGrounded;

    Vector2 lastCheckPoint;


    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
        sp= GetComponent<SpriteRenderer>();
        lastCheckPoint=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        InputPlayer();
        MovePlayer();
        Animate();
    }

    void InputPlayer() {
        h = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space)) { 
            jumpPressed = true;
        }
    }

    void MovePlayer() {
        targetVelocity = new Vector2(h * speed, rb.velocity.y);
    }

    void FixedMovePlayer() {
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref dampVelocity, smoothTime);
    
    }

    private void FixedUpdate()
    {
        Ray();
        FixedMovePlayer();
        Jump();
        ChangeGravity();
    }

    private void Ray() {

        isGrounded = Physics2D.Raycast(rayPosition.position, Vector2.down, rayLen, groundLayer);
    }

    private void Jump() {
        if (jumpPressed && isGrounded) {
            rb.AddForce(Vector2.up * jumpForce);
            jumpPressed = false;
         }
    }

    private void Animate() {
        if (h < 0)
        {
            sp.flipX = true;
        }
        else if(h>0){
            sp.flipX = false;
        }
        if (h != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        anim.SetBool("isGrounded", isGrounded);
    
    }

    private void ChangeGravity() {
        if (!isGrounded && rb.velocity.y < 0)
        {
            rb.gravityScale = 1.5f;
        }
        else {
            rb.gravityScale = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
            if(collision.CompareTag("Respawn")){
                lastCheckPoint=collision.transform.position;

            }
            if(collision.CompareTag("Death")){
                    Restart();


            }

    }

    public void Restart(){
        gameObject.GetComponent<PlayerHealth>().TakeDamage(fallDamage);
        transform.position=lastCheckPoint;
        rb.velocity=Vector2.zero;
    }
}
