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

            // Сброс цвета полей
            ResetTextBoxColors();

            // Получение выбранной фигуры
            string? selectedFigure = comboBoxFigure.SelectedItem?.ToString();
            if (selectedFigure == null)
            {
                MessageBox.Show("Выберите фигуру.");
                return;
            }

            // Получение выбранного действия (Площадь или Периметр)
            string? selectedAction = comboBox1.SelectedItem?.ToString();
            if (selectedAction == null)
            {
                MessageBox.Show("Выберите действие (Площадь или Периметр).");
                return;
            }

            try
            {
                // Логика для разных фигур
                switch (selectedFigure)
                {
                    case "Круг":
                        if (selectedAction == "Площадь" || selectedAction == "Периметр")
                        {
                            double radius = ValidateAndParse(txtRadius);
                            iFigure = new Task1.Circle(radius);
                        }
                        break;

                    case "Прямоугольник":
                        if (selectedAction == "Площадь" || selectedAction == "Периметр")
                        {
                            double width = ValidateAndParse(txtWidth);
                            double height = ValidateAndParse(txtHeight);
                            iFigure = new Task1.Rectangle(width, height);
                        }
                        break;

                    case "Треугольник":
                        if (selectedAction == "Площадь")
                        {
                            double width = ValidateAndParse(txtWidth);
                            double height = ValidateAndParse(txtHeight);
                            iFigure = new Task1.Triangle(width, height, height); // Площадь через базу и высоту
                        }
                        else if (selectedAction == "Периметр")
                        {
                            double sideA = ValidateAndParse(txtSideA);
                            double sideB = ValidateAndParse(txtSideB);
                            double sideC = ValidateAndParse(txtSideC);
                            iFigure = new Task1.Triangle(sideA, sideB, sideC);
                        }
                        break;
                }

                // Вычисление площади и периметра
                if (iFigure != null)
                {
                    if (selectedAction == "Площадь")
                        lblAreaResult.Text = "Площадь: " + iFigure.CalculateArea().ToString("F2");
                    else if (selectedAction == "Периметр")
                        lblPerimeterResult.Text = "Периметр: " + iFigure.CalculatePerimeter().ToString("F2");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Ошибка ввода: " + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Поле не может быть пустым: " + ex.Message);
            }
        }

        // Сброс цвета всех текстбоксов
        private void ResetTextBoxColors()
        {
            txtRadius.BackColor = SystemColors.Window;
            txtWidth.BackColor = SystemColors.Window;
            txtHeight.BackColor = SystemColors.Window;
            txtSideA.BackColor = SystemColors.Window;
            txtSideB.BackColor = SystemColors.Window;
            txtSideC.BackColor = SystemColors.Window;
        }

        // Функция для проверки и парсинга текста из TextBox
        private double ValidateAndParse(TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.BackColor = Color.Red;
                throw new ArgumentNullException($"{textBox.Name} не может быть пустым.");
            }

            if (!double.TryParse(textBox.Text, out double value))
            {
                textBox.BackColor = Color.Red;
                throw new FormatException($"Неверный формат данных в {textBox.Name}.");
            }

            return value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSideA.Visible = false;
            txtSideB.Visible = false;
            txtSideC.Visible = false;

            comboBoxFigure.Items.Add("Круг");
            comboBoxFigure.Items.Add("Прямоугольник");
            comboBoxFigure.Items.Add("Треугольник");
            comboBoxFigure.SelectedIndex = 0;

            comboBox1.Items.Add("Площадь");
            comboBox1.Items.Add("Периметр");
            comboBox1.SelectedIndex = 0;

            // Подключаем обработчики для изменения выбора
            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
            comboBoxFigure.SelectedIndexChanged += new EventHandler(comboBoxFigure_SelectedIndexChanged);

            // Отключаем все поля по умолчанию
            SetActiveFieldsForActionAndFigure("Площадь", "Круг");
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
            if (action == "Площадь")
            {
                if (figure == "Круг")
                {
                    txtRadius.Enabled = true;
                    txtWidth.Enabled = false;
                    txtHeight.Enabled = false;

                    txtSideA.Enabled = false;
                    txtSideB.Enabled = false;
                    txtSideC.Enabled = false;
                }
                else if (figure == "Прямоугольник" || figure == "Треугольник")
                {
                    txtRadius.Enabled = false;
                    txtWidth.Enabled = true;
                    txtHeight.Enabled = true;

                    txtSideA.Enabled = false;
                    txtSideB.Enabled = false;
                    txtSideC.Enabled = false;
                }
            }
            else if (action == "Периметр")
            {
                if (figure == "Круг")
                {
                    txtRadius.Enabled = true;

                    txtWidth.Enabled = false;
                    txtHeight.Enabled = false;

                    txtSideA.Enabled = false;
                    txtSideB.Enabled = false;
                    txtSideC.Enabled = false;
                }
                else if (figure == "Прямоугольник")
                {
                    txtRadius.Enabled = false;

                    txtWidth.Enabled = true;
                    txtHeight.Enabled = true;

                    txtSideA.Enabled = false;
                    txtSideB.Enabled = false;
                    txtSideC.Enabled = false; // Неактивен для прямоугольника
                }
                else if (figure == "Треугольник")
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
