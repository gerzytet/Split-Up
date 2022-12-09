using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy == null)
        {
            return;
        }
        
        Destroy(enemy.gameObject);
        HealthBar.instance.health -= 1;
        if (HealthBar.instance.health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
