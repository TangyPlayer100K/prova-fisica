using UnityEngine;

public class Launch : MonoBehaviour
{
    [Header("Configurações")]
    public float maxAngle = 60f;          
    public float chargeSpeed = 30f;       
    public float releaseSpeed = 300f;     

    private float currentAngle = 0f;
    private bool charging = true;
    private bool releasing = false;

    void Update()
    {
        if (charging)
        {
            float deltaAngle = chargeSpeed * Time.deltaTime;
            if (currentAngle + deltaAngle < maxAngle)
            {
                RotateArm(deltaAngle);
                currentAngle += deltaAngle;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && charging)
        {
            charging = false;
            releasing = true;
        }

        if (releasing)
        {
            float deltaAngle = releaseSpeed * Time.deltaTime;
            if (currentAngle - deltaAngle > 0)
            {
                RotateArm(-deltaAngle);
                currentAngle -= deltaAngle;
            }
            else
            {
                RotateArm(-currentAngle);
                currentAngle = 0f;
                releasing = false;

                charging = true;
            }
        }
    }

    void RotateArm(float angle)
    {
        transform.Rotate(Vector3.back * angle, Space.Self);
    }
}
