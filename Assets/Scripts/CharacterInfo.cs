using UnityEngine;
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

            foreach(Button bttn in playerButtonList) {
                if(bttn.GetComponent<Image>().raycastTarget == false) {
                    bttn.GetComponent<Image>().raycastTarget = true;
                }

                ChangeSprite();
            }

            foreach(Button bttn in friendButtonList) {
                if(bttn.GetComponent<Image>().raycastTarget == false) {
                    bttn.GetComponent<Image>().raycastTarget = true;
                }

                ChangeSprite();
            }
        }
    }

    public void OnButtonPress(Button button) {
        if(button.tag == "PlayerButton") {
            chosenPlayerCharacter = button.name;

            foreach(Button bttn in playerButtonList) {
                if(chosenPlayerCharacter != "") {
                    bttn.image.sprite = bttn.spriteState.disabledSprite;
                    bttn.image.CrossFadeColor(new Color(1.0f, 1.0f, 1.0f, 0.2f), 1.0f, false, true);
                }

                if(bttn.name == chosenPlayerCharacter) {
                    bttn.image.sprite = bttn.spriteState.pressedSprite;
                    bttn.image.CrossFadeColor(new Color(1.0f, 1.0f, 1.0f, 1.0f), 1.0f, false, true);
                }
            }

        } else if(button.tag == "FriendButton") {
            chosenFriendCharacter = button.name;

            foreach(Button bttn in friendButtonList) {
                if(chosenFriendCharacter != "") {
                    bttn.GetComponent<Image>().sprite = bttn.spriteState.disabledSprite;
                    bttn.image.CrossFadeColor(new Color(1.0f, 1.0f, 1.0f, 0.2f), 0.5f, false, true);
                }

                if(bttn.name == chosenFriendCharacter) {
                    bttn.GetComponent<Image>().sprite = bttn.spriteState.pressedSprite;
                    bttn.image.CrossFadeColor(new Color(1.0f, 1.0f, 1.0f, 1.0f), 0.5f, false, true);
                }
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

    static string TidyCase(string sourceStr) {
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

    void ChangeSprite() {
        switch(chosenPlayerCharacter) {
            case "PJohn":
                GameObject.Find("FJohn").GetComponent<Image>().CrossFadeColor(new Color(1.0f, 1.0f, 1.0f, 0.2f), 0.5f, false, true);
                GameObject.Find("FJohn").GetComponent<Image>().raycastTarget = false;
                break;
            case "PSherlock":
                GameObject.Find("FSherlock").GetComponent<Image>().CrossFadeColor(new Color(1.0f, 1.0f, 1.0f, 0.2f), 0.5f, false, true);
                GameObject.Find("FSherlock").GetComponent<Image>().raycastTarget = false;
                break;
            case "PJoanne":
                GameObject.Find("FJoanne").GetComponent<Image>().CrossFadeColor(new Color(1.0f, 1.0f, 1.0f, 0.2f), 0.5f, false, true);
                GameObject.Find("FJoanne").GetComponent<Image>().raycastTarget = false;
                break;
            case "PSherley":
                GameObject.Find("FSherley").GetComponent<Image>().CrossFadeColor(new Color(1.0f, 1.0f, 1.0f, 0.2f), 0.5f, false, true);
                GameObject.Find("FSherley").GetComponent<Image>().raycastTarget = false;
                break;
        }

        switch(chosenFriendCharacter) {
            case "FJohn":
                GameObject.Find("PJohn").GetComponent<Image>().CrossFadeColor(new Color(1.0f, 1.0f, 1.0f, 0.2f), 0.5f, false, true);
                GameObject.Find("PJohn").GetComponent<Image>().raycastTarget = false;
                break;
            case "FSherlock":
                GameObject.Find("PSherlock").GetComponent<Image>().CrossFadeColor(new Color(1.0f, 1.0f, 1.0f, 0.2f), 0.5f, false, true);
                GameObject.Find("PSherlock").GetComponent<Image>().raycastTarget = false;
                break;
            case "FJoanne":
                GameObject.Find("PJoanne").GetComponent<Image>().CrossFadeColor(new Color(1.0f, 1.0f, 1.0f, 0.2f), 0.5f, false, true);
                GameObject.Find("PJoanne").GetComponent<Image>().raycastTarget = false;
                break;
            case "FSherley":
                GameObject.Find("PSherley").GetComponent<Image>().CrossFadeColor(new Color(1.0f, 1.0f, 1.0f, 0.2f), 0.5f, false, true);
                GameObject.Find("PSherley").GetComponent<Image>().raycastTarget = false;
                break;
        }
    }
}
