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

            // ��������� ��������� ������
            string? selectedFigure = comboBoxFigure.SelectedItem?.ToString();
            if (selectedFigure == null)
            {
                MessageBox.Show("�������� ������.");
                return;
            }

            switch (selectedFigure)
            {
                case "����":
                    double radius = double.Parse(txtRadius.Text);
                    iFigure = new Task1.Circle(radius); 
                    break;

                case "�������������":
                    double width = double.Parse(txtWidth.Text);
                    double height = double.Parse(txtHeight.Text);
                    iFigure = new Task1.Rectangle(width, height);
                    break;

                case "�����������":
                    double sideA = double.Parse(txtSideA.Text);
                    double sideB = double.Parse(txtSideB.Text);
                    double sideC = double.Parse(txtSideC.Text);
                    iFigure = new Task1.Triangle(sideA, sideB, sideC); 
                    break;
            }

            // ���������� ������� � ���������
            if (iFigure != null)
            {
                lblAreaResult.Text = "�������: " + iFigure.CalculateArea().ToString("F2");
                lblPerimeterResult.Text = "��������: " + iFigure.CalculatePerimeter().ToString("F2");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxFigure.Items.Add("����");
            comboBoxFigure.Items.Add("�������������");
            comboBoxFigure.Items.Add("�����������");
            comboBoxFigure.SelectedIndex = 0;
        }
    }
}
