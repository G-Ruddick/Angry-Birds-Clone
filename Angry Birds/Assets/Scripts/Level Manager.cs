using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour {
    public static bool completeLv1 = false;
    public static bool completeLv2 = false;

    public Button ButtonLv2;
    public Button ButtonLv3;

    void Start() {
        if (completeLv1) {
            ButtonLv2.interactable = true;
            ButtonLv2.GetComponentInChildren<TMP_Text>().text = "LV 2";
        }
        else {
            ButtonLv2.interactable = false;
            ButtonLv2.GetComponentInChildren<TMP_Text>().text = "X";
        }

        if (completeLv2) {
            ButtonLv3.interactable = true;
            ButtonLv3.GetComponentInChildren<TMP_Text>().text = "LV 3";
        }
        else {
            ButtonLv3.interactable = false;
            ButtonLv3.GetComponentInChildren<TMP_Text>().text = "X";
        }
    }

    
}
