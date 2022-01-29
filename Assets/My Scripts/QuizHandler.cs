using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizHandler : MonoBehaviour
{
    [Header("** Country Name **")]
    public string[] CountryName;
    public Text NameText;
    [Header("** Score **")]
    public Text ScoreText;
    public int TotalAttempts;
    public int UsedAttempt = 0;
    [Header("Game Lose")]
    public GameObject losePanel;
    // Start is called before the first frame update
    void Start()
    {
        losePanel.SetActive(false);

        NameText.color = Color.black;
        NameText.text = CountryName[Random.Range(0, CountryName.Length)]; 
    }

    public void Country(string Name)
    {
        if(TotalAttempts == 0)
        {
            NameText.gameObject.SetActive(false);
            losePanel.SetActive(true);

            return;
        }

        if(Name.ToUpper() == NameText.text.ToUpper())
        {
            NameText.color = Color.black;
            NameText.text = CountryName[Random.Range(0, CountryName.Length)];
        }
        else
        {
            UsedAttempt++;
            ScoreText.text = "Remaning Attempts = " + TotalAttempts-- ;
            NameText.color = Color.red;
        }
    }

    public void GameRestart()
    {
        losePanel.SetActive(false);
        NameText.gameObject.SetActive(true);

        ScoreText.text = "Remaning Attempts = " + 0;
        TotalAttempts = 10;
    }
}
