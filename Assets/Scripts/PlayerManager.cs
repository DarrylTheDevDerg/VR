using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int points;
    public TextMeshProUGUI display;

    public string displayText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        display.text = $"{displayText}: {points}";
    }

    public void PointManip(int amt)
    {
        points += amt;
    }
}
