using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab; // Prefab del bloque
    public Transform spawnPoint; // Empty donde aparecerá el bloque
    private GameObject currentBlock;

    void Start()
    {
        SpawnNewBlock();
    }

    void SpawnNewBlock()
    {
        // Instanciar el bloque en el punto del Empty
        currentBlock = Instantiate(blockPrefab, spawnPoint.position, Quaternion.identity);
        currentBlock.transform.parent = transform; // Hacer que el bloque siga el balanceo
    }

    void Update()
    {
        // Si presionas Fire1 (Click Izq o Espacio), suelta el bloque
        if (Input.GetButtonDown("Fire1") && currentBlock != null)
        {
            DropBlock();
        }
    }

    void DropBlock()
    {
        currentBlock.transform.parent = null; // Soltar el bloque
        TowerBlock blockScript = currentBlock.GetComponent<TowerBlock>();
        if (blockScript != null)
        {
            blockScript.ActivateGravity();
        }

        currentBlock = null;
        Invoke("SpawnNewBlock", 0.5f); // Esperar 0.5s antes de generar otro
    }
}
