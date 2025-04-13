using UnityEngine;

public class FeatherScript : MonoBehaviour
{
    public bool featherCollected = false;
    public float moveSpeed = 5f;  // Speed at which the object moves

    void Update()
    {
        // Move the object to the left every frame
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            featherCollected = true;
            Destroy(gameObject);
        }
    }
}
