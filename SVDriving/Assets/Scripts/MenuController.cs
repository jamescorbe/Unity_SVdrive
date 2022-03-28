using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

	public void createAccount()
    {
		SceneManager.LoadSceneAsync("Scenes/CreateAccount");
	}
	public void Login()
	{
		SceneManager.LoadSceneAsync("Scenes/Login");
	}
	public void GameMode()
	{
		SceneManager.LoadSceneAsync("Scenes/Selectmode");
	}
	public void Singleplayer()
    {
		SceneManager.LoadSceneAsync("Scenes/Level 1");
	}
	public void AImultiplayer()
    {
		SceneManager.LoadSceneAsync("Scenes/Level2 AI");
	}

}

