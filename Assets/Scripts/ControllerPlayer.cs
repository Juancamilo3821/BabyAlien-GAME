using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    [SerializeField] private float velocidadNave = 5f; 
    private Rigidbody2D rig;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.gravityScale = 0; 
        rig.freezeRotation = true; 
    }

    private void FixedUpdate()
    {
        MovimientoNave();
    }

    private void MovimientoNave()
    {
        float movX = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");

        Debug.Log("Input Horizontal: " + movX);
        Debug.Log("Input Vertical: " + movY);

        Vector2 movimiento = new Vector2(movX, movY) * velocidadNave * Time.fixedDeltaTime;
        rig.MovePosition(rig.position + movimiento);
    }
}
