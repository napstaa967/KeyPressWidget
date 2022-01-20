using Gma.System.MouseKeyHook;
using keystuff.Properties;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace keystuff
{
    public partial class Form1 : Form
    {


        public static string lastkeypress;
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        private IKeyboardMouseEvents m_GlobalHook;
        public bool IsOnSettings = false;

        public ContextMenu contextMenu1;
        public MenuItem alwaysOnTop;
        public MenuItem exit;
        public MenuItem autoHide;
        public MenuItem wordBuild;
        public MenuItem hideMain;
        public MenuItem settingStuff;
        public Form1()
        {
            InitializeComponent();


            if (Settings.Default.PerKeyMonitors != null)
            {
                Console.WriteLine("fard");
                Settings.Default.PerKeyMonitors.ForEach(x =>
                {
                    Console.WriteLine("shit");
                    new Form3(x).Show();
                });
            }

            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.contextMenu1 = new ContextMenu();
            this.alwaysOnTop = new MenuItem();
            this.wordBuild = new MenuItem();
            this.hideMain = new MenuItem();
            this.autoHide = new MenuItem();
            this.settingStuff = new MenuItem();
            this.exit = new MenuItem();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = Settings.Default.WindowSize;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.KeyDown += UpdateText;
            alwaysOnTop.Index = 0;
            alwaysOnTop.Text = "Always On Top";
            alwaysOnTop.Click += new EventHandler(this.alwaysOnTop_Click);
            wordBuild.Index = 1;
            wordBuild.Text = "Word Persistance";
            wordBuild.Click += new EventHandler(wordBuild_Click);
            wordBuild.Checked = Settings.Default.WordBuild;
            autoHide.Index = 2;
            autoHide.Text = "Auto-Hide";
            autoHide.Click += new EventHandler(autohide_Click);
            autoHide.Checked = Settings.Default.Autohide;
            hideMain.Index = 3;
            hideMain.Text = "Hide Main Window";
            hideMain.Click += new EventHandler(hideMain_Click);
            hideMain.Checked = Settings.Default.HideMain;
            settingStuff.Index = 4;
            settingStuff.Text = "Settings";
            settingStuff.Click += new EventHandler(settingStuff_Click);
            exit.Index = 5;
            exit.Text = "Exit";
            exit.Click += new EventHandler(exit_Click);
            contextMenu1.MenuItems.AddRange(
                    new System.Windows.Forms.MenuItem[] { alwaysOnTop, wordBuild, autoHide, hideMain, settingStuff, exit });
            KeyboardDisplay.ContextMenu = contextMenu1;
            timer2.Start();
            alwaysOnTop.Checked = TopMost;
            if (Settings.Default.HideMain == true)
            {
                Hide();
            }
        }

        private void alwaysOnTop_Click(object Sender, EventArgs e)
        {
            TopMost = !TopMost;
            Settings.Default.isAlwaysOnTop = TopMost;
            alwaysOnTop.Checked = TopMost;
            Settings.Default.Save();
        }

        private void autohide_Click(object Sender, EventArgs e)
        {
            Settings.Default.Autohide = !Settings.Default.Autohide;
            Settings.Default.Save();
            autoHide.Checked = Settings.Default.Autohide;
        }
        private void hideMain_Click(object Sender, EventArgs e)
        {
            Settings.Default.HideMain = !Settings.Default.HideMain;
            Settings.Default.Save();
            hideMain.Checked = Settings.Default.HideMain;
        }
        private void settingStuff_Click(object Sender, EventArgs e)
        {
            new Form2().Show();
        }
        private void wordBuild_Click(object Sender, EventArgs e)
        {
            Settings.Default.WordBuild = !Settings.Default.WordBuild;
            wordBuild.Checked = Settings.Default.WordBuild;
            Settings.Default.Save();
        }
        private void exit_Click(object Sender, EventArgs e)
        {
            this.Close();
        }
        public string TextList;
        public string FinalLabel;
        public string[] NewList;
        public int IndexStuff;
        public List<string> Chars = new List<string>()
        {
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
        };
        List<string> ListStuff;
        private void UpdateText(object sender, KeyEventArgs e)
        {
            if (Settings.Default.IsOnSettings == false)
            {
                if (Settings.Default.HideMain == false)
                {
                    Show();
                    if (Opacity != Settings.Default.Opacity)
                    {
                        timer1.Stop();
                        Opacity = Settings.Default.Opacity;
                    }
                    TextList = String.Format("\t{0}", e.KeyData);
                    TextList = Regex.Replace(TextList, @"s", "");
                    TextList = TextList.Replace("	", "");
                    TextList = TextList.Replace(" ", "");
                    NewList = TextList.Split(',');
                    ListStuff = new List<string>(NewList);
                    if (ListStuff.IndexOf("RShiftKey") != -1 || ListStuff.IndexOf("LShiftKey") != -1 || ListStuff.IndexOf("Shift") != -1)
                    {
                        while (ListStuff.IndexOf("LShiftKey") != -1)
                        {
                            ListStuff.RemoveAt(ListStuff.IndexOf("LShiftKey"));
                        }
                        while (ListStuff.IndexOf("RShiftKey") != -1)
                        {
                            ListStuff.RemoveAt(ListStuff.IndexOf("RShiftKey"));
                        }
                        while (ListStuff.IndexOf("Shift") != -1)
                        {
                            ListStuff.RemoveAt(ListStuff.IndexOf("Shift"));
                        }
                        if (ListStuff.IndexOf("RShiftKey") == -1 && ListStuff.IndexOf("LShiftKey") == -1 && ListStuff.IndexOf("Shift") == -1)
                        {
                            ListStuff.Insert(0, "Shift");
                        }
                    }
                    if (ListStuff.IndexOf("Alt") != -1 || ListStuff.IndexOf("LMenu") != -1 || ListStuff.IndexOf("RMenu") != -1)
                    {
                        while (ListStuff.IndexOf("Alt") != -1)
                        {
                            ListStuff.RemoveAt(ListStuff.IndexOf("Alt"));
                        }
                        while (ListStuff.IndexOf("LMenu") != -1)
                        {
                            ListStuff.RemoveAt(ListStuff.IndexOf("LMenu"));
                        }
                        while (ListStuff.IndexOf("RMenu") != -1)
                        {
                            ListStuff.RemoveAt(ListStuff.IndexOf("RMenu"));
                        }
                        if (ListStuff.IndexOf("Alt") == -1 && ListStuff.IndexOf("LMenu") == -1 && ListStuff.IndexOf("RMenu") == -1)
                        {

                            ListStuff.Insert(0, "Alt");
                        }
                    }
                    if (ListStuff.IndexOf("Control") != -1 || ListStuff.IndexOf("LControlKey") != -1 || ListStuff.IndexOf("RControlKey") != -1)
                    {
                        while (ListStuff.IndexOf("Control") != -1)
                        {
                            ListStuff.RemoveAt(ListStuff.IndexOf("Control"));
                        }
                        while (ListStuff.IndexOf("LControlKey") != -1)
                        {
                            ListStuff.RemoveAt(ListStuff.IndexOf("LControlKey"));
                        }
                        while (ListStuff.IndexOf("RControlKey") != -1)
                        {
                            ListStuff.RemoveAt(ListStuff.IndexOf("RControlKey"));
                        }
                        if (ListStuff.IndexOf("Control") == -1 && ListStuff.IndexOf("LControlKey") == -1 && ListStuff.IndexOf("RControlKey") == -1)
                        {
                            ListStuff.Insert(0, "Control");
                        }
                    }
                    IndexStuff = ListStuff.IndexOf("LWin");
                    if (IndexStuff != -1)
                    {
                        ListStuff.RemoveAt(IndexStuff);
                        ListStuff.Insert(0, "Win");
                    };
                    Chars.ForEach(test =>
                    {
                        if (ListStuff.IndexOf(test) != -1)
                        {
                            if ((Control.IsKeyLocked(Keys.CapsLock) == true && ListStuff.IndexOf("Shift") != -1) || (Control.IsKeyLocked(Keys.CapsLock) == false && ListStuff.IndexOf("Shift") == -1))
                            {
                                ListStuff[ListStuff.IndexOf(test)] = ListStuff[ListStuff.IndexOf(test)].ToLower();
                            }
                            if (ListStuff.IndexOf("Shift") != -1)
                            {
                                ListStuff.RemoveAt(ListStuff.IndexOf("Shift"));
                            }
                        }

                    });

                    if (Settings.Default.WordBuild == true)
                    {
                        if (!label1.Text.Contains("+"))
                        {
                            if (Chars.Contains(ListStuff[0].ToUpper()))
                            {


                                if (Settings.Default.LastKeyPress == "null" || Chars.Contains(Settings.Default.LastKeyPress.ToUpper()) == false)
                                {
                                    label1.Text = "";
                                    label1.Text = ListStuff[0];
                                }
                                else
                                {
                                    label1.Text += ListStuff[0];
                                }
                                Settings.Default.LastKeyPress = String.Join("+", ListStuff);
                                Settings.Default.Save();
                            }
                            else
                            {
                                Settings.Default.LastKeyPress = String.Join("+", ListStuff);
                                Settings.Default.Save();
                                label1.Text = String.Join("+", ListStuff);
                            }
                        }
                        else
                        {
                            label1.Text = String.Join("+", ListStuff);
                        }
                    }
                    else
                    {
                        label1.Text = String.Join("+", ListStuff);
                    }
                    timer2.Start();
                }
                else
                {
                    Hide();
                }
            }

        }

        internal static void RestartApp()
        {
            Application.Restart();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Opacity -= 0.01D;
            if (Settings.Default.WordBuild == true)
            {
                label1.Text = "";
            }
            if (Opacity <= 0D)
            {
                Opacity = 0D;
                Hide();
                timer1.Stop();
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            label1.Text = "[Idle]";
            timer2.Stop();
            if (Settings.Default.Autohide == true)
                timer1.Start();
        }

        private void KeyboardDisplay_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Opacity = Settings.Default.Opacity;
            Show();
        }
    }
}