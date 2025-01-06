using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBestScore : MonoBehaviour
{

    public TMPro.TextMeshProUGUI bestScoreText;

    private void Awake() {
        bestScoreText = GetComponent<TMPro.TextMeshProUGUI>();
    }
    private void Update() {
        bestScoreText.text = "Best Score: " + GameManager.bestScore;
    }
}
