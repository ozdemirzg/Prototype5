using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    //oyunuhn zorluk derecesi için yazdýk.
    public int difficulty;
    void Start()
    {
        button = GetComponent<Button>();
        gameManager=GameObject.Find("Game Manager").GetComponent<GameManager>();
        //event .bununla hangisini clicklediðini buluyor.
        button.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty() 
    {
        //Test için
        Debug.Log(button.gameObject.name + "was clicked!");
        gameManager.StartGame(difficulty); //parametre zorluk için eklendi.
    }
}
