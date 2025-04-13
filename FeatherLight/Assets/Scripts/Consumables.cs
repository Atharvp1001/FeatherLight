using UnityEngine;

public class Consumables : MonoBehaviour
{
    public bool featherCollected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Consumable"))
        {
            featherCollected = true;
            Destroy(collision);
        }
    }
}
