using System;
using UnityEngine;
using System.Collections.Generic;

public enum DataType
{
    Float,
    Int,
    Bool,
    Trigger
}

[Serializable]
public class AnimatorParameter
{
    [Header("Please define the type and the name before using, otherwise, it may bring unexpected or no results.")]
    public DataType Type = DataType.Int;
    public string Name;
    
    [Header("Only use it if you chose the Int type in the Type section!")]
    public int IntegerValue;
    
    [Header("Only use it if you chose the Bool type in the Type section!")]
    public bool BoolValue;
    
    [Header("Only use it if you chose the Float type in the Type section!")]
    public float FloatValue;

    [Header("There's no setting for Trigger because it's automatic; henceforth, unneeded.")]
    private float _hidden;
}

// I hate this project so much.
[RequireComponent(typeof(Animator))]
public class AnimatorManipulator : MonoBehaviour
{
    [SerializeField] public List<AnimatorParameter> parameters = new List<AnimatorParameter>();
    
    public bool shouldDoUpdate, isTimed, doOnStart;
    
    [Header("Only use this if the IsTimed bool is active, otherwise, nothing happens.")]
    public float timedThreshold;

    private float _time;
    private Animator _a;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _a = GetComponent<Animator>();
        if (doOnStart) ManipulateParams();
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldDoUpdate)
        {
            if (isTimed)
            {
                _time += Time.deltaTime;

                if (_time > timedThreshold)
                {
                    _time = 0;
                    ManipulateParams();
                }
            }
            else
            {
                ManipulateParams();
            }
        }
    }

    private void ManipulateParams()
    {
        foreach (AnimatorParameter parameter in parameters)
        {
            if (parameter.Type == DataType.Bool)
            {
                _a.SetBool(parameter.Name, parameter.BoolValue);
            }
            else if (parameter.Type == DataType.Float)
            {
                _a.SetFloat(parameter.Name, parameter.FloatValue);
            }
            else if (parameter.Type == DataType.Int)
            {
                _a.SetInteger(parameter.Name, parameter.IntegerValue);
            }
            else if (parameter.Type == DataType.Trigger)
            {
                _a.SetTrigger(parameter.Name);
            }
        }
    }

    public void IntChange(string parameterName)
    {
        int p = _a.GetInteger(parameterName);
        
        _a.SetInteger(parameterName, p + 1);
    }

    public void ResetInt(string parameterName)
    {
        _a.SetInteger(parameterName, 0);
    }
}
