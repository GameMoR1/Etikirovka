using System;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Reflection;
using static System.Windows.Forms.LinkLabel;

class checkDirectories
{
    private int configsCount = 0;
    private bool isConfigsDirectory = false;
    private List<string> configs = new List<string>();
    private List<string> openedConfigsData = new List<string>();

    public string openedFileConfigDirectoryPath;
    public string openedFileConfigPath;
    public string openedFileConfigName;
    public string repeatsFileDirectory;

    public List<string> openedConfigsData_
    {
        get
        {
            return openedConfigsData;
        }
    }

    public List<string> configs_
    {
        get
        {
            return configs;
        }
    }

    public bool isConfigsDirectory_
    {
        get
        {
            return isConfigsDirectory;
        }
    }

    public int configsCount_
    {
        get
        {
            return configsCount;
        }
    }

    //===========================================================================
    //=================== Проверка наличия директории конфигов ==================
    //===========================================================================

    private void checkConfigsDirectory(string DirectoryName)
    {
        try
        {
            DirectoryInfo dirInfo = new DirectoryInfo($@"..\..\..\..\");    // Новый объект директории
            var directories = dirInfo.GetDirectories();                     // Записываем все имена директорий в массив
            foreach (var directory in directories)                          // Цикл для каждого имени в массиве
            {
                if (directory.Name == DirectoryName)                        // если имя директории совпадает с "Configs", то пропускаем
                {
                    isConfigsDirectory = true;                              // Устанавливаем переменную наличия директориив true
                    return;                                                 // Краш функции
                }
            }
            createConfigDirectory(DirectoryName);                           // При условии, что if не сработал - будет вызвана функция создания директории
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
    //=========================== Создание директории ===========================
    //===========================================================================

    private void createConfigDirectory(string DirectoryName)
    {
        try
        {
            DirectoryInfo dirInfo = new DirectoryInfo($@"..\..\..\..\");    // Новый объект директории
            dirInfo.CreateSubdirectory(DirectoryName);                      // Создаем директорию для конфигов
            isConfigsDirectory = true;                                      // Устанавливаем переменную наличия директориив true
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
    //============================= Создание корней =============================
    //===========================================================================

    public static void createDirectoryIfNotExists(string pathInput)
    {
        try
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"..\..\..\..\Repeats");  // Создаем объект
            if (dirInfo.Exists)                                                 // Если если директории
            {
                var inputPathLength = pathInput.Split(@"\").Length;             // Записываем длинну спличеного пути
                foreach (DirectoryInfo dir in dirInfo.GetDirectories())         // Для каждой директории в родительской
                {
                    if (dir.Name == pathInput.Split(@"\")[--inputPathLength])   // Если имена совпадают
                    {
                        return;                                                 // Крашим функцию
                    }
                }
            }
            Directory.CreateDirectory(pathInput);                               // Создаем директорию
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
    //======================= Счетчик количества конфигов =======================
    //===========================================================================

    private void countConfigs()
    {
        try
        {
            DirectoryInfo dirInfo = new DirectoryInfo($@"..\..\..\..\Configs"); // Новый объект директории
            var directories = dirInfo.GetDirectories();                         // Получаем все директории
            configsCount = directories.Length;                                  // Записываем количество директорий
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
    //============== Получаем все названия директорий с конфигами ===============
    //===========================================================================

    public void directoryNames()
    {
        try
        {
            configs.Clear();                                                    // Стираем прошлый лист
            DirectoryInfo dirInfo = new DirectoryInfo($@"..\..\..\..\Configs"); // Новый объект директории
            var directories = dirInfo.GetDirectories();                         // Получаем все директории
            foreach (var directory in directories)                              // Цикл для записи имен директорий в лист
            {
                configs.Add(directory.Name);                                    // Записываем новый элемент в лист
            }
            countConfigs();                                                     // Считаем количество конфигов
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
    //================== Получаем данные из конфига по индексу ==================
    //===========================================================================

    public void dataOUT(int index)
    {
        try
        {
            openedConfigsData.Clear();                                                                              // Стираем прошлый лист
            DirectoryInfo dirInfo = new DirectoryInfo($@"..\..\..\..\Configs\{configs[index]}");                    // Получаем данные директории под выбранным индексом
            var filesInfo = dirInfo.GetFiles("*.gcode")[0];                                                           // Получаем имя файла с расширением .gcode
            openedFileConfigDirectoryPath = $@"..\..\..\..\Configs\{configs[index]}";                               // Записываем путь открытого конфига
            openedFileConfigPath = filesInfo.FullName;                                                              // Записываем путь
            openedFileConfigName = configs[index];                                                                  // Записываем имя кинфога
            repeatsFileDirectory = $@"..\..\..\..\Repeats\{configs[index]}";
            StreamReader dataReader = new StreamReader($@"..\..\..\..\Configs\{configs[index]}\{filesInfo.Name}");  // Открываем файл для чтения
            string line;                                                                                            // Создаем переменную, костыль((
            while ((line = dataReader.ReadLine()) != null)                                                          // Чтение строк до конца файла
            {
                openedConfigsData.Add(line);                                                                        // Добавление строки в список
            }
            dataReader.Close();                                                                                     // Закрываем ридер
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
    //===================== Чистим пустые директории кофигов ====================
    //===========================================================================

    private void DirectoryDeletion()
    {
        try
        {
            DirectoryInfo dir = new DirectoryInfo($@"..\..\..\..\Configs");     // Создаем объект
            var dirInfo = dir.GetDirectories();                                 // Получаем все директории с конфигами
            foreach (var directory in dirInfo)                                  // Цикл для каждой директории
            {
                var filesInfo = directory.GetFiles("*.gcode");                    // Получаем все .gcode файлы из директории
                if (filesInfo.Length < 1)                                       // Если файлов .gcode нет
                {
                    var filesToDelete = directory.GetFiles();                   // Массив с файлами для удаления
                    foreach (var file in filesToDelete)                         // Для каждого файла из массива
                    {
                        file.Delete();                                          // Удалить файл
                    }
                    directory.Delete();                                         // Удаляем директорию
                }
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
    //============================= Удаление конфига ============================
    //===========================================================================

    public void DeleteConfig()
    {
        try
        {
            File.Delete(openedFileConfigPath);                  //Удалить файл
            Directory.Delete(openedFileConfigDirectoryPath);    //Удалить директорию
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
    //=========================== Конструкторы класса ===========================
    //===========================================================================

    public checkDirectories()                   // Основной конструктор
    {
        DirectoryDeletion();                    // Чистка директории конфигов
        checkConfigsDirectory("Configs");       // Вызов функции проверки наличия директории Configs
        checkConfigsDirectory("Logs");          // Вызов функции проверки наличия директории Logs
        checkConfigsDirectory("Repeats");       // Вызов функции проверки наличия директории Repeats
        countConfigs();                         // Считаем количество конфигов
        directoryNames();                       // Заполняем переменную класса
    }
}