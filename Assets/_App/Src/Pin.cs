using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField] float tresholdAngle = 45f;
    bool hasFallen = false;

    void Start()
    {
        Invoke(nameof(EnableRotation), 1f);
    }

    private void Update()
    {
        if (!hasFallen)
        {
            CheckIfHasFallen();
        }
    }

    void CheckIfHasFallen()
    {
        // Vector3.up;//global up
        // transform.up; //local up
        float angle = Vector3.Angle(transform.up, Vector3.up);

        if (angle >= tresholdAngle)
        {
            hasFallen = true;
            GameManager.Instance.PinFell(this);
        }
    }

    void EnableRotation()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.constraints = 0;
    }

}
