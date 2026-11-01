using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelState : MonoBehaviour
{
    // This script runs when the level loads and keeps track of score 
    // and other stuff like stopping the input when the game is interrupted
    // by a screen like Retry or Game Over.
    // It also keeps count of how many enemies are defeated and triggers a
    // boss fight for the level when the quota is met.
    public static LevelState Instance { get; private set; }
    [SerializeField] private AudioClip victoryTune;
    [SerializeField] private int enemiesToDefeat;
    public int EnemiesToDefeat => enemiesToDefeat;

    // {get; private set;} means that it the value can be looked but cannot be modified outside the script. 
    // A function is set and exposed to change this value internally.
    public int EnemiesDefeated { get; private set; }
    public bool IsInputLocked { get; private set; }
    public bool EnemySpawn { get; private set; }
    public bool BossFight { get; private set; }
    public bool BossDefeated { get; private set; }
    public bool levelComplete = false;
    float secondsToChangeScene = 8f;
    AudioSource music;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        ResetLevelState();
        music = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!BossFight && EnemiesDefeated >= enemiesToDefeat)
        {
            SetEnemySpawn(false);
            SetBossFight(true);
        }
        else if (BossFight && BossDefeated && !levelComplete)
        {
            levelComplete = true;
            StartCoroutine(FinishLevel());
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    public void RegisterEnemyDefeated()
    {
        EnemiesDefeated++;
    }

    public void ResetEnemiesDefeated()
    {
        EnemiesDefeated = 0;
    }

    public void SetInputLocked(bool value)
    {
        IsInputLocked = value;
    }

    public void SetEnemySpawn(bool value)
    {
        EnemySpawn = value;
    }

    public void SetBossFight(bool value)
    {
        BossFight = value;
    }

    public void SetBossDefeated(bool value)
    {
        BossDefeated = value;
    }

    public void ResetLevelState()
    {
        SetInputLocked(false);
        SetEnemySpawn(true);
        SetBossFight(false);
        ResetEnemiesDefeated();
    }

    private IEnumerator FinishLevel()
    {
        if (victoryTune != null && music != null)
        {
            music.Stop();
            AudioSource.PlayClipAtPoint(victoryTune, transform.position);
        }
        yield return new WaitForSeconds(secondsToChangeScene);

        SceneManager.LoadScene(GameConstants.ThankYouForPlaying);
    }
}