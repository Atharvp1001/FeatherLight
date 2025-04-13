using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    public float speed = 2f; // Speed of the background movement
    public GameObject background1; // First image
    public GameObject background2; // Second image

    private float backgroundWidth; // Width of the image
    private Vector3 startPosition;

    void Start()
    {
        // Calculate the width of the background image (assuming both have the same size)
        SpriteRenderer spriteRenderer = background1.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            backgroundWidth = spriteRenderer.bounds.size.x;
        }
        else
        {
            Debug.LogError("SpriteRenderer not found! Make sure these objects have SpriteRenderer components.");
        }
    }

    void Update()
    {
        // Move both backgrounds to the left
        background1.transform.position += Vector3.left * speed * Time.deltaTime;
        background2.transform.position += Vector3.left * speed * Time.deltaTime;

        // Check if background1 is off-screen and reposition it
        if (background1.transform.position.x <= -backgroundWidth)
        {
            background1.transform.position = new Vector3(background2.transform.position.x + backgroundWidth, 3, 0);
        }

        // Check if background2 is off-screen and reposition it
        if (background2.transform.position.x <= -backgroundWidth)
        {
            background2.transform.position = new Vector3(background1.transform.position.x + backgroundWidth, 3, 0);
        }
    }
}
