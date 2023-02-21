namespace Auticka
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        List<Auto> carX = new List<Auto>();
        List<Auto> carY = new List<Auto>();
        private Auto AutoX;
        private Auto AutoY;

        public Form1()
        {
            InitializeComponent();
        }
       public void SpawnX()
        {
          
            AutoX = new Auto(MousePosition.X , MousePosition.Y , 16, 40, 1, new SolidBrush(Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256))));
            carX.Add(AutoX);
            Refresh();
        }

        public void SpawnY()
        {
            AutoY = new Auto(MousePosition.X, MousePosition.Y, 40, 16, 1, new SolidBrush(Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256))));
            carY.Add(AutoY);
            Refresh();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
           
            foreach(Auto x in carX)
            {
                x.Draw(g);
            }

            foreach(Auto y in carY)
            {
                y.Draw(g);
            }         

        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            
            
                if (e.Button == MouseButtons.Left)
                {
                    SpawnX();
                    
                }

                if (e.Button == MouseButtons.Right)
                {
                    SpawnY();
                   
                }    
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckCollision();
            MoveX();
            MoveY();
            panel1.Refresh();

        }
        private void CheckCollision()
        {
            foreach(Auto x in carX)
            {
                if(x.x + 3 < 0||
                   x.x + 3 + x.width > panel1.Size.Width)
                {
                    x.direction *= -1;
                }
            }
            foreach (Auto y in carY)
            {
                if (y.y + 3 < 0 ||
                   y.y + 3 + y.height > panel1.Size.Height)
                {
                    y.direction *= -1;
                }
            }

        }

        private void MoveY()
        {
            foreach(Auto y in carY)
            {
                y.y += 3 * y.direction;
                y.leftKolecko.y += 3 * y.direction;
                y.rightKolecko.y += 3 * y.direction;
            }   
        }

        private void MoveX()
        {
            foreach (Auto x in carX)
            {
                x.x += 3 * x.direction;
                x.leftKolecko.x += 3 * x.direction;
                x.rightKolecko.x += 3 * x.direction;
            }
        }

        
    }
}