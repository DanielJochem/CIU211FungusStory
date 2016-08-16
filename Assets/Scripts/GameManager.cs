using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Fungus;

public class GameManager : SingletonBehaviour<GameManager>
{
    public Flowchart flowchart;

    public int bgNum = 0;
    public List<Material> bgMats;

    public int playerNum = 0;
    public List<Sprite> playerStates;

    public int friendNum = 0;
    public List<Sprite> friendStates;

    public GameObject background;

    public string playerName = "PLAYER", friendName = "FRIEND", chosenCharacterPlayer = "PJoanne", chosenCharacterFriend = "FSherlock", playerGender = "Female", friendGender = "Male";

    // Use this for initialization
    void Start() {
        ChangeBackground();

        playerName = CharacterInfo.Instance.chosenPlayerName;
        friendName = CharacterInfo.Instance.chosenFriendName;

        chosenCharacterPlayer = CharacterInfo.Instance.chosenPlayerCharacter;
        chosenCharacterFriend = CharacterInfo.Instance.chosenFriendCharacter;

        playerGender = (chosenCharacterPlayer == "PJohn" || chosenCharacterPlayer == "PSherlock") ? "Male" : "Female";
        friendGender = (chosenCharacterFriend == "FJoanne" || chosenCharacterPlayer == "FSherley") ? "Female" : "Male";

        flowchart.SetStringVariable("playerName", playerName);
        flowchart.SetStringVariable("friendName", friendName);
        flowchart.SetStringVariable("playerGender", playerGender);
        flowchart.SetStringVariable("friendGender", friendGender);
    }
	
	// Update is called once per frame
	void Update () {

        //Change scenes
        if(flowchart.GetBooleanVariable("bgChange") == true) {
            flowchart.SetBooleanVariable("bgChange", false);
            ChangeBackground();
        }

	}

    public void ChangePlayerState() {
        playerNum++;
        if(playerNum <= playerStates.Count) {
            background.GetComponent<MeshRenderer>().material = bgMats[bgNum];
        }
    }

    public void ChangeFriendState() {
        friendNum++;
        if(friendNum <= friendStates.Count) {
            background.GetComponent<MeshRenderer>().material = bgMats[bgNum];
        }
    }

    public void ChangeBackground() {
        bgNum++;
        if(bgNum <= bgMats.Count) {
            background.GetComponent<MeshRenderer>().material = bgMats[bgNum];
        }

    }
}
