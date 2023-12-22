using TMPro;
using UnityEngine;
public class ScoreCalculator : MonoBehaviour
{
    public BestScore bestScoreData;
    public ScoreData level1_ScoreData, level2_ScoreData, level3_ScoreData;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    private void Start() {
        int score = level1_ScoreData.score + level2_ScoreData.score + level3_ScoreData.score;
        bestScoreText.text = "Score: " + score.ToString();
        if(score > bestScoreData.bestScore) {
            bestScoreData.bestScore = score;
        }
    }
   
}
