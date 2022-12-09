using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public int spot;
    public int mass;
    public Slime sibling;
    public GameObject firstLaser;
    public bool dead = false;

    int Size()
    {
        return Mathf.RoundToInt(Mathf.Log(mass, 2)) + 1;
    }

    void Split()
    {
        if (Size() <= 1)
        {
            return;
        }

        if (!(Vector3.Distance(transform.position, GameController.instance.spots[spot].transform.position) < 0.01f))
        {
            return;
        }
        Destroy(gameObject);
        int m1 = mass / 2;
        int m2 = mass - m1;
        GameObject s1 = Instantiate(GameController.instance.slime, transform.position, Quaternion.identity);
        GameObject s2 = Instantiate(GameController.instance.slime, transform.position, Quaternion.identity);
        var component1 = s1.GetComponent<Slime>();
        var component2 = s2.GetComponent<Slime>();
        component1.mass = m1;
        component1.spot = Math.Clamp(spot - 1, 0, GameController.instance.spots.Count - 1);
        component1.sibling = component2;
        component2.mass = m2;
        component2.spot = Math.Clamp(spot + 1, 0, GameController.instance.spots.Count - 1);
        component2.sibling = component1;
    }

    void MoveUp()
    {
        spot = Math.Clamp(spot - 1, 0, GameController.instance.spots.Count - 1);
        sibling = null;
    }

    void MoveDown()
    {
        spot = Math.Clamp(spot + 1, 0, GameController.instance.spots.Count - 1);
        sibling = null;
    }

    void MergeInto(Slime other)
    {
        other.mass += mass;
        Destroy(gameObject);
        dead = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var slime = other.gameObject.GetComponent<Slime>();
        if (slime == null || slime == sibling)
        {
            return;
        }

        if (slime.spot != spot)
        {
            return;
        }

        if (slime.dead)
        {
            return;
        }

        if (dead)
        {
            return;
        }

        if (slime.mass > mass)
        {
            MergeInto(slime);
        } else if (slime.mass == mass)
        {
            if (other.gameObject.transform.position.y >= transform.position.y)
            {
                MergeInto(slime);
            }
        }
    }

    void Shoot()
    {
        if (firstLaser != null)
        {
            firstLaser.GetComponent<FirstLaser>().power = Size();
            return;
        }
        firstLaser = Instantiate(GameController.instance.firstLaser, transform.position + (0.5f * Vector3.right), Quaternion.identity);
        firstLaser.transform.SetParent(transform);
        firstLaser.GetComponent<FirstLaser>().power = Size();
    }

    void UnShoot()
    {
        if (firstLaser != null)
        {
            Destroy(firstLaser);
        }
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, GameController.instance.spots[spot].transform.position, 0.2f);
    }

    void Update()
    {
        mass = Math.Clamp(mass, 1, 8);
        Sprite sprite = GameController.instance.slimes[Size() - 1];
        GetComponent<SpriteRenderer>().sprite = sprite;

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveDown();
        } else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveUp();
        }

        if (Input.GetKey(KeyCode.X))
        {
            Shoot();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Split();
            }
            UnShoot();
        }
    }
}
