using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    private Animator anim;
    private float velocity;
    public EnemyDamage EnemyDamage;

    public Transform detectionPoint;
    private float groundCheckRadius = 2.0f;
    public GameObject SceneManager;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;



    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetFloat("velocity", 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(anim.GetBool("jump") + " " + IsGrounded());
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
        CheckJumpNFall();

        //get damage status for animator
        anim.SetBool("damage", EnemyDamage.dmg_trigger);
    }

    private void CheckJumpNFall()
    {
        if (Input.GetButton("Jump") && IsGrounded())
        {
            anim.SetBool("falling", false);
            anim.SetBool("jump", true);
        }

        else if (Input.GetButtonUp("Jump") && !IsGrounded())
        {
            anim.SetBool("jump", false);
            anim.SetBool("falling", true);
        }

        else if (!IsGrounded())
        {
            anim.SetBool("falling", true);
        }

        else if (IsGrounded() == true)
        {
            anim.SetBool("jump", false);
            anim.SetBool("falling", false);

        }
    }


    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            StartCoroutine(delay());
            Destroy(other.gameObject);

        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(.5f);
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        SceneManager.gameObject.GetComponent<SceneManagerScript>().ActivateMicInstructions();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(detectionPoint.position, groundCheckRadius);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (rb.velocity == Vector2.zero || rb.velocity == new Vector2(0, rb.velocity.y))
        {
            anim.SetFloat("velocity", 0);
        }
        else
        {
            anim.SetFloat("velocity", 1);
        }
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}
