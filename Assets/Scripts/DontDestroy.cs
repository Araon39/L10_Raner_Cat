using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ Unity, ������� ����������� �� �������� � ������: 0
public class DontDestroy : MonoBehaviour
{
    // ����� Awake ���������� ��� ������������� �������, �� ������ ������� �����
    void Awake()
    {
        // ������� ��� GameObject � ����� "Music"
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        // ���� ������� ����� ������ ������� � ����� "Music"
        if (objs.Length > 1)
        {
            // ���������� ������� GameObject, ����� �������� ������������ ������
            Destroy(this.gameObject);
        }

        // ������������� ���� DontDestroyOnLoad, ����� ������ �� ����������� ��� �������� ����� �����
        DontDestroyOnLoad(this.gameObject);
    }
}
