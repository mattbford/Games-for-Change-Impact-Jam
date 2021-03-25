using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUIController : MonoBehaviour
{
    public HealthBar healthBar;

    public void SetHP(int amount, int max)
	{
        healthBar.setMaxHealth(max);
        healthBar.SetHealth(amount);
	}
}
