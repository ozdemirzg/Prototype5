using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //textler i�in
using UnityEngine.SceneManagement; // Button ile sahneyi yeniden y�klemek i�in 
using UnityEngine.UI; // button i�in ekledik.
public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    //
    private float spawnRate = 1.0f;
    //Score i�in
    private int score;
    public TextMeshProUGUI scoreText;
    //
    public TextMeshProUGUI gameOverText;
    // for stop
    public bool isGameActive;
    //Button � inspectorda eklemeyi unutma
    public Button restartButton;
    //TitleScreen
    public GameObject titleScreen;

    void Start()
    {
       
        
    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            //E�er buraya eklersek updatescore � her bir target ��kard���nda score � 5 artt�r�r.
            // UpdateScore(5);
        }
    }
    //Score � di�er scriptte kullanmak i�in public yapt�k
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        //checkbox ta kald�rd���m�z i�in burada aktif ediyoruz oyunda.  
        gameOverText.gameObject.SetActive(true);
        //Restart � active etmek i�in
        restartButton.gameObject.SetActive(true);

        isGameActive = false;
    }
    //bu methodu buttonda game manager � ekleyip daha sonra bu methodu se�tik.
    public void RestartGame()
    {
        //SceneManager SceneManagement ile geldi.
        //Direkt sahne ad�n�da yazabilirdin parantez i�ine.ikisi de oluyor.bununla �u an aktif olan� geri y�kle dedin
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int difficulty)
    {//Bunun i�ini start �n i�inden ald�k.

        //isGameActive en �stte olmal� yoksa di�erleri �al��maz.
        isGameActive = true;
        score = 0;
        //
        //spawnRate = spawnRate / difficulty;
        spawnRate /= difficulty;                 //�stteki ile yan�

        StartCoroutine(SpawnTarget());
        UpdateScore(0);//Ba�lang��ta s�f�r yazd�r�r.
        
        //oyun ba�lad���nda yaz�lar silinsin diye,
        titleScreen.gameObject.SetActive(false);
    }
}
