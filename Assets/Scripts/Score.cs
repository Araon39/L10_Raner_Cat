// ���������� ����������� ������������ ����
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

// ������ Unity (1 ������ �� �������)
public class Score : MonoBehaviour
{
    // ������� TextMeshProUGUI ��� ����������� ������� � ������ �����
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;

    // ��������� ���������� ��� �������� ������� � ������ �����
    private int currentScore;
    private int bestScore;

    // ��������� ������ ��� �������� ���� � ����� � ������� �����
    private string filePath;

    // ��������� Unity (���������� ��� ������� �������)
    private void Awake()
    {
        // ���������� ���� � ����� � ������� �����
        filePath = Path.Combine(Application.persistentDataPath, "scoreData.json");
        // ��������� ������ ���� �� �����
        LoadBestScore();
    }

    // ��������� Unity (���������� ������ ����)
    void Update()
    {
        // ��������� ����� �����
        UpdateScoreText();
    }

    // ����� ��� ���������� ������ �����
    void UpdateScoreText()
    {
        // �������� ������� ����, �������� ������� ������� �� ������ �����
        currentScore = Mathf.FloorToInt(transform.position.z);
        // ��������� ����� �����
        scoreText.text = currentScore.ToString();

        // ���� ������� ���� ������, ��� ������ ����
        if (currentScore > bestScore)
        {
            // ��������� ������ ����
            bestScore = currentScore;
            // ��������� ����� ������ �����
            bestScoreText.text = bestScore.ToString();
            // ��������� ������ ����
            SaveBestScore();
        }
    }

    // ����� ��� �������� ������ �����
    void LoadBestScore()
    {
        // ���������, ���������� �� ���� � ������� ������
        if (File.Exists(filePath))
        {
            // ������ ���������� �����
            string json = File.ReadAllText(filePath);
            // ����������� JSON � ������ ������ �����
            ScoreData data = JsonUtility.FromJson<ScoreData>(json);
            // ��������� ������ ����
            bestScore = data.bestScore;
            // ��������� ����� ������ �����
            bestScoreText.text = bestScore.ToString();
        }
        else
        {
            // ���� ���� �� ����������, ������������� ������ ���� � 0
            bestScore = 0;
            // ��������� ����� ������ �����
            bestScoreText.text = bestScore.ToString();
        }
    }

    // ����� ��� ���������� ������ �����
    void SaveBestScore()
    {
        // ������� ����� ������ ������ ����� � �������� ������� ������
        ScoreData data = new ScoreData { bestScore = bestScore };
        // ����������� ������ ������ � JSON
        string json = JsonUtility.ToJson(data, true);
        // ���������� JSON � ����
        File.WriteAllText(filePath, json);
    }

    // ������� [System.Serializable] ��������� ������������� ���� ����� � JSON � ������ �������
    [System.Serializable]
    public class ScoreData
    {
        // ��������� ����� ���� ��� �������� ������� ����������
        public int bestScore;
    }

}
