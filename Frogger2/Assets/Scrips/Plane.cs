using UnityEngine;

public class Plane : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Destroy als hij uit beeld is
        if (Mathf.Abs(transform.position.x) > 50f)
        {
            Destroy(gameObject);
        }
    }
}