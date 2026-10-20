using UnityEngine;

public class Movimento : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public float velocidade = 7f;

    public Transform checarChao;
    public LayerMask camadaChao;
    public float raioChao = 0.12f;

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
}