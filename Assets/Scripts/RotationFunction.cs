using UnityEngine;

public enum Axis
{
    X,
    Y,
    Z
}

// THIS THING WORKS! WOOOOOOOOOO!
public class RotationFunction : MonoBehaviour
{
    public bool useOtherCenter;
    [Header("Only use when Use Other Center bool is active!")]
    public Transform center;
    
    public Axis rotationAxis = Axis.Z;
    public bool reverseRotation;

    public float speed;

    // Update is called once per frame
    void Update()
    {
        Banana___Rotate(useOtherCenter);
    }

    // Suddenly, these functions became 100 times more useful! Thanks to those who brought the "?" expression to existence. I love u <3
    void Banana___Rotate(bool decenter)
    {
        switch (rotationAxis)
        {
            case Axis.X:
                transform.RotateAround(decenter ? center.position : transform.position, reverseRotation ? Vector3.right : Vector3.left,
                    speed * Time.deltaTime);
                break;
            
            case Axis.Y:
                transform.RotateAround(decenter ? center.position : transform.position, reverseRotation ? Vector3.up : Vector3.down,
                    speed * Time.deltaTime);
                break;
            
            case Axis.Z:
                transform.RotateAround(decenter ? center.position : transform.position, reverseRotation ? Vector3.forward : Vector3.back,
                    speed * Time.deltaTime);
                break;
        }
    }
}
