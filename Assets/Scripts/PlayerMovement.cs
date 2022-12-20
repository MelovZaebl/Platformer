using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private SpriteRenderer _chapterSprite;

    private float input;
    private Rigidbody2D rb;
    public LayerMask groundLayer;

    private bool canmove = true;
    [SerializeField] private int HP;
    [SerializeField] private int Damage;

    private BoxCollider2D coll;

    // NAS RANO GIT TEST

    private Animator animator;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (canmove)
        {
            Move();
        }
        if (HP > 0)
        {
            canmove = true;
        }
        
    }
    void Update()
    {
        Jump();
        FlyCheck();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            canmove = false;
            HP -= Damage;

            rb.AddForce(Vector2.left * 100, ForceMode2D.Impulse);
            if (HP <= 0)
            {
                Destroy(gameObject);
            }
            Debug.Log(HP);
        }
    }




    private void Move()
    {
        input = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(input*_speed, rb.velocity.y);
        if (input != 0)
        {
            if(input > 0)
            {
                _chapterSprite.flipX = false;
            }
            else _chapterSprite.flipX = true;
            animator.SetBool("IsRun", true);
        }
        else
        {
           animator.SetBool("IsRun", false); 
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, _jumpForce);
        }
    }

    private bool IsGrounded()
    {   
        // прыгать от стен
        //return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, groundLayer);

        //без прыжков от стен
        return Physics2D.Raycast(coll.bounds.center, Vector2.down, 1f, groundLayer);
    }

    private void FlyCheck()
    {
        if (rb.velocity.y > 0 && !IsGrounded())
        {
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsFalling", false);
        }
        else if (rb.velocity.y < 0 && !IsGrounded())
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", true);
        }
        else if (IsGrounded())
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", false);
        }
    }


}
