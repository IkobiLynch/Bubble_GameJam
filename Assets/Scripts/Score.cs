using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI for displaying the score
    private int totalScore = 0; // Tracks the total score

    void Update()
    {
        // Calculate score based on time and additional scores added
        int timeScore = Mathf.FloorToInt(Time.timeSinceLevelLoad); // Score based on time
        int currentScore = totalScore + timeScore;

        // Update the score text
        scoreText.text = currentScore.ToString();
    }

    public void AddScore(int score)
    {
        // Add the specified score to the total score
        totalScore += score;
    }
}

