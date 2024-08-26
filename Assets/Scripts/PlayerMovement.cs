using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] LayerMask clickableSurface;

    private NavMeshAgent myAgent;

    // Player move stat
    [SerializeField] float moveRange;
    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if(Physics.Raycast (myRay, out hitInfo, 100, clickableSurface))
            {
                myAgent.SetDestination(hitInfo.point);
                isMoving = true;
            }
            if(myAgent.isStopped == true)
            {
                isMoving = false;
            }
            /*if (!myAgent.pathPending)
            {
                if (myAgent.remainingDistance <= myAgent.stoppingDistance)
                {
                    if (!myAgent.hasPath || myAgent.velocity.sqrMagnitude == 0f)
                    {
                        isMoving = false;
                    }
                }
            }*/
        }
        if(isMoving)
        {
            moveRange -= Mathf.Abs(myAgent.transform.position.z);
            if (moveRange <= 0)
            {
                myAgent.isStopped = true;
            }
        }
        
    }
}
