using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Button startGameButton;

    private void Start() 
    {
        startGameButton.onClick.AddListener(HandleStartClicked);
    }

    private void HandleStartClicked()
    {
        GameManager.instance.LoadNextLevel();
    }
}
