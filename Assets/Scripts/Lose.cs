using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Lose : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private Text countHealth;
    [SerializeField] private Text scoreGT;
    [SerializeField] private Text record;
    [SerializeField] private Text currentRecord;
    [SerializeField] private GameObject explosionEffect;
    public int _health;
    
    private void Start()
    {
        _health=int.Parse(countHealth.text);
        PlayerPrefs.GetInt("Score");
    }
    
    private void ApplyDamage()
    {
        if (_health == 1) {
            TakeLife();
            Die();
        }
        else {
            TakeLife();
        }
    }

    private void TakeLife() 
    {
        _health--;
        countHealth.text = _health.ToString();
    }

    private void Die() 
    {
        SaveMaxRecord();
        ShowRecord();
        deathScreen.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collideWith = collision.gameObject;

        if (collideWith.tag == "Bomb") { 
            Instantiate(explosionEffect, collideWith.transform.position, Quaternion.identity);
            Destroy(collideWith);
            ApplyDamage();
           
        }
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
