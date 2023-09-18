using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public int maxhealth = 100;
    public int currenthealth;
    public healthbarscript healthbar;
  //  private Transform enemy;
    private Animator forwardsandbackwards;
    public GameObject deathExp;
    [Header("navmesh")]
    public NavMeshAgent agent;
    public float range;
    [SerializeField] private Animator anim;
    private bool movement;

    public Transform centrePoint;

    Vector3 lastPosition;
    Vector3 currentPosition;
    public float velocity;
    public float velocityLimit = .05f;
    private static readonly int Velocity = Animator.StringToHash("velocity");

    bool isGameStarted = false;
   
    

    private void Awake()
    {
        
        forwardsandbackwards = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        //  enemy = GetComponent<Transform>();
    }

    private void Start()
    {
        currenthealth = maxhealth;
        healthbar.setmaxhealth(maxhealth);

        agent.isStopped = true;

        M_GameManager.I.onLevelStart += GameStart;
        M_GameManager.I.onLevelEnd += GameEnd;
        
    }

    #region Game

    void GameStart()
    {
        isGameStarted = true;
        agent.isStopped = false;
    }

    void GameEnd()
    {
        isGameStarted = false;
        agent.isStopped = true;
    }

    #endregion

 
    void Update()
    {
        
        if(!agent.isStopped)        
            if (agent.remainingDistance <= agent.stoppingDistance) 
            {
                Vector3 point;
                if (RandomPoint(centrePoint.position, range, out point)) 
                {
                    Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); 
                    agent.SetDestination(point);
                }
            }
        
        CalculateVelocity();
        
        if(velocity > velocityLimit)
            anim.SetFloat(Velocity,velocity);
    }

    void CalculateVelocity()
    {
        velocity = agent.velocity.magnitude;
        
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;  
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) 
        { 
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
    public void takedamage(int damage)
    {
        currenthealth -= damage;
        healthbar.sethealth(currenthealth);
        if (currenthealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        M_EndGameWin.I.WinPanelOpen();
        Destroy(gameObject);
        Instantiate(deathExp, transform.position, Quaternion.identity);
    }
   

}
