using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Dextroamphetamine
{
    public partial class Form1 : Form
    {
        private static Random random = new Random();
        private static int screenW = Screen.PrimaryScreen.Bounds.Width;
        private static int screenH = Screen.PrimaryScreen.Bounds.Height;
        private static int ballWidth = 401;
        private static int ballHeight = 174;
        private static int ballPosX = random.Next(screenW - ballWidth);
        private static int ballPosY = random.Next(screenH - ballHeight);
        private static int moveStepX = 4;
        private static int moveStepY = 4;
        public Form1()
        {
            InitializeComponent();
            ballPosX = random.Next(screenW - ballWidth);
            ballPosY = random.Next(screenH - ballHeight);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private double ti;

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            int width = this.Width;
            int height = this.Height;
            int[] pixelArray = new int[width * height];
            for (int tt = 0; tt < pixelArray.Length; tt++)
            {
                ti += 1;
                int t = (int)ti;
                pixelArray[tt] = (int)(
                    ((t & t / 1 & t / 2) * t / 10E2) % 2
                    );
            }

            Bitmap bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);

            BitmapData bmpData = bmp.LockBits(
                                new Rectangle(0, 0, bmp.Width, bmp.Height),
                                ImageLockMode.WriteOnly, bmp.PixelFormat);
            Marshal.Copy(pixelArray, 0, bmpData.Scan0, pixelArray.Length);

            bmp.UnlockBits(bmpData);
            pictureBox1.Image = bmp;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Size = new Size(300, 150);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            this.Location = new Point(ballPosX, ballPosY);
            ballPosX += moveStepX;
            if (
                ballPosX < 0 ||
                ballPosX + ballWidth > screenW
                )
            {
                moveStepX = -moveStepX;
            }

            ballPosY += moveStepY;
            if (
                ballPosY < 0 ||
                ballPosY + ballHeight > screenH
                )
            {
                moveStepY = -moveStepY;
            }
        }
    }
}