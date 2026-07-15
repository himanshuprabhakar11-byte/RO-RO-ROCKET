using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustStrength = 100f;
    [SerializeField] float rotationStrength = 100f;
    [SerializeField] AudioClip mainEngineSFX;

    [SerializeField] ParticleSystem thrustParticle;
    [SerializeField] ParticleSystem leftThrustParticle;
    [SerializeField] ParticleSystem rightThrustParticle;

    Rigidbody rb;
    AudioSource audioSource;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    private void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        StartThrusting();
    }
    private void ProcessRotation()
    {
        StartRotation();
    }


    private void ApplyRotation(float rotateThisFrame)
    {
        rb.freezeRotation = true;
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        transform.Rotate(Vector3.forward * rotateThisFrame * Time.fixedDeltaTime);
        rb.freezeRotation = false;

    }


    private void StartThrusting()
    {
        if (thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
            thrustParticle.Play();


            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngineSFX);
            }

            if (thrustParticle.isPlaying)
            {
                thrustParticle.Play();
            }

        }
        else
        {
            audioSource.Stop();
            thrustParticle.Stop();
        }
    }
    private void StartRotation()
    {
        float rotationInput = rotation.ReadValue<float>();

        if (rotationInput < 0)
        {
            ApplyRotation(rotationStrength);

            if (!rightThrustParticle.isPlaying)
            {
                leftThrustParticle.Stop();
                rightThrustParticle.Play();
            }
        }

        else if (rotationInput > 0)
        {
            ApplyRotation(-rotationStrength);


            if (!leftThrustParticle.isPlaying)
            {
                leftThrustParticle.Play();
                rightThrustParticle.Stop();
            }


        }

        else
        {
            leftThrustParticle.Stop();
            rightThrustParticle.Stop();
        }
    }
}