using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] LayerMask clickableSurface;

    public NavMeshAgent myAgent;

    // Player move stat
    public float moveMeter;
    public float moveFactor;
    public float moveRefill;
    public bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    public void PlayerMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(myRay, out hitInfo, 100, clickableSurface))
            {
                myAgent.SetDestination(hitInfo.point);

            }
        }

        if (myAgent.remainingDistance > 0)
        {
            isMoving = true;
        }
        if (myAgent.remainingDistance <= 0)
        {
            isMoving = false;
        }

        if (isMoving)
        {
            MoveMeter();
        }
    }


    void MoveMeter()
    {
        moveMeter -= moveFactor * Time.deltaTime;
        if(moveMeter <= 0)
        {
            myAgent.SetDestination(myAgent.transform.position);
            moveMeter *= 0;
        }
    }

    public void MoveRefill()
    {
        moveMeter = moveRefill;
    }

    public void DepleteMoveMeter()
    {
        moveMeter = 0;
    }

    private IEnumerator RefillMeter()
    {
        yield return new WaitForSeconds(2);
        moveMeter = moveRefill;
    }
}

