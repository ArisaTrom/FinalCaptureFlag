/*
 * Arisa Takenaka Trombley & Sam Lash
 * 2375446 2366917
 * trombley@chapman.edu slash@chapman.edu
 * CPSC-245-01
 * Final
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;

    private int count;
    // add clamping so we don't escape the map

    private GameController _gameController;

    // Start is called before the first frame update
    void Start()
    {
        _gameController = GetComponentInParent<GameController>();
        count = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        transform.position += movement * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
        if (other.gameObject.CompareTag("Flag"))
        {
            // Make the other game object (the flag) turn black, to make it captured
            print("Triggered");
            other.transform.GetComponent<SpriteRenderer>().color = Color.black;

            // Add one to the score variable 'count'
            count = count + 1;

            // Run the GameController function for picking up a collectible
            _gameController.OnFlagCollectible(count);
        }

    }
}
