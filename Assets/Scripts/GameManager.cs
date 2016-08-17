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

    public string playerName = "PLAYER", friendName = "FRIEND", chosenCharacterStart = "PSherley", chosenCharacterPlayer = "PSherley", chosenCharacterFriend = "FSherlock", playerGender = "Female", friendGender = "Male";

    public GameObject start, player, friend;

    public List<Sprite> sJohnPortraits, sSherlockPortraits, sJoannePortraits, sSherleyPortraits;
    public List<Sprite> pJohnPortraits, pSherlockPortraits, pJoannePortraits, pSherleyPortraits;
    public List<Sprite> fJohnPortraits, fSherlockPortraits, fJoannePortraits, fSherleyPortraits;

    // Use this for initialization
    void Start() {
        ChangeBackground();

        playerName = CharacterInfo.Instance.chosenPlayerName;
        friendName = CharacterInfo.Instance.chosenFriendName;

        chosenCharacterStart = CharacterInfo.Instance.chosenPlayerCharacter;
        chosenCharacterPlayer = CharacterInfo.Instance.chosenPlayerCharacter;
        chosenCharacterFriend = CharacterInfo.Instance.chosenFriendCharacter;

        playerGender = (chosenCharacterPlayer == "PJohn" || chosenCharacterPlayer == "PSherlock") ? "Male" : "Female";
        friendGender = (chosenCharacterFriend == "FJoanne" || chosenCharacterPlayer == "FSherley") ? "Female" : "Male";

        flowchart.SetStringVariable("playerName", playerName);
        flowchart.SetStringVariable("friendName", friendName);
        flowchart.SetStringVariable("playerGender", playerGender);
        flowchart.SetStringVariable("friendGender", friendGender);

        switch(chosenCharacterStart) {
            case "PJohn":
                start.GetComponent<Character>().portraits = sJohnPortraits;
                break;
            case "PSherlock":
                start.GetComponent<Character>().portraits = sSherlockPortraits;
                break;
            case "PJoanne":
                start.GetComponent<Character>().portraits = sJoannePortraits;
                break;
            case "PSherley":
                start.GetComponent<Character>().portraits = sSherleyPortraits;
                break;
        }

        switch(chosenCharacterPlayer) {
            case "PJohn":
                player.GetComponent<Character>().portraits = pJohnPortraits;
                break;
            case "PSherlock":
                player.GetComponent<Character>().portraits = pSherlockPortraits;
                break;
            case "PJoanne":
                player.GetComponent<Character>().portraits = pJoannePortraits;
                break;
            case "PSherley":
                player.GetComponent<Character>().portraits = pSherleyPortraits;
                break;
        }

        switch(chosenCharacterFriend) {
            case "FJohn":
                friend.GetComponent<Character>().portraits = fJohnPortraits;
                break;
            case "FSherlock":
                friend.GetComponent<Character>().portraits = fSherlockPortraits;
                break;
            case "FJoanne":
                friend.GetComponent<Character>().portraits = fJoannePortraits;
                break;
            case "FSherley":
                friend.GetComponent<Character>().portraits = fSherleyPortraits;
                break;
        }
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
            //background.GetComponent<MeshRenderer>().material = bgMats[bgNum];
        }
    }

    public void ChangeFriendState() {
        friendNum++;
        if(friendNum <= friendStates.Count) {
            //background.GetComponent<MeshRenderer>().material = bgMats[bgNum];
        }
    }

    public void ChangeBackground() {
        bgNum++;
        if(bgNum <= bgMats.Count) {
            background.GetComponent<MeshRenderer>().material = bgMats[bgNum];
        }

    }
}
