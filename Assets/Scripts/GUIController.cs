using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GUIController : MonoBehaviour
{
    public HealthBar healthBar;
    public GameObject gameOver;
    public Button goquit;
    public Button gotryAgain;
	public GameObject winMenu;
	public Button winquit;
	public Button wintryAgain;
	public TextMeshProUGUI score;
	public TextMeshProUGUI review;


	private void Start()
	{
		goquit.onClick.AddListener(() => { SceneManager.LoadScene("MainMenu"); Time.timeScale = 1; });
		gotryAgain.onClick.AddListener(() => { SceneManager.LoadScene("GameScene"); Time.timeScale = 1; });
		winquit.onClick.AddListener(() => { SceneManager.LoadScene("MainMenu"); Time.timeScale = 1; });
		wintryAgain.onClick.AddListener(() => { SceneManager.LoadScene("GameScene"); Time.timeScale = 1; });
	}

	public void GameOver()
	{
		gameOver.SetActive(true);
	}

	public void WinGame(int hp)
	{
		score.text = hp + "/5";
		switch (hp)
		{
			case 1:
				review.text = "What does this have to do with Game Dev?";
				break;
			case 2:
				review.text = "Missing the IMPACT it needs";
				break;
			case 3:
				review.text = "I like boats, but I don't get it";
				break;
			case 4:
				review.text = "I bought this out of pity";
				break;
			case 5:
				review.text = "Here's my money. Better luck next time";
				break;
		}
		winMenu.SetActive(true);
	}

	public void SetHP(int amount, int max)
	{
        healthBar.setMaxHealth(max);
        healthBar.SetHealth(amount);
	}
}
