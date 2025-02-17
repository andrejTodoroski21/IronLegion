using UnityEngine;

public class PlayerWallCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Walls"))
        {
            Debug.Log("Player hit a wall!");
        }
    }
}
