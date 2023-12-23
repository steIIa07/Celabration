using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private AudioSource audioSource;
    public ScoreData scoreData;
    [SerializeField] private SpawnSystem spawnSystem;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) { // player collided with SpawnPoint
            if(CompareTag("Respawn")) {
                scoreData.score += 3000;
                GetComponent<SpriteRenderer>().color = Color.white;
                audioSource.Play();
                GetComponent<Collider2D>().enabled = false;
            }
            spawnSystem.UpdateCheckPoint(transform);
        }
    }
}
