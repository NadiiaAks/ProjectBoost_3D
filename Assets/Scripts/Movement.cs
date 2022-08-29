using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 0f;
    [SerializeField] float rotateSpeed = 0f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem thrustEffect;
    [SerializeField] ParticleSystem leftRotationEffect;
    [SerializeField] ParticleSystem rightRotationEffect;

    Rigidbody rb;
    AudioSource audioSource;

    bool isAlive;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotation();
        }
    }

    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!thrustEffect.isPlaying)
        {
            thrustEffect.Play();
        }
    }
    private void StopThrusting()
    {
        audioSource.Stop();
        thrustEffect.Stop();
    }

    private void RotateRight()
    {
        ApplyRotation(-rotateSpeed);
        if (!leftRotationEffect.isPlaying)
        {
            leftRotationEffect.Play();
        }
    }

    private void RotateLeft()
    {
        ApplyRotation(rotateSpeed);
        if (!rightRotationEffect.isPlaying)
        {
            rightRotationEffect.Play();
        }
    }

    private void StopRotation()
    {
        rightRotationEffect.Stop();
        leftRotationEffect.Stop();
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; 
    }
}
