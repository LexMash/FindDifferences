# FindDifferences

Test task - create a simple small game

При нажатии на правильном месте, происходит эффект нажатия на обоих изображениях (партиклы или анимация - на выбор исполнителя,)
При нахождении всех отличий появляется окно о победе
Поместить на сцену таймер на 2 минуты. По истечении времени должно выскакивать окно о проигрыше
Уровень должен быть исполнен в виде префаба. 
Необходимо запаковать префаб уровня в бандл (с помощью Addressables) и загружать его в начале игры
Разместить на сцене счетчик уровней (к примеру “Уровень: 1”). Оформление и местоположение не важно
На обоих окнах (победы и проигрыша) должна быть кнопка рестарта уровня. То есть при ее нажатии, просто все начинается и цифра на счетчике уровней становится на 1 больше
При каждом изменении счетчика сохранять значение в JSON формат (реализация сохранения)  и подставлять при перезапуске игры
Установите SDK Appodeal и напишите код для вызова тестовой межстраничной рекламы во время рестарта. 
Установите Unity IAP. Добавьте на сцене кнопку по нажатию на которую можно купить +10 секунд (оформление не важно)

Обязательные условия при выполнении:
Версия последняя 2022.3.23f1
Оформление победы и проигрыша окон - не важно. Можно просто белую панель с надписью и кнопкой
Оформление Таймера не важно. 
Для Appodeal допускается просто код, без регистрации на сервисах и полноценной инициализации.  В таком случае в билде сделайте сообщения “заглушки” об отсылке события или показания рекламы (можно просто текст внизу экрана). Но код в проекте должен быть написан верно. Проект должен собираться без ошибок.
