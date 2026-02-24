using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    public BackgroundGenerator generator;  // assigned by generator

    private void Update()
    {
        if (generator == null) return;

        transform.Translate(Vector2.left * generator.currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("backgroundNL"))
        {
            generator?.GenerateBackground();
        }

        if (collision.CompareTag("backgroundFL"))
        {
            Destroy(gameObject);
        }
    }
}

