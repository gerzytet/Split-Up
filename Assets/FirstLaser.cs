using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class FirstLaser : MonoBehaviour
{
    public int power = 1;
    void Update()
    {
        GetComponent<SpriteRenderer>().sprite = GameController.instance.lasers[power - 1];
        GameObject laser = Instantiate(GameController.instance.laser, transform.position, transform.rotation);
        laser.GetComponent<Laser>().power = power;
    }
}
