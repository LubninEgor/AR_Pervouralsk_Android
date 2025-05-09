# AR_Pervouralsk_Android
Дополненная реальность с привязкой к GPS. ARCore, Unity <!-- описание репозитория -->
<!--Блок информации о репозитории в бейджах-->
![Static Badge](https://img.shields.io/badge/OkulusDev-Oxygen-Oxygen)
![GitHub top language](https://img.shields.io/github/languages/top/OkulusDev/Oxygen)
![GitHub](https://img.shields.io/github/license/OkulusDev/Oxygen)
![GitHub Repo stars](https://img.shields.io/github/stars/OkulusDev/Oxygen)
![GitHub issues](https://img.shields.io/github/issues/OkulusDev/Oxygen)

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
