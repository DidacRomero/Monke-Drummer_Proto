using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float jump_force = 1.0f;
    public float lateral_speed = 1000.0f;
    BoxCollider2D col;
    [SerializeField] private LayerMask ground;
    Rigidbody2D rb;

    [SerializeField]
    private Vector2 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
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
        movement.x = lateral_speed * Time.deltaTime;

        rb.velocity = movement;
        //rb.AddForce(movement);
        if (!IsGrounded())
            movement.y -= jump_force * Time.deltaTime;
        else if (movement.y < -0.0f)
            movement.y = 0;
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

    private bool IsGrounded()
    {
        RaycastHit2D rayhit = Physics2D.Raycast(col.bounds.center,Vector2.down,col.bounds.extents.y + .1f, ground);
        Debug.DrawRay(col.bounds.center, Vector2.down * (col.bounds.extents.y + .1f));
        return rayhit.collider != null;
    }
}
