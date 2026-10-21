using System.Collections;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform Target;
    public float Speed = 1f;

    private Coroutine LookCoroutine;

    void Update()
    {
        StartRotating();

    }


    public void StartRotating()
    {
        if (LookCoroutine != null)
        {
            StopCoroutine(LookCoroutine);
        }

        LookCoroutine = StartCoroutine(LookAt());
    }

    private IEnumerator LookAt()
    {
        Quaternion lookRotation = Quaternion.LookRotation(Target.position - transform.position);
        lookRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lookRotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        Quaternion initialRotation = transform.rotation;
        transform.rotation = Quaternion.Slerp(initialRotation, lookRotation, 1f);
        yield return null;
    }
}