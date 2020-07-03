using TMPro;
using UnityEngine;

public class UIPlayerName : MonoBehaviour {

    private TextMeshProUGUI playerNameTextMesh = null;

    // Start is called before the first frame update
    void Start() {
        playerNameTextMesh = GetComponent<TextMeshProUGUI>();
        string playerNameValue = PlayerPrefs.GetString(Constants.PLAYER_NAME_PLAYER_PREFS);
        playerNameTextMesh.SetText(playerNameValue);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
