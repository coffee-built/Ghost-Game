using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FearBar : MonoBehaviour
{
    public int maximum;
    public int current;
    public int minThresholdToAppear;
    public int maxEndingXValue;
    public Image mask;
    public GameObject fearBarBeginning;
    public GameObject fearBarEnding;

    private Vector3 endBarInitialPosition;

    // Start is called before the first frame update
    void Start()
    {
        endBarInitialPosition = fearBarEnding.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (current > minThresholdToAppear) GetCurrentFill(current);
        else
        {
            GetCurrentFill(0);
        }
    }

    void GetCurrentFill(int fillValue)
    {
        float fillAmount = (float)fillValue / (float)maximum;

        if (fillAmount * 100 > minThresholdToAppear)
        {
            mask.fillAmount = fillAmount;

            float movementAmount = Mathf.Min(1, fillAmount);
            fearBarEnding.transform.localPosition = endBarInitialPosition + new Vector3((float)maxEndingXValue * (float)movementAmount, 0, 0);
        }
        else
        {
            mask.fillAmount = 0;
            fearBarEnding.transform.localPosition = endBarInitialPosition;
        }
    }
}
