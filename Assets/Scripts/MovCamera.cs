using UnityEngine;

public class MovCamera : MonoBehaviour
{
    public Transform jogador;
    public float limiteAltura = 99f;
    public float distanciaZ = -10f;

    void LateUpdate()
    {
        float altura = Mathf.Max(jogador.position.y,limiteAltura);

        transform.position = new Vector3(jogador.position.x,altura,distanciaZ);
    }
}
