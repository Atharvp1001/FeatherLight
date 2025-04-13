using UnityEngine;
using UnityEngine.UI;

public class BarFill : MonoBehaviour
{
    private Consumables consumables;
    public Image fillImage;
    public float maxValue = 100f;
    public float minValue = 0f;
    public float currentValue = 100f;
    public float decreaseRate = 20f;
    public float increaseRate = 20f;

    private bool isPressingSpace = false;

    private void Start()
    {
        consumables = FindObjectOfType<Consumables>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Register that spacebar was pressed
            isPressingSpace = true;
            // Decrease value only when tapped
            currentValue -= decreaseRate;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            // Reset the flag when the key is released
            isPressingSpace = false;
        }

        if (!Input.GetKey(KeyCode.Space) && consumables.featherCollected)
        {
            // Regenerate value when not pressing space
            currentValue += increaseRate;
            currentValue = Mathf.Clamp(currentValue, minValue, maxValue);
            fillImage.fillAmount = currentValue / maxValue;

            consumables.featherCollected = false;
        }

        // Clamp the value to ensure it doesn't go below 0
        currentValue = Mathf.Clamp(currentValue, minValue, maxValue);

        // Update the fill amount of the bar
        fillImage.fillAmount = currentValue / maxValue;
    }
}
