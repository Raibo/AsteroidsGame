## Общее описание проекта
Этот проект - выполнение тестового задания.  
Задание состоит в том, чтобы воссоздать игру Asteroids, но с некоторыми отличиями, указанными в ТЗ.  

Отличия описаны в документе по ссылке: [Отличия от оригинальной игры.txt](https://github.com/Raibo/AsteroidsGame/blob/master/Info/%D0%9E%D1%82%D0%BB%D0%B8%D1%87%D0%B8%D1%8F%20%D0%BE%D1%82%20%D0%BE%D1%80%D0%B8%D0%B3%D0%B8%D0%BD%D0%B0%D0%BB%D1%8C%D0%BD%D0%BE%D0%B9%20%D0%B8%D0%B3%D1%80%D1%8B.txt)  
Ссылка на ТЗ: [ТЗ серверный программист[506].pdf](https://github.com/Raibo/AsteroidsGame/blob/master/Info/%D0%A2%D0%97%20%D1%81%D0%B5%D1%80%D0%B2%D0%B5%D1%80%D0%BD%D1%8B%D0%B8%CC%86%20%D0%BF%D1%80%D0%BE%D0%B3%D1%80%D0%B0%D0%BC%D0%BC%D0%B8%D1%81%D1%82%5B506%5D.pdf)  
Ссылка на описание оригинальной игры Asteroids на википедии: [Ссылка en.wikipedia.org](https://en.wikipedia.org/wiki/Asteroids_(video_game))  
Ссылка на видео, содержащее геймплей оригинальной игры Asteroids: [Ссылка YouTube](https://youtu.be/_TKiRvGfw3Q)

## Структура проекта:
Выполнено в Unity.

C# проект состоит из двух сборок: EngineIndependent и UnitySpecific.  
Вся игровая логика содержится в EngineIndependent.  
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

## Управление в игре
Ускорение: `W`  
Поворот влево: `A`  
Поворот вправо: `D`  
Стрелять пулями: `Space`  
Стрелять лазером: `LShift`  
Начать новую игру (работает только при проигрыше): `N`  

## Изначальный дизайн игры
Перед тем как приступать к реализации, я просмотрел описание и видео с оригинальной игрой и ТЗ, чтобы составить представление о том, что нужно делать.  

Получился следующий список игровых объектов, видимых игроку:  
Корабль, Астероид(большой), Астероид(обломок), Летающая тарелка, Пуля, Лазер.  
Подробное описание того, что должны "уметь" эти объекты в документе по ссылке: [Игровые объекты.txt](https://github.com/Raibo/AsteroidsGame/blob/master/Info/%D0%98%D0%B3%D1%80%D0%BE%D0%B2%D1%8B%D0%B5%20%D0%BE%D0%B1%D1%8A%D0%B5%D0%BA%D1%82%D1%8B.txt)  

Поскольку с самого начала было ясно, что логику игры предстоит писать без зависимостей от движка, была выбрана архитектура с DI.  

Так же сразу же было решено что ответственность за то, за что обычно отвечает движок, сразу же на него и переложим.  
Да, сборка не зависит от движка, но какой-то движок все равно будет. Если даже это был бы не Unty, то какой-то другой, хоть даже самописный, но 2D физика, коллизии, update-loop там точно должны быть.  
Поэтому реализовывать это всё в игровом коде было бы расточительно.  

Начал с того, что посмотрел, какие объекты планируются в игре, вычленил что у них есть общего (вроде объекта с 2D физикой, разрушаемого объекта, фабрики), получилось хорошее начало для разработки структуры. Начал с интерфейсов, продолжил реализацией.  

По мере того, как реализовывал интерфейсы, становилось понятно, какие у них будут зависимости, и какие механики требуются в игре.  
Те интерфейсы, которые требуют для своей реализации непосредственно возможности Unity, были реализованы уже в сборке, зависящей от Unity.  
Например, `IPhysicsObject` требует реализации симуляции физики. Значит, реализовать его без зависимости от движка не получится.  

Когда в сборке `EngineIndependent` все было готово, приступил к сборке `UnitySpecific`.  
После реализации интерфейсов, связанных с движком, пришлось сделать контейнеры для всех реализаций внутри `EngineIndependent`, чтобы их можно было разместить в виде компонентов на игровых объектах.  
В плане того, в какой форме это сделать, в итоге пришел к абстрактному классу `EntityHolder<TEntity> : MonoBehaviour`, где `TEntity` - это сущность игровой логики.  
Каждый класс с оберткой какой-либо сущности имеет публичные поля со всеми её зависимостями, чтобы их можно было предоставить в Инспекторе.  

## Особенности и другие комментарии
### Проставление полей в инспекторе
Unity не всегда хорошо работает с компонентами, наследующими от дженериков, поэтому иногда для проставления поля в инспекторе недостаточно перетащить содержащий его игровой объект, а надо перетаскивать сам компонент явно.  
Но при работе с реальным проектом, эту проблему можно было бы решить кастомными инструментами.  

### Пользовательский ввод
В проекте есть 2 интерфейса, отвечающих за пользовательский ввод: `IControlInputProvider` и `IUiInputProvider`.  
Это обусловлено тем, что они используются в разное время. Один во время игры, а другой в "меню", когда можно начать новую после проигрыша.  

Реализации у них тоже разные.  
`IControlInputProvider` хранит признаки управляющих сигналов и меняет их при нажатии кнопок. Это потому что инпут читается в Update, а используется в FixedUpdate.  
`IUiInputProvider` не предоставляет свой инпут объектам, работающим на FixedUpdate, поэтому имеет упрощенную реализацию, не требующую это учитывать.  

Кнопки управления захардкожены, не стал выносить их в Инспектор.  
Это неудобно, енам KeyCode слишком большой для редактирования в Инспекторе.  
В реальном проекте скорее всего использовалась бы InputSystem, настройки кнопок были бы вынесены туда.  
В общем, хард код кнопок управления сделан не потому что я не догадался вынести его в Инспектор, это осознанное решение.  

### Реализация лазера
Из описания не ясно в точности, как должен работать лазер.  
Деталь которая не ясна - он должен стрелять мнгновенно или светить некоторое время.  
Поэтому я реализовал его светящим некоторое время, а если требовался мнгновенный выстрел, то можно просто проставить время 0.

Для лазера (и для реализации поиска попавших под лазер объектов) есть ограничение на количество задетых целей за фрейм.  
Это связано с тем, что используется `CircleCastNonAlloc`.  
Я не хотел, чтобы на каждый фрейм работы лазера создавался мусор в виде одноразового массива, а NonAlloc требует буфер.  
Размер настраивается, и в контексте этой игры, не требуется большой размер, 10 вполне достаточно.  

От выполнения лазера в виде продолговатого объекта с прямоугольным коллайдером я тоже отказался, мне такой способ показался менее элегантным.  

### Фабрики, не использующие ObjectPool
Реализации фабрик не переиспользуют объекты. Это не самый лучший подход с точки зрения оптимизации по времени и памяти.  
Не стал реализовывать пулинг потому что это всё-таки тестовое задание, а улучшать можно до бесконечности. Всегда будет еще один аспект, который можно было бы сделать лучше.  

Однако, архитеатура проекта вполне позволяет сделать пулинг без больших изменений.  
Единственное изменение, выходящее за пределы реализации интерфейса `IObjectFactory` - это добавление поддержки сброса состояния для всех игровых сущностей, для которых требуется это состояние сбросить в случае переиспользования.  
Это можно было бы сделать через новый интерфейс, например, `IResetable`, реализация которого стояла бы в тех сущностях, которые требуют сброса.  
Тогда фабрика бы находила каждый такой компонент по признаку реализации этого интерфейса и вызывала бы сброс.  

Да, можно было бы сказать, что игровая логика не должна зависеть от реализации, но всё же пишущий её не живет на другой планете и знает, что ObjectPooling - это распространенная практика, и игровые сущности могли бы её поддерживать.  


