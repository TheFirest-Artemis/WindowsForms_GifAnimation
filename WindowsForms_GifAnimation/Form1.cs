using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_GifAnimation
{
    public partial class Form1 : Form
    {
        static Image fan;
        static Image newFan;

        public Form1()
        {
            InitializeComponent();
            LoadImages();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            ImageAnimator.UpdateFrames(newFan);

            e.Graphics.DrawImage(newFan, new Point(50, 50));

            //this.Invalidate();
        }

        private void LoadImages()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint, true);

            fan = Properties.Resources.Fan;

            newFan = resizeImage(fan ,new Size(100, 100));

            ImageAnimator.Animate(newFan, onFrameChangedHandler);
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        void onFrameChangedHandler(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
