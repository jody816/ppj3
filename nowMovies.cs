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
    public partial class nowMovies : Form
    {
        Button[] btn = new Button[DataManager.Movies.Count];
        static int margin = 10;
        static int btnWidth =150;
        static int btnHeight = 150;
        public nowMovies()
        {
            InitializeComponent();

            this.Width = 2 * margin + 4 * btnWidth + 2 * 3 + 2 * 4; // 3: btn 사이의 간격, 4는 form의 boundary 두께
            this.Height = 2 * margin + 3 * btnWidth + 2 * 2 + 2 * 4 + 24;

            for (int i = 0; i < btn.Length; i++)
            {
                btn[i] = new Button();
                btn[i].Text = i.ToString();
                btn[i].Size = new Size(btnWidth, btnHeight);
                btn[i].Location = new Point(margin + i % 4 * btn[i].Width, margin + i / 4 * btn[i].Height);
                btn[i].BackgroundImage = Image.FromFile("..\\..\\Resources\\" + i + ".jpg");
                btn[i].BackgroundImageLayout = ImageLayout.Stretch;
                btn[i].Click += nowMovies_Click;

                Controls.Add(btn[i]);
            }
        }
        private void nowMovies_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            for (int i = 0; i < DataManager.Movies.Count; i++)
            {
                if (btn.Text == i.ToString())
                {
                    Movie movie = DataManager.Movies.Single((x) => x.Room == (i+1).ToString());
                    label1.Text = movie.Title;
                    label3.Text = movie.Genre;
                    label5.Text = movie.Screeningtime;
                    textBox1.Text = movie.Content;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new ReservePage().Show();
        }
    }
}
