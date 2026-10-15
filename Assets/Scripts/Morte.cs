using UnityEngine;
using UnityEngine.SceneManagement;

public class Morte : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collider)
{
    if (collider.CompareTag("Ativado"))
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
}
