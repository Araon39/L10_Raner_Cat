using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт Unity, который выполняется на ресурсах и ссылок: 0
public class DontDestroy : MonoBehaviour
{
    // Метод Awake вызывается при инициализации скрипта, до начала первого кадра
    void Awake()
    {
        // Находим все GameObject с тегом "Music"
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        // Если найдено более одного объекта с тегом "Music"
        if (objs.Length > 1)
        {
            // Уничтожаем текущий GameObject, чтобы избежать дублирования музыки
            Destroy(this.gameObject);
        }

        // Устанавливаем флаг DontDestroyOnLoad, чтобы объект не уничтожался при загрузке новой сцены
        DontDestroyOnLoad(this.gameObject);
    }
}
