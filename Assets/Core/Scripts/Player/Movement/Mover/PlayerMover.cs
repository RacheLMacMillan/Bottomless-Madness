using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _MaxSpeed;

    public void Move(Vector2 direction)
    {
        float scaleMoveSpeed = _MaxSpeed * Time.deltaTime;
        
        Vector2 newDirection = new Vector2(direction.x * scaleMoveSpeed, 0);
        
        transform.position += new Vector3(newDirection.x, 0, 0);
    }
}