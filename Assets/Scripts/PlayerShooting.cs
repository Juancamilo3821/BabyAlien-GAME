using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;  // Prefab de la bala
    public Transform firePoint;  // Punto de salida de la bala
    public float bulletSpeed = 10f;  // Velocidad del disparo
    public float fireRate = 0.2f;  // Tiempo entre cada disparo

    private float nextFireTime = 0f;

    void Update()
    {
        // Disparar cuando el jugador presiona o mantiene presionada la tecla ESPACIO
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate; // Configurar tiempo del siguiente disparo
        }
    }

    void Shoot()
    {
        // Instanciar la bala en la posición de "FirePoint"
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Agregar velocidad al Rigidbody2D de la bala
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.up * bulletSpeed;  // Dispara hacia arriba
        }
    }
}


