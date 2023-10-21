using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToViewportPoint(Vector3.zero).x - 13f;
    }

    private void Update()
    {
        transform.position += Vector3.left * (GameManager.Instance.GameSpeed * Time.deltaTime);

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
