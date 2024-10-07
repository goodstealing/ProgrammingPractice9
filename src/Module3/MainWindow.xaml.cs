﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Module3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void CloseButton_Click(object sender, RoutedEventArgs e) => Close();

        void MinimizeButton_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

        void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal; // Восстановление размера окна
            }
            else
            {
                WindowState = WindowState.Maximized; // Окно на весь экран
            }
        }

        void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Если ЛКМ
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                DragMove(); // Перемещение окна
            }
        }

        void OpenTask1_Click(object sender, RoutedEventArgs e)
        {
            Task1 task1 = new();
            task1.Left = Left; task1.Top = Top;
            task1.Show();
            Hide();
        }

        void OpenTask2_Click(object sender, RoutedEventArgs e)
        {
            Task2 task2 = new();
            task2.Left = Left; task2.Top = Top;
            task2.Show();
            Hide();
        }

        void OpenTask3_Click(object sender, RoutedEventArgs e)
        {
            Task3 task3 = new();
            task3.Left = Left; task3.Top = Top;
            task3.Show();
            Hide();
        }

        void OpenTask4_Click(object sender, RoutedEventArgs e)
        {
            Task4 task4 = new();
            task4.Left = Left; task4.Top = Top;
            task4.Show();
            Hide();
        }

        void OpenTask5_Click(object sender, RoutedEventArgs e)
        {
            Task5 task5 = new();
            task5.Left = Left; task5.Top = Top;
            task5.Show();
            Hide();
        }
    }
}