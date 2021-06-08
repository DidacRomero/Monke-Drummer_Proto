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

    [FMODUnity.EventRef]
    public string KickEvent = "";

    [FMODUnity.ParamRef]
    public string KickVelocity = "";

    [FMODUnity.EventRef]
    public string SnareEvent = "";

    [FMODUnity.EventRef]
    public string HiHatEvent = "";

    [FMODUnity.EventRef]
    public string KickOneShot = "";

    [FMODUnity.EventRef]
    public string SnareOneShot = "";

    [FMODUnity.EventRef]
    public string HiHatOneShot = "";

    public int max_jumps = 3;
    int jumps = 0;


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
        if(Keyboard.current.uKey.wasPressedThisFrame == true)
        {
            FMODUnity.RuntimeManager.PlayOneShot(HiHatOneShot, transform.position);
        }
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

                if (mov == Vector2.up)
                {
                    FMODUnity.RuntimeManager.PlayOneShot(KickOneShot, transform.position);
                    if (jumps < max_jumps)
                    {
                        jumps++;
                        movement = jump_force * mov;
                    }
                }
                else
                {
                    FMODUnity.RuntimeManager.PlayOneShot(SnareOneShot, transform.position);

                    movement = jump_force * mov;
                }

            }
    }

    public void MIDI_Kick(InputAction.CallbackContext context)
    {
        //Testing MIDI Input
        Debug.Log("Kick");

        float vel = context.ReadValue<float>();

        if (context.performed)
        {
            if (vel > 0.0f)
            {
                Debug.Log("Vertical Movement");
                if(jumps < max_jumps)
                {
                    movement = Vector2.up * jump_force * vel;
                    jumps++;
                }
                //FMODUnity.RuntimeManager.PlayOneShot(KickEvent, transform.position);
                //KickVelocity.
                FMOD.Studio.EventInstance kick = FMODUnity.RuntimeManager.CreateInstance(KickEvent);
                kick.setParameterByName("Velocity", vel);
                kick.start();
                kick.release();
                Debug.Log("Velocity: " + vel);
            }
        }
           
    }

    public void MIDI_Snare(InputAction.CallbackContext context)
    {
        //Testing MIDI Input
        Debug.Log("Snare");

        float vel = context.ReadValue<float>();

        if (context.performed)
        {
            if (vel > 0.0f)
            {
                Debug.Log("Vertical Movement");
                movement = Vector2.down * jump_force * vel;
                FMODUnity.RuntimeManager.PlayOneShot(SnareEvent, transform.position);

                FMOD.Studio.EventInstance kick = FMODUnity.RuntimeManager.CreateInstance(SnareEvent);
                kick.setParameterByName("Velocity", vel);
                kick.start();
                kick.release();
                Debug.Log("Velocity: " + vel);
            }
        }
    }

    public void MIDI_hihat(InputAction.CallbackContext context)
    {
        //Testing MIDI Input
        Debug.Log("Hi-Hat");

        float vel = context.ReadValue<float>();

        if (context.performed)
        {
            if (vel > 0.0f)
            {
                Debug.Log("Vertical Movement");

                FMOD.Studio.EventInstance hihat = FMODUnity.RuntimeManager.CreateInstance(HiHatEvent);
                hihat.setParameterByName("Velocity", vel);
                hihat.start();
                hihat.release();
                Debug.Log("Velocity: " + vel);
            }
        }

    }

    private bool IsGrounded()
    {
        RaycastHit2D rayhit = Physics2D.Raycast(col.bounds.center,Vector2.down,col.bounds.extents.y + .1f, ground);
        Debug.DrawRay(col.bounds.center, Vector2.down * (col.bounds.extents.y + .1f));
        if (rayhit.collider != null)
            jumps = 1;

        return rayhit.collider != null;
    }
}
