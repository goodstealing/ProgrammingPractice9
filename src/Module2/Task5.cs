using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2
{
    internal class Task5
    {
        public static void Execute()
        {
            Console.Clear();
            Console.CursorVisible = false;

            TemperatureSensor sensor = new();
            Thermostat thermostat = new(22.0);

            // Подписываем термостат на событие TemperatureChanged
            sensor.TemperatureChanged += thermostat.OnTemperatureChanged;

            // Изменяем температуру, чтобы проверить реакцию термостата
            sensor.CurrentTemperature = 20.0; // Вкл. отопление
            sensor.CurrentTemperature = 23.0; // Выкл. отопление
            sensor.CurrentTemperature = 21.0; // Вкл. отопление
        }

        public class TemperatureChangedEventArgs : EventArgs
        {
            public double NewTemperature { get; }

            public TemperatureChangedEventArgs(double newTemperature)
            {
                NewTemperature = newTemperature;
            }
        }

        // Класс TemperatureSensor, который отслеживает температуру и генерирует событие
        public class TemperatureSensor
        {
            private double _currentTemperature;
            public event EventHandler<TemperatureChangedEventArgs> TemperatureChanged;

            public double CurrentTemperature
            {
                get { return _currentTemperature; }
                set
                {
                    if (_currentTemperature != value)
                    {
                        _currentTemperature = value;
                        OnTemperatureChanged(new TemperatureChangedEventArgs(_currentTemperature));
                    }
                }
            }

            // Метод для вызова события
            protected virtual void OnTemperatureChanged(TemperatureChangedEventArgs e)
            {
                TemperatureChanged?.Invoke(this, e);
            }
        }

        // Класс Thermostat, который реагирует на изменение температуры
        public class Thermostat
        {
            private double _threshold;
            private bool _isHeatingOn;

            public Thermostat(double threshold)
            {
                _threshold = threshold;
                _isHeatingOn = false;
            }

            // Метод для обработки события изменения температуры
            public void OnTemperatureChanged(object sender, TemperatureChangedEventArgs e)
            {
                if (e.NewTemperature < _threshold && !_isHeatingOn)
                {
                    Console.WriteLine($"Температура {e.NewTemperature} ниже порога {_threshold}. Включаем отопление.");
                    _isHeatingOn = true;
                }
                else if (e.NewTemperature >= _threshold && _isHeatingOn)
                {
                    Console.WriteLine($"Температура {e.NewTemperature} выше порога {_threshold}. Выключаем отопление.");
                    _isHeatingOn = false;
                }
            }
        }
    }
}
