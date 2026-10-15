using UnityEngine;

public class Movimento : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public float velocidade=7f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

   
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rb.linearVelocity = new Vector2(-velocidade, rb.linearVelocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Andar", true);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            rb.linearVelocity = new Vector2(velocidade, rb.linearVelocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Andar", true);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            animator.SetBool("Andar", false);
        }

    }

}
