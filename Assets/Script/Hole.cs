using System.Collections;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] private SpawnSystem spawnSystem;
    [SerializeField] private float respawnTime = 2f;
    public ScoreData scoreData;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            GetComponent<AudioSource>().Play();
            scoreData.numberOfDeaths++;
            StartCoroutine(RespawnPlayer());
        }
    }

    IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(respawnTime);
        spawnSystem.Respown();
    }
}
