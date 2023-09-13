using System;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private Transform playersprite;
    [SerializeField] private Animator anim;
    private bool movement;

    public float Velocity;
    
    public float speed = 5;
    Vector3 lastPosition;
    
    [Header("anim")]
    public float animforvelo=0.0f;
    public float Acceleration = 1;
    private int velocityhash = Animator.StringToHash("Velocity");

    CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }


    void Start()
    {
        // playersprite.gameObject.SetActive(false);
        M_Camera.I.StartCamera(transform);
        lastPosition = transform.position;
        playersprite.gameObject.SetActive(true);
    }

    void CalculateVelocity()
    {
        Velocity = characterController.velocity.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick.Horizontal > 0 || joystick.Horizontal < 0 || joystick.Vertical > 0 || joystick.Vertical < 0)
        {
            playersprite.position = new Vector3(joystick.Horizontal + transform.position.x, .1f,
                joystick.Vertical + transform.position.z);
            transform.LookAt(new Vector3(playersprite.position.x, 0, playersprite.position.z));
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
        
        Vector3 moveDirection = new Vector3(joystick.Horizontal, 0.0f, joystick.Vertical);

        if (moveDirection.magnitude > 1)
            moveDirection.Normalize();
        characterController.Move(moveDirection * speed * Time.deltaTime);
        
        CalculateVelocity();
        anim.SetFloat( velocityhash, Velocity);
    }
}
