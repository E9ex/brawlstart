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
    public GameObject deathExp;
    public int Maxhealth = 100;
    public int Currenthealth;
    private bool movement;
    public float moveSpeed = 10f;

    public float Velocity;
    
    public float speed = 5;
    Vector3 lastPosition;
   
    
    [Header("anim")]
    public float animforvelo=0.0f;
    public float Acceleration = 1;
    private int velocityhash = Animator.StringToHash("Velocity");
    private UImanager UImanagerr;
    CharacterController characterController;
    public healtbarforplayers healtbarforplayers;
    public bool inputIsJoystick = true;
    [Header("movespeed")]
    public bool isIncreasingMoveSpeed = false;
    public float initialMoveSpeed = 10f;
    public float increasedMoveSpeed = 20f;
    public float duration = 10f;
    public float timer = 0f;
    public GameObject Shoes;
    public float velocity;
    public float velocityLimit = .05f;
    private static readonly int Velocityhash = Animator.StringToHash("velocity");
    Camera mainCam;

    public Vector3 velocityMove;

    private void Awake()
    {
        UImanagerr = GetComponent<UImanager>();
        characterController = GetComponent<CharacterController>();
    }


    void Start()
    {
        Shoes.gameObject.SetActive(false);
        Currenthealth = Maxhealth;
        healtbarforplayers.setmaximumhealth(Maxhealth);
        // playersprite.gameObject.SetActive(false);
        M_Camera.I.StartCamera(transform);
        lastPosition = transform.position;
      

        mainCam = Camera.main;
    }

    void CalculateVelocity()
    {
        velocityMove = characterController.velocity;
        velocity = velocityMove.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        if (isIncreasingMoveSpeed)
        {
            timer += Time.deltaTime;
            if (timer >= duration)
            {
                moveSpeed = initialMoveSpeed;
                isIncreasingMoveSpeed = false;
                Shoes.gameObject.SetActive(false);
            }
        }

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
            if(velocity > velocityLimit)
                anim.SetFloat(Velocityhash, velocity);
        }

        GetMousePos();

    }


    void LookAtTarget(Vector3 lookPos)
    {
        Vector3 targetDirection = lookPos - transform.position;

        targetDirection -= Vector3.up * targetDirection.y;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5 * Time.deltaTime);
    }

    
    
    void GetMousePos()
    {
        if (mainCam != null)
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                
                LookAtTarget(new Vector3(raycastHit.point.x, 0, raycastHit.point.z));   
                // transform.position = targetPos;
            }
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
    
    public void takedamage(int damage)
    {
        Currenthealth -= damage;
        healtbarforplayers.SetHealthh(Currenthealth);
        if (Currenthealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        M_EndGame.I.LosePanelOpen();
        Destroy(gameObject);
        Instantiate(deathExp, transform.position, Quaternion.identity);
    }

    private void IncreasemoveSpeed()
    {
        if (!isIncreasingMoveSpeed)
        {
            moveSpeed = increasedMoveSpeed;
            isIncreasingMoveSpeed = true;
            timer = 0f;
            Shoes.gameObject.SetActive(true);
        }
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
