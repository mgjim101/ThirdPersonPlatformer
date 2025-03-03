using UnityEngine;

using TMPro;
public class CoinDetection : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 void OnTriggerEnter(Collider other) {
        
        if (other.tag == "Coin") {

            score++;
            text.text = "Score: " + score;
            Destroy(other.gameObject);

        }
    }
}
