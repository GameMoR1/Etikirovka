using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.Metrics;
using System.Security.Cryptography;

class ObrabotkaFiles
{

    public string configDirectoryPath;
    public string configFilePath;
    public string configFileName;
    public string repeatsFileDirectory;

    public string configDirectoryPathOut
    {
        get
        {
            return configDirectoryPath;
        }
    }
    public string configFilePathOut
    {
        get
        {
            return configFilePath;
        }
    }
    public string configFileNameOut
    {
        get
        {
            return configFileName;
        }
    }

    public List<string> AllSpeed = new List<string>();
    public List<string> ChangingSave = new List<string>();
    public List<string> ChangingSaveParking = new List<string>();

    private float AllCount = 0;
    private float XSpeed = 0;
    private float YSpeed = 0;
    private float ZSpeed = 0;
    private float ASpeed = 0;
    private float BSpeed = 0;

    private float Repeats = 0;
    private float Delay = 0;
    private float TurnFlakon = 0;
    private float ZazhimFlakon = 0;
    private float PrizhimValika = 0;

    private float FlyStart = 0;
    private float ValikStart = 0;
    private float ValikEnd = 0;
    private float KaretkaStart = 0;
    private float KaretkaEnd = 0;
    private float TurnFlakonStart = 0;
    private float TurnFlakonEnd = 0;
    private float AxisPrizhimStart = 0;
    private float AxisPrizhimEnd = 0;

    private bool XParking = false;
    private bool YParking = false;
    private bool ZParking = false;
    private bool AParking = false;
    private bool BParking = false;


    public List<string> AllSpeed_ = new List<string>();

    private float XSpeed_ = 0;
    private float YSpeed_ = 0;
    private float ZSpeed_ = 0;
    private float ASpeed_ = 0;
    private float BSpeed_ = 0;

    private float Repeats_ = 0;
    private float Delay_ = 0;
    private float TurnFlakon_ = 0;
    private float ZazhimFlakon_ = 0;
    private float PrizhimValika_ = 0;

    private float FlyStart_ = 0;
    private float ValikStart_ = 0;
    private float ValikEnd_ = 0;
    private float KaretkaStart_ = 0;
    private float KaretkaEnd_ = 0;
    private float TurnFlakonStart_ = 0;
    private float TurnFlakonEnd_ = 0;
    private float AxisPrizhimStart_ = 0;
    private float AxisPrizhimEnd_ = 0;

    private bool XParking_ = false;
    private bool YParking_ = false;
    private bool ZParking_ = false;
    private bool AParking_ = false;
    private bool BParking_ = false;

    public string file = "";

    //===========================================================================
    //========================== Логерный вывод путей ===========================
    //===========================================================================

    public string TestingOuts()
    {
        return $"Путь к директории конфига:\n{configDirectoryPath}\n" +
            $"Путь к файлу конфига:\n{configFilePath}\n" +
            $"Имя файла конфига:\n{configFileName}\n";
    }

    //===========================================================================
    //============================= Чтение конфига ==============================
    //===========================================================================

