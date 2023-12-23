using UnityEngine;

// Santa animation
public class Santa : MonoBehaviour
{
    private const float speed = 0.05f;
    private const float vanishTime = 3f;
    private float passedTime;
    void Update()
    {
        transform.Translate(new Vector3(-speed, 0, 0));
        passedTime += Time.deltaTime;

        if (passedTime > vanishTime)
        {
            Destroy(gameObject);
        }
    }
}

