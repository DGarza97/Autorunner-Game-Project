using UnityEngine;

public class ForegroundGenerator : MonoBehaviour
{
    public GameObject foregroundPrefab;
    public float tileWidth = 10f; // width of one foreground tile

    public float minSpeed = 2f;
    public float maxSpeed = 10f;
    public float speedMultiplier = 0.1f;

    [HideInInspector]
    public float currentSpeed;

    void Awake()
    {
        currentSpeed = minSpeed;
    }

    void Update()
    {
        if (currentSpeed < maxSpeed)
            currentSpeed += speedMultiplier * Time.deltaTime;
    }

    public void GenerateForeground(Vector3 offset = default)
    {
        if (offset == default) offset = Vector3.zero;

        GameObject tile = Instantiate(foregroundPrefab, transform.position + offset, transform.rotation);

        // Assign this generator to the tile
        tile.GetComponent<ForegroundScript>().generator = this;
    }
}
