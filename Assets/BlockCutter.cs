/*using UnityEngine;

public class BlockCutter : MonoBehaviour
{
    public void CutBlock(GameObject fallingBlock, GameObject baseBlock)
    {
        float offset = fallingBlock.transform.position.x - baseBlock.transform.position.x;
        float newWidth = baseBlock.transform.localScale.x - Mathf.Abs(offset);

        if (newWidth <= 0)
        {
            Debug.Log("Perdiste");
            return;
        }

        // Crear el nuevo bloque alineado
        fallingBlock.transform.localScale = new Vector3(newWidth, fallingBlock.transform.localScale.y, 1);
        fallingBlock.transform.position = new Vector2(baseBlock.transform.position.x, fallingBlock.transform.position.y);

        // Crear la parte sobrante que cae
        float cutPosition = fallingBlock.transform.position.x + (fallingBlock.transform.localScale.x / 2 * Mathf.Sign(offset));
        GameObject cutPiece = Instantiate(fallingBlock, new Vector2(cutPosition, fallingBlock.transform.position.y), Quaternion.identity);
        cutPiece.transform.localScale = new Vector3(Mathf.Abs(offset), fallingBlock.transform.localScale.y, 1);
        cutPiece.GetComponent<Rigidbody2D>().gravityScale = 1;
        Destroy(cutPiece, 1.5f);
    }
}
*/