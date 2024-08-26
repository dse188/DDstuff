using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] LayerMask clickableSurface;

    private NavMeshAgent myAgent;

    // Player move stat
    [SerializeField] float moveMeter;
    [SerializeField] float moveFactor;
    [SerializeField] float moveRefill;
    public bool isMoving = false;

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

            if(Physics.Raycast(myRay, out hitInfo, 100, clickableSurface))
            {
                myAgent.SetDestination(hitInfo.point);
                
            }
        }

        if(myAgent.remainingDistance > 0)
        {
            isMoving = true;
        }
        if(myAgent.remainingDistance <= 0)
        {
            isMoving = false;
        }

        if (isMoving)
        {
            MoveMeter();
        }
        if(moveMeter <= 0)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                moveMeter = moveRefill;
            }
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

    private IEnumerator RefillMeter()
    {
        yield return new WaitForSeconds(2);
        moveMeter = moveRefill;
    }
}

