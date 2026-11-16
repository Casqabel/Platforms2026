using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] Image health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = GameManager.coins+"";
        health.fillAmount = GameManager.health / GameManager.maxHealth;
    }
}
