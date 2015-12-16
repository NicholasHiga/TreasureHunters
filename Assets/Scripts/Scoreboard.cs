using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour {

    public static Text playerOne;
    public static Text playerTwo;
    public static Image scoreboard;
    public static float playerOneKills = 0;
    public static float playerOneDeaths = 0;
    public static float playerTwoKills = 0;
    public static float playerTwoDeaths = 0;

	// Use this for initialization
	void Start () {
        playerOne = GameObject.Find("Player1Score").GetComponent<Text>();
        playerOne.text = "Player1  Kills: 0      Deaths: 0";
        playerTwo = GameObject.Find("Player2Score").GetComponent<Text>();
        playerTwo.text = "Player2  Kills: 0      Deaths: 0";
        scoreboard = GameObject.Find("Scoreboard").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Tab))
        {
            playerOne.GetComponent<Text>().enabled = true;
            playerTwo.GetComponent<Text>().enabled = true;
            scoreboard.GetComponent<Image>().enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            playerOne.GetComponent<Text>().enabled = false;
            playerTwo.GetComponent<Text>().enabled = false;
            scoreboard.GetComponent<Image>().enabled = false;
        }
    }
}
