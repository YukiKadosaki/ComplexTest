using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCreator : MonoBehaviour
{
    public GameObject circle;
    private GameObject circleInstance;
    private ComplexNumber c1;
    private ComplexNumber c2;

    void Start()
    {
        c1 = new ComplexNumber(0, 5);
        float direction = 180 * Mathf.Deg2Rad;
        c2 = new ComplexNumber(Mathf.Cos(direction), Mathf.Sin(direction));
        circleInstance = Instantiate(circle);

        StartCoroutine(Animation());
    }

    // Update is called once per frame
    void Update() {

        
    }

    private void Log(string name,  ComplexNumber c)
    {
        Debug.Log(name + ":" + c.m_RealPart + "+" + c.m_ImaginaryPart + "i");
    }

    private IEnumerator Animation() {
        float time = 0;
        float direction;

        while(time < 15)
        {
            time += Time.deltaTime;

            if (time < 3)
            {
                direction = 180 * Mathf.Deg2Rad * Time.deltaTime;
                c2 = new ComplexNumber(Mathf.Cos(direction), Mathf.Sin(direction)) * 0.99f;
            }
            else if(time < 4)
            {
                c2 = new ComplexNumber(1.02f, 0);
            }
            else if(time < 7)
            {
                c2 = new ComplexNumber(1f, -0.01f);
            }
            else if (time < 10)
            {
                c2 = new ComplexNumber(0.99f, 0);
            }
            else
            {
                c2 = new ComplexNumber(0, 0);
            }

            c1 *= c2;
            circleInstance.transform.position = ComplexNumber.ComplexToVector(c1);
            yield return null;
        }

        yield return null;
    }
}
