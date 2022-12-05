using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public static float speed = 0.1f;

    public int power = 1;
    void Update()
    {
        GetComponent<SpriteRenderer>().sprite = GameController.instance.lasers[power - 1];
        transform.Translate(Vector2.right * speed);
        if (transform.position.x > 20)
        {
            Destroy(gameObject);
        }
    }
}
