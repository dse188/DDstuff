using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> players;
    [SerializeField] public int currentPlayerIndex = 0;
    [SerializeField] public bool isTurnActive = false;

    public CinemachineVirtualCamera cinemachineCam;

    //UI
    [SerializeField] private TextMeshProUGUI turnText;
    [SerializeField] private Button endTurnButton = null;

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

    }

    // For use of other Scripts. Checks whether it's the current Player's turn.
    public bool PlayerTurnActive(GameObject playerObj)  
    {
        if(players[currentPlayerIndex] == playerObj && isTurnActive)
        {
            return true;
        }
        return false;
    }

    void StartTurn()
    {
        if(currentPlayerIndex >= players.Count)
        {
            currentPlayerIndex = 0;     //Reset turn cycle
        }

        StartCoroutine(ShowText());
        //StartCoroutine(FadeText());

        Debug.Log($"It's {players[currentPlayerIndex].name}'s turn!");
        isTurnActive = true;

        //Enable player's control for their turn. (Reset the player's move meter)
        players[currentPlayerIndex].GetComponent<PlayerMovement>().MoveRefill();

        //Make the Cinemachine camera follow and look at the current player.
        cinemachineCam.Follow = players[currentPlayerIndex].transform;
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

    private IEnumerator ShowText()
    {
        yield return new WaitForSeconds(0.5f);
        turnText.enabled = true;
        turnText.text = players[currentPlayerIndex].name + "'s turn";
        yield return StartCoroutine(FadeText());
    }

    private IEnumerator FadeText()
    {
        yield return new WaitForSeconds(1);
        turnText.enabled = false;

    }
}
