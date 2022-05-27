using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Float variable", menuName = "SO/Variables/Float")]
public class FloatVariable : ScriptableObject
{
#if UNITY_EDITOR
    public string Description;
#endif
    public float Value;

    public void Increment(float increment) {
        Value += increment;
    }
}
