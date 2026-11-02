public static class GameConstants
{
    // TAGS
    public const string PlayerTag = "Player";
    public const string EnemyTag = "Enemy";
    public const string PlayerBullet = "PlayerBullet";
    public const int maxEnemiesOnScreen = 15; // TODO: not a good idea to have this here?
    public const string HeartFilled = "filled";
    public const string HeartEmpty = "empty";
    public const string TitleMenu = "TitleMenu";
    public const string SampleLevel = "SampleLevel";
    public const string GameOver = "GameOver";
    public const string HowToPlay = "HowToPlay";
    public const string ThankYouForPlaying = "ThankYouForPlaying";

    // LINKS
    public const string SocialMediaIGUrl = "https://www.instagram.com/otako_fefe_/";
    public const string SocialMediaXUrl = "https://x.com/HanakoAozora";

    // ANIMATION VARIABLES

    // PLAYER

    public const string playerPraying = "praying";
    public const string playerIsMoving = "isMoving";
    public const string playerInputX = "inputX";
    public const string playerInputY = "inputY";
    public const string playerLastInputX = "lastInputX";
    public const string playerLastInputY = "lastInputY";

    // ENEMIES

    public const string enemyEmitterOpen = "open";

    // BOSS

    public const string bossIsAttacking = "isAttacking";

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
