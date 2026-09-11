using System;
using UnityEngine;
using Random = UnityEngine.Random;

public enum BaseColor
{
    Red,
    Blue,
    None
}

public class ColorDiscrimination : MonoBehaviour
{
    public Material red;
    public Material blue;

    public BaseColor color;
    
    private MeshRenderer _m;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (color)
        {
            case BaseColor.Red:
                _m.material = red;
                break;
            
            case BaseColor.Blue:
                _m.material = blue;
                break;
        }
    }

    public void SetColor()
    {
        color = Random.Range(0, 2) == 0 ? BaseColor.Red : BaseColor.Blue;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ColorDiscrimination>().color == color)
        {
            Destroy(other.gameObject);
        }
    }
}
