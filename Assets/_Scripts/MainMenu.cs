using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnStartButton()
    {
        // Cambia "GameScene" por el nombre real de tu escena de juego
        SceneManager.LoadScene("GameScene");
    }
}
