using UnityEngine;
using UnityEngine.Serialization;

public enum Direction
{
    X,
    Y,
    Z,
    XY,
    YZ,
    XZ,
    None
}

public class MoveObject : MonoBehaviour
{
    public Direction direction = Direction.X;
    public float speed = 5f;
    public float duration;
    
    public bool hasDestruct;
    
    private Rigidbody _rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
        if (hasDestruct)
        {
            Destroy(gameObject, duration);
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (direction)
        {
            case Direction.X:
                _rb.AddForce(speed, 0f, 0f);
                break;
            
            case Direction.Y:
                _rb.AddForce(0f, speed, 0f);
                break;
            
            case Direction.Z:
                _rb.AddForce(0f, 0f, speed);
                break;
            
            case Direction.XY:
                _rb.AddForce(speed, speed, 0f);
                break;
            
            case Direction.YZ:
                _rb.AddForce(0f, speed, speed);
                break;
            
            case Direction.XZ:
                _rb.AddForce(speed, 0f, speed);
                break;
            
            case Direction.None:
            default:
                break;
        }
    }
}
