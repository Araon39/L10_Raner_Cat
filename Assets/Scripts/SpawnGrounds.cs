using System.Collections.Generic; // ���������� ������������ ���� ��� ������ �� ��������
using UnityEngine; 

public class SpawnGrounds : MonoBehaviour 
{
    public GameObject[] grounds;        // ������ �������� �������� �����
    private List<GameObject> groundsList = new List<GameObject>(); // ������ ��� �������� ��������������� �������� �����

    private float spawnPos = 0;         // ������� ��� ������ ���������� ������� �����
    private float groundLength = 100;   // ����� ������ ������� �����

    public Transform player;            // ������ �� ������
    private int startGround = 6;        // ���������� ��������� �������� �����

    void Start()
    {
        // ���������� ��������� ������� �����
        for (int i = 0; i < startGround; i++)
        {
            // ���������� ������� ����� � ��������� �������� �� ������� grounds
            Spawn(Random.Range(0, grounds.Length));
        }
    }

    // ����� ��� ��������� ������ ������� �����
    void Spawn(int index)
    {
        // ������� ����� ������� ����� �� ������ ������� �� ������� grounds �� �������
        GameObject nextGround = Instantiate(grounds[index], transform.forward * spawnPos, transform.rotation);
        // ��������� ����� ������� ����� � ������ groundsList
        groundsList.Add(nextGround);
        // ����������� spawnPos �� ����� ������� ����� ��� ��������� ���������
        spawnPos += groundLength;
    }

    // ����� ��� �������� ������ ������� ������� �����
    void DestroyGrounds()
    {
        // ������� ����� ������ ������� ����� �� ������ groundsList
        Destroy(groundsList[0]);
        // ������� ����� ������ ������� ����� �� ������ groundsList
        groundsList.RemoveAt(0);
    }

    void Update() // �����, ���������� ������ ����
    {
        // ���������, ��������� �� ����� �� ��������� �������� ������� �����
        if (player.position.z - 100 > spawnPos - (startGround * groundLength))
        {
            // ���������� ��������� ������ ��� ���������� ������� �����
            Spawn(Random.Range(0, grounds.Length));
            // ������� ����� ������ ������� �����
            DestroyGrounds();
        }
    }
}
