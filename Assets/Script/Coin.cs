using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private AudioSource audioSource;
    public ScoreData scoreData;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            audioSource.Play();
            scoreData.numberOfCoins++;
            StartCoroutine(Vanish());
        }
    }

    IEnumerator Vanish() {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
