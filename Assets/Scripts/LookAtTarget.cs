using System.Collections;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform target;
    private Coroutine lookAtCoroutine;
   
   void Update()
    {
        LookAt();
    }
    private void LookAt()
    {
        Quaternion LookRotation = Quaternion.LookRotation(target.position - transform.position);
        LookRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, LookRotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        {
            Debug.Log("LookAt");
            transform.rotation = Quaternion.RotateTowards(transform.rotation, LookRotation, 1f);
        }
    }

}
