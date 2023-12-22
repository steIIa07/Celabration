using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/ScoreData")]
public class ScoreData : ScriptableObject
{
    public int numberOfDeaths;
    public int numberOfCoins;
    public int time;
    public int score;
}
