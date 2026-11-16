using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{

    int coins;
    [SerializeField] TextMeshProUGUI textCoins;
    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
        textCoins.text=coins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin")) {
            Destroy(collision.gameObject);
            coins++;
            textCoins.text = coins.ToString();

            GameManager.Instance.SumarMoneda(1);
        }
    }
}
