using UnityEngine;

public class MovCamera : MonoBehaviour
{
    public Transform jogador;
    public float limiteAltura = 99f;
    public float distanciaZ = -10f;
    public float velocidadeDescida = 2f;

    private Movimento movimento;

    void Start()
    {
        movimento = jogador.GetComponent<Movimento>();
    }

    void LateUpdate()
    {
        float altura = Mathf.Max(jogador.position.y,limiteAltura);

        if (movimento.descerCamera)
        {

            float alturaDesejada = altura - 5f;

            float novaAltura = Mathf.MoveTowards(transform.position.y,alturaDesejada,velocidadeDescida * Time.deltaTime);

            transform.position = new Vector3(jogador.position.x,novaAltura,distanciaZ);
        }
        else
        {
            transform.position = new Vector3(jogador.position.x,altura,distanciaZ);
        }
    }
}