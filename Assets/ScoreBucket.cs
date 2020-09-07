using TMPro;
using UnityEngine;

public class ScoreBucket : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText, multiplierText;

    private static int score;
    private int multiplier;
    private bool isReset;

    private void Start()
    {
        isReset = false;
        multiplier = 0;
    }

    private void Update()
    {
        if (isReset)
        {
            PlayerPrefs.SetInt("Score", score);
            isReset = false; 
        }
        scoreText.text = score.ToString();
        multiplierText.text = "X" + multiplier.ToString();
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd * multiplier;
    }

    public void AddMulitplier(int multiplierToAdd)
    {
        multiplier += multiplierToAdd;
    }

    public void ResetMulitplier()
    {
        multiplier = 1;
        isReset = true;
    }

}
