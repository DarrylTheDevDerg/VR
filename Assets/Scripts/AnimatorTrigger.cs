using System;
using UnityEngine;

[Serializable]
public enum ToDo
{
    Set,
    Reset
}

public class AnimatorTrigger : MonoBehaviour
{
    public string[] triggerName;
    public ToDo what;

    private Animator _a;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _a = GetComponent<Animator>();
    }

    public void Trigger()
    {
        switch (what)
        {
            case ToDo.Set:
                foreach (var item in triggerName)
                {
                    _a.SetTrigger(item);
                }
                break;
            
            case ToDo.Reset:
                foreach (var item in triggerName)
                {
                    _a.ResetTrigger(item);
                }
                break;
        }
    }

    public void TriggerManual(string triggerName)
    {
        _a.SetTrigger(triggerName);
    }
}
