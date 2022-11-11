using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
<<<<<<< Updated upstream
=======
    private Animator anim;
    private float velocity;
    public EnemyDamage EnemyDamage;
    public GameObject SoulOne;
    public GameObject SoulTwo;
    public GameObject SoulThree;
    public GameObject SoulFour;
    public GameObject SoulFive;
    public GameObject SoulSix;
    public GameObject SoulSeven;
    public GameObject SoulEight;
    public GameObject SoulNine;
>>>>>>> Stashed changes


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


  // Update is called once per frame
    void Update()
    {
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
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Soul"))
        {
            SoulOne.SetActive(false);
            
        }

        if (other.gameObject.CompareTag("Soul2"))
        {
            SoulTwo.SetActive(false);

        }

        if (other.gameObject.CompareTag("Soul3"))
        {
            SoulThree.SetActive(false);

        }

        if (other.gameObject.CompareTag("Soul4"))
        {
            SoulFour.SetActive(false);

        }

        if (other.gameObject.CompareTag("Soul5"))
        {
            SoulFive.SetActive(false);

        }

        if (other.gameObject.CompareTag("Soul6"))
        {
            SoulSix.SetActive(false);

        }

        if (other.gameObject.CompareTag("Soul7"))
        {
            SoulSeven.SetActive(false);

        }

        if (other.gameObject.CompareTag("Soul8"))
        {
            SoulEight.SetActive(false);

        }

        if (other.gameObject.CompareTag("Soul9"))
        {
            SoulNine.SetActive(false);

        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
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
