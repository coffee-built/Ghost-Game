using UnityEngine;

public class SpritePulser : MonoBehaviour
{
    public float beats_per_minute = 120;
    public float percentage_change = 2;
    public float pulses_per_beat = 1.0f;

    private float z;

    private float initialHeight;
    private float initialWidth;

    private float minHeight;
    private float minWidth;

    private float maxHeight;
    private float maxWidth;

    private float currentHeight;
    private float currentWidth;

    private float heightChangePerSecond;
    private float widthChangePerSecond;

    private float lastTimestamp;

    // Start is called before the first frame update
    void Start()
    {
        var initialScale = transform.localScale;

        initialHeight = initialScale[0];
        initialWidth = initialScale[1];
        z = initialScale[2];

        minHeight = initialHeight * ((100.0f - percentage_change) / 100.0f);
        minWidth = initialWidth * ((100.0f - percentage_change) / 100.0f);

        maxHeight = initialHeight * ((100.0f + percentage_change) / 100.0f);
        maxWidth = initialWidth * ((100.0f + percentage_change) / 100.0f);

        currentHeight = initialHeight;
        currentWidth = initialWidth;

        var beats_per_second = beats_per_minute / (60.0f);
        lastTimestamp = Time.realtimeSinceStartup;
    }

    void Update()
    {
        var sinValue = Mathf.Sin((2 * Mathf.PI * beats_per_minute / 60.0f) * Time.realtimeSinceStartup);
        currentHeight = (initialHeight * percentage_change / 100) * sinValue + initialHeight;
        currentWidth = ((maxWidth - minWidth) / 2) * sinValue + initialWidth;
        
        transform.localScale = new Vector3(currentHeight, currentWidth, z);
    }
}
