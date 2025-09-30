using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float movement_speed;
    public float jumpspeed;
    bool onGround;
    GameObject MM;

    AudioSource jumpSFX, coinSFX, gameoverSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        coinSFX.Play();
        Destroy(collision.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gameoverSFX.Play();
            SceneManager.LoadScene(2);
        }
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
       movement_speed = 10;
       jumpspeed = 500;
       rb = gameObject.GetComponent<Rigidbody2D>();
       MM = GameObject.FindGameObjectWithTag("MM");

        jumpSFX = MM.GetComponents<AudioSource>()[1];
        coinSFX = MM.GetComponents<AudioSource>()[2];
        gameoverSFX = MM.GetComponents<AudioSource>()[3];
    }

    // Update is called once per frame
    void Update()
    {
        PlayerKeyboardInput();
    }

    void PlayerKeyboardInput()
    {
        //Player movement on Key Press
        if (Input.GetKeyDown(KeyCode.UpArrow) && onGround)
        {
            //gameObject.GetComponent<Transform>().Translate(Vector2.up);
            rb.AddForce(Vector2.up * jumpspeed);
            onGround = false;
            jumpSFX.Play();
        }

        if (Input.GetKey(KeyCode.RightArrow) && onGround)
        {
            rb.AddForce(Vector2.right * movement_speed);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && onGround)
        {
            rb.AddForce(Vector2.left * movement_speed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(Vector2.down * movement_speed);
        }
    }

}
