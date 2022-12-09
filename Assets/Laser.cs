using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public static float speed = 0.2f;

    public int power = 1;
    void FixedUpdate()
    {
        GetComponent<SpriteRenderer>().sprite = GameController.instance.lasers[power - 1];
        transform.Translate(Vector2.right * speed);
        if (transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {

        var enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy == null)
        {
            return;
        }

        if (power == enemy.strength)
        {
            Destroy(enemy.gameObject);
            Scoreboard.score++;
        }
    }
}
