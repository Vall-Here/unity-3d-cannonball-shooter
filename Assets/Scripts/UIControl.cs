using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public TextMeshProUGUI Ammo;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Alert;
    public TextMeshProUGUI BestScore;

    public GameObject loseScreen;
    public GameObject menuScene;

    public Button restartButton;
    public Button exitButton;




    public void RestartGame(){
        GameManager.Instance.StartGame();
    }

    public void exitGame(){
        StopAllCoroutines();
        SceneManager.LoadScene(0);
    }

    public void SaveExit(){
        StopAllCoroutines();
        GameManager.Instance.SaveScore();
        GameManager.Instance.fallenBrickAmounr = 0 ; GameManager.Instance.fallenBrickNeeded = 0;
        SceneManager.LoadScene(0);
    }

    public void ToggleMenu(){
        menuScene.SetActive(!menuScene.activeSelf);
        Time.timeScale = menuScene.activeSelf ? 0 : 1;
    }

}
