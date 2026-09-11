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
    public bool fuckYourGravity;
    
    private Rigidbody _rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fuckYourGravity)
        {
            _rb.useGravity = false;
        }
        
        switch (direction)
        {
            case Direction.X:
                _rb.AddForce(speed * Time.deltaTime, 0f, 0f);
                break;
            
            case Direction.Y:
                _rb.AddForce(0f, speed * Time.deltaTime, 0f);
                break;
            
            case Direction.Z:
                _rb.AddForce(0f, 0f, speed * Time.deltaTime);
                break;
            
            case Direction.XY:
                _rb.AddForce(speed * Time.deltaTime, speed * Time.deltaTime, 0f);
                break;
            
            case Direction.YZ:
                _rb.AddForce(0f, speed * Time.deltaTime, speed * Time.deltaTime);
                break;
            
            case Direction.XZ:
                _rb.AddForce(speed * Time.deltaTime, 0f, speed * Time.deltaTime);
                break;
            
            case Direction.None:
            default:
                break;
        }
    }
}
