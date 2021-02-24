using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text scoreLabel;
    [SerializeField] UnityEngine.UI.Text livesLabel;
    [SerializeField] UnityEngine.UI.Text endGame;
    public Rocket rocket;
    public Ufo ufo;

    int valueAsteroid = 100;
    int score = 0;
    int lives = 3;

    private void Start()
    {
        StartCoroutine(ufo.SpawnUfo());
        endGame.gameObject.SetActive(false);
        scoreLabel.text = "Score: " + score.ToString();
        livesLabel.text = "Lives: " + lives.ToString();
    }
    private void Update()
    {
        if (GameObject.FindWithTag("Asteroid") == null)
        {
            Time.timeScale = 0;
            endGame.text = "Поздравляем с победой";
            endGame.gameObject.SetActive(true);
        }
    }

    public void UpdateScore()
    {
        score += valueAsteroid;
        scoreLabel.text = "Score: " + score.ToString();
    }

    public void UpdateLives()
    {
        if (lives!=1)
        {
            lives--;
            livesLabel.text = "Lives: " + lives.ToString();
            rocket.ResetRocket();
        }
        else
        {
            Time.timeScale = 0;
            endGame.text = "Поражение";
            endGame.gameObject.SetActive(true);
        }
    }
}