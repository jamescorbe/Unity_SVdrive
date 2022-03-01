using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour
{
	public Button yourButton;

	void Start()
	{
		yourButton = GetComponent<Button>();
		yourButton.onClick.AddListener(playBobbyPlatformGame);
	}

	void playBobbyPlatformGame()
	{
		Debug.Log("You have clicked the play button!");
		SceneManager.LoadSceneAsync("Scenes/Level 1");
	}
}

