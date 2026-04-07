using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float laneDistance = 2f;   // afstand tussen lanes (forward)
    public float sideDistance = 2f;   // links/rechts movement
    public float moveSpeed = 10f;

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
    }

    void MovePlayer()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
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