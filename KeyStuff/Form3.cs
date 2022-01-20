using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;
using keystuff.Properties;
using System.Drawing;
using System.Linq;

namespace keystuff
{
    public partial class Form3 : Form
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
        public ContextMenu contextMenu1;
        public MenuItem alwaysOnTop;
        public MenuItem exit;
        public MenuItem autoHide;
        public MenuItem wordBuild;
        public MenuItem settingStuff;
        public bool CurrentlyPressed = false;
        public string monitorkey;
        public string typeofmonitor;
        public Form3(string thekey)
        {
            if (ThemeSet == "System")
            {
                if (regsys == 1)
                {
                    ThemeSet = "System";
                    Settings.Default.ThemeTextColor = Color.Black;
                    Settings.Default.ThemeBackColor = Color.White;
                    Settings.Default.ThemeHighlightColor = Color.FromArgb(220, 220, 220);
                    Settings.Default.Save();
                }
                if (regsys == 0)
                {
                    ThemeSet = "System";
                    Settings.Default.ThemeTextColor = Color.White;
                    Settings.Default.ThemeBackColor = Color.Black;
                    Settings.Default.ThemeHighlightColor = Color.FromArgb(60, 60, 60);
                    Settings.Default.Save();
                }
            }
            if (ThemeSet == "Light")
            {
                Settings.Default.ThemeTextColor = Color.Black;
                Settings.Default.ThemeBackColor = Color.White;
                Settings.Default.ThemeHighlightColor = Color.FromArgb(220, 220, 220);
                Settings.Default.Save();
            }
            else if (ThemeSet == "Dark")
            {
                Settings.Default.ThemeTextColor = Color.White;
                Settings.Default.ThemeBackColor = Color.Black;
                Settings.Default.ThemeHighlightColor = Color.FromArgb(60, 60, 60);
                Settings.Default.Save();
            }
            InitializeComponent();
            List<string> stuffnew = thekey.Split('|').ToList();

            this.label1.Text = stuffnew[0];
            this.monitorkey = stuffnew[0];
            Console.WriteLine(stuffnew[1]);
            Console.WriteLine(stuffnew.Count);
            typeofmonitor = stuffnew[3];
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.contextMenu1 = new ContextMenu();
            this.alwaysOnTop = new MenuItem();
            this.wordBuild = new MenuItem();
            this.autoHide = new MenuItem();
            this.settingStuff = new MenuItem();
            this.exit = new MenuItem();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(Int32.Parse(stuffnew[1]), Int32.Parse(stuffnew[2]));
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.panel1.Size = new Size(Int32.Parse(stuffnew[1])-40, Int32.Parse(stuffnew[2])-40);
            this.panel1.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.panel1.Width, this.panel1.Height, 20, 20));
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.KeyDown += UpdateText;
            m_GlobalHook.KeyUp += StopKey;
            m_GlobalHook.MouseDown += UpdateTextMouse;
            m_GlobalHook.MouseUp += StopKeyMouse;
            timer2.Start();
            
        }

        private void UpdateTextMouse(object sender, MouseEventArgs e)
        {
            if (Settings.Default.IsOnSettings == false)
            {
                if (typeofmonitor == "Mouse")
                {
                    Show();
                    List<string> leftmousekeys = new List<string>()
            {
                "LMouse", "LeftMouse", "LeftMouseButton", "LeftMouseKey", "Mouse1", "L"
            };
                    List<string> rightmousekeys = new List<string>()
            {
                "RMouse", "RightMouse", "RightMouseButton", "RightMouseKey", "Mouse2", "R"
            };
                    List<string> middlemousekeys = new List<string>()
            {
                "MMouse", "LMiddleouse", "MiddleMouseButton", "MiddleMouseKey", "Mouse3", "M"
            };
                    if (e.Button == MouseButtons.Left && leftmousekeys.IndexOf(monitorkey) != -1)
                    {

                        CurrentlyPressed = true;
                        if (Opacity != Settings.Default.Opacity)
                        {
                            timer1.Stop();
                            Opacity = Settings.Default.Opacity;
                        }

                        this.panel1.BackColor = Settings.Default.ThemeHighlightColor;

                    }
                    if (e.Button == MouseButtons.Right && rightmousekeys.IndexOf(monitorkey) != -1)
                    {

                        CurrentlyPressed = true;
                        if (Opacity != Settings.Default.Opacity)
                        {
                            timer1.Stop();
                            Opacity = Settings.Default.Opacity;
                        }

                        this.panel1.BackColor = Settings.Default.ThemeHighlightColor;

                    }
                    if (e.Button == MouseButtons.Middle && middlemousekeys.IndexOf(monitorkey) != -1)
                    {

                        CurrentlyPressed = true;
                        if (Opacity != Settings.Default.Opacity)
                        {
                            timer1.Stop();
                            Opacity = Settings.Default.Opacity;
                        }

                        this.panel1.BackColor = Settings.Default.ThemeHighlightColor;

                    }
                }
            }
        }

        private void StopKeyMouse(object sender, MouseEventArgs e)
        {
            if (Settings.Default.IsOnSettings == false)
            {
                if (typeofmonitor == "Mouse")
                {
                    Show();
                    List<string> leftmousekeys = new List<string>()
                {
                    "LMouse", "LeftMouse", "LeftMouseButton", "LeftMouseKey", "Mouse1"
                };
                    List<string> rightmousekeys = new List<string>()
                {
                    "RMouse", "RightMouse", "RightMouseButton", "RightMouseKey", "Mouse2"
                };
                    List<string> middlemousekeys = new List<string>()
                {
                    "MMouse", "LMiddleouse", "MiddleMouseButton", "MiddleMouseKey", "Mouse3"
                };
                    if (e.Button == MouseButtons.Left && leftmousekeys.IndexOf(monitorkey) != -1)
                    {

                        CurrentlyPressed = false;
                        if (Opacity != Settings.Default.Opacity)
                        {
                            timer1.Stop();
                            Opacity = Settings.Default.Opacity;
                        }

                        this.panel1.BackColor = Settings.Default.ThemeBackColor;

                    }
                    if (e.Button == MouseButtons.Right && rightmousekeys.IndexOf(monitorkey) != -1)
                    {

                        CurrentlyPressed = false;
                        if (Opacity != Settings.Default.Opacity)
                        {
                            timer1.Stop();
                            Opacity = Settings.Default.Opacity;
                        }

                        this.panel1.BackColor = Settings.Default.ThemeBackColor;

                    }
                    if (e.Button == MouseButtons.Middle && middlemousekeys.IndexOf(monitorkey) != -1)
                    {

                        CurrentlyPressed = false;
                        if (Opacity != Settings.Default.Opacity)
                        {
                            timer1.Stop();
                            Opacity = Settings.Default.Opacity;
                        }

                        this.panel1.BackColor = Settings.Default.ThemeBackColor;

                    }
                    timer2.Start();
                }
            }
        }

        private void UpdateText(object sender, KeyEventArgs e)
        {
            if (Settings.Default.IsOnSettings == false)
            {
                if (typeofmonitor == "Keyboard")
                {
                    Show();

                    var TextList = e.KeyData.ToString();
                    TextList = TextList.Replace("	", "");
                    TextList = TextList.Replace(" ", "");
                    var NewList = TextList.Split(',');
                    List<string> ListStuff = new List<string>(NewList);
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
                    if (ListStuff.IndexOf("LWin") != -1)
                    {
                        ListStuff.RemoveAt(ListStuff.IndexOf("LWin"));
                        ListStuff.Insert(0, "Win");
                    };
                    ListStuff.ForEach(x =>
                    {
                        if (x.Length == 1) x = x.ToUpper();
                    });
                    var joined = String.Join("+", ListStuff);
                    if (ListStuff.IndexOf(monitorkey) != -1 || joined == monitorkey)
                    {

                        CurrentlyPressed = true;
                        if (Opacity != Settings.Default.Opacity)
                        {
                            timer1.Stop();
                            Opacity = Settings.Default.Opacity;
                        }

                        this.panel1.BackColor = Settings.Default.ThemeHighlightColor;

                    }
                }
            }
        }

        private void StopKey(object sender, KeyEventArgs e)
        {
            if (Settings.Default.IsOnSettings == false)
            {
                if (typeofmonitor == "Keyboard")
                {
                    Show();

                    var TextList = e.KeyData.ToString();
                    TextList = TextList.Replace("	", "");
                    TextList = TextList.Replace(" ", "");
                    var NewList = TextList.Split(',');
                    List<string> ListStuff = new List<string>(NewList);
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
                    if (ListStuff.IndexOf("LWin") != -1)
                    {
                        ListStuff.RemoveAt(ListStuff.IndexOf("LWin"));
                        ListStuff.Insert(0, "Win");
                    };
                    ListStuff.ForEach(x =>
                    {
                        if (x.Length == 1) x = x.ToUpper();
                    });
                    var joined = String.Join("+", ListStuff);
                    if (ListStuff.IndexOf(monitorkey) != -1 || joined == monitorkey)
                    {
                        CurrentlyPressed = false;
                        this.panel1.BackColor = Settings.Default.ThemeBackColor;
                        if (Opacity != Settings.Default.Opacity)
                        {
                            timer1.Stop();
                            Opacity = Settings.Default.Opacity;
                        }
                    }
                    timer2.Start();
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


        private void Form3_MouseDown(object sender, MouseEventArgs e)
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
            if (Opacity <= 0D)
            {
                Opacity = 0D;
                Hide();
                timer1.Stop();
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            if (Settings.Default.Autohide == true)
                timer1.Start();
        }

        private void KeyboardDisplay_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Opacity = 0.65;
            Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}