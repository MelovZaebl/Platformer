using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private SpriteRenderer _chapterSprite;
    [SerializeField] private int HP;
    [SerializeField] private int Damage;
     public static float knock=6f;
     public static bool knockright;
     public static float totaltime=0.2f;
     public static float counter;


    public static float input;
    public static Rigidbody2D rb;
    public LayerMask groundLayer;

    private bool canmove = true;
   
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
        if (LivesScript.canmove)
        {
            Move();
        }
        if (LivesScript.current > 0)
        {
            LivesScript.canmove = true;
        }
        else
        {
            
        }
    }
    void Update()
    {
        Jump();
        FlyCheck();
        if (LivesScript.current <= 0)
        {
            animator.SetBool("die", true);
        }
    }
    

    public void Die()
    {
        animator.SetBool("die", false);
        Debug.Log("You die");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    private void Move()
    {
        input = Input.GetAxis("Horizontal");
        if (counter <= 0)
        {
            rb.velocity = new Vector2(input * _speed, rb.velocity.y);
        }
        else
        {
            if (knockright)
            {
                rb.velocity = new Vector2(-knock, knock);
            }
            else
            {
                rb.velocity = new Vector2(knock, knock);
            }
            counter -= Time.deltaTime;
        }
        
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
