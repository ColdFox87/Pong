using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{
    public void Restart() => SceneManager.LoadScene("Game");
    public void Menu() => SceneManager.LoadScene("Menu");
}