using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBackground : MonoBehaviour
{
    [SerializeField] private GameObject backgroundPrefab; // Prefab del fondo
    private List<GameObject> activeBackgrounds = new List<GameObject>(); // Lista de fondos activos
    private float backgroundHeight; // Altura del fondo

    [SerializeField] private Transform BabyAlien; // Referencia a BabyAlien
    private int maxBackgrounds = 5; // Máximo de fondos activos antes de eliminar
    private float spawnPositionY; // Posición Y del último fondo generado

    private void Start()
    {
        if (backgroundPrefab != null)
        {
            // Obtener la altura del fondo basado en el SpriteRenderer
            backgroundHeight = backgroundPrefab.GetComponent<SpriteRenderer>().bounds.size.y;

            // Iniciar la posición de spawn
            spawnPositionY = transform.position.y;

            // Generar los primeros fondos
            for (int i = 0; i < maxBackgrounds; i++)
            {
                SpawnBackground(spawnPositionY);
                spawnPositionY += backgroundHeight;
            }
        }
        else
        {
            Debug.LogError("❌ ERROR: No hay un prefab asignado en GestorFondos.");
        }
    }

    private void Update()
    {
        if (BabyAlien != null && activeBackgrounds.Count > 0)
        {
            float topBackgroundY = activeBackgrounds[activeBackgrounds.Count - 1].transform.position.y;

            // Si BabyAlien se acerca al último fondo generado, generar otro
            if (BabyAlien.position.y >= topBackgroundY - (backgroundHeight / 2))
            {
                SpawnBackground(topBackgroundY + backgroundHeight);
            }

            // Si hay más de `maxBackgrounds`, eliminar el más antiguo
            if (activeBackgrounds.Count > maxBackgrounds)
            {
                DestroyOldestBackground();
            }
        }
    }

    private void SpawnBackground(float yPos)
    {
        GameObject newBackground = Instantiate(backgroundPrefab, new Vector3(0, yPos, 0), Quaternion.identity);
        activeBackgrounds.Add(newBackground);
        Debug.Log("🟢 Nuevo fondo generado en: " + yPos);
    }

    private void DestroyOldestBackground()
    {
        GameObject oldestBackground = activeBackgrounds[0];
        activeBackgrounds.RemoveAt(0);
        Destroy(oldestBackground);
        Debug.Log("❌ Fondo eliminado.");
    }
}
