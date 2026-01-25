using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    public void Restart() => gameManager.RestartGame();
    public void Menu() => SceneManager.LoadScene("Menu");
}
