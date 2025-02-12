using UnityEngine;

public class Palanca : MonoBehaviour
{
    public float speed = 2f; // Velocidad del balanceo
    public float range = 3f; // Cuánto se mueve de lado a lado

    private Vector3 startPosition;
    private int direction = 1;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Mover la palanca de lado a lado
        transform.position = startPosition + Vector3.right * Mathf.Sin(Time.time * speed) * range;
    }
}

