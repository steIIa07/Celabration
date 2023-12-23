using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Transform checkPoint;

    public void UpdateCheckPoint(Transform newCheckPoint) {
        checkPoint = newCheckPoint;
    }

    public void Respown() {
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        rb.simulated = true;
        player.transform.rotation = Quaternion.identity;
        player.position = checkPoint.position;
    }
}
