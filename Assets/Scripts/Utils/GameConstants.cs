public static class GameConstants
{
    public const string TagPlayer = "Player";
    public const string EnemyTag = "Enemy";
    public const int maxEnemiesOnScreen = 30;

    public enum PlayerStatus
    {
        Default,
        Idle,
        Moving,
        Attacking,
        Hurt,
        Dead
    }
}
