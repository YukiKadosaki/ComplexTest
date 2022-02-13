using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexNumber : MonoBehaviour
{
    public string m_Name;
    public float m_RealPart;
    public float m_ImaginaryPart;

    //コンストラクタ
    public ComplexNumber(float re, float im)
    {
        m_RealPart = re;
        m_ImaginaryPart = im;
    }

    public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.m_RealPart + b.m_RealPart, a.m_ImaginaryPart + b.m_ImaginaryPart);
    }
    public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.m_RealPart * b.m_RealPart - a.m_ImaginaryPart * b.m_ImaginaryPart
            , a.m_ImaginaryPart * b.m_RealPart + a.m_RealPart * b.m_ImaginaryPart);
    }
    public static ComplexNumber operator *(ComplexNumber a, float b)
    {
        return new ComplexNumber(a.m_RealPart * b, a.m_ImaginaryPart * b);
    }

    public static Vector3 ComplexToVector(ComplexNumber c)
    {
        return new Vector3(c.m_RealPart, c.m_ImaginaryPart, 0);
    }

}
