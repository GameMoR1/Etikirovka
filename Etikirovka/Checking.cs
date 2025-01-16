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
    //=================== �������� ������� ���������� �������� ==================
    //===========================================================================

    private void checkConfigsDirectory(string DirectoryName)
    {
        try
        {
            DirectoryInfo dirInfo = new DirectoryInfo($@"..\..\..\..\");    // ����� ������ ����������
            var directories = dirInfo.GetDirectories();                     // ���������� ��� ����� ���������� � ������
            foreach (var directory in directories)                          // ���� ��� ������� ����� � �������
            {
                if (directory.Name == DirectoryName)                        // ���� ��� ���������� ��������� � "Configs", �� ����������
                {
                    isConfigsDirectory = true;                              // ������������� ���������� ������� ����������� true
                    return;                                                 // ���� �������
                }
            }
            createConfigDirectory(DirectoryName);                           // ��� �������, ��� if �� �������� - ����� ������� ������� �������� ����������
        }
        catch (Exception ex)
        {
            MessageBox.Show("��������� ������, ������������� ����������");
            StreamWriter WriteException = new StreamWriter(logPathes.Exceptions);
            WriteException.WriteLine(ex);
            WriteException.Close();
        }
    }

    //===========================================================================
    //=========================== �������� ���������� ===========================
    //===========================================================================

    private void createConfigDirectory(string DirectoryName)
    {
        try
        {
            DirectoryInfo dirInfo = new DirectoryInfo($@"..\..\..\..\");    // ����� ������ ����������
            dirInfo.CreateSubdirectory(DirectoryName);                      // ������� ���������� ��� ��������
            isConfigsDirectory = true;                                      // ������������� ���������� ������� ����������� true
        }
        catch (Exception ex)
        {
            MessageBox.Show("��������� ������, ������������� ����������");
            StreamWriter WriteException = new StreamWriter(logPathes.Exceptions);
            WriteException.WriteLine(ex);
            WriteException.Close();
        }
    }

    //===========================================================================
    //============================= �������� ������ =============================
    //===========================================================================

    public static void createDirectoryIfNotExists(string pathInput)
    {
        try
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"..\..\..\..\Repeats");  // ������� ������
            if (dirInfo.Exists)                                                 // ���� ���� ����������
            {
                var inputPathLength = pathInput.Split(@"\").Length;             // ���������� ������ ���������� ����
                foreach (DirectoryInfo dir in dirInfo.GetDirectories())         // ��� ������ ���������� � ������������
                {
                    if (dir.Name == pathInput.Split(@"\")[--inputPathLength])   // ���� ����� ���������
                    {
                        return;                                                 // ������ �������
                    }
                }
            }
            Directory.CreateDirectory(pathInput);                               // ������� ����������
        }
        catch (Exception ex)
        {
            MessageBox.Show("��������� ������, ������������� ����������");
            StreamWriter WriteException = new StreamWriter(logPathes.Exceptions);
            WriteException.WriteLine(ex);
            WriteException.Close();
        }
    }

    //===========================================================================
    //======================= ������� ���������� �������� =======================
    //===========================================================================

    private void countConfigs()
    {
        try
        {
            DirectoryInfo dirInfo = new DirectoryInfo($@"..\..\..\..\Configs"); // ����� ������ ����������
            var directories = dirInfo.GetDirectories();                         // �������� ��� ����������
            configsCount = directories.Length;                                  // ���������� ���������� ����������
        }
        catch (Exception ex)
        {
            MessageBox.Show("��������� ������, ������������� ����������");
            StreamWriter WriteException = new StreamWriter(logPathes.Exceptions);
            WriteException.WriteLine(ex);
            WriteException.Close();
        }
    }

    //===========================================================================
    //============== �������� ��� �������� ���������� � ��������� ===============
    //===========================================================================

    public void directoryNames()
    {
        try
        {
            configs.Clear();                                                    // ������� ������� ����
            DirectoryInfo dirInfo = new DirectoryInfo($@"..\..\..\..\Configs"); // ����� ������ ����������
            var directories = dirInfo.GetDirectories();                         // �������� ��� ����������
            foreach (var directory in directories)                              // ���� ��� ������ ���� ���������� � ����
            {
                configs.Add(directory.Name);                                    // ���������� ����� ������� � ����
            }
            countConfigs();                                                     // ������� ���������� ��������
        }
        catch (Exception ex)
        {
            MessageBox.Show("��������� ������, ������������� ����������");
            StreamWriter WriteException = new StreamWriter(logPathes.Exceptions);
            WriteException.WriteLine(ex);
            WriteException.Close();
        }
    }

    //===========================================================================
    //================== �������� ������ �� ������� �� ������� ==================
    //===========================================================================

    public void dataOUT(int index)
    {
        try
        {
            openedConfigsData.Clear();                                                                              // ������� ������� ����
            DirectoryInfo dirInfo = new DirectoryInfo($@"..\..\..\..\Configs\{configs[index]}");                    // �������� ������ ���������� ��� ��������� ��������
            var filesInfo = dirInfo.GetFiles("*.gcode")[0];                                                           // �������� ��� ����� � ����������� .gcode
            openedFileConfigDirectoryPath = $@"..\..\..\..\Configs\{configs[index]}";                               // ���������� ���� ��������� �������
            openedFileConfigPath = filesInfo.FullName;                                                              // ���������� ����
            openedFileConfigName = configs[index];                                                                  // ���������� ��� �������
            repeatsFileDirectory = $@"..\..\..\..\Repeats\{configs[index]}";
            StreamReader dataReader = new StreamReader($@"..\..\..\..\Configs\{configs[index]}\{filesInfo.Name}");  // ��������� ���� ��� ������
            string line;                                                                                            // ������� ����������, �������((
            while ((line = dataReader.ReadLine()) != null)                                                          // ������ ����� �� ����� �����
            {
                openedConfigsData.Add(line);                                                                        // ���������� ������ � ������
            }
            dataReader.Close();                                                                                     // ��������� �����
        }
        catch (Exception ex)
        {
            MessageBox.Show("��������� ������, ������������� ����������");
            StreamWriter WriteException = new StreamWriter(logPathes.Exceptions);
            WriteException.WriteLine(ex);
            WriteException.Close();
        }
    }

    //===========================================================================
    //===================== ������ ������ ���������� ������� ====================
    //===========================================================================

    private void DirectoryDeletion()
    {
        try
        {
            DirectoryInfo dir = new DirectoryInfo($@"..\..\..\..\Configs");     // ������� ������
            var dirInfo = dir.GetDirectories();                                 // �������� ��� ���������� � ���������
            foreach (var directory in dirInfo)                                  // ���� ��� ������ ����������
            {
                var filesInfo = directory.GetFiles("*.gcode");                    // �������� ��� .gcode ����� �� ����������
                if (filesInfo.Length < 1)                                       // ���� ������ .gcode ���
                {
                    var filesToDelete = directory.GetFiles();                   // ������ � ������� ��� ��������
                    foreach (var file in filesToDelete)                         // ��� ������� ����� �� �������
                    {
                        file.Delete();                                          // ������� ����
                    }
                    directory.Delete();                                         // ������� ����������
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("��������� ������, ������������� ����������");
            StreamWriter WriteException = new StreamWriter(logPathes.Exceptions);
            WriteException.WriteLine(ex);
            WriteException.Close();
        }
    }

    //===========================================================================
    //============================= �������� ������� ============================
    //===========================================================================

    public void DeleteConfig()
    {
        try
        {
            File.Delete(openedFileConfigPath);                  //������� ����
            Directory.Delete(openedFileConfigDirectoryPath);    //������� ����������
        }
        catch (Exception ex)
        {
            MessageBox.Show("��������� ������, ������������� ����������");
            StreamWriter WriteException = new StreamWriter(logPathes.Exceptions);
            WriteException.WriteLine(ex);
            WriteException.Close();
        }
    }

    //===========================================================================
    //=========================== ������������ ������ ===========================
    //===========================================================================

    public checkDirectories()                   // �������� �����������
    {
        DirectoryDeletion();                    // ������ ���������� ��������
        checkConfigsDirectory("Configs");       // ����� ������� �������� ������� ���������� Configs
        checkConfigsDirectory("Logs");          // ����� ������� �������� ������� ���������� Logs
        checkConfigsDirectory("Repeats");       // ����� ������� �������� ������� ���������� Repeats
        countConfigs();                         // ������� ���������� ��������
        directoryNames();                       // ��������� ���������� ������
    }
}