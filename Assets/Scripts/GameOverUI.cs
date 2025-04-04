using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Button quitButton; // Assign in Inspector

    void Start()
    {
        if (quitButton != null)
        {
            quitButton.onClick.AddListener(QuitGame);
        }
    }

    void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in Editor
        #else
                    Application.Quit(); // Quit the application in a build
        #endif
    }
}