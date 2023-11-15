using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthAndScoreController : MonoBehaviour
{
    [Header("Game parametrs")]
    [SerializeField] private int health;
    [SerializeField] private int score;

    [Header("Game objects")]
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private Text countHealth;
    [SerializeField] private Text scoreGT;
    [SerializeField] private Text record;
    [SerializeField] private Text currentRecord;
    
    private void Start()
    {
        countHealth.text = health.ToString();
        PlayerPrefs.GetInt("Score");
    }

    public void AddPoints(int points)
    {
        int score = int.Parse(scoreGT.text);
        score += points;
        scoreGT.text = score.ToString();

    }

    public void ApplyDamage(int damage)
    {
        ChangeLife(damage);

        if (health<= 0) {
            Die();
        }
    
    }

    public void ChangeLife(int index)
    {
        health += index;
        countHealth.text = health.ToString();
    }

    private void Die()
    {
        SaveMaxRecord();
        ShowRecord();
        deathScreen.SetActive(true);
        Time.timeScale = 0;
    }

    private void SaveMaxRecord()
    {
        if (int.Parse(scoreGT.text) > PlayerPrefs.GetInt("Score")) {
            PlayerPrefs.SetInt("Score", int.Parse(scoreGT.text));
        }
    }

    private void ShowRecord()
    {
        record.text = PlayerPrefs.GetInt("Score").ToString();
        currentRecord.text = scoreGT.text;
    }
}
