using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SplashScreenAssignment
{
    public partial class Form1 : Form
    {
        FirebaseClient firebaseClient = new FirebaseClient(FireBaseConf.url);
        public Form1()
        {
            InitializeComponent();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetDatafromFB();

           // if (label1=textBox1.Text && label2=textBox2.Text)
            {
             
                MessageBox.Show("Login Successfuly");
            
            }
           // else
            //{
              //  MessageBox.Show("Invalid Info");
            //}
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void CheckPassAccUser(string key)
        {
           
            try
            {
                button1.Text = "Loading...";
               
                var obj = await firebaseClient.Child("userdeatails").Child(key).OnceSingleAsync<RegObj>();
                if(obj.Email == textBox1.Text)
                {
                    if(obj.Password == textBox2.Text)
                    {
                        button1.Text = "Login";
                        MessageBox.Show("Login Successfully");
                    }
                    else
                    {
                        button1.Text = "Login";
                        textBox2.ForeColor = Color.Red;
                        MessageBox.Show("Invalid Password");
                    }
                }
                   
              
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private async void GetDatafromFB()
        {



            try {
                
                var obj = await firebaseClient.Child("userdeatails").OnceAsync<RegObj>();
                if(textBox1.Text != string.Empty && textBox2.Text != string.Empty)
                {
                    foreach (var data in obj)
                    {
                        if(textBox1.Text == data.Object.Email)
                        {
                            CheckPassAccUser(data.Key);
                            break;
                        }
                        
                       
                    }
                }
                else
                {
                    MessageBox.Show("All Fields Reuired");
                }
                
               
            }catch(Exception ex)
            {
                Console.Write(ex);
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Text= textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.Black;
        }
    }
}
