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
    public partial class ReservePage : Form
    {
        public ReservePage()
        {
            InitializeComponent();

            checkBoxes = new CheckBox[] { checkBox1, checkBox2, checkBox3, checkBox4,
                checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10, checkBox11, checkBox12 };

            foreach (var checkBox in checkBoxes)
            {
                checkBox.CheckedChanged += new EventHandler(ShowCheckedCheckboxes);
            }
            //DataManager.Reservations.Single(x => x.rTitle == ())
            //checkBox1.Enabled = false;
            //if (DataManager.Reservations.Exists(x => x.rTitle == comboBox1.SelectedIndex.ToString()))
            //{
            //    MessageBox.Show("ss");
            //    Reservation reservation = DataManager.Reservations.Single(x => x.rRoom == "1");
            //    if (reservation.Seat == "A1")
            //    {
            //        checkBox1.Enabled = false;
            //    }
            //}

            //Reservation reservation = DataManager.Reservations.Single(x => x.rRoom == "1");
            //MessageBox.Show(reservation.Seat);
            //if(reservation.Seat == "A1")
            //{
            //    checkBox1.Enabled = false;
            //}
        }

        void ShowCheckedCheckboxes(object sender, EventArgs e)
        {
            string message = string.Empty;
            int sum = 0;

            for (int i = 0; i < checkBoxes.Length; i++)
            {
                if (checkBoxes[i].Checked && checkBoxes[i].Enabled)
                {
                    message += (string.Format(checkBoxes[i].Text) + ' ' + ' ');
                    sum = (message.Count()/4) * 10000;
                    textBox5.Text = sum.ToString();
                    textBox1.Text = message;
                    if(message == null)
                    { textBox1.Clear(); }
                }
            }
            MessageBox.Show(message);
        }
        CheckBox[] checkBoxes;

        private void ReservePage_Load(object sender, EventArgs e)
        {
            try
            {
                for(int i = 1; i<=DataManager.Movies.Count; i++)
                {
                    Movie movie = DataManager.Movies.Single((x) => x.Room == i.ToString());
                    comboBox1.Items.Add(movie.Title);

                    //DataManager.Reservations.Single(x => x.rTitle == comboBox1.Items.Add(movie.Title).ToString());

                }
            }catch(Exception ex) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                listBox1.Items.Add(comboBox1.SelectedItem); //제목
                listBox1.Items.Add(textBox1.Text.ToString()); // 좌석
                listBox1.Items.Add(textBox5.Text); // 가격
                listBox1.Items.Add(textBox2.Text); // 이름
                listBox1.Items.Add(textBox3.Text); // 전화번호
                listBox1.Items.Add(textBox4.Text); // 비밀번호
            }catch(Exception ex) { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Movie movie = DataManager.Movies.Single(x => x.Title == listBox1.Items[0].ToString());
                //string a = movie.Room;
                //string b = movie.Screeningtime;
                if (!(DataManager.Reservations.Exists(x => x.Password == listBox1.Items[5].ToString())))
                {
                    Reservation reservation = new Reservation()
                    {
                        rTitle = listBox1.Items[0].ToString(),
                        rRoom = movie.Room,
                        rSt = movie.Screeningtime,
                        Seat = listBox1.Items[1].ToString(),
                        Price = Convert.ToInt32(listBox1.Items[2]),
                        Name = listBox1.Items[3].ToString(),
                        PhoneNum = listBox1.Items[4].ToString(),
                        WhenReserve = DateTime.Now,
                        Password = listBox1.Items[5].ToString()
                    };
                    DataManager.Reservations.Add(reservation);
                    DataManager.Save();
                    MessageBox.Show("예매되었습니다.");
                    Application.OpenForms["ReservePage"].Close();
                    Application.OpenForms["nowMovie"].Close();
                }
                else
                {
                    MessageBox.Show("다른 비밀번호를 입력해주세요!");
                }
            }
            catch(Exception ex) { }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "어벤져스 : 엔드게임" && DataManager.Reservations.Exists(x => x.rTitle == "어벤져스 : 엔드게임"))
            {            
                Reservation reservation = DataManager.Reservations.Single(x => x.rTitle == "어벤져스 : 엔드게임");
                for (int i = 1; i <= 12; i++)
                {
                    if (reservation.Seat.Contains("A" + i)) { checkBoxes[i].Enabled = false; }
                    if (reservation.Seat.Contains("B" + i)) { checkBoxes[i+4].Enabled = false; }
                    if (reservation.Seat.Contains("C" + i)) { checkBoxes[i+8].Enabled = false; }
                }
            }
            if (comboBox1.SelectedItem.ToString() == "어바웃 타임" && DataManager.Reservations.Exists(x => x.rTitle == "어바웃 타임"))
            {
                Reservation reservation = DataManager.Reservations.Single(x => x.rTitle == "어바웃 타임");
                for (int i = 1; i <= 12; i++)
                {
                    if (reservation.Seat.Contains("A" + i)) { checkBoxes[i].Enabled = false; }
                    if (reservation.Seat.Contains("B" + i)) { checkBoxes[i + 4].Enabled = false; }
                    if (reservation.Seat.Contains("C" + i)) { checkBoxes[i + 8].Enabled = false; }
                }
            }
            if (comboBox1.SelectedItem.ToString() == "위 아 더 밀러스" && DataManager.Reservations.Exists(x => x.rTitle == "위 아 더 밀러스"))
            {
                Reservation reservation = DataManager.Reservations.Single(x => x.rTitle == "위 아 더 밀러스");
                for (int i = 1; i <= 12; i++)
                {
                    if (reservation.Seat.Contains("A" + i)) { checkBoxes[i].Enabled = false; }
                    if (reservation.Seat.Contains("B" + i)) { checkBoxes[i + 4].Enabled = false; }
                    if (reservation.Seat.Contains("C" + i)) { checkBoxes[i + 8].Enabled = false; }
                }
            }
            if (comboBox1.SelectedItem.ToString() == "너의 결혼식" && DataManager.Reservations.Exists(x => x.rTitle == "너의 결혼식"))
            {
                Reservation reservation = DataManager.Reservations.Single(x => x.rTitle == "너의 결혼식");
                for (int i = 1; i <= 12; i++)
                {
                    if (reservation.Seat.Contains("A" + i)) { checkBoxes[i].Enabled = false; }
                    if (reservation.Seat.Contains("B" + i)) { checkBoxes[i + 4].Enabled = false; }
                    if (reservation.Seat.Contains("C" + i)) { checkBoxes[i + 8].Enabled = false; }
                }
            }
            DataManager.Reservations.Select(x => x.rRoom == '1'.ToString());
        }
    }
}
