using UnityEngine;
using UnityEngine.Events;

public class UponContactWithTag : MonoBehaviour
{
    public string tagName;
    public UnityEvent onContact;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagName))
        {
            onContact.Invoke();
            Destroy(other.gameObject);
        }
    }
}
