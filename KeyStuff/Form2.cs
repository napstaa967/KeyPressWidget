using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using keystuff.Properties;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using Gma.System.MouseKeyHook;

namespace keystuff
{
    public partial class Form2 : Form
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
        public bool testinput;
        public Form2()
        {
            m_GlobalHook = Hook.GlobalEvents();
            Settings.Default.IsOnSettings = true;
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
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void InitializeComponent()
        {
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new Font(Settings.Default.Font.Name, 18F);
            this.button3.ForeColor = global::keystuff.Properties.Settings.Default.ThemeTextColor;
            this.button3.Location = new System.Drawing.Point(12, 728);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(191, 60);
            this.button3.TabIndex = 23;
            this.button3.Text = "Reset Settings";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new Font(Settings.Default.Font.Name, 18F);
            this.button2.ForeColor = global::keystuff.Properties.Settings.Default.ThemeTextColor;
            this.button2.Location = new System.Drawing.Point(811, 728);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(191, 60);
            this.button2.TabIndex = 7;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new Font(Settings.Default.Font.Name, 18F);
            this.button1.ForeColor = global::keystuff.Properties.Settings.Default.ThemeTextColor;
            this.button1.Location = new System.Drawing.Point(1008, 728);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 60);
            this.button1.TabIndex = 6;
            this.button1.Text = "Save Changes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = global::keystuff.Properties.Settings.Default.ThemeBackColor;
            this.textBox2.Font = new Font(Settings.Default.Font.Name, 24F);
            this.textBox2.ForeColor = global::keystuff.Properties.Settings.Default.ThemeTextColor;
            this.textBox2.Location = new System.Drawing.Point(222, 98);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(180, 50);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "300";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new Font(Settings.Default.Font.Name, 24F);
            this.label3.ForeColor = global::keystuff.Properties.Settings.Default.ThemeTextColor;
            this.label3.Location = new System.Drawing.Point(14, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 45);
            this.label3.TabIndex = 4;
            this.label3.Text = "Window Size";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new Font(Settings.Default.Font.Name, 24F);
            this.label2.ForeColor = global::keystuff.Properties.Settings.Default.ThemeTextColor;
            this.label2.Location = new System.Drawing.Point(6, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 45);
            this.label2.TabIndex = 8;
            this.label2.Text = "Font";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new Font(Settings.Default.Font.Name, 24F);
            this.label4.ForeColor = global::keystuff.Properties.Settings.Default.ThemeTextColor;
            this.label4.Location = new System.Drawing.Point(6, 315);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 45);
            this.label4.TabIndex = 9;
            this.label4.Text = "Theme";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = global::keystuff.Properties.Settings.Default.ThemeBackColor;
            this.textBox1.Font = new Font(Settings.Default.Font.Name, 24F);
            this.textBox1.ForeColor = global::keystuff.Properties.Settings.Default.ThemeTextColor;
            this.textBox1.Location = new System.Drawing.Point(214, 259);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(258, 50);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "Segoe UI";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = global::keystuff.Properties.Settings.Default.ThemeBackColor;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new Font(Settings.Default.Font.Name, 24F);
            this.comboBox1.ForeColor = global::keystuff.Properties.Settings.Default.ThemeTextColor;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "System",
            "Dark",
            "Light"});
            this.comboBox1.Location = new System.Drawing.Point(214, 315);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(368, 53);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.SelectedItem = Settings.Default.Theme;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = global::keystuff.Properties.Settings.Default.ThemeBackColor;
            this.textBox3.Font = new Font(Settings.Default.Font.Name, 24F);
            this.textBox3.ForeColor = global::keystuff.Properties.Settings.Default.ThemeTextColor;
            this.textBox3.Location = new System.Drawing.Point(478, 259);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(104, 50);
            this.textBox3.TabIndex = 12;
            this.textBox3.Text = "36";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new Font(Settings.Default.Font.Name, 24F);
            this.label5.ForeColor = global::keystuff.Properties.Settings.Default.ThemeTextColor;
            this.label5.Location = new System.Drawing.Point(289, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 45);
            this.label5.TabIndex = 13;
            this.label5.Text = "Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new Font(Settings.Default.Font.Name, 24F);
            this.label6.ForeColor = global::keystuff.Properties.Settings.Default.ThemeTextColor;
            this.label6.Location = new System.Drawing.Point(493, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 45);
            this.label6.TabIndex = 14;
            this.label6.Text = "Size";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = global::keystuff.Properties.Settings.Default.ThemeBackColor;
            this.textBox4.Font = new Font(Settings.Default.Font.Name, 24F);
            this.textBox4.ForeColor = global::keystuff.Properties.Settings.Default.ThemeTextColor;
            this.textBox4.Location = new System.Drawing.Point(408, 98);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(180, 50);
            this.textBox4.TabIndex = 15;
            this.textBox4.Text = "300";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new Font(Settings.Default.Font.Name, 24F);
            this.label7.ForeColor = global::keystuff.Properties.Settings.Default.ThemeTextColor;
            this.label7.Location = new System.Drawing.Point(257, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 45);
            this.label7.TabIndex = 16;
            this.label7.Text = "Width";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new Font(Settings.Default.Font.Name, 24F);
            this.label8.ForeColor = global::keystuff.Properties.Settings.Default.ThemeTextColor;
            this.label8.Location = new System.Drawing.Point(437, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 45);
            this.label8.TabIndex = 17;
            this.label8.Text = "Height";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new Font(Settings.Default.Font.Name, 24F);
            this.label9.ForeColor = global::keystuff.Properties.Settings.Default.ThemeTextColor;
            this.label9.Location = new System.Drawing.Point(6, 376);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 45);
            this.label9.TabIndex = 18;
            this.label9.Text = "Opacity";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(291, 379);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(294, 45);
            this.trackBar1.TabIndex = 22;
            this.trackBar1.Value = Int32.Parse((Settings.Default.Opacity * 100).ToString());
            this.trackBar1.ValueChanged += TrackBar1_ValueChanged;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = global::keystuff.Properties.Settings.Default.ThemeBackColor;
            this.textBox5.Font = new Font(Settings.Default.Font.Name, 24F);
            this.textBox5.ForeColor = global::keystuff.Properties.Settings.Default.ThemeTextColor;
            this.textBox5.Location = new System.Drawing.Point(214, 376);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(71, 50);
            this.textBox5.TabIndex = 21;
            this.textBox5.Text = Settings.Default.Opacity.ToString();
            this.textBox5.TextChanged += textBox5_TextChanged;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new Font(Settings.Default.Font.Name, 24F);
            this.label10.ForeColor = global::keystuff.Properties.Settings.Default.ThemeTextColor;
            this.label10.Location = new System.Drawing.Point(618, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(204, 45);
            this.label10.TabIndex = 24;
            this.label10.Text = "Custom Keys";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // textBox6
            // 
            this.textBox6.BackColor = global::keystuff.Properties.Settings.Default.ThemeBackColor;
            this.textBox6.Font = new Font(Settings.Default.Font.Name, 24F);
            this.textBox6.ForeColor = global::keystuff.Properties.Settings.Default.ThemeTextColor;
            this.textBox6.Location = new System.Drawing.Point(1008, 212);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(180, 50);
            this.textBox6.TabIndex = 25;
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new Font(Settings.Default.Font.Name, 18F);
            this.button4.ForeColor = global::keystuff.Properties.Settings.Default.ThemeTextColor;
            this.button4.Location = new System.Drawing.Point(648, 277);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(174, 60);
            this.button4.TabIndex = 26;
            this.button4.Text = "Remove";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new Font(Settings.Default.Font.Name, 18F);
            this.button5.ForeColor = global::keystuff.Properties.Settings.Default.ThemeTextColor;
            this.button5.Location = new System.Drawing.Point(648, 211);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(174, 60);
            this.button5.TabIndex = 27;
            this.button5.Text = "Add";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = global::keystuff.Properties.Settings.Default.ThemeBackColor;
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox2.Font = new Font(Settings.Default.Font.Name, 24F);
            this.comboBox2.ForeColor = global::keystuff.Properties.Settings.Default.ThemeTextColor;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(828, 278);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(188, 53);
            if (Settings.Default.PerKeyMonitors == null)
            {
                Settings.Default.PerKeyMonitors = new List<string> {  };
            };
            List<string> listthing = new List<string>() { };
            Settings.Default.PerKeyMonitors.ForEach(x =>
            {
                listthing.Add(x.Split('|')[0]);
            });
            this.comboBox2.Items.AddRange(listthing.Cast<object>().ToArray());
            this.comboBox2.TabIndex = 28;
            this.comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = global::keystuff.Properties.Settings.Default.ThemeBackColor;
            this.textBox7.Font = new Font(Settings.Default.Font.Name, 24F);
            this.textBox7.ForeColor = global::keystuff.Properties.Settings.Default.ThemeTextColor;
            this.textBox7.Location = new System.Drawing.Point(822, 98);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(180, 50);
            this.textBox7.TabIndex = 29;
            this.textBox7.Text = "150";
            // 
            // textBox8
            // 
            this.textBox8.BackColor = global::keystuff.Properties.Settings.Default.ThemeBackColor;
            this.textBox8.Font = new Font(Settings.Default.Font.Name, 24F);
            this.textBox8.ForeColor = global::keystuff.Properties.Settings.Default.ThemeTextColor;
            this.textBox8.Location = new System.Drawing.Point(1008, 98);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(180, 50);
            this.textBox8.TabIndex = 30;
            this.textBox8.Text = "150";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new Font(Settings.Default.Font.Name, 24F);
            this.label11.ForeColor = global::keystuff.Properties.Settings.Default.ThemeTextColor;
            this.label11.Location = new System.Drawing.Point(618, 101);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(198, 45);
            this.label11.TabIndex = 31;
            this.label11.Text = "SnglKey Size";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new Font(Settings.Default.Font.Name, 24F);
            this.label12.ForeColor = global::keystuff.Properties.Settings.Default.ThemeTextColor;
            this.label12.Location = new System.Drawing.Point(14, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(217, 45);
            this.label12.TabIndex = 32;
            this.label12.Text = "Main Window";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new Font(Settings.Default.Font.Name, 24F);
            this.label13.ForeColor = global::keystuff.Properties.Settings.Default.ThemeTextColor;
            this.label13.Location = new System.Drawing.Point(820, 164);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(208, 45);
            this.label13.TabIndex = 34;
            this.label13.Text = "Press To Bind";
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new Font(Settings.Default.Font.Name, 18F);
            this.button6.ForeColor = global::keystuff.Properties.Settings.Default.ThemeTextColor;
            this.button6.Location = new System.Drawing.Point(828, 212);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(174, 60);
            this.button6.TabIndex = 35;
            this.button6.Text = "Set";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += Button6_Click;
            // 
            // Form2
            // 
            this.BackColor = global::keystuff.Properties.Settings.Default.ThemeBackColor;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.Opacity = global::keystuff.Properties.Settings.Default.Opacity;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.FormClosing += exitform;
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != null && textBox8.Text != null)
            {
                int countingstuff = 0;
                List<string> list = Settings.Default.PerKeyMonitors.ToList();
                list.ForEach(x =>
                {
                    var z = x.Split('|');
                    if (z[0] == comboBox2.SelectedItem.ToString())
                    {
                        Settings.Default.PerKeyMonitors.Add(z[0] + '|' + textBox7.Text + '|' + textBox8.Text);

                    }
                });
            }
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.PerKeyMonitors.ForEach(x =>
            {
                var y = x.Split('|');
                if (y[0] == comboBox2.SelectedItem.ToString())
                {
                    this.textBox7.Text = y[1];
                    this.textBox8.Text = y[2];
                }
            });
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Settings.Default.Reset();
            Settings.Default.Save();
        }
        private bool textchanging = false;
        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (textchanging == false)
            {
                this.textBox5.Text = this.trackBar1.Value.ToString();
            }
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textchanging = true;
            this.trackBar1.ValueChanged -= TrackBar1_ValueChanged;
            this.trackBar1.Value = Int32.Parse(this.textBox5.Text);
            textchanging = false;
            this.trackBar1.ValueChanged += TrackBar1_ValueChanged;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Settings.Default.IsOnSettings = false;
            Settings.Default.Save();
            this.Close();
            Form1.RestartApp();
        }

        private void exitform(object sender, EventArgs e)
        {
            Settings.Default.IsOnSettings = false;
            Settings.Default.Save();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text != null)
            {
                Settings.Default.WindowSize = new Size(Int32.Parse(textBox2.Text), Int32.Parse(textBox4.Text));
            }
            if (textBox3 != null && textBox1 != null)
            {
                Settings.Default.Font = new Font(textBox1.Text, float.Parse(textBox3.Text));
            }
            if (comboBox1.SelectedIndex != -1)
            {
                Settings.Default.Theme = comboBox1.SelectedItem.ToString();
                if (comboBox1.SelectedItem.ToString() == "System")
                {
                    Settings.Default.Theme = "System";
                    if (regsys == 1)
                    {
                        Settings.Default.ThemeTextColor = Color.Black;
                        Settings.Default.ThemeBackColor = Color.White;
                        Settings.Default.ThemeHighlightColor = Color.FromArgb(220, 220, 220);
                        Settings.Default.Save();
                    }
                    if (regsys == 0)
                    {
                        Settings.Default.ThemeTextColor = Color.White;
                        Settings.Default.ThemeBackColor = Color.Black;
                        Settings.Default.ThemeHighlightColor = Color.FromArgb(60, 60, 60);
                        Settings.Default.Save();
                    }
                }
                if (comboBox1.SelectedItem.ToString() == "Light")
                {
                    Settings.Default.Theme = "Light";
                    Settings.Default.ThemeTextColor = Color.Black;
                    Settings.Default.ThemeBackColor = Color.White;
                    Settings.Default.ThemeHighlightColor = Color.FromArgb(220, 220, 220);
                    Settings.Default.Save();
                }
                else if (comboBox1.SelectedItem.ToString() == "Dark")
                {
                    Settings.Default.Theme = "Dark";
                    Settings.Default.ThemeTextColor = Color.White;
                    Settings.Default.ThemeBackColor = Color.Black;
                    Settings.Default.ThemeHighlightColor = Color.FromArgb(60, 60, 60);
                    Settings.Default.Save();
                }
            }
            if (textBox7.Text != null && textBox8.Text != null)
            {
                Settings.Default.KeyMonitorWindowSize = new Size(Int32.Parse(textBox7.Text), Int32.Parse(textBox8.Text));
            }
            Settings.Default.Save();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Form2_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1 && Settings.Default.PerKeyMonitors != null)
            {
                Settings.Default.PerKeyMonitors.RemoveAt(comboBox2.SelectedIndex);
                comboBox2.Items.Clear();
                Settings.Default.Save();
                List<string> listthing = new List<string>() { };
                Settings.Default.PerKeyMonitors.ForEach(x =>
                {
                    listthing.Add(x.Split('|')[0]);
                });
                comboBox2.Items.AddRange(listthing.Cast<object>().ToArray());
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == null)
            {
                return;
            }
            else if (textBox6.Text.Length == 1)
            {
                if (Settings.Default.PerKeyMonitors == null)
                {
                    if (textBox7.Text == null)
                    {
                        return;
                    }
                    Settings.Default.PerKeyMonitors = new List<string>()
                    {
                        textBox6.Text.ToUpper() + '|' + textBox7.Text + '|' + textBox8.Text
                    };
                    Settings.Default.Save();
                }
                else
                {
                    Settings.Default.PerKeyMonitors.Add(textBox6.Text.ToUpper() + '|' + textBox7.Text + '|' + textBox8.Text);
                    Settings.Default.Save();
                }
                
            }
            else
            {
                if (Settings.Default.PerKeyMonitors == null)
                {
                    Settings.Default.PerKeyMonitors = new List<string>()
                    {
                        textBox6.Text + '|' + textBox7.Text + '|' + textBox8.Text
                    };
                    Settings.Default.Save();
                }
                else
                {
                    Settings.Default.PerKeyMonitors.Add(textBox6.Text + '|' + textBox7.Text + '|' + textBox8.Text);
                }
                Settings.Default.Save();
            }
            comboBox2.Items.Clear();
            Settings.Default.Save();
            List<string> listthing = new List<string>() { };
            Settings.Default.PerKeyMonitors.ForEach(x =>
            {
                listthing.Add(x.Split('|')[0]);
            });
            this.comboBox2.Items.AddRange(listthing.Cast<object>().ToArray());

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}