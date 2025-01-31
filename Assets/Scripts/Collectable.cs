using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))  // player 1 
        {
            Destroy(gameObject);  // destroy the collectable
            GameManager.instance.AddScore(1);
        }
    }
}