using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LogicOfPrinting : MonoBehaviour
{
    [Header("Ускоритель")]
    public int speedBoster;
    [Header("Ускоритель")]
    public bool testMode;
    [Header("Декаративное сопровождение")]
    public GameObject sys_Load_img;

    [Header("Цветовое сопровождение")]
    public Color system_Messanger;
    public Color doctor_Messanger;
    public Color hero_Messanger;
    public Color noName_Messanger;

    [Header("Шаги в сюжете")]
    public int step;
    [Header("Подшаги в сюжете")]
    int substeps;
    [Header("Значение выбора \"наблюдателя\" в разговоре с Доком")]
    public int mainChoice;
    public int _mainChoice;
    [Header("Булевые переменные отвечающие за прогресс выполнения того или иного действия")]

    bool printingMainTextFinality;
    bool printingAnswerOneFinality;
    bool printingAnswerTwoFinality;
    bool printingNAFinality;
    bool deletingMainTextFinality;
    bool deletingAnswerOneFinality;
    bool deletingAnswerTwoFinality;
    bool deletingNAFinality;
    [HideInInspector]
    public bool readinessToButtonPressed;
    bool timerStart;
    bool timerFinality;
    [HideInInspector]
    public bool ButtonPressed;
    [Header("Значение выбранного")]
    public int buttonNumber;
    public int buttonMultiDialogNumber;
    [Header("Компоненты для работы \"загрузки\"")]
    public GameObject slider_Process;
    string playerName;
    [Header("Различные тексты на экране")]
    public Text mainText;
    public Text optionOneText;
    public Text optionTwoText;
    public Text optionNAText;
    public Text nameText;

    [Header("Различные объекты")]
    public GameObject buttonOptionOne;
    public GameObject buttonOptionTwo;

    public GameObject buttonNNA;//единственная кнопка, без возможности печатания текста

    public GameObject buttonNA;//единственная кнопка, с возможностью печатания текста
    [Header("Поле ввода")]
    public InputField inputField;

    [Header("Slider для различных целей")]
    public Slider sliderTime;
    [Header("Аудио сорсы")]
    public AudioSource audioSource;
    public AudioSource ambientSource;
     int eventStartTimeYear;
     int eventStartTimeMonth;
     int eventStartTimeDays;
     int eventStartTimeHourse;
     int eventStartTimeMinutes;
     int eventStartTimeSeconds;
     int eventFinalTimeYear;
     int eventFinalTimeMonth;
     int eventFinalTimeDays;
     int eventFinalTimeHourse;
     int eventFinalTimeMinutes;
     int eventFinalTimeSeconds;
    [HideInInspector]
    public int typeOfWorkGlobal;
    public bool startStep;
    public TextFromJSON textFromJSON = new TextFromJSON();
     string[] MainText = new string[69];
     string[] MainText0 = new string[28];
     string[] MainText1 = new string[58];
     string[] AOT = new string[22];
     string[] AOT0 = new string[5];
     string[] AOT1 = new string[15];
     string[] ATT = new string[22];
     string[] ATT0 = new string[5];
     string[] ATT1 = new string[15];
     string[] AT = new string[14];
    public bool startCountdown, finishCountdown;
    public Text timerText;
    public GameObject timerGO;
    public int speedPrintingText = 1, speedDeletingText = 1;
    bool iPrint;

    public GameObject galleryPushAnimator;

    public GameObject game;
    public GameObject loadScreen;

    public GameObject autosaveLogo;

    public Animator settingAnm;
    public Settings settings;

    public ClickLoadScene cLS;
    public Slider audioSlider;
     string[] MainText_0 = new string[5];
     string[] MainText_1 = new string[5];

    TextLogic textLogic;
    public class TextFromJSON
    {
        public string[] MainText_0 = new string[5]{
            "Неизвестный: Откуда? У меня твоё имя в комуникаторе написано, ладно, я выбрал направление... начинаю идти...",
            "Странник: Я упал и вырубился на пару секунд, когда встал, передо мною были какие-то твари, похожие на чертов из библии, они были отвратительны.",
            "Странник: Нет, это было все реально!",
            "Странник: Ладно, нужно выбираться отсюда . . . ",
            "Странник: Вижу,что дальше есть узкий проход. Могу попробовать пройти дальше."
        };
        public string[] MainText_1 = new string[5]{
            "Неизвестный: Хорошо, я выбрал направление... начинаю идти...",
            "Странник: Нормально, я упал и вырубился на пару секунд, когда встал, передо мною были какие-то твари, похожие на чертов из библии, они были отвратительны.",
            "Странник :Ты не веришь мне!?",
            "Странник: Не веришь? Ну и хрен с тобой, мне нужно выбираться отсюда . . . ",
            "Странник: Нет. Ничерта здесь нет!Думаю, нужно выбраться из этой дыры, как можно скорее."
    };
        public string[] MainText = new string[64] {
        "System: Спасибо за приобретение коммуникатора TGP V.1.0.",
        "System: Калибровка, процедура начата...",
        "System: Введите ваше имя...",
        "System: Сохранение параметров...",
        "System: Есть входящие сигнатуры. Принять сигнал?",
        "Неизвестный: Приё... ме... слы...",
        "Игра окончена.",
        "Неизвестный: У меня огромные проблемы, я нахожусь неизвестно где, не помню, как здесь оказался и что делаю. Здесь адски холодно, а еще я попал в самую бурю.",
        "Неизвестный: Да ты издеваешься!? Я же сказал тебе, что здесь буря! Ещё  и холод бешенный.",
        "Неизвестный:Ладно,ладно . . . И да,спасибо ",
        "System: ожидание когда неизвестный выйдет на связь...",
        "Неизвестный: Эй,это я!Все в порядке,но я заметил одну вещь . . . На моем комбинезоне надпись ,,Странник’’ . Странно не правда ли? Так вот. . . Как меня зовут я все равно не помню,так что можешь звать меня странником.",
        "System:Синхронизация новых данных . . .",
        "System:Синхронизация завершена.",
        "System: Ожидание пока Странник выйдет на связь.",
        "Странник: Ого!Ты бы только это видел!Я нашел что-то на подобие пещеры!Только вот...вход завален снегом,придется копать...С другой стороны это лишняя трата времени...Я рассчитываю на твой выбор.",
        "Странник: Черт . . . как же холодно . . . у меня больше нет сил идти. Отдохну . . .",
        "System:Связь потеряна . . .",
        "Игра окончена. Странник погиб от переохлаждения.",
        "Странник: Да! Да! Почти! Вот, погоди...пробую пролезть...",
        "Странник: Я уже почти полностью пролез...твою мать! Я пад...",
        "System: Связь потеряна . . . ",
        "System: Подключение невозможно, попытка  переподключения . . .",
        "System: Сигнал обнаружен, попытка соединения . . .",
        "System:  Слабый сигнал, подключение ретрансляторов .",
        "System: Сигнал возобновлен . . . ",
        "Странник: Чертовы твари! Уйдите от меня! А ну с-сука!",
        "System: Обнаружена неисправность устройства собеседника",
        "System:  Устройство активировано.",
        "Некто: Черт возьми, его устройство  работает? Я же сказал его в первую очередь проверить. Его дружок ничего не должен узнать об операции...",
        "System:  Устройство отключено, режим ожидания.",
        "System: Устройство включено, установка сигнала . . .",
        "Странник: О боже, о боже, только ответь ,пожалуйста! Ну же!",
        "Странник: О боги! Как же я рад, что ты на связи... Я упал с выступа, эта пещера оказалась ловушкой...",
        "Странник: Да, я могу попробовать выбраться через ту же дыру, через которую и залез, либо обследовать местность. Что скажешь?",
        "Странник: Хорошо, дай мне пару секунд... Так, я уже карабкаюсь... Как же скользко и холодно... Почти доле...",
        "Игра окончена.Странник погиб от падения и множественных переломов позвоночника.",
        "Странник: Да, ты прав, это слишком опасно, да и страховки у меня нет...",
        "Странник: Выйду на связь, как найду что-то полезное...",
        "Странник: Погоди, что-то... что-то есть... Это похоже на люк. Странно, что он делает в пещере...",
        "Странник: Я еще не смотрел, открыт ли он, но чтобы выбраться мне придется лезть туда.",
        "Странник: Я всегда осторожен, но спасибо за заботу.",
        "Странник: Так, я начал спускаться и здесь воняет тухлятиной...надеюсь это ненадолго. Жди.",
        "Странник: Так, я спустился. Здесь есть свет и это меня радует. Путь у меня только один - прямо по туннелю.",
        "Странник: Стоп. Я что-то слышал. О черт, это мой коммуникатор пищит, я надеюсь, что это не заряд...",
        "System: Обнаружено новое соединение ...",
        "System: Принять сигнал?",
        "Неизвестный: Подожди секундочку, мой сладкий, я возьму управление на себя...",
        "Неизвестный: Ах, какое разочарование, верно?",
        "Неизвестный :Ой, какие мы злые... Знаешь, если бы не я, то вы бы и не связались никогда .",
        "Неизвестный: Ты не поверишь, но…именно я управляю ретрансляторами  и именно Я позволил твоему сигналу попасть в список доступных на его устройстве",
        "Неизвестный: и если ты хочешь дальше помогать ему морально, то тебе придется заключить со мной договор…",
        "Неизвестный: Понимаешь... Он... как же ты его тогда назвал… Странник? Ну вот,",
        "Неизвестный: Странник - не совсем человек. Вернее... он человек, но ничего человеческого в нем не осталось…",
        "Неизвестный: Зря ты так... Ведь он сейчас находится в тоннеле и пытается с тобой связаться…Будет очень грустно, если он этого не сможет.",
        "Неизвестный: Хорошо, мы сейчас поговорим, но для начала я немного поковыряюсь в твоем устройстве чтобы ты видел моё имя",
        "System:  Доступ к данным... Сохранение новых значений",
        "System:Синхронизация данных...",
        "System:Процесс завершен.",
        "Доктор Вольфганг: Ну вот, так намного лучше. Перейдём сразу к делу. Мне нужно чтобы ты мне подыгрывал. Можешь его поддерживать, рассказывать ему анекдоты… Но когда мои люди будут идти за ним, ты должен им помочь поймать его.",
        "Доктор Вольфганг: Понимаешь, он не тот, кем кажется. Раньше он был обычным офисным  работником. Его имя - Джон Ригель. У него был ребенок, жена…Они есть и сейчас, но именно они попросили нас помочь ему!",
        "Доктор Вольфганг: С ним начало происходить непостижимое науке. Он - новый виток эволюции. Его нервная система…психика… они намного совершеннее ,чем наши.",
        "Доктор Вольфганг: Его мозг может восстанавливать почти всю нервную систему и психику за счет  дополнительного поглощения  кислорода и выработке неизвестного нам вещества в его теле. Мы не знаем, что это за вещество, но оно крайне ценно для всего мира.",
        "Доктор Вольфганг: Да, есть некая формальность. Я же не сказал, восстанавливает полностью. Мы допустили огромную ошибку, когда сказали ему это. Я думаю, этого тебе пока что достаточно знать. Я хочу услышать твое решение..."
    };
        public string[] MainText0 = new string[28] {
            "Доктор Вольфганг: А теперь  я возращу тебя к твоему другу…",
        "System:  переподключение…",
        "System: Операция завершена…",
        "Странник: Да чертов ты коммуникатор! Давай, поймай же этот гребанный сигнал!",
        "Странник: Когда ты перестанешь так пропадать? Ты заставляешь меня нервничать…",
        "Странник: Правда? Что-то мне не особо верится, но…. проехали, мне нужна твоя помощь.",
        "Странник: Так, как связаться с тобой я не мог, мне пришлось идти наугад.Я забрел в какую-то отдельную комнату ,как только я зашел внутрь, дверь закрылась.",
        "Странник: Я успел осмотреться и нашел в полу небольшую решетку, видимо это вентиляция. Я могу попробовать вылезти в нее.",
        "System: Получено разрешение от администратора на исполнение код а  ,,Странник ,, .Уровень-1.",
        "System: Загрузка дополнительного приложения для коммуникатора…",
        "System: Загрузка завершена. Синхронизация устройств.",
        "Странник: Что это за херня?! Какого черта,(USER NAME)!?",
        "Странник: Не дури мне мозги, тварь! Ты тоже с ними заодно?! Какого черта?! Что они предложили тебе!? Ради чего ты продал нашу связь!?",
        "Странник: Знаешь что?.. Да пошел ты…",
        "System: Канал связи закрыт. Повторное соединение…",
        "System: В соединении отказано…",
        "System: Загрузка данных…",
        "System: Получено Текстовое сообщение….",
        "System:  Ты можешь наблюдать за ним через наши камеры и вести с ним разговор через колонки, просто отвлеки его, пока мои люди идут за ним… P.S. Доктор Вольфганг .",
        "System: Исполнение кода ,,Странник КСУ,, начато…",
        "System: Отслеживание объекта….",
        "System:  Объект найден, местоположение-тоннель.",
        "System: Колонки активированы.",
        "Странник: Да поше…Ты….кх….",
        "System: Связь с колонкой № 739 потеряна.",
        "Доктор Вольфганг: Большое спасибо,(USER NAME), вы очень помогли нам, но теперь, пока мои люди не нашли его, я отключаю вас. Ожидайте посылку размером в двадцать тысяч долларов.",
        "System:  Ваше устройство отключено от сети",
        "System: Надеемся ,что коммуникатор вам понравился. Спасибо за приобретение."
        };
        public string[] MainText1 = new string[58] {
            "Доктор Вольфганг : Значит это твое последнее слово?",
        "Доктор Вольфганг: Значит ты крупно пожалеешь о том, что сделал.",
        "System:  Устройство отключено. Связь потеряна.",
        "System:  Начать поиск предыдущей сессии?",
        "System : Процедура начата…",
        "System :  устройство не обнаружено…повторить попытку?",
        "System: Повторить попытку?",
        "System: Обнаружена ошибка. Получено разрешение на соединение. Принять сигнал?",
        "System: Подключение….",
        "Странник:  USER NAME!USER NAME! Отзовись, же ты наконец….",
        "Странник : О боже, как хорошо, что ты вернулся…что это, блять, было?",
        "Странник: Это… это пиздец….",
        "Странник: Да, ты прав…не время раскисать, но я должен спросить…",
        "Странник: Он ведь может разорвать соединение снова?",
        "Странник: Вот же дерьмо, ладно, слушай…  Я, после того, как связь с тобой оборвалась , поковырялся здесь в тоннеле. И хочу сказать, что заметил одну вещь…На стенах, через определенное расстояние, находятся колонки .Странно, не правда ли?",
        "Странник: Да, хорошо, просто подумал, что тебе нужно это знать…",
        "Странник: Ну… здесь явно была экстренная эвакуация, причём по ЭТОМУ тоннелю. Везде документы, прочая офисная дрянь.",
        "System:  Обнаружена  чужеродная активность….",
        "System: Колонки включены….",
        "System:  Новое соединение…",
        "Доктор Вольфганг:  А-ха-ха-ха…ты думал/а, что всё и в правду так просто? Так вот. Хочу тебе сказать, что я подключил колонки в тоннеле. Сейчас мои люди займутся им, а потом и тобой, можешь поговорить с ним на прощание.",
        "Странник: Что за говно? Здесь везде орут колонки, что мне делать?",
        "Странник : Хорошо, я понял тебя……",
        "Странник: О боже, о боже….я нашел дверь, но она заперта, еще, я слышал шум из начала тоннеля, возможно там кто-то есть…",
        "Странник: я тебя понял…",
        "Странник: Все, готово, я сделал это!",
        "Странник: Так, хорошо…. я внутри. Чем загородить дверь? Здесь есть деревянный стол и железный офисный ящик?",
        "Странник:  Приказ понял, сейчас ….",
        "Странник: У…ффф….Знаешь ,а он тяжелей ,чем я думал…",
        "Странник: Все, я  закончил…",
        "Странник: Нет, все нормально, здесь есть еще одна дверь. Что-то холодно стало… Надеюсь я не получил переохлаждение, когда бродил в буре?",
        "Странник: Сейчас посмотрю, что за той дверью… Черт! Какого хрена?!",
        "Странник: Я вышел из-за чертовой двери, а здесь улица! Но это еще не самое плохое… Вот что хуже всего, здесь  маленькая площадка, а дальше обрыв, по-моему я на горе…",
        "Странник: Боже…я так не думаю, мой единственный выход - прыгнуть…",
        "Странник: Нет,USER NAME, уже поздно…Они ломают дверь…",
        "Странник: Ты издеваешься!? Хотя, погоди…. да ты же гений! Когда они войдут, я аккуратно обкидаю этих уродов камнями, может получится кого-то вырубить и забрать его оружие, но если все пойдет наперекосяк…я лучше прыгну…",
        "System: Поймана новая радиочастота…",
        "System: Внедрение в сеть…",
        "Неизвестные: Сэр, дверь почти выломана,у нас есть разрешение на огонь?",
        "Неизвестный:  Никак нет, солдат. Объект нужен живым, в его мозгу слишком много важного.",
        "Неизвестные : Вас понял. Ну что там с дверью?",
        "Неизвестные:  Мы сломали замок, ждем вашей команды и войдем внутрь…",
        "Странник: Ты тоже уловил новую частоту?",
        "Странник: Ну что же… вот и все…",
        "Странник: О боже, а они на всю голову отбитые! Они взорвали ее, а ведь они знают ,что мы на ГОРЕ!",
        "Неизвестные:  сохраняйте спокойствие, мы здесь, чтобы помочь вам…",
        "Странник: Да пошли вы нахер, уроды!",
        "Неизвестные: Сэр, черт, сэр! Он обкидывает нас камнями! Как нам действовать?!",
        "Неизвестный: Сержант, сделайте все, что бы привести его к нам в целости и сохранности .",
        "Неизвестные: Ребят, обходи его, берем в петлю!",
        "Странник: Вот и все,USER NAME, спасибо тебе за помощь, я обещаю тебе, мы еще увидимся!",
        "Неизвестные: Твою мать, сэр, он спрыгнул! Повторяю, он спрыгнул с горы…",
        "Неизвестный: Как вы могли это допустить, тупые вояки!",
        "Неизвестные: Сэр, мы ничего не могли сделать.",
        "Доктор Вольфганг:  У нас есть образцы крови, может сможем вывести из них формулу …",
        "Неизвестный: Доктор, теперь надежда только на вас.",
        "Доктор Вольфганг: Что же…Закрыть протокол ,,СТРАННИК,, операция провалена .",
        "КОНЕЦ."
        };
        public string[] AOT = new string[22]
            {"Да",
        "Да!",
        "Продолжить с последней контрольной точки.",
        "Ты видишь что-нибудь вокруг себя?",
        "Спокойно,я помогу тебе",
        "Откуда ты знаешь моё имя?",
        "Да, иди дальше",
        "Осторожней там",
        "Приём?",
        "Странник,что происходит!?",
        "Не меня звал?",
        "Что с тобой произошло?",
        "Может тебе привидилось?",
        "Верю",
        "Видишь что-нибудь?",
        "Попробуй забраться",
        "Люк закрыт?",
        "Будь осторожен",
        "Что ты имеешь в виду!?",
        "Ладно, ладно, постой! Я согласен на все.",
        "Но это безумие!",
        "Хорошо, я согласен…"
            };
        public string[] AOT0 = new string[5]{"Эй, я здесь",
        "Что такое?",
        "Что ты имеешь в виду?",
        "Странник, я хочу помочь тебе!",
        "Отключиться." };
        public string[] AOT1 = new string[15] {"Именно",
        "Да",
        "Я здесь",
        "Что?",
        "Да",
        "Не стой на месте. Двигайся.",
        "Есть что-нибудь полезное под рукой?",
        "Входи!",
        "Стол!",
        "Есть другой выход?",
        "По-моему это из-за двери…",
        "Есть другой путь?",
        "Погоди, мы что-нибудь придумаем!",
        "Поищи оружие!",
        "Ага" };
        public string[] ATT = new string[22] {"Нет",
        "Сильные помехи.",
        "Выйти в главное меню.",
        "Попробуй отыскать укрытие.",
        "Попробуй идти вперед не изменяя курса",
        "Обращайся",
        "Нет, попробуй раскопать",
        "Будь внимателен",
        "Странник?",
        "Отвечай,мать твою!",
        "Я на связи!",
        "Как ты?",
        "Ты точно встал после падения?",
        "Кто знает что с тобой произошло",
        "Есть что-то полезное?",
        "Обследуй пещеру",
        "Хочешь проверить?",
        "Аккуратно только",
        "Что за чушь ты несешь?",
        "Все, я слушаю тебя. Только не отключай меня.",
        "Да ты совсем сбрендил!",
        "Да пошел ты…" };
        public string[] ATT0 = new string[5] { "Смотри не разломай его",
        "Проблемы?",
        "Что такое!?",
        "Я помогу тебе, слушай меня…",
        "Да пошел ты на хер, больной  выродок!"};
        public string[] ATT1 = new string[15] {"Да",
        "Нет",
        "Я на связи",
        "Я слушаю…",
        "Возможно, но маловероятно.",
        "Давай, нужно идти.",
        "Видишь что-нибудь? ",
        "Войди и забаррикадируй дверь!",
        "Ящик!",
        "Надеюсь, ты не взаперти?",
        "Навряд ли…",
        "Может можно  что-нибудь придумать?",
        "Стой, это не выход…",
        "Есть чем защищаться !?",
        "Да" };
        public string[] AT = new string[14] {
        "Какого хера ты делаешь в моем коммуникаторе?!",
        "Если все это - правда, то что ты хочешь от меня?",
        "Боже, что за чушь ты несешь?",
        "Стоп. Ты дуришь меня, старик. Он не помнит ни черта!",
        "Теперь я не пропаду…",
        "Подожди, я все объясню!",
        "Да",
        "Да. Сделать принятие сигнала автоматическим.",
        "Какой-то  неизвестный мне человек прервал сессию  и отключил меня. Он предложил меня предать тебя и завести в ловушку.",
        "Но я послал его на четыре стороны, давай достанем тебя оттуда…",
        "Беги не останавливаясь, ищи выход.",
        "Выбивай дверь!",
        "Что ты видишь!?",
        "Знай, я с тобой…" };
    }

    public enum TypeOfWork
    {
        standard,
        withSlider,
        inputField,
        multiSteps,
        characterDied,
        save,
        mainChoice
    }

    public void LanguageLoad()
    {
        MainText_0 = textFromJSON.MainText_0;
        MainText_1 = textFromJSON.MainText_1;
        MainText = textFromJSON.MainText;
        MainText0 = textFromJSON.MainText0;
        MainText1 = textFromJSON.MainText1;
        AOT = textFromJSON.AOT;
        AOT1 = textFromJSON.AOT1;
        AOT0 = textFromJSON.AOT0;
        ATT = textFromJSON.ATT;
        ATT0 = textFromJSON.ATT0;
        ATT1 = textFromJSON.ATT1;
        AT = textFromJSON.AT;
    }

    void Start()
    {
        
        LanguageLoad();
        slider_Process.SetActive(false);
        timerGO.SetActive(false);
        autosaveLogo.SetActive(false);
        galleryPushAnimator.SetActive(false);
        UniversalOffEnabledButton();
        UniversalOffEnabledButtonNNA();
        UniversalOffEnabledNAButton();
        optionOneText.text = "";
        optionTwoText.text = "";

        inputField.gameObject.SetActive(false);
        if (!testMode)
        {
            if (PlayerPrefs.GetInt("newGame") == 1)
            {
                NewGame();
                PlayerPrefs.SetInt("newGame", 0);
                PlayerPrefs.Save();
            }
            else if (PlayerPrefs.GetInt("loadGame") == 1)
            {
                Load();
                PlayerPrefs.SetInt("loadGame", 0);
                PlayerPrefs.Save();
            }
            else
            {
                NewGame();
                PlayerPrefs.SetInt("newGame", 0);
                PlayerPrefs.Save();
            }
        }
        else
        {
            printingMainTextFinality = false;
            printingAnswerOneFinality = false;
            printingAnswerTwoFinality = false;
            deletingMainTextFinality = false;
            deletingAnswerOneFinality = false;
            deletingAnswerTwoFinality = false;
            readinessToButtonPressed = false;
            PlayerPrefs.SetInt("GalleryProgress", 0);
        }
    }


    void UniversalStandartDialogNNA(Color message, string _mainText)
    {
        mainText.color = message;
        MainTextPrtStd(_mainText);
        UniversalMainTextDlt();
        PrsBtnStdNNA();
        typeOfWorkGlobal = (int)TypeOfWork.standard;
        NextStepStdNNA();
    }

    void UniversalStandartDialogNNA(Color message, string _mainText, string _mainText1)
    {
        mainText.color = message;
        if (buttonNumber == 1)
        {
            MainTextPrtStd(_mainText);
        }
        else if(buttonNumber == 2)
        {
            MainTextPrtStd(_mainText1);
        }
        UniversalMainTextDlt();
        PrsBtnStdNNA();
        typeOfWorkGlobal = (int)TypeOfWork.standard;
        NextStepStdNNA();
    }
    void UniversalStandartDialogNNAFinal(Color message, string _mainText)
    {
        mainText.color = message;
        MainTextPrtStd(_mainText);
        UniversalMainTextDlt();
        PrsBtnStdNNA();
        typeOfWorkGlobal = (int)TypeOfWork.standard;
        NextStepStdNNAFinal();
    }

    void UniversalStandartDialog(Color message, string _mainText, string AOText, string ATText)
    {
        mainText.color = message;
        MainTextPrtStd(_mainText);
        AnswerOneTextPrtStd(AOText);
        AnswerTwoTextPrtStd(ATText);
        UniversalMainTextDlt();
        UniversalAnswerOneTextDlt();
        UniversalAnswerTwoTextDlt();
        typeOfWorkGlobal = (int)TypeOfWork.standard;
        PrsBtnStd();
        NextStepStd();
    }

    void UniversalStandartDialogMainChoice(Color message, string _mainText, string AOText, string ATText)
    {
        mainText.color = message;
        MainTextPrtStd(_mainText);
        AnswerOneTextPrtStd(AOText);
        AnswerTwoTextPrtStd(ATText);
        UniversalMainTextDlt();
        UniversalAnswerOneTextDlt();
        UniversalAnswerTwoTextDlt();
        typeOfWorkGlobal = (int)TypeOfWork.mainChoice;
        PrsBtnStd();
        NextStepStdMC();
    }

    void UniversalStandartDialog(Color message, string _mainText, string _mainText1, string AOText, string ATText)
    {
        mainText.color = message;
        if (buttonNumber == 1)
        {
            MainTextPrtStd(_mainText);
        }
        else if (buttonNumber == 2)
        {
            MainTextPrtStd(_mainText1);
        }
        AnswerOneTextPrtStd(AOText);
        AnswerTwoTextPrtStd(ATText);
        UniversalMainTextDlt();
        UniversalAnswerOneTextDlt();
        UniversalAnswerTwoTextDlt();
        typeOfWorkGlobal = (int)TypeOfWork.standard;
        PrsBtnStd();
        NextStepStd();
    }

    void UniversalStandartDialogPre(Color message, string _mainText, string _mainText1, string AOText, string ATText)
    {
        mainText.color = message;
        if (buttonNumber == 1)
        {
            MainTextPrtStd(_mainText);
        }
        else if (buttonNumber == 2)
        {
            MainTextPrtStd(_mainText1);
        }
        AnswerOneTextPrtStd(AOText);
        AnswerTwoTextPrtStd(ATText);
        UniversalMainTextDlt();
        UniversalAnswerOneTextDlt();
        UniversalAnswerTwoTextDlt();
        typeOfWorkGlobal = (int)TypeOfWork.standard;
        PrsBtnStd();
        NextStepStd();
    }
    void UniversalStandartDialogNA(Color message, string _mainText, string mainText1, string NAText)
    {
        mainText.color = message;
        if (buttonNumber == 1)
        {
            MainTextPrtStd(_mainText);
        }
        else if (buttonNumber == 2)
        {
            MainTextPrtStd(mainText1);
        }
        AnswerNATextPrtStd(NAText);
        UniversalMainTextDlt();
        UniversalAnswerNATextDlt();
        typeOfWorkGlobal = (int)TypeOfWork.standard;
        PrsBtnNAStd();
        NextStepStdNA();
    }

    void UniversalStandartDialogNA(Color message, string _mainText, string NAText)
    {
        mainText.color = message;
        MainTextPrtStd(_mainText);
        AnswerNATextPrtStd(NAText);
        UniversalMainTextDlt();
        UniversalAnswerNATextDlt();
        typeOfWorkGlobal = (int)TypeOfWork.standard;
        PrsBtnNAStd();
        NextStepStdNA();
    }


    void ClearVar()
    {
        if(printingMainTextFinality & !readinessToButtonPressed)
            buttonMultiDialogNumber = 0;
    }
    void UniversalStandartDialogPreMultiDialog(Color message, string _mainText, string AOText, string ATText)
    {
        mainText.color = message;
        StartSave();
        MainTextPrtStd(_mainText);
        AnswerOneTextPrtStd(AOText);
        AnswerTwoTextPrtStd(ATText);
        UniversalMainTextDlt();
        UniversalAnswerOneTextDlt();
        UniversalAnswerTwoTextDlt();
        typeOfWorkGlobal = (int)TypeOfWork.standard;
        PrsBtnStd();
        NextStepStd();
        ClearVar();
    }

    void UniversalStandartDialogPreMultiDialog(Color message, string _mainText, string mainText1, string AOText, string ATText)
    {
        mainText.color = message;
        StartSave();
        if (buttonNumber == 1)
        {
            MainTextPrtStd(_mainText);
        }
        else if (buttonNumber == 2)
        {
            MainTextPrtStd(mainText1);
        }
        AnswerOneTextPrtStd(AOText);
        AnswerTwoTextPrtStd(ATText);
        UniversalMainTextDlt();
        UniversalAnswerOneTextDlt();
        UniversalAnswerTwoTextDlt();
        typeOfWorkGlobal = (int)TypeOfWork.standard;
        PrsBtnStd();
        NextStepStd();
        ClearVar();
    }

    void UniversalStandartMultiDialog(Color message, string _mainText, string AOText, string ATText)
    {
        mainText.color = message;
        MainTextPrtStd(_mainText);
        AnswerOneTextPrtStd(AOText);
        AnswerTwoTextPrtStd(ATText);
        UniversalMainTextDlt();
        UniversalAnswerOneTextDlt();
        UniversalAnswerTwoTextDlt();
        typeOfWorkGlobal = (int)TypeOfWork.standard;
        PrsBtnStd();
        NextStepMultiSteps();
    }

    void UniversalStandartMultiDialogNNA(Color message, string _mainText)
    {
        mainText.color = message;
        MainTextPrtStd(_mainText);
        UniversalMainTextDlt();
        typeOfWorkGlobal = (int)TypeOfWork.standard;
        PrsBtnStdNNA();
        NextStepMultiStepsNNA();
    }

    void UniversalSliderDialog(Color message, string _mainText, string AOText, string ATText, float maxValue)
    {
        mainText.color = message;
        MainTextPrtSld(_mainText, maxValue);
        AnswerOneTextPrtSld(AOText);
        AnswerTwoTextPrtSld(ATText);
        UniversalMainTextDlt();
        UniversalAnswerOneTextDlt();
        UniversalAnswerTwoTextDlt();
        typeOfWorkGlobal = (int)TypeOfWork.withSlider;
        PrsBtnSld();
        NextStepSld();
    }

    void UniversalSliderDialogNNA(Color message, string _mainText, float maxValue)
    {
        mainText.color = message;
        MainTextPrtSld(_mainText, maxValue);
        UniversalMainTextDlt();
        PrsBtnSldNNA();
        typeOfWorkGlobal = (int)TypeOfWork.withSlider;
        NextStepSldNNA();
    }

    void UniversalCountdownDialog(Color message, string _mainText, string AOText, string ATText, double addHour)
    {
        mainText.color = message;
        MainTextPrtCnt(_mainText, addHour);
        CheckerCountdown();
        if (finishCountdown)
        {
            AnswerOneTextPrtCnt(AOText);
            AnswerTwoTextPrtCnt(ATText);
            UniversalMainTextDlt();
            UniversalAnswerOneTextDlt();
            UniversalAnswerTwoTextDlt();
            typeOfWorkGlobal = (int)TypeOfWork.withSlider;
            PrsBtnCnt();
            NextStepCnt();
        }
    }

    void UniversalCountdownDialogNNA(Color message, string _mainText, double addHour)
    {
        mainText.color = message;
        MainTextPrtCnt(_mainText, addHour);
        CheckerCountdown();
        if (finishCountdown)
        {
            UniversalMainTextDlt();
            typeOfWorkGlobal = (int)TypeOfWork.withSlider;
            PrsBtnCntNNA();
            NextStepCntNNA();
        }
    }
    void UniversalInputDialog(Color message, string _mainText, string AOText, string ATText)
    {
        mainText.color = message;
        MainTextPrtInp(_mainText);
        AnswerOneTextPrtInp(AOText);
        AnswerTwoTextPrtInp(ATText);
        UniversalMainTextDlt();
        UniversalAnswerOneTextDlt();
        UniversalAnswerTwoTextDlt();
        typeOfWorkGlobal = (int)TypeOfWork.inputField;
        PrsBtnInp();
        NextStepInp();
    }

    void UniversalInputDialogNNA(Color message, string _mainText)
    {
        mainText.color = message;
        MainTextPrtInp(_mainText);
        UniversalMainTextDlt();
        typeOfWorkGlobal = (int)TypeOfWork.inputField;
        PrsBtnInp();
        NextStepInp();
    }

    void UniversalDeadDialog(Color message, string _mainText, string AOText, string ATText)
    {
        mainText.color = message;
        MainTextPrtStd(_mainText);
        AnswerOneTextPrtStd(AOText);
        AnswerTwoTextPrtStd(ATText);
        UniversalMainTextDlt();
        UniversalAnswerOneTextDlt();
        UniversalAnswerTwoTextDlt();
        typeOfWorkGlobal = (int)TypeOfWork.characterDied;
        PrsBtnStd();
        NextStepDead();
    }
    void Update()
    {
        GlobalTimer();
        if (mainChoice == 0)
        {
            switch (step)
            {
                case 1:
                    UniversalStandartDialogNNA(system_Messanger, MainText[0]);
                    break;
                case 2:
                    UniversalSliderDialogNNA(system_Messanger, MainText[1], 5);
                    break;
                case 3:
                    UniversalInputDialogNNA(system_Messanger, MainText[2]);
                    break;
                case 4:
                    UniversalSliderDialogNNA(system_Messanger, MainText[3], 10);
                    break;
                case 5:
                    UniversalStandartDialogPreMultiDialog(system_Messanger, MainText[4], AOT[0], ATT[0]);
                    break;
                case 6:
                    switch (buttonNumber)
                    {
                        case 1:
                            UniversalStandartDialog(hero_Messanger, MainText[5], AOT[1], ATT[1]);
                            break;
                        case 2:
                            UniversalDeadDialog(system_Messanger, MainText[6], AOT[2], ATT[2]);
                            break;
                    }
                    break;
                case 7:
                    UniversalStandartDialog(hero_Messanger, MainText[7], AOT[3], ATT[3]);
                    break;
                case 8:
                    UniversalStandartDialog(hero_Messanger, MainText[8], AOT[4], ATT[4]);
                    break;
                case 9:
                    UniversalStandartDialog(hero_Messanger, MainText[9] + playerName, AOT[5], ATT[5]);
                    break;
                case 10:
                    UniversalStandartDialogNNA(hero_Messanger, MainText_0[0], MainText_1[0]);
                    break;
                case 11:
                    UniversalSliderDialogNNA(system_Messanger, MainText[10],5);
                    break;
                case 12:
                    UniversalStandartDialogNNA(hero_Messanger, MainText[11]);
                    break;
                case 13:
                    UniversalSliderDialogNNA(system_Messanger, MainText[12], 5);
                    break;
                case 14:
                    UniversalStandartDialogNNA(system_Messanger, MainText[13]);
                    break;
                case 15:
                    UniversalSliderDialogNNA(system_Messanger, MainText[14], 5);
                    break;
                case 16:
                    UniversalStandartDialogPreMultiDialog(hero_Messanger, MainText[15], AOT[6], ATT[6]);
                    break;
                case 17:
                    switch (buttonMultiDialogNumber)
                    {
                        case 1:
                            switch (substeps)
                            {
                                case -1:
                                    UniversalStandartMultiDialogNNA(hero_Messanger, MainText[16]);
                                    break;
                                case 0:
                                    UniversalStandartMultiDialogNNA(system_Messanger, MainText[17]);
                                    break;
                                case 1:
                                    UniversalDeadDialog(system_Messanger, MainText[18], AOT[2], ATT[2]);
                                    break;
                            }
                            break;
                        case 2:
                            UniversalStandartDialog(hero_Messanger, MainText[19], AOT[7], ATT[7]);
                            break;
                    }
                    break;
                case 18:
                    UniversalStandartDialogNNA(hero_Messanger, MainText[20]);
                    break;
                case 19:
                    UniversalStandartDialogNNA(system_Messanger, MainText[21]);
                    break;
                case 20:
                    UniversalSliderDialogNNA(system_Messanger, MainText[22], 2);
                    break;
                case 21:
                    UniversalSliderDialogNNA(system_Messanger, MainText[23], 5);
                    break;
                case 22:
                    UniversalSliderDialogNNA(system_Messanger, MainText[24], 10);
                    break;
                case 23:
                    UniversalStandartDialog(system_Messanger, MainText[25], AOT[8], ATT[8]);
                    break;
                case 24:
                    UniversalStandartDialogNNA(hero_Messanger, MainText[26]);
                    break;
                case 25:
                    UniversalStandartDialogNNA(system_Messanger, MainText[27]);
                    break;
                case 26:
                    UniversalStandartDialog(system_Messanger, MainText[28], AOT[9], ATT[9]);
                    break;
                case 27:
                    UniversalStandartDialogNNA(noName_Messanger, MainText[29]);
                    break;
                case 28:
                    UniversalSliderDialogNNA(system_Messanger, MainText[30], 5);
                    break;
                case 29:
                    UniversalSliderDialogNNA(system_Messanger, MainText[31], 5);
                    break;
                case 30:
                    UniversalStandartDialog(hero_Messanger, MainText[32], AOT[10], ATT[10]);
                    if (startStep)
                    {
                        startStep = false;
                        if (PlayerPrefs.GetInt("GalleryProgress") == 0)
                            OpenPic(1);

                    }
                    break;
                case 31:
                    UniversalStandartDialog(hero_Messanger, MainText[33],AOT[11], ATT[11]);
                    break;
                case 32:
                    UniversalStandartDialog(hero_Messanger, MainText_0[1], MainText_1[1],  AOT[12], ATT[12]);
                    break;
                case 33:
                    UniversalStandartDialog(hero_Messanger, MainText_0[2], MainText_1[2], AOT[13], ATT[13]);
                    break;
                case 34:
                    UniversalStandartDialog(hero_Messanger, MainText_0[3], MainText_1[3], AOT[14], ATT[14]);
                    break;
                case 35:
                    UniversalStandartDialogPreMultiDialog(hero_Messanger, MainText_0[4], MainText_1[4], AOT[15], ATT[15]);
                    break;
                case 36:
                    switch (buttonNumber)
                    {
                        case 1:
                            switch (substeps)
                            {
                                case -1:
                                    UniversalStandartMultiDialogNNA(hero_Messanger, MainText[35]);
                                    break;
                                case 0:
                                    UniversalDeadDialog(system_Messanger, MainText[36], AOT[2], ATT[2]);
                                    break;
                            }
                            break;
                        case 2:
                            UniversalStandartDialogNNA(hero_Messanger, MainText[37]);
                            break;
                    }
                    break;
                case 37:
                    UniversalSliderDialogNNA(hero_Messanger, MainText[38], 10);
                    break;
                case 38:
                    UniversalStandartDialog(hero_Messanger, MainText[39], AOT[16], ATT[16]);
                    break;
                case 39:
                    UniversalStandartDialog(hero_Messanger, MainText[40], AOT[17], ATT[17]);
                    break;
                case 40:
                    UniversalStandartDialogNNA(hero_Messanger, MainText[41]);
                    break;
                case 41:
                    UniversalCountdownDialogNNA(hero_Messanger, MainText[42],10);
                    break;
                case 42:
                    UniversalStandartDialogNNA(hero_Messanger, MainText[43]);
                    break;
                case 43:
                    UniversalStandartDialogNNA(hero_Messanger, MainText[44]);
                    break;
                case 44:
                    UniversalStandartDialogNNA(system_Messanger, MainText[45]);
                    break;
                case 45:
                    UniversalStandartDialog(system_Messanger, MainText[46], AOT[0], ATT[0]);
                    break;
                case 46:
                    UniversalStandartDialogNA(noName_Messanger, MainText[47], MainText[48], AT[0]);
                    break;
                case 47:
                    UniversalStandartDialog(noName_Messanger, MainText[54], AOT[18], ATT[18]);
                    break;
                case 48:
                    UniversalStandartDialogNNA(noName_Messanger, MainText[55]);
                    break;
                case 49:
                    UniversalStandartDialogNA(noName_Messanger, MainText[56], AT[1]);
                    break;
                case 50:
                    UniversalStandartDialogNNA(noName_Messanger, MainText[57]);
                    break;
                case 51:
                    UniversalStandartDialogNA(noName_Messanger, MainText[58], AT[2]);
                    break;
                case 52:
                    UniversalStandartDialog(noName_Messanger, MainText[59], AOT[19], ATT[19]);
                    break;
                case 53:
                    UniversalStandartDialogNNA(noName_Messanger, MainText[60]);
                    break;
                case 54:
                    UniversalSliderDialogNNA(system_Messanger, MainText[61], 5);
                    break;
                case 55:
                    UniversalSliderDialogNNA(system_Messanger, MainText[62], 10);
                    break;
                case 56:
                    UniversalStandartDialogNNA(system_Messanger, MainText[63]);
                    break;
                case 57:
                    UniversalStandartDialog(doctor_Messanger, MainText[64], AOT[20], ATT[20]);
                    break;
                case 58:
                    UniversalStandartDialogNNA(doctor_Messanger, MainText[65]);
                    break;
                case 59:
                    UniversalStandartDialogNNA(doctor_Messanger, MainText[66]);
                    break;
                case 60:
                    UniversalStandartDialogNA(doctor_Messanger, MainText[67], AT[3]);
                    break;
                case 61:
                    UniversalStandartDialogMainChoice(doctor_Messanger, MainText[68], AOT[21], ATT[21]);
                    if (startStep)
                    {
                        startStep = false;
                        if (PlayerPrefs.GetInt("GalleryProgress") <= 1)
                            OpenPic(2);
                    }
                    break;
            }
        }
        else if (mainChoice == 1) {
            switch (step)
            {

                case 62:
                    cLS.EditLoadLevel();
                    break;
            }
        }
        else if (mainChoice == 2)
        {
            switch (step)
            {

                case 62:
                    cLS.EditLoadLevel();
                    break;
            }
        }
        /*else if (mainChoice == 1)
        {
            switch (step)
            {
                case 62:
                    UniversalStandartDialogNNA(Doctor_Messanger, MainText0[0], NameWriter[4]);
                    break;
                case 63:
                    UniversalSliderDialogNNA(System_Messanger, MainText0[1], NameWriter[0], 10);
                    break;
                case 64:
                    UniversalStandartDialogNNA(System_Messanger, MainText0[2], NameWriter[0]);
                    break;
                case 65:
                    UniversalStandartDialog(Hero_Messanger, MainText0[3], NameWriter[2], AOT0[0], ATT0[0]);
                    break;
                case 66:
                    UniversalStandartDialogNA(Hero_Messanger, MainText0[4], NameWriter[2], AT[4]);
                    break;
                case 67:
                    UniversalStandartDialog(Hero_Messanger, MainText0[5], NameWriter[2], AOT0[1], ATT0[1]);
                    break;
                case 68:
                    UniversalStandartDialogNNA(Hero_Messanger, MainText0[6], NameWriter[2]);
                    break;
                case 69:
                    UniversalStandartDialogNNA(Hero_Messanger, MainText0[7], NameWriter[2]);
                    break;
                case 70:
                    UniversalStandartDialogNNA(System_Messanger, MainText0[8], NameWriter[0]);
                    break;
                case 71:
                    UniversalSliderDialogNNA(System_Messanger, MainText0[9], NameWriter[0], 10);
                    break;
                case 72:
                    UniversalSliderDialogNNA(System_Messanger, MainText0[10], NameWriter[0], 10);
                    break;
                case 73:
                    UniversalStandartDialog(Hero_Messanger, MainText0[11], NameWriter[2], AOT0[2], ATT0[2]);
                    break;
                case 74:
                    UniversalStandartDialogNA(Hero_Messanger, MainText0[12], NameWriter[2], AT[5]);
                    break;
                case 75:
                    UniversalStandartDialogNNA(Hero_Messanger, MainText0[13], NameWriter[2]);
                    break;
                case 76:
                    UniversalSliderDialogNNA(System_Messanger, MainText0[14], NameWriter[0], 15);
                    break;
                case 77:
                    UniversalStandartDialogNNA(System_Messanger, MainText0[15], NameWriter[0]);
                    break;
                case 78:
                    UniversalSliderDialogNNA(System_Messanger, MainText0[16], NameWriter[0], 10);
                    break;
                case 79:
                    UniversalStandartDialogNNA(System_Messanger, MainText0[17], NameWriter[0]);
                    break;
                case 80:
                    UniversalStandartDialogNNA(System_Messanger, MainText0[18], NameWriter[0]);
                    break;
                case 81:
                    UniversalStandartDialogNNA(System_Messanger, MainText0[19], NameWriter[0]);
                    break;
                case 82:
                    UniversalSliderDialogNNA(System_Messanger, MainText0[20], NameWriter[0], 15);
                    break;
                case 83:
                    UniversalStandartDialogNNA(System_Messanger, MainText0[21], NameWriter[0]);
                    break;
                case 84:
                    UniversalStandartDialog(System_Messanger, MainText0[22], NameWriter[0], AOT0[3], ATT0[3]);
                    break;
                case 85:
                    UniversalStandartDialogNNA(Hero_Messanger, MainText0[23], NameWriter[2]);
                    break;
                case 86:
                    UniversalStandartDialogNNA(System_Messanger, MainText0[24], NameWriter[0]);
                    break;
                case 87:
                    UniversalStandartDialog(Doctor_Messanger, MainText0[25], NameWriter[4], AOT0[4], ATT0[4]);
                    break;
                case 88:
                    UniversalStandartDialogNNA(System_Messanger, MainText0[26], NameWriter[0]);
                    break;
                case 89:
                    UniversalStandartDialogNNAFinal(System_Messanger, MainText0[27], NameWriter[0]);
                    if (startStep)
                    {
                        startStep = false;
                        if(PlayerPrefs.GetInt("GalleryProgress") == 3)
                            OpenPic(3);
                        else if (PlayerPrefs.GetInt("GalleryProgress") == 4)
                            OpenPic(4);

                    }
                    break;
            }
        }
        else if (mainChoice == 2)
        {
            switch (step)
            {
                case 62:
                    UniversalStandartDialog(Doctor_Messanger, MainText1[0], NameWriter[4], AOT1[0], ATT1[0]);
                    break;
                case 63:
                    UniversalStandartDialogNNA(Doctor_Messanger, MainText1[1], NameWriter[4]);
                    break;
                case 64:
                    UniversalStandartDialogNNA(System_Messanger, MainText1[2], NameWriter[0]);
                    break;
                case 65:
                    UniversalStandartDialogNA(System_Messanger, MainText1[3], NameWriter[0], AT[6]);
                    break;
                case 66:
                    UniversalCountdownDialogNNA(System_Messanger, MainText1[4], NameWriter[0], 5);
                    break;
                case 67:
                    UniversalStandartDialogPreMultiDialog(System_Messanger, MainText1[5], NameWriter[0], AOT1[1], ATT1[1]);
                    break;
                case 68:
                    switch (ButtonNumber)
                    {
                        case 2:
                            UniversalDeadDialog(System_Messanger, MainText[6], NameWriter[0], AOT[2], ATT[2]);
                            break;
                        case 1:
                            UniversalStandartDialogNA(System_Messanger, MainText1[6], NameWriter[0], AT[6]);
                            break;
                    }
                    break;
                case 69:
                    UniversalStandartDialogNA(System_Messanger, MainText1[7], NameWriter[0], AT[7]);
                    break;
                case 70:
                    UniversalStandartDialogNNA(System_Messanger, MainText1[8], NameWriter[0]);
                    break;
                case 71:
                    UniversalStandartDialog(Hero_Messanger, MainText1[9], NameWriter[2], AOT1[2], ATT1[2]);
                    break;
                case 72:
                    UniversalStandartDialogNA(Hero_Messanger, MainText1[10], NameWriter[2], AT[8]);
                    break;
                case 73:
                    UniversalStandartDialogNA(Hero_Messanger, MainText1[11], NameWriter[2], AT[9]);
                    break;
                case 74:
                    UniversalStandartDialog(Hero_Messanger, MainText1[12], NameWriter[2], AOT1[3], ATT1[3]);
                    break;
                case 75:
                    UniversalStandartDialog(Hero_Messanger, MainText1[13], NameWriter[2], AOT1[4], ATT1[4]);
                    break;
                case 76:
                    UniversalStandartDialog(Hero_Messanger, MainText1[14], NameWriter[2], AOT1[5], ATT1[5]);
                    break;
                case 77:
                    UniversalStandartDialog(Hero_Messanger, MainText1[15], NameWriter[2], AOT1[6], ATT1[6]);
                    break;
                case 78:
                    UniversalStandartDialogNNA(Hero_Messanger, MainText1[16], NameWriter[2]);
                    break;
                case 79:
                    UniversalStandartDialogNNA(System_Messanger, MainText1[17], NameWriter[0]);
                    break;
                case 80:
                    UniversalStandartDialogNNA(System_Messanger, MainText1[18], NameWriter[0]);
                    break;
                case 81:
                    UniversalStandartDialogNNA(System_Messanger, MainText1[19], NameWriter[0]);
                    break;
                case 82:
                    UniversalStandartDialogNNA(Doctor_Messanger, MainText1[20], NameWriter[4]);
                    break;
                case 83:
                    UniversalStandartDialogNA(Hero_Messanger, MainText1[21], NameWriter[2], AT[10]);
                    break;
                case 84:
                    UniversalCountdownDialogNNA(Hero_Messanger, MainText1[22], NameWriter[2], 0.12);
                    break;
                case 85:
                    UniversalStandartDialogNA(Hero_Messanger, MainText1[23], NameWriter[2], AT[11]);
                    break;
                case 86:
                    UniversalCountdownDialogNNA(Hero_Messanger, MainText1[24], NameWriter[2], 6);
                    break;
                case 87:
                    UniversalStandartDialog(Hero_Messanger, MainText1[25], NameWriter[2], AOT1[7], ATT1[7]);
                    break;
                case 88:
                    UniversalStandartDialog(Hero_Messanger, MainText1[26], NameWriter[2], AOT1[8], ATT1[8]);
                    break;
                case 89:
                    UniversalStandartDialogNNA(Hero_Messanger, MainText1[27], NameWriter[2]);
                    break;
                case 90:
                    UniversalSliderDialogNNA(Hero_Messanger, MainText1[28], NameWriter[2], 10);
                    break;
                case 91:
                    UniversalStandartDialog(Hero_Messanger, MainText1[29], NameWriter[2], AOT1[9], ATT1[9]);
                    break;
                case 92:
                    UniversalStandartDialog(Hero_Messanger, MainText1[30], NameWriter[2], AOT1[10], ATT1[10]);
                    break;
                case 93:
                    UniversalStandartDialogNA(Hero_Messanger, MainText1[31], NameWriter[2], AT[12]);
                    break;
                case 94:
                    UniversalStandartDialog(Hero_Messanger, MainText1[32], NameWriter[2], AOT1[11], ATT1[11]);
                    break;
                case 95:
                    UniversalStandartDialog(Hero_Messanger, MainText1[33], NameWriter[2], AOT1[12], ATT1[12]);
                    break;
                case 96:
                    UniversalStandartDialog(Hero_Messanger, MainText1[34], NameWriter[2], AOT1[13], ATT1[13]);
                    break;
                case 97:
                    UniversalStandartDialogNA(Hero_Messanger, MainText1[35], NameWriter[2], AT[13]);
                    break;
                case 98:
                    UniversalStandartDialogNNA(System_Messanger, MainText1[36], NameWriter[0]);
                    break;
                case 99:
                    UniversalSliderDialogNNA(System_Messanger, MainText1[37], NameWriter[0], 15);
                    break;
                case 100:
                    UniversalStandartDialogNNA(NoName_Messanger, MainText1[38], NameWriter[3]);
                    break;
                case 101:
                    UniversalStandartDialogNNA(NoName_Messanger, MainText1[39], NameWriter[3]);
                    break;
                case 102:
                    UniversalStandartDialogNNA(NoName_Messanger, MainText1[40], NameWriter[3]);
                    break;
                case 103:
                    UniversalStandartDialogNNA(NoName_Messanger, MainText1[41], NameWriter[3]);
                    break;
                case 104:
                    UniversalStandartDialog(Hero_Messanger, MainText1[42], NameWriter[2], AOT1[14], ATT1[14]);
                    break;
                case 105:
                    UniversalStandartDialogNNA(Hero_Messanger, MainText1[43], NameWriter[2]);
                    break;
                case 106:
                    UniversalStandartDialogNNA(Hero_Messanger, MainText1[44], NameWriter[2]);
                    break;
                case 107:
                    UniversalStandartDialogNNA(NoName_Messanger, MainText1[45], NameWriter[3]);
                    break;
                case 108:
                    UniversalStandartDialogNNA(Hero_Messanger, MainText1[46], NameWriter[2]);
                    break;
                case 109:
                    UniversalStandartDialogNNA(NoName_Messanger, MainText1[47], NameWriter[3]);
                    break;
                case 110:
                    UniversalStandartDialogNNA(NoName_Messanger, MainText1[48], NameWriter[3]);
                    break;
                case 111:
                    UniversalStandartDialogNNA(NoName_Messanger, MainText1[49], NameWriter[3]);
                    break;
                case 112:
                    UniversalStandartDialogNNA(Hero_Messanger, MainText1[50], NameWriter[2]);
                    break;
                case 113:
                    UniversalStandartDialogNNA(NoName_Messanger, MainText1[51], NameWriter[3]);
                    break;
                case 114:
                    UniversalStandartDialogNNA(NoName_Messanger, MainText1[52], NameWriter[3]);
                    break;
                case 115:
                    UniversalStandartDialogNNA(NoName_Messanger, MainText1[53], NameWriter[3]);
                    break;
                case 116:
                    UniversalStandartDialogNNA(Doctor_Messanger, MainText1[54], NameWriter[4]);
                    break;
                case 117:
                    UniversalStandartDialogNNA(NoName_Messanger, MainText1[55], NameWriter[3]);
                    break;
                case 118:
                    UniversalStandartDialogNNA(Doctor_Messanger, MainText1[56], NameWriter[4]);
                    break;
                case 119:
                    UniversalStandartDialogNNAFinal(System_Messanger, MainText1[57], NameWriter[0]);
                    if (startStep)
                    {
                        startStep = false;
                        if (PlayerPrefs.GetInt("GalleryProgress") == 3)
                            OpenPic(3);
                        else if (PlayerPrefs.GetInt("GalleryProgress") == 4)
                            OpenPic(4);

                    }
                    break;
            }
        }
        */
    }
    void OpenPic(int i)
    {
        PlayerPrefs.SetInt("GalleryProgress", i);
        PlayerPrefs.Save();
        galleryPushAnimator.SetActive(true);
        if (!settings.close)
        {
            settings.animator.SetTrigger("Close");
        }
    }

    void AutoSave()
    {
        if(!settings.close)
        {
            settings.animator.SetTrigger("Close");
        }
        autosaveLogo.SetActive(true);
    }
    public void NewGame()
    {
        printingMainTextFinality = false;
        printingAnswerOneFinality = false;
        printingAnswerTwoFinality = false;
        printingNAFinality = false;
        deletingMainTextFinality = false;
        deletingAnswerOneFinality = false;
        deletingAnswerTwoFinality = false;
        deletingNAFinality = false;
        step = 1;
        mainChoice = 0;
        _mainChoice = 0;
        readinessToButtonPressed = false;
        speedPrintingText = PlayerPrefs.GetInt("ValueSliderSpeedPrinting");
        speedDeletingText = PlayerPrefs.GetInt("ValueSliderSpeedDeleting");
        if (PlayerPrefs.GetInt("InstantPrinting") == 0)
            iPrint = false;
        else
            iPrint = true;
        return;
    }
    public void Save()
    {
        PlayerPrefs.SetFloat("SoundValue", audioSlider.value);


        PlayerPrefs.SetFloat("SliderTimeValue", sliderTime.value);
        PlayerPrefs.SetFloat("SliderMaxValue", sliderTime.maxValue);

        print("save sliderTime.value = " + sliderTime.value);
        print("save sliderTime.maxValue = " + sliderTime.maxValue);







        if (timerStart)
        {
            PlayerPrefs.SetInt("timerStart", 1);
        }
        else if (!timerStart)
        {
            PlayerPrefs.SetInt("timerStart", 0);
        }

        if (timerFinality)
        {
            PlayerPrefs.SetInt("timerFinality", 1);
        }
        else if (!timerFinality)
        {
            PlayerPrefs.SetInt("timerFinality", 0);
        }

        PlayerPrefs.SetInt("MainChoice", mainChoice);

        PlayerPrefs.SetInt("StartEventTimeYear", eventStartTimeYear);
        PlayerPrefs.SetInt("StartEventTimeMonth", eventStartTimeMonth);
        PlayerPrefs.SetInt("StartEventTimeDay", eventStartTimeDays);
        PlayerPrefs.SetInt("StartEventTimeHourse", eventStartTimeHourse);
        PlayerPrefs.SetInt("StartEventTimeMinutes", eventStartTimeMinutes);
        PlayerPrefs.SetInt("StartEventTimeSeconds", eventStartTimeSeconds);
        PlayerPrefs.SetInt("FinalEventTimeYear", eventFinalTimeYear);
        PlayerPrefs.SetInt("FinalEventTimeMonth", eventFinalTimeMonth);
        PlayerPrefs.SetInt("FinalEventTimeDay", eventFinalTimeDays);
        PlayerPrefs.SetInt("FinalEventTimeHourse", eventFinalTimeHourse);
        PlayerPrefs.SetInt("FinalEventTimeMinutes", eventFinalTimeMinutes);
        PlayerPrefs.SetInt("FinalEventTimeSeconds", eventFinalTimeSeconds);



        PlayerPrefs.SetFloat("RColorMainText", (int)mainText.color.r);
        PlayerPrefs.SetFloat("GColorMainText", (int)mainText.color.g);
        PlayerPrefs.SetFloat("BColorMainText", (int)mainText.color.b);
        PlayerPrefs.SetFloat("AColorMainText", (int)mainText.color.a);

        if (startCountdown)
        {
            PlayerPrefs.SetInt("startCountdown", 1);
        }
        else if (!startCountdown)
        {
            PlayerPrefs.SetInt("startCountdown", 0);
        }

        if (finishCountdown)
        {
            PlayerPrefs.SetInt("finishCountdown", 1);
        }
        else if (!finishCountdown)
        {
            PlayerPrefs.SetInt("finishCountdown", 0);
        }

        if (readinessToButtonPressed)
        {
            PlayerPrefs.SetInt("readinessToButtonPressed", 1);
        }
        else if (!readinessToButtonPressed)
        {
            PlayerPrefs.SetInt("readinessToButtonPressed", 0);
        }

        if (!buttonOptionOne.activeSelf)
        {
            PlayerPrefs.SetInt("EnabledOneAnswerText", 0);
        }
        else if (buttonOptionOne.activeSelf)
        {
            PlayerPrefs.SetInt("EnabledOneAnswerText", 1);
        }

        if (!buttonOptionTwo.activeSelf)
        {
            PlayerPrefs.SetInt("EnabledTwoAnswerText", 0);
        }
        else if (buttonOptionTwo.activeSelf)
        {
            PlayerPrefs.SetInt("EnabledTwoAnswerText", 1);
        }


        PlayerPrefs.SetString("MainText", mainText.text);
        PlayerPrefs.SetString("OneAnswerText", optionOneText.text);
        PlayerPrefs.SetString("TwoAnswerText", optionTwoText.text);
        PlayerPrefs.SetInt("step", step);
        PlayerPrefs.SetInt("subSteps", substeps);
        if (!printingMainTextFinality)
        {
            PlayerPrefs.SetInt("printingMainTextFinality", 0);
        }
        else if (printingMainTextFinality)
        {
            PlayerPrefs.SetInt("printingMainTextFinality", 1);
        }

        if (!printingAnswerOneFinality)
        {
            PlayerPrefs.SetInt("printingAnswerOneFinality", 0);
        }
        else if (printingAnswerOneFinality)
        {
            PlayerPrefs.SetInt("printingAnswerOneFinality", 1);
        }

        if (!printingAnswerTwoFinality)
        {
            PlayerPrefs.SetInt("printingAnswerTwoFinality", 0);
        }
        else if (printingAnswerTwoFinality)
        {
            PlayerPrefs.SetInt("printingAnswerTwoFinality", 1);
        }

        if (!deletingMainTextFinality)
        {
            PlayerPrefs.SetInt("deletingMainTextFinality", 0);
        }
        else if (deletingMainTextFinality)
        {
            PlayerPrefs.SetInt("deletingMainTextFinality", 1);
        }

        if (!deletingAnswerOneFinality)
        {
            PlayerPrefs.SetInt("deletingAnswerOneFinality", 0);
        }
        else if (deletingAnswerOneFinality)
        {
            PlayerPrefs.SetInt("deletingAnswerOneFinality", 1);
        }

        if (!deletingAnswerTwoFinality)
        {
            PlayerPrefs.SetInt("deletingAnswerTwoFinality", 0);
        }
        else if (deletingAnswerTwoFinality)
        {
            PlayerPrefs.SetInt("deletingAnswerTwoFinality", 1);
        }

        if (ButtonPressed)
        {
            PlayerPrefs.SetInt("ButtonPressed", 1);
        }
        else if (!ButtonPressed)
        {
            PlayerPrefs.SetInt("ButtonPressed", 0);
        }

        if (printingNAFinality)
        {
            PlayerPrefs.SetInt("printingNAFinality", 1);
        }
        else if (!printingNAFinality)
        {
            PlayerPrefs.SetInt("printingNAFinality", 0);
        }

        if (deletingNAFinality)
        {
            PlayerPrefs.SetInt("deletingNAFinality", 1);
        }
        else if (!deletingNAFinality)
        {
            PlayerPrefs.SetInt("deletingNAFinality", 0);
        }
        PlayerPrefs.SetString("InputFieldText", inputField.text);
        PlayerPrefs.SetInt("ButtonNumber", buttonNumber);
        PlayerPrefs.Save();
    }


    public void CheckPointSave()
    {

        PlayerPrefs.SetInt("CPMainChoice", mainChoice);

        PlayerPrefs.SetInt("CPStartEventTimeYear", eventStartTimeYear);
        PlayerPrefs.SetInt("CPStartEventTimeMonth", eventStartTimeMonth);
        PlayerPrefs.SetInt("CPStartEventTimeDay", eventStartTimeDays);
        PlayerPrefs.SetInt("CPStartEventTimeHourse", eventStartTimeHourse);
        PlayerPrefs.SetInt("CPStartEventTimeMinutes", eventStartTimeMinutes);
        PlayerPrefs.SetInt("CPStartEventTimeSeconds", eventStartTimeSeconds);
        PlayerPrefs.SetInt("CPFinalEventTimeYear", eventFinalTimeYear);
        PlayerPrefs.SetInt("CPFinalEventTimeMonth", eventFinalTimeMonth);
        PlayerPrefs.SetInt("CPFinalEventTimeDay", eventFinalTimeDays);
        PlayerPrefs.SetInt("CPFinalEventTimeHourse", eventFinalTimeHourse);
        PlayerPrefs.SetInt("CPFinalEventTimeMinutes", eventFinalTimeMinutes);
        PlayerPrefs.SetInt("CPFinalEventTimeSeconds", eventFinalTimeSeconds);



        PlayerPrefs.SetFloat("CPRColorMainText", (int)mainText.color.r);
        PlayerPrefs.SetFloat("CPGColorMainText", (int)mainText.color.g);
        PlayerPrefs.SetFloat("CPBColorMainText", (int)mainText.color.b);
        PlayerPrefs.SetFloat("CPAColorMainText", (int)mainText.color.a);

        if (startCountdown)
        {
            PlayerPrefs.SetInt("CPstartCountdown", 1);
        }
        else if (!startCountdown)
        {
            PlayerPrefs.SetInt("CPstartCountdown", 0);
        }

        if (finishCountdown)
        {
            PlayerPrefs.SetInt("CPfinishCountdown", 1);
        }
        else if (!finishCountdown)
        {
            PlayerPrefs.SetInt("CPfinishCountdown", 0);
        }

        if (readinessToButtonPressed)
        {
            PlayerPrefs.SetInt("CPreadinessToButtonPressed", 1);
        }
        else if (!readinessToButtonPressed)
        {
            PlayerPrefs.SetInt("CPreadinessToButtonPressed", 0);
        }

        if (!buttonOptionOne.activeSelf)
        {
            PlayerPrefs.SetInt("CPEnabledOneAnswerText", 0);
        }
        else if (buttonOptionOne.activeSelf)
        {
            PlayerPrefs.SetInt("CPEnabledOneAnswerText", 1);
        }

        if (!buttonOptionTwo.activeSelf)
        {
            PlayerPrefs.SetInt("CPEnabledTwoAnswerText", 0);
        }
        else if (buttonOptionTwo.activeSelf)
        {
            PlayerPrefs.SetInt("CPEnabledTwoAnswerText", 1);
        }

        PlayerPrefs.SetFloat("CPValueSlider", sliderTime.value);

        PlayerPrefs.SetString("CPMainText", mainText.text);
        PlayerPrefs.SetString("CPOneAnswerText", optionOneText.text);
        PlayerPrefs.SetString("CPTwoAnswerText", optionTwoText.text);
        PlayerPrefs.SetInt("CPstep", step);
        PlayerPrefs.SetInt("CPsubSteps", substeps);
        if (!printingMainTextFinality)
        {
            PlayerPrefs.SetInt("CPprintingMainTextFinality", 0);
        }
        else if (printingMainTextFinality)
        {
            PlayerPrefs.SetInt("CPprintingMainTextFinality", 1);
        }

        if (!printingAnswerOneFinality)
        {
            PlayerPrefs.SetInt("CPprintingAnswerOneFinality", 0);
        }
        else if (printingAnswerOneFinality)
        {
            PlayerPrefs.SetInt("CPprintingAnswerOneFinality", 1);
        }

        if (!printingAnswerTwoFinality)
        {
            PlayerPrefs.SetInt("CPprintingAnswerTwoFinality", 0);
        }
        else if (printingAnswerTwoFinality)
        {
            PlayerPrefs.SetInt("CPprintingAnswerTwoFinality", 1);
        }

        if (!deletingMainTextFinality)
        {
            PlayerPrefs.SetInt("CPdeletingMainTextFinality", 0);
        }
        else if (deletingMainTextFinality)
        {
            PlayerPrefs.SetInt("CPdeletingMainTextFinality", 1);
        }

        if (!deletingAnswerOneFinality)
        {
            PlayerPrefs.SetInt("CPdeletingAnswerOneFinality", 0);
        }
        else if (deletingAnswerOneFinality)
        {
            PlayerPrefs.SetInt("CPdeletingAnswerOneFinality", 1);
        }

        if (!deletingAnswerTwoFinality)
        {
            PlayerPrefs.SetInt("CPdeletingAnswerTwoFinality", 0);
        }
        else if (deletingAnswerTwoFinality)
        {
            PlayerPrefs.SetInt("CPdeletingAnswerTwoFinality", 1);
        }

        if (ButtonPressed)
        {
            PlayerPrefs.SetInt("CPButtonPressed", 1);
        }
        else if (!ButtonPressed)
        {
            PlayerPrefs.SetInt("CPButtonPressed", 0);
        }

        if (printingNAFinality)
        {
            PlayerPrefs.SetInt("CPprintingNAFinality", 1);
        }
        else if (!printingNAFinality)
        {
            PlayerPrefs.SetInt("CPprintingNAFinality", 0);
        }

        if (deletingNAFinality)
        {
            PlayerPrefs.SetInt("CPdeletingNAFinality", 1);
        }
        else if (!deletingNAFinality)
        {
            PlayerPrefs.SetInt("CPdeletingNAFinality", 0);
        }
        PlayerPrefs.SetString("CPInputFieldText", inputField.text);

        PlayerPrefs.SetInt("CPButtonNumber", buttonNumber);

        PlayerPrefs.Save();
    }



    public void Load()
    {
        sliderTime.maxValue = PlayerPrefs.GetFloat("SliderMaxValue");
        sliderTime.value = PlayerPrefs.GetFloat("SliderTimeValue");
        //sliderTime.maxValue = PlayerPrefs.GetFloat("SliderMaxValue");
        print("load sliderTime.value = " + sliderTime.value);
        print("load sliderTime.maxValue = " + sliderTime.maxValue);

        audioSlider.value = PlayerPrefs.GetFloat("SoundValue");
        playerName = PlayerPrefs.GetString("Name");
        mainChoice = PlayerPrefs.GetInt("MainChoice");
        eventStartTimeYear = PlayerPrefs.GetInt("StartEventTimeYear");
        eventStartTimeMonth = PlayerPrefs.GetInt("StartEventTimeMonth");
        eventStartTimeDays = PlayerPrefs.GetInt("StartEventTimeDay");
        eventStartTimeHourse = PlayerPrefs.GetInt("StartEventTimeHourse");
        eventStartTimeMinutes = PlayerPrefs.GetInt("StartEventTimeMinutes");
        eventStartTimeSeconds = PlayerPrefs.GetInt("StartEventTimeSeconds");
        eventFinalTimeYear = PlayerPrefs.GetInt("FinalEventTimeYear");
        eventFinalTimeMonth = PlayerPrefs.GetInt("FinalEventTimeMonth");
        eventFinalTimeDays = PlayerPrefs.GetInt("FinalEventTimeDay");
        eventFinalTimeHourse = PlayerPrefs.GetInt("FinalEventTimeHourse");
        eventFinalTimeMinutes = PlayerPrefs.GetInt("FinalEventTimeMinutes");
        eventFinalTimeSeconds = PlayerPrefs.GetInt("FinalEventTimeSeconds");

        speedPrintingText = PlayerPrefs.GetInt("ValueSliderSpeedPrinting");
        speedDeletingText = PlayerPrefs.GetInt("ValueSliderSpeedDeleting");

        inputField.text = PlayerPrefs.GetString("InputFieldText");
        Color color = new Color(PlayerPrefs.GetFloat("RColorMainText"), PlayerPrefs.GetFloat("GColorMainText"), PlayerPrefs.GetFloat("BColorMainText"), PlayerPrefs.GetFloat("AColorMainText"));
        mainText.color = color;
        if(PlayerPrefs.GetInt("InstantPrinting") == 0)
            iPrint = false;
        else
            iPrint = true;
        if (PlayerPrefs.GetInt("startCountdown") == 1)
        {
            startCountdown = true;
            timerGO.SetActive(true);
        }
        else
        {
            startCountdown = false;
            timerGO.SetActive(false);
        }

        if (PlayerPrefs.GetInt("finishCountdown") == 1)
        {
            finishCountdown = true;
        }
        else
        {
            finishCountdown = false;
        }

        if (PlayerPrefs.GetInt("readinessToButtonPressed") == 1)
        {
            readinessToButtonPressed = true;
        }
        else if (PlayerPrefs.GetInt("readinessToButtonPressed") == 0)
        {
            readinessToButtonPressed = false;
        }

        if (PlayerPrefs.GetInt("EnabledOneAnswerText") == 0)
        {
            buttonOptionOne.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("EnabledOneAnswerText") == 1)
        {
            buttonOptionOne.SetActive(true);
        }
        if (PlayerPrefs.GetInt("EnabledTwoAnswerText") == 0)
        {
            buttonOptionTwo.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("EnabledTwoAnswerText") == 1)
        {
            buttonOptionTwo.SetActive(true);
        }
        mainText.text = PlayerPrefs.GetString("MainText");
        optionOneText.text = PlayerPrefs.GetString("OneAnswerText");
        optionTwoText.text = PlayerPrefs.GetString("TwoAnswerText");

        step = PlayerPrefs.GetInt("step");
        substeps = PlayerPrefs.GetInt("subSteps");

        if (PlayerPrefs.GetInt("printingMainTextFinality") == 0)
        {
            printingMainTextFinality = false;
        }
        else if (PlayerPrefs.GetInt("printingMainTextFinality") == 1)
        {
            printingMainTextFinality = true;
        }

        if (PlayerPrefs.GetInt("printingAnswerOneFinality") == 0)
        {
            printingAnswerOneFinality = false;
        }
        else if (PlayerPrefs.GetInt("printingAnswerOneFinality") == 1)
        {
            printingAnswerOneFinality = true;
        }

        if (PlayerPrefs.GetInt("printingAnswerTwoFinality") == 0)
        {
            printingAnswerTwoFinality = false;
        }
        else if (PlayerPrefs.GetInt("printingAnswerTwoFinality") == 1)
        {
            printingAnswerTwoFinality = true;
        }

        if (PlayerPrefs.GetInt("deletingMainTextFinality") == 0)
        {
            deletingMainTextFinality = false;
        }
        else if (PlayerPrefs.GetInt("deletingMainTextFinality") == 1)
        {
            deletingMainTextFinality = true;
        }

        if (PlayerPrefs.GetInt("deletingAnswerOneFinality") == 0)
        {
            deletingAnswerOneFinality = false;
        }
        else if (PlayerPrefs.GetInt("deletingAnswerOneFinality") == 1)
        {
            deletingAnswerOneFinality = true;
        }

        if (PlayerPrefs.GetInt("deletingAnswerTwoFinality") == 0)
        {
            deletingAnswerTwoFinality = false;
        }
        else if (PlayerPrefs.GetInt("deletingAnswerTwoFinality") == 1)
        {
            deletingAnswerTwoFinality = true;
        }

        if (PlayerPrefs.GetInt("ButtonPressed") == 1)
        {
            ButtonPressed = true;
        }
        else if (PlayerPrefs.GetInt("ButtonPressed") == 0)
        {
            ButtonPressed = false;
        }

        if (PlayerPrefs.GetInt("printingNAFinality") == 0)
        {
            printingNAFinality = false;
        }
        else if (PlayerPrefs.GetInt("printingNAFinality") == 1)
        {
            printingNAFinality = true;
        }

        if (PlayerPrefs.GetInt("deletingNAFinality") == 0)
        {
            deletingNAFinality = false;
        }
        else if (PlayerPrefs.GetInt("deletingNAFinality") == 1)
        {
            deletingNAFinality = true;
        }

        if (PlayerPrefs.GetInt("timerStart") == 1)
        {
            timerStart = true;
            slider_Process.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("timerStart") == 0)
        {
            timerStart = false;
            slider_Process.SetActive(false);
        }
        if (PlayerPrefs.GetInt("timerFinality") == 1)
        {
            timerFinality = true;
        }
        else if (PlayerPrefs.GetInt("timerFinality") == 0)
        {
            timerFinality = false;
        }

        buttonNumber = PlayerPrefs.GetInt("ButtonNumber");
    }

    public void CheckPointLoad()
    {
        mainChoice = PlayerPrefs.GetInt("CPMainChoice");
        eventStartTimeYear = PlayerPrefs.GetInt("CPStartEventTimeYear");
        eventStartTimeMonth = PlayerPrefs.GetInt("CPStartEventTimeMonth");
        eventStartTimeDays = PlayerPrefs.GetInt("CPStartEventTimeDay");
        eventStartTimeHourse = PlayerPrefs.GetInt("CPStartEventTimeHourse");
        eventStartTimeMinutes = PlayerPrefs.GetInt("CPStartEventTimeMinutes");
        eventStartTimeSeconds = PlayerPrefs.GetInt("CPStartEventTimeSeconds");
        eventFinalTimeYear = PlayerPrefs.GetInt("CPFinalEventTimeYear");
        eventFinalTimeMonth = PlayerPrefs.GetInt("CPFinalEventTimeMonth");
        eventFinalTimeDays = PlayerPrefs.GetInt("CPFinalEventTimeDay");
        eventFinalTimeHourse = PlayerPrefs.GetInt("CPFinalEventTimeHourse");
        eventFinalTimeMinutes = PlayerPrefs.GetInt("CPFinalEventTimeMinutes");
        eventFinalTimeSeconds = PlayerPrefs.GetInt("CPFinalEventTimeSeconds");

        speedPrintingText = PlayerPrefs.GetInt("ValueSliderSpeedPrinting");
        speedDeletingText = PlayerPrefs.GetInt("ValueSliderSpeedDeleting");

        inputField.text = PlayerPrefs.GetString("CPInputFieldText");
        Color color = new Color(PlayerPrefs.GetFloat("CPRColorMainText"), PlayerPrefs.GetFloat("CPGColorMainText"), PlayerPrefs.GetFloat("CPBColorMainText"), PlayerPrefs.GetFloat("CPAColorMainText"));
        mainText.color = color;
        if (PlayerPrefs.GetInt("CPInstantPrinting") == 0)
            iPrint = false;
        else
            iPrint = true;
        if (PlayerPrefs.GetInt("CPstartCountdown") == 1)
        {
            startCountdown = true;
            timerGO.SetActive(true);
        }
        else
        {
            startCountdown = false;
            timerGO.SetActive(false);
        }

        if (PlayerPrefs.GetInt("CPfinishCountdown") == 1)
        {
            finishCountdown = true;
        }
        else
        {
            finishCountdown = false;
        }

        if (PlayerPrefs.GetInt("CPreadinessToButtonPressed") == 1)
        {
            readinessToButtonPressed = true;
        }
        else if (PlayerPrefs.GetInt("CPreadinessToButtonPressed") == 0)
        {
            readinessToButtonPressed = false;
        }

        if (PlayerPrefs.GetInt("CPEnabledOneAnswerText") == 0)
        {
            buttonOptionOne.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("CPEnabledOneAnswerText") == 1)
        {
            buttonOptionOne.SetActive(true);
        }
        if (PlayerPrefs.GetInt("CPEnabledTwoAnswerText") == 0)
        {
            buttonOptionTwo.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("CPEnabledTwoAnswerText") == 1)
        {
            buttonOptionTwo.SetActive(true);
        }
        mainText.text = PlayerPrefs.GetString("CPMainText");
        optionOneText.text = PlayerPrefs.GetString("CPOneAnswerText");
        optionTwoText.text = PlayerPrefs.GetString("CPTwoAnswerText");

        step = PlayerPrefs.GetInt("CPstep");
        substeps = PlayerPrefs.GetInt("CPsubSteps");

        if (PlayerPrefs.GetInt("CPprintingMainTextFinality") == 0)
        {
            printingMainTextFinality = false;
        }
        else if (PlayerPrefs.GetInt("CPprintingMainTextFinality") == 1)
        {
            printingMainTextFinality = true;
        }

        if (PlayerPrefs.GetInt("CPprintingAnswerOneFinality") == 0)
        {
            printingAnswerOneFinality = false;
        }
        else if (PlayerPrefs.GetInt("CPprintingAnswerOneFinality") == 1)
        {
            printingAnswerOneFinality = true;
        }

        if (PlayerPrefs.GetInt("CPprintingAnswerTwoFinality") == 0)
        {
            printingAnswerTwoFinality = false;
        }
        else if (PlayerPrefs.GetInt("CPprintingAnswerTwoFinality") == 1)
        {
            printingAnswerTwoFinality = true;
        }

        if (PlayerPrefs.GetInt("CPdeletingMainTextFinality") == 0)
        {
            deletingMainTextFinality = false;
        }
        else if (PlayerPrefs.GetInt("CPdeletingMainTextFinality") == 1)
        {
            deletingMainTextFinality = true;
        }

        if (PlayerPrefs.GetInt("CPdeletingAnswerOneFinality") == 0)
        {
            deletingAnswerOneFinality = false;
        }
        else if (PlayerPrefs.GetInt("CPdeletingAnswerOneFinality") == 1)
        {
            deletingAnswerOneFinality = true;
        }

        if (PlayerPrefs.GetInt("CPdeletingAnswerTwoFinality") == 0)
        {
            deletingAnswerTwoFinality = false;
        }
        else if (PlayerPrefs.GetInt("CPdeletingAnswerTwoFinality") == 1)
        {
            deletingAnswerTwoFinality = true;
        }

        if (PlayerPrefs.GetInt("CPButtonPressed") == 1)
        {
            ButtonPressed = true;
        }
        else if (PlayerPrefs.GetInt("CPButtonPressed") == 0)
        {
            ButtonPressed = false;
        }

        if (PlayerPrefs.GetInt("CPprintingNAFinality") == 0)
        {
            printingNAFinality = false;
        }
        else if (PlayerPrefs.GetInt("CPprintingNAFinality") == 1)
        {
            printingNAFinality = true;
        }

        if (PlayerPrefs.GetInt("CPdeletingNAFinality") == 0)
        {
            deletingNAFinality = false;
        }
        else if (PlayerPrefs.GetInt("CPdeletingNAFinality") == 1)
        {
            deletingNAFinality = true;
        }

        sliderTime.value = PlayerPrefs.GetFloat("CPValueSlider");
        buttonNumber = PlayerPrefs.GetInt("CPButtonNumber");
    }

    void GlobalTimer()
    {
        if (sliderTime.value < sliderTime.maxValue & timerStart)
        {
            sliderTime.value += Time.deltaTime;
            return;
        }
        else if (sliderTime.value >= sliderTime.maxValue & timerStart)
        {
            timerStart = false;
            timerFinality = true;

            slider_Process.SetActive(false);
            return;
        }
    }

    public void LoadMainMenuNotSave()
    {
        loadScreen.SetActive(true);
        game.SetActive(false);
    }
    public void LoadMainMenuAndSave()
    {
        loadScreen.SetActive(true);
        game.SetActive(false);
        Save();
    }
    //Функция печатания главного текста, стандартный тип.
    public void MainTextPrtStd(string text)
    {
        if (!readinessToButtonPressed)
        {
            if (mainText.text.Length < text.Length)
            {
                UniversalBodyTextPrinting(text, mainText);
                return;
            }
            else if (mainText.text.Length == text.Length)
            {
                CEOPrtMTStd();
                return;
            }
        }
    }

    //Функция печатания главного текста, слайдер тип.
    public void MainTextPrtSld(string text,  float maxValue)
    {
        if (!readinessToButtonPressed)
        {
            if (mainText.text.Length < text.Length)
            {
                UniversalBodyTextPrinting(text, mainText);
                return;
            }
            else if (mainText.text.Length == text.Length & !timerStart)
            {
                CEOPrtMTSld(maxValue);
                return;
            }
        }
    }


    //Функция печатания главного текста, таймер тип.
    public void MainTextPrtCnt(string text, double addHour)
    {
        if (!readinessToButtonPressed)
        {
            if (mainText.text.Length < text.Length)
            {
                UniversalBodyTextPrinting(text, mainText);
                return;
            }
            else if (mainText.text.Length == text.Length)
            {
                CEOPrtMTCnt(addHour);
                return;
            }
        }
    }

    //Функция печатания главного текста, инпут тип.
    public void MainTextPrtInp(string text)
    {
        if (!readinessToButtonPressed)
        {
            if (mainText.text.Length < text.Length)
            {
                UniversalBodyTextPrinting(text, mainText);
                return;
            }
            else if (mainText.text.Length == text.Length)
            {
                CEOPrtMTInp();
                return;
            }
        }
    }

    //Функция печатания NA текста, стандартный тип
    public void AnswerNATextPrtStd(string text)
    {
        if (!readinessToButtonPressed & !printingNAFinality)
        {
            if (printingMainTextFinality)
            {
                if (optionNAText.text.Length < text.Length)
                {
                    UniversalBodyTextPrinting(text, optionNAText);
                    return;
                }
                else if (optionNAText.text.Length == text.Length)
                {
                    UniversalCEOPrtNAT();
                    return;
                }
            }
        }
    }

    //Функция печатания первого ответа, стандартный тип
    public void AnswerOneTextPrtStd(string text)
    {
        if (!readinessToButtonPressed & !printingAnswerOneFinality)
        {
            if (printingMainTextFinality)
            {
                if (optionOneText.text.Length < text.Length)
                {
                    UniversalBodyTextPrinting(text, optionOneText);
                    return;
                }
                else if (optionOneText.text.Length == text.Length)
                {
                    UniversalCEOPrtAOT();
                    return;
                }
            }
        }
    }
    //Функция печатания первого ответа, слайдер тип.
    public void AnswerOneTextPrtSld(string text)
    {
        if (!readinessToButtonPressed & !printingAnswerOneFinality)
        {
            if (printingMainTextFinality & sliderTime.value == sliderTime.maxValue)
            {
                if (optionOneText.text.Length < text.Length)
                {
                    UniversalBodyTextPrinting(text, optionOneText);
                    return;
                }
                else if (optionOneText.text.Length == text.Length)
                {
                    UniversalCEOPrtAOT();
                    return;
                }
            }
        }
    }

    //Функция печатания первого ответа, слайдер тип.
    public void AnswerOneTextPrtCnt(string text)
    {
        if (!readinessToButtonPressed & !printingAnswerOneFinality)
        {
            if (printingMainTextFinality & finishCountdown)
            {
                if (optionOneText.text.Length < text.Length)
                {
                    UniversalBodyTextPrinting(text, optionOneText);
                    return;
                }
                else if (optionOneText.text.Length == text.Length)
                {
                    UniversalCEOPrtAOT();
                    return;
                }
            }
        }
    }

    //Функция печатания первого ответа, инпут тип.
    public void AnswerOneTextPrtInp(string text)
    {
        if (!readinessToButtonPressed & !printingAnswerOneFinality)
        {
            if (printingMainTextFinality)
            {
                if (optionOneText.text.Length < text.Length)
                {
                    UniversalBodyTextPrinting(text, optionOneText);
                    return;
                }
                else if (optionOneText.text.Length == text.Length)
                {
                    UniversalCEOPrtAOT();
                    return;
                }
            }
        }
    }

    //Функция печатания второго ответа, стандартный тип
    public void AnswerTwoTextPrtStd(string text)
    {
        if (!readinessToButtonPressed & !printingAnswerTwoFinality)
        {
            if (printingMainTextFinality)
            {
                if (optionTwoText.text.Length < text.Length)
                {
                    UniversalBodyTextPrinting(text, optionTwoText);
                    return;
                }
                else if (optionTwoText.text.Length == text.Length)
                {
                    UniversalCEOPrtATT();
                    return;
                }
            }
        }
    }
    //Функция печатания второго ответа, слайдер тип.
    public void AnswerTwoTextPrtSld(string text)
    {
        if (!readinessToButtonPressed & !printingAnswerTwoFinality)
        {
            if (printingMainTextFinality & sliderTime.value == sliderTime.maxValue)
            {
                if (optionTwoText.text.Length < text.Length)
                {
                    UniversalBodyTextPrinting(text, optionTwoText);
                    return;
                }
                else if (optionTwoText.text.Length == text.Length)
                {
                    UniversalCEOPrtATT();
                    return;
                }
            }
        }
    }

    //Функция печатания второго ответа, слайдер тип.
    public void AnswerTwoTextPrtCnt(string text)
    {
        if (!readinessToButtonPressed & !printingAnswerTwoFinality)
        {
            if (printingMainTextFinality & finishCountdown)
            {
                if (optionTwoText.text.Length < text.Length)
                {
                    UniversalBodyTextPrinting(text, optionTwoText);
                    return;
                }
                else if (optionTwoText.text.Length == text.Length)
                {
                    UniversalCEOPrtATT();
                    return;
                }
            }
        }
    }

    //Функция печатания второго ответа, инпут тип.
    public void AnswerTwoTextPrtInp(string text)
    {
        if (!readinessToButtonPressed & !printingAnswerTwoFinality)
        {
            if (printingMainTextFinality)
            {
                if (optionTwoText.text.Length < text.Length)
                {
                    UniversalBodyTextPrinting(text, optionTwoText);
                    return;
                }
                else if (optionTwoText.text.Length == text.Length)
                {
                    UniversalCEOPrtATT();
                    return;
                }
            }
        }
    }

    //Функция удаления главного текста, универсальный тип.
    public void UniversalMainTextDlt()
    {
        if (readinessToButtonPressed)
        {
            mainText.text = "";
            UniversalCEODltMT();
            /*
            if (mainText.text.Length > 0)
            {
                UniversalBodyTextDeleting(mainText);
                return;
            }
            else if (mainText.text.Length == 0)
            {
                UniversalCEODltMT();
                return;
            }
            */
        }
    }
    //Функция удаления первого ответа, универсальный тип.
    public void UniversalAnswerOneTextDlt()
    {
        if (readinessToButtonPressed)
        {
            optionOneText.text = "";
            UniversalCEODltAOT();
            /*
            if (optionOneText.text.Length > 0)
            {
                UniversalBodyTextDeleting(optionOneText);
                return;
            }
            else if (optionOneText.text.Length == 0)
            {
                UniversalCEODltAOT();
                return;
            }
            */
        }
    }

    //Функция удаления NA ответа, универсальный тип.
    public void UniversalAnswerNATextDlt()
    {
        if (readinessToButtonPressed)
        {
            optionNAText.text = "";
            UniversalCEODltNAT();
            //if (optionNAText.text.Length > 0)
            //{
            //    UniversalBodyTextDeleting(optionNAText);
            //    return;
            //}
            //else if (optionNAText.text.Length == 0)
            //{
            //    UniversalCEODltNAT();
            //    return;
            //}
        }
    }

    //Функция удаления второго ответа, универсальный тип. 
    public void UniversalAnswerTwoTextDlt()
    {
        if (readinessToButtonPressed)
        {
            optionTwoText.text = "";
            //if (optionTwoText.text.Length > 0)
            //{
            //    UniversalBodyTextDeleting(optionTwoText);
            //    return;
            //}
            //else if (optionTwoText.text.Length == 0)
            //{
            //    UniversalCEODltATT();
            //    return;
            //}
        }
    }

    //Проверка на окончание печати главного текста, стандартный метод
    public void CEOPrtMTStd()
    {
        printingMainTextFinality = true;
    }

    //Проверка на окончание печати главного текста, слайдер тип. 
    public void CEOPrtMTSld(float maxValue)
    {
        printingMainTextFinality = true;
        slider_Process.SetActive(true);
        timerStart = true;
        sliderTime.maxValue = maxValue;
        PlayerPrefs.SetFloat("SliderMaxValue", maxValue);
        PlayerPrefs.Save();
    }
    //Проверка на окончание печати главного текста, таймер тип. 
    public void CEOPrtMTCnt(double addHour)
    {
        printingMainTextFinality = true;
        StartCountdown(addHour);
    }

    //Проверка на окончание печати главного текста, инпут тип. 
    public void CEOPrtMTInp()
    {
        printingMainTextFinality = true;
        inputField.gameObject.SetActive(true);
    }

    //Проверка на окончание печати первого ответа, стандартный метод
    public void UniversalCEOPrtAOT()
    {
        printingAnswerOneFinality = true;
    }

    public void UniversalCEOPrtNAT()
    {
        printingNAFinality = true;
    }

    //Проверка на окончание печати второго ответа, стандартный метод
    public void UniversalCEOPrtATT()
    {
        printingAnswerTwoFinality = true;
    }

    //Проверка на окончание удаления главного текста, стандартный метод
    public void UniversalCEODltMT()
    {
        deletingMainTextFinality = true;
    }

    //Проверка на окончание удаления первого ответа, стандартный метод
    public void UniversalCEODltAOT()
    {
        deletingAnswerOneFinality = true;
    }

    public void UniversalCEODltNAT()
    {
        deletingNAFinality = true;
    }

    //Проверка на окончание удаления второго ответа, стандартный метод
    public void UniversalCEODltATT()
    {
        deletingAnswerTwoFinality = true;
    }

    void PrsBtnStd()
    {
        if (printingMainTextFinality & !(deletingAnswerOneFinality & deletingAnswerTwoFinality))
        {
            UniversalOnEnabledButton();
            return;
        }
        else if (deletingAnswerOneFinality & deletingAnswerTwoFinality)
        {
            UniversalOffEnabledButton();
            return;
        }
        else
        {
            UniversalOffEnabledButton();
            return;
        }
    }


    void PrsBtnNAStd()
    {
        if (printingMainTextFinality & !ButtonPressed)
        {
            UniversalOnEnabledNAButton();
            return;
        }
        else if (ButtonPressed)
        {
            UniversalOffEnabledNAButton();
            return;
        }
        else
        {
            UniversalOffEnabledNAButton();
            return;
        }
    }
    void PrsBtnStdNNA()
    {
        if (printingMainTextFinality & !ButtonPressed)
        {
            UniversalOnEnabledButtonNNA();
            return;
        }
        else if (ButtonPressed)
        {
            UniversalOffEnabledButtonNNA();
            return;
        }
        else
        {
            UniversalOffEnabledButtonNNA();
            return;
        }
    }

    void PrsBtnSldNNA()
    {
        if (printingMainTextFinality & sliderTime.value == sliderTime.maxValue & !ButtonPressed)
        {
            UniversalOnEnabledButtonNNA();
            return;
        }
        else if (ButtonPressed)
        {
            UniversalOffEnabledButtonNNA();
            return;
        }
        else
        {
            UniversalOffEnabledButtonNNA();
            return;
        }
    }

    void PrsBtnSld()
    {
        if (printingMainTextFinality & sliderTime.value == sliderTime.maxValue & !deletingAnswerOneFinality & !deletingAnswerTwoFinality)
        {
            UniversalOnEnabledButton();
            return;
        }
        else if (!printingMainTextFinality)
        {
            UniversalOffEnabledButton();
            return;
        }
        else if (deletingAnswerOneFinality & deletingAnswerTwoFinality)
        {
            UniversalOffEnabledButton();
            return;
        }
    }

    void PrsBtnCnt()
    {
        if (printingMainTextFinality & finishCountdown & !deletingAnswerOneFinality & !deletingAnswerTwoFinality)
        {
            UniversalOnEnabledButton();
            return;
        }
        else if (!printingMainTextFinality)
        {
            UniversalOffEnabledButton();
            return;
        }
        else if (deletingAnswerOneFinality & deletingAnswerTwoFinality)
        {
            UniversalOffEnabledButton();
            return;
        }
    }

    void PrsBtnCntNNA()
    {
        if (printingMainTextFinality & finishCountdown)
        {
            UniversalOnEnabledButtonNNA();
            return;
        }
        else if (!printingMainTextFinality)
        {
            UniversalOffEnabledButtonNNA();
            return;
        }
    }

    void PrsBtnInp()
    {
        if (printingMainTextFinality & !ButtonPressed)
        {
            UniversalOnEnabledButtonNNA();
            return;
        }
        else if (ButtonPressed)
        {
            UniversalOffEnabledButtonNNA();
            inputField.gameObject.SetActive(false);
            return;
        }
        else
        {
            UniversalOffEnabledButtonNNA();
            inputField.gameObject.SetActive(false);
            return;
        }
    }

    public void NextStepStd()
    {
        if (deletingMainTextFinality)
        {
            UniversalNextStepAction();
            UniversalOffEnabledButton();
            UniversalIterationStep();
            Save();
            return;
        }
    }

    public void NextStepStdMC()
    {
        if (deletingMainTextFinality)
        {
            UniversalNextStepAction();
            UniversalOffEnabledButton();
            UniversalIterationStep();
            mainChoice = _mainChoice;
            Save();
            return;
        }
    }
    public void NextStepStdNA()
    {
        if (deletingMainTextFinality & deletingNAFinality)
        {
            UniversalNextStepAction();
            UniversalOffEnabledButton();
            UniversalOffEnabledNAButton();
            UniversalIterationStep();
            Save();
            return;
        }
    }

    public void NextStepStdNNA()
    {
        if (deletingMainTextFinality)
        {
            UniversalNextStepAction();
            UniversalOffEnabledButton();
            UniversalOffEnabledButtonNNA();
            UniversalIterationStep();
            Save();
            return;
        }
    }

    public void NextStepStdNNAFinal()
    {
        if (deletingMainTextFinality)
        {
            Save();
            SceneManager.LoadScene("The end");
            return;
        }
    }

    public void NextStepSld()
    {
        if (deletingMainTextFinality)
        {
            UniversalNextStepAction();
            UniversalOffEnabledButton();
            UniversalIterationStep();
            timerStart = false;
            timerFinality = false;
            sliderTime.value = 0;

            slider_Process.SetActive(false);
            Save();
            return;
        }
    }

    public void NextStepSldNNA()
    {
        if (deletingMainTextFinality)
        {
            UniversalNextStepAction();
            UniversalOffEnabledButton();
            UniversalOffEnabledButtonNNA();
            UniversalIterationStep();
            timerStart = false;
            timerFinality = false;
            sliderTime.value = 0;

            slider_Process.SetActive(false);
            Save();
            return;
        }
    }

    public void NextStepCnt()
    {
        if (deletingMainTextFinality)
        {
            UniversalNextStepAction();
            UniversalOffEnabledButton();
            UniversalIterationStep();
            finishCountdown = false;
            startCountdown = false;
            Save();
            return;
        }
    }

    public void NextStepCntNNA()
    {
        if (deletingMainTextFinality)
        {
            UniversalNextStepAction();
            UniversalOffEnabledButton();
            UniversalOffEnabledButtonNNA();
            UniversalIterationStep();
            finishCountdown = false;
            timerGO.SetActive(false);
            startCountdown = false;
            Save();
            return;
        }
    }

    public void NextStepInp()
    {
        if (deletingMainTextFinality)
        {
            UniversalNextStepAction();
            UniversalOffEnabledButton();
            UniversalOffEnabledButtonNNA();
            UniversalIterationStep();
            playerName = inputField.text;
            PlayerPrefs.SetString("Name", playerName);
            PlayerPrefs.Save();
            inputField.gameObject.SetActive(false);
            Save();
            return;
        }
    }

    public void NextStepDead()
    {
        if (deletingMainTextFinality)
        {
            UniversalNextStepAction();
            return;
        }
    }

    public void NextStepMultiSteps()
    {
        if (deletingMainTextFinality)
        {
            UniversalNextStepAction();
            UniversalOffEnabledButton();
            UniversalOffEnabledButtonNNA();
            substeps++;
            Save();
            return;
        }
    }

    public void NextStepMultiStepsNNA()
    {
        if (deletingMainTextFinality)
        {
            UniversalNextStepAction();
            UniversalOffEnabledButton();
            UniversalOffEnabledButtonNNA();
            Save();
            substeps++;
            return;
        }
    }

    public void ReButtonNumber()
    {
        if (!printingMainTextFinality)
        {
            buttonNumber = 0;
            return;
        }
    }

    public void StartSave()
    {
        if (startStep)
        {
            CheckPointSave();
            AutoSave();
            startStep = false;
            return;
        }
    }

    void UniversalNextStepAction()
    {
        printingMainTextFinality = false;
        printingAnswerOneFinality = false;
        printingAnswerTwoFinality = false;
        printingNAFinality = false;
        deletingMainTextFinality = false;
        deletingAnswerOneFinality = false;
        deletingAnswerTwoFinality = false;
        deletingNAFinality = false;
        readinessToButtonPressed = false;
        ButtonPressed = false;
        startStep = true;
        optionNAText.text = "";
        optionOneText.text = "";
        optionTwoText.text = "";
        mainText.text = "";
        galleryPushAnimator.SetActive(false);
        autosaveLogo.SetActive(false);
        return;
    }

    void UniversalOffEnabledButton()
    {
        buttonOptionOne.SetActive(false);
        buttonOptionTwo.SetActive(false);
    }
    void UniversalOffEnabledButtonNNA()
    {
        buttonNNA.SetActive(false);
        buttonOptionOne.SetActive(false);
        buttonOptionTwo.SetActive(false);
    }

    void UniversalOnEnabledButton()
    {
        buttonOptionOne.SetActive(true);
        buttonOptionTwo.SetActive(true);
    }

    void UniversalOnEnabledButtonNNA()
    {
        buttonNNA.SetActive(true);
    }

    void UniversalOnEnabledNAButton()
    {
        buttonNA.SetActive(true);
    }

    void UniversalOffEnabledNAButton()
    {
        buttonNA.SetActive(false);
    }

    void UniversalIterationStep()
    {
        step++;
        substeps = -1;
    }

    void UniversalBodyTextPrinting(string Text, Text text)
    {
        if (!iPrint)
        {
            int a = text.text.Length + speedPrintingText;
            int b = Text.Length - a;
            if (b < 0)
            {
                for (int i = text.text.Length; i < Text.Length; i++)
                {
                    text.text += Text[text.text.Length];
                }
            }
            else
            {
                for (int i = 0; i < speedPrintingText; i++)
                {
                    text.text += Text[text.text.Length];
                }
            }
        }
        else
        {
            text.text = Text;
        }
    }

    void UniversalBodyTextDeleting(Text text)
    {
        if (!iPrint)
        {
            if (text.text.Length < speedDeletingText)
            {
                for (int i = 0; i < text.text.Length; i++)
                {
                    text.text = text.text.Remove(text.text.Length - 1);
                }
            }
            else
            {
                text.text = text.text.Remove(text.text.Length - (speedDeletingText));
            }
        }
        else
            text.text = "";
    }
    void CheckerCountdown()
    {
        if (startCountdown)
        {
            DateTime time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.TimeOfDay.Hours, DateTime.Now.TimeOfDay.Minutes, DateTime.Now.TimeOfDay.Seconds);
            DateTime finalTime = new DateTime(eventFinalTimeYear, eventFinalTimeMonth, eventFinalTimeDays, eventFinalTimeHourse, eventFinalTimeMinutes, eventFinalTimeSeconds);
            if (time >= finalTime)
            {
                finishCountdown = true;
                timerGO.SetActive(false);
            }
            return;
        }
    }
    void StartCountdown(double addMinutes)
    {
        if (!startCountdown)
        {
            eventStartTimeYear = DateTime.Now.Year;
            eventStartTimeMonth = DateTime.Now.Month;
            eventStartTimeDays = DateTime.Now.Day;
            eventStartTimeHourse = DateTime.Now.TimeOfDay.Hours;
            eventStartTimeMinutes = DateTime.Now.TimeOfDay.Minutes;
            eventStartTimeSeconds = DateTime.Now.TimeOfDay.Seconds;
            DateTime time = new DateTime(eventStartTimeYear, eventStartTimeMonth, eventStartTimeDays, eventStartTimeHourse, eventStartTimeMinutes, eventStartTimeSeconds);
            DateTime finalTime = new DateTime(eventStartTimeYear, eventStartTimeMonth, eventStartTimeDays, eventStartTimeHourse, eventStartTimeMinutes, eventStartTimeSeconds);
            finalTime = finalTime.AddMinutes(addMinutes);
            eventFinalTimeYear = finalTime.Year;
            eventFinalTimeMonth = finalTime.Month;
            eventFinalTimeDays = finalTime.Day;
            eventFinalTimeHourse = finalTime.Hour;
            eventFinalTimeMinutes = finalTime.Minute;
            eventFinalTimeSeconds = finalTime.Second;

            startCountdown = true;
            timerGO.SetActive(true);
            Save();
            return;
        }
    }
}