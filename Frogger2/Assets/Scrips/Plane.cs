using UnityEngine;

public class Plane : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // Destroy als hij uit beeld is
        if (Mathf.Abs(transform.position.x) > 50f)
        {
            Destroy(gameObject);
        }
    }
}