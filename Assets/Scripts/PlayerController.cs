using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // ������ CharacterController, ������� ����� ��������� ����������
    private CharacterController controller;

    // �������� ����������� ���������
    private int speed = 3;

    // ���������� ��� ����������� �����, �� ������� ����� ������������ ��������
    private int lineToMove = 1;

    // ���������� ����� �������
    private float lineDistance = 3;

    // ����� Start ���������� ����� ������ ����������� �����
    void Start()
    {
        // �������� ��������� CharacterController, ������������� � ����� GameObject
        controller = GetComponent<CharacterController>();
    }

    // ����� FixedUpdate ���������� � ������������� ��������
    private void FixedUpdate()
    {
        // ���������� ��������� ������ � ������ �������� � �������, ���������� � ���������� �����
        controller.Move(Vector3.forward * Time.deltaTime * speed);
    }

    void Update()
    {
        // ���������, ������ �� ������� "D"
        if (Input.GetKeyDown(KeyCode.D))
        {
            // ���� lineToMove ������ 2, ����������� ��� �� 1
            if (lineToMove < 2)
            {
                lineToMove++;
            }
        }

        // ���������, ������ �� ������� "A"
        if (Input.GetKeyDown(KeyCode.A))
        {
            // ���� lineToMove ������ 0, ��������� ��� �� 1
            if (lineToMove > 0)
            {
                lineToMove--;
            }
        }

        // ��������� ������� ������� �� ������ ������� ������� � �����������
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        // ���� lineToMove ����� 0, ������� ������� ������� ����� �� lineDistance
        if (lineToMove == 0)
        {
            targetPosition += Vector3.left * lineDistance;
        }
        // ���� lineToMove ����� 2, ������� ������� ������� ������ �� lineDistance
        else if (lineToMove == 2)
        {
            targetPosition += Vector3.right * lineDistance;
        }

        // ������������� ����� ������� �������
        transform.position = targetPosition;
    }

}
