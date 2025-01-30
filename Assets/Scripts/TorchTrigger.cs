using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cargar y recargar escenas

public class TorchTrigger : MonoBehaviour
{
    // Este método detecta cuando el jugador entra en el trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que tocó el trigger tiene el tag de Player
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            Debug.Log("¡Jugador tocó la antorcha! Reiniciando el nivel...");

            // Reinicia la escena actual (puedes usar el nombre de la escena o el índice)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
