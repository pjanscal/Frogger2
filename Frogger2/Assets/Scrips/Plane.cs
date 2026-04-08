using UnityEngine;

public class Plane : MonoBehaviour
{
    public float speed;
    private float startX;
    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        Vector3 direction = new Vector3(speed, 0, 0); // X richting

        // 🔥 vliegtuig kijkt waar hij heen gaat
        transform.forward = direction.normalized;

        // 🔥 beweegt vooruit (local forward)
        transform.Translate(Vector3.forward * Mathf.Abs(speed) * Time.deltaTime);
       if (Mathf.Abs(transform.position.x - startX) > 60f)
        {
        Destroy(gameObject);
        }
    }
}