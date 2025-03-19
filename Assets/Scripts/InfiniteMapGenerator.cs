using System.Collections.Generic;
using UnityEngine;

public class InfiniteMapGenerator : MonoBehaviour
{
    public GameObject tilePrefab;  // Prefab del tile (fondo)
    public Transform player;  // Referencia al jugador
    public int maxTilesOnScreen = 5; // Máximo de tiles visibles

    private List<GameObject> activeTiles = new List<GameObject>(); // Lista de tiles activos
    private float tileHeight;  // Altura de cada tile
    private float lastTileY;  // Última posición Y donde se generó un tile

    void Start()
    {
        // Obtener la altura real del tile automáticamente
        tileHeight = tilePrefab.GetComponent<SpriteRenderer>().bounds.size.y;

        // Crear los primeros tiles iniciales
        for (int i = 0; i < maxTilesOnScreen; i++)
        {
            SpawnTile();
        }
    }

    void Update()
    {
        // Si el jugador sube, generar un nuevo tile
        if (player.position.y > lastTileY - (maxTilesOnScreen * tileHeight) / 2)
        {
            SpawnTile();
        }

        // Eliminar tiles antiguos si hay demasiados
        if (activeTiles.Count > maxTilesOnScreen)
        {
            DestroyOldestTile();
        }
    }

    void SpawnTile()
    {
        // Posicionar el nuevo tile encima del último tile creado
        Vector3 spawnPosition = new Vector3(0, lastTileY + tileHeight, 0);
        GameObject newTile = Instantiate(tilePrefab, spawnPosition, Quaternion.identity);

        // Agregar el nuevo tile a la lista
        activeTiles.Add(newTile);
        lastTileY += tileHeight;
    }

    void DestroyOldestTile()
    {
        if (activeTiles.Count > 0)
        {
            GameObject oldestTile = activeTiles[0];
            activeTiles.RemoveAt(0);
            Destroy(oldestTile);
        }
    }
}
