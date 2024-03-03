using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class CharacterIK : MonoBehaviour
{
    [SerializeField] private RigBuilder rigBuilder;
    [SerializeField] private TwoBoneIKConstraint[] twoBoneIKConstraints;
    [SerializeField] private MultiAimConstraint[] multiAimConstraints;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ConfigureIK(Transform ikTarget)
    {
        rigBuilder.enabled = true;

        foreach (TwoBoneIKConstraint ik in twoBoneIKConstraints) 
        {
            ik.data.target = ikTarget;        
        }
        foreach(MultiAimConstraint ik in multiAimConstraints)
        {
            WeightedTransformArray weightedTransforms = new WeightedTransformArray();
            weightedTransforms.Add(new WeightedTransform(ikTarget, 1));
            ik.data.sourceObjects = weightedTransforms;
        }

        rigBuilder.Build();
    }
    public void DisableIK()
    {
        rigBuilder.enabled = false;
    }
}
