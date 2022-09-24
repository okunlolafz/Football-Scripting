using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject playerGoal;
    private SpawnManagerX spawnManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.Find("Player Goal");
        spawnManagerScript = GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * spawnManagerScript.enemySpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If enemy collides with either goal, destroy it
        if (collision.gameObject.CompareTag("Enemy Goal"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player Goal"))
        {
            Destroy(gameObject);
        }

    }

}
