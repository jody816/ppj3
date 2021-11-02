using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ppj3
{
    public partial class nowMovie : Form
    {
        public nowMovie()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Movie movie = DataManager.Movies.Single((x) => x.Room == '1'.ToString());
                label1.Text = movie.Title;
                label3.Text = movie.Genre;
                label5.Text = movie.Screeningtime;
                textBox1.Text = movie.Content;
            }catch(Exception ex) { }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Movie movie = DataManager.Movies.Single((x) => x.Room == '2'.ToString());
                label1.Text = movie.Title;
                label3.Text = movie.Genre;
                label5.Text = movie.Screeningtime;
                textBox1.Text = movie.Content;
            }
            catch(Exception ex) { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Movie movie = DataManager.Movies.Single((x) => x.Room == '3'.ToString());
                label1.Text = movie.Title;
                label3.Text = movie.Genre;
                label5.Text = movie.Screeningtime;
                textBox1.Text = movie.Content;
            }
            catch (Exception ex) { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Movie movie = DataManager.Movies.Single((x) => x.Room == '4'.ToString());
                label1.Text = movie.Title;
                label3.Text = movie.Genre;
                label5.Text = movie.Screeningtime;
                textBox1.Text = movie.Content;
            }
            catch (Exception ex) { }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new ReservePage().Show();
        }
    }
}
