using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    // Метод OnGUI вызывается несколько раз в секунду для отрисовки пользовательского интерфейса
    private void OnGUI()
    {
        // Определяем центр экрана по оси X
        int xCenter = Screen.width / 2;
        // Определяем центр экрана по оси Y
        int yCenter = 20;
        // Ширина кнопки
        int width = 120;
        // Высота кнопки
        int height = 40;

        // Создаем стиль для кнопки с использованием шкурки GUI и устанавливаем размер шрифта
        GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("button"));
        fontSize.fontSize = 20;

        // Получаем текущую активную сцену
        Scene scene = SceneManager.GetActiveScene();

        // Проверяем, является ли текущая сцена "Menu"
        if (scene.name == "Menu")
        {
            // Если нажата кнопка "Играть"
            if (GUI.Button(new Rect(xCenter - width / 2, yCenter - height / 2, width, height), "Играть", fontSize))
            {
                // Загружаем сцену "Game"
                SceneManager.LoadScene("Game");
            }
        }
        else
        {
            // Если нажата кнопка "Меню"
            if (GUI.Button(new Rect(xCenter - width / 2, yCenter - height / 2, width, height), "Меню", fontSize))
            {
                // Загружаем сцену "Menu"
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
