using TMPro;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed at which the object moves

    void Update()
    {
        // Move the object to the left every frame
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }
}
