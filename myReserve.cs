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
    public partial class myReserve : Form
    {
        public myReserve()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DataManager.Reservations.Exists(x => x.Password == textBox7.Text))
            {
                Reservation reservation = DataManager.Reservations.Single((x) => x.Password == textBox7.Text);
                Movie movie = DataManager.Movies.Single((y) => y.Title == reservation.rTitle);

                label2.Text = reservation.rTitle;
                label4.Text = (reservation.rRoom + "관");
                label6.Text = (reservation.rSt + " | " + movie.Genre + " | " + movie.Grade);
                label8.Text = reservation.Seat;
                label10.Text = reservation.Price.ToString();
                textBox1.Text = reservation.Name;
                textBox2.Text = reservation.PhoneNum;
                textBox3.Text = reservation.Password;
                label15.Text = reservation.WhenReserve.ToString();

                textBox4.Text = reservation.Name;
                textBox5.Text = reservation.PhoneNum;
                textBox6.Text = reservation.Password;
            }else if(textBox7.Text == "")
            {
                MessageBox.Show("비밀번호를 입력해주세요!");
            }
            else
            {
                MessageBox.Show("없는 비밀번호입니다!");
            }
        } // 예매 조회

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(!(DataManager.Reservations.Exists(x => x.Password == textBox6.Text)))
                {
                    Reservation reservation = DataManager.Reservations.Single(x => x.Password == textBox7.Text);
                    reservation.Name = textBox4.Text;
                    reservation.PhoneNum = textBox5.Text;
                    reservation.Password = textBox6.Text;

                    DataManager.Save();
                }else
                {
                    MessageBox.Show("해당 비밀번호로 수정 불가능합니다!");
                }

                //Reservation reservation = DataManager.Reservations.Single(x => x.Password == textBox7.Text);
                //reservation.Name = textBox4.Text;
                //reservation.PhoneNum = textBox5.Text;
                //reservation.Password = textBox6.Text;

                //DataManager.Save();
            }catch(Exception ex) { }
        } // 수정

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Reservation reservation = DataManager.Reservations.Single(x => x.Password == textBox6.Text);
                DataManager.Reservations.Remove(reservation);

                DataManager.Save();
            }catch(Exception ex) { }
        } // 예매 취소(삭제)
    }
}
