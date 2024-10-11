using Module4.Task1;


namespace Module4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            Task1.IFigure? iFigure = null;

            // Получение выбранной фигуры
            string? selectedFigure = comboBoxFigure.SelectedItem?.ToString();
            if (selectedFigure == null)
            {
                MessageBox.Show("Выберите фигуру.");
                return;
            }

            switch (selectedFigure)
            {
                case "Круг":
                    double radius = double.Parse(txtRadius.Text);
                    iFigure = new Task1.Circle(radius); 
                    break;

                case "Прямоугольник":
                    double width = double.Parse(txtWidth.Text);
                    double height = double.Parse(txtHeight.Text);
                    iFigure = new Task1.Rectangle(width, height);
                    break;

                case "Треугольник":
                    double sideA = double.Parse(txtSideA.Text);
                    double sideB = double.Parse(txtSideB.Text);
                    double sideC = double.Parse(txtSideC.Text);
                    iFigure = new Task1.Triangle(sideA, sideB, sideC); 
                    break;
            }

            // Вычисление площади и периметра
            if (iFigure != null)
            {
                lblAreaResult.Text = "Площадь: " + iFigure.CalculateArea().ToString("F2");
                lblPerimeterResult.Text = "Периметр: " + iFigure.CalculatePerimeter().ToString("F2");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxFigure.Items.Add("Круг");
            comboBoxFigure.Items.Add("Прямоугольник");
            comboBoxFigure.Items.Add("Треугольник");
            comboBoxFigure.SelectedIndex = 0;
        }
    }
}
