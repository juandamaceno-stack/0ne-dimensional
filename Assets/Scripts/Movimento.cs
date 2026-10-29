using UnityEngine;

public class Movimento : MonoBehaviour
{
    public Morte morte;

    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public float velocidade = 7f;

    public Transform checarChao;
    public LayerMask camadaChao;
    public float raioChao = 0.12f;
    public bool descerCamera;
    private bool estaNoChao;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        estaNoChao = Physics2D.OverlapCircle(checarChao.position,raioChao,camadaChao);

        float movimento = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            movimento = -1f;
            spriteRenderer.flipX = false;
            animator.SetBool("Andar", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movimento = 1f;
            spriteRenderer.flipX = true;
            animator.SetBool("Andar", true);
        }
        else
        {
            animator.SetBool("Andar", false);
        }
        if (estaNoChao==false)
        {
            animator.SetBool("Pulando", true);
            animator.SetBool("Andar", false);
        }
        else
        {
            animator.SetBool("Pulando", false);
        }

        rb.linearVelocity = new Vector2(movimento * velocidade,rb.linearVelocity.y);
     
        if (Input.GetKeyDown(KeyCode.W) && estaNoChao)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x,velocidade);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (checarChao == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(checarChao.position, raioChao);
    }
       void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Limite") || collision.gameObject.CompareTag("Inimigo"))
        {
          morte.Morreu();
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("DescerCM"))
        {
            descerCamera=true;
        }        
        if (collider.gameObject.CompareTag("SubirCM"))
        {
            descerCamera=false;
        }
    }
}