using System.Collections; // Подключаем пространство имен для работы с коллекциями
using System.Collections.Generic; // Подключаем пространство имен для работы со списками
using UnityEngine; // Подключаем пространство имен Unity
using UnityEngine.UI; // Подключаем пространство имен для работы с UI в Unity

public class MusicSetting : MonoBehaviour // Объявляем класс MusicSetting, наследуемый от MonoBehaviour
{
    public Slider slider; // Ссылка на слайдер для управления громкостью
    public AudioSource audioSource; // Ссылка на источник звука

    void Start() // Метод, вызываемый при запуске сцены
    {
        // Добавляем слушателя на событие изменения значения слайдера
        slider.onValueChanged.AddListener(delegate { ChangeVolume(); });
    }

    // Метод для изменения громкости звука
    private void ChangeVolume()
    {
        // Устанавливаем громкость источника звука равной значению слайдера
        audioSource.volume = slider.value;
    }
}
