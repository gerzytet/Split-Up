using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int strength;
    void FixedUpdate()
    {
        transform.position = transform.position - new Vector3(EnemySpawner.instance.speed, 0, 0 - 0);
    }
}
