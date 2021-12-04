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
        private Rectangle button1OriginalRectangle;
        private Rectangle button2OriginalRectangle;
        private Rectangle button3OriginalRectangle;
        private Rectangle button4OriginalRectangle;
        private Rectangle button5OriginalRectangle;
        private Rectangle button6OriginalRectangle;
        private Rectangle button7OriginalRectangle;
        private Rectangle button8OriginalRectangle;
        private Rectangle button9OriginalRectangle;
        private Rectangle buttonYOriginalRectangle;
        private Rectangle button0OriginalRectangle;
        private Rectangle buttonNOriginalRectangle;
        private Rectangle originalFormSize;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //This gets the size and location of the original buttons and form
            originalFormSize = new Rectangle(this.Location, this.Size);
            button1OriginalRectangle = new Rectangle(button1.Location.X, button1.Location.Y, button1.Width, button1.Height);
            button2OriginalRectangle = new Rectangle(button2.Location.X, button2.Location.Y, button2.Width, button2.Height);
            button3OriginalRectangle = new Rectangle(button3.Location.X, button3.Location.Y, button3.Width, button3.Height);
            button4OriginalRectangle = new Rectangle(button4.Location.X, button4.Location.Y, button4.Width, button4.Height);
            button5OriginalRectangle = new Rectangle(button5.Location.X, button5.Location.Y, button5.Width, button5.Height);
            button6OriginalRectangle = new Rectangle(button6.Location.X, button6.Location.Y, button6.Width, button6.Height);
            button7OriginalRectangle = new Rectangle(button7.Location.X, button7.Location.Y, button7.Width, button7.Height);
            button8OriginalRectangle = new Rectangle(button8.Location.X, button8.Location.Y, button8.Width, button8.Height);
            button9OriginalRectangle = new Rectangle(button9.Location.X, button9.Location.Y, button9.Width, button9.Height);
            buttonYOriginalRectangle = new Rectangle(buttonY.Location.X, buttonY.Location.Y, buttonY.Width, buttonY.Height);
            button0OriginalRectangle = new Rectangle(button0.Location.X, button0.Location.Y, button0.Width, button0.Height);
            buttonNOriginalRectangle = new Rectangle(buttonN.Location.X, buttonN.Location.Y, buttonN.Width, buttonN.Height);
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
            resizeControl(button1OriginalRectangle, button1);
            resizeControl(button2OriginalRectangle, button2);
            resizeControl(button3OriginalRectangle, button3);
            resizeControl(button4OriginalRectangle, button4);
            resizeControl(button5OriginalRectangle, button5);
            resizeControl(button6OriginalRectangle, button6);
            resizeControl(button7OriginalRectangle, button7);
            resizeControl(button8OriginalRectangle, button8);
            resizeControl(button9OriginalRectangle, button9);
            resizeControl(buttonYOriginalRectangle, buttonY);
            resizeControl(button0OriginalRectangle, button0);
            resizeControl(buttonNOriginalRectangle, buttonN);
         }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
