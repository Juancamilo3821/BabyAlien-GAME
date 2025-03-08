using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform BabyAlien; // Referencia a la nave
    [SerializeField] private float smoothSpeed = 5f; // Ajusta la suavidad

    private float minY; // Límite inferior para evitar que la cámara baje

    private void Start()
    {
        if (BabyAlien != null)
        {
            minY = BabyAlien.position.y; // Guardar la altura inicial de la nave
        }
    }

    private void LateUpdate()
    {
        if (BabyAlien != null)
        {
            // La cámara sigue a BabyAlien pero nunca baja de su altura inicial
            float newY = Mathf.Max(minY, BabyAlien.position.y);
            Vector3 newPosition = new Vector3(transform.position.x, newY, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
