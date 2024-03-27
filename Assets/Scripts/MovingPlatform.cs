using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    Vector3 DesPoint;

    public GameObject Bridge;
    public Transform[] waypoints;
    int point;
    int pointAmount;
    int direction = 1;

    public float waitDuration;
    int speedMutiplier;

    public void Awake()
    {
        waypoints = new Transform[Bridge.transform.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = Bridge.transform.GetChild(i).gameObject.transform;
        }

    }
    private void Start()
    {
        pointAmount = waypoints.Length;
        point = 0;
        DesPoint = waypoints[point].transform.position;
    }
    private void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, DesPoint, step);

        if (transform.position == DesPoint)
        {
            NextPoint();
        }
    }
    void NextPoint()
    {
        if (point == pointAmount)
        {
            direction = -1;
        }
        if (point == 0)
        {
            direction = 1;
        }
        point += direction;
        DesPoint = waypoints[point].transform.position;
    }
    IEnumerable WaitPoint()
    {
        speedMutiplier = 0;
        yield return new WaitForSeconds(waitDuration);
        speedMutiplier = 1;
    }
    
}
