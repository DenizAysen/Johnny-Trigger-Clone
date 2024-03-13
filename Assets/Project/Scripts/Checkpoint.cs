using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private SpriteRenderer gradient;

    public static Action<Checkpoint> onInteracted;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Interact()
    {
        gradient.color = Color.green;

        onInteracted?.Invoke(this);
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
