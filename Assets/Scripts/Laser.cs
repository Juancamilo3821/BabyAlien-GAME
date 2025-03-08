using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Laser : MonoBehaviour
{
    [SerializeField] float velocidad = 50f;

    // Método de Unity que se ejecuta al iniciar
    private void Start()
    {
        transform.position = transform.parent.position;
    }

    // Método de Unity que se ejecuta en cada frame
    private void Update()
    {
        transform.Translate(Vector2.up * velocidad * Time.deltaTime);
    }

    // Método de Unity que se ejecuta cuando colisiona con otro objeto
    private void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.gameObject.CompareTag("Borde"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
