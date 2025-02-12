using UnityEngine;

public class TowerBlock : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isFalling = false; // Controla si está cayendo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // No cae hasta ser soltado
        rb.isKinematic = true; // Evita que se mueva hasta que lo suelten
    }

    public void ActivateGravity()
    {
        rb.gravityScale = 1; // Activar gravedad
        rb.isKinematic = false; // Permitir colisiones
        isFalling = true; // Está cayendo
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isFalling && (collision.gameObject.CompareTag("Block") || collision.gameObject.CompareTag("Ground")))
        {
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;
            rb.bodyType = RigidbodyType2D.Static; // Lo deja fijo

            isFalling = false; // Ya no está cayendo
        }
    }
}
