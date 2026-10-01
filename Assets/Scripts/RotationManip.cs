using UnityEngine;
using System.Collections.Generic;

public class RotationManip : MonoBehaviour
{
    public GameObject[] objectsWithRotationScript;
    public float speedMultiplier;

    public bool shouldModifyDecenter;
    public bool debug;

    private List<float> _origSpeeds = new List<float>();

    private void Start()
    {
        if (debug)
        {
            foreach (GameObject obj in objectsWithRotationScript)
            {
                foreach (RotationFunction script in obj.GetComponentsInChildren<RotationFunction>())
                {
                    if (shouldModifyDecenter && script.useOtherCenter)
                    {
                        _origSpeeds.Add(script.speed);
                        break;
                    }
                
                    _origSpeeds.Add(script.speed);
                }
            }
        }
    }
    
    private void Update()
    {
        if (debug)
        {
            if (PlayerInputInstance.Instance.Input.Player.Attack.WasPressedThisDynamicUpdate()) ModifySpeed(false);
            if (PlayerInputInstance.Instance.Input.Debug.Function1.WasPressedThisDynamicUpdate()) ModifySpeed(true);
        }
    }

    private void ModifySpeed(bool reset)
    {
        int i = 0;
        
        foreach (GameObject obj in objectsWithRotationScript)
        {
            foreach (RotationFunction script in obj.GetComponentsInChildren<RotationFunction>())
            {
                if (!reset)
                {
                    if (script.useOtherCenter && shouldModifyDecenter)
                    {
                        script.speed *= speedMultiplier;
                        break;
                    }
                
                    script.speed *= speedMultiplier;
                }
                else
                {
                    if (script.useOtherCenter && shouldModifyDecenter)
                    {
                        script.speed = _origSpeeds[i];
                        break;
                    }
                
                    script.speed = _origSpeeds[i];
                }

                i++;
            }
        }
    }
}
