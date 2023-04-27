using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SplashScreenAssignment
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();

        }
        public void StartSplash()
        {
            Application.Run(new Form1());
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(StartSplash));
            thread.Start();
           // Thread.Sleep(5000);
           
            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //label1=label1 + textBox1.Text;
        }

        private async void datasendToFirebase()
        {
            RegObj regObj = new RegObj();
            regObj.Username = textBox1.Text;
            regObj.Password = textBox3.Text;
            regObj.Email = textBox2.Text;
            regObj.Mobileno = textBox5.Text;

            try
            {
                FirebaseClient firebaseClient = new FirebaseClient(FireBaseConf.url);
                await firebaseClient.Child("userdeatails").PostAsync(regObj);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                MessageBox.Show("Registered");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox3.Text != string.Empty && textBox4.Text != string.Empty && textBox5.Text != string.Empty )
            {

                if (textBox3.Text == textBox4.Text)
                {

                    if (textBox2.Text.Contains("@"))
                    {
                        if (textBox5.Text.Length == 10)
                        {
                            if (double.TryParse(textBox5.Text, out double result) == true)
                            {
                                datasendToFirebase();
                            }
                            else
                            {
                                textBox5.ForeColor = Color.Red;
                            }

                        }
                        else
                        {
                            textBox5.ForeColor = Color.Red;
                        }



                    }
                    else
                    {
                        textBox2.ForeColor = Color.Red;
                    }

                }
                else
                {
                    textBox4.ForeColor = Color.Red;
                }

            }
            else
            {
                MessageBox.Show("All Fields Required");
            }
           


        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.ForeColor = Color.Black;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.Black;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.ForeColor = Color.Black;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void canBtw_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
