using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float timer;
    public static float cointimer;
    public float camSpeed;
    public GameObject Spikes;
    public GameObject Coin;
    public GameObject platform;
    public GameObject Ground;   // Reference to the ground prefab
    public Transform Player;          // Reference to the player's transform
    public float groundLength = 17f;  // Length of a single ground tile
    private float nextSpawnPoint = 19f;
    // Start is called before the first frame update
    void Start()
    {
        timer = 2;
        cointimer = 1; 
        // Spawn initial ground pieces
        for (int i = 0; i < 3; i++)  // Spawn a few pieces at the start
        {
            SpawnGround();
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnspikes();
        //spawncoins();
        // Check if the player has passed the next spawn point
        if (Player.position.x > nextSpawnPoint - groundLength)
        {
            SpawnGround();
        }
    }

    void spawnspikes()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            Instantiate(Spikes, new Vector3(Random.Range(gameObject.transform.position.x + 15, gameObject.transform.position.x +33), -2 , 0), Quaternion.identity);
            timer = Random.Range(2, 6);
        }

        gameObject.GetComponent<Transform>().Translate(Vector2.right * camSpeed);
    }
    void SpawnGround()
    {
        // Instantiate a new ground object in front of the scene
        Instantiate(Ground, new Vector3(nextSpawnPoint, -4, 0), Quaternion.identity);

        // Move the spawn point forward
        nextSpawnPoint += groundLength;
    }

    //void spawncoins()
    //{
    //    timer -= Time.deltaTime;

    //    if (timer < 0)
    //    {
    //        Instantiate(Coin, new Vector3(Random.Range(gameObject.transform.position.x + 5, gameObject.transform.position.x + 23), Random.Range(-3.2f, -2f), 0), Quaternion.identity);
    //        timer = Random.Range(2, 6);
    //    }

    //    gameObject.GetComponent<Transform>().Translate(Vector2.right * camSpeed);
    //}
}