    public void FileRead()
    {
        Clear();                                                                            // Чистим класс
        StreamWriter WriterLogs = new StreamWriter(logPathes.FileReadLogs);                 // Открываем логер
        WriterLogs.WriteLine($"Логи за {DateTime.Now}");                                    // Записываем дату логов
        try
        {
            var LineCounter = File.ReadLines(configFilePath);                               // Записываем строки для их подсчета
            float countLines = 0;                                                           // Переменная счетчика линий
            foreach (var line in LineCounter)                                               // Цикл для подсчета
            {
                countLines++;                                                               // Прибавляем значение
            }
            float forHomes = countLines / 2;                                                // Делим количество строк для последующего определения парковки

            StreamReader ConfigReader = new StreamReader(configFilePath);                   // Читаем файл

            string lineM;                                                                   // Создаем переменную, костыль((
            int listsCounter = -1;                                                          // Счетчки открытой строки

            while ((lineM = ConfigReader.ReadLine()) != null)                               // Чтение строк до конца файла, обработка
            {
                listsCounter++;                                                             // Прибаляем значение к переменной открытой строки

                WriterLogs.WriteLine($"Линия {listsCounter}) {lineM}");

                if ((lineM != "") && (lineM.ToCharArray()[0] == ';'))                       // Если строка не пустая и первый символ строки - ;
                {
                    string line = lineM.Replace(';', ' ').Trim();                           // Убираем лишние пробелы в начале и в конце, переменная-костыль
                    var peremennie = line.Split(',');                                       // Массив со спличенными именами переменных в файле
                    string SecondLine = ConfigReader.ReadLine();                            // Читаем вторую строку
                    listsCounter++;                                                         // Прибаляем значение к переменной открытой строки
                    WriterLogs.WriteLine($"Линия {listsCounter}) {SecondLine}");
                    var gCode = SecondLine.Split(' ');                                      // Массив со спличенными командами gCode
                    foreach (var p in peremennie)                                           // Цикл для обработки переменных
                    {
                        string peremennaya = p.Trim();                                      // Убираем лишние пробелы в начале и в конце, переменная-костыль
                        WriterLogs.WriteLine($"peremennaya: {peremennaya}");

                        // Далее идут строки, которые отвечат за поиск имен переменных в первой взятой строке, если
                        // if срабатывает, вторая строка делится на массив с каждой командой, каждая отдельная ячейка
                        // этого массива обрабатывается, убираются лишние пробелы, если 1 символ совпадает с тем, что
                        // нам нужно - далее эта команда идет в обработку, создается новый цикл для проверки каждого
                        // символа (костыли для уверенности, что не крашнет и проблемы будут не со стороы приложения),
                        // запись символов в одну переменную, сохранение полученного в массив (List) для дальнейшей
                        // обработки при перезаписи файлов.

                        // Структура сохранения данных в массиве:
                        // {Имя переменной}|{Номер строки}

                        if (peremennaya == "home_x")
                        {
                            if (listsCounter < forHomes)
                            {
                                XParking = true;
                            }
                            WriterLogs.WriteLine($"Парсер: home_x|{listsCounter}");
                            WriterLogs.WriteLine("Переменная: " + XParking);
                            ChangingSaveParking.Add($"home_x|{listsCounter}");
                        }
                        if (peremennaya == "home_y")
                        {
                            if (listsCounter < forHomes)
                            {
                                YParking = true;
                            }
                            WriterLogs.WriteLine($"Парсер: home_y|{listsCounter}");
                            WriterLogs.WriteLine("Переменная: " + YParking);
                            ChangingSaveParking.Add($"home_y|{listsCounter}");
                        }
                        if (peremennaya == "home_z")
                        {
                            if (listsCounter < forHomes)
                            {
                                ZParking = true;
                            }
                            WriterLogs.WriteLine($"Парсер: home_z|{listsCounter}");
                            WriterLogs.WriteLine("Переменная: " + ZParking);
                            ChangingSaveParking.Add($"home_z|{listsCounter}");
                        }
                        if (peremennaya == "home_a")
                        {
                            if (listsCounter < forHomes)
                            {
                                AParking = true;
                            }
                            WriterLogs.WriteLine($"Парсер: home_a|{listsCounter}");
                            WriterLogs.WriteLine("Переменная: " + AParking);
                            ChangingSaveParking.Add($"home_a|{listsCounter}");
                        }
                        if (peremennaya == "home_b")
                        {
                            if (listsCounter < forHomes)
                            {
                                BParking = true;
                            }
                            WriterLogs.WriteLine($"Парсер: home_b|{listsCounter}");
                            WriterLogs.WriteLine("Переменная: " + BParking);
                            ChangingSaveParking.Add($"home_b|{listsCounter}");
                        }

                        if (peremennaya == "feedrate_x")
                        {
                            foreach (var c in gCode)
                            {
                                string code = c.Trim();
                                if (code.ToCharArray()[0] == 'F')
                                {
                                    int counter = 0;
                                    string itog = "";
                                    var array = code.ToCharArray();
                                    foreach (var character in array)
                                    {
                                        if (counter == 0) { }
                                        else if (character != ' ')
                                        {
                                            itog += character;
                                        }
                                        counter++;
                                    }
                                    string kostil = itog.Replace('.', ',');
                                    XSpeed = float.Parse(kostil.Trim());
                                    WriterLogs.WriteLine($"Парсер: feedrate_x|{listsCounter}");
                                    WriterLogs.WriteLine("Переменная: " + XSpeed);
                                    ChangingSave.Add($"feedrate_x|{listsCounter}");
                                }
                            }
                        }
                        if (peremennaya == "feedrate_y")
                        {
                            foreach (var c in gCode)
                            {
                                string code = c.Trim();
                                if (code.ToCharArray()[0] == 'F')
                                {
                                    int counter = 0;
                                    string itog = "";
                                    var array = code.ToCharArray();
                                    foreach (var character in array)
                                    {
                                        if (counter == 0) { }
                                        else if (character != ' ')
                                        {
                                            itog += character;
                                        }
                                        counter++;
                                    }
                                    string kostil = itog.Replace('.', ',');
                                    YSpeed = float.Parse(kostil.Trim());
                                    WriterLogs.WriteLine($"Парсер: feedrate_y|{listsCounter}");
                                    WriterLogs.WriteLine("Переменная: " + YSpeed);
                                    ChangingSave.Add($"feedrate_y|{listsCounter}");
                                }
                            }
                        }
                        if (peremennaya == "feedrate_z")
                        {
                            foreach (var c in gCode)
                            {
                                string code = c.Trim();
                                if (code.ToCharArray()[0] == 'F')
                                {
                                    int counter = 0;
                                    string itog = "";
                                    var array = code.ToCharArray();
                                    foreach (var character in array)
                                    {
                                        if (counter == 0) { }
                                        else if (character != ' ')
                                        {
                                            itog += character;
                                        }
                                        counter++;
                                    }
                                    string kostil = itog.Replace('.', ',');
                                    ZSpeed = float.Parse(kostil.Trim());
                                    WriterLogs.WriteLine($"Парсер: feedrate_z|{listsCounter}");
                                    WriterLogs.WriteLine("Переменная: " + ZSpeed);
                                    ChangingSave.Add($"feedrate_z|{listsCounter}");
                                }
                            }
                        }
                        if (peremennaya == "feedrate_a")
                        {
                            foreach (var c in gCode)
                            {
                                string code = c.Trim();
                                if (code.ToCharArray()[0] == 'F')
                                {
                                    int counter = 0;
                                    string itog = "";
                                    var array = code.ToCharArray();
                                    foreach (var character in array)
                                    {
                                        if (counter == 0) { }
                                        else if (character != ' ')
                                        {
                                            itog += character;
                                        }
                                        counter++;
                                    }
                                    string kostil = itog.Replace('.', ',');
                                    ASpeed = float.Parse(kostil.Trim());
                                    WriterLogs.WriteLine($"Парсер: feedrate_a|{listsCounter}");
                                    WriterLogs.WriteLine("Переменная: " + ASpeed);
                                    ChangingSave.Add($"feedrate_a|{listsCounter}");
                                }
                            }
                        }
                        if (peremennaya == "feedrate_b")
                        {
                            foreach (var c in gCode)
                            {
                                string code = c.Trim();
                                if (code.ToCharArray()[0] == 'F')
                                {
                                    int counter = 0;
                                    string itog = "";
                                    var array = code.ToCharArray();
                                    foreach (var character in array)
                                    {
                                        if (counter == 0) { }
                                        else if (character != ' ')
                                        {
                                            itog += character;
                                        }
                                        counter++;
                                    }
                                    string kostil = itog.Replace('.', ',');
                                    BSpeed = float.Parse(kostil.Trim());
                                    WriterLogs.WriteLine($"Парсер: feedrate_b|{listsCounter}");
                                    WriterLogs.WriteLine("Переменная: " + BSpeed);
                                    ChangingSave.Add($"feedrate_b|{listsCounter}");
                                }
                            }
                        }
                        if (peremennaya == "feedrate_all")
                        {
                            foreach (var c in gCode)
                            {
                                string code = c.Trim();
                                if (code.ToCharArray()[0] == 'F')
                                {
                                    int counter = 0;
                                    string itog = "";
                                    var array = code.ToCharArray();
                                    foreach (var character in array)
                                    {
                                        if (counter == 0) { }
                                        else if (character != ' ')
                                        {
                                            itog += character;
                                        }
                                        counter++;
                                    }

                                    string comboName = "";

                                    if (line.Contains("start_x"))
                                    {
                                        comboName += "X_start ";
                                    }
                                    if (line.Contains("start_y"))
                                    {
                                        comboName += "Y_start ";
                                    }
                                    if (line.Contains("start_z"))
                                    {
                                        comboName += "Z_start ";
                                    }
                                    if (line.Contains("start_a"))
                                    {
                                        comboName += "A_start ";
                                    }
                                    if (line.Contains("start_b"))
                                    {
                                        comboName += "B_start ";
                                    }

                                    if (line.Contains("end_x"))
                                    {
                                        comboName += "X_end ";
                                    }
                                    if (line.Contains("end_y"))
                                    {
                                        comboName += "Y_end ";
                                    }
                                    if (line.Contains("end_z"))
                                    {
                                        comboName += "Z_end ";
                                    }
                                    if (line.Contains("end_a"))
                                    {
                                        comboName += "A_end ";
                                    }
                                    if (line.Contains("end_b"))
                                    {
                                        comboName += "B_end ";
                                    }

                                    WriterLogs.WriteLine($"Парсер: allFeedrate|{listsCounter}");
                                    ChangingSave.Add($"allFeedrate|{listsCounter}");

                                    itog += $" {comboName}";

                                    AllSpeed.Add(itog);
                                    WriterLogs.WriteLine("Переменная: " + itog);
                                    AllCount++;
                                }
                            }
                        }

                        if (peremennaya == "start_x")
                        {
                            foreach (var c in gCode)
                            {
                                string code = c.Trim();
                                if (code.ToCharArray()[0] == 'X')
                                {
                                    int counter = 0;
                                    string itog = "";
                                    var array = code.ToCharArray();
                                    foreach (var character in array)
                                    {
                                        if (counter == 0) { }
                                        else if (character != ' ')
                                        {
                                            itog += character;
                                        }
                                        counter++;
                                    }
                                    string kostil = itog.Replace('.', ',');
                                    FlyStart = float.Parse(kostil.Trim());
                                    WriterLogs.WriteLine($"Парсер: start_x|{listsCounter}");
                                    WriterLogs.WriteLine("Переменная: " + FlyStart);
                                    ChangingSave.Add($"start_x|{listsCounter}");
                                }
                            }
                        }
                        if (peremennaya == "start_y")
                        {
                            foreach (var c in gCode)
                            {
                                string code = c.Trim();
                                if (code.ToCharArray()[0] == 'Y')
                                {
                                    int counter = 0;
                                    string itog = "";
                                    var array = code.ToCharArray();
                                    foreach (var character in array)
                                    {
                                        if (counter == 0) { }
                                        else if (character != ' ')
                                        {
                                            itog += character;
                                        }
                                        counter++;
                                    }
                                    string kostil = itog.Replace('.', ',');
                                    ValikStart = float.Parse(kostil.Trim());
                                    WriterLogs.WriteLine($"Парсер: start_y|{listsCounter}");
                                    WriterLogs.WriteLine("Переменная: " + ValikStart);
                                    ChangingSave.Add($"start_y|{listsCounter}");
                                }
                            }
                        }
                        if (peremennaya == "end_y")
                        {
                            foreach (var c in gCode)
                            {
                                string code = c.Trim();
                                if (code.ToCharArray()[0] == 'Y')
                                {
                                    int counter = 0;
                                    string itog = "";
                                    var array = code.ToCharArray();
                                    foreach (var character in array)
                                    {
                                        if (counter == 0) { }
                                        else if (character != ' ')
                                        {
                                            itog += character;
                                        }
                                        counter++;
                                    }
                                    string kostil = itog.Replace('.', ',');
                                    ValikEnd = float.Parse(kostil.Trim());
                                    WriterLogs.WriteLine($"Парсер: end_y|{listsCounter}");
                                    WriterLogs.WriteLine("Переменная: " + ValikEnd);
                                    ChangingSave.Add($"end_y|{listsCounter}");
                                }
                            }
                        }
                        if (peremennaya == "start_z")
                        {
                            foreach (var c in gCode)
                            {
                                string code = c.Trim();
                                if (code.ToCharArray()[0] == 'Z')
                                {
                                    int counter = 0;
                                    string itog = "";
                                    var array = code.ToCharArray();
                                    foreach (var character in array)
                                    {
                                        if (counter == 0) { }
                                        else if (character != ' ')
                                        {
                                            itog += character;
                                        }
                                        counter++;
                                    }
                                    string kostil = itog.Replace('.', ',');
                                    KaretkaStart = float.Parse(kostil.Trim());
                                    WriterLogs.WriteLine($"Парсер: start_z|{listsCounter}");
                                    WriterLogs.WriteLine("Переменная: " + KaretkaStart);
                                    ChangingSave.Add($"start_z|{listsCounter}");
                                }
                            }
                        }
                        if (peremennaya == "end_z")
                        {
                            foreach (var c in gCode)
                            {
                                string code = c.Trim();
                                if (code.ToCharArray()[0] == 'Z')
                                {
                                    int counter = 0;
                                    string itog = "";
                                    var array = code.ToCharArray();
                                    foreach (var character in array)
                                    {
                                        if (counter == 0) { }
                                        else if (character != ' ')
                                        {
                                            itog += character;
                                        }
                                        counter++;
                                    }
                                    string kostil = itog.Replace('.', ',');
                                    KaretkaEnd = float.Parse(kostil.Trim());
                                    WriterLogs.WriteLine($"Парсер: end_z|{listsCounter}");
                                    WriterLogs.WriteLine("Переменная: " + KaretkaEnd);
                                    ChangingSave.Add($"end_z|{listsCounter}");
                                }
                            }
                        }
                        if (peremennaya == "start_a")
                        {
                            foreach (var c in gCode)
                            {
                                string code = c.Trim();
                                if (code.ToCharArray()[0] == 'A')
                                {
                                    int counter = 0;
                                    string itog = "";
                                    var array = code.ToCharArray();
                                    foreach (var character in array)
                                    {
                                        if (counter == 0) { }
                                        else if (character != ' ')
                                        {
                                            itog += character;
                                        }
                                        counter++;
                                    }
                                    string kostil = itog.Replace('.', ',');
                                    TurnFlakonStart = float.Parse(kostil.Trim());
                                    WriterLogs.WriteLine($"Парсер: start_a|{listsCounter}");
                                    WriterLogs.WriteLine("Переменная: " + TurnFlakonStart);
                                    ChangingSave.Add($"start_a|{listsCounter}");
                                }
                            }
                        }
                        if (peremennaya == "end_a")
                        {
                            foreach (var c in gCode)
                            {
                                string code = c.Trim();
                                if (code.ToCharArray()[0] == 'A')
                                {
                                    int counter = 0;
                                    string itog = "";
                                    var array = code.ToCharArray();
                                    foreach (var character in array)
                                    {
                                        if (counter == 0) { }
                                        else if (character != ' ')
                                        {
                                            itog += character;
                                        }
                                        counter++;
                                    }
                                    string kostil = itog.Replace('.', ',');
                                    TurnFlakonEnd = float.Parse(kostil.Trim());
                                    WriterLogs.WriteLine($"Парсер: end_a|{listsCounter}");
                                    WriterLogs.WriteLine("Переменная: " + TurnFlakonEnd);
                                    ChangingSave.Add($"end_a|{listsCounter}");
                                }
                            }
                        }
                        if (peremennaya == "start_b")
                        {
                            foreach (var c in gCode)
                            {
                                string code = c.Trim();
                                if (code.ToCharArray()[0] == 'B')
                                {
                                    int counter = 0;
                                    string itog = "";
                                    var array = code.ToCharArray();
                                    foreach (var character in array)
                                    {
                                        if (counter == 0) { }
                                        else if (character != ' ')
                                        {
                                            itog += character;
                                        }
                                        counter++;
                                    }
                                    string kostil = itog.Replace('.', ',');
                                    AxisPrizhimStart = float.Parse(kostil.Trim());
                                    WriterLogs.WriteLine($"Парсер: start_b|{listsCounter}");
                                    WriterLogs.WriteLine("Переменная: " + AxisPrizhimStart);
                                    ChangingSave.Add($"start_b|{listsCounter}");
                                }
                            }
                        }
                        if (peremennaya == "end_b")
                        {
                            foreach (var c in gCode)
                            {
                                string code = c.Trim();
                                if (code.ToCharArray()[0] == 'B')
                                {
                                    int counter = 0;
                                    string itog = "";
                                    var array = code.ToCharArray();
                                    foreach (var character in array)
                                    {
                                        if (counter == 0) { }
                                        else if (character != ' ')
                                        {
                                            itog += character;
                                        }
                                        counter++;
                                    }
                                    string kostil = itog.Replace('.', ',');
                                    AxisPrizhimEnd = float.Parse(kostil.Trim());
                                    WriterLogs.WriteLine($"Парсер: end_b|{listsCounter}");
                                    WriterLogs.WriteLine("Переменная: " + AxisPrizhimEnd);
                                    ChangingSave.Add($"end_b|{listsCounter}");
                                }
                            }
                        }

                        if (peremennaya == "clamp_b")
                        {
                            foreach (var c in gCode)
                            {
                                string code = c.Trim();
                                if (code.ToCharArray()[0] == 'B')
                                {
                                    int counter = 0;
                                    string itog = "";
                                    var array = code.ToCharArray();
                                    foreach (var character in array)
                                    {
                                        if (counter == 0) { }
                                        else if (character != ' ')
                                        {
                                            itog += character;
                                        }
                                        counter++;
                                    }
                                    string kostil = itog.Replace('.', ',');
                                    ZazhimFlakon = float.Parse(kostil.Trim());
                                    WriterLogs.WriteLine($"Парсер: clamp_b|{listsCounter}");
                                    WriterLogs.WriteLine("Переменная: " + ZazhimFlakon);
                                    ChangingSave.Add($"clamp_b|{listsCounter}");
                                }
                            }
                        }
                        if (peremennaya == "clamp_y")
                        {
                            foreach (var c in gCode)
                            {
                                string code = c.Trim();
                                if (code.ToCharArray()[0] == 'Y')
                                {
                                    int counter = 0;
                                    string itog = "";
                                    var array = code.ToCharArray();
                                    foreach (var character in array)
                                    {
                                        if (counter == 0) { }
                                        else if (character != ' ')
                                        {
                                            itog += character;
                                        }
                                        counter++;
                                    }
                                    string kostil = itog.Replace('.', ',');
                                    PrizhimValika = float.Parse(kostil.Trim());
                                    WriterLogs.WriteLine($"Парсер: clamp_y|{listsCounter}");
                                    WriterLogs.WriteLine("Переменная: " + PrizhimValika);
                                    ChangingSave.Add($"clamp_y|{listsCounter}");
                                }
                            }
                        }
                        if (peremennaya == "rotate_a")
                        {
                            foreach (var c in gCode)
                            {
                                string code = c.Trim();
                                if (code.ToCharArray()[0] == 'A')
                                {
                                    int counter = 0;
                                    string itog = "";
                                    var array = code.ToCharArray();
                                    foreach (var character in array)
                                    {
                                        if (counter == 0) { }
                                        else if (character != ' ')
                                        {
                                            itog += character;
                                        }
                                        counter++;
                                    }
                                    string kostil = itog.Replace('.', ',');
                                    TurnFlakon = float.Parse(kostil.Trim());
                                    WriterLogs.WriteLine($"Парсер: rotate_a|{listsCounter}");
                                    WriterLogs.WriteLine("Переменная: " + TurnFlakon);
                                    ChangingSave.Add($"rotate_a|{listsCounter}");
                                }
                            }
                        }
                        if (peremennaya == "delay_s")
                        {
                            foreach (var c in gCode)
                            {
                                string code = c.Trim();
                                if (code.ToCharArray()[0] == 'S')
                                {
                                    int counter = 0;
                                    string itog = "";
                                    var array = code.ToCharArray();
                                    foreach (var character in array)
                                    {
                                        if (counter == 0) { }
                                        else if (character != ' ')
                                        {
                                            itog += character;
                                        }
                                        counter++;
                                    }
                                    string kostil = itog.Replace('.', ',');
                                    Delay = float.Parse(kostil.Trim());
                                    WriterLogs.WriteLine($"Парсер: delay_s|{listsCounter}");
                                    WriterLogs.WriteLine("Переменная: " + Delay);
                                    ChangingSave.Add($"delay_s|{listsCounter}");
                                }
                            }
                        }
                    }
                }
            }

            ConfigReader.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Произошла ошибка, перезапустите приложение");
            StreamWriter WriteException = new StreamWriter(logPathes.Exceptions);
            WriteException.WriteLine(ex);
            WriteException.Close();
        }
        if(Delay == 0)
        {
            WriterLogs.WriteLine("Параметр delay_s отсутствует");
        }
        else
        {
            WriterLogs.WriteLine("Параметр delay_s присутствует");
        }
        WriterLogs.WriteLine();
        WriterLogs.WriteLine();
        WriterLogs.Close();
    }

