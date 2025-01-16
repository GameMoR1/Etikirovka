namespace Etikirovka
{
    partial class GCodeGenerator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            XSpeedBox = new RichTextBox();
            XSpeedLabel = new Label();
            YSpeedLabel = new Label();
            YSpeedBox = new RichTextBox();
            ZSpeedLabel = new Label();
            ZSpeedBox = new RichTextBox();
            ASpeedLabel = new Label();
            ASpeedBox = new RichTextBox();
            BSpeedBox = new RichTextBox();
            BSpeedLabel = new Label();
            Help = new ToolTip(components);
            ConfigDelete = new Button();
            AllSpeedBox = new RichTextBox();
            RepeatsBox = new RichTextBox();
            DelayBox = new RichTextBox();
            TurnBox = new RichTextBox();
            ZazhimBox = new RichTextBox();
            PrizimBox = new RichTextBox();
            StartFlyBox = new RichTextBox();
            ValikPrizhimStartBox = new RichTextBox();
            ValikPrizhimEndBox = new RichTextBox();
            KaretkaEndBox = new RichTextBox();
            KaretkaStartBox = new RichTextBox();
            TurnFlakonPolozhenieEndBox = new RichTextBox();
            TurnFlakonPolozhenieStartBox = new RichTextBox();
            PrizhimFlakonPolozhenieEndBox = new RichTextBox();
            PrizhimFlakonPolozhenieStartBox = new RichTextBox();
            OpenConfigsFolder = new Button();
            OpenFileButton = new Button();
            XEnd = new RadioButton();
            XStart = new RadioButton();
            YEnd = new RadioButton();
            YStart = new RadioButton();
            ZEnd = new RadioButton();
            ZStart = new RadioButton();
            AEnd = new RadioButton();
            AStart = new RadioButton();
            BEnd = new RadioButton();
            BStart = new RadioButton();
            ChangeFile = new Button();
            UpdateConfigs = new Button();
            FileInfo = new RichTextBox();
            ConfigsCountSTR = new Label();
            ConfigsCountINT = new Label();
            Configs = new ComboBox();
            openFileDialog1 = new OpenFileDialog();
            AllSpeedLabel = new Label();
            RepeatsLabel = new Label();
            DelayLabel = new Label();
            TurnLabel = new Label();
            ZazhimLabel = new Label();
            PrizimLabel = new Label();
            StartFlyLabel = new Label();
            ValikPrizhimLabel = new Label();
            ValikPrizhimStartLabel = new Label();
            ValikPrizhimEndLabel = new Label();
            KaretkaEndLabel = new Label();
            KaretkaStartLabel = new Label();
            KaretkaLabel = new Label();
            TurnFlakonPolozhenieEndLabel = new Label();
            TurnFlakonPolozhenieStartLabel = new Label();
            TurnFlakonPolozhenieLabel = new Label();
            PrizhimFlakonPolozhenieEndLabel = new Label();
            PrizhimFlakonPolozhenieStartLabel = new Label();
            PrizhimFlakonPolozhenieLabel = new Label();
            XGroup = new GroupBox();
            YGroup = new GroupBox();
            ZGroup = new GroupBox();
            AGroup = new GroupBox();
            BGroup = new GroupBox();
            LogsOutBox = new RichTextBox();
            Test = new Button();
            CleanLogsOutBox = new CheckBox();
            TurnOnLogsOut = new CheckBox();
            ConfigDirectoryPathLabel = new Label();
            ConfigFilePathLabel = new Label();
            ConfigFileNameLabel = new Label();
            ConfigFileNameLabel2 = new Label();
            ConfigFilePathLabel2 = new Label();
            ConfigDirectoryPathLabel2 = new Label();
            allFeedrates = new ComboBox();
            AllFeedratesLabel = new Label();
            BindsOut = new CheckBox();
            ItogOut = new CheckBox();
            Admin = new CheckBox();
            XGroup.SuspendLayout();
            YGroup.SuspendLayout();
            ZGroup.SuspendLayout();
            AGroup.SuspendLayout();
            BGroup.SuspendLayout();
            SuspendLayout();
            // 
            // XSpeedBox
            // 
            XSpeedBox.Font = new Font("Arial Narrow", 14F);
            XSpeedBox.Location = new Point(82, 121);
            XSpeedBox.Name = "XSpeedBox";
            XSpeedBox.Size = new Size(122, 35);
            XSpeedBox.TabIndex = 1;
            XSpeedBox.Text = "";
            Help.SetToolTip(XSpeedBox, "Скорость оси X");
            // 
            // XSpeedLabel
            // 
            XSpeedLabel.AutoSize = true;
            XSpeedLabel.Location = new Point(12, 129);
            XSpeedLabel.Name = "XSpeedLabel";
            XSpeedLabel.Size = new Size(64, 20);
            XSpeedLabel.TabIndex = 1;
            XSpeedLabel.Text = "X Speed";
            // 
            // YSpeedLabel
            // 
            YSpeedLabel.AutoSize = true;
            YSpeedLabel.Location = new Point(12, 170);
            YSpeedLabel.Name = "YSpeedLabel";
            YSpeedLabel.Size = new Size(63, 20);
            YSpeedLabel.TabIndex = 3;
            YSpeedLabel.Text = "Y Speed";
            // 
            // YSpeedBox
            // 
            YSpeedBox.Font = new Font("Arial Narrow", 14F);
            YSpeedBox.Location = new Point(82, 162);
            YSpeedBox.Name = "YSpeedBox";
            YSpeedBox.Size = new Size(122, 35);
            YSpeedBox.TabIndex = 2;
            YSpeedBox.Text = "";
            Help.SetToolTip(YSpeedBox, "Скорость оси Y");
            // 
            // ZSpeedLabel
            // 
            ZSpeedLabel.AutoSize = true;
            ZSpeedLabel.Location = new Point(12, 211);
            ZSpeedLabel.Name = "ZSpeedLabel";
            ZSpeedLabel.Size = new Size(64, 20);
            ZSpeedLabel.TabIndex = 5;
            ZSpeedLabel.Text = "Z Speed";
            // 
            // ZSpeedBox
            // 
            ZSpeedBox.Font = new Font("Arial Narrow", 14F);
            ZSpeedBox.Location = new Point(82, 203);
            ZSpeedBox.Name = "ZSpeedBox";
            ZSpeedBox.Size = new Size(122, 35);
            ZSpeedBox.TabIndex = 3;
            ZSpeedBox.Text = "";
            Help.SetToolTip(ZSpeedBox, "Скорость оси Z");
            // 
            // ASpeedLabel
            // 
            ASpeedLabel.AutoSize = true;
            ASpeedLabel.Location = new Point(14, 252);
            ASpeedLabel.Name = "ASpeedLabel";
            ASpeedLabel.Size = new Size(65, 20);
            ASpeedLabel.TabIndex = 7;
            ASpeedLabel.Text = "A Speed";
            // 
            // ASpeedBox
            // 
            ASpeedBox.Font = new Font("Arial Narrow", 14F);
            ASpeedBox.Location = new Point(82, 244);
            ASpeedBox.Name = "ASpeedBox";
            ASpeedBox.Size = new Size(122, 35);
            ASpeedBox.TabIndex = 4;
            ASpeedBox.Text = "";
            Help.SetToolTip(ASpeedBox, "Скорость оси A");
            // 
            // BSpeedBox
            // 
            BSpeedBox.Font = new Font("Arial Narrow", 14F);
            BSpeedBox.Location = new Point(82, 285);
            BSpeedBox.Name = "BSpeedBox";
            BSpeedBox.Size = new Size(122, 35);
            BSpeedBox.TabIndex = 5;
            BSpeedBox.Text = "";
            Help.SetToolTip(BSpeedBox, "Скорость оси B");
            // 
            // BSpeedLabel
            // 
            BSpeedLabel.AutoSize = true;
            BSpeedLabel.Location = new Point(14, 293);
            BSpeedLabel.Name = "BSpeedLabel";
            BSpeedLabel.Size = new Size(64, 20);
            BSpeedLabel.TabIndex = 7;
            BSpeedLabel.Text = "B Speed";
            // 
            // ConfigDelete
            // 
            ConfigDelete.BackColor = Color.Transparent;
            ConfigDelete.BackgroundImage = Properties.Resources.trash;
            ConfigDelete.BackgroundImageLayout = ImageLayout.Stretch;
            ConfigDelete.ForeColor = Color.Transparent;
            ConfigDelete.Location = new Point(210, 35);
            ConfigDelete.Name = "ConfigDelete";
            ConfigDelete.Size = new Size(29, 28);
            ConfigDelete.TabIndex = 34;
            Help.SetToolTip(ConfigDelete, "Удалить выбранный конфиг");
            ConfigDelete.UseVisualStyleBackColor = false;
            ConfigDelete.Click += ConfigDelete_Click;
            // 
            // AllSpeedBox
            // 
            AllSpeedBox.Font = new Font("Arial Narrow", 14F);
            AllSpeedBox.Location = new Point(82, 80);
            AllSpeedBox.Name = "AllSpeedBox";
            AllSpeedBox.Size = new Size(122, 35);
            AllSpeedBox.TabIndex = 0;
            AllSpeedBox.Text = "";
            Help.SetToolTip(AllSpeedBox, "Общая скорость");
            AllSpeedBox.TextChanged += AllSpeedBox_TextChanged;
            // 
            // RepeatsBox
            // 
            RepeatsBox.Font = new Font("Arial Narrow", 14F);
            RepeatsBox.Location = new Point(418, 80);
            RepeatsBox.Name = "RepeatsBox";
            RepeatsBox.Size = new Size(122, 35);
            RepeatsBox.TabIndex = 6;
            RepeatsBox.Text = "";
            Help.SetToolTip(RepeatsBox, "Количество повторений");
            // 
            // DelayBox
            // 
            DelayBox.Font = new Font("Arial Narrow", 14F);
            DelayBox.Location = new Point(418, 121);
            DelayBox.Name = "DelayBox";
            DelayBox.Size = new Size(122, 35);
            DelayBox.TabIndex = 7;
            DelayBox.Text = "";
            Help.SetToolTip(DelayBox, "Задержка перед повтором");
            // 
            // TurnBox
            // 
            TurnBox.Font = new Font("Arial Narrow", 14F);
            TurnBox.Location = new Point(418, 162);
            TurnBox.Name = "TurnBox";
            TurnBox.Size = new Size(122, 35);
            TurnBox.TabIndex = 8;
            TurnBox.Text = "";
            Help.SetToolTip(TurnBox, "Поворот флакона перед обкаткой");
            // 
            // ZazhimBox
            // 
            ZazhimBox.Font = new Font("Arial Narrow", 14F);
            ZazhimBox.Location = new Point(418, 203);
            ZazhimBox.Name = "ZazhimBox";
            ZazhimBox.Size = new Size(122, 35);
            ZazhimBox.TabIndex = 9;
            ZazhimBox.Text = "";
            Help.SetToolTip(ZazhimBox, "Зажим флакона");
            // 
            // PrizimBox
            // 
            PrizimBox.Font = new Font("Arial Narrow", 14F);
            PrizimBox.Location = new Point(418, 244);
            PrizimBox.Name = "PrizimBox";
            PrizimBox.Size = new Size(122, 35);
            PrizimBox.TabIndex = 10;
            PrizimBox.Text = "";
            Help.SetToolTip(PrizimBox, "Прижим флакона");
            // 
            // StartFlyBox
            // 
            StartFlyBox.Font = new Font("Arial Narrow", 14F);
            StartFlyBox.Location = new Point(418, 285);
            StartFlyBox.Name = "StartFlyBox";
            StartFlyBox.Size = new Size(122, 35);
            StartFlyBox.TabIndex = 11;
            StartFlyBox.Text = "";
            Help.SetToolTip(StartFlyBox, "Начальный вылет этикетки с ножа");
            // 
            // ValikPrizhimStartBox
            // 
            ValikPrizhimStartBox.Font = new Font("Arial Narrow", 14F);
            ValikPrizhimStartBox.Location = new Point(17, 384);
            ValikPrizhimStartBox.Name = "ValikPrizhimStartBox";
            ValikPrizhimStartBox.Size = new Size(69, 35);
            ValikPrizhimStartBox.TabIndex = 12;
            ValikPrizhimStartBox.Text = "";
            Help.SetToolTip(ValikPrizhimStartBox, "Начальное положение прижимного валика");
            // 
            // ValikPrizhimEndBox
            // 
            ValikPrizhimEndBox.Font = new Font("Arial Narrow", 14F);
            ValikPrizhimEndBox.Location = new Point(92, 384);
            ValikPrizhimEndBox.Name = "ValikPrizhimEndBox";
            ValikPrizhimEndBox.Size = new Size(69, 35);
            ValikPrizhimEndBox.TabIndex = 13;
            ValikPrizhimEndBox.Text = "";
            Help.SetToolTip(ValikPrizhimEndBox, "Конечное положение прижимного валика");
            // 
            // KaretkaEndBox
            // 
            KaretkaEndBox.Font = new Font("Arial Narrow", 14F);
            KaretkaEndBox.Location = new Point(342, 384);
            KaretkaEndBox.Name = "KaretkaEndBox";
            KaretkaEndBox.Size = new Size(69, 35);
            KaretkaEndBox.TabIndex = 15;
            KaretkaEndBox.Text = "";
            Help.SetToolTip(KaretkaEndBox, "Конечное положение каретки");
            // 
            // KaretkaStartBox
            // 
            KaretkaStartBox.Font = new Font("Arial Narrow", 14F);
            KaretkaStartBox.Location = new Point(267, 384);
            KaretkaStartBox.Name = "KaretkaStartBox";
            KaretkaStartBox.Size = new Size(69, 35);
            KaretkaStartBox.TabIndex = 14;
            KaretkaStartBox.Text = "";
            Help.SetToolTip(KaretkaStartBox, "Начальное положение каретки");
            // 
            // TurnFlakonPolozhenieEndBox
            // 
            TurnFlakonPolozhenieEndBox.Font = new Font("Arial Narrow", 14F);
            TurnFlakonPolozhenieEndBox.Location = new Point(92, 475);
            TurnFlakonPolozhenieEndBox.Name = "TurnFlakonPolozhenieEndBox";
            TurnFlakonPolozhenieEndBox.Size = new Size(69, 35);
            TurnFlakonPolozhenieEndBox.TabIndex = 17;
            TurnFlakonPolozhenieEndBox.Text = "";
            Help.SetToolTip(TurnFlakonPolozhenieEndBox, "Конечное положение поворота флакона");
            // 
            // TurnFlakonPolozhenieStartBox
            // 
            TurnFlakonPolozhenieStartBox.Font = new Font("Arial Narrow", 14F);
            TurnFlakonPolozhenieStartBox.Location = new Point(17, 475);
            TurnFlakonPolozhenieStartBox.Name = "TurnFlakonPolozhenieStartBox";
            TurnFlakonPolozhenieStartBox.Size = new Size(69, 35);
            TurnFlakonPolozhenieStartBox.TabIndex = 16;
            TurnFlakonPolozhenieStartBox.Text = "";
            Help.SetToolTip(TurnFlakonPolozhenieStartBox, "Начальное положение поворота флакона");
            // 
            // PrizhimFlakonPolozhenieEndBox
            // 
            PrizhimFlakonPolozhenieEndBox.Font = new Font("Arial Narrow", 14F);
            PrizhimFlakonPolozhenieEndBox.Location = new Point(342, 475);
            PrizhimFlakonPolozhenieEndBox.Name = "PrizhimFlakonPolozhenieEndBox";
            PrizhimFlakonPolozhenieEndBox.Size = new Size(69, 35);
            PrizhimFlakonPolozhenieEndBox.TabIndex = 19;
            PrizhimFlakonPolozhenieEndBox.Text = "";
            Help.SetToolTip(PrizhimFlakonPolozhenieEndBox, "Конечное положение оси прижима флакона");
            // 
            // PrizhimFlakonPolozhenieStartBox
            // 
            PrizhimFlakonPolozhenieStartBox.Font = new Font("Arial Narrow", 14F);
            PrizhimFlakonPolozhenieStartBox.Location = new Point(267, 475);
            PrizhimFlakonPolozhenieStartBox.Name = "PrizhimFlakonPolozhenieStartBox";
            PrizhimFlakonPolozhenieStartBox.Size = new Size(69, 35);
            PrizhimFlakonPolozhenieStartBox.TabIndex = 18;
            PrizhimFlakonPolozhenieStartBox.Text = "";
            Help.SetToolTip(PrizhimFlakonPolozhenieStartBox, "Начальное положение оси прижима флакона");
            // 
            // OpenConfigsFolder
            // 
            OpenConfigsFolder.Location = new Point(546, 478);
            OpenConfigsFolder.Name = "OpenConfigsFolder";
            OpenConfigsFolder.Size = new Size(157, 29);
            OpenConfigsFolder.TabIndex = 32;
            OpenConfigsFolder.Text = "Папка с конфигами";
            Help.SetToolTip(OpenConfigsFolder, "Открывает папку с конфигами");
            OpenConfigsFolder.UseVisualStyleBackColor = true;
            OpenConfigsFolder.Click += OpenConfigsFolder_Click;
            // 
            // OpenFileButton
            // 
            OpenFileButton.Location = new Point(546, 443);
            OpenFileButton.Name = "OpenFileButton";
            OpenFileButton.Size = new Size(157, 29);
            OpenFileButton.TabIndex = 31;
            OpenFileButton.Text = "Добавить конфиг";
            Help.SetToolTip(OpenFileButton, "Выберите файл конфига, он будет добавлен в приложение");
            OpenFileButton.UseVisualStyleBackColor = true;
            OpenFileButton.Click += OpenFileButton_Click;
            // 
            // XEnd
            // 
            XEnd.AutoSize = true;
            XEnd.Location = new Point(86, 26);
            XEnd.Name = "XEnd";
            XEnd.Size = new Size(55, 24);
            XEnd.TabIndex = 21;
            XEnd.TabStop = true;
            XEnd.Text = "End";
            Help.SetToolTip(XEnd, "Парковка в конце программы по оси X");
            XEnd.UseVisualStyleBackColor = true;
            XEnd.CheckedChanged += XEnd_CheckedChanged;
            // 
            // XStart
            // 
            XStart.AutoSize = true;
            XStart.Location = new Point(19, 26);
            XStart.Name = "XStart";
            XStart.Size = new Size(61, 24);
            XStart.TabIndex = 20;
            XStart.TabStop = true;
            XStart.Text = "Start";
            Help.SetToolTip(XStart, "Парковка перед началом программы по оси X");
            XStart.UseVisualStyleBackColor = true;
            XStart.CheckedChanged += XStart_CheckedChanged;
            // 
            // YEnd
            // 
            YEnd.AutoSize = true;
            YEnd.Location = new Point(86, 26);
            YEnd.Name = "YEnd";
            YEnd.Size = new Size(55, 24);
            YEnd.TabIndex = 23;
            YEnd.TabStop = true;
            YEnd.Text = "End";
            Help.SetToolTip(YEnd, "Парковка в конце программы по оси Y");
            YEnd.UseVisualStyleBackColor = true;
            YEnd.CheckedChanged += YEnd_CheckedChanged;
            // 
            // YStart
            // 
            YStart.AutoSize = true;
            YStart.Location = new Point(19, 26);
            YStart.Name = "YStart";
            YStart.Size = new Size(61, 24);
            YStart.TabIndex = 22;
            YStart.TabStop = true;
            YStart.Text = "Start";
            Help.SetToolTip(YStart, "Парковка перед началом программы по оси Y");
            YStart.UseVisualStyleBackColor = true;
            YStart.CheckedChanged += YStart_CheckedChanged;
            // 
            // ZEnd
            // 
            ZEnd.AutoSize = true;
            ZEnd.Location = new Point(86, 26);
            ZEnd.Name = "ZEnd";
            ZEnd.Size = new Size(55, 24);
            ZEnd.TabIndex = 25;
            ZEnd.TabStop = true;
            ZEnd.Text = "End";
            Help.SetToolTip(ZEnd, "Парковка в конце программы по оси Z");
            ZEnd.UseVisualStyleBackColor = true;
            ZEnd.CheckedChanged += ZEnd_CheckedChanged;
            // 
            // ZStart
            // 
            ZStart.AutoSize = true;
            ZStart.Location = new Point(19, 26);
            ZStart.Name = "ZStart";
            ZStart.Size = new Size(61, 24);
            ZStart.TabIndex = 24;
            ZStart.TabStop = true;
            ZStart.Text = "Start";
            Help.SetToolTip(ZStart, "Парковка перед началом программы по оси Z");
            ZStart.UseVisualStyleBackColor = true;
            ZStart.CheckedChanged += ZStart_CheckedChanged;
            // 
            // AEnd
            // 
            AEnd.AutoSize = true;
            AEnd.Location = new Point(86, 26);
            AEnd.Name = "AEnd";
            AEnd.Size = new Size(55, 24);
            AEnd.TabIndex = 27;
            AEnd.TabStop = true;
            AEnd.Text = "End";
            Help.SetToolTip(AEnd, "Парковка в конце программы по оси A");
            AEnd.UseVisualStyleBackColor = true;
            AEnd.CheckedChanged += AEnd_CheckedChanged;
            // 
            // AStart
            // 
            AStart.AutoSize = true;
            AStart.Location = new Point(19, 26);
            AStart.Name = "AStart";
            AStart.Size = new Size(61, 24);
            AStart.TabIndex = 26;
            AStart.TabStop = true;
            AStart.Text = "Start";
            Help.SetToolTip(AStart, "Парковка перед началом программы по оси A");
            AStart.UseVisualStyleBackColor = true;
            AStart.CheckedChanged += AStart_CheckedChanged;
            // 
            // BEnd
            // 
            BEnd.AutoSize = true;
            BEnd.Location = new Point(86, 26);
            BEnd.Name = "BEnd";
            BEnd.Size = new Size(55, 24);
            BEnd.TabIndex = 29;
            BEnd.TabStop = true;
            BEnd.Text = "End";
            Help.SetToolTip(BEnd, "Парковка в конце программы по оси B");
            BEnd.UseVisualStyleBackColor = true;
            BEnd.CheckedChanged += BEnd_CheckedChanged;
            // 
            // BStart
            // 
            BStart.AutoSize = true;
            BStart.Location = new Point(19, 26);
            BStart.Name = "BStart";
            BStart.Size = new Size(61, 24);
            BStart.TabIndex = 28;
            BStart.TabStop = true;
            BStart.Text = "Start";
            Help.SetToolTip(BStart, "Парковка перед началом программы по оси B");
            BStart.UseVisualStyleBackColor = true;
            BStart.CheckedChanged += BStart_CheckedChanged;
            // 
            // ChangeFile
            // 
            ChangeFile.Location = new Point(546, 408);
            ChangeFile.Name = "ChangeFile";
            ChangeFile.Size = new Size(157, 29);
            ChangeFile.TabIndex = 30;
            ChangeFile.Text = "Перезаписать";
            Help.SetToolTip(ChangeFile, "Создает .gcode файл");
            ChangeFile.UseVisualStyleBackColor = true;
            ChangeFile.Click += ChangeFile_Click;
            // 
            // UpdateConfigs
            // 
            UpdateConfigs.BackgroundImage = Properties.Resources.updater1;
            UpdateConfigs.BackgroundImageLayout = ImageLayout.Stretch;
            UpdateConfigs.Location = new Point(511, 479);
            UpdateConfigs.Name = "UpdateConfigs";
            UpdateConfigs.Size = new Size(29, 28);
            UpdateConfigs.TabIndex = 72;
            Help.SetToolTip(UpdateConfigs, "Обновить список конфигов");
            UpdateConfigs.UseVisualStyleBackColor = true;
            UpdateConfigs.Click += UpdateConfigs_Click;
            // 
            // FileInfo
            // 
            FileInfo.Location = new Point(709, 12);
            FileInfo.Name = "FileInfo";
            FileInfo.Size = new Size(320, 495);
            FileInfo.TabIndex = 35;
            FileInfo.Text = "";
            // 
            // ConfigsCountSTR
            // 
            ConfigsCountSTR.AutoSize = true;
            ConfigsCountSTR.ForeColor = Color.IndianRed;
            ConfigsCountSTR.Location = new Point(17, 9);
            ConfigsCountSTR.Name = "ConfigsCountSTR";
            ConfigsCountSTR.Size = new Size(164, 20);
            ConfigsCountSTR.TabIndex = 10;
            ConfigsCountSTR.Text = "Количество конфигов:";
            // 
            // ConfigsCountINT
            // 
            ConfigsCountINT.AutoSize = true;
            ConfigsCountINT.Location = new Point(187, 9);
            ConfigsCountINT.Name = "ConfigsCountINT";
            ConfigsCountINT.Size = new Size(17, 20);
            ConfigsCountINT.TabIndex = 11;
            ConfigsCountINT.Text = "0";
            // 
            // Configs
            // 
            Configs.DropDownStyle = ComboBoxStyle.DropDownList;
            Configs.FormattingEnabled = true;
            Configs.Location = new Point(17, 35);
            Configs.Name = "Configs";
            Configs.Size = new Size(187, 28);
            Configs.TabIndex = 33;
            Configs.SelectedIndexChanged += Configs_SelectedIndexChanged;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // AllSpeedLabel
            // 
            AllSpeedLabel.AutoSize = true;
            AllSpeedLabel.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            AllSpeedLabel.Location = new Point(12, 91);
            AllSpeedLabel.Name = "AllSpeedLabel";
            AllSpeedLabel.Size = new Size(63, 17);
            AllSpeedLabel.TabIndex = 17;
            AllSpeedLabel.Text = "Speed All";
            // 
            // RepeatsLabel
            // 
            RepeatsLabel.AutoSize = true;
            RepeatsLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            RepeatsLabel.Location = new Point(216, 88);
            RepeatsLabel.Name = "RepeatsLabel";
            RepeatsLabel.Size = new Size(95, 20);
            RepeatsLabel.TabIndex = 23;
            RepeatsLabel.Text = "Повторения";
            // 
            // DelayLabel
            // 
            DelayLabel.AutoSize = true;
            DelayLabel.Location = new Point(216, 129);
            DelayLabel.Name = "DelayLabel";
            DelayLabel.Size = new Size(196, 20);
            DelayLabel.TabIndex = 20;
            DelayLabel.Text = "Задержка перед повтором";
            // 
            // TurnLabel
            // 
            TurnLabel.AutoSize = true;
            TurnLabel.Location = new Point(216, 170);
            TurnLabel.Name = "TurnLabel";
            TurnLabel.Size = new Size(133, 20);
            TurnLabel.TabIndex = 25;
            TurnLabel.Text = "Поворот флакона";
            // 
            // ZazhimLabel
            // 
            ZazhimLabel.AutoSize = true;
            ZazhimLabel.Location = new Point(216, 211);
            ZazhimLabel.Name = "ZazhimLabel";
            ZazhimLabel.Size = new Size(119, 20);
            ZazhimLabel.TabIndex = 27;
            ZazhimLabel.Text = "Зажим флакона";
            // 
            // PrizimLabel
            // 
            PrizimLabel.AutoSize = true;
            PrizimLabel.Location = new Point(216, 252);
            PrizimLabel.Name = "PrizimLabel";
            PrizimLabel.Size = new Size(121, 20);
            PrizimLabel.TabIndex = 29;
            PrizimLabel.Text = "Прижим валика";
            // 
            // StartFlyLabel
            // 
            StartFlyLabel.AutoSize = true;
            StartFlyLabel.Location = new Point(216, 293);
            StartFlyLabel.Name = "StartFlyLabel";
            StartFlyLabel.Size = new Size(134, 20);
            StartFlyLabel.TabIndex = 31;
            StartFlyLabel.Text = "Начальный вылет";
            // 
            // ValikPrizhimLabel
            // 
            ValikPrizhimLabel.AutoSize = true;
            ValikPrizhimLabel.Location = new Point(17, 338);
            ValikPrizhimLabel.Name = "ValikPrizhimLabel";
            ValikPrizhimLabel.Size = new Size(238, 20);
            ValikPrizhimLabel.TabIndex = 32;
            ValikPrizhimLabel.Text = "Положение прижимного валика";
            // 
            // ValikPrizhimStartLabel
            // 
            ValikPrizhimStartLabel.AutoSize = true;
            ValikPrizhimStartLabel.Location = new Point(17, 361);
            ValikPrizhimStartLabel.Name = "ValikPrizhimStartLabel";
            ValikPrizhimStartLabel.Size = new Size(61, 20);
            ValikPrizhimStartLabel.TabIndex = 33;
            ValikPrizhimStartLabel.Text = "Начало";
            // 
            // ValikPrizhimEndLabel
            // 
            ValikPrizhimEndLabel.AutoSize = true;
            ValikPrizhimEndLabel.Location = new Point(92, 361);
            ValikPrizhimEndLabel.Name = "ValikPrizhimEndLabel";
            ValikPrizhimEndLabel.Size = new Size(53, 20);
            ValikPrizhimEndLabel.TabIndex = 34;
            ValikPrizhimEndLabel.Text = "Конец";
            // 
            // KaretkaEndLabel
            // 
            KaretkaEndLabel.AutoSize = true;
            KaretkaEndLabel.Location = new Point(342, 361);
            KaretkaEndLabel.Name = "KaretkaEndLabel";
            KaretkaEndLabel.Size = new Size(53, 20);
            KaretkaEndLabel.TabIndex = 40;
            KaretkaEndLabel.Text = "Конец";
            // 
            // KaretkaStartLabel
            // 
            KaretkaStartLabel.AutoSize = true;
            KaretkaStartLabel.Location = new Point(267, 361);
            KaretkaStartLabel.Name = "KaretkaStartLabel";
            KaretkaStartLabel.Size = new Size(61, 20);
            KaretkaStartLabel.TabIndex = 39;
            KaretkaStartLabel.Text = "Начало";
            // 
            // KaretkaLabel
            // 
            KaretkaLabel.AutoSize = true;
            KaretkaLabel.Location = new Point(267, 338);
            KaretkaLabel.Name = "KaretkaLabel";
            KaretkaLabel.Size = new Size(149, 20);
            KaretkaLabel.TabIndex = 38;
            KaretkaLabel.Text = "Положение каретки";
            // 
            // TurnFlakonPolozhenieEndLabel
            // 
            TurnFlakonPolozhenieEndLabel.AutoSize = true;
            TurnFlakonPolozhenieEndLabel.Location = new Point(92, 452);
            TurnFlakonPolozhenieEndLabel.Name = "TurnFlakonPolozhenieEndLabel";
            TurnFlakonPolozhenieEndLabel.Size = new Size(53, 20);
            TurnFlakonPolozhenieEndLabel.TabIndex = 45;
            TurnFlakonPolozhenieEndLabel.Text = "Конец";
            // 
            // TurnFlakonPolozhenieStartLabel
            // 
            TurnFlakonPolozhenieStartLabel.AutoSize = true;
            TurnFlakonPolozhenieStartLabel.Location = new Point(17, 452);
            TurnFlakonPolozhenieStartLabel.Name = "TurnFlakonPolozhenieStartLabel";
            TurnFlakonPolozhenieStartLabel.Size = new Size(61, 20);
            TurnFlakonPolozhenieStartLabel.TabIndex = 44;
            TurnFlakonPolozhenieStartLabel.Text = "Начало";
            // 
            // TurnFlakonPolozhenieLabel
            // 
            TurnFlakonPolozhenieLabel.AutoSize = true;
            TurnFlakonPolozhenieLabel.Location = new Point(17, 429);
            TurnFlakonPolozhenieLabel.Name = "TurnFlakonPolozhenieLabel";
            TurnFlakonPolozhenieLabel.Size = new Size(225, 20);
            TurnFlakonPolozhenieLabel.TabIndex = 43;
            TurnFlakonPolozhenieLabel.Text = "Положение поворота флакона";
            // 
            // PrizhimFlakonPolozhenieEndLabel
            // 
            PrizhimFlakonPolozhenieEndLabel.AutoSize = true;
            PrizhimFlakonPolozhenieEndLabel.Location = new Point(342, 452);
            PrizhimFlakonPolozhenieEndLabel.Name = "PrizhimFlakonPolozhenieEndLabel";
            PrizhimFlakonPolozhenieEndLabel.Size = new Size(53, 20);
            PrizhimFlakonPolozhenieEndLabel.TabIndex = 50;
            PrizhimFlakonPolozhenieEndLabel.Text = "Конец";
            // 
            // PrizhimFlakonPolozhenieStartLabel
            // 
            PrizhimFlakonPolozhenieStartLabel.AutoSize = true;
            PrizhimFlakonPolozhenieStartLabel.Location = new Point(267, 452);
            PrizhimFlakonPolozhenieStartLabel.Name = "PrizhimFlakonPolozhenieStartLabel";
            PrizhimFlakonPolozhenieStartLabel.Size = new Size(61, 20);
            PrizhimFlakonPolozhenieStartLabel.TabIndex = 49;
            PrizhimFlakonPolozhenieStartLabel.Text = "Начало";
            // 
            // PrizhimFlakonPolozhenieLabel
            // 
            PrizhimFlakonPolozhenieLabel.AutoSize = true;
            PrizhimFlakonPolozhenieLabel.Location = new Point(267, 429);
            PrizhimFlakonPolozhenieLabel.Name = "PrizhimFlakonPolozhenieLabel";
            PrizhimFlakonPolozhenieLabel.Size = new Size(253, 20);
            PrizhimFlakonPolozhenieLabel.TabIndex = 48;
            PrizhimFlakonPolozhenieLabel.Text = "Положение оси прижима флакона";
            // 
            // XGroup
            // 
            XGroup.Controls.Add(XEnd);
            XGroup.Controls.Add(XStart);
            XGroup.Location = new Point(546, 80);
            XGroup.Name = "XGroup";
            XGroup.Size = new Size(157, 59);
            XGroup.TabIndex = 53;
            XGroup.TabStop = false;
            XGroup.Text = "Парковка X";
            // 
            // YGroup
            // 
            YGroup.BackColor = SystemColors.ControlLightLight;
            YGroup.Controls.Add(YEnd);
            YGroup.Controls.Add(YStart);
            YGroup.Location = new Point(546, 145);
            YGroup.Name = "YGroup";
            YGroup.Size = new Size(157, 59);
            YGroup.TabIndex = 54;
            YGroup.TabStop = false;
            YGroup.Text = "Парковка Y";
            // 
            // ZGroup
            // 
            ZGroup.Controls.Add(ZEnd);
            ZGroup.Controls.Add(ZStart);
            ZGroup.Location = new Point(546, 213);
            ZGroup.Name = "ZGroup";
            ZGroup.Size = new Size(157, 59);
            ZGroup.TabIndex = 55;
            ZGroup.TabStop = false;
            ZGroup.Text = "Парковка Z";
            // 
            // AGroup
            // 
            AGroup.Controls.Add(AEnd);
            AGroup.Controls.Add(AStart);
            AGroup.Location = new Point(546, 278);
            AGroup.Name = "AGroup";
            AGroup.Size = new Size(157, 59);
            AGroup.TabIndex = 56;
            AGroup.TabStop = false;
            AGroup.Text = "Парковка A";
            // 
            // BGroup
            // 
            BGroup.Controls.Add(BEnd);
            BGroup.Controls.Add(BStart);
            BGroup.Location = new Point(546, 343);
            BGroup.Name = "BGroup";
            BGroup.Size = new Size(157, 59);
            BGroup.TabIndex = 56;
            BGroup.TabStop = false;
            BGroup.Text = "Парковка B";
            // 
            // LogsOutBox
            // 
            LogsOutBox.Location = new Point(709, 252);
            LogsOutBox.Name = "LogsOutBox";
            LogsOutBox.Size = new Size(320, 205);
            LogsOutBox.TabIndex = 57;
            LogsOutBox.Text = "";
            LogsOutBox.Visible = false;
            // 
            // Test
            // 
            Test.Location = new Point(935, 479);
            Test.Name = "Test";
            Test.Size = new Size(94, 29);
            Test.TabIndex = 58;
            Test.Text = "Тык";
            Test.UseVisualStyleBackColor = true;
            Test.Visible = false;
            Test.Click += Test_Click;
            // 
            // CleanLogsOutBox
            // 
            CleanLogsOutBox.AutoSize = true;
            CleanLogsOutBox.Location = new Point(825, 463);
            CleanLogsOutBox.Name = "CleanLogsOutBox";
            CleanLogsOutBox.Size = new Size(86, 24);
            CleanLogsOutBox.TabIndex = 59;
            CleanLogsOutBox.Text = "Чистить";
            CleanLogsOutBox.UseVisualStyleBackColor = true;
            CleanLogsOutBox.Visible = false;
            // 
            // TurnOnLogsOut
            // 
            TurnOnLogsOut.AutoSize = true;
            TurnOnLogsOut.Location = new Point(825, 486);
            TurnOnLogsOut.Name = "TurnOnLogsOut";
            TurnOnLogsOut.Size = new Size(73, 24);
            TurnOnLogsOut.TabIndex = 60;
            TurnOnLogsOut.Text = "Логер";
            TurnOnLogsOut.UseVisualStyleBackColor = true;
            TurnOnLogsOut.Visible = false;
            // 
            // ConfigDirectoryPathLabel
            // 
            ConfigDirectoryPathLabel.AutoSize = true;
            ConfigDirectoryPathLabel.Location = new Point(592, 17);
            ConfigDirectoryPathLabel.Name = "ConfigDirectoryPathLabel";
            ConfigDirectoryPathLabel.Size = new Size(15, 20);
            ConfigDirectoryPathLabel.TabIndex = 61;
            ConfigDirectoryPathLabel.Text = "-";
            ConfigDirectoryPathLabel.Visible = false;
            // 
            // ConfigFilePathLabel
            // 
            ConfigFilePathLabel.AutoSize = true;
            ConfigFilePathLabel.Location = new Point(592, 37);
            ConfigFilePathLabel.Name = "ConfigFilePathLabel";
            ConfigFilePathLabel.Size = new Size(15, 20);
            ConfigFilePathLabel.TabIndex = 62;
            ConfigFilePathLabel.Text = "-";
            ConfigFilePathLabel.Visible = false;
            // 
            // ConfigFileNameLabel
            // 
            ConfigFileNameLabel.AutoSize = true;
            ConfigFileNameLabel.Location = new Point(592, 57);
            ConfigFileNameLabel.Name = "ConfigFileNameLabel";
            ConfigFileNameLabel.Size = new Size(15, 20);
            ConfigFileNameLabel.TabIndex = 63;
            ConfigFileNameLabel.Text = "-";
            ConfigFileNameLabel.Visible = false;
            // 
            // ConfigFileNameLabel2
            // 
            ConfigFileNameLabel2.AutoSize = true;
            ConfigFileNameLabel2.Location = new Point(444, 57);
            ConfigFileNameLabel2.Name = "ConfigFileNameLabel2";
            ConfigFileNameLabel2.Size = new Size(119, 20);
            ConfigFileNameLabel2.TabIndex = 66;
            ConfigFileNameLabel2.Text = "ConfigFileName:";
            ConfigFileNameLabel2.Visible = false;
            // 
            // ConfigFilePathLabel2
            // 
            ConfigFilePathLabel2.AutoSize = true;
            ConfigFilePathLabel2.Location = new Point(444, 37);
            ConfigFilePathLabel2.Name = "ConfigFilePathLabel2";
            ConfigFilePathLabel2.Size = new Size(107, 20);
            ConfigFilePathLabel2.TabIndex = 65;
            ConfigFilePathLabel2.Text = "ConfigFilePath:";
            ConfigFilePathLabel2.Visible = false;
            // 
            // ConfigDirectoryPathLabel2
            // 
            ConfigDirectoryPathLabel2.AutoSize = true;
            ConfigDirectoryPathLabel2.Location = new Point(444, 17);
            ConfigDirectoryPathLabel2.Name = "ConfigDirectoryPathLabel2";
            ConfigDirectoryPathLabel2.Size = new Size(145, 20);
            ConfigDirectoryPathLabel2.TabIndex = 64;
            ConfigDirectoryPathLabel2.Text = "ConfigDirectoryPath:";
            ConfigDirectoryPathLabel2.Visible = false;
            // 
            // allFeedrates
            // 
            allFeedrates.DropDownStyle = ComboBoxStyle.DropDownList;
            allFeedrates.FormattingEnabled = true;
            allFeedrates.Location = new Point(245, 35);
            allFeedrates.Name = "allFeedrates";
            allFeedrates.Size = new Size(187, 28);
            allFeedrates.TabIndex = 67;
            allFeedrates.SelectedIndexChanged += allFeedrates_SelectedIndexChanged;
            // 
            // AllFeedratesLabel
            // 
            AllFeedratesLabel.AutoSize = true;
            AllFeedratesLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            AllFeedratesLabel.Location = new Point(245, 12);
            AllFeedratesLabel.Name = "AllFeedratesLabel";
            AllFeedratesLabel.Size = new Size(95, 20);
            AllFeedratesLabel.TabIndex = 68;
            AllFeedratesLabel.Text = "All Feedrates";
            // 
            // BindsOut
            // 
            BindsOut.AutoSize = true;
            BindsOut.Location = new Point(742, 463);
            BindsOut.Name = "BindsOut";
            BindsOut.Size = new Size(77, 24);
            BindsOut.TabIndex = 69;
            BindsOut.Text = "Бинды";
            BindsOut.UseVisualStyleBackColor = true;
            BindsOut.Visible = false;
            // 
            // ItogOut
            // 
            ItogOut.AutoSize = true;
            ItogOut.Location = new Point(742, 486);
            ItogOut.Name = "ItogOut";
            ItogOut.Size = new Size(63, 24);
            ItogOut.TabIndex = 70;
            ItogOut.Text = "Итог";
            ItogOut.UseVisualStyleBackColor = true;
            ItogOut.Visible = false;
            // 
            // Admin
            // 
            Admin.AutoSize = true;
            Admin.Location = new Point(628, 11);
            Admin.Name = "Admin";
            Admin.Size = new Size(75, 24);
            Admin.TabIndex = 71;
            Admin.Text = "Admin";
            Admin.UseVisualStyleBackColor = true;
            Admin.CheckedChanged += Admin_CheckedChanged;
            // 
            // GCodeGenerator
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1038, 515);
            Controls.Add(UpdateConfigs);
            Controls.Add(Admin);
            Controls.Add(ItogOut);
            Controls.Add(BindsOut);
            Controls.Add(AllFeedratesLabel);
            Controls.Add(allFeedrates);
            Controls.Add(ConfigFileNameLabel2);
            Controls.Add(ConfigFilePathLabel2);
            Controls.Add(ConfigDirectoryPathLabel2);
            Controls.Add(ConfigFileNameLabel);
            Controls.Add(ConfigFilePathLabel);
            Controls.Add(ConfigDirectoryPathLabel);
            Controls.Add(TurnOnLogsOut);
            Controls.Add(CleanLogsOutBox);
            Controls.Add(Test);
            Controls.Add(LogsOutBox);
            Controls.Add(ChangeFile);
            Controls.Add(BGroup);
            Controls.Add(AGroup);
            Controls.Add(ZGroup);
            Controls.Add(YGroup);
            Controls.Add(XGroup);
            Controls.Add(PrizhimFlakonPolozhenieEndBox);
            Controls.Add(PrizhimFlakonPolozhenieStartBox);
            Controls.Add(PrizhimFlakonPolozhenieEndLabel);
            Controls.Add(PrizhimFlakonPolozhenieStartLabel);
            Controls.Add(PrizhimFlakonPolozhenieLabel);
            Controls.Add(TurnFlakonPolozhenieEndBox);
            Controls.Add(TurnFlakonPolozhenieStartBox);
            Controls.Add(TurnFlakonPolozhenieEndLabel);
            Controls.Add(TurnFlakonPolozhenieStartLabel);
            Controls.Add(TurnFlakonPolozhenieLabel);
            Controls.Add(KaretkaEndBox);
            Controls.Add(KaretkaStartBox);
            Controls.Add(KaretkaEndLabel);
            Controls.Add(KaretkaStartLabel);
            Controls.Add(KaretkaLabel);
            Controls.Add(ValikPrizhimEndBox);
            Controls.Add(ValikPrizhimStartBox);
            Controls.Add(ValikPrizhimEndLabel);
            Controls.Add(ValikPrizhimStartLabel);
            Controls.Add(ValikPrizhimLabel);
            Controls.Add(StartFlyLabel);
            Controls.Add(StartFlyBox);
            Controls.Add(PrizimLabel);
            Controls.Add(PrizimBox);
            Controls.Add(ZazhimLabel);
            Controls.Add(ZazhimBox);
            Controls.Add(TurnLabel);
            Controls.Add(TurnBox);
            Controls.Add(RepeatsLabel);
            Controls.Add(RepeatsBox);
            Controls.Add(DelayLabel);
            Controls.Add(DelayBox);
            Controls.Add(AllSpeedLabel);
            Controls.Add(AllSpeedBox);
            Controls.Add(ConfigDelete);
            Controls.Add(OpenFileButton);
            Controls.Add(OpenConfigsFolder);
            Controls.Add(Configs);
            Controls.Add(ConfigsCountINT);
            Controls.Add(ConfigsCountSTR);
            Controls.Add(FileInfo);
            Controls.Add(BSpeedLabel);
            Controls.Add(ASpeedLabel);
            Controls.Add(BSpeedBox);
            Controls.Add(ASpeedBox);
            Controls.Add(ZSpeedLabel);
            Controls.Add(ZSpeedBox);
            Controls.Add(YSpeedLabel);
            Controls.Add(YSpeedBox);
            Controls.Add(XSpeedLabel);
            Controls.Add(XSpeedBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "GCodeGenerator";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GCodeGenerator";
            XGroup.ResumeLayout(false);
            XGroup.PerformLayout();
            YGroup.ResumeLayout(false);
            YGroup.PerformLayout();
            ZGroup.ResumeLayout(false);
            ZGroup.PerformLayout();
            AGroup.ResumeLayout(false);
            AGroup.PerformLayout();
            BGroup.ResumeLayout(false);
            BGroup.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox XSpeedBox;
        private Label XSpeedLabel;
        private Label YSpeedLabel;
        private RichTextBox YSpeedBox;
        private Label ZSpeedLabel;
        private RichTextBox ZSpeedBox;
        private Label ASpeedLabel;
        private RichTextBox ASpeedBox;
        private RichTextBox BSpeedBox;
        private Label BSpeedLabel;
        private ToolTip Help;
        private RichTextBox FileInfo;
        private Label ConfigsCountSTR;
        private Label ConfigsCountINT;
        private ComboBox Configs;
        private Button OpenConfigsFolder;
        private Button OpenFileButton;
        private OpenFileDialog openFileDialog1;
        private Button ConfigDelete;
        private RichTextBox AllSpeedBox;
        private Label AllSpeedLabel;
        private Label RepeatsLabel;
        private RichTextBox RepeatsBox;
        private Label DelayLabel;
        private RichTextBox DelayBox;
        private Label TurnLabel;
        private RichTextBox TurnBox;
        private Label ZazhimLabel;
        private RichTextBox ZazhimBox;
        private Label PrizimLabel;
        private RichTextBox PrizimBox;
        private Label StartFlyLabel;
        private RichTextBox StartFlyBox;
        private Label ValikPrizhimLabel;
        private Label ValikPrizhimStartLabel;
        private Label ValikPrizhimEndLabel;
        private RichTextBox ValikPrizhimStartBox;
        private RichTextBox ValikPrizhimEndBox;
        private RichTextBox KaretkaEndBox;
        private RichTextBox KaretkaStartBox;
        private Label KaretkaEndLabel;
        private Label KaretkaStartLabel;
        private Label KaretkaLabel;
        private RichTextBox TurnFlakonPolozhenieEndBox;
        private RichTextBox TurnFlakonPolozhenieStartBox;
        private Label TurnFlakonPolozhenieEndLabel;
        private Label TurnFlakonPolozhenieStartLabel;
        private Label TurnFlakonPolozhenieLabel;
        private RichTextBox PrizhimFlakonPolozhenieEndBox;
        private RichTextBox PrizhimFlakonPolozhenieStartBox;
        private Label PrizhimFlakonPolozhenieEndLabel;
        private Label PrizhimFlakonPolozhenieStartLabel;
        private Label PrizhimFlakonPolozhenieLabel;
        private GroupBox XGroup;
        private RadioButton XEnd;
        private RadioButton XStart;
        private GroupBox YGroup;
        private RadioButton YEnd;
        private RadioButton YStart;
        private GroupBox ZGroup;
        private RadioButton ZEnd;
        private RadioButton ZStart;
        private GroupBox AGroup;
        private RadioButton AEnd;
        private RadioButton AStart;
        private GroupBox BGroup;
        private RadioButton BEnd;
        private RadioButton BStart;
        private Button ChangeFile;
        private RichTextBox LogsOutBox;
        private Button Test;
        private CheckBox CleanLogsOutBox;
        private CheckBox TurnOnLogsOut;
        private Label ConfigDirectoryPathLabel;
        private Label ConfigFilePathLabel;
        private Label ConfigFileNameLabel;
        private Label ConfigFileNameLabel2;
        private Label ConfigFilePathLabel2;
        private Label ConfigDirectoryPathLabel2;
        private ComboBox allFeedrates;
        private Label AllFeedratesLabel;
        private CheckBox BindsOut;
        private CheckBox ItogOut;
        private CheckBox Admin;
        private Button UpdateConfigs;
    }
}
