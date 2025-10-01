using UnityEngine;
using TMPro;

/// <summary>
/// Singleton para la gestión de puntuaciones globales y UI.
/// </summary>
public class GlobalScore : MonoBehaviour
{
    public static GlobalScore Instance { get; private set; }

    public int currentScore = 0;
    public int totalHighscore = 0;

    [SerializeField] public TextMeshProUGUI currentScoreText;
    [SerializeField] public TextMeshProUGUI highscoreText;

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

        totalHighscore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void Start()
    {
        UpdateUI();
    }

    /// <summary>
    /// Añade puntos y actualiza el récord si es necesario.
    /// </summary>
    public void AddScore(int amount)
    {
        currentScore += amount;

        if (currentScore > totalHighscore)
        {
            totalHighscore = currentScore;
            PlayerPrefs.SetInt("HighScore", totalHighscore);
            PlayerPrefs.Save();
        }

        UpdateUI();
    }

    /// <summary>
    /// Reinicia la puntuación actual.
    /// </summary>
    public void ResetScore()
    {
        currentScore = 0;
        UpdateUI();
    }

    /// <summary>
    /// Actualiza la UI de puntuaciones.
    /// </summary>
    private void UpdateUI()
    {
        if (currentScoreText != null)
            currentScoreText.text = $"{currentScore}";
        if (highscoreText != null)
            highscoreText.text = $"{totalHighscore}";
    }
}
