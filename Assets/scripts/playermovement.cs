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
    public float Acceleration = .1f;
    private int velocityhash;
    
    
    void Start()
    {
        playersprite.gameObject.SetActive(false);
        M_Camera.I.StartCamera(transform);
        velocityhash = Animator.StringToHash("Velocityy");
    }

    void CalculateVelocity()
    {
        var position = transform.position;
        Velocity = (position - lastPosition).magnitude;
        lastPosition = position;
    }
    
    

    // Update is called once per frame
    void Update()
    {
        if (joystick.Horizontal > 0 || joystick.Horizontal < 0 || joystick.Vertical > 0 || joystick.Vertical < 0)
        {
            playersprite.gameObject.SetActive(true);
            playersprite.position = new Vector3(joystick.Horizontal + transform.position.x, .1f,
                joystick.Vertical + transform.position.z);
            transform.LookAt(new Vector3(playersprite.position.x, 0, playersprite.position.z));
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            transform.Translate(Vector3.forward * Time.deltaTime * 5);

            Velocity += Time.deltaTime * Acceleration;
            anim.SetFloat(velocityhash, animforvelo);
        }

        CalculateVelocity();
        
        
    }
}
