using UnityEngine;

public class GameOverButtons : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    public void Restart()
    {
        gameManager.RestartGame();
    }
}
