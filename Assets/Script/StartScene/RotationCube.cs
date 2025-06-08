using UnityEngine;

public class RotationCube : MonoBehaviour
{
    private Quaternion targetRotation;

    [SerializeField] private float rotationSpeed = 5f;

    void Start()
    {
        targetRotation = transform.rotation;
    }

    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    public void RotateToPosition1() => SetTargetRotation(new Vector3(0, 0, 0));
    public void RotateToPosition2() => SetTargetRotation(new Vector3(0, 90, 0));
    public void RotateToPosition3() => SetTargetRotation(new Vector3(0, 180, 0));
    public void RotateToPosition4() => SetTargetRotation(new Vector3(0, 270, 0));
    public void RotateToPosition5() => SetTargetRotation(new Vector3(90, 0, 0));
    public void RotateToPosition6() => SetTargetRotation(new Vector3(90, 90, -90));

    private void SetTargetRotation(Vector3 eulerAngles)
    {
        targetRotation = Quaternion.Euler(eulerAngles);
    }
}
