using UnityEngine;
using System.Collections;

public class MudarEspinho : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public Sprite spriteDesativado;
    public Sprite spriteAtivado;
    public bool primeiraVez=true;
    public int estaAtivado;
    public GameObject bom;
    public GameObject mal;

    public string Desativado = "Desativado"; 
    public string Ativado = "Ativado";

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
        {
            if(gameObject.tag=="Ativado"&&primeiraVez){
                estaAtivado=-2;
                primeiraVez=false;
            }
            if(gameObject.tag=="Desativado"&&primeiraVez){
                estaAtivado=1;
                primeiraVez=false;
            }
            if(Input.GetKeyDown(KeyCode.Q))
            {
                estaAtivado = -estaAtivado;
            }
            if (estaAtivado==-2 || estaAtivado==-1)
            {
                gameObject.tag = Ativado;
                mal.SetActive(true);
                bom.SetActive(false);

                spriteRenderer.sprite = spriteAtivado;

                if (animator != null)

                animator.SetBool("Ativo", true);
            }
            else if(estaAtivado==2 || estaAtivado==1)
            {
                gameObject.tag = Desativado;
                mal.SetActive(false);
                bom.SetActive(true);
                spriteRenderer.sprite = spriteDesativado;

                if (animator != null)

                animator.SetBool("Ativo", false);
            }
        }
        
    }
    

