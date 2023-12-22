using MoreMountains.Feedbacks;
using UnityEngine;
public class Present : MonoBehaviour
{
    private bool isDragging = false;
    private bool isGrounded = true;
    private Vector2 dragStartPosition;
    private Vector2 force;
    private Vector2 dragDelta;
    private Rigidbody2D rb;
    private AudioSource audioSource;
    public MMF_Player mMF_Player;
    
    [SerializeField] private float maxForce = 15f;
    [SerializeField] private float forceMultiplier = 1f;
    [SerializeField] private ArrowControl arrowControl;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (!isGrounded) {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            StartDragging();
            arrowControl.StartDragging(transform);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EndDragging();
            force = Vector2.zero;
            arrowControl.EndDragging();
        }

        if (isDragging)
        {
            UpdateDragging();
            if(!isGrounded) arrowControl.EndDragging(); 
        }
    }

    void StartDragging()
    {
        force = Vector2.zero;
        isDragging = true;
        dragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void UpdateDragging()
    {
        Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragDelta = currentMousePosition - dragStartPosition;
        force = Vector2.ClampMagnitude(dragDelta * forceMultiplier * -1f, maxForce);
        arrowControl.UpdateArrow(force);
    }

    void EndDragging()
    {
        audioSource.Play();
        isDragging = false;
        if(isGrounded) rb.AddForce(force, ForceMode2D.Impulse);
        mMF_Player.PlayFeedbacks();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
