using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DeathMenu : MonoBehaviour
{
    public Health playerHealth = null;
    public Score playerScore = null;
	public GameObject gameHUD = null;

    private TextMeshProUGUI endScore = null;
    // Start is called before the first frame update
    void Start() {
        gameObject.SetActive(false);
        playerHealth = GameObject.FindWithTag("Player").GetComponent<Health>();
        playerScore = GameObject.FindWithTag("Player").GetComponent<Score>();
		
        endScore = GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update() {
        playerHealth.OnDie += ToggleDeathMenu;
    }


    public void ToggleDeathMenu() {
	//there should be a better way to disable HUD when dead
        gameHUD.SetActive(false);
		gameObject.SetActive(true);
        endScore.SetText(playerScore.GetScore().ToString());
        Debug.Log("u r dead");
    }
}
