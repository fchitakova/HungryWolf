using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreSystem : MonoBehaviour
{
    private const int INITIAL_SCORE = 0;
    private const int ONE_SCORE_POINT = 1;

    public static int currentScore;
    private TextMeshProUGUI scoreTextMeshPro;

    public void Start()
    {
        scoreTextMeshPro = GetComponent<TextMeshProUGUI>();
        SetScore(INITIAL_SCORE);
    }

    private void SetScore(int score)
    {
        currentScore = score;
        scoreTextMeshPro.text= currentScore.ToString();
    }

    public void OnEnable()
    {
        Sheep.OnSheepAttacked += UpdateScore;
    }

    private void UpdateScore()
    {
        int newScore = currentScore + ONE_SCORE_POINT;
        SetScore(newScore);  
    }

    private void OnDisable()
    {
        Sheep.OnSheepAttacked -= UpdateScore;
    }
}
