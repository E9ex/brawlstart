using UnityEngine;

public class MousePosition : MonoBehaviour
{
     private Camera maincamera;

     [SerializeField] Vector3 targetPos;

     private void Awake()
     {
         maincamera = FindObjectOfType<Camera>();
     }

     void Update()
    {
        if (maincamera != null)
        {
            Ray ray = maincamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                targetPos = new Vector3(raycastHit.point.x, 9f, raycastHit.point.z);//1.25f ==y
                
                transform.position = targetPos;
            }
        }
    }
}
