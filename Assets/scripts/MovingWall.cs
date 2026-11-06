
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public enum MovementAxis
    {
        Horizontal,
        Vertical
    }

    public enum StartDirection
    {
        Positive,
        Negative
    }

    [Header("Movement Settings")]
    [SerializeField] private MovementAxis movementAxis;
    [SerializeField] private StartDirection startDirection;

    [Header("Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float distance;

    private Vector2 startPosition;
    private Vector2 targetPosition;
    private Vector2 movementDirection;

    void Start()
    {
        startPosition = transform.position;

        if (movementAxis == MovementAxis.Horizontal)
        {
            movementDirection = startDirection == StartDirection.Positive
                ? Vector2.right
                : Vector2.left;
        }
        else
        {
            movementDirection = startDirection == StartDirection.Positive
                ? Vector2.up
                : Vector2.down;
        }

        targetPosition = startPosition + movementDirection * distance;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            targetPosition,
            speed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, targetPosition) < 0.01f)
        {
            movementDirection = -movementDirection;

            targetPosition = startPosition + movementDirection * distance;
        }
    }
}
