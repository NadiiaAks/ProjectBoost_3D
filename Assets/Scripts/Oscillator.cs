using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 2f;
    Vector3 startingPos;
    float movementFactor;

    void Start()
    {
        startingPos = transform.position;
    }


    void Update()
    {
        MoveObstacle();
    }

    private void MoveObstacle()
    {
        if (period <= Mathf.Epsilon)
        {
            return;
        }

        float cycles = Time.time / period; // continually growing over time
        const float tau = Mathf.PI * 2; // constant value of 6.283
        float rawSinWave = Mathf.Sin(cycles * tau); // going from -1 to 1

        movementFactor = (rawSinWave + 1f) / 2f; //recalculated to go from 0 to 1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }

}
