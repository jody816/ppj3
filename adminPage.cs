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
    public partial class 관리자_페이지 : Form
    {
        public 관리자_페이지()
        {
            InitializeComponent();

            dataGridView1.DataSource = DataManager.Reservations;
            dataGridView1.CurrentCellChanged += dataGridView1_CurrentCellChanged;

            dataGridView2.DataSource = DataManager.Movies;
            dataGridView2.CurrentCellChanged += dataGridView2_CurrentCellChanged;

            label2.Text = DataManager.Reservations.Count.ToString();
            label4.Text = DataManager.Movies.Count.ToString();
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Reservation reservation = dataGridView1.CurrentRow.DataBoundItem as Reservation;
                textBox1.Text = reservation.Seat.ToString();
                textBox2.Text = reservation.PhoneNum;
                textBox3.Text = reservation.Password;
            }catch(Exception ex) { }
        }

        private void dataGridView2_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Movie movie = dataGridView2.CurrentRow.DataBoundItem as Movie;
                textBox4.Text = movie.Title;
                textBox5.Text = movie.Room;
                textBox6.Text = movie.Screeningtime;
                textBox7.Text = movie.Grade;
                textBox8.Text = movie.Content;
                textBox9.Text = movie.Genre;
            }
            catch (Exception ex)
            { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if(DataManager.Movies.Exists(x => x.Room == textBox5.Text))
                {
                    MessageBox.Show("해당 상영관에 예정된 영화가 이미 존재합니다.");
                }
                else
                {
                    Movie movie = new Movie()
                    {
                        Title = textBox4.Text,
                        Room = textBox5.Text,
                        Screeningtime = textBox6.Text,
                        Grade = textBox7.Text,
                        Content = textBox8.Text,
                        Genre = textBox9.Text
                    };
                    DataManager.Movies.Add(movie);
                }
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = DataManager.Movies;
                DataManager.Save();
            }
            catch(Exception ex) { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Movie movie = DataManager.Movies.Single(x => x.Title == textBox4.Text);
                movie.Room = textBox5.Text;
                movie.Screeningtime = textBox6.Text;
                movie.Grade = textBox7.Text;
                movie.Content = textBox8.Text;
                movie.Genre = textBox9.Text;

                dataGridView2.DataSource = null;
                dataGridView2.DataSource = DataManager.Movies;
                DataManager.Save();
            }catch(Exception ex) { }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Movie movie = DataManager.Movies.Single(x => x.Room == textBox5.Text);
                DataManager.Movies.Remove(movie);

                dataGridView2.DataSource = null;
                dataGridView2.DataSource = DataManager.Movies;
                DataManager.Save();
            }catch(Exception ex) { }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Reservation reservation = DataManager.Reservations.Single(x => x.PhoneNum == textBox2.Text);
                reservation.Password = textBox3.Text;

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = DataManager.Reservations;
                DataManager.Save();
            }
            catch (Exception ex) { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Reservation reservation = DataManager.Reservations.Single(x => x.Password == textBox3.Text);
                DataManager.Reservations.Remove(reservation);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = DataManager.Reservations;
                DataManager.Save();
            }catch(Exception ex) { }
        }
    }
}
