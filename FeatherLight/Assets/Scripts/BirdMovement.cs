using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public float flapForce = 25f;         // Force applied when the spacebar is pressed for a flap
    public float floatForce = 1f;         // Small force applied to simulate slow upward floating when holding spacebar
    public Rigidbody2D rb;                // Reference to the bird's Rigidbody2D component
    public Animator animator;             // Reference to the bird's Animator component

    private bool isFlapping = false;      // Boolean to check if the bird is flapping

    void Start()
    {
        // Ensure the Rigidbody2D and Animator components are attached
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        // If the spacebar is pressed, make the bird flap
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Flap();
        }

        // If the spacebar is held, apply a small upward force to simulate floating (slow fall)
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Float(); 
        }

        // If no key is pressed, the bird will fall naturally
        if (Input.GetKeyUp(KeyCode.Space))
        {
            // Transition to float animation when space is released
            animator.SetBool("isFlapping", false); // Set isFlapping to false
            isFlapping = false;
        }
    }

    void Flap()
    {
        // Instantly set upward velocity for a strong flap
        rb.linearVelocity = Vector2.up * flapForce;
        // Trigger the flap animation
        animator.SetBool("isFlapping", true);
        isFlapping = true;
    }

    void Float()
    {
        // Apply a small upward force to simulate floating while holding spacebar
        // This force will make the bird rise slowly instead of falling at the default rate
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Max(rb.linearVelocity.y, 0));  // Prevent upward movement if falling
        rb.AddForce(Vector2.up * floatForce, ForceMode2D.Force);
    }
}