    //===========================================================================
    //========================= Вывод данных объекта  ===========================
    //===========================================================================

    public List<string> dataOut()
    {
        List<string> strings = new List<string>();

        strings.Add(AllCount.ToString());
        strings.Add(XSpeed.ToString());
        strings.Add(YSpeed.ToString());
        strings.Add(ZSpeed.ToString());
        strings.Add(ASpeed.ToString());
        strings.Add(BSpeed.ToString());

        strings.Add(Repeats.ToString());
        strings.Add(Delay.ToString());
        strings.Add(TurnFlakon.ToString());
        strings.Add(ZazhimFlakon.ToString());
        strings.Add(PrizhimValika.ToString());
        strings.Add(FlyStart.ToString());

        strings.Add(ValikStart.ToString());
        strings.Add(ValikEnd.ToString());
        strings.Add(KaretkaStart.ToString());
        strings.Add(KaretkaEnd.ToString());
        strings.Add(TurnFlakonStart.ToString());
        strings.Add(TurnFlakonEnd.ToString());
        strings.Add(AxisPrizhimStart.ToString());
        strings.Add(AxisPrizhimEnd.ToString());

        strings.Add(outHelper(XParking));
        strings.Add(outHelper(YParking));
        strings.Add(outHelper(ZParking));
        strings.Add(outHelper(AParking));
        strings.Add(outHelper(BParking));

        return strings;
    }

