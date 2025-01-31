using System.Collections; // ���������� ������������ ���� ��� ������ � �����������
using System.Collections.Generic; // ���������� ������������ ���� ��� ������ �� ��������
using UnityEngine; // ���������� ������������ ���� Unity
using UnityEngine.UI; // ���������� ������������ ���� ��� ������ � UI � Unity

public class MusicSetting : MonoBehaviour // ��������� ����� MusicSetting, ����������� �� MonoBehaviour
{
    public Slider slider; // ������ �� ������� ��� ���������� ����������
    public AudioSource audioSource; // ������ �� �������� �����

    void Start() // �����, ���������� ��� ������� �����
    {
        // ��������� ��������� �� ������� ��������� �������� ��������
        slider.onValueChanged.AddListener(delegate { ChangeVolume(); });
    }

    // ����� ��� ��������� ��������� �����
    private void ChangeVolume()
    {
        // ������������� ��������� ��������� ����� ������ �������� ��������
        audioSource.volume = slider.value;
    }
}
