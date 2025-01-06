
using System;
using System.Collections;
using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    public GameObject[] wallOfGroupsPrefab;
    public Transform wallOfGroupSpawnPos;
    public int fallenBrickAmounr, fallenBrickNeeded;


    public UIControl uIControl;
    public event Action setAmmo;
    public static int score;    
    public static int bestScore = 0;

   


    private CannonController cannonController;
    private FallenWallDetector fallenWallDetector;


    private void Awake() {
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }

        LoadScore();
 
    }

    public void StartGame(){
        StartCoroutine(StartGamePlay());
    }

    private IEnumerator StartGamePlay(){
        SceneManager.LoadScene(1);
        yield return new WaitForSeconds(2f);
        cannonController = FindObjectOfType<CannonController>();
        uIControl = FindObjectOfType<UIControl>();
        fallenWallDetector = FindObjectOfType<FallenWallDetector>();
        wallOfGroupSpawnPos = GameObject.FindGameObjectWithTag("Respawn").transform;
        uIControl.Alert.text = "";
        uIControl.loseScreen.SetActive(false);
        uIControl.menuScene.SetActive(false);
        yield return new WaitForSeconds(1f);
        StartSpawn();
    }

     private IEnumerator ReStartGamePlay(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        yield return new WaitForSeconds(1f);
        cannonController = FindObjectOfType<CannonController>();
        uIControl = FindObjectOfType<UIControl>();
        fallenWallDetector = FindObjectOfType<FallenWallDetector>();
        wallOfGroupSpawnPos = GameObject.FindGameObjectWithTag("Respawn").transform;
        uIControl.Alert.text = "";
        uIControl.loseScreen.SetActive(false);
        uIControl.menuScene.SetActive(false);
        yield return new WaitForSeconds(1f);
        StartSpawn();
    }

    private void StartSpawn() {
        SpawnWallGroup(UnityEngine.Random.Range(0, wallOfGroupsPrefab.Length));
        uIControl.Score.text = "score: " + score;
    }

    private void Update() {
  
        if (uIControl != null && Input.GetKeyDown(KeyCode.Escape))
        {
            uIControl.ToggleMenu();
        }
        
    }

    void SpawnWallGroup(int wallIndex){
        Instantiate(wallOfGroupsPrefab[wallIndex], wallOfGroupSpawnPos.position, Quaternion.identity);
    }

    public void SetAmmo(){
        setAmmo?.Invoke();
    }


    public void BrickFall(){
        fallenBrickAmounr++;
        if(fallenBrickAmounr >= fallenBrickNeeded){
            Debug.Log("All bricks have fallen");
            int ammo = cannonController.GetComponent<Ammo>().currentAmmo;
            score = fallenBrickNeeded * ammo;
            uIControl.Score.text = "score: " + score;
            ShowWin();
            
        }
    }

    private void AutoRestart(){
        bestScore += score;
        int lastScore = PlayerPrefs.GetInt("BestScore");
        if(bestScore > lastScore){
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
        StartCoroutine(ReStartGamePlay());
    }


    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        StartSpawn();
    }

    public void addScore (int Score){
        score += Score;
    }

    public void SetBestScore (int curentScore){
        bestScore = curentScore;
    }

    public void ShowWin(){
        StartCoroutine(ShowTextWin(uIControl.Alert, "All Brick Has Fallen", 2f));
    }

    public void CheckLose()
    {
        fallenWallDetector.noAmmo = true;
    }

  

    public IEnumerator DoDelayCheck(){
        print("delay check");
        yield return new WaitForSeconds(4f);
        if (fallenBrickAmounr < fallenBrickNeeded){
            ShowLose();
        }
    }

    public void ShowLose(){

        int lastScore = PlayerPrefs.GetInt("BestScore");
        if(bestScore > lastScore){
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
        StartCoroutine(ShowTextLose(uIControl.Alert, "You Lose", 2f));
    }

    public IEnumerator ShowTextWin(TextMeshProUGUI text, string message, float delay)
    {
        text.text = message;
        yield return new WaitForSeconds(delay);
        text.text = "";
        yield return new WaitForSeconds(delay);
        AutoRestart();
    }
    public IEnumerator ShowTextLose(TextMeshProUGUI text, string message, float delay)
    {
        text.text = message;
        yield return new WaitForSeconds(delay);
        text.text = "";
        yield return new WaitForSeconds(delay);
        uIControl.loseScreen.SetActive(true);
        yield return new WaitForSeconds(1f);
        uIControl.BestScore.text = "Best : " + bestScore;
        score = 0;
    }


    public void Exit(){
        PlayerPrefs.SetInt("BestScore", bestScore);
        Application.Quit();
    }

    public void SaveScore(){
        if (score > bestScore)
        {
            bestScore = score;
        }
        PlayerPrefs.SetInt("BestScore", bestScore);
    }

    public void LoadScore(){
        bestScore = PlayerPrefs.GetInt("BestScore");
    }

    

}