    private string outHelper(bool input)
    {
        string forOut;
        if (input)
        {
            forOut = "true";
        }
        else
        {
            forOut = "false";
        }
        return forOut;
    }

    //===========================================================================
    //============================= Чистки класса ===============================
    //===========================================================================

    public void Clear()
    {
        try
        {
            AllCount = 0;
            XSpeed = 0;
            YSpeed = 0;
            ZSpeed = 0;
            ASpeed = 0;
            BSpeed = 0;

            Repeats = 0;
            Delay = 0;
            TurnFlakon = 0;
            ZazhimFlakon = 0;
            PrizhimValika = 0;
            FlyStart = 0;

            ValikStart = 0;
            ValikEnd = 0;
            KaretkaStart = 0;
            KaretkaEnd = 0;
            TurnFlakonStart = 0;
            TurnFlakonEnd = 0;
            AxisPrizhimStart = 0;
            AxisPrizhimEnd = 0;

            XParking = false;
            YParking = false;
            ZParking = false;
            AParking = false;
            BParking = false;

            AllSpeed.Clear();
            ChangingSave.Clear();

            XSpeed_ = 0;
            YSpeed_ = 0;
            ZSpeed_ = 0;
            ASpeed_ = 0;
            BSpeed_ = 0;

            Repeats_ = 0;
            Delay_ = 0;
            TurnFlakon_ = 0;
            ZazhimFlakon_ = 0;
            PrizhimValika_ = 0;
            FlyStart_ = 0;

            ValikStart_ = 0;
            ValikEnd_ = 0;
            KaretkaStart_ = 0;
            KaretkaEnd_ = 0;
            TurnFlakonStart_ = 0;
            TurnFlakonEnd_ = 0;
            AxisPrizhimStart_ = 0;
            AxisPrizhimEnd_ = 0;

            XParking_ = false;
            YParking_ = false;
            ZParking_ = false;
            AParking_ = false;
            BParking_ = false;

            AllSpeed_.Clear();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Произошла ошибка, перезапустите приложение");
            StreamWriter WriteException = new StreamWriter(logPathes.Exceptions);
            WriteException.WriteLine(ex);
            WriteException.Close();
        }
    }

    public void ClearNew()
    {
        try
        {
            XSpeed_ = 0;
            YSpeed_ = 0;
            ZSpeed_ = 0;
            ASpeed_ = 0;
            BSpeed_ = 0;

            Repeats_ = 0;
            Delay_ = 0;
            TurnFlakon_ = 0;
            ZazhimFlakon_ = 0;
            PrizhimValika_ = 0;
            FlyStart_ = 0;

            ValikStart_ = 0;
            ValikEnd_ = 0;
            KaretkaStart_ = 0;
            KaretkaEnd_ = 0;
            TurnFlakonStart_ = 0;
            TurnFlakonEnd_ = 0;
            AxisPrizhimStart_ = 0;
            AxisPrizhimEnd_ = 0;

            XParking_ = false;
            YParking_ = false;
            ZParking_ = false;
            AParking_ = false;
            BParking_ = false;

            AllSpeed_.Clear();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Произошла ошибка, перезапустите приложение");
            StreamWriter WriteException = new StreamWriter(logPathes.Exceptions);
            WriteException.WriteLine(ex);
            WriteException.Close();
        }
    }

    public void ClearOld()
    {
        try
        {
            AllCount = 0;
            XSpeed = 0;
            YSpeed = 0;
            ZSpeed = 0;
            ASpeed = 0;
            BSpeed = 0;

            Repeats = 0;
            Delay = 0;
            TurnFlakon = 0;
            ZazhimFlakon = 0;
            PrizhimValika = 0;
            FlyStart = 0;

            ValikStart = 0;
            ValikEnd = 0;
            KaretkaStart = 0;
            KaretkaEnd = 0;
            TurnFlakonStart = 0;
            TurnFlakonEnd = 0;
            AxisPrizhimStart = 0;
            AxisPrizhimEnd = 0;

            XParking = false;
            YParking = false;
            ZParking = false;
            AParking = false;
            BParking = false;

            AllSpeed.Clear();
            ChangingSave.Clear();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Произошла ошибка, перезапустите приложение");
            StreamWriter WriteException = new StreamWriter(logPathes.Exceptions);
            WriteException.WriteLine(ex);
            WriteException.Close();
        }
    }

    //===========================================================================
    //=========================== Изменение конфига =============================
    //===========================================================================

