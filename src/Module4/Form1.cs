using System;
using System.Drawing;
using System.Windows.Forms;
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

            // ����� ����� �����
            ResetTextBoxColors();

            // ��������� ��������� ������
            string? selectedFigure = comboBoxFigure.SelectedItem?.ToString();
            if (selectedFigure == null)
            {
                MessageBox.Show("�������� ������.");
                return;
            }

            // ��������� ���������� �������� (������� ��� ��������)
            string? selectedAction = comboBox1.SelectedItem?.ToString();
            if (selectedAction == null)
            {
                MessageBox.Show("�������� �������� (������� ��� ��������).");
                return;
            }

            try
            {
                // ������ ��� ������ �����
                switch (selectedFigure)
                {
                    case "����":
                        if (selectedAction == "�������" || selectedAction == "��������")
                        {
                            double radius = ValidateAndParse(txtRadius);
                            iFigure = new Task1.Circle(radius);
                        }
                        break;

                    case "�������������":
                        if (selectedAction == "�������" || selectedAction == "��������")
                        {
                            double width = ValidateAndParse(txtWidth);
                            double height = ValidateAndParse(txtHeight);
                            iFigure = new Task1.Rectangle(width, height);
                        }
                        break;

                    case "�����������":
                        if (selectedAction == "�������")
                        {
                            double width = ValidateAndParse(txtWidth);
                            double height = ValidateAndParse(txtHeight);
                            iFigure = new Task1.Triangle(width, height, height); // ������� ����� ���� � ������
                        }
                        else if (selectedAction == "��������")
                        {
                            double sideA = ValidateAndParse(txtSideA);
                            double sideB = ValidateAndParse(txtSideB);
                            double sideC = ValidateAndParse(txtSideC);
                            iFigure = new Task1.Triangle(sideA, sideB, sideC);
                        }
                        break;
                }

                // ���������� ������� � ���������
                if (iFigure != null)
                {
                    if (selectedAction == "�������")
                        lblAreaResult.Text = "�������: " + iFigure.CalculateArea().ToString("F2");
                    else if (selectedAction == "��������")
                        lblPerimeterResult.Text = "��������: " + iFigure.CalculatePerimeter().ToString("F2");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("������ �����: " + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("���� �� ����� ���� ������: " + ex.Message);
            }
        }

        // ����� ����� ���� �����������
        private void ResetTextBoxColors()
        {
            txtRadius.BackColor = SystemColors.Window;
            txtWidth.BackColor = SystemColors.Window;
            txtHeight.BackColor = SystemColors.Window;
            txtSideA.BackColor = SystemColors.Window;
            txtSideB.BackColor = SystemColors.Window;
            txtSideC.BackColor = SystemColors.Window;
        }

        // ������� ��� �������� � �������� ������ �� TextBox
        private double ValidateAndParse(TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.BackColor = Color.Red;
                throw new ArgumentNullException($"{textBox.Name} �� ����� ���� ������.");
            }

            if (!double.TryParse(textBox.Text, out double value))
            {
                textBox.BackColor = Color.Red;
                throw new FormatException($"�������� ������ ������ � {textBox.Name}.");
            }

            return value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSideA.Visible = false;
            txtSideB.Visible = false;
            txtSideC.Visible = false;

            comboBoxFigure.Items.Add("����");
            comboBoxFigure.Items.Add("�������������");
            comboBoxFigure.Items.Add("�����������");
            comboBoxFigure.SelectedIndex = 0;

            comboBox1.Items.Add("�������");
            comboBox1.Items.Add("��������");
            comboBox1.SelectedIndex = 0;

            // ���������� ����������� ��� ��������� ������
            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
            comboBoxFigure.SelectedIndexChanged += new EventHandler(comboBoxFigure_SelectedIndexChanged);

            // ��������� ��� ���� �� ���������
            SetActiveFieldsForActionAndFigure("�������", "����");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedAction = comboBox1.SelectedItem?.ToString();
            string selectedFigure = comboBoxFigure.SelectedItem?.ToString();
            if (selectedAction != null && selectedFigure != null)
            {
                SetActiveFieldsForActionAndFigure(selectedAction, selectedFigure);
            }
        }

        private void comboBoxFigure_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedAction = comboBox1.SelectedItem?.ToString();
            string selectedFigure = comboBoxFigure.SelectedItem?.ToString();
            if (selectedAction != null && selectedFigure != null)
            {
                SetActiveFieldsForActionAndFigure(selectedAction, selectedFigure);
            }
        }

        private void SetActiveFieldsForActionAndFigure(string action, string figure)
        {
            if (action == "�������")
            {
                if (figure == "����")
                {
                    txtRadius.Enabled = true;
                    txtWidth.Enabled = false;
                    txtHeight.Enabled = false;

                    txtSideA.Enabled = false;
                    txtSideB.Enabled = false;
                    txtSideC.Enabled = false;
                }
                else if (figure == "�������������" || figure == "�����������")
                {
                    txtRadius.Enabled = false;
                    txtWidth.Enabled = true;
                    txtHeight.Enabled = true;

                    txtSideA.Enabled = false;
                    txtSideB.Enabled = false;
                    txtSideC.Enabled = false;
                }
            }
            else if (action == "��������")
            {
                if (figure == "����")
                {
                    txtRadius.Enabled = true;

                    txtWidth.Enabled = false;
                    txtHeight.Enabled = false;

                    txtSideA.Enabled = false;
                    txtSideB.Enabled = false;
                    txtSideC.Enabled = false;
                }
                else if (figure == "�������������")
                {
                    txtRadius.Enabled = false;

                    txtWidth.Enabled = true;
                    txtHeight.Enabled = true;

                    txtSideA.Enabled = false;
                    txtSideB.Enabled = false;
                    txtSideC.Enabled = false; // ��������� ��� ��������������
                }
                else if (figure == "�����������")
                {
                    txtRadius.Enabled = false;

                    txtWidth.Enabled = false;
                    txtHeight.Enabled = false;

                    txtSideA.Visible = true;
                    txtSideB.Visible = true;
                    txtSideC.Visible = true;

                    txtSideA.Enabled = true;
                    txtSideB.Enabled = true;
                    txtSideC.Enabled = true;
                }
            }
        }
    }
}
