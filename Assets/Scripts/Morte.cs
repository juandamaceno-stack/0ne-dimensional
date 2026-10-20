using UnityEngine;
using UnityEngine.SceneManagement;

public class Morte : MonoBehaviour
{

   void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && gameObject.CompareTag("Ativado"))
        {
          Morreu();
        }
    }
    
   public void Morreu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
