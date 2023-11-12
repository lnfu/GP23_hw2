using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public HealthPoint healthPoint;

    public int hp = 100;

    public void DecreaseHP(int delta)
    {
        if (hp > 0)
        {
            hp -= delta;
        }

        if (hp <= 0 && gameObject.tag == "Player")
        {
            hp = 0;
            print("Lose");
        }

        if (hp <= 0 && gameObject.tag == "Enemy")
        {
            hp = 0;
            gameObject.SetActive(false);
        }

        if (hp >= 100 && gameObject.tag == "Player")
        {
            hp = 100;
        }
    }
    public void SetHP(int value)
    {
        hp = value;
    }



    // Update is called once per frame
    void Update()
    {
        healthPoint.Render(hp);
    }


    void OnTriggerEnter(Collider collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.tag == "Bullet")
        {
            DecreaseHP(5);
        }

        if (collision.gameObject.tag == "Healingbox")
        {
            DecreaseHP(-5);
            Destroy(collision.gameObject);
        }

        /*if (collision.gameObject.tag == "Enemybomb")
        {
            DecreaseHP(40);
        }*/
    }

   void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemybomb")
        {
            DecreaseHP(40);
        }
    }
}
