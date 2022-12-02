using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    
    // add clamping so we don't escape the map
    
    private GameController _gameController;
    // Start is called before the first frame update
    void Start()
    {
        _gameController = GetComponentInParent<GameController>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        transform.position += movement * speed;
    }
}