    public void Replacer()
    {
        StreamWriter WriterLogs = new StreamWriter(logPathes.ReplacerLogs);         // Открываем логер
        WriterLogs.WriteLine($"Логи за {DateTime.Now}");                            // Записываем дату логов
        try
        {
            var lines = File.ReadAllLines(configFilePath);                          // Записываем строки в массив для их подсчета и работы с ними
            int linesCount = lines.Length;                                          // Записываем количество строк в файле
            List<string> newFile = new List<string>();                              // Создаем лист (тотже массив, но с ним проще работать)

            for (int i = 0; i < linesCount; i++)                                    // Цикл для создания *ячеек* в листе, костыль
            {
                newFile.Add("");                                                    // Добавляем строку
            }

            List<int> otschetStrok = new List<int>();                               // Лист для сохранения повторяющихся строк с несколькими переменными

            int counterForFeedrate = 0;                                             // Счетчик цикла для переменных фидрейта
            foreach (var change in ChangingSave)                                    // Цикл для обработки каждого значения в листе
            {
                var splitedChange = change.Split('|');                              // Сплитаем сохраненную переменную
                int lineNumber = int.Parse(splitedChange[1]);                       // Выделяем номер строки, в которой нужно изменить переменную

                bool sovpadeniya = false;                                           // Переменная для обозначения того, что строка повторяется
                foreach (var list in otschetStrok)                                  // Цикл для поиска повторяющихся строк
                {
                    if (list == lineNumber)                                         // Если строки совпадают
                    {
                        sovpadeniya = true;                                         // Переводим переменную в true
                    }
                }
                if (!sovpadeniya)                                                   // Если переменная осталась false, записываем строку в лист
                {
                    otschetStrok.Add(lineNumber);                                   // Запись строки
                }

                WriterLogs.WriteLine($"Переменная sovpadeniya: {sovpadeniya}");

                // Далее идет замена переменных, запись в пустой массив. Отличие if от else
                // лишь в том, что в else идет изменение переменной уже в новом массиве, а
                // не в старом и запись. Это все сделано через несколько массивов, так как
                // в ссылки к сожалению не меняют данные в массивах, так как хранятся в 
                // разных ячейках памяти =) Изза этого костыли в виде нескольких массивов

                // Изменение работает так, что в старой и новой переменных меняются запятые
                // на точки, так как gCode ест только точки, далее идет изменение ячейки в
                // конечном массиве, тоесть берется массив со старым кодом, меняется 
                // переменная (не в массиве, во временной памяти) и записывается в конечный массив


                if (!sovpadeniya)                                                   // Если повторений небыло
                {
                    if (splitedChange[0] == "feedrate_x")
                    {
                        WriterLogs.WriteLine($"Старая строка lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = XSpeed.ToString().Replace(',', '.');
                        string newData = XSpeed_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (XSpeed): {oldData}\n" +
                            $"Новое значение (XSpeed_): {newData}");
                    }
                    else if (splitedChange[0] == "feedrate_y")
                    {
                        WriterLogs.WriteLine($"Старая строка lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = YSpeed.ToString().Replace(',', '.');
                        string newData = YSpeed_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (YSpeed): {oldData}\n" +
                            $"Новое значение (YSpeed_): {newData}");
                    }
                    else if (splitedChange[0] == "feedrate_z")
                    {
                        WriterLogs.WriteLine($"Старая строка lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = ZSpeed.ToString().Replace(',', '.');
                        string newData = ZSpeed_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (ZSpeed): {oldData}\n" +
                            $"Новое значение (ZSpeed_): {newData}");
                    }
                    else if (splitedChange[0] == "feedrate_a")
                    {
                        WriterLogs.WriteLine($"Старая строка lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = ASpeed.ToString().Replace(',', '.');
                        string newData = ASpeed_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (ASpeed): {oldData}\n" +
                            $"Новое значение (ASpeed_): {newData}");
                    }
                    else if (splitedChange[0] == "feedrate_b")
                    {
                        WriterLogs.WriteLine($"Старая строка lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = BSpeed.ToString().Replace(',', '.');
                        string newData = BSpeed_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (BSpeed): {oldData}\n" +
                            $"Новое значение (BSpeed_): {newData}");
                    }
                    else if (splitedChange[0] == "start_x")
                    {
                        WriterLogs.WriteLine($"Старая строка lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = FlyStart.ToString().Replace(',', '.');
                        string newData = FlyStart_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (FlyStart): {oldData}\n" +
                            $"Новое значение (FlyStart_): {newData}");
                    }
                    else if (splitedChange[0] == "start_y")
                    {
                        WriterLogs.WriteLine($"Старая строка lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = ValikStart.ToString().Replace(',', '.');
                        string newData = ValikStart_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (ValikStart): {oldData}\n" +
                            $"Новое значение (ValikStart_): {newData}");
                    }
                    else if (splitedChange[0] == "end_y")
                    {
                        WriterLogs.WriteLine($"Старая строка lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = ValikEnd.ToString().Replace(',', '.');
                        string newData = ValikEnd_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (ValikEnd): {oldData}\n" +
                            $"Новое значение (ValikEnd_): {newData}");
                    }
                    else if (splitedChange[0] == "start_z")
                    {
                        WriterLogs.WriteLine($"Старая строка lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = KaretkaStart.ToString().Replace(',', '.');
                        string newData = KaretkaStart_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (KaretkaStart): {oldData}\n" +
                            $"Новое значение (KaretkaStart_): {newData}");
                    }
                    else if (splitedChange[0] == "end_z")
                    {
                        WriterLogs.WriteLine($"Старая строка lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = KaretkaEnd.ToString().Replace(',', '.');
                        string newData = KaretkaEnd_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (KaretkaEnd): {oldData}\n" +
                            $"Новое значение (KaretkaEnd_): {newData}");
                    }
                    else if (splitedChange[0] == "start_a")
                    {
                        WriterLogs.WriteLine($"Старая строка lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = TurnFlakonStart.ToString().Replace(',', '.');
                        string newData = TurnFlakonStart_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (TurnFlakonStart): {oldData}\n" +
                            $"Новое значение (TurnFlakonStart_): {newData}");
                    }
                    else if (splitedChange[0] == "end_a")
                    {
                        WriterLogs.WriteLine($"Старая строка lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = TurnFlakonEnd.ToString().Replace(',', '.');
                        string newData = TurnFlakonEnd_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (TurnFlakonEnd): {oldData}\n" +
                            $"Новое значение (TurnFlakonEnd_): {newData}");
                    }
                    else if (splitedChange[0] == "start_b")
                    {
                        WriterLogs.WriteLine($"Старая строка lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = AxisPrizhimStart.ToString().Replace(',', '.');
                        string newData = AxisPrizhimStart_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (AxisPrizhimStart): {oldData}\n" +
                            $"Новое значение (AxisPrizhimStart_): {newData}");
                    }
                    else if (splitedChange[0] == "end_b")
                    {
                        WriterLogs.WriteLine($"Старая строка lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = AxisPrizhimEnd.ToString().Replace(',', '.');
                        string newData = AxisPrizhimEnd_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (AxisPrizhimEnd): {oldData}\n" +
                            $"Новое значение (AxisPrizhimEnd_): {newData}");
                    }
                    else if (splitedChange[0] == "delay_s")
                    {
                        WriterLogs.WriteLine($"Старая строка lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = Delay.ToString().Replace(',', '.');
                        string newData = Delay_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (Delay): {oldData}\n" +
                            $"Новое значение (Delay_): {newData}");
                    }
                    else if (splitedChange[0] == "rotate_a")
                    {
                        WriterLogs.WriteLine($"Старая строка lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = TurnFlakon.ToString().Replace(',', '.');
                        string newData = TurnFlakon_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (TurnFlakon): {oldData}\n" +
                            $"Новое значение (TurnFlakon_): {newData}");
                    }
                    else if (splitedChange[0] == "clamp_b")
                    {
                        WriterLogs.WriteLine($"Старая строка lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = ZazhimFlakon.ToString().Replace(',', '.');
                        string newData = ZazhimFlakon_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (ZazhimFlakon): {oldData}\n" +
                            $"Новое значение (ZazhimFlakon_): {newData}");
                    }
                    else if (splitedChange[0] == "clamp_y")
                    {
                        WriterLogs.WriteLine($"Старая строка lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = PrizhimValika.ToString().Replace(',', '.');
                        string newData = PrizhimValika_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (PrizimValika): {oldData}\n" +
                            $"Новое значение (PrizimValika_): {newData}");
                    }
                    else if (splitedChange[0] == "allFeedrate")
                    {
                        var AllSpeedSplited = AllSpeed[counterForFeedrate].Split(" ");
                        var AllSpeed_Splited = AllSpeed_[counterForFeedrate].Split(" ");
                        WriterLogs.WriteLine($"Старая строка lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = AllSpeedSplited[0].ToString().Replace(',', '.');
                        string newData = AllSpeed_Splited[0].ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (allFeedrate): {oldData}\n" +
                            $"Новое значение (allFeedrate_): {newData}");
                        counterForFeedrate++;
                    }
                }
                else // Если повторение было
                {
                    if (splitedChange[0] == "feedrate_x")
                    {
                        WriterLogs.WriteLine($"Старая строка newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = XSpeed.ToString().Replace(',', '.');
                        string newData = XSpeed_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (XSpeed): {oldData}\n" +
                            $"Новое значение (XSpeed_): {newData}");
                    }
                    else if (splitedChange[0] == "feedrate_y")
                    {
                        WriterLogs.WriteLine($"Старая строка newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = YSpeed.ToString().Replace(',', '.');
                        string newData = YSpeed_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (YSpeed): {oldData}\n" +
                            $"Новое значение (YSpeed_): {newData}");
                    }
                    else if (splitedChange[0] == "feedrate_z")
                    {
                        WriterLogs.WriteLine($"Старая строка newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = ZSpeed.ToString().Replace(',', '.');
                        string newData = ZSpeed_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (ZSpeed): {oldData}\n" +
                            $"Новое значение (ZSpeed_): {newData}");
                    }
                    else if (splitedChange[0] == "feedrate_a")
                    {
                        WriterLogs.WriteLine($"Старая строка newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = ASpeed.ToString().Replace(',', '.');
                        string newData = ASpeed_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (ASpeed): {oldData}\n" +
                            $"Новое значение (ASpeed_): {newData}");
                    }
                    else if (splitedChange[0] == "feedrate_b")
                    {
                        WriterLogs.WriteLine($"Старая строка newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = BSpeed.ToString().Replace(',', '.');
                        string newData = BSpeed_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (BSpeed): {oldData}\n" +
                            $"Новое значение (BSpeed_): {newData}");
                    }
                    else if (splitedChange[0] == "start_x")
                    {
                        WriterLogs.WriteLine($"Старая строка newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = FlyStart.ToString().Replace(',', '.');
                        string newData = FlyStart_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (FlyStart): {oldData}\n" +
                            $"Новое значение (FlyStart_): {newData}");
                    }
                    else if (splitedChange[0] == "start_y")
                    {
                        WriterLogs.WriteLine($"Старая строка newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = ValikStart.ToString().Replace(',', '.');
                        string newData = ValikStart_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (ValikStart): {oldData}\n" +
                            $"Новое значение (ValikStart_): {newData}");
                    }
                    else if (splitedChange[0] == "end_y")
                    {
                        WriterLogs.WriteLine($"Старая строка newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = ValikEnd.ToString().Replace(',', '.');
                        string newData = ValikEnd_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (ValikEnd): {oldData}\n" +
                            $"Новое значение (ValikEnd_): {newData}");
                    }
                    else if (splitedChange[0] == "start_z")
                    {
                        WriterLogs.WriteLine($"Старая строка newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = KaretkaStart.ToString().Replace(',', '.');
                        string newData = KaretkaStart_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (KaretkaStart): {oldData}\n" +
                            $"Новое значение (KaretkaStart_): {newData}");
                    }
                    else if (splitedChange[0] == "end_z")
                    {
                        WriterLogs.WriteLine($"Старая строка newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = KaretkaEnd.ToString().Replace(',', '.');
                        string newData = KaretkaEnd_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (KaretkaEnd): {oldData}\n" +
                            $"Новое значение (KaretkaEnd_): {newData}");
                    }
                    else if (splitedChange[0] == "start_a")
                    {
                        WriterLogs.WriteLine($"Старая строка newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = TurnFlakonStart.ToString().Replace(',', '.');
                        string newData = TurnFlakonStart_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (TurnFlakonStart): {oldData}\n" +
                            $"Новое значение (TurnFlakonStart_): {newData}");
                    }
                    else if (splitedChange[0] == "end_a")
                    {
                        WriterLogs.WriteLine($"Старая строка newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = TurnFlakonEnd.ToString().Replace(',', '.');
                        string newData = TurnFlakonEnd_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (TurnFlakonEnd): {oldData}\n" +
                            $"Новое значение (TurnFlakonEnd_): {newData}");
                    }
                    else if (splitedChange[0] == "start_b")
                    {
                        WriterLogs.WriteLine($"Старая строка newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = AxisPrizhimStart.ToString().Replace(',', '.');
                        string newData = AxisPrizhimStart_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (AxisPrizhimStart): {oldData}\n" +
                            $"Новое значение (AxisPrizhimStart_): {newData}");
                    }
                    else if (splitedChange[0] == "end_b")
                    {
                        WriterLogs.WriteLine($"Старая строка newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = AxisPrizhimEnd.ToString().Replace(',', '.');
                        string newData = AxisPrizhimEnd_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (AxisPrizhimEnd): {oldData}\n" +
                            $"Новое значение (AxisPrizhimEnd_): {newData}");
                    }
                    else if (splitedChange[0] == "delay_s")
                    {
                        WriterLogs.WriteLine($"Старая строка newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = Delay.ToString().Replace(',', '.');
                        string newData = Delay_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (Delay): {oldData}\n" +
                            $"Новое значение (Delay_): {newData}");
                    }
                    else if (splitedChange[0] == "rotate_a")
                    {
                        WriterLogs.WriteLine($"Старая строка newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = TurnFlakon.ToString().Replace(',', '.');
                        string newData = TurnFlakon_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (TurnFlakon): {oldData}\n" +
                            $"Новое значение (TurnFlakon_): {newData}");
                    }
                    else if (splitedChange[0] == "clamp_b")
                    {
                        WriterLogs.WriteLine($"Старая строка newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = ZazhimFlakon.ToString().Replace(',', '.');
                        string newData = ZazhimFlakon_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (ZazhimFlakon): {oldData}\n" +
                            $"Новое значение (ZazhimFlakon_): {newData}");
                    }
                    else if (splitedChange[0] == "clamp_y")
                    {
                        WriterLogs.WriteLine($"Старая строка newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = PrizhimValika.ToString().Replace(',', '.');
                        string newData = PrizhimValika_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (PrizimValika): {oldData}\n" +
                            $"Новое значение (PrizimValika_): {newData}");
                    }
                    else if (splitedChange[0] == "allFeedrate")
                    {
                        var AllSpeedSplited = AllSpeed[counterForFeedrate].Split(" ");
                        var AllSpeed_Splited = AllSpeed_[counterForFeedrate].Split(" ");
                        WriterLogs.WriteLine($"Старая строка newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = AllSpeedSplited[0].ToString().Replace(',', '.');
                        string newData = AllSpeed_Splited[0].ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"После замены newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"Старое значение (allFeedrate): {oldData}\n" +
                            $"Новое значение (allFeedrate_): {newData}");
                        counterForFeedrate++;
                    }
                }
                WriterLogs.WriteLine();
            }

            // Далее идет заполнение строк, которые не менялись

            for (int i = 0; i < newFile.Count; i++) // Цикл для заполнения ячеек
            {
                if (newFile[i] == "" || newFile[i] == null) // Если ячейка пустая
                {
                    newFile[i] = lines[i]; // Записываем данные в ячейку
                }
            }

            // Если в изначальном файле была задержка, но ее убрали - следующий
            // if какраз для такой ситуации

            if (Delay != 0 && Delay_ == 0) // if для удаления задержки
            {
                WriterLogs.WriteLine("Удаление задержки перед повтором");
                for (int i = 0; i < 2; i++) // Цикл для удаления 2 строк
                {
                    newFile.RemoveAt(--linesCount); // Удаление строк
                    WriterLogs.WriteLine($"Удалена строка {linesCount}");
                }
            }

            StreamWriter WriteFile = new StreamWriter(configFilePath); // Открываем запись массива в файл

            // Переменные для изменения парковок

            string startFirstLine = ";";
            string startSecondLine = "G28 ";
            string endFirstLine = ";";
            string endSecondLine = "G28 ";

            int countTrue = 0;
            int countFalse = 0;

            if (XParking_)
            {
                countTrue++;
            }
            else
            {
                countFalse++;
            }
            if (YParking_)
            {
                countTrue++;
            }
            else
            {
                countFalse++;
            }
            if (ZParking_)
            {
                countTrue++;
            }
            else
            {
                countFalse++;
            }
            if (AParking_)
            {
                countTrue++;
            }
            else
            {
                countFalse++;
            }
            if (BParking_)
            {
                countTrue++;
            }
            else
            {
                countFalse++;
            }

            if (XParking_)
            {
                if(countTrue > 1)
                {
                    startFirstLine += "home_x,";
                    countTrue--;
                }
                else
                {
                    startFirstLine += "home_x";
                }
                startSecondLine += "X0 ";
            }
            else
            {
                if(countFalse > 1)
                {
                    endFirstLine += "home_x,";
                    countFalse--;
                }
                else
                {
                    endFirstLine += "home_x";
                }
                endSecondLine += "X0 ";
            }
            if (YParking_)
            {
                if (countTrue > 1)
                {
                    startFirstLine += "home_y,";
                    countTrue--;
                }
                else
                {
                    startFirstLine += "home_y";
                }
                startSecondLine += "Y0 ";
            }
            else
            {
                if (countFalse > 1)
                {
                    endFirstLine += "home_y,";
                    countFalse--;
                }
                else
                {
                    endFirstLine += "home_y";
                }
                endSecondLine += "Y0 ";
            }
            if (ZParking_)
            {
                if (countTrue > 1)
                {
                    startFirstLine += "home_z,";
                    countTrue--;
                }
                else
                {
                    startFirstLine += "home_z";
                }
                startSecondLine += "Z0 ";
            }
            else
            {
                if (countFalse > 1)
                {
                    endFirstLine += "home_z,";
                    countFalse--;
                }
                else
                {
                    endFirstLine += "home_z";
                }
                endSecondLine += "Z0 ";
            }
            if(AParking_)
            {
                if (countTrue > 1)
                {
                    startFirstLine += "home_a,";
                    countTrue--;
                }
                else
                {
                    startFirstLine += "home_a";
                }
                startSecondLine += "A0 ";
            }
            else
            {
                if (countFalse > 1)
                {
                    endFirstLine += "home_a,";
                    countFalse--;
                }
                else
                {
                    endFirstLine += "home_a";
                }
                endSecondLine += "A0 ";
            }
            if (BParking_)
            {
                if (countTrue > 1)
                {
                    startFirstLine += "home_b,";
                    countTrue--;
                }
                else
                {
                    startFirstLine += "home_b";
                }
                startSecondLine += "B0 ";
            }
            else
            {
                if (countFalse > 1)
                {
                    endFirstLine += "home_b,";
                    countFalse--;
                }
                else
                {
                    endFirstLine += "home_b";
                }
                endSecondLine += "B0 ";
            }

            int secondLineWithDelay = newFile.Count - 3;
            int firstLineWithDelay = newFile.Count - 4;

            int secondLineNumber = newFile.Count - 1;
            int firstLineNumber = newFile.Count - 2;

            // Было в начале, стало в начале
            if ((XParking && YParking && ZParking && AParking && BParking) && (XParking_ && YParking_ && ZParking_ && AParking_ && BParking_))
            {
                WriterLogs.WriteLine("Было в начале, стало в начале");
                newFile[0] = startFirstLine;
                newFile[1] = startSecondLine;
            }
            // Было в конце, стало в конце
            else if ((!XParking && !YParking && !ZParking && !AParking && !BParking) && (!XParking_ && !YParking_ && !ZParking_ && !AParking_ && !BParking_))
            {
                WriterLogs.WriteLine("Было в цонце, стало в конце");
                if (Delay != 0 && Delay_ != 0)
                {
                    newFile[firstLineWithDelay] = endFirstLine;
                    newFile[secondLineWithDelay] = endSecondLine;
                }
                else
                {
                    newFile[firstLineNumber] = endFirstLine;
                    newFile[secondLineNumber] = endSecondLine;
                }
            }
            // Было в начале, стало в конце
            else if ((XParking && YParking && ZParking && AParking && BParking) && (!XParking_ && !YParking_ && !ZParking_ && !AParking_ && !BParking_))
            {
                WriterLogs.WriteLine("Было в начале, стало в конце");
                if (Delay != 0 && Delay_ != 0)
                {
                    string f = newFile[firstLineNumber];
                    newFile[firstLineNumber] = $"{endFirstLine}\n{endSecondLine}\n{f}";
                    newFile.RemoveAt(1);
                    newFile.RemoveAt(0);
                }
                else
                {
                    newFile.Add(endFirstLine);
                    newFile.Add(endSecondLine);
                    newFile.RemoveAt(1);
                    newFile.RemoveAt(0);
                }
            }
            // Было в конце, стало в начале
            else if ((!XParking && !YParking && !ZParking && !AParking && !BParking) && (XParking_ && YParking_ && ZParking_ && AParking_ && BParking_))
            {
                WriterLogs.WriteLine("Было в конце, стало в начале");
                if (Delay != 0 && Delay_ != 0)
                {
                    string f = newFile[0];
                    newFile[0] = $"{startFirstLine}\n{startSecondLine}\n{f}";
                    newFile[firstLineWithDelay] = "";
                    newFile[secondLineWithDelay] = "";
                }
                else
                {
                    string f = newFile[0];
                    newFile[0] = $"{startFirstLine}\n{startSecondLine}\n{f}";
                    newFile[firstLineNumber] = "";
                    newFile[secondLineNumber] = "";
                }
            }
            // Было везде, стало в начале
            else if ((XParking || YParking || ZParking || AParking || BParking) && (XParking_ && YParking_ && ZParking_ && AParking_ && BParking_))
            {
                WriterLogs.WriteLine("Было везде, стало в начале");
                if (Delay != 0 && Delay_ != 0)
                {
                    newFile[0] = startFirstLine;
                    newFile[1] = startSecondLine;
                    newFile[firstLineWithDelay] = "";
                    newFile[secondLineWithDelay] = "";
                }
                else
                {
                    newFile[0] = startFirstLine;
                    newFile[1] = startSecondLine;
                    newFile[firstLineNumber] = "";
                    newFile[secondLineNumber] = "";
                }
            }
            // Было везде, стало в конце
            else if ((XParking || YParking || ZParking || AParking || BParking) && (!XParking_ && !YParking_ && !ZParking_ && !AParking_ && !BParking_))
            {
                WriterLogs.WriteLine("Было везде, стало в конце");
                if (Delay != 0 && Delay_ != 0)
                {
                    newFile[0] = "";
                    newFile[1] = "";
                    newFile[firstLineWithDelay] = endFirstLine;
                    newFile[secondLineWithDelay] = endSecondLine;
                }
                else
                {
                    newFile[0] = "";
                    newFile[1] = "";
                    newFile[firstLineNumber] = endFirstLine;
                    newFile[secondLineNumber] = endSecondLine;
                }
            }
            // Было в начале, стало везде
            else if ((XParking && YParking && ZParking && AParking && BParking) && (XParking_ || YParking_ || ZParking_ || AParking_ || BParking_))
            {
                WriterLogs.WriteLine("Было в начале, стало везде");
                if (Delay != 0 && Delay_ != 0)
                {
                    newFile[0] = startFirstLine;
                    newFile[1] = startSecondLine;
                    string f = newFile[firstLineNumber];
                    newFile[firstLineNumber] = $"{endFirstLine}\n{endSecondLine}\n{f}";
                }
                else
                {
                    newFile[0] = startFirstLine;
                    newFile[1] = startSecondLine;
                    string f = newFile[secondLineNumber];
                    newFile[secondLineNumber] = $"{f}\n{endFirstLine}\n{endSecondLine}";
                }
            }
            // Было в конце, стало в везде
            else if ((!XParking && !YParking && !ZParking && !AParking && !BParking) && (XParking_ || YParking_ || ZParking_ || AParking_ || BParking_))
            {
                WriterLogs.WriteLine("Было в конце, стало в везде");
                if (Delay != 0 && Delay_ != 0)
                {
                    string f = newFile[0];
                    newFile[0] = $"{startFirstLine}\n{startSecondLine}\n{f}";
                    newFile[firstLineWithDelay] = endFirstLine;
                    newFile[secondLineWithDelay] = endSecondLine;
                }
                else
                {
                    string f = newFile[0];
                    newFile[0] = $"{startFirstLine}\n{startSecondLine}\n{f}";
                    newFile[firstLineNumber] = endFirstLine;
                    newFile[secondLineNumber] = endSecondLine;
                }
            }
            // Было везде, стало везде
            else
            {
                WriterLogs.WriteLine("Было везде, стало везде");
                if (Delay != 0 && Delay_ != 0)
                {
                    newFile[0] = startFirstLine;
                    newFile[1] = startSecondLine;
                    newFile[firstLineWithDelay] = endFirstLine;
                    newFile[secondLineWithDelay] = endSecondLine;
                }
                else
                {
                    newFile[0] = startFirstLine;
                    newFile[1] = startSecondLine;
                    newFile[firstLineNumber] = endFirstLine;
                    newFile[secondLineNumber] = endSecondLine;
                }
            }

            if (Repeats_ > 1)                                                                       // Если есть повторения
            {
                foreach (var line in newFile)                                                       // Цикл для записи каждой ячейки массива в файл
                {
                    if (line != "" || line != null)                                                 // Отгребаем пустые ячейки, если они еще вообще остались)))
                    {
                        WriteFile.WriteLine(line);                                                  // Записываем ячейку в файл
                    }
                }
                if (Delay == 0 && Delay_ != 0)                                                      // Если Задержки небыло, но она появилась
                {
                    int fileLength = newFile.Count;                                                 // Записываем количество строк (это для логера)
                    WriterLogs.WriteLine($"Новая команда G4 (delay_s), " +
                        $"добавлена в конце ({++fileLength}, {++fileLength} строки)"); 
                    WriteFile.WriteLine(";delay_s");                                                // Записываем переменную
                    WriteFile.WriteLine($"G4 S{Delay_}");                                           // Записываем команду
                }

                WriterLogs.WriteLine(repeatsFileDirectory + @"\1.gcode");
                checkDirectories.createDirectoryIfNotExists(repeatsFileDirectory);                  // Достаем путь к файлу с повторами (где его хранить)
                StreamWriter WriteRepeats = new StreamWriter(repeatsFileDirectory + @"\1.gcode");   // Открываем запись
                WriterLogs.WriteLine();
                WriterLogs.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||||||");
                WriterLogs.WriteLine();
                WriterLogs.WriteLine("Запись файла с повторами");
                WriterLogs.WriteLine($"Количество повторов: {Repeats_}");
                for (int i = 0; i < Repeats_; i++)
                {
                    foreach (var line in newFile)
                    {
                        if (line != "")
                        {
                            WriteRepeats.WriteLine(line);
                        }
                    }
                    if (Delay == 0 && Delay_ != 0)
                    {
                        int fileLength = newFile.Count;
                        WriterLogs.WriteLine($"Новая команда G4 (delay_s), добавлена в конце ({++fileLength}, {++fileLength} строки)");
                        WriteRepeats.WriteLine(";delay_s");
                        WriteRepeats.WriteLine($"G4 S{Delay_}");
                    }
                }
                WriterLogs.WriteLine();
                WriterLogs.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||||||");
                WriterLogs.WriteLine();
                WriteRepeats.Close();
            }
            else
            {
                foreach (var line in newFile)
                {
                    if (line != "")
                    {
                        WriteFile.WriteLine(line);
                    }
                }
                if (Delay == 0 && Delay_ != 0)
                {
                    int fileLength = newFile.Count;
                    WriterLogs.WriteLine($"Новая команда G4 (delay_s), добавлена в конце ({++fileLength}, {++fileLength} строки)");
                    WriteFile.WriteLine(";delay_s");
                    WriteFile.WriteLine($"G4 S{Delay_}");
                }
            }

            WriteFile.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Произошла ошибка, перезапустите приложение");
            StreamWriter WriteException = new StreamWriter(logPathes.Exceptions);
            WriteException.WriteLine(ex);
            WriteException.Close();
        }
        WriterLogs.WriteLine();
        WriterLogs.WriteLine();
        WriterLogs.Close();
    }

