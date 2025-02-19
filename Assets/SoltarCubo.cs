using UnityEngine;
using UnityEngine.InputSystem;

public class SoltarCubo : MonoBehaviour
{
    public GameObject blockPrefab; // Prefab del cubo
    public float moveSpeed = 3f;   // Velocidad del balanceo
    public float moveRange = 3f;   // Rango de movimiento lateral

    private InputAction action;
    private GameObject currentBlock;

    void Start()
    {
        SpawnNewBlock();

        action = InputSystem.actions.FindAction("pushite");
    }

    void Update()
    {
        action.performed += context =>
        {
            if (currentBlock != null)
            {
                float x = Mathf.PingPong(Time.time * moveSpeed, moveRange) - (moveRange / 2);
                currentBlock.transform.position = new Vector2(x, transform.position.y);
            }

            if (Input.GetButtonDown("Fire1") && currentBlock != null)
            {
                DropBlock();
            }
        };

    }




    void SpawnNewBlock()
    {
        currentBlock = Instantiate(blockPrefab, transform.position, Quaternion.identity);
    }

    void DropBlock()
    {
        currentBlock.GetComponent<TowerBlock>().ActivateGravity();
        currentBlock = null;
        Invoke("SpawnNewBlock", 0.5f);
    }
}
