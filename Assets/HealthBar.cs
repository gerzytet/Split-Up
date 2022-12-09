using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public int health = 10;
    public Vector3 originalSpot;
    public float originalScale;
    
    public static HealthBar instance;

    HealthBar()
    {
        instance = this;
    }

    // Update is called once per frame
    void Start()
    {
        originalSpot = transform.position;
        originalScale = transform.localScale.y;
    }
    
    void Update()
    {
        transform.position = new Vector3(originalSpot.x, Mathf.Lerp(originalSpot.y, originalSpot.y - 5, (1 - health / 10f)), 0f);
        transform.localScale = new Vector3(1, (health / 10f) * originalScale, 1);
    }
}
