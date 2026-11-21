namespace ball_game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.Load += Form1_Load;
            this.KeyDown += Form1_KeyDown;
            timer1.Tick += timer1_Tick;
        }

        int dx = 6;
        int dy = 6;
        int count = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 20;
            timer1.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && panel1.Left > 0)
            {
                panel1.Left -= 20;
            }
            if (e.KeyCode == Keys.Right && panel1.Right < ClientSize.Width)
            {
                panel1.Left += 20;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Left += dx;
            pictureBox1.Top += dy;

            if (pictureBox1.Left <= 0 || pictureBox1.Right >= ClientSize.Width)
            {
                dx = -dx;
            }

            if (pictureBox1.Top <= 0)
            {
                dy = -dy;
            }

            if (pictureBox1.Bounds.IntersectsWith(panel1.Bounds) && dy > 0)
            {
                dy = -dy;
                count++;
            }

            if (pictureBox1.Top > panel1.Bottom)
            {
                timer1.Stop();
                DialogResult d = MessageBox.Show(
                    "Oyun bitdi! Yekun xal: " + count + "\nYeni oyun üçün Ok düyməsinə basın",
                    "İnformasiya",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                if (d == DialogResult.OK)
                {
                    count = 0;
                    dx = 6;
                    dy = 6;
                    pictureBox1.Location = new Point(100, 50);
                    panel1.Left = (ClientSize.Width - panel1.Width) / 2;
                    timer1.Start();
                }
            }
        }
    }
}