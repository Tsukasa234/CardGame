using UnityEngine;
using TMPro;

public class GlobalScore : MonoBehaviour
{
    public static GlobalScore Instance { get; private set; }

    public int currentScore = 0;
    public int totalHighscore = 0;

    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highscoreText;

    private void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Cargar HighScore de PlayerPrefs
        totalHighscore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void Start()
    {
        UpdateUI();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;

        // Si superamos el récord, lo actualizamos y guardamos
        if (currentScore > totalHighscore)
        {
            totalHighscore = currentScore;
            PlayerPrefs.SetInt("HighScore", totalHighscore);
            PlayerPrefs.Save();
        }

        UpdateUI();
    }

    public void ResetScore()
    {
        currentScore = 0;
        UpdateUI();
    }

    private void UpdateUI()
    {
        currentScoreText.text = $"{currentScore}";
        highscoreText.text = $"{totalHighscore}";
    }
}
