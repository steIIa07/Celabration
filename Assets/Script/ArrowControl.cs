using UnityEngine;

public class ArrowControl : MonoBehaviour
{
    [SerializeField] private float divideValue = 3f;
    private RectTransform rectTransform;
    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        gameObject.SetActive(false);
    }
    public void StartDragging(Transform playerTransform) {
        gameObject.SetActive(true);
        rectTransform.position = Camera.main.WorldToScreenPoint(playerTransform.position);
    }

    public void EndDragging() {
        gameObject.SetActive(false);
    }

    public void UpdateArrow(Vector2 force) {
        float angle = Mathf.Atan2(force.normalized.y, force.normalized.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.localScale = new Vector2(force.magnitude / divideValue, 1f);
    }
}
