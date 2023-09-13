using UnityEngine;

public class CannonBall : MonoBehaviour 
{
    [SerializeField]
    GameObject deathEffect;

    string selfTag;

    public void SetTag(string newTag)
    {
        selfTag = newTag;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(selfTag)) return;
        
        Debug.Log("MERMI PATLIYOR " + collision.gameObject.tag);
        Instantiate(deathEffect, transform.position, Quaternion.LookRotation(collision.contacts[0].normal));

        Destroy(gameObject);
    }
}
