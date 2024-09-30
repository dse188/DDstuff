using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> players;
    [SerializeField] private int currentPlayerIndex = 0;
    [SerializeField] private bool isTurnActive = false;

    public CinemachineVirtualCamera cinemachineCam;

    // Start is called before the first frame update
    void Start()
    {


        if(players.Count > 0)
        {
            StartTurn();
        }
        else
        {
            Debug.Log("No player available!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isTurnActive && Input.GetKeyDown(KeyCode.Space))
        {
            EndTurn();
        }
    }

    void StartTurn()
    {
        if(currentPlayerIndex >= players.Count)
        {
            currentPlayerIndex = 0;     //Reset turn cycle
        }

        Debug.Log($"It's {players[currentPlayerIndex].name}'s turn!");
        isTurnActive = true;

        //Enable player's control for their turn. (Reset the player's move meter)
        //players[currentPlayerIndex].GetComponent<PlayerMovement>().moveMeter = 
        players[currentPlayerIndex].GetComponent<PlayerMovement>().MoveRefill();

        //Make the Cinemachine camera follow and look at the current player.
        cinemachineCam.Follow = players[currentPlayerIndex].transform;
        //cinemachineCam.LookAt = players[currentPlayerIndex].transform;
    }

    public void EndTurn()
    {
        if (!isTurnActive) return;

        Debug.Log($"{players[currentPlayerIndex].name}'s turn is over.");
        isTurnActive = false;

        //Disable controls for the current player if needed. (Deplete all remaining move meter on the current player)
        players[currentPlayerIndex].GetComponent<PlayerMovement>().DepleteMoveMeter();

        //Next player's turn
        currentPlayerIndex++;
        StartTurn();
    }
}
