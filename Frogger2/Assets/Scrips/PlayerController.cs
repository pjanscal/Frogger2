using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float laneDistance = 2f;   // afstand tussen lanes (forward)
    public float sideDistance = 2f;   // links/rechts movement
    public float moveSpeed = 10f;
    public float minX = -10f;
    public float maxX = 10f;
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        HandleInput();
        MovePlayer();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            targetPosition += Vector3.forward * laneDistance;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            targetPosition += Vector3.left * sideDistance;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            targetPosition += Vector3.right * sideDistance;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            targetPosition += Vector3.back * sideDistance;
        }
    }

    void MovePlayer()
    {
        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        if (targetPosition.x <= minX || targetPosition.x >= maxX)
    {
    // kleine push terug
    targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);

    // feedback
    Debug.Log("Edge!");
    }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            Time.timeScale = 0f;
        }
    }
} 