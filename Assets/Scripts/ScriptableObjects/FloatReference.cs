using System;

[Serializable]
public class FloatReference
{
    public bool UseConstanst = true;
    public float ConstantValue;
    public FloatVariable Variable;

    public FloatReference() { }

    public FloatReference(float value)
    {
        UseConstanst = true;
        ConstantValue = value;
    }

    public float Value
    {
        get => UseConstanst ? ConstantValue : Variable.Value;
    }

    public static implicit operator float(FloatReference reference)
    {
        return reference.Value;
    }
}
