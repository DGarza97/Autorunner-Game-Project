using UnityEngine;

public class ForegroundScript : MonoBehaviour
{
    public ForegroundGenerator generator; // assigned by generator

    private void Update()
    {
        if (generator == null) return;

        transform.Translate(Vector2.left * generator.currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("foregroundNL"))
        {
            generator?.GenerateForeground();
        }

        if (collision.CompareTag("foregroundFL"))
        {
            Destroy(gameObject);
        }
    }
}
