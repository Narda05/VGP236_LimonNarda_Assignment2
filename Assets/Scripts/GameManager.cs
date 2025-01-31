using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake() 
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [SerializeField]
    private TMP_Text scoreText = null;

    private int score = 0;

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "-  " + score.ToString();
    }

    public int GetScore()
    {
        return score;
    }
}