using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    //oyunuhn zorluk derecesi i�in yazd�k.
    public int difficulty;
    void Start()
    {
        button = GetComponent<Button>();
        gameManager=GameObject.Find("Game Manager").GetComponent<GameManager>();
        //event .bununla hangisini clickledi�ini buluyor.
        button.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty() 
    {
        //Test i�in
        Debug.Log(button.gameObject.name + "was clicked!");
        gameManager.StartGame(difficulty); //parametre zorluk i�in eklendi.
    }
}
