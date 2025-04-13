using UnityEngine;
using TMPro; // For UI components

public class ScoreManager : MonoBehaviour
{
    private BarFill barFill;
    public TextMeshProUGUI scoreText;   // Reference to the Text component to display the score
    private int score = 0;             // Initial score
    private float timer = 0f;          // Timer to track intervals
    public float interval = 1f;        // Interval in seconds to increase the score
    public bool canIncreaseScore = true; // Boolean to control score increment


    private void Start()
    {
        barFill = FindObjectOfType<BarFill>();    
    }

    void Update()
    {
        // Check if score increase is allowed
        if (canIncreaseScore)
        {
            // Increment the timer by deltaTime
            timer += Time.deltaTime;

            // Check if the timer exceeds the interval
            if (timer >= interval)
            {
                IncreaseScore(); // Increase score
                timer = 0f;      // Reset the timer
            }
        }

        // Check if score has reached the maximum limit
        if (barFill.currentValue == 0)
        {
            canIncreaseScore = false; // Stop increasing the score when it reaches the max score
            Debug.Log("Score limit reached! Increasing score stopped.");
        }
    }

    void IncreaseScore()
    {
        score += 1; // Increase score by 1
        scoreText.text = score.ToString(); // Update the score display
    }
}
