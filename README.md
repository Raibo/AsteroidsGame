## Общее описание проекта
Этот проект - выполнение тестового задания.  
Задание состоит в том, чтобы воссоздать игру Asteroids, но с некоторыми отличиями, указанными в ТЗ.  

Отличия описаны в документе по ссылке: [Ссылка](https://github.com/Raibo/AsteroidsGame/blob/master/Info/%D0%9E%D1%82%D0%BB%D0%B8%D1%87%D0%B8%D1%8F%20%D0%BE%D1%82%20%D0%BE%D1%80%D0%B8%D0%B3%D0%B8%D0%BD%D0%B0%D0%BB%D1%8C%D0%BD%D0%BE%D0%B9%20%D0%B8%D0%B3%D1%80%D1%8B.txt)  
Ссылка на ТЗ: [Ссылка](https://github.com/Raibo/AsteroidsGame/blob/master/Info/%D0%A2%D0%97%20%D1%81%D0%B5%D1%80%D0%B2%D0%B5%D1%80%D0%BD%D1%8B%D0%B8%CC%86%20%D0%BF%D1%80%D0%BE%D0%B3%D1%80%D0%B0%D0%BC%D0%BC%D0%B8%D1%81%D1%82%5B506%5D.pdf)  
Ссылка на описание оригинальной игры Asteroids на википедии: [Ссылка](https://en.wikipedia.org/wiki/Asteroids_(video_game))  
Ссылка на видео, содержащее геймплей оригинальной игры Asteroids: [Ссылка](https://youtu.be/_TKiRvGfw3Q)

## Структура проекта:
Выполнено в Unity.

C# проект состоит из двух сборок: EngineIndependent и UnitySpecific.  
Вся игровая логика содержится в EngineIndependent, как и требовалось в задании.  
UnitySpecific выступает в роли адапрета.  

![image](https://user-images.githubusercontent.com/8547320/236560701-9d959064-f6f3-4046-bd0e-3e212ff53a7e.png)

### 1. EngineIndependent
Не имеет зависимостей от Unity.  
Отвечает за игровую логику.  
Не несет ответственности за симуляцию физики, регистрацию столкновений, update-loop, хранение объектов на игровом поле.  
Это перекладывается на движок (любой движок, не обязательно Unity, но какой-то движок должен быть).  

Объявляет интерфейсы для всех сущностей, имеющих смысл в контексте игровой логики,  
реализует те из них, которые могут работать без помощи какого-либо движка.  

### 2. UnitySpecific
Зависит как от Unity, так и от EngineIndependent.  
Отвечает за соединение сборки EngineIndependent с движком Unity.  
Использует Unity для симуляции физики, регистрации столкновений, update-loop, хранения компонентов в GameObjects.

Адаптирует Unity под EngineIndependent, предоставляя возможности движка сборке.

Так же адаптирует EngineIndependent под Unity, предоставляя обертку для хранения внутриигровых сущностей в виде компонентов UnityEngine.MonoBehaviour.

Выступает в роли DI-контейнера (создает, хранит, предоставляет зависимости реализациям интерфейсов).  
Передает настройки из редактора Unity в параметры создаваемых внутриигровых сущностей.  
Разрешение зависимостей выполняется вручную, через Inspector в редакоре Unity.  
Каждый компонент с внутриигровой сущностью имеет ее зависимости в виде полей, в которые нужно перетащить компоненты с реализацией зависимости.  

### Общая структура
Каждая игровая механика выделена в отдельный интерфейс, реализация которого может иметь зависимости в виде интерфейсов от других игровых механик.  
То есть с использованием Dependency Inversion.  

Например, механика стрельбы (WeaponGun : IWeapon) зависит от других механик:  
учета амуниции (IAmmoProvider), пользовательского ввода (IControlInputProvider),  
физического объекта, откуда стрелять (IPhysicsObject), фабрики пуль (IObjectFactory).  
То есть WeaponGun умеет стрелять, но создавать пули или читать пользовательский ввод не умеет, этим занимаются отдельные классы.  

Сами игровые объекты, как правило, не имеют собственного представления в виде отдельного класса, например, в игре есть корабль, но нет класса корабль.  
(Корабль является объектом Unity.GameObject, обладающим компонентами, реализующими все его свойства, такие как управляемость, оружие и т.д.)  

Такой подход обеспечивает гибкость, модульность/переиспользуемость, уменьшает зависимость между командами разработки и дизайна, дает возможность использовать unit-тестирование.  
