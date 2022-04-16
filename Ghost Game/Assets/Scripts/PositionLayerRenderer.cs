using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionLayerRenderer : MonoBehaviour
{
    [SerializeField]
    private int sortingOrderBase = 5000;
    private Renderer myRenderer;
    public int offset;

    private void Awake()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        myRenderer.sortingOrder = (int)(sortingOrderBase - transform.position.y - offset);
    }
}
