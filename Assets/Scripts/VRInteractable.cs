using UnityEngine;
using UnityEngine.Events;

public class VRInteractable : MonoBehaviour
{
    public UnityEvent doWhat;
    public bool doNothing;
    
    public UnityEvent twiceWhat;

    public bool twiceFunction;

    private bool _doneOnce;

    public void Interact()
    {
        if (!doNothing) 
        {
            doWhat.Invoke();
            doNothing = true;
            
            if (twiceFunction)
            {
                _doneOnce = true;
            }
        }

        if (_doneOnce && !doNothing)
        {
            twiceWhat.Invoke();
            doNothing = true;
        }
    }

    public void ResetState()
    {
        doNothing = false;
    }
    
}
