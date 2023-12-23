using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    public BestScore bestScoreData;
    public ScoreData level1_ScoreData, level2_ScoreData, level3_ScoreData;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TextMeshProUGUI playScoreText;

    private void Start() {
        int score = level1_ScoreData.score + level2_ScoreData.score + level3_ScoreData.score;

        // playScoreText.text = "Score: " + score.ToString();
        StartCoroutine(DisyplayScore(score, 5f));

        if(score >= bestScoreData.bestScore) {
            bestScoreData.bestScore = score;
            bestScoreText.text = "Congratulation!\n You have a new best score!";
        } else {
            bestScoreText.text = "Best Score: " + bestScoreData.bestScore.ToString();
        }
    }

    private IEnumerator DisyplayScore(int targetScore, float duration)
    {
        int currentScore = 0;

        while (currentScore <= targetScore)
        {
            playScoreText.text = "Score: " + currentScore.ToString();
            float step = targetScore * Time.deltaTime / duration;
            currentScore += Mathf.CeilToInt(step);
            yield return null;
        }

        playScoreText.text = "Score: " + targetScore.ToString();
    }
}
