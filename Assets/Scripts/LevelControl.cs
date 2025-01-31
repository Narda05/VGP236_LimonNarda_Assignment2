using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    public int sceneBuildIndex;
    public int scoreRequired = 0;

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
            print("Switching Scene to " + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex);
        }
    }
}