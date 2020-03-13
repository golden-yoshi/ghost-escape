using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float Speed;
    private float WaitTime;
    public float StartWaitTime;

    public Transform[] moveSpot;
    private int spots;

    // Start is called before the first frame update
    void Start()
    {
        WaitTime = StartWaitTime;
        spots = Random.Range(0, moveSpot.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot[spots].position, Speed*Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpot[spots].position) < 0.2f)
        {
            if(WaitTime <= 0)
            {
                spots = Random.Range(0, moveSpot.Length);
                WaitTime = StartWaitTime;
            }
            else {
                WaitTime -= Time.deltaTime;
            }
        }
    }
}
