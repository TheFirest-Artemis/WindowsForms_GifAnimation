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
        Image fan;
        public Form1()
        {
            InitializeComponent();
            LoadImages();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            ImageAnimator.UpdateFrames(fan);

            e.Graphics.DrawImage(fan, new Point(50, 50));

            //this.Invalidate();
        }

        private void LoadImages()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint, true);

            fan = Properties.Resources.Fan;

            ImageAnimator.Animate(fan, onFrameChangedHandler);
        }

        void onFrameChangedHandler(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
