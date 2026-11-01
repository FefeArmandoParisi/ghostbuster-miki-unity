public static class GameConstants
{
    public const string PlayerTag = "Player";
    public const string EnemyTag = "Enemy";
    public const int maxEnemiesOnScreen = 12; // TODO: not a good idea to have this here?
    public const string HeartFilled = "filled";
    public const string HeartEmpty = "empty";
    public const string TitleMenu = "TitleMenu";
    public const string SampleLevel = "SampleLevel";
    public const string GameOver = "GameOver";
    public const string HowToPlay = "HowToPlay";
    public const string ThankYouForPlaying = "ThankYouForPlaying";
    public const string SocialMediaIGUrl = "https://www.instagram.com/otako_fefe_/";
    public const string SocialMediaXUrl = "https://x.com/HanakoAozora";
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
