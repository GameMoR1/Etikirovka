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
    //========================== �������� ����� ����� ===========================
    //===========================================================================

    public string TestingOuts()
    {
        return $"���� � ���������� �������:\n{configDirectoryPath}\n" +
            $"���� � ����� �������:\n{configFilePath}\n" +
            $"��� ����� �������:\n{configFileName}\n";
    }

    //===========================================================================
    //============================= ������ ������� ==============================
    //===========================================================================

    public void FileRead()
    {
        Clear();                                                                            // ������ �����
        StreamWriter WriterLogs = new StreamWriter(logPathes.FileReadLogs);                 // ��������� �����
        WriterLogs.WriteLine($"���� �� {DateTime.Now}");                                    // ���������� ���� �����
        try
        {
            var LineCounter = File.ReadLines(configFilePath);                               // ���������� ������ ��� �� ��������
            float countLines = 0;                                                           // ���������� �������� �����
            foreach (var line in LineCounter)                                               // ���� ��� ��������
            {
                countLines++;                                                               // ���������� ��������
            }
            float forHomes = countLines / 2;                                                // ����� ���������� ����� ��� ������������ ����������� ��������

            StreamReader ConfigReader = new StreamReader(configFilePath);                   // ������ ����

            string lineM;                                                                   // ������� ����������, �������((
            int listsCounter = -1;                                                          // ������� �������� ������

            while ((lineM = ConfigReader.ReadLine()) != null)                               // ������ ����� �� ����� �����, ���������
            {
                listsCounter++;                                                             // ��������� �������� � ���������� �������� ������

                WriterLogs.WriteLine($"����� {listsCounter}) {lineM}");

                if ((lineM != "") && (lineM.ToCharArray()[0] == ';'))                       // ���� ������ �� ������ � ������ ������ ������ - ;
                {
                    string line = lineM.Replace(';', ' ').Trim();                           // ������� ������ ������� � ������ � � �����, ����������-�������
                    var peremennie = line.Split(',');                                       // ������ �� ����������� ������� ���������� � �����
                    string SecondLine = ConfigReader.ReadLine();                            // ������ ������ ������
                    listsCounter++;                                                         // ��������� �������� � ���������� �������� ������
                    WriterLogs.WriteLine($"����� {listsCounter}) {SecondLine}");
                    var gCode = SecondLine.Split(' ');                                      // ������ �� ����������� ��������� gCode
                    foreach (var p in peremennie)                                           // ���� ��� ��������� ����������
                    {
                        string peremennaya = p.Trim();                                      // ������� ������ ������� � ������ � � �����, ����������-�������
                        WriterLogs.WriteLine($"peremennaya: {peremennaya}");

                        // ����� ���� ������, ������� ������� �� ����� ���� ���������� � ������ ������ ������, ����
                        // if �����������, ������ ������ ������� �� ������ � ������ ��������, ������ ��������� ������
                        // ����� ������� ��������������, ��������� ������ �������, ���� 1 ������ ��������� � ���, ���
                        // ��� ����� - ����� ��� ������� ���� � ���������, ��������� ����� ���� ��� �������� �������
                        // ������� (������� ��� �����������, ��� �� ������� � �������� ����� �� �� ������ ����������),
                        // ������ �������� � ���� ����������, ���������� ����������� � ������ (List) ��� ����������
                        // ��������� ��� ���������� ������.

                        // ��������� ���������� ������ � �������:
                        // {��� ����������}|{����� ������}

                        if (peremennaya == "home_x")
                        {
                            if (listsCounter < forHomes)
                            {
                                XParking = true;
                            }
                            WriterLogs.WriteLine($"������: home_x|{listsCounter}");
                            WriterLogs.WriteLine("����������: " + XParking);
                            ChangingSaveParking.Add($"home_x|{listsCounter}");
                        }
                        if (peremennaya == "home_y")
                        {
                            if (listsCounter < forHomes)
                            {
                                YParking = true;
                            }
                            WriterLogs.WriteLine($"������: home_y|{listsCounter}");
                            WriterLogs.WriteLine("����������: " + YParking);
                            ChangingSaveParking.Add($"home_y|{listsCounter}");
                        }
                        if (peremennaya == "home_z")
                        {
                            if (listsCounter < forHomes)
                            {
                                ZParking = true;
                            }
                            WriterLogs.WriteLine($"������: home_z|{listsCounter}");
                            WriterLogs.WriteLine("����������: " + ZParking);
                            ChangingSaveParking.Add($"home_z|{listsCounter}");
                        }
                        if (peremennaya == "home_a")
                        {
                            if (listsCounter < forHomes)
                            {
                                AParking = true;
                            }
                            WriterLogs.WriteLine($"������: home_a|{listsCounter}");
                            WriterLogs.WriteLine("����������: " + AParking);
                            ChangingSaveParking.Add($"home_a|{listsCounter}");
                        }
                        if (peremennaya == "home_b")
                        {
                            if (listsCounter < forHomes)
                            {
                                BParking = true;
                            }
                            WriterLogs.WriteLine($"������: home_b|{listsCounter}");
                            WriterLogs.WriteLine("����������: " + BParking);
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
                                    WriterLogs.WriteLine($"������: feedrate_x|{listsCounter}");
                                    WriterLogs.WriteLine("����������: " + XSpeed);
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
                                    WriterLogs.WriteLine($"������: feedrate_y|{listsCounter}");
                                    WriterLogs.WriteLine("����������: " + YSpeed);
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
                                    WriterLogs.WriteLine($"������: feedrate_z|{listsCounter}");
                                    WriterLogs.WriteLine("����������: " + ZSpeed);
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
                                    WriterLogs.WriteLine($"������: feedrate_a|{listsCounter}");
                                    WriterLogs.WriteLine("����������: " + ASpeed);
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
                                    WriterLogs.WriteLine($"������: feedrate_b|{listsCounter}");
                                    WriterLogs.WriteLine("����������: " + BSpeed);
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

                                    WriterLogs.WriteLine($"������: allFeedrate|{listsCounter}");
                                    ChangingSave.Add($"allFeedrate|{listsCounter}");

                                    itog += $" {comboName}";

                                    AllSpeed.Add(itog);
                                    WriterLogs.WriteLine("����������: " + itog);
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
                                    WriterLogs.WriteLine($"������: start_x|{listsCounter}");
                                    WriterLogs.WriteLine("����������: " + FlyStart);
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
                                    WriterLogs.WriteLine($"������: start_y|{listsCounter}");
                                    WriterLogs.WriteLine("����������: " + ValikStart);
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
                                    WriterLogs.WriteLine($"������: end_y|{listsCounter}");
                                    WriterLogs.WriteLine("����������: " + ValikEnd);
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
                                    WriterLogs.WriteLine($"������: start_z|{listsCounter}");
                                    WriterLogs.WriteLine("����������: " + KaretkaStart);
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
                                    WriterLogs.WriteLine($"������: end_z|{listsCounter}");
                                    WriterLogs.WriteLine("����������: " + KaretkaEnd);
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
                                    WriterLogs.WriteLine($"������: start_a|{listsCounter}");
                                    WriterLogs.WriteLine("����������: " + TurnFlakonStart);
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
                                    WriterLogs.WriteLine($"������: end_a|{listsCounter}");
                                    WriterLogs.WriteLine("����������: " + TurnFlakonEnd);
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
                                    WriterLogs.WriteLine($"������: start_b|{listsCounter}");
                                    WriterLogs.WriteLine("����������: " + AxisPrizhimStart);
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
                                    WriterLogs.WriteLine($"������: end_b|{listsCounter}");
                                    WriterLogs.WriteLine("����������: " + AxisPrizhimEnd);
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
                                    WriterLogs.WriteLine($"������: clamp_b|{listsCounter}");
                                    WriterLogs.WriteLine("����������: " + ZazhimFlakon);
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
                                    WriterLogs.WriteLine($"������: clamp_y|{listsCounter}");
                                    WriterLogs.WriteLine("����������: " + PrizhimValika);
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
                                    WriterLogs.WriteLine($"������: rotate_a|{listsCounter}");
                                    WriterLogs.WriteLine("����������: " + TurnFlakon);
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
                                    WriterLogs.WriteLine($"������: delay_s|{listsCounter}");
                                    WriterLogs.WriteLine("����������: " + Delay);
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
            MessageBox.Show("��������� ������, ������������� ����������");
            StreamWriter WriteException = new StreamWriter(logPathes.Exceptions);
            WriteException.WriteLine(ex);
            WriteException.Close();
        }
        if(Delay == 0)
        {
            WriterLogs.WriteLine("�������� delay_s �����������");
        }
        else
        {
            WriterLogs.WriteLine("�������� delay_s ������������");
        }
        WriterLogs.WriteLine();
        WriterLogs.WriteLine();
        WriterLogs.Close();
    }

    //===========================================================================
    //========================= ����� ������ �������  ===========================
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
    //============================= ������ ������ ===============================
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
            MessageBox.Show("��������� ������, ������������� ����������");
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
            MessageBox.Show("��������� ������, ������������� ����������");
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
            MessageBox.Show("��������� ������, ������������� ����������");
            StreamWriter WriteException = new StreamWriter(logPathes.Exceptions);
            WriteException.WriteLine(ex);
            WriteException.Close();
        }
    }

    //===========================================================================
    //=========================== ��������� ������� =============================
    //===========================================================================

    public void Replacer()
    {
        StreamWriter WriterLogs = new StreamWriter(logPathes.ReplacerLogs);         // ��������� �����
        WriterLogs.WriteLine($"���� �� {DateTime.Now}");                            // ���������� ���� �����
        try
        {
            var lines = File.ReadAllLines(configFilePath);                          // ���������� ������ � ������ ��� �� �������� � ������ � ����
            int linesCount = lines.Length;                                          // ���������� ���������� ����� � �����
            List<string> newFile = new List<string>();                              // ������� ���� (����� ������, �� � ��� ����� ��������)

            for (int i = 0; i < linesCount; i++)                                    // ���� ��� �������� *�����* � �����, �������
            {
                newFile.Add("");                                                    // ��������� ������
            }

            List<int> otschetStrok = new List<int>();                               // ���� ��� ���������� ������������� ����� � ����������� �����������

            int counterForFeedrate = 0;                                             // ������� ����� ��� ���������� ��������
            foreach (var change in ChangingSave)                                    // ���� ��� ��������� ������� �������� � �����
            {
                var splitedChange = change.Split('|');                              // �������� ����������� ����������
                int lineNumber = int.Parse(splitedChange[1]);                       // �������� ����� ������, � ������� ����� �������� ����������

                bool sovpadeniya = false;                                           // ���������� ��� ����������� ����, ��� ������ �����������
                foreach (var list in otschetStrok)                                  // ���� ��� ������ ������������� �����
                {
                    if (list == lineNumber)                                         // ���� ������ ���������
                    {
                        sovpadeniya = true;                                         // ��������� ���������� � true
                    }
                }
                if (!sovpadeniya)                                                   // ���� ���������� �������� false, ���������� ������ � ����
                {
                    otschetStrok.Add(lineNumber);                                   // ������ ������
                }

                WriterLogs.WriteLine($"���������� sovpadeniya: {sovpadeniya}");

                // ����� ���� ������ ����������, ������ � ������ ������. ������� if �� else
                // ���� � ���, ��� � else ���� ��������� ���������� ��� � ����� �������, �
                // �� � ������ � ������. ��� ��� ������� ����� ��������� ��������, ��� ���
                // � ������ � ��������� �� ������ ������ � ��������, ��� ��� �������� � 
                // ������ ������� ������ =) ���� ����� ������� � ���� ���������� ��������

                // ��������� �������� ���, ��� � ������ � ����� ���������� �������� �������
                // �� �����, ��� ��� gCode ��� ������ �����, ����� ���� ��������� ������ �
                // �������� �������, ������ ������� ������ �� ������ �����, �������� 
                // ���������� (�� � �������, �� ��������� ������) � ������������ � �������� ������


                if (!sovpadeniya)                                                   // ���� ���������� ������
                {
                    if (splitedChange[0] == "feedrate_x")
                    {
                        WriterLogs.WriteLine($"������ ������ lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = XSpeed.ToString().Replace(',', '.');
                        string newData = XSpeed_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (XSpeed): {oldData}\n" +
                            $"����� �������� (XSpeed_): {newData}");
                    }
                    else if (splitedChange[0] == "feedrate_y")
                    {
                        WriterLogs.WriteLine($"������ ������ lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = YSpeed.ToString().Replace(',', '.');
                        string newData = YSpeed_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (YSpeed): {oldData}\n" +
                            $"����� �������� (YSpeed_): {newData}");
                    }
                    else if (splitedChange[0] == "feedrate_z")
                    {
                        WriterLogs.WriteLine($"������ ������ lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = ZSpeed.ToString().Replace(',', '.');
                        string newData = ZSpeed_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (ZSpeed): {oldData}\n" +
                            $"����� �������� (ZSpeed_): {newData}");
                    }
                    else if (splitedChange[0] == "feedrate_a")
                    {
                        WriterLogs.WriteLine($"������ ������ lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = ASpeed.ToString().Replace(',', '.');
                        string newData = ASpeed_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (ASpeed): {oldData}\n" +
                            $"����� �������� (ASpeed_): {newData}");
                    }
                    else if (splitedChange[0] == "feedrate_b")
                    {
                        WriterLogs.WriteLine($"������ ������ lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = BSpeed.ToString().Replace(',', '.');
                        string newData = BSpeed_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (BSpeed): {oldData}\n" +
                            $"����� �������� (BSpeed_): {newData}");
                    }
                    else if (splitedChange[0] == "start_x")
                    {
                        WriterLogs.WriteLine($"������ ������ lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = FlyStart.ToString().Replace(',', '.');
                        string newData = FlyStart_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (FlyStart): {oldData}\n" +
                            $"����� �������� (FlyStart_): {newData}");
                    }
                    else if (splitedChange[0] == "start_y")
                    {
                        WriterLogs.WriteLine($"������ ������ lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = ValikStart.ToString().Replace(',', '.');
                        string newData = ValikStart_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (ValikStart): {oldData}\n" +
                            $"����� �������� (ValikStart_): {newData}");
                    }
                    else if (splitedChange[0] == "end_y")
                    {
                        WriterLogs.WriteLine($"������ ������ lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = ValikEnd.ToString().Replace(',', '.');
                        string newData = ValikEnd_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (ValikEnd): {oldData}\n" +
                            $"����� �������� (ValikEnd_): {newData}");
                    }
                    else if (splitedChange[0] == "start_z")
                    {
                        WriterLogs.WriteLine($"������ ������ lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = KaretkaStart.ToString().Replace(',', '.');
                        string newData = KaretkaStart_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (KaretkaStart): {oldData}\n" +
                            $"����� �������� (KaretkaStart_): {newData}");
                    }
                    else if (splitedChange[0] == "end_z")
                    {
                        WriterLogs.WriteLine($"������ ������ lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = KaretkaEnd.ToString().Replace(',', '.');
                        string newData = KaretkaEnd_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (KaretkaEnd): {oldData}\n" +
                            $"����� �������� (KaretkaEnd_): {newData}");
                    }
                    else if (splitedChange[0] == "start_a")
                    {
                        WriterLogs.WriteLine($"������ ������ lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = TurnFlakonStart.ToString().Replace(',', '.');
                        string newData = TurnFlakonStart_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (TurnFlakonStart): {oldData}\n" +
                            $"����� �������� (TurnFlakonStart_): {newData}");
                    }
                    else if (splitedChange[0] == "end_a")
                    {
                        WriterLogs.WriteLine($"������ ������ lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = TurnFlakonEnd.ToString().Replace(',', '.');
                        string newData = TurnFlakonEnd_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (TurnFlakonEnd): {oldData}\n" +
                            $"����� �������� (TurnFlakonEnd_): {newData}");
                    }
                    else if (splitedChange[0] == "start_b")
                    {
                        WriterLogs.WriteLine($"������ ������ lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = AxisPrizhimStart.ToString().Replace(',', '.');
                        string newData = AxisPrizhimStart_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (AxisPrizhimStart): {oldData}\n" +
                            $"����� �������� (AxisPrizhimStart_): {newData}");
                    }
                    else if (splitedChange[0] == "end_b")
                    {
                        WriterLogs.WriteLine($"������ ������ lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = AxisPrizhimEnd.ToString().Replace(',', '.');
                        string newData = AxisPrizhimEnd_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (AxisPrizhimEnd): {oldData}\n" +
                            $"����� �������� (AxisPrizhimEnd_): {newData}");
                    }
                    else if (splitedChange[0] == "delay_s")
                    {
                        WriterLogs.WriteLine($"������ ������ lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = Delay.ToString().Replace(',', '.');
                        string newData = Delay_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (Delay): {oldData}\n" +
                            $"����� �������� (Delay_): {newData}");
                    }
                    else if (splitedChange[0] == "rotate_a")
                    {
                        WriterLogs.WriteLine($"������ ������ lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = TurnFlakon.ToString().Replace(',', '.');
                        string newData = TurnFlakon_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (TurnFlakon): {oldData}\n" +
                            $"����� �������� (TurnFlakon_): {newData}");
                    }
                    else if (splitedChange[0] == "clamp_b")
                    {
                        WriterLogs.WriteLine($"������ ������ lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = ZazhimFlakon.ToString().Replace(',', '.');
                        string newData = ZazhimFlakon_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (ZazhimFlakon): {oldData}\n" +
                            $"����� �������� (ZazhimFlakon_): {newData}");
                    }
                    else if (splitedChange[0] == "clamp_y")
                    {
                        WriterLogs.WriteLine($"������ ������ lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = PrizhimValika.ToString().Replace(',', '.');
                        string newData = PrizhimValika_.ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (PrizimValika): {oldData}\n" +
                            $"����� �������� (PrizimValika_): {newData}");
                    }
                    else if (splitedChange[0] == "allFeedrate")
                    {
                        var AllSpeedSplited = AllSpeed[counterForFeedrate].Split(" ");
                        var AllSpeed_Splited = AllSpeed_[counterForFeedrate].Split(" ");
                        WriterLogs.WriteLine($"������ ������ lines[{lineNumber}]: {lines[lineNumber]}");
                        string oldData = AllSpeedSplited[0].ToString().Replace(',', '.');
                        string newData = AllSpeed_Splited[0].ToString().Replace(',', '.');

                        newFile[lineNumber] = lines[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (allFeedrate): {oldData}\n" +
                            $"����� �������� (allFeedrate_): {newData}");
                        counterForFeedrate++;
                    }
                }
                else // ���� ���������� ����
                {
                    if (splitedChange[0] == "feedrate_x")
                    {
                        WriterLogs.WriteLine($"������ ������ newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = XSpeed.ToString().Replace(',', '.');
                        string newData = XSpeed_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (XSpeed): {oldData}\n" +
                            $"����� �������� (XSpeed_): {newData}");
                    }
                    else if (splitedChange[0] == "feedrate_y")
                    {
                        WriterLogs.WriteLine($"������ ������ newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = YSpeed.ToString().Replace(',', '.');
                        string newData = YSpeed_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (YSpeed): {oldData}\n" +
                            $"����� �������� (YSpeed_): {newData}");
                    }
                    else if (splitedChange[0] == "feedrate_z")
                    {
                        WriterLogs.WriteLine($"������ ������ newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = ZSpeed.ToString().Replace(',', '.');
                        string newData = ZSpeed_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (ZSpeed): {oldData}\n" +
                            $"����� �������� (ZSpeed_): {newData}");
                    }
                    else if (splitedChange[0] == "feedrate_a")
                    {
                        WriterLogs.WriteLine($"������ ������ newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = ASpeed.ToString().Replace(',', '.');
                        string newData = ASpeed_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (ASpeed): {oldData}\n" +
                            $"����� �������� (ASpeed_): {newData}");
                    }
                    else if (splitedChange[0] == "feedrate_b")
                    {
                        WriterLogs.WriteLine($"������ ������ newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = BSpeed.ToString().Replace(',', '.');
                        string newData = BSpeed_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (BSpeed): {oldData}\n" +
                            $"����� �������� (BSpeed_): {newData}");
                    }
                    else if (splitedChange[0] == "start_x")
                    {
                        WriterLogs.WriteLine($"������ ������ newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = FlyStart.ToString().Replace(',', '.');
                        string newData = FlyStart_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (FlyStart): {oldData}\n" +
                            $"����� �������� (FlyStart_): {newData}");
                    }
                    else if (splitedChange[0] == "start_y")
                    {
                        WriterLogs.WriteLine($"������ ������ newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = ValikStart.ToString().Replace(',', '.');
                        string newData = ValikStart_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (ValikStart): {oldData}\n" +
                            $"����� �������� (ValikStart_): {newData}");
                    }
                    else if (splitedChange[0] == "end_y")
                    {
                        WriterLogs.WriteLine($"������ ������ newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = ValikEnd.ToString().Replace(',', '.');
                        string newData = ValikEnd_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (ValikEnd): {oldData}\n" +
                            $"����� �������� (ValikEnd_): {newData}");
                    }
                    else if (splitedChange[0] == "start_z")
                    {
                        WriterLogs.WriteLine($"������ ������ newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = KaretkaStart.ToString().Replace(',', '.');
                        string newData = KaretkaStart_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (KaretkaStart): {oldData}\n" +
                            $"����� �������� (KaretkaStart_): {newData}");
                    }
                    else if (splitedChange[0] == "end_z")
                    {
                        WriterLogs.WriteLine($"������ ������ newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = KaretkaEnd.ToString().Replace(',', '.');
                        string newData = KaretkaEnd_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (KaretkaEnd): {oldData}\n" +
                            $"����� �������� (KaretkaEnd_): {newData}");
                    }
                    else if (splitedChange[0] == "start_a")
                    {
                        WriterLogs.WriteLine($"������ ������ newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = TurnFlakonStart.ToString().Replace(',', '.');
                        string newData = TurnFlakonStart_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (TurnFlakonStart): {oldData}\n" +
                            $"����� �������� (TurnFlakonStart_): {newData}");
                    }
                    else if (splitedChange[0] == "end_a")
                    {
                        WriterLogs.WriteLine($"������ ������ newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = TurnFlakonEnd.ToString().Replace(',', '.');
                        string newData = TurnFlakonEnd_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (TurnFlakonEnd): {oldData}\n" +
                            $"����� �������� (TurnFlakonEnd_): {newData}");
                    }
                    else if (splitedChange[0] == "start_b")
                    {
                        WriterLogs.WriteLine($"������ ������ newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = AxisPrizhimStart.ToString().Replace(',', '.');
                        string newData = AxisPrizhimStart_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (AxisPrizhimStart): {oldData}\n" +
                            $"����� �������� (AxisPrizhimStart_): {newData}");
                    }
                    else if (splitedChange[0] == "end_b")
                    {
                        WriterLogs.WriteLine($"������ ������ newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = AxisPrizhimEnd.ToString().Replace(',', '.');
                        string newData = AxisPrizhimEnd_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (AxisPrizhimEnd): {oldData}\n" +
                            $"����� �������� (AxisPrizhimEnd_): {newData}");
                    }
                    else if (splitedChange[0] == "delay_s")
                    {
                        WriterLogs.WriteLine($"������ ������ newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = Delay.ToString().Replace(',', '.');
                        string newData = Delay_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (Delay): {oldData}\n" +
                            $"����� �������� (Delay_): {newData}");
                    }
                    else if (splitedChange[0] == "rotate_a")
                    {
                        WriterLogs.WriteLine($"������ ������ newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = TurnFlakon.ToString().Replace(',', '.');
                        string newData = TurnFlakon_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (TurnFlakon): {oldData}\n" +
                            $"����� �������� (TurnFlakon_): {newData}");
                    }
                    else if (splitedChange[0] == "clamp_b")
                    {
                        WriterLogs.WriteLine($"������ ������ newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = ZazhimFlakon.ToString().Replace(',', '.');
                        string newData = ZazhimFlakon_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (ZazhimFlakon): {oldData}\n" +
                            $"����� �������� (ZazhimFlakon_): {newData}");
                    }
                    else if (splitedChange[0] == "clamp_y")
                    {
                        WriterLogs.WriteLine($"������ ������ newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = PrizhimValika.ToString().Replace(',', '.');
                        string newData = PrizhimValika_.ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (PrizimValika): {oldData}\n" +
                            $"����� �������� (PrizimValika_): {newData}");
                    }
                    else if (splitedChange[0] == "allFeedrate")
                    {
                        var AllSpeedSplited = AllSpeed[counterForFeedrate].Split(" ");
                        var AllSpeed_Splited = AllSpeed_[counterForFeedrate].Split(" ");
                        WriterLogs.WriteLine($"������ ������ newFile[{lineNumber}]: {newFile[lineNumber]}");
                        string oldData = AllSpeedSplited[0].ToString().Replace(',', '.');
                        string newData = AllSpeed_Splited[0].ToString().Replace(',', '.');

                        newFile[lineNumber] = newFile[lineNumber].Replace($"{oldData}", $"{newData}");

                        WriterLogs.WriteLine($"����� ������ newFile[{lineNumber}]: {newFile[lineNumber]}\n" +
                            $"������ �������� (allFeedrate): {oldData}\n" +
                            $"����� �������� (allFeedrate_): {newData}");
                        counterForFeedrate++;
                    }
                }
                WriterLogs.WriteLine();
            }

            // ����� ���� ���������� �����, ������� �� ��������

            for (int i = 0; i < newFile.Count; i++) // ���� ��� ���������� �����
            {
                if (newFile[i] == "" || newFile[i] == null) // ���� ������ ������
                {
                    newFile[i] = lines[i]; // ���������� ������ � ������
                }
            }

            // ���� � ����������� ����� ���� ��������, �� �� ������ - ���������
            // if ������ ��� ����� ��������

            if (Delay != 0 && Delay_ == 0) // if ��� �������� ��������
            {
                WriterLogs.WriteLine("�������� �������� ����� ��������");
                for (int i = 0; i < 2; i++) // ���� ��� �������� 2 �����
                {
                    newFile.RemoveAt(--linesCount); // �������� �����
                    WriterLogs.WriteLine($"������� ������ {linesCount}");
                }
            }

            StreamWriter WriteFile = new StreamWriter(configFilePath); // ��������� ������ ������� � ����

            // ���������� ��� ��������� ��������

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

            // ���� � ������, ����� � ������
            if ((XParking && YParking && ZParking && AParking && BParking) && (XParking_ && YParking_ && ZParking_ && AParking_ && BParking_))
            {
                WriterLogs.WriteLine("���� � ������, ����� � ������");
                newFile[0] = startFirstLine;
                newFile[1] = startSecondLine;
            }
            // ���� � �����, ����� � �����
            else if ((!XParking && !YParking && !ZParking && !AParking && !BParking) && (!XParking_ && !YParking_ && !ZParking_ && !AParking_ && !BParking_))
            {
                WriterLogs.WriteLine("���� � �����, ����� � �����");
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
            // ���� � ������, ����� � �����
            else if ((XParking && YParking && ZParking && AParking && BParking) && (!XParking_ && !YParking_ && !ZParking_ && !AParking_ && !BParking_))
            {
                WriterLogs.WriteLine("���� � ������, ����� � �����");
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
            // ���� � �����, ����� � ������
            else if ((!XParking && !YParking && !ZParking && !AParking && !BParking) && (XParking_ && YParking_ && ZParking_ && AParking_ && BParking_))
            {
                WriterLogs.WriteLine("���� � �����, ����� � ������");
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
            // ���� �����, ����� � ������
            else if ((XParking || YParking || ZParking || AParking || BParking) && (XParking_ && YParking_ && ZParking_ && AParking_ && BParking_))
            {
                WriterLogs.WriteLine("���� �����, ����� � ������");
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
            // ���� �����, ����� � �����
            else if ((XParking || YParking || ZParking || AParking || BParking) && (!XParking_ && !YParking_ && !ZParking_ && !AParking_ && !BParking_))
            {
                WriterLogs.WriteLine("���� �����, ����� � �����");
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
            // ���� � ������, ����� �����
            else if ((XParking && YParking && ZParking && AParking && BParking) && (XParking_ || YParking_ || ZParking_ || AParking_ || BParking_))
            {
                WriterLogs.WriteLine("���� � ������, ����� �����");
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
            // ���� � �����, ����� � �����
            else if ((!XParking && !YParking && !ZParking && !AParking && !BParking) && (XParking_ || YParking_ || ZParking_ || AParking_ || BParking_))
            {
                WriterLogs.WriteLine("���� � �����, ����� � �����");
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
            // ���� �����, ����� �����
            else
            {
                WriterLogs.WriteLine("���� �����, ����� �����");
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

            if (Repeats_ > 1)                                                                       // ���� ���� ����������
            {
                foreach (var line in newFile)                                                       // ���� ��� ������ ������ ������ ������� � ����
                {
                    if (line != "" || line != null)                                                 // ��������� ������ ������, ���� ��� ��� ������ ��������)))
                    {
                        WriteFile.WriteLine(line);                                                  // ���������� ������ � ����
                    }
                }
                if (Delay == 0 && Delay_ != 0)                                                      // ���� �������� ������, �� ��� ���������
                {
                    int fileLength = newFile.Count;                                                 // ���������� ���������� ����� (��� ��� ������)
                    WriterLogs.WriteLine($"����� ������� G4 (delay_s), " +
                        $"��������� � ����� ({++fileLength}, {++fileLength} ������)"); 
                    WriteFile.WriteLine(";delay_s");                                                // ���������� ����������
                    WriteFile.WriteLine($"G4 S{Delay_}");                                           // ���������� �������
                }

                WriterLogs.WriteLine(repeatsFileDirectory + @"\1.gcode");
                checkDirectories.createDirectoryIfNotExists(repeatsFileDirectory);                  // ������� ���� � ����� � ��������� (��� ��� �������)
                StreamWriter WriteRepeats = new StreamWriter(repeatsFileDirectory + @"\1.gcode");   // ��������� ������
                WriterLogs.WriteLine();
                WriterLogs.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||||||");
                WriterLogs.WriteLine();
                WriterLogs.WriteLine("������ ����� � ���������");
                WriterLogs.WriteLine($"���������� ��������: {Repeats_}");
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
                        WriterLogs.WriteLine($"����� ������� G4 (delay_s), ��������� � ����� ({++fileLength}, {++fileLength} ������)");
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
                    WriterLogs.WriteLine($"����� ������� G4 (delay_s), ��������� � ����� ({++fileLength}, {++fileLength} ������)");
                    WriteFile.WriteLine(";delay_s");
                    WriteFile.WriteLine($"G4 S{Delay_}");
                }
            }

            WriteFile.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("��������� ������, ������������� ����������");
            StreamWriter WriteException = new StreamWriter(logPathes.Exceptions);
            WriteException.WriteLine(ex);
            WriteException.Close();
        }
        WriterLogs.WriteLine();
        WriterLogs.WriteLine();
        WriterLogs.Close();
    }

    //===========================================================================
    //========================== ���� ������ �� ����� ===========================
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
            MessageBox.Show("��������� ������, ������������� ����������");
            StreamWriter WriteException = new StreamWriter(logPathes.Exceptions);
            WriteException.WriteLine(ex);
            WriteException.Close();
        }
    }

    //===========================================================================
    //======================== ��������� �������� ����� =========================
    //===========================================================================

    public void changeFile(string configDirectoryPath_, string configFilePath_, string configFileName_, string repeatsFileDirectory_)
    {
        try
        {
            Clear();                                        // ������ �����
            configDirectoryPath = configDirectoryPath_;     // �������� ���� ����������
            configFilePath = configFilePath_;               // �������� ������ ���� � ��������� �����
            configFileName = configFileName_;               // �������� ��� ��������� ������� (��� ��� ����������, � ������� ����� ������)
            repeatsFileDirectory = repeatsFileDirectory_;   // �������� ����������, � ������� ����� ������� ���� � ���������
            FileRead();
        }
        catch (Exception ex)
        {
            MessageBox.Show("��������� ������, ������������� ����������");
            StreamWriter WriteException = new StreamWriter(logPathes.Exceptions);
            WriteException.WriteLine(ex);
            WriteException.Close();
        }
    }

}