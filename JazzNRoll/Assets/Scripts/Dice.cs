using System; 
using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public byte[] valueOnFaces = new byte[6];
    private Rigidbody rb => GetComponent<Rigidbody>();
    private Vector3 baseVector = Vector3.forward;
    const float fault = 0.3f;

    private static float _minForce = 10f;
    private static float _maxForce = 20f;
    private static float _minTorqueFroce = 10f;
    private static float _maxTorqueFroce = 20f;

    public static void SetMinMax(float minForce, float maxForce, float minTorqueFroce, float maxTorqueFroce)
    {
        _minForce = minForce;
        _maxForce = maxForce;
        _minTorqueFroce = minTorqueFroce;
        _maxTorqueFroce = maxTorqueFroce;
    }

    
    public IEnumerator DieRoll(Action<byte> callback)
    {
        Physics();
        yield return new WaitForSeconds(0.5f);
        int framesStill = 0;
        while (framesStill < 10)
        {
            if (rb.linearVelocity == Vector3.zero || rb.angularVelocity == Vector3.zero)
                framesStill++; 
            else
                framesStill = 0;
            yield return new WaitForFixedUpdate();
        }


        callback?.Invoke(GetCurrentFace()); 
    }

    private void Physics()
    {
        float movingForce = UnityEngine.Random.Range(_minForce, _maxForce);
        float torqueForce = UnityEngine.Random.Range(_minTorqueFroce, _maxTorqueFroce);
        Vector3 forceAxis = new Vector3(0, UnityEngine.Random.Range(0.5f, 1.2f), UnityEngine.Random.Range(0.1f, 0.6f)) + baseVector;
        Vector3 rotationAxis = UnityEngine.Random.rotation.eulerAngles;
        rb.AddTorque(rotationAxis * torqueForce, ForceMode.Impulse);
        rb.AddForce(forceAxis * movingForce, ForceMode.Impulse);
    }


    private byte GetCurrentFace()
    {
        Vector3[] localDirections = new Vector3[]
        {
            transform.up ,     //  грань 1
            transform.forward,  // грань 2
            transform.right,    //  грань 3
            -transform.right ,     //  грань 4
            -transform.forward,     //  грань 5
            -transform.up    //  грань 6
        };
        float max = -10;
        byte maxIndex = 0;
        for (byte i = 0; i < localDirections.Length; i++)
            if (Vector3.Dot(localDirections[i], Vector3.up) > max)
            {
                max = Vector3.Dot(localDirections[i], Vector3.up);
                maxIndex = i;
            }
        return valueOnFaces[maxIndex];
    }


}
