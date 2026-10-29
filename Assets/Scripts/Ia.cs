using UnityEngine;

public class Ia : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    public float velocidade=3f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
      rb.linearVelocity = new Vector2(velocidade ,rb.linearVelocity.y);

      if(velocidade<0)
      {
            spriteRenderer.flipX = true;
      }
      else if(velocidade>0)
      {
            spriteRenderer.flipX = false;
      }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Inimigo"))
        {
          velocidade=-velocidade;
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("IaLimite"))
        {
            velocidade=-velocidade;
        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Ativado") && GetComponent<SpriteRenderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }
}
