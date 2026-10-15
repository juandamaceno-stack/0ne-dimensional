using UnityEngine;
using UnityEngine.SceneManagement;

public class Morte : MonoBehaviour
{
    private bool jogadorMorreu = false;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (jogadorMorreu)
            return;

       
        if (collider.CompareTag("Player") &&
            gameObject.CompareTag("Ativado"))
        {
            jogadorMorreu = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
