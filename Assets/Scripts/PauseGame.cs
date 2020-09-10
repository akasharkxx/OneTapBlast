using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject pauseMenuCanvas;

    private void Start() 
    {
        pauseMenuCanvas.SetActive(false);
        pauseButton.onClick.AddListener(HandlePauseClicked);
    }

    private void Update()
    {
        if (GameManager.instance.IsGamePaused())
        {
            EnablePauseCanvas();
        }
    }

    private void HandlePauseClicked()
    {
        EnablePauseCanvas();
        GameManager.instance.TogglePause();
    }

    private void EnablePauseCanvas()
    {
        pauseMenuCanvas.SetActive(true);
    }
}
