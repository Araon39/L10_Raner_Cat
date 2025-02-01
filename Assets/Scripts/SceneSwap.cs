using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    // ����� OnGUI ���������� ��������� ��� � ������� ��� ��������� ����������������� ����������
    private void OnGUI()
    {
        // ���������� ����� ������ �� ��� X
        int xCenter = Screen.width / 2;
        // ���������� ����� ������ �� ��� Y
        int yCenter = 20;
        // ������ ������
        int width = 120;
        // ������ ������
        int height = 40;

        // ������� ����� ��� ������ � �������������� ������ GUI � ������������� ������ ������
        GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("button"));
        fontSize.fontSize = 20;

        // �������� ������� �������� �����
        Scene scene = SceneManager.GetActiveScene();

        // ���������, �������� �� ������� ����� "Menu"
        if (scene.name == "Menu")
        {
            // ���� ������ ������ "������"
            if (GUI.Button(new Rect(xCenter - width / 2, yCenter - height / 2, width, height), "������", fontSize))
            {
                // ��������� ����� "Game"
                SceneManager.LoadScene("Game");
            }
        }
        else
        {
            // ���� ������ ������ "����"
            if (GUI.Button(new Rect(xCenter - width / 2, yCenter - height / 2, width, height), "����", fontSize))
            {
                // ��������� ����� "Menu"
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
