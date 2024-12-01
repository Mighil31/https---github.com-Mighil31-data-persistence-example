using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public TMP_InputField playerNameInputField;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartGame() {
        if (!string.IsNullOrWhiteSpace(playerNameInputField.text)) {
            Persistance.Instance.playerName = playerNameInputField.text;
            SceneManager.LoadScene(0);
        }
    }

}
