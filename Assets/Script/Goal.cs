using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private int nextSceneIndex = 0;
    private SceneManager sceneManager;
    public ScoreData scoreData;
    private void Start() {
        sceneManager = FindObjectOfType<SceneManager>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player") {
            GetComponent<AudioSource>().Play();
            GetComponent<BoxCollider2D>().enabled = false;
            scoreData.time = (int)Time.timeSinceLevelLoad;
            scoreData.score += 5000;
            sceneManager.LoadScene(nextSceneIndex);
            // sceneManager.FadeToScene(nextSceneIndex);
        }
    }
}