using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using CmlLib.Core;
using CmlLib.Core.Auth;
using CmlLib.Core.Auth.Microsoft.UI.WinForm;
using CmlLib.Core.Version;
using CmlLib.Core.Downloader;
using DiscordRPC;

namespace PolsatLauncher_beta
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            // =========== NOTIFY ICON ===========

            notifyIcon1.ContextMenuStrip = new ContextMenuStrip();
            notifyIcon1.ContextMenuStrip.Items.Add("Zakończ", null, MenuTest1_Click);
        }

        public DiscordRpcClient client { get; private set; }

        private void onApplicationExit(object sender, EventArgs e)
        {
            try
            {
                TextToLog("Application Exit");
                Process procesToKil = Process.GetProcessById(procesID);
                procesToKil.Kill();
            }
            catch (Exception ex)
            {
                TextToLog("Application Exit bug: " + ex);
            }
        }

        bool MenuClickZakoncz;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveCurrentValues();
            TextToLog("Form Closing");
            if (MenuClickZakoncz == true) { return; }
            if (procesID == -1) { return; }
            if (MessageBox.Show("Minecraft jest włączony.\nCzy chcesz zminimalizować launcher?", "PolsatLauncher", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                e.Cancel = true;
                Hide();
                notifyIcon1.Visible = true;
                return;
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Show();
                notifyIcon1.Visible = false;
            }
        }

        void MenuTest1_Click(object sender, EventArgs e)
        {
            if (procesID == -1)
            {
                return;
            }
            if (MessageBox.Show("Minecraft jest włączony.\nCzy na pewno chcesz wyłączyć launcher?\n\nTa akcja spowoduje wyjście z gry minecraft!", "PolsatLauncher", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                MenuClickZakoncz = true;
                Application.Exit();
            }
        }

        string nick;
        Timestamps TimestampsX = Timestamps.Now;
        private void UpdateDiscordRichPresence()
        {
            try
            {
                if (checkBox2.Checked)
                { nick = sessionMC.Username; }
                else
                { nick = textBox1.Text; }
            }
            catch
            {
                nick = textBox1.Text;
            }

            client.SetPresence(new RichPresence()
            {
                Details = "Nick:  " + nick + $"  ({premiumstatus})",
                State = "Wersja:  " + comboBox1.Text,
                Timestamps = TimestampsX,
                Assets = new Assets()
                {
                    LargeImageKey = "polsatlauncherlogo",
                    LargeImageText = "Wersja launchera: BETA",
                },
                Buttons = new DiscordRPC.Button[]
{
                    new DiscordRPC.Button() { Label = "POBIERZ", Url = "https://discord.gg/vvnRgJMXvV" }, //https://polsatgranie.pl/download
                    new DiscordRPC.Button() { Label = "DISCORD", Url = "https://discord.gg/vvnRgJMXvV" }
}
            });
        }

        private async void Form1_Load(object sender, EventArgs e)
        {

            // =========== ON EXIT ===========

            AppDomain.CurrentDomain.ProcessExit += new EventHandler(onApplicationExit);

            // =========== DISCORD ===========

            client = new DiscordRpcClient("1001141221172977766");
            client.Initialize();
            TextToLog("Discord Rpc Initialize");
            UpdateDiscordRichPresence();

            // =========== LAUNCHER ===========

            LoadCurrentValues(sender);

            var path = new MinecraftPath();
            var launcher = new CMLauncher(path);

            MVersionCollection versions = await launcher.GetAllVersionsAsync();
            foreach (MVersionMetadata ver in versions)
            {
                if (ver.Type == "local")
                {
                    comboBox1.Items.Add(ver.Name);
                    TextToLog("Version load: " + ver.Name);
                }
            }
            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                comboBox1.Text = launcher.Versions?.LatestReleaseVersion?.Name;
            }
            int mb = Convert.ToInt32(new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory / 1073741);
            trackBar1.Maximum = mb;
            label3.Text = "Wybrana pamięć: " + trackBar1.Value + "/" + trackBar1.Maximum;
            TextToLog("Form loaded");
        }

        private void DisableSysLauncher()
        {
            comboBox1.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            button2.Enabled = false;
            checkBox2.Enabled = false;
            checkBox1.Enabled = false;
            trackBar1.Enabled = false;
            TextToLog("Minecraft start loading...");
        }

        private void EnableSysLauncher()
        {
            comboBox1.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            button2.Enabled = true;
            checkBox2.Enabled = true;
            checkBox1.Enabled = true;
            trackBar1.Enabled = true;
            progressBar1.Value = 0;
            label4.Text = "Status:";
            label7.Text = "";
            TextToLog("Minecraft stop");
        }

        private TaskCompletionSource<bool> eventHandled;

        private MSession sessionMC;
        MicrosoftLoginForm loginForm = new MicrosoftLoginForm();
        int procesID = -1;
        private async void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Zabij proces")
            {
                Process procesToKil = Process.GetProcessById(procesID);
                procesToKil.Kill();
                TextToLog("Process kill");
                return;
            }
            try
            {
                eventHandled = new TaskCompletionSource<bool>();

                var path = new MinecraftPath();
                var launcher = new CMLauncher(path);

                launcher.FileChanged += Launcher_FileChanged;
                launcher.ProgressChanged += Launcher_ProgressChanged;

                if (!checkBox2.Checked)
                { sessionMC = MSession.GetOfflineSession(textBox1.Text); }

                var launchOption = new MLaunchOption
                {

                    Session = sessionMC,

                    Path = new MinecraftPath(),
                    MaximumRamMb = trackBar1.Value,

                    ScreenWidth = int.Parse(textBox2.Text),
                    ScreenHeight = int.Parse(textBox3.Text),

                    VersionType = "§cPolsatLauncher-BETA§f ©",
                    GameLauncherName = "§cPolsatLauncher-BETA§f ©",
                    GameLauncherVersion = "2",

                    FullScreen = checkBox1.Checked
                };

                MVersionCollection versions2 = await launcher.GetAllVersionsAsync();
                string selected;

                selected = comboBox1.Text;
                if (!checkBox2.Checked)
                {
                    if (string.IsNullOrWhiteSpace(textBox1.Text))
                    {
                        MessageBox.Show("Nieprawidłowa nazwa użytkownika!", "PolsatLauncher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (string.IsNullOrWhiteSpace(selected))
                {
                    MessageBox.Show("Podaj jakąkolwiek wersję gry!", "PolsatLauncher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!versions2.Contains(selected))
                {
                    MessageBox.Show("Podana wersja gry nie istnieje!", "PolsatLauncher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                DisableSysLauncher();
                button1.Enabled = false;
                button1.Text = "Uruchamianie...";
                var process = await launcher.CreateProcessAsync(selected, launchOption, true);
                process.EnableRaisingEvents = true;
                process.Exited += new EventHandler(process_Exited);
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.StandardErrorEncoding = Encoding.UTF8;
                process.StartInfo.StandardOutputEncoding = Encoding.UTF8;

                process.Start();

                process.BeginErrorReadLine();
                process.BeginOutputReadLine();
                process.ErrorDataReceived += Process_DataReceived;
                process.OutputDataReceived += Process_DataReceived;
                TextToLog("Process start");
                button1.Enabled = true;
                button1.Text = "Zabij proces";
                procesID = process.Id;
            }
            catch (Exception ex)
            {
                button1.Enabled = true;
                button1.Text = "Uruchom minecraft";
                TextToLog(ex.ToString());
                MessageBox.Show("Wystąpił błąd podczas uruchamiania rozgrywki: " + ex.Message, "PolsatLauncher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EnableSysLauncher();
                return;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            if (button2.Text != "Microsoft login")
            {
                if (MessageBox.Show("Jesteś już zalogowany, chcesz się wylogować?", "PolsatLauncher", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MicrosoftLoginForm loginForm = new MicrosoftLoginForm();
                    loginForm.ShowLogoutDialog();
                    button2.Text = "Microsoft login";
                    checkBox2.Checked = false;
                    checkBox2.Enabled = false;
                    button1.Enabled = true;
                    return;
                }
                else
                {
                    button1.Enabled = true;
                    return;
                }
            }
            button2.Text = "Logowanie...";
            button2.Enabled = false;
            try
            {
                MSession session = await loginForm.ShowLoginDialog();
                sessionMC = session;
                button2.Enabled = true;
                button2.Text = "Konto: " + session.Username;
                checkBox2.Checked = true;
                checkBox2.Enabled = true;
                textBox1.Enabled = false;
                TextToLog("Success login: " + session.Username);
                UpdateDiscordRichPresence();
                button1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas logowania: " + ex.Message, "PolsatLauncher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextToLog("Bug: " + ex);
                button2.Text = "Microsoft login";
                button2.Enabled = true;
                checkBox2.Checked = false;
                checkBox2.Enabled = false;
                button1.Enabled = true;
            }
        }

        private void process_Exited(object sender, EventArgs e)
        {
            SetButtonOnStop();
            eventHandled.TrySetResult(true);
        }

        private void SetButtonOnStop()
        {
            if (button1.InvokeRequired)
            {
                Action safeWrite = delegate { SetButtonOnStop(); };
                button1.Invoke(safeWrite);
            }
            else
            {
                procesID = -1;
                Show();
                notifyIcon1.Visible = false;
                EnableSysLauncher();
                button1.Enabled = true;
                button1.Text = "Uruchom minecraft";

            }
        }

        private void Launcher_FileChanged(DownloadFileChangedEventArgs e)
        {
            richTextBox1.Invoke(new Action(delegate ()
            {
                progressBar1.Maximum = e.TotalFileCount;
                progressBar1.Value = e.ProgressedFileCount;
                string Text = "Status: " + e.FileName;
                if (Text.Length > 35)
                {
                    Text = Text.Substring(0, 35);
                }
                label4.Text = Text;

                AddLog("\n[" + e.FileKind.ToString() + "] " + e.FileName + " - " + e.ProgressedFileCount + "/" + e.TotalFileCount);
                if (e.ProgressedFileCount == e.TotalFileCount)
                {
                    TextToLog("Resource loaded");
                }
            }));
        }

        private void Launcher_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Maximum = 100;
            progressBar1.Value = e.ProgressPercentage;
            label7.Text = "(" + e.ProgressPercentage + "%)";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        { label3.Text = "Wybrana pamięć: " + trackBar1.Value + "/" + trackBar1.Maximum; }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { UpdateDiscordRichPresence(); }

        private void textBox1_TextChanged(object sender, EventArgs e) { UpdateDiscordRichPresence(); }


        string premiumstatus = "Cracked";
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox1.Enabled = false;
                premiumstatus = "Premium";
            }
            else
            {
                textBox1.Enabled = true;
                premiumstatus = "Cracked";
            }
            UpdateDiscordRichPresence();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                client = new DiscordRpcClient("1001141221172977766");
                client.Initialize();
                UpdateDiscordRichPresence();
            }
            else
            {
                client.Dispose();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "<")
            {
                richTextBox1.Visible = false;
                this.Size = new Size(this.Size.Width - 434, this.Size.Height);
                button3.Text = ">";
            }
            else if (button3.Text == ">")
            {
                this.Size = new Size(this.Size.Width + 434, this.Size.Height);
                button3.Text = "<";
                richTextBox1.Visible = true;
            }

        }
        private void TextToLog(string Tekst)
        {
            try
            {
                richTextBox1.Invoke(new Action(delegate ()
                {
                    AddLog("\n[Launcher] " + Tekst);
                }));
            }
            catch { }
        }

        private void Process_DataReceived(object sender, DataReceivedEventArgs e)
        {
            string log = e.Data;
            richTextBox1.Invoke(new Action(delegate ()
            {
                try
                {
                    // Połączenie kodu XML w jeden ciąg znaków
                    string xmlCode = string.Join("", log.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries));

                    // Wyszukanie wartości CDATA
                    int cdataStartIndex = xmlCode.IndexOf("<![CDATA[");
                    int cdataEndIndex = xmlCode.IndexOf("]]>");

                    if (cdataStartIndex != -1 && cdataEndIndex != -1)
                    {
                        cdataStartIndex += "<![CDATA[".Length;
                        string cdataValue = xmlCode.Substring(cdataStartIndex, cdataEndIndex - cdataStartIndex);
                        AddLog("\n[Minecraft] " + cdataValue);
                    }
                }
                catch
                {

                }
            }));
        }

        private void AddLog(string text)
        {
            richTextBox1.AppendText(text);
            richTextBox1.ScrollToCaret();
        }

        private void SaveCurrentValues()
        {
            var data = new
            {
                ComboBox1Value = comboBox1.Text,
                TextBox2Value = textBox2.Text,
                TextBox3Value = textBox3.Text,
                TextBox1Value = textBox1.Text,
                CheckBox1Value = checkBox1.Checked,
                CheckBox2Value = checkBox2.Checked,
                CheckBox3Value = checkBox3.Checked,
                TrackBar1Value = trackBar1.Value,
                LogsValue = button3.Text
            };
            string jsonData = JsonSerializer.Serialize(data);
            File.WriteAllText("data.json", jsonData);
        }

        private void LoadCurrentValues(object sender)
        {
            try
            {
                // Wczytywanie danych z pliku data.json
                string jsonData = File.ReadAllText("data.json");

                // Deserializacja danych JSON do obiektu
                var data = JsonSerializer.Deserialize<DataObject>(jsonData);

                // Wyświetlanie wczytanych wartości
                comboBox1.Text = data.ComboBox1Value;
                textBox2.Text = data.TextBox2Value;
                textBox3.Text = data.TextBox3Value;
                textBox1.Text = data.TextBox1Value;
                checkBox1.Checked = data.CheckBox1Value;
                checkBox3.Checked = data.CheckBox3Value;
                checkBox2.Checked = data.CheckBox2Value;
                trackBar1.Value = data.TrackBar1Value;

                if (data.LogsValue == ">")
                {
                    richTextBox1.Visible = false;
                    this.Size = new Size(this.Size.Width - 434, this.Size.Height);
                    button3.Text = ">";
                }
                if (checkBox2.Checked == true)
                {
                    button2_Click(sender, null);
                }
            }
            catch
            {
                TextToLog("Brak zapisanych preferencji");
                File.Create("data.json");
            }
        }

        public class DataObject
        {
            public string LogsValue { get; set; }
            public string ComboBox1Value { get; set; }
            public string TextBox2Value { get; set; }
            public string TextBox1Value { get; set; }
            public string TextBox3Value { get; set; }
            public bool CheckBox1Value { get; set; }
            public bool CheckBox2Value { get; set; }
            public bool CheckBox3Value { get; set; }
            public int TrackBar1Value { get; set; }
        }
    }
}
