using UnityEngine;
using System.Collections;

public class MudarEspinho : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public Sprite spriteDesativado;
    public Sprite spriteAtivado;
    public bool estaAtivado;

    public string Desativado = "Desativado"; 
    public string Ativado = "Ativado";

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        StartCoroutine(AlternarEspinho());
    }


   IEnumerator AlternarEspinho()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            estaAtivado = !estaAtivado;

            if (estaAtivado)
            {
                gameObject.tag = Ativado;
                spriteRenderer.sprite = spriteAtivado;

                if (animator != null)
                    animator.SetBool("Ativo", true);
            }
            else
            {
                gameObject.tag = Desativado;
                spriteRenderer.sprite = spriteDesativado;

                if (animator != null)
                    animator.SetBool("Ativo", false);
            }
        }
    }
    
}
