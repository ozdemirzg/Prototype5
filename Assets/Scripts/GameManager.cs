using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //textler için
using UnityEngine.SceneManagement; // Button ile sahneyi yeniden yüklemek için 
using UnityEngine.UI; // button için ekledik.
public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    //
    private float spawnRate = 1.0f;
    //Score için
    private int score;
    public TextMeshProUGUI scoreText;
    //
    public TextMeshProUGUI gameOverText;
    // for stop
    public bool isGameActive;
    //Button ý inspectorda eklemeyi unutma
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
            //Eðer buraya eklersek updatescore ý her bir target çýkardýðýnda score ý 5 arttýrýr.
            // UpdateScore(5);
        }
    }
    //Score ý diðer scriptte kullanmak için public yaptýk
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        //checkbox ta kaldýrdýðýmýz için burada aktif ediyoruz oyunda.  
        gameOverText.gameObject.SetActive(true);
        //Restart ý active etmek için
        restartButton.gameObject.SetActive(true);

        isGameActive = false;
    }
    //bu methodu buttonda game manager ý ekleyip daha sonra bu methodu seçtik.
    public void RestartGame()
    {
        //SceneManager SceneManagement ile geldi.
        //Direkt sahne adýnýda yazabilirdin parantez içine.ikisi de oluyor.bununla þu an aktif olaný geri yükle dedin
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int difficulty)
    {//Bunun içini start ýn içinden aldýk.

        //isGameActive en üstte olmalý yoksa diðerleri çalýþmaz.
        isGameActive = true;
        score = 0;
        //
        //spawnRate = spawnRate / difficulty;
        spawnRate /= difficulty;                 //üstteki ile yaný

        StartCoroutine(SpawnTarget());
        UpdateScore(0);//Baþlangýçta sýfýr yazdýrýr.
        
        //oyun baþladýðýnda yazýlar silinsin diye,
        titleScreen.gameObject.SetActive(false);
    }
}