    //===========================================================================
    //========================== Ввод данных из полей ===========================
    //===========================================================================

    public void newDataInput(float XSpeedn, float YSpeedn, float ZSpeedn, float ASpeedn, float BSpeedn, float Repeatsn, float Delayn, float TurnFlakonn, float ZazhimFlakonn, float PrizhimValikan, float FlyStartn, float ValikStartn, float ValikEndn, float KaretkaStartn, float KaretkaEndn, float TurnFlakonStartn, float TurnFlakonEndn, float AxisPrizhimStartn, float AxisPrizhimEndn, bool XParkingn, bool YParkingn, bool ZParkingn, bool AParkingn, bool BParkingn, List<string> AllSpeedn)
    {
        try
        {
            ClearNew();
            XSpeed_ = XSpeedn;
            YSpeed_ = YSpeedn;
            ZSpeed_ = ZSpeedn;
            ASpeed_ = ASpeedn;
            BSpeed_ = BSpeedn;

            Repeats_ = Repeatsn;
            Delay_ = Delayn;
            TurnFlakon_ = TurnFlakonn;
            ZazhimFlakon_ = ZazhimFlakonn;
            PrizhimValika_ = PrizhimValikan;
            FlyStart_ = FlyStartn;

            ValikStart_ = ValikStartn;
            ValikEnd_ = ValikEndn;
            KaretkaStart_ = KaretkaStartn;
            KaretkaEnd_ = KaretkaEndn;
            TurnFlakonStart_ = TurnFlakonStartn;
            TurnFlakonEnd_ = TurnFlakonEndn;
            AxisPrizhimStart_ = AxisPrizhimStartn;
            AxisPrizhimEnd_ = AxisPrizhimEndn;

            XParking_ = XParkingn;
            YParking_ = YParkingn;
            ZParking_ = ZParkingn;
            AParking_ = AParkingn;
            BParking_ = BParkingn;

            for (int i = 0; i < AllSpeed.Count; i++)
            {
                AllSpeed_.Add(AllSpeedn[i]);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Произошла ошибка, перезапустите приложение");
            StreamWriter WriteException = new StreamWriter(logPathes.Exceptions);
            WriteException.WriteLine(ex);
            WriteException.Close();
        }
    }

    //===========================================================================
    //======================== Изменение рабочего файла =========================
    //===========================================================================

    public void changeFile(string configDirectoryPath_, string configFilePath_, string configFileName_, string repeatsFileDirectory_)
    {
        try
        {
            Clear();                                        // Чистим класс
            configDirectoryPath = configDirectoryPath_;     // Изменяем путь директории
            configFilePath = configFilePath_;               // Изменяем полный путь к открытому файлу
            configFileName = configFileName_;               // Изменяем имя открытого конфига (это имя директории, в которой лежит конфиг)
            repeatsFileDirectory = repeatsFileDirectory_;   // Изменяем директорию, в которую будет записан файл с повторами
            FileRead();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Произошла ошибка, перезапустите приложение");
            StreamWriter WriteException = new StreamWriter(logPathes.Exceptions);
            WriteException.WriteLine(ex);
            WriteException.Close();
        }
    }

}