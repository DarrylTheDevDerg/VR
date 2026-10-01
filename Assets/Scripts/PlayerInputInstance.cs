using UnityEngine;

// This thing solely exists because we need debug functions, otherwise, we will have a buggy mess.
public class PlayerInputInstance : MonoBehaviour
{
    public static PlayerInputInstance Instance;
    public PlayerControls Input;

    void Awake()
    {
        if (Input == null) Input = new PlayerControls();
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
    }

    void OnEnable()
    {
        Input.Enable();
    }

    void OnDisable()
    {
        Input.Disable();
    }
}
