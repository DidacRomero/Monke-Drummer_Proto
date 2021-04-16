using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float jump_force = 1.0f;
    Rigidbody2D rb;

    [SerializeField]
    private Vector2 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        rb.AddForce(movement);

        if (movement.y > 0)
        {
            movement.y -= jump_force * Time.deltaTime;
        }

    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 mov = context.ReadValue<Vector2>();

        if(context.performed)
        if(mov == Vector2.up || mov == Vector2.down)
        {
            Debug.Log("Vertical Movement");
            movement = jump_force*mov;
        }
    }
}
