using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController gameControllerInstance;

    public Transform spawnPoint;
    public BoxCollider2D spawnBounds;
    public float timerLimit;
    public TextMeshProUGUI scoreText;
    public GameObject tutorialPanel;
    public GameObject gameOverPanel;
    public GameObject player;
    private int score;

    private enum EnemyEnum { Bug, Error, Warning }
    private enum PickupEnum { Beer, Coffee }
    private float timer = 0;
    private bool slowToEnd;

    private void Start() {
        if(gameControllerInstance == null) {
            gameControllerInstance = this;
        }

        slowToEnd = false;
        score = 0;
        scoreText.text = score.ToString();
        gameOverPanel.SetActive(false);
        tutorialPanel.SetActive(true);
        player.SetActive(false);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        Time.timeScale = 1;
        tutorialPanel.SetActive(false);
        player.SetActive(true);
        StartCoroutine(RunGame());
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    private void SpawnEnemy(EnemyEnum enemy)
    {
        GameObject enemyObject = Instantiate(Resources.Load(enemy.ToString()),spawnPoint, true) as GameObject;
        enemyObject.transform.position = new Vector3(Random.Range(-spawnBounds.size.x / 2, spawnBounds.size.x / 2), spawnPoint.position.y);
    }

    public void DecreaseTimerLimit()
    {
        AddScore();

        if (timerLimit > 1.1f)
            timerLimit -= Mathf.Log10(timerLimit) / 3;
        else 
            timerLimit -= Mathf.Log10(2.0f * timerLimit) / 3;
    }

    public void Reset() {
        foreach (Transform t in spawnPoint.transform) {
            GameObject g = t.gameObject;
            g.GetComponent<Enemy>().Die(false);
        }

        timerLimit = 3.0f;
    }

    public void GameOver()
    {
        StartCoroutine(ShowDeathGui());
        Debug.Log("Game Over");
    }

    public void AddScore()
    {
        scoreText.text = (++score).ToString();
    }

    private IEnumerator ShowDeathGui()
    {
        do
        {
            float newTimeScale = Time.timeScale - Time.unscaledDeltaTime;

            Time.timeScale = newTimeScale > 0 ? newTimeScale : 0;
            yield return null;
        } while (Time.timeScale > 0);

        gameOverPanel.SetActive(true);
    }

    private IEnumerator RunGame()
    {
        while (true)
        {
            timer += Time.deltaTime;

            if (timer > timerLimit)
            {
                timer = 0;
                SpawnEnemy(EnemyEnum.Bug);
            }
            yield return null;
        } 
    }
}