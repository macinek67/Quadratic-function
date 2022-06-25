using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap bitmap = new Bitmap(200, 200);
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = (Image)bitmap;
            g = pictureBox1.CreateGraphics();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        int skala = 1;

        public void wypelnij()
        {
            PositionList p = new PositionList(-3, 3, (float)0.1);
            dataGridView1.DataSource = p.positions;
            float Ux = pictureBox1.Width / 2 + p.start;
            float Uy = pictureBox1.Height / 2 - p.positions.First().f;
            Pen pen1 = new Pen(brush: Brushes.Red);
            pen1.Width = 1.0f;
            g.DrawLine(pen1, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);
            g.DrawLine(pen1, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);

            for (int i = 1; i < p.positions.Count(); i++)
            {
                pen1 = new Pen(brush: Brushes.Black);
                pen1.Width = 1.5f;
                g.DrawLine(pen1, new PointF(Ux + p.positions.ElementAt(i - 1).x * 10 * skala, Uy - p.positions.ElementAt(i - 1).f * 10 * skala), new PointF(Ux + p.positions.ElementAt(i).x * 10 * skala, Uy - p.positions.ElementAt(i).f * 10 * skala));
                pen1.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wypelnij();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        float A = -99, B = -99;

        public void StworzPunkt()
        {
            if ((textBox1.Text != "" && textBox2.Text != "") && (!textBox1.Text.Contains(".") && !textBox2.Text.Contains(".")))
            {
                Pen pen2 = new Pen(brush: Brushes.Blue);
                pen2.Width = 2.5f;
                float Ux = pictureBox1.Width / 2;
                float Uy = pictureBox1.Height / 2;
                g.DrawEllipse(pen2, (skala * 9 * float.Parse(textBox1.Text) + Ux) - 2, Uy - (float.Parse(textBox2.Text) * 9 * skala) - 2, 4, 4);
                pen2.Dispose();
                if (A == -99) { A = float.Parse(textBox1.Text); label2.Text = A.ToString(); } 
                else { B = float.Parse(textBox1.Text); label4.Text = B.ToString(); }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StworzPunkt();
        }

        private void numericUpDown1_Click(object sender, EventArgs e)
        {
            skala = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));
        }

        public void Czysc()
        {
            g.Clear(Color.White);
            A = -99;
            B = -99;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Czysc();
        }

        float S = -99;
        float Fa, Fb, Fs;
        public float Ff(float x) { return (x * x)-3; }

        private void button4_Click(object sender, EventArgs e)
        {
            if (A != -99 && B != -99)
            {
                g.Clear(Color.White);
                wypelnij();
                Pen pen = new Pen(brush: Brushes.Red);
                pen.Width = 2.5f;
                Pen penS = new Pen(brush: Brushes.Green);
                penS.Width = 2.5f;
                float Ux = pictureBox1.Width / 2;
                float Uy = pictureBox1.Height / 2;
                g.DrawEllipse(pen, (skala * 9 * A + Ux) - 5, Uy - (0 * 9 * skala) - 2, 4, 4);
                label2.Text = A.ToString();
                g.DrawEllipse(pen, (skala * 9 * B + Ux) - 5, Uy - (0 * 9 * skala) - 2, 4, 4);
                label4.Text = B.ToString();
                S = (A + B) / 2;
                Fa = Ff(A);
                Fb = Ff(B);
                Fs = Ff(S);
                if (Fs < 0 && Fa < 0) A = S;
                else B = S;
                g.DrawEllipse(penS, (skala * 9 * S + Ux) - 5, Uy - (0 * 9 * skala) - 2, 4, 4);
                label6.Text = S.ToString();
                pen.Dispose();
            }
        }
    }
}
