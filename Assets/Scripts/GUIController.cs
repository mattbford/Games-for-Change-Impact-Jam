using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUIController : MonoBehaviour
{
    public TextMeshProUGUI hp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHP(int amount, int max)
	{
        hp.text = amount + "/" + max;
	}
}
