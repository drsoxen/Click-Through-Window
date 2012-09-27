using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        private static extern int SetLayeredWindowAttributes(IntPtr hwnd, int crKey, byte bAlpha, int dwFlags);

        public Form1()
        {
            InitializeComponent();
            this.TopMost = true;
            this.Text = "";
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            this.ShowInTaskbar = false;

            //this.BackgroundImage = Properties.Resources.Error;

            this.BackColor = Color.White;
            this.TransparencyKey = this.BackColor;

            int width = 0;
            int height = 0;
            for(int i = 0; i < Screen.AllScreens.Length;i++)
            {
                width += Screen.AllScreens[i].Bounds.Width;
                height += Screen.AllScreens[i].Bounds.Width;
            }

            this.Width = width;
            this.Height = height;

            this.pictureBox1.Width = Properties.Resources.Raining.Width;
            this.pictureBox1.Height = Properties.Resources.Raining.Height;

            this.pictureBox1.Location = new Point(0, 0);

            this.pictureBox1.Image = Properties.Resources.Raining;


            SetWindowLong(this.Handle, -20, 0x80000 | 0x20);
            //SetLayeredWindowAttributes(this.Handle, 0, 255, 0x2);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();            
        }
    }
}
