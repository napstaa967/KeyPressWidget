using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;
using keystuff.Properties;
using System.Drawing;

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
            this.label1.Text = thekey;
            this.monitorkey = thekey;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.contextMenu1 = new ContextMenu();
            this.alwaysOnTop = new MenuItem();
            this.wordBuild = new MenuItem();
            this.autoHide = new MenuItem();
            this.settingStuff = new MenuItem();
            this.exit = new MenuItem();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.panel1.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.panel1.Width, this.panel1.Height, 20, 20));
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.KeyDown += UpdateText;
            m_GlobalHook.KeyUp += StopKey;
            timer2.Start();
            
        }

        private void UpdateText(object sender, KeyEventArgs e)
        {
            
            Show();
            
            if (e.KeyData.ToString() == monitorkey)
            {
                Console.WriteLine("shit");
                CurrentlyPressed = true;
                if (Opacity != Settings.Default.Opacity)
                {
                    timer1.Stop();
                    Opacity = Settings.Default.Opacity;
                }
                Console.WriteLine(panel1.BackColor);
                this.panel1.BackColor = Settings.Default.ThemeHighlightColor;
                Console.WriteLine(panel1.BackColor);
            }
        }

        private void StopKey(object sender, KeyEventArgs e)
        {
            Show();
            
            if (e.KeyData.ToString() == monitorkey)
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