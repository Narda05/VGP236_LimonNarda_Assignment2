using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private UnityEvent onScoreAdded = new UnityEvent();

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
        onScoreAdded.Invoke();
    }

    public int GetScore()
    {
        return score;
    }

    public void AddScoreAddedListener(UnityAction action)
    {
        onScoreAdded.AddListener(action);
    }
    public void RemoveScoreAddedListener(UnityAction action)
    {
        onScoreAdded.RemoveListener(action);
    }
}