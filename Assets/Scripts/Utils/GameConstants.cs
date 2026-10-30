public static class GameConstants
{
    public const string PlayerTag = "Player";
    public const string EnemyTag = "Enemy";
    public const int maxEnemiesOnScreen = 30; // TODO: not a good idea to have this here?
    public const string HeartFilled = "filled";
    public const string HeartEmpty = "empty";
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
