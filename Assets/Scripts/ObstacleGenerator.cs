using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstacle;

    public float MinSpeed;
    public float MaxSpeed;
    public float currentSpeed;

    public float SpeedMultiplier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        currentSpeed = MinSpeed;
        generateObstacle();
    }


    public void GenerateNextObstacleWithGap()
    {
        float randomWait = Random.Range(0.1f, 1.2f);
        Invoke("generateObstacle", randomWait);
    }
    
    public void generateObstacle()
    {
        GameObject ObstacleIns = Instantiate(obstacle, transform.position, transform.rotation);

        ObstacleIns.GetComponent<ObstacleScript>().obstacleGenerator = this;
    }

    void Update()
    {
        if(currentSpeed < MaxSpeed)
        {
            currentSpeed += SpeedMultiplier;
        }
    }
}
