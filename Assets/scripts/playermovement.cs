using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class playermovement : MonoBehaviour
{
    [SerializeField] private Joystick leftJoystick;
    [SerializeField] private Joystick rightJoystick;
    [SerializeField] private Transform playersprite;
    [SerializeField] private Animator anim;
    private playerhealthbar Playerhealthbar;
    public float Maxhealth = 100;
    public float Currenthealth;
    private bool movement;
    public float moveSpeed = 10f;

    public float Velocity;
    
    public float speed = 5;
    Vector3 lastPosition;
    
    [Header("anim")]
    public float animforvelo=0.0f;
    public float Acceleration = 1;
    private int velocityhash = Animator.StringToHash("Velocity");

    CharacterController characterController;

    public bool inputIsJoystick = true;
   // public static  playermovement ınstance;
    
    private void Awake()
    {
        //ınstance = this;
        characterController = GetComponent<CharacterController>();
    }


    void Start()
    {
        Currenthealth = Maxhealth;
       //Playerhealthbar.Setmaxhealth(Maxhealth);
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

        if (inputIsJoystick)
        { 
            #region KlavyeInput
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
            transform.Translate(movement);
            Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
            if (moveDirection.magnitude > 1)
                moveDirection.Normalize();
            characterController.Move(moveDirection * speed * Time.deltaTime);
            #endregion
          
            //     if (leftJoystick.Horizontal > 0 || leftJoystick.Horizontal < 0 || leftJoystick.Vertical > 0 || leftJoystick.Vertical < 0)
            //     {
            //         playersprite.position = new Vector3(leftJoystick.Horizontal + transform.position.x, .1f,
            //             leftJoystick.Vertical + transform.position.z);
            //         transform.LookAt(new Vector3(playersprite.position.x, 0, playersprite.position.z));
            //         transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            //     }
            //
            //     Vector3 moveDirection = new Vector3(leftJoystick.Horizontal, 0.0f, leftJoystick.Vertical);
            //
            //     if (moveDirection.magnitude > 1)
            //         moveDirection.Normalize();
            //     characterController.Move(moveDirection * speed * Time.deltaTime);
            // }
            // else
            // {
            //     // //KLAVYE İLE HAREKET BURDA
            //     float horizontalInput = Input.GetAxis("Horizontal");
            //     float verticalInput = Input.GetAxis("Vertical");
            //     
            //     Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
            //     transform.Translate(movement);
            //     
            //     //characterController.Move(moveDirection * speed * Time.deltaTime);
            // }

            CalculateVelocity();
            anim.SetFloat(velocityhash, Velocity);
        }
    }
    

    public void OnDrag(PointerEventData ped)
    {
        //move joystick        
        //move character
    }

    public void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public void OnPointerUp(PointerEventData ped)
    {
        //reset joystick
    }
    public void takedamage(float damage)
    {
        Currenthealth -= damage;
        //Playerhealthbar.Sethealth(Currenthealth);
        if (Currenthealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
       // Instantiate(deathExp, transform.position, Quaternion.identity);
    }

    private void IncreasemoveSpeed()
    {
        moveSpeed += 10f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("movespeedextra"))
        {
            Destroy(other.gameObject);
            IncreasemoveSpeed();
        }
    }
}
