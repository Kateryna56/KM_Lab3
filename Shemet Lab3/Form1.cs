using Shemet_Lab3.CLasses;

namespace Shemet_Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            try
            {
                Drawer.CreateGraphics(MainPictureBox);
                Drawer.DrawCoordinateSystem();

                Calculator.SolveRungeKutta2(Drawer.xMin, Drawer.xMax);
                Calculator.SolveABM(Drawer.xMin, Drawer.xMax);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}