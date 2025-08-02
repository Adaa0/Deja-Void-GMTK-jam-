using UnityEngine;
using System.Collections;

public class UFO_Mover : MonoBehaviour
{
    public Transform pointA; // boş GameObject 1
    public Transform pointB; // boş GameObject 2

    public float speed = 3f;
    public float waitTime = 5f;

    private Vector3 targetPos;
    private bool goingToB = true;

    void Start()
    {
        if (pointA == null || pointB == null)
        {
            Debug.LogError("Point A ve Point B referansları atanmalı!");
            enabled = false;
            return;
        }

        transform.position = pointA.position;
        targetPos = pointB.position;

        StartCoroutine(MoveRoutine());
    }

    IEnumerator MoveRoutine()
    {
        while (true)
        {
            while (Vector3.Distance(transform.position, targetPos) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(waitTime);

            targetPos = goingToB ? pointA.position : pointB.position;
            goingToB = !goingToB;
        }
    }
}
