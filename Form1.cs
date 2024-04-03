namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Button currentButton;
        private int buttonCount = 1;
        private Point startPoint;
        

        public Form1()
        {
            InitializeComponent();
        }


        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentButton = new Button();
                currentButton.Width = 0;
                currentButton.Height = 0;
                currentButton.FlatStyle = FlatStyle.Flat;
                currentButton.BackColor = Color.Cyan;
                this.Controls.Add(currentButton);
                currentButton.BringToFront();
                startPoint = e.Location;
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (currentButton != null && e.Button == MouseButtons.Left)
            {
                int width = Math.Abs(e.X - startPoint.X);
                int height = Math.Abs(e.Y - startPoint.Y);
                currentButton.Location = new Point(Math.Min(startPoint.X, e.X), Math.Min(startPoint.Y, e.Y));
                currentButton.Size = new Size(width, height);
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (currentButton != null)
            {
                if (currentButton.Width > 0 && currentButton.Height > 0)
                {
                    currentButton.Text = buttonCount.ToString();
                    buttonCount++;
                }
                else
                {
                    this.Controls.Remove(currentButton);
                }
                currentButton = null;
            }
        }
    }
}
