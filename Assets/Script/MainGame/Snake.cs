using UnityEngine;
using System.Collections.Generic;
public class Snake : MonoBehaviour
{
    public float moveRate = 0.2f;
    public Vector2 gridMoveStep = new Vector2(0.25f, 0.25f);
    private Vector2 moveDirection = Vector2.right;
    private float moveTimer;
    private List<Transform> _segments;
    [SerializeField] Transform segmentPrefab;
    private void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(this.transform);
    }
    void Update()
    {
        HandleInput();

        moveTimer += Time.deltaTime;
        if (moveTimer >= moveRate)
        {
            moveTimer = 0f;
            Move();
            for (int i = _segments.Count - 1; i > 0; i--)
            {
                _segments[i].position = _segments[i - 1].position;
            }
        }
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
            moveDirection = Vector2.up;
        else if (Input.GetKeyDown(KeyCode.S))
            moveDirection = Vector2.down;
        else if (Input.GetKeyDown(KeyCode.A))
            moveDirection = Vector2.left;
        else if (Input.GetKeyDown(KeyCode.D))
            moveDirection = Vector2.right;

    }

    void Move()
    {
        Vector3 moveVector = new Vector3(moveDirection.x * gridMoveStep.x, moveDirection.y * gridMoveStep.y, 0);
        transform.position += moveVector;
    }

    public void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position; 
        _segments.Add(segment);
    }
}
