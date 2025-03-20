using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    public int sceneBuildIndex;
    public int scoreRequired = 0;

    private bool player1 = false;
    private bool player2 = false;

    public Collider2D doorCollider = null;

    private void Start()
    {
        doorCollider = GetComponent<Collider2D>();
        doorCollider.enabled = false;
        GameManager.instance.AddScoreAddedListener(OnScoreAdded);
    }

    private void OnScoreAdded()
    {
        int score = GameManager.instance.GetScore();
        // door closed = score < scoreRequired
        // door open = score >= scoreRequired
        doorCollider.enabled = score >= scoreRequired;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player1")
        {
            player1 = true;
        }
        if (other.tag == "Player2")
        {
            player2 = true;
        }

        if (player1 && player2)
        {
            SceneManager.LoadScene(sceneBuildIndex);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player1")
        {
            Debug.Log("Player 1 exited");
            player1 = false;
        }
        if (other.tag == "Player2")
        {
            Debug.Log("Player 2 exited");
            player2 = false;
        }
    }
}