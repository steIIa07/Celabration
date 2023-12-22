using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public Vector2 minCameraPos;
    public Vector2 maxCameraPos;
    [SerializeField] private float smoothTime = 0.3f;
    private void FixedUpdate() 
    {
        if (player != null)
        {
            Vector3 targetPos = new Vector3(player.position.x, player.position.y, -10f);

            targetPos.x = Mathf.Clamp(targetPos.x, minCameraPos.x, maxCameraPos.x);
            targetPos.y = Mathf.Clamp(targetPos.y, minCameraPos.y, maxCameraPos.y);

            transform.position = Vector3.Lerp(transform.position, targetPos, smoothTime);
        }
    }
}
