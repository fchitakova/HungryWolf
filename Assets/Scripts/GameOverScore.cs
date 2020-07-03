using UnityEngine;
using TMPro;
using static ScoreSystem;

[RequireComponent(typeof(TextMeshProUGUI))]
public class GameOverScore : MonoBehaviour
{
    void Start()
    {
        TextMeshProUGUI finalScore = GetComponent<TextMeshProUGUI>();
        finalScore.text = "Score: " + currentScore;
    }
}
