using UnityEngine;

public class Controller : MonoBehaviour
{
    [Header("CONTROLLER SETTINGS")]
    [SerializeField] Transform thisTransform;
    [Space(15)]
    [SerializeField] float moveSpeed = 25f;
    [SerializeField] float warpSpeed = 100f;
    [SerializeField] float rotationSpeed = 100f;

    [Header("PARTICLES FX")]
    [SerializeField] ParticleSystem ExhaustFX1;
    [SerializeField] ParticleSystem ExhaustFX2;
    [SerializeField] ParticleSystem ExhaustFX3;
    [SerializeField] ParticleSystem ExhaustFX4;

    private float engineFXSpeed;

    private void Start()
    {
        thisTransform = transform;
    }

    private void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        thisTransform.Rotate(new Vector3(mouseY,0,0) * rotationSpeed * Time.deltaTime);

        float horizontalInput = Input.GetAxis("Horizontal");
        thisTransform.Rotate(new Vector3(0,horizontalInput,0) * rotationSpeed * Time.deltaTime);
        thisTransform.Translate(new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime);
        
        float spaceshipSpeed = moveSpeed;
        engineFXSpeed = 0f;

        if (Input.GetKey(KeyCode.LeftShift)) // Warp speed
        {
            if (Input.GetKey(KeyCode.W)) // Warp speed
            {
                spaceshipSpeed = warpSpeed;
                engineFXSpeed = 15f;
            }
        }
        else if (Input.GetKey(KeyCode.W)) // Normal speed (forward)
        {
            spaceshipSpeed = moveSpeed;
            engineFXSpeed = 5f;
        }
        else if (Input.GetKey(KeyCode.S)) // Normal speed (back)
        {
            spaceshipSpeed = moveSpeed;
            engineFXSpeed = 5f;
        }

        EngineSpeedFX();

        float verticalInput = Input.GetAxis("Vertical");
        thisTransform.Translate(new Vector3(0, 0, verticalInput) * spaceshipSpeed * Time.deltaTime);
    }

    private void EngineSpeedFX()
    {
        var nFX1 = ExhaustFX1.main;
        var nFX2 = ExhaustFX2.main;
        var nFX3 = ExhaustFX3.main;
        var nFX4 = ExhaustFX4.main;
        
        nFX1.startSpeed = engineFXSpeed;
        nFX2.startSpeed = engineFXSpeed;
        nFX3.startSpeed = engineFXSpeed;
        nFX4.startSpeed = engineFXSpeed;
    }
}