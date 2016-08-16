using UnityEngine;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterInfo : SingletonBehaviour<CharacterInfo> {

    public string chosenPlayerCharacter = "";
    public string chosenFriendCharacter = "";

    public List<Button> playerButtonList;
    public List<Button> friendButtonList;

    public string chosenPlayerName = "";
    public string chosenFriendName = "";

    public Button startGameButton;

    // Use this for initialization
    void Start() {
        if(SceneManager.GetActiveScene().name == "StartScene") {
            foreach(Button bttn in FindObjectsOfType<Button>()) {
                if(bttn.tag == "PlayerButton")
                    playerButtonList.Add(bttn);

                else if(bttn.tag == "FriendButton")
                    friendButtonList.Add(bttn);
            }

            startGameButton.enabled = false;
        }

        Object.DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update() {
        if(SceneManager.GetActiveScene().name == "StartScene") {
            startGameButton.enabled = (chosenPlayerName.Length > 2 && chosenFriendName.Length > 2 && chosenPlayerCharacter != "" && chosenFriendCharacter != "") ? true : false;
            startGameButton.image.color = (!startGameButton.enabled) ? startGameButton.colors.disabledColor : startGameButton.colors.normalColor;
        }
    }

    public void OnButtonPress(Button button) {
        if(button.tag == "PlayerButton") {
            chosenPlayerCharacter = button.name;

            foreach(Button bttn in playerButtonList) {
                if(chosenPlayerCharacter != "")
                    bttn.GetComponent<Image>().sprite = bttn.spriteState.disabledSprite;

                if(bttn.name == chosenPlayerCharacter)
                    bttn.GetComponent<Image>().sprite = bttn.spriteState.pressedSprite;
            }

        } else if(button.tag == "FriendButton") {
            chosenFriendCharacter = button.name;

            foreach(Button bttn in friendButtonList) {
                if(chosenFriendCharacter != "")
                    bttn.GetComponent<Image>().sprite = bttn.spriteState.disabledSprite;

                if(bttn.name == chosenFriendCharacter)
                    bttn.GetComponent<Image>().sprite = bttn.spriteState.pressedSprite;
            }
        }
    }

    public void OnNameEdited(InputField field) {
        if(field.name == "PName")
            chosenPlayerName = field.text;

        else if(field.name == "FName")
            chosenFriendName = field.text;
    }

    public void UpperCaseify(InputField field) {
        field.text = TidyCase(field.text);
    }

    public void StartGamePressed() {
        SceneManager.LoadScene(1);
    }

    public static string TidyCase(string sourceStr) {
        sourceStr.Trim();
        if(!string.IsNullOrEmpty(sourceStr)) {
            char[] allCharacters = sourceStr.ToCharArray();

            for(int i = 0; i < allCharacters.Length; i++) {
                char character = allCharacters[i];
                if(i == 0) {
                    if(char.IsLower(character)) {
                        allCharacters[i] = char.ToUpper(character);
                    }
                } else {
                    if(char.IsUpper(character)) {
                        allCharacters[i] = char.ToLower(character);
                    }
                }
            }
            return new string(allCharacters);
        }
        return sourceStr;
    }
}
