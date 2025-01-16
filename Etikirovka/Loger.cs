class logPathes
{
    private static string mainDirectory = @"..\..\..\..\Logs";
    private static string replacerLogs = @"..\..\..\..\Logs\Replacer";
    private static string fileReadLogs = @"..\..\..\..\Logs\FileRead";
    private static string exceptions = @"..\..\..\..\Logs\Exceptions";

    static List<string> allDirectories = new List<string>
        {
            "Replacer",
            "FileRead",
            "Exceptions"
        };

    //===========================================================================
    //====================== Поиск пути для вывода ошибок =======================
    //===========================================================================

    public static string Exceptions
    {
        get
        {
            startDirectories();

            string CurrentPath = $@"{exceptions}";
            DirectoryInfo DirInfo = new DirectoryInfo(CurrentPath);
            string TodayDate = DateTime.Now.ToString("dd.MM.yyyy");

            bool Sovpadenie = false;
            foreach (DirectoryInfo Directories in DirInfo.GetDirectories())
            {
                if (Directories.Exists)
                {
                    if (Directories.Name == TodayDate)
                    {
                        Sovpadenie = true;
                        CurrentPath += $@"\{Directories.Name}";
                    }
                }
            }
            if (!Sovpadenie)
            {
                string DirectoryToCreate = $@"{CurrentPath}\{TodayDate}";
                Directory.CreateDirectory(DirectoryToCreate);
                CurrentPath = DirectoryToCreate;
            }

            DirectoryInfo CurrentDirectoryInfo = new DirectoryInfo(CurrentPath);
            int LogName = 0;

            foreach (FileInfo file in CurrentDirectoryInfo.GetFiles())
            {
                if (file.Exists)
                {
                    int fileNumber = int.Parse(file.Name.Split('.')[0]);
                    if (fileNumber > LogName)
                    {
                        LogName = fileNumber;
                    }
                }
            }

            LogName++;

            CurrentPath += $@"\{LogName}.txt";

            return CurrentPath;
        }
    }

    //===========================================================================
    //========== Поиск пути для вывода логов функции изменения файлов ===========
    //===========================================================================

    public static string ReplacerLogs
    {
        get
        {
            startDirectories();

            string CurrentPath = $@"{replacerLogs}";
            DirectoryInfo DirInfo = new DirectoryInfo(CurrentPath);
            string TodayDate = DateTime.Now.ToString("dd.MM.yyyy");

            bool Sovpadenie = false;
            foreach (DirectoryInfo Directories in DirInfo.GetDirectories())
            {
                if (Directories.Exists)
                {
                    if (Directories.Name == TodayDate)
                    {
                        Sovpadenie = true;
                        CurrentPath += $@"\{Directories.Name}";
                    }
                }
            }
            if (!Sovpadenie)
            {
                string DirectoryToCreate = $@"{CurrentPath}\{TodayDate}";
                Directory.CreateDirectory(DirectoryToCreate);
                CurrentPath = DirectoryToCreate;
            }

            DirectoryInfo CurrentDirectoryInfo = new DirectoryInfo(CurrentPath);
            int LogName = 0;

            foreach (FileInfo file in CurrentDirectoryInfo.GetFiles())
            {
                if (file.Exists)
                {
                    int fileNumber = int.Parse(file.Name.Split('.')[0]);
                    if (fileNumber > LogName)
                    {
                        LogName = fileNumber;
                    }
                }
            }

            LogName++;

            CurrentPath += $@"\{LogName}.txt";

            return CurrentPath;
        }
    }

    //===========================================================================
    //============ Поиск пути для вывода логов функции чтения файлов ============
    //===========================================================================

    public static string FileReadLogs
    {
        get
        {
            startDirectories();

            string CurrentPath = $@"{fileReadLogs}";
            DirectoryInfo DirInfo = new DirectoryInfo(CurrentPath);
            string TodayDate = DateTime.Now.ToString("dd.MM.yyyy");

            bool Sovpadenie = false;
            foreach (DirectoryInfo Directories in DirInfo.GetDirectories())
            {
                if (Directories.Exists)
                {
                    if (Directories.Name == TodayDate)
                    {
                        Sovpadenie = true;
                        CurrentPath += $@"\{Directories.Name}";
                    }
                }
            }
            if (!Sovpadenie)
            {
                string DirectoryToCreate = $@"{CurrentPath}\{TodayDate}";
                Directory.CreateDirectory(DirectoryToCreate);
                CurrentPath = DirectoryToCreate;
            }

            DirectoryInfo CurrentDirectoryInfo = new DirectoryInfo(CurrentPath);
            int LogName = 0;

            foreach (FileInfo file in CurrentDirectoryInfo.GetFiles())
            {
                if (file.Exists)
                {
                    int fileNumber = int.Parse(file.Name.Split('.')[0]);
                    if (fileNumber > LogName)
                    {
                        LogName = fileNumber;
                    }
                }
            }

            LogName++;

            CurrentPath += $@"\{LogName}.txt";

            return CurrentPath;
        }
    }

    //===========================================================================
    //================= Проверка наличия всех директорий логов ==================
    //===========================================================================

    private static void startDirectories()
    {
        DirectoryInfo DirInfo = new DirectoryInfo(mainDirectory);
        List<string> forFixing = new List<string>();

        for (int i = 0; i < allDirectories.Count; i++)
        {
            forFixing.Add("");
            foreach (DirectoryInfo Dir in DirInfo.GetDirectories())
            {
                if (Dir.Name == allDirectories[i])
                {
                    Console.WriteLine($"Было: {forFixing[i]}");
                    forFixing[i] = Dir.Name;
                    Console.WriteLine($"Стало: {forFixing[i]}");
                }
            }
        }

        for (int i = 0; i < forFixing.Count; i++)
        {
            Console.WriteLine($"{i}) {forFixing[i]}");
            if (forFixing[i] == "")
            {
                Console.WriteLine($"Создаю директорию ({allDirectories[i]})");
                string CreatePath = $@"{mainDirectory}\{allDirectories[i]}";
                Directory.CreateDirectory(CreatePath);
            }
        }
    }
}