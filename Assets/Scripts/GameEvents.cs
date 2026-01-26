using System;

public static class GameEvents
{
    public static event Action<int> OnGoalScored;
    public static void GoalScored(int player) => OnGoalScored?.Invoke(player);

    public static event Action OnBallHit;
    public static void BallHit() => OnBallHit?.Invoke();

    public static event Action<int[]> OnScoreChanged;
    public static void ScoreChanged(int[] score) => OnScoreChanged?.Invoke(score);

    public static event Action<int> OnGameEnded;
    public static void GameEnded(int winner) => OnGameEnded?.Invoke(winner);
}
