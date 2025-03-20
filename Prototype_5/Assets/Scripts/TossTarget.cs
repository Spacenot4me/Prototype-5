using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class TossTarget : MonoBehaviour
{
    private Rigidbody targetRb;

    private float outOfBoundForce = 3;
    private int randomSpawnPositionRange = 4;
    private float spawnYConstant = -2f;
    private GameManager gameManager;
    public int score;
    public ParticleSystem particle;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        AddForceForTarget();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 5)
        {
            targetRb.AddForce(Vector3.left * outOfBoundForce, ForceMode.Impulse);
        }
        if (transform.position.x < -5)
        {
            targetRb.AddForce(Vector3.right * outOfBoundForce, ForceMode.Impulse);
        }
    }

    private void AddForceForTarget()
    {
        float randomStrenght = Random.Range(12, 20);
        float randomTorque = Random.Range(0, 5);
        float randomX = Random.Range(-randomSpawnPositionRange, randomSpawnPositionRange);
        Vector3 randomPos = new Vector3(randomX, spawnYConstant);
        Vector3 torque = new Vector3(randomTorque, randomTorque, randomTorque);
        targetRb.AddForce(Vector3.up * randomStrenght, ForceMode.Impulse);
        targetRb.AddTorque(torque, ForceMode.Impulse);
        transform.position = new Vector3(randomX, spawnYConstant);
    }


    private void OnMouseDown()
    {
        Destroy(gameObject);
        gameManager.UpdateScoreText(score);
        Instantiate(particle, transform.position, particle.GetComponent<ParticleSystem>().transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("Bad"))
        {
                gameManager.GameOver();
        }
        Destroy(gameObject);
    }


    
}
