using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button ResumeButton;
    [SerializeField] private Button QuitButton;
    [SerializeField] private GameObject pauseMenuCanvas;

    private void Start() {
        ResumeButton.onClick.AddListener(HandleResumeClicked);
        QuitButton.onClick.AddListener(HandleQuitClicked);

        DisableCanvas();
    }

    private void Update()
    {
        if (!GameManager.instance.IsGamePaused())
        {
            DisableCanvas();
        }
    }

    void HandleResumeClicked()
    {
        GameManager.instance.TogglePause();
        DisableCanvas();
    }

    void HandleQuitClicked(){
        GameManager.instance.QuitGame();
    }

    private void DisableCanvas()
    {
        pauseMenuCanvas.SetActive(false);
    }
}
