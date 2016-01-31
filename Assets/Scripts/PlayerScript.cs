using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public int speed = 7;
    private float move;
    private bool facingRight = true;
    private bool grounded = false;
    private bool doubleJump = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 400;
    public GameObject shurikenPrefab;

    private Animator animator;
    private Rigidbody2D physic;

    void Start(){

        animator = GetComponent<Animator>();
        physic = GetComponent<Rigidbody2D>();
    }

    void Update(){

        if((grounded || !doubleJump) && Input.GetKeyDown(KeyCode.Space)){

            animator.SetBool("Ground", false);
            physic.AddForce(new Vector2(0, jumpForce));

            if (!doubleJump && !grounded){

                doubleJump = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.E)){

            Instantiate(shurikenPrefab, transform.position, Quaternion.identity);
        }
    }	

	void FixedUpdate() {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        animator.SetBool("Ground", grounded);

        if (grounded){

            doubleJump = false;
        }
        move = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(move));
        physic.velocity = new Vector2(move * speed, physic.velocity.y);

        if(move > 0 && !facingRight){

            Flip();
        }
        else if (move < 0 && facingRight){

            Flip();
        }
    }

    void Flip(){

        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
