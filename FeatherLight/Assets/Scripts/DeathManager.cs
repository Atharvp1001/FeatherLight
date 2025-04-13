using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public SpriteRenderer SR;           // Reference to the SpriteRenderer for hiding the player
    public Canvas deathCanvas;          // Reference to the Canvas (Game Over screen)
    private BarFill barFill;            // Reference to BarFill script for currentValue
    private CameraShake cameraShake;
    private ScoreManager scoreManager;
    private bool isDead = false;

    void Start()
    {
        // Try to find the BarFill component in the scene
        barFill = FindObjectOfType<BarFill>();
        scoreManager = FindObjectOfType<ScoreManager>();
        cameraShake = FindAnyObjectByType<CameraShake>();

        if (barFill == null)
        {
            Debug.LogError("BarFill component not found in the scene.");
        }

        // Ensure deathCanvas is inactive initially
        if (deathCanvas != null)
        {
            deathCanvas.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        // Check if the player's health bar has reached 0
        if (barFill != null && barFill.currentValue == 0 && !isDead)
        {
            isDead = true;
            HandleDeath();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player collides with an obstacle
        if (collision.CompareTag("Obstacle") && !isDead)
        {
            isDead = true;
            HandleDeath();
        }
    }

    private void HandleDeath()
    {
        cameraShake.Shake(0.2f, 0.3f);

        // Hide the player's sprite when they die
        if (SR != null)
        {
            SR.gameObject.SetActive(false);
            scoreManager.canIncreaseScore = false;
        }

        // Activate the death Canvas (Game Over screen)
        if (deathCanvas != null)
        {
            deathCanvas.gameObject.SetActive(true);
        }
    }
}
