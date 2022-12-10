using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private float health;
    private float maxHealth = 1000;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform currentHealthBar;
    [SerializeField] private Transform maxHealthBar;
    [SerializeField] private GameObject smoke;

    private void Awake()
    {
        health = maxHealth;
    }
    private void Update()
    {
        currentHealthBar.rotation = Quaternion.Euler(0, 0, 0);
        maxHealthBar.rotation = Quaternion.Euler(0, 0, 0);
        if (health <= 0)
        {
            // выброс вещей перед разрушением и создание партикла
            Instantiate(smoke, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= collision.gameObject.GetComponent<Bullet>().damage;
        }
        currentHealthBar.localScale = new Vector3(0.66f * (health / maxHealth) * maxHealthBar.localScale.x, currentHealthBar.localScale.y, currentHealthBar.localScale.z);
    }
}
