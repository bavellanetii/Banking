using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banking
{
    public partial class Form1 : Form
    {
        private Rectangle buttonOriginalRectangle;
        private Rectangle originalFormSize;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //This gets the size and location of the original buttons and form
            originalFormSize = new Rectangle(this.Location, this.Size);
            buttonOriginalRectangle = new Rectangle(button1.Location.X, button1.Location.Y, button1.Width, button1.Height);
        }



        private void resizeControl(Rectangle r, Control c)
        {
            //calculates ratio x and y coords have compared to form
            float xRatio = (float)this.Width / (float)originalFormSize.Width;
            float yRatio = (float)this.Height / (float)originalFormSize.Height;

            //calculates new x and y coord
            int newX = (int)(r.Location.X * xRatio);
            int newY = (int)(r.Location.Y * yRatio);

            //calculate new height and width
            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            resizeControl(buttonOriginalRectangle, button1);
        }
    }
}
