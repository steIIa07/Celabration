using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public ScoreData scoreData;
    [SerializeField] private int timeLimit = 180;
    [SerializeField] private int timeScore = 100;
    [SerializeField] private int coinScore = 2000;
    

    private void Start() {
        scoreData.time = 0;
        scoreData.numberOfCoins = 0;
        scoreData.score = 0;
    }

    private void Update() {
        scoreData.score = scoreData.numberOfCoins * coinScore + (timeLimit - scoreData.time) * timeScore;
    }
}
