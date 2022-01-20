using keystuff.Properties;
using Microsoft.Win32;
using RegistryUtils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace keystuff
{
    partial class Form3
    {
        public string ThemeSet = Settings.Default.Theme;
        public Color ThemeTextColor;
        public Color ThemeBackColor;
        int regsys = (int)Registry.GetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize",
            "AppsUseLightTheme",
            0);
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 
        public RegistryMonitor monitor;
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(panel1.Width, panel1.Height);
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = global::keystuff.Properties.Settings.Default.Font;
            this.label1.ForeColor = global::keystuff.Properties.Settings.Default.ThemeTextColor;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.TabIndex = 2;
            this.label1.Text = "[Idle]";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form3_MouseDown);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = global::keystuff.Properties.Settings.Default.Font;
            this.panel1.ForeColor = global::keystuff.Properties.Settings.Default.ThemeTextColor;
            this.panel1.Location = new System.Drawing.Point(20, 20);
            this.panel1.Name = "panel1";
            this.panel1.TabIndex = 1;
            // 
            // Form3
            // 
            this.Size = Settings.Default.KeyMonitorWindowSize;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::keystuff.Properties.Settings.Default.ThemeBackColor;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.panel1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("TopMost", global::keystuff.Properties.Settings.Default, "isAlwaysOnTop", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = global::keystuff.Properties.Settings.Default.Location;
            this.Name = "Form3";
            this.Opacity = global::keystuff.Properties.Settings.Default.Opacity;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form3";
            this.TopMost = global::keystuff.Properties.Settings.Default.isAlwaysOnTop;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.panel1.Size = new System.Drawing.Size(this.Width - 40, this.Height - 40);
            this.label1.Size = this.panel1.Size;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        public int reginit = (int)Registry.GetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize",
            "AppsUseLightTheme",
            0);
        public int reg2;
        private void RegistryChanged(object sender, EventArgs e)
        {
            reg2 = (int)Registry.GetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize",
            "AppsUseLightTheme",
            0);
            if (reginit != reg2)
            {
                if (Settings.Default.Theme == "System")
                {
                    if (reg2.ToString() == "1")
                    {
                        Settings.Default.ThemeTextColor = Color.Black;
                        Settings.Default.ThemeBackColor = Color.White;
                        Settings.Default.ThemeHighlightColor = Color.FromArgb(195, 195, 195);
                        Settings.Default.Save();
                    }
                    if (reg2.ToString() == "0")
                    {
                        Settings.Default.ThemeTextColor = Color.White;
                        Settings.Default.ThemeBackColor = Color.Black;
                        Settings.Default.ThemeHighlightColor = Color.FromArgb(60, 60, 60);
                        Settings.Default.Save();
                    }
                }
                if (Settings.Default.Theme == "Light")
                {
                    Settings.Default.ThemeTextColor = Color.Black;
                    Settings.Default.ThemeBackColor = Color.White;
                    Settings.Default.ThemeHighlightColor = Color.FromArgb(195, 195, 195);
                    Settings.Default.Save();
                }
                else if (Settings.Default.Theme == "Dark")
                {
                    Settings.Default.ThemeTextColor = Color.White;
                    Settings.Default.ThemeBackColor = Color.Black;
                    Settings.Default.ThemeHighlightColor = Color.FromArgb(60, 60, 60);
                    Settings.Default.Save();
                }
            }
            Form3.RestartApp();
        }


        private void Form3_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            Settings.Default.Location = this.Location;

            Settings.Default.LastKeyPress = "null";

            Settings.Default.Save();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon KeyboardDisplay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel panel1;
    }
}

