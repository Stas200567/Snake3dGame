using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private Snake snake;
    private int score = 0;

    [System.Obsolete]
    private void Start()
    {
        snake = FindObjectOfType<Snake>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            snake.Grow();
            TeleportToRandomPosition();
            score++;
            scoreText.text = score.ToString();
        }
    }

    private void TeleportToRandomPosition()
    {
        float randomX = Mathf.Round(Random.Range(-2f, 2f) / 0.25f) * 0.25f;
        float randomY = Mathf.Round(Random.Range(-4.5f, -0.5f) / 0.25f) * 0.25f;
        transform.position = new Vector2(randomX, randomY);
    }
}
