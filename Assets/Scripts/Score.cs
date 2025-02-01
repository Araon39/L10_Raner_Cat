// Используем необходимые пространства имен
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

// Скрипт Unity (1 ссылка на ресурсы)
public class Score : MonoBehaviour
{
    // Объекты TextMeshProUGUI для отображения текущих и лучших очков
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;

    // Приватные переменные для хранения текущих и лучших очков
    private int currentScore;
    private int bestScore;

    // Приватная строка для хранения пути к файлу с данными очков
    private string filePath;

    // Сообщение Unity (вызывается при запуске скрипта)
    private void Awake()
    {
        // Определяем путь к файлу с данными очков
        filePath = Path.Combine(Application.persistentDataPath, "scoreData.json");
        // Загружаем лучшие очки из файла
        LoadBestScore();
    }

    // Сообщение Unity (вызывается каждый кадр)
    void Update()
    {
        // Обновляем текст очков
        UpdateScoreText();
    }

    // Метод для обновления текста очков
    void UpdateScoreText()
    {
        // Получаем текущие очки, округляя позицию объекта до целого числа
        currentScore = Mathf.FloorToInt(transform.position.z);
        // Обновляем текст очков
        scoreText.text = currentScore.ToString();

        // Если текущие очки больше, чем лучшие очки
        if (currentScore > bestScore)
        {
            // Обновляем лучшие очки
            bestScore = currentScore;
            // Обновляем текст лучших очков
            bestScoreText.text = bestScore.ToString();
            // Сохраняем лучшие очки
            SaveBestScore();
        }
    }

    // Метод для загрузки лучших очков
    void LoadBestScore()
    {
        // Проверяем, существует ли файл с лучшими очками
        if (File.Exists(filePath))
        {
            // Читаем содержимое файла
            string json = File.ReadAllText(filePath);
            // Преобразуем JSON в объект данных очков
            ScoreData data = JsonUtility.FromJson<ScoreData>(json);
            // Обновляем лучшие очки
            bestScore = data.bestScore;
            // Обновляем текст лучших очков
            bestScoreText.text = bestScore.ToString();
        }
        else
        {
            // Если файл не существует, устанавливаем лучшие очки в 0
            bestScore = 0;
            // Обновляем текст лучших очков
            bestScoreText.text = bestScore.ToString();
        }
    }

    // Метод для сохранения лучших очков
    void SaveBestScore()
    {
        // Создаем новый объект данных очков с текущими лучшими очками
        ScoreData data = new ScoreData { bestScore = bestScore };
        // Преобразуем объект данных в JSON
        string json = JsonUtility.ToJson(data, true);
        // Записываем JSON в файл
        File.WriteAllText(filePath, json);
    }

    // Атрибут [System.Serializable] позволяет сериализовать этот класс в JSON и другие форматы
    [System.Serializable]
    public class ScoreData
    {
        // Публичное целое поле для хранения лучшего результата
        public int bestScore;
    }

}
