using TMPro;
using UnityEngine;

public class TimeKeeping : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject timeDisplay;
    public int secondsPerHour;

    private float lastCheckedTimeStamp;

    public System.DateTime currentTime;
    private TextMeshProUGUI textDisplay;

    public int outputTime;

    void Start()
    {
        //Starting DateTime of 2020/06/06 00:00
        currentTime = new System.DateTime(2020, 6, 6, 0, 0, 0);
        outputTime = 0;
        lastCheckedTimeStamp = Time.time;

        textDisplay = timeDisplay.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastCheckedTimeStamp > secondsPerHour)
        {
            currentTime = currentTime.AddHours(1);
            lastCheckedTimeStamp = Time.time;
            textDisplay.text = currentTime.ToShortTimeString();
            outputTime = currentTime.Hour;

            Debug.Log(outputTime);
        }
        
    }
}
