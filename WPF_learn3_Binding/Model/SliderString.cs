using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF6_Binding.Model
{
    class SliderString : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;


        private string _textShow;

        public string TextShow
        {
            get => _textShow;
            set
            {
                _textShow = $"{double.Parse(value),6:F}";
                _sliderValue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TextShow"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SliderValue"));

            }
        }

        private string _sliderValue;

        public string SliderValue
        {
            get => _sliderValue;
            set
            {
                _sliderValue = value;
                TextShow = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TextShow"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SliderValue"));
            }
        }
    }
}