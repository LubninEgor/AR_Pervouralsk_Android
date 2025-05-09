# AR_Pervouralsk_Android
Дополненная реальность с привязкой к GPS. ARCore, Unity <!-- описание репозитория -->
<!--Блок информации о репозитории в бейджах-->
[![Unity](https://img.shields.io/badge/Unity-6000.0.23+-black?style=flat&logo=unity)](https://unity.com/)
[![AR Foundation](https://img.shields.io/badge/AR%20Foundation-6.1.0-blue?style=flat&logo=unity)](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@6.1/manual/index.html)
[![Platform](https://img.shields.io/badge/Platform-Android-green?style=flat&logo=android)](https://developer.android.com/)
[![License](https://img.shields.io/badge/License-MIT-yellow?style=flat)](https://opensource.org/licenses/MIT)
![Made With Love](https://img.shields.io/badge/Made%20With%20Love%20by%20Cheloveki%20team-FF69B4?style=flat)
![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=c-sharp&logoColor=white)


![Logotype](https://github.com/user-attachments/assets/7e47ccd1-32b3-4c86-b8cb-4b610275da83)

<!--Установка-->
## 🚀 Как запустить проект?


Требования:
У вас должны быть установлены Unity Hub + Unity 6000.0.X Целевая версия 6000.0.23.f1

Cкачать: https://unityhub://6000.0.23f1/1c4764c07fb4

Пакеты устанавливаются автоматически при запуске проекта.

Установка:

1.   Клонируйте репозиторий:

(через команду) 
```git clone https://github.com/LubninEgor/AR_Pervouralsk_Android.git```
			
   (или через сайт GutHub https://github.com/LubninEgor/AR_Pervouralsk_Android)
		
   (если установлен GitHub Desktop): ```https://github.com/LubninEgor/AR_Pervouralsk_Android --> зеленая кнопка "<>Code" --> "open with GitHub Desktop" ```
			
   (если не установлен GitHub Desktop): ```https://github.com/LubninEgor/AR_Pervouralsk_Android --> зеленая кнопка "<>Code" --> "Download ZIP"```
			
2.   Добавьте проект в Unity (Unity Hub --> Add --> Add project from dick --> выбрать папку с проектом)
	
3.   Откройте проект в Unity
		
4.   Выберите целевую платформу (Android) в Build Settings
		
5.  Сделайте Build
	
❗❗❗❗❗ Если приложение при установке на смартфон выдает ошибку типа "Приложение не установлено", то установите дополнительные SDK в Unity:
	
PlayerSettings --> Player --> OtherSettings --> identification --> Target API level (заменить Automatic на Android 9/10) --> сделайте Build (ждите скачивания пакетов через PowerShell)

<!--О проекте-->
## 📌 Возможности


 - Распознавание целевых и фактических координат, высчитывание расстояния до объекта (истороического здания) (через AR и GPS).

 - Взаимодействие с виртуальными объектами (В режиме без GPS можно вращать, перемещать, масштабировать объекты).

 - Поддержка Android (В Uinty стоит минимальная версия Android 9. Тестировалось на android 10).
 
 - Добавлено 3 режима отображения объектов:
	
	1) **С AR и GPS** ```(Объекты привязываются к координатам, а затем к AR.(Зачастую не поддерживается на старых или бютжетных смартфонах. Полный список поддерживаемых устройств см.
на сейте``` https://developers.google.com/ar/devices?hl=ru ```Для таких устройств подойдет режим номер 3))```
	
	3) **С AR, но без GPS** ```(Объекты привязываются к плоскостям в AR.(Так же как и в режиме номе 1: зачастую не поддерживается на старых или бютжетных смартфонах.
Этот режим сделан для демо или при невозможности посетить историческое место)```
	
	4) **Без AR и без GPS** ```(Идеальный режим для слабых устройств. Представляет собой 3д модель с возможностью рессмотреть ее со всех сторон)```

## 📡 Геолокация и AR (как это работает??)
Проект использует GPS и компас для точного позиционирования виртуальных объектов в реальном мире:
- **Получение координат**: Через `UnityEngine.LocationService`.
- **Расчёт расстояния**: Алгоритм Haversine для метрической точности.
- **Конвертация в AR-пространство**: Пересчёт разницы координат в метры по осям X/Z.
  
**Примеры кода**

1️⃣ Получение GPS-координат
// Запуск службы GPS с точностью 1 метр

```csharp

IEnumerator InitializeGPS()
{
    Input.location.Start(1f, 1f); 
    while (Input.location.status == LocationServiceStatus.Initializing && Time.time < 20)
    {
        yield return null; // Ожидание инициализации (макс. 20 секунд)
    }

    if (Input.location.status == LocationServiceStatus.Failed)
    {
        Debug.LogError("Не удалось получить координаты GPS.");
    }
    else
    {
        gpsInitialized = true;
        Debug.Log($"GPS начался. Текущая позиция: {Input.location.lastData.latitude}, {Input.location.lastData.longitude}");
    }
}
```

2️⃣ Расчёт расстояния до цели (в метрах)
Формула Haversine для точного расчёта:

```csharp

// Возвращает расстояние в метрах между двумя точками на Земле
float CalculateDistanceToTarget(double lat1, double lon1, double lat2, double lon2)
{
    float R = 6371f; // Радиус Земли в км
    float dLat = (float)(lat2 - lat1) * Mathf.Deg2Rad;
    float dLon = (float)(lon2 - lon1) * Mathf.Deg2Rad;
    float a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) + 
              Mathf.Cos((float)lat1 * Mathf.Deg2Rad) * 
              Mathf.Cos((float)lat2 * Mathf.Deg2Rad) * 
              Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2);
    float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
    return R * c * 1000f; // Конвертация в метры
}
```


3️⃣ Конвертация GPS → AR-позиция
Перевод разницы координат в метры для Unity:

```csharp
// Преобразует разницу широты/долготы в Vector3 (XZ-плоскость)
Vector3 GetARPositionFromGPS(double targetLat, double targetLon)
{
    double currentLat = Input.location.lastData.latitude;
    double currentLon = Input.location.lastData.longitude;

    // 1 градус широты ≈ 111319.488 м
    double zOffset = (targetLat - currentLat) * 111319.488;

    // Долгота зависит от широты (коррекция через косинус)
    double xOffset = (targetLon - currentLon) * 111319.488 * Mathf.Cos((float)currentLat * Mathf.Deg2Rad);

    return new Vector3((float)xOffset, 0, (float)zOffset);
}
```
<!--лицензия-->
## 📝 Лицензия

Проект сводобный, при условии упоминания авторов : https://t.me/Prpr11 и https://t.me/Lybnineg, а так же сылки на данный репозиторий в GitHub 


<!--Приложение-->
## 📸 Скриншоты/Видео


![Slide 16_9 - 21](https://github.com/user-attachments/assets/fa99dfad-63f2-45ff-894f-52e2e7a68d8a)
![Slide 16_9 - 26](https://github.com/user-attachments/assets/daef870e-e2b0-4e2d-85e0-2e094627633e)
![Slide 16_9 - 29](https://github.com/user-attachments/assets/c15095fd-2e0a-4e9c-ae94-eea4a0f50f9e)
![Slide 16_9 - 24](https://github.com/user-attachments/assets/b33d3bc4-f93c-4839-bba0-065df5c686bf)
![Slide 16_9 - 25](https://github.com/user-attachments/assets/e1eec980-614b-44c4-a0b7-16872c0975f1)
![Slide 16_9 - 26-1](https://github.com/user-attachments/assets/6a635bce-6031-470d-a8dc-d9b65938003b)
![Slide 16_9 - 27](https://github.com/user-attachments/assets/c4214076-184e-415f-beeb-b914342baf3d)
![Slide 16_9 - 28](https://github.com/user-attachments/assets/3ba97cd1-bd3f-4a86-8d3a-2d7d1871f6fd)
