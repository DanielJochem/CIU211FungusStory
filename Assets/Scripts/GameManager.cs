using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Fungus;

public class GameManager : SingletonBehaviour<GameManager>
{
    public Flowchart flowchart;
    public Light lightIntensity;

    public int bgNum = 0;
    public List<Material> bgMats;

    public int startNum = 0;
    public List<Sprite> startStates;

    public int playerNum = 0;
    public List<Sprite> playerStates;

    public int friendNum = 0;
    public List<Sprite> friendStates;

    public GameObject background;

    public string playerName = "PLAYER", friendName = "FRIEND", chosenCharacterStart = "PSherlock", chosenCharacterPlayer = "PSherlock", chosenCharacterFriend = "FSherley", playerGender = "Male", friendGender = "Female";

    public GameObject start, player, friend;

    public List<Sprite> sJohnPortraits, sSherlockPortraits, sJoannePortraits, sSherleyPortraits;
    public List<Sprite> pJohnPortraits, pSherlockPortraits, pJoannePortraits, pSherleyPortraits;
    public List<Sprite> fJohnPortraits, fSherlockPortraits, fJoannePortraits, fSherleyPortraits;
    

    void Start() {
        playerName = CharacterInfo.Instance.chosenPlayerName;
        friendName = CharacterInfo.Instance.chosenFriendName;

        chosenCharacterStart = CharacterInfo.Instance.chosenPlayerCharacter;
        chosenCharacterPlayer = CharacterInfo.Instance.chosenPlayerCharacter;
        chosenCharacterFriend = CharacterInfo.Instance.chosenFriendCharacter;

        playerGender = (chosenCharacterPlayer == "PJohn" || chosenCharacterPlayer == "PSherlock") ? "Male" : "Female";
        friendGender = (chosenCharacterFriend == "FJoanne" || chosenCharacterFriend == "FSherley") ? "Female" : "Male";

        flowchart.SetStringVariable("playerName", playerName);
        flowchart.SetStringVariable("friendName", friendName);

        flowchart.SetStringVariable("playerHeShe", playerGender == "Male" ? "he" : "she");
        flowchart.SetStringVariable("playerHimHer", playerGender == "Male" ? "him" : "her");
        flowchart.SetStringVariable("playerHisHer", playerGender == "Male" ? "his" : "her");
        flowchart.SetStringVariable("playerBroGirl", playerGender == "Male" ? "bro" : "girl");

        flowchart.SetStringVariable("friendHeShe", friendGender == "Female" ? "she" : "he");
        flowchart.SetStringVariable("friendHimHer", friendGender == "Female" ? "her" : "him");
        flowchart.SetStringVariable("friendHisHer", friendGender == "Female" ? "her" : "his");
        flowchart.SetStringVariable("friendBroGirl", friendGender == "Female" ? "girl" : "bro");

        player.GetComponent<Character>().nameText = playerName;
        friend.GetComponent<Character>().nameText = friendName;

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


    void Update() {

        //Change scenes
        if(flowchart.GetBooleanVariable("bgChange") == true) {
            flowchart.SetBooleanVariable("bgChange", false);
            ChangeBackground();
        }

        if(lightIntensity.intensity == 0 && flowchart.GetBooleanVariable("changeLightIntensity") == true)
            lightIntensity.intensity = 3;

        if(flowchart.GetStringVariable("prosthetic") == "hand" || flowchart.GetStringVariable("prosthetic") == "leg") {
            flowchart.SetStringVariable("wasWere", "was");
            flowchart.SetStringVariable("itThey", "it");
            flowchart.SetStringVariable("isAre", "is");
        } else {
            flowchart.SetStringVariable("wasWere", "were");
            flowchart.SetStringVariable("itThey", "they");
            flowchart.SetStringVariable("isAre", "are");
        }
	}

    public void ChangeBackground() {
        bgNum++;
        if(bgNum <= bgMats.Count)
            background.GetComponent<MeshRenderer>().material = bgMats[bgNum];
    }

    public void ChosenAccident(Button choice) {
        flowchart.SetStringVariable("prosthetic", choice.name);
        Fungus.Flowchart.BroadcastFungusMessage("Scene 5 Begin");
    }

    public void ChosenProcedureLocation(Button choice) {
        flowchart.SetStringVariable("procedureLocation", choice.name);
        Fungus.Flowchart.BroadcastFungusMessage("Scene 8 Begin");
    }
}
