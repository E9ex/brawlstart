using UnityEngine;

public class M_Camera : Singleton<M_Camera>
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;


    public void StartCamera(Transform newTransform)
    {
        player = newTransform;
    }
    
    
    void Update()
    {
        if(player)
            transform.position = player.position + offset;
    }
}
