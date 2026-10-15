using UnityEngine;

public class MudarEspinho : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public Sprite spriteDesativado;
    public Sprite spriteAtivado;

    public string Desativado = "Desativado"; 
    public string Ativado = "Ativado";

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (gameObject.CompareTag(Desativado))
            {
              gameObject.tag = Ativado;
              spriteRenderer.sprite = spriteAtivado;
              animator.SetBool("Ativo", false);
            }
        
        else if (gameObject.CompareTag(Ativado))
            {
              gameObject.tag = Desativado;
              spriteRenderer.sprite = spriteDesativado;
              animator.SetBool("Ativo", true);
            }
        }   
    }
}
