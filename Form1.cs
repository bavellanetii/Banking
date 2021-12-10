using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Banking.Properties;
using System.Data.SqlClient;

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
        private Rectangle buttonArrow1OriginalRectangle;
        private Rectangle buttonArrow2OriginalRectangle;
        private Rectangle buttonArrow3OriginalRectangle;

        public static Form1 instance;

        string userName;
        string userPin;
        string userBalance;

        private Rectangle originalFormSize;
       
        public Form1()
        {
            InitializeComponent();
            
            //saves instance to be accessed by another form
            instance = this;
        }

        SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bavel\source\repos\Banking\Database1.mdf;Integrated Security=True");

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
            buttonYOriginalRectangle = new Rectangle(buttonClear.Location.X, buttonClear.Location.Y, buttonClear.Width, buttonClear.Height);
            button0OriginalRectangle = new Rectangle(button0.Location.X, button0.Location.Y, button0.Width, button0.Height);
            buttonNOriginalRectangle = new Rectangle(buttonEnt.Location.X, buttonEnt.Location.Y, buttonEnt.Width, buttonEnt.Height);
            buttonArrow1OriginalRectangle = new Rectangle(buttonArrow1.Location.X, buttonArrow1.Location.Y, buttonArrow1.Width, buttonArrow1.Height);
            buttonArrow2OriginalRectangle = new Rectangle(buttonArrow2.Location.X, buttonArrow2.Location.Y, buttonArrow2.Width, buttonArrow2.Height);
            buttonArrow3OriginalRectangle = new Rectangle(buttonArrow3.Location.X, buttonArrow3.Location.Y, buttonArrow3.Width, buttonArrow3.Height);
            panel1.SendToBack();
            textBoxUserData.Hide();


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
            resizeControl(buttonYOriginalRectangle, buttonClear);
            resizeControl(button0OriginalRectangle, button0);
            resizeControl(buttonNOriginalRectangle, buttonEnt);
            resizeControl(buttonArrow1OriginalRectangle, buttonArrow1);
            resizeControl(buttonArrow2OriginalRectangle, buttonArrow2);
            resizeControl(buttonArrow3OriginalRectangle, buttonArrow3);
  


        }

  
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxPin.Clear();
        }

  

        private void buttonEnt_Click(object sender, EventArgs e)
        {

            if (textBoxEnterCard.Text == "Please Enter Your Card")
            {
                textBoxEnterCard.Clear();
                textBoxEnterCard2.Clear();
                textBoxEnterCard.Text = "Please Enter Your Pin";
            }

            else if (textBoxEnterCard.Text == "Please Enter Your Pin" || textBoxEnterCard.Text == "Incorrect Pin, Please Try Again.")
            {



                sc.Open();
                SqlCommand cmd = new SqlCommand();

                string login = "SELECT * FROM username WHERE pin= '" + textBoxPin.Text + "'";
                cmd = new SqlCommand(login, sc);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read() == true)
                {


                    userName = reader["name"].ToString();
                    userPin = reader["pin"].ToString();
                    userBalance = reader["Balance"].ToString();

                    textBoxPin.Clear();
                    textBoxPin.Hide();
                    textBoxEnterCard.Clear();
                    textBoxEnterCard.Hide();
                    textBoxEnterCard2.Hide();

                    textBoxLeft1.BringToFront();
                    textBoxLeft2.BringToFront();
                    textBoxLeft1.Text = "Deposit Money";
                    textBoxLeft2.Text = "Withdraw Money";
                    textBoxLeft3.Text = "View Balance";

                    textBoxUserData.Show();
                    textBoxUserData.Text = "Welcome " + userName;
                }
                else
                {
                    textBoxEnterCard.Font = new Font("Arial", 20, FontStyle.Bold);
                    textBoxEnterCard.Text = "Incorrect Pin, Please Try Again.";
                    textBoxPin.Clear();
                }
                reader.Close();

                sc.Close();
            }



            
            
         
        }

        private void buttonKeys_Click(object sender, EventArgs e)
        {
            if ((textBoxEnterCard.Text == "Please Enter Your Pin" || textBoxEnterCard.Text == "Incorrect Pin, Please Try Again.") && textBoxPin.Text.Length < 4)
            {
                Button button = (Button)sender;
                textBoxPin.Text = textBoxPin.Text + button.Text;
            }

            if (textBoxUserData.Text == "How much would you like to withdraw?")
            {
                Button button = (Button)sender;
                textBoxPin.UseSystemPasswordChar = false;
                textBoxPin.Text = textBoxPin.Text + button.Text;
            }

        }


        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }

        private void textBoxLeft3_TextChanged(object sender, EventArgs e)
        {
 
        }

        private void buttonArrow1_Click(object sender, EventArgs e)
        {
            if (textBoxLeft3.Text == "View Balance")
            {
                textBoxLeft1.Clear();
                textBoxLeft2.Clear();
                textBoxLeft3.Clear();
              
                textBoxUserData.Text = "Your Balance is " + userBalance;
            }
        }

        private void textBoxLeft1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonArrow2_Click(object sender, EventArgs e)
        {
            if (textBoxLeft2.Text == "Withdraw Money")
            {
                textBoxLeft1.Clear();
                textBoxLeft2.Clear();
                textBoxLeft3.Clear();
                textBoxPin.Show();

                textBoxUserData.Text = "How much would you like to withdraw? (Max £99)";
            }
        }
    }
}
