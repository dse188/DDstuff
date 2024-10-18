using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveMeterUI : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] private List<GameObject> players;

    private int currentPlayerIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(currentPlayerIndex >= players.Count)
        {
            currentPlayerIndex = 0;
        }
        /*players = GetComponent<PlayerMovement>();

        slider.minValue = players.moveMeter;
        slider.maxValue = players.moveRefill;*/
    }

    // Update is called once per frame
    void Update()
    {
        //slider.value = players.moveMeter;
    }
}
