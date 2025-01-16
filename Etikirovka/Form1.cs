using Microsoft.VisualBasic;
using System.Diagnostics;
using System.IO;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Etikirovka
{
    public partial class GCodeGenerator : Form
    {

        checkDirectories check = new checkDirectories();    // Создаем объект класса для проверки директорий

        ObrabotkaFiles Obrabotka = new ObrabotkaFiles();    // Создаем объект класса для работы с файлами

        List<string> forAllChangedFeedrates = new List<string>(); 

        public GCodeGenerator()
        {
            InitializeComponent();                          // Инициализация объектов на форме
            firstCode();                                    // Прогонка перых строк с запуском приложения
        }

        //===========================================================================
        //============ Код, обрабатывающийся вместе с запуском приложения ===========
        //===========================================================================

        private void firstCode()
        {
            if (check.isConfigsDirectory_)                          // Если есть директория с конфигами, то
            {
                ConfigsCountSTR.ForeColor = Color.Green;            // Красим label в зеленый для обозначения
                ConfigsCountINT.Text = $"{check.configsCount_}";    // Вывод количества конфигов
            }

            foreach (var name in check.configs_)                    // Цикл для заполнения комбобокса
            {
                Configs.Items.Add(name);                            // Записываем новую переменную в комбобокс
            }

            Configs.SelectedIndex = 0;                              // Устанавливаем выбранный в комбобоксе индекс на 0

            Obrabotka.changeFile(check.openedFileConfigDirectoryPath, check.openedFileConfigPath, check.openedFileConfigName, check.repeatsFileDirectory);
            //CustomButton();
        }

        //===========================================================================
        //======================= Изменение индекса комбобокса ======================
        //===========================================================================

        private void Configs_SelectedIndexChanged(object sender, EventArgs e)
        {
            LogsOutBox.Clear();                                                                     // Чистим вывод
            foreach (var tex in forAllChangedFeedrates)                                             // Цикл для каждого фидрейта
            {
                LogsOutBox.Text += $"{tex}\n";                                                      // Выводим фидрейт
            }
            check.dataOUT(Configs.SelectedIndex);                                                   // Читаем конфиг по выбранному индексу

            Obrabotka.changeFile(check.openedFileConfigDirectoryPath, check.openedFileConfigPath, 
                check.openedFileConfigName, check.repeatsFileDirectory);                            // Меняем рабочий файл в классе

            ConfigDirectoryPathLabel.Text = Obrabotka.configDirectoryPathOut;                       // Вывод пути
            ConfigFilePathLabel.Text = Obrabotka.configFilePathOut;                                 // Вывод пути
            ConfigFileNameLabel.Text = Obrabotka.configFileNameOut;                                 // Вывод пути

            FileInfo.Clear();                                                                       // Чистим логерный вывод
            int LinesCounter = 1;                                                                   // Счетчик линий
            foreach (var file in check.openedConfigsData_)                                          // Цикл для вывода всей информации файла
            {
                FileInfo.Text = $"{FileInfo.Text}{LinesCounter++}){file}{Environment.NewLine}";     // Записываем данные в richTextBox (логерный вывод)
            }

            formFill(Obrabotka.dataOut(), Obrabotka.AllSpeed);                                      // Вызов функции заполнения полей
        }

        //===========================================================================
        //================== Функция обновления бокса с конфигами ===================
        //===========================================================================

        public void ComboBoxUpdate()
        {
            check.directoryNames();                             // Обновляем список директорий
            Configs.Items.Clear();                              // Чистим комбобокс
            foreach (var name in check.configs_)                // Цикл для заполнения комбобокса
            {
                Configs.Items.Add(name);                        // Записываем новую переменную в комбобокс
            }
            ConfigsCountINT.Text = $"{check.configsCount_}";    // Выводит количесво конфигов
            Configs.SelectedIndex = 0;                          // Задаем начальный выбпанный индекс в 0 для корректной работы
        }

        //===========================================================================
        //=========================== Открытие проводника ===========================
        //===========================================================================

        private void OpenExplorer(string path)
        {
            try
            {
                Process.Start("explorer.exe", path);
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
        //================ Открываем проводник в директории конфигов ================
        //===========================================================================

        private void OpenConfigsFolder_Click(object sender, EventArgs e)
        {
            OpenExplorer(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"../../../../Configs"))); // Вызываем функцию открытия проводника
        }

        //===========================================================================
        //============== Открываем проводник для выбора нового конфига ==============
        //===========================================================================

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())                                    // Работаем с OpenFileDialog
            {
                openFileDialog.Title = "Выберите файл";                                                     // Титл
                openFileDialog.Filter = "Текстовые файлы (*.gcode)|*.gcode|Все файлы (*.*)|*.*";            // Фильтр для файлов

                if (openFileDialog.ShowDialog() == DialogResult.OK)                                         // Отображение диалога и проверка, был ли выбран файл
                {
                    string filePath = openFileDialog.FileName;                                              // Получение полного пути к выбранному файлу
                    var fileNameB = openFileDialog.FileName.Split('\\');                                    // Сплитаем путь для получения имени
                    int length = fileNameB.Length;                                                          // Записываем длинну массива
                    var fileName = fileNameB[--length].Split('.')[0];                                       // Получаем имя
                    StreamReader ReadFile = new StreamReader(filePath);                                     // Открываем поток
                    try
                    {
                        Directory.CreateDirectory(@$"../../../../Configs/{fileName}");                      // Создам директорию
                    }
                    catch
                    {
                        try
                        {
                            Directory.Delete(@$"../../../../Configs/{fileName}");                           // Удаляем директорию
                        }
                        catch
                        {
                            File.Delete(@$"../../../../Configs/{fileName}");                                // Удаляем файл
                        }
                    }
                    try
                    {
                        Directory.CreateDirectory(@$"../../../../Configs/{fileName}");                      // Создам директорию
                    }
                    catch { }
                    StreamWriter WriteFile = new StreamWriter(@$"../../../../Configs/{fileName}/1.gcode");  // Открываем поток
                    WriteFile.Write(ReadFile.ReadToEnd());                                                  // Копируем
                    ReadFile.Close();                                                                       // Закрываем поток
                    WriteFile.Close();                                                                      // Закрываем поток
                }
            }
            ComboBoxUpdate();                                                                               // Вызов функции обновления комбобокс
        }

        //===========================================================================
        //============================= Удаление конфига ============================
        //===========================================================================

        private void ConfigDelete_Click(object sender, EventArgs e)
        {
            check.DeleteConfig();   // УВызов функции удаления конфига
            ComboBoxUpdate();       // Вызов функции обновления комбобокс
        }

        //===========================================================================
        //========================= Валидация string в box ==========================
        //===========================================================================

        static bool IsValidString(string input)
        {
            string pattern = @"^[0-9.,-]+$";           // Регулярное выражение для проверки: только цифры, точки и тире
            return Regex.IsMatch(input, pattern);      // Вывод true/false
        }

        //===========================================================================
        //============================= Валидация формы =============================
        //===========================================================================

        private bool ValidateForm()
        {
            int checker = 0;
            /////////////////////////////////////
            if (!IsValidString(AllSpeedBox.Text))
            {
                AllSpeedBox.BackColor = Color.Red;
                checker++;
            }
            else
            {
                AllSpeedBox.BackColor = Color.White;
            }
            if (!IsValidString(XSpeedBox.Text))
            {
                XSpeedBox.BackColor = Color.Red;
                checker++;
            }
            else
            {
                XSpeedBox.BackColor = Color.White;
            }
            if (!IsValidString(YSpeedBox.Text))
            {
                YSpeedBox.BackColor = Color.Red;
                checker++;
            }
            else
            {
                YSpeedBox.BackColor = Color.White;
            }
            if (!IsValidString(ZSpeedBox.Text))
            {
                ZSpeedBox.BackColor = Color.Red;
                checker++;
            }
            else
            {
                ZSpeedBox.BackColor = Color.White;
            }
            if (!IsValidString(ASpeedBox.Text))
            {
                ASpeedBox.BackColor = Color.Red;
                checker++;
            }
            else
            {
                ASpeedBox.BackColor = Color.White;
            }
            if (!IsValidString(BSpeedBox.Text))
            {
                BSpeedBox.BackColor = Color.Red;
                checker++;
            }
            else
            {
                BSpeedBox.BackColor = Color.White;
            }
            /////////////////////////////////////
            if (!IsValidString(RepeatsBox.Text))
            {
                RepeatsBox.BackColor = Color.Red;
                checker++;
            }
            else
            {
                RepeatsBox.BackColor = Color.White;
            }
            if (!IsValidString(DelayBox.Text))
            {
                DelayBox.BackColor = Color.Red;
                checker++;
            }
            else
            {
                DelayBox.BackColor = Color.White;
            }
            if (!IsValidString(TurnBox.Text))
            {
                TurnBox.BackColor = Color.Red;
                checker++;
            }
            else
            {
                TurnBox.BackColor = Color.White;
            }
            if (!IsValidString(ZazhimBox.Text))
            {
                ZazhimBox.BackColor = Color.Red;
                checker++;
            }
            else
            {
                ZazhimBox.BackColor = Color.White;
            }
            if (!IsValidString(PrizimBox.Text))
            {
                PrizimBox.BackColor = Color.Red;
                checker++;
            }
            else
            {
                PrizimBox.BackColor = Color.White;
            }
            if (!IsValidString(StartFlyBox.Text))
            {
                StartFlyBox.BackColor = Color.Red;
                checker++;
            }
            else
            {
                StartFlyBox.BackColor = Color.White;
            }
            /////////////////////////////////////
            if (!IsValidString(ValikPrizhimStartBox.Text))
            {
                ValikPrizhimStartBox.BackColor = Color.Red;
                checker++;
            }
            else
            {
                ValikPrizhimStartBox.BackColor = Color.White;
            }
            if (!IsValidString(ValikPrizhimEndBox.Text))
            {
                ValikPrizhimEndBox.BackColor = Color.Red;
                checker++;
            }
            else
            {
                ValikPrizhimEndBox.BackColor = Color.White;
            }
            if (!IsValidString(KaretkaStartBox.Text))
            {
                KaretkaStartBox.BackColor = Color.Red;
                checker++;
            }
            else
            {
                KaretkaStartBox.BackColor = Color.White;
            }
            if (!IsValidString(KaretkaEndBox.Text))
            {
                KaretkaEndBox.BackColor = Color.Red;
                checker++;
            }
            else
            {
                KaretkaEndBox.BackColor = Color.White;
            }
            if (!IsValidString(TurnFlakonPolozhenieStartBox.Text))
            {
                TurnFlakonPolozhenieStartBox.BackColor = Color.Red;
                checker++;
            }
            else
            {
                TurnFlakonPolozhenieStartBox.BackColor = Color.White;
            }
            if (!IsValidString(TurnFlakonPolozhenieEndBox.Text))
            {
                TurnFlakonPolozhenieEndBox.BackColor = Color.Red;
                checker++;
            }
            else
            {
                TurnFlakonPolozhenieEndBox.BackColor = Color.White;
            }
            if (!IsValidString(PrizhimFlakonPolozhenieStartBox.Text))
            {
                PrizhimFlakonPolozhenieStartBox.BackColor = Color.Red;
                checker++;
            }
            else
            {
                PrizhimFlakonPolozhenieStartBox.BackColor = Color.White;
            }
            if (!IsValidString(PrizhimFlakonPolozhenieEndBox.Text))
            {
                PrizhimFlakonPolozhenieEndBox.BackColor = Color.Red;
                checker++;
            }
            else
            {
                PrizhimFlakonPolozhenieEndBox.BackColor = Color.White;
            }
            /////////////////////////////////////
            //if ((XStart.Checked && XEnd.Checked) == false)
            //{
            //    XGroup.BackColor = Color.Red;
            //    checker++;
            //}
            //if (XStart.Checked || XEnd.Checked)
            //{
            //    XGroup.BackColor = Color.White;
            //}
            //if ((YStart.Checked && YEnd.Checked) == false)
            //{
            //    YGroup.BackColor = Color.Red;
            //    checker++;
            //}
            //if (YStart.Checked || YEnd.Checked)
            //{
            //    YGroup.BackColor = Color.White;
            //}
            //if ((ZStart.Checked && ZEnd.Checked) == false)
            //{
            //    ZGroup.BackColor = Color.Red;
            //    checker++;
            //}
            //if (ZStart.Checked || ZEnd.Checked)
            //{
            //    ZGroup.BackColor = Color.White;
            //}
            //if ((AStart.Checked && AEnd.Checked) == false)
            //{
            //    AGroup.BackColor = Color.Red;
            //    checker++;
            //}
            //if (AStart.Checked || AEnd.Checked)
            //{
            //    AGroup.BackColor = Color.White;
            //}
            //if ((BStart.Checked && BEnd.Checked) == false)
            //{
            //    BGroup.BackColor = Color.Red;
            //    checker++;
            //}
            //if (BStart.Checked || BEnd.Checked)
            //{
            //    BGroup.BackColor = Color.White;
            //}
            /////////////////////////////////////
            if (checker == 0)
            {
                return true;
            }
            return false;
        }

        private float toHelpFill(string input)
        {
            string forOut = input.Replace('.', ',');
            return float.Parse(forOut);
        }

        //===========================================================================
        //====================== Кнопка создания .gcode файла =======================
        //===========================================================================

        private async void ChangeFile_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                Obrabotka.newDataInput(toHelpFill(XSpeedBox.Text), toHelpFill(YSpeedBox.Text), toHelpFill(ZSpeedBox.Text),
                    toHelpFill(ASpeedBox.Text), toHelpFill(BSpeedBox.Text), toHelpFill(RepeatsBox.Text), toHelpFill(DelayBox.Text),
                    toHelpFill(TurnBox.Text), toHelpFill(ZazhimBox.Text), toHelpFill(PrizimBox.Text), toHelpFill(StartFlyBox.Text),
                    toHelpFill(ValikPrizhimStartBox.Text), toHelpFill(ValikPrizhimEndBox.Text), toHelpFill(KaretkaStartBox.Text),
                    toHelpFill(KaretkaEndBox.Text), toHelpFill(TurnFlakonPolozhenieStartBox.Text), toHelpFill(TurnFlakonPolozhenieEndBox.Text),
                    toHelpFill(PrizhimFlakonPolozhenieStartBox.Text), toHelpFill(PrizhimFlakonPolozhenieEndBox.Text),
                    XStart.Checked, YStart.Checked, ZStart.Checked, AStart.Checked, BStart.Checked, forAllChangedFeedrates);

                Obrabotka.Replacer();

                check.dataOUT(Configs.SelectedIndex);

                FileInfo.Clear();                                                                       // Чистим логерный вывод
                int LinesCounter = 1;
                foreach (var file in check.openedConfigsData_)                                          // Цикл для вывода всей информации файла
                {
                    FileInfo.Text = $"{FileInfo.Text}{LinesCounter++}){file}{Environment.NewLine}";     // Записываем данные в richTextBox (логерный вывод)
                }

                Obrabotka.FileRead();
                formFill(Obrabotka.dataOut(), Obrabotka.AllSpeed);
            }
        }

        //===========================================================================
        //============================ Заполнение формы =============================
        //===========================================================================

        private void formFill(List<string> data, List<string> allFeedrate)
        {
            AllSpeedBox.ReadOnly = false;
            AllSpeedLabel.ForeColor = Color.Green;
            XSpeedBox.ReadOnly = false;
            XSpeedLabel.ForeColor = Color.Green;
            YSpeedBox.ReadOnly = false;
            YSpeedLabel.ForeColor = Color.Green;
            ZSpeedBox.ReadOnly = false;
            ZSpeedLabel.ForeColor = Color.Green;
            ASpeedBox.ReadOnly = false;
            ASpeedLabel.ForeColor = Color.Green;
            BSpeedBox.ReadOnly = false;
            BSpeedLabel.ForeColor = Color.Green;

            RepeatsBox.ReadOnly = false;
            RepeatsLabel.ForeColor = Color.Green;
            DelayBox.ReadOnly = false;
            DelayLabel.ForeColor = Color.Green;
            TurnBox.ReadOnly = false;
            TurnLabel.ForeColor = Color.Green;
            ZazhimBox.ReadOnly = false;
            ZazhimLabel.ForeColor = Color.Green;
            PrizimBox.ReadOnly = false;
            PrizimLabel.ForeColor = Color.Green;
            StartFlyBox.ReadOnly = false;
            StartFlyLabel.ForeColor = Color.Green;

            ValikPrizhimStartBox.ReadOnly = false;
            ValikPrizhimStartLabel.ForeColor = Color.Green;
            ValikPrizhimEndBox.ReadOnly = false;
            ValikPrizhimEndLabel.ForeColor = Color.Green;
            KaretkaStartBox.ReadOnly = false;
            KaretkaStartLabel.ForeColor = Color.Green;
            KaretkaEndBox.ReadOnly = false;
            KaretkaEndLabel.ForeColor = Color.Green;
            TurnFlakonPolozhenieStartBox.ReadOnly = false;
            TurnFlakonPolozhenieStartLabel.ForeColor = Color.Green;
            TurnFlakonPolozhenieEndBox.ReadOnly = false;
            TurnFlakonPolozhenieEndLabel.ForeColor = Color.Green;
            PrizhimFlakonPolozhenieStartBox.ReadOnly = false;
            PrizhimFlakonPolozhenieStartLabel.ForeColor = Color.Green;
            PrizhimFlakonPolozhenieEndBox.ReadOnly = false;
            PrizhimFlakonPolozhenieEndLabel.ForeColor = Color.Green;

            forAllChangedFeedrates.Clear();
            allFeedrates.Items.Clear();

            allFeedrates.Text = "Пусто";
            AllFeedratesLabel.Text = $"AllFeedrates";

            if (allFeedrate.Count > 0)
            {
                foreach (var item in allFeedrate)
                {
                    var splitedItem = item.Split(' ');
                    int helpc = 0;
                    string comboName = "";
                    foreach (var item2 in splitedItem)
                    {
                        if (helpc != 0)
                        {
                            comboName += $"{item2} ";
                        }
                        helpc++;
                    }
                    allFeedrates.Items.Add(comboName);

                    forAllChangedFeedrates.Add(splitedItem[0]);
                }
                allFeedrates.SelectedIndex = 0;
            }

            if (data[0] == "0")
            {
                AllSpeedBox.Text = "0";
                AllSpeedBox.ReadOnly = true;
                AllSpeedLabel.ForeColor = Color.Red;
            }
            else
            {
                AllSpeedBox.Text = forAllChangedFeedrates[allFeedrates.SelectedIndex];
            }
            //AllFeedratesLabel.Text = $"AllFeedrates ({data[0]})";
            AllFeedratesLabel.Text = $"AllFeedrates ({forAllChangedFeedrates.Count})";

            XSpeedBox.Text = data[1];
            if (data[1] == "0")
            {
                XSpeedBox.ReadOnly = true;
                XSpeedLabel.ForeColor = Color.Red;
            }
            YSpeedBox.Text = data[2];
            if (data[2] == "0")
            {
                YSpeedBox.ReadOnly = true;
                YSpeedLabel.ForeColor = Color.Red;
            }
            ZSpeedBox.Text = data[3];
            if (data[3] == "0")
            {
                ZSpeedBox.ReadOnly = true;
                ZSpeedLabel.ForeColor = Color.Red;
            }
            ASpeedBox.Text = data[4];
            if (data[4] == "0")
            {
                ASpeedBox.ReadOnly = true;
                ASpeedLabel.ForeColor = Color.Red;
            }
            BSpeedBox.Text = data[5];
            if (data[5] == "0")
            {
                BSpeedBox.ReadOnly = true;
                BSpeedLabel.ForeColor = Color.Red;
            }

            RepeatsBox.Text = data[6];
            if (data[6] == "0")
            {
                RepeatsLabel.ForeColor = Color.Orange;
            }
            DelayBox.Text = data[7];
            if (data[7] == "0")
            {
                DelayLabel.ForeColor = Color.Orange;
            }
            TurnBox.Text = data[8];
            if (data[8] == "0")
            {
                TurnBox.ReadOnly = true;
                TurnLabel.ForeColor = Color.Red;
            }
            ZazhimBox.Text = data[9];
            if (data[9] == "0")
            {
                ZazhimBox.ReadOnly = true;
                ZazhimLabel.ForeColor = Color.Red;
            }
            PrizimBox.Text = data[10];
            if (data[10] == "0")
            {
                PrizimBox.ReadOnly = true;
                PrizimLabel.ForeColor = Color.Red;
            }
            StartFlyBox.Text = data[11];
            if (data[11] == "0")
            {
                StartFlyBox.ReadOnly = true;
                StartFlyLabel.ForeColor = Color.Red;
            }

            ValikPrizhimStartBox.Text = data[12];
            if (data[12] == "0")
            {
                ValikPrizhimStartBox.ReadOnly = true;
                ValikPrizhimStartLabel.ForeColor = Color.Red;
            }
            ValikPrizhimEndBox.Text = data[13];
            if (data[13] == "0")
            {
                ValikPrizhimEndBox.ReadOnly = true;
                ValikPrizhimEndLabel.ForeColor = Color.Red;
            }
            KaretkaStartBox.Text = data[14];
            if (data[14] == "0")
            {
                KaretkaStartBox.ReadOnly = true;
                KaretkaStartLabel.ForeColor = Color.Red;
            }
            KaretkaEndBox.Text = data[15];
            if (data[15] == "0")
            {
                KaretkaEndBox.ReadOnly = true;
                KaretkaEndLabel.ForeColor = Color.Red;
            }
            TurnFlakonPolozhenieStartBox.Text = data[16];
            if (data[16] == "0")
            {
                TurnFlakonPolozhenieStartBox.ReadOnly = true;
                TurnFlakonPolozhenieStartLabel.ForeColor = Color.Red;
            }
            TurnFlakonPolozhenieEndBox.Text = data[17];
            if (data[17] == "0")
            {
                TurnFlakonPolozhenieEndBox.ReadOnly = true;
                TurnFlakonPolozhenieEndLabel.ForeColor = Color.Red;
            }
            PrizhimFlakonPolozhenieStartBox.Text = data[18];
            if (data[18] == "0")
            {
                PrizhimFlakonPolozhenieStartBox.ReadOnly = true;
                PrizhimFlakonPolozhenieStartLabel.ForeColor = Color.Red;
            }
            PrizhimFlakonPolozhenieEndBox.Text = data[19];
            if (data[19] == "0")
            {
                PrizhimFlakonPolozhenieEndBox.ReadOnly = true;
                PrizhimFlakonPolozhenieEndLabel.ForeColor = Color.Red;
            }

            if (data[20] == "true")
            {
                XGroup.BackColor = Color.Green;
                XStart.Checked = true;
                XEnd.Checked = false;
            }
            else
            {
                XGroup.BackColor = Color.Yellow;
                XStart.Checked = false;
                XEnd.Checked = true;
            }
            if (data[21] == "true")
            {
                YGroup.BackColor = Color.Green;
                YStart.Checked = true;
                YEnd.Checked = false;
            }
            else
            {
                YGroup.BackColor = Color.Yellow;
                YStart.Checked = false;
                YEnd.Checked = true;
            }
            if (data[22] == "true")
            {
                ZGroup.BackColor = Color.Green;
                ZStart.Checked = true;
                ZEnd.Checked = false;
            }
            else
            {
                ZGroup.BackColor = Color.Yellow;
                ZStart.Checked = false;
                ZEnd.Checked = true;
            }
            if (data[23] == "true")
            {
                AGroup.BackColor = Color.Green;
                AStart.Checked = true;
                AEnd.Checked = false;
            }
            else
            {
                AGroup.BackColor = Color.Yellow;
                AStart.Checked = false;
                AEnd.Checked = true;
            }
            if (data[24] == "true")
            {
                BGroup.BackColor = Color.Green;
                BStart.Checked = true;
                BEnd.Checked = false;
            }
            else
            {
                BGroup.BackColor = Color.Yellow;
                BStart.Checked = false;
                BEnd.Checked = true;
            }
        }

        //===========================================================================
        //============================= Логерная кнопка =============================
        //===========================================================================

        private void Test_Click(object sender, EventArgs e)
        {
            List<string> data = Obrabotka.dataOut();

            if (CleanLogsOutBox.Checked)
            {
                LogsOutBox.Clear();
            }

            if (TurnOnLogsOut.Checked)
            {
                LogsOutBox.Text += Obrabotka.TestingOuts();
                for (int i = 0; i < data.Count; i++)
                {
                    LogsOutBox.Text += $"{i}) {data[i]}\n";
                }
            }

            if (BindsOut.Checked)
            {
                foreach (var item in Obrabotka.ChangingSave)
                {
                    LogsOutBox.Text += $"{item}\n";
                }
            }

            if (ItogOut.Checked)
            {
                LogsOutBox.Text += Obrabotka.file;
            }
        }

        //===========================================================================
        //=========================== Изменение парковок ============================
        //===========================================================================

        // Тут изменение цвета в зависимости от начала/конца парковки.

        // True - парковка в начале
        // False - парковка в конце

        private void XStart_CheckedChanged(object sender, EventArgs e)
        {
            if (XStart.Checked)
            {
                XGroup.BackColor = Color.Green;
            }
            else
            {
                XGroup.BackColor = Color.Yellow;
            }
        }
        private void XEnd_CheckedChanged(object sender, EventArgs e)
        {
            if (XEnd.Checked)
            {
                XGroup.BackColor = Color.Yellow;
            }
            else
            {
                XGroup.BackColor = Color.Green;
            }
        }
        private void YStart_CheckedChanged(object sender, EventArgs e)
        {
            if (YStart.Checked)
            {
                YGroup.BackColor = Color.Green;
            }
            else
            {
                YGroup.BackColor = Color.Yellow;
            }
        }
        private void YEnd_CheckedChanged(object sender, EventArgs e)
        {
            if (YEnd.Checked)
            {
                YGroup.BackColor = Color.Yellow;
            }
            else
            {
                YGroup.BackColor = Color.Green;
            }
        }
        private void ZStart_CheckedChanged(object sender, EventArgs e)
        {
            if (ZStart.Checked)
            {
                ZGroup.BackColor = Color.Green;
            }
            else
            {
                ZGroup.BackColor = Color.Yellow;
            }
        }
        private void ZEnd_CheckedChanged(object sender, EventArgs e)
        {
            if (ZEnd.Checked)
            {
                ZGroup.BackColor = Color.Yellow;
            }
            else
            {
                ZGroup.BackColor = Color.Green;
            }
        }
        private void AStart_CheckedChanged(object sender, EventArgs e)
        {
            if (AStart.Checked)
            {
                AGroup.BackColor = Color.Green;
            }
            else
            {
                AGroup.BackColor = Color.Yellow;
            }
        }
        private void AEnd_CheckedChanged(object sender, EventArgs e)
        {
            if (AEnd.Checked)
            {
                AGroup.BackColor = Color.Yellow;
            }
            else
            {
                AGroup.BackColor = Color.Green;
            }
        }
        private void BStart_CheckedChanged(object sender, EventArgs e)
        {
            if (BStart.Checked)
            {
                BGroup.BackColor = Color.Green;
            }
            else
            {
                BGroup.BackColor = Color.Yellow;
            }
        }
        private void BEnd_CheckedChanged(object sender, EventArgs e)
        {
            if (BEnd.Checked)
            {
                BGroup.BackColor = Color.Yellow;
            }
            else
            {
                BGroup.BackColor = Color.Green;
            }
        }

        //===========================================================================
        //====================== Выбор переменной allFeedrates ======================
        //===========================================================================

        private void allFeedrates_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllSpeedBox.Text = forAllChangedFeedrates[allFeedrates.SelectedIndex];  // Изменение данных в поле
        }

        //===========================================================================
        //==================== Изменение переменной allFeedrates ====================
        //===========================================================================

        private void AllSpeedBox_TextChanged(object sender, EventArgs e)
        {
            if (forAllChangedFeedrates.Count == allFeedrates.Items.Count && allFeedrates.Items.Count > 0)
            {
                forAllChangedFeedrates[allFeedrates.SelectedIndex] = AllSpeedBox.Text;
            }
        }

        //===========================================================================
        //============================ *Админский* режим ============================
        //===========================================================================

        private void Admin_CheckedChanged(object sender, EventArgs e)
        {
            if (Admin.Checked)
            {
                FileInfo.Size = new Size(320, 158);         // Изменение размеров
                FileInfo.Location = new Point(709, 80);     // Новые координаты поля вывода
                Admin.Location = new Point(951, 12);        // Новые координаты чекбокса
                ConfigDirectoryPathLabel2.Visible = true;   // Показываем поле
                ConfigDirectoryPathLabel.Visible = true;    // Показываем поле
                ConfigFilePathLabel2.Visible = true;        // Показываем поле
                ConfigFilePathLabel.Visible = true;         // Показываем поле
                ConfigFileNameLabel2.Visible = true;        // Показываем поле
                ConfigFileNameLabel.Visible = true;         // Показываем поле
                LogsOutBox.Visible = true;                  // Показываем поле
                BindsOut.Visible = true;                    // Показываем поле
                ItogOut.Visible = true;                     // Показываем поле
                CleanLogsOutBox.Visible = true;             // Показываем поле
                TurnOnLogsOut.Visible = true;               // Показываем поле
                Test.Visible = true;                        // Показываем поле
            }
            else
            {
                FileInfo.Size = new Size(320, 495);         // Изменение размеров
                FileInfo.Location = new Point(709, 12);     // Новые координаты поля вывода
                Admin.Location = new Point(628, 17);        // Новые координаты чекбокса
                ConfigDirectoryPathLabel2.Visible = false;  // Скрываем поле
                ConfigDirectoryPathLabel.Visible = false;   // Скрываем поле
                ConfigFilePathLabel2.Visible = false;       // Скрываем поле
                ConfigFilePathLabel.Visible = false;        // Скрываем поле
                ConfigFileNameLabel2.Visible = false;       // Скрываем поле
                ConfigFileNameLabel.Visible = false;        // Скрываем поле
                LogsOutBox.Visible = false;                 // Скрываем поле
                BindsOut.Visible = false;                   // Скрываем поле
                ItogOut.Visible = false;                    // Скрываем поле
                CleanLogsOutBox.Visible = false;            // Скрываем поле
                TurnOnLogsOut.Visible = false;              // Скрываем поле
                Test.Visible = false;                       // Скрываем поле
            }
        }

        //===========================================================================
        //======================= Обновление списка конфигов ========================
        //===========================================================================

        private void UpdateConfigs_Click(object sender, EventArgs e)
        {
            ComboBoxUpdate(); // Вызов функции
        }
    }
}
