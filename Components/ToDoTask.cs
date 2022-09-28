using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ToDoList.Components
{
    internal delegate void ToDoTaskButtonHandler(ToDoTask sender);

    internal class ToDoTaskTemplates
    {
        public ControlTemplate ButtonSuccesstemplate;
        public ControlTemplate TaskCompletedTemplate;
        public ControlTemplate ButtonDeleteTemplate;
        public ControlTemplate TaskTemplate;

        public ToDoTaskTemplates(ControlTemplate _buttonSuccessTemplate,
            ControlTemplate _taskCompletedTemplate,
            ControlTemplate _buttonDeleteTemplate,
            ControlTemplate _taskTemplate)
        {
            (this.ButtonSuccesstemplate, this.TaskCompletedTemplate, this.ButtonDeleteTemplate, this.TaskTemplate) =
                (_buttonSuccessTemplate, _taskCompletedTemplate, _buttonDeleteTemplate, _taskTemplate);
        }
    }

    internal class ToDoTask : StackPanel
    {

        private readonly Button _buttonSuccess = new();
        private readonly Label _text = new();
        private readonly Label _time = new();
        private readonly Button _buttonDelete = new();

        private ToDoTaskTemplates _toDoTaskTemplate;
        public ToDoTaskTemplates ToDoTaskTemplate
        {
            get { return _toDoTaskTemplate; }
            set
            {
                _toDoTaskTemplate = value;
                _text.Template = _toDoTaskTemplate.TaskTemplate;
                _time.Template = _toDoTaskTemplate.TaskTemplate;
                _buttonDelete.Template = _toDoTaskTemplate.ButtonDeleteTemplate;
                _buttonSuccess.Template = _toDoTaskTemplate.ButtonSuccesstemplate;
            }
        }

        private bool _isSuccess = false;
        public bool IsSuccess
        {
            get { return _isSuccess; }
            private set { _isSuccess = value; }
        }

        public event ToDoTaskButtonHandler ToDoTaskDeleteEvent;

        ~ToDoTask()
        {
            _buttonDelete.Click -= DeleteTaskHandler;
            _buttonSuccess.Click -= SuccessTaskHandler;
        }

        private ToDoTask()
        {
            Orientation = Orientation.Horizontal;

            _text.Width = 700;
            _time.Width = 100;

            Margin = new Thickness(0, 10, 0, 0);

            Children.Add(_text);
            Children.Add(_time);
            Children.Add(_buttonSuccess);
            Children.Add(_buttonDelete);

            _buttonDelete.Click += DeleteTaskHandler;
            _buttonSuccess.Click += SuccessTaskHandler;
        }

        public ToDoTask(object content, TimeSpan time) : this()
        {
            _text.Content = content;
            _time.Content = TimeSpanInstruments.ConverteTimeSpanToClockStringFormat(time);
        }

        protected void DeleteTaskHandler(object sender, RoutedEventArgs e) => ToDoTaskDeleteEvent?.Invoke(this);
        private void SuccessTaskHandler(object sender, RoutedEventArgs e)
        {
            _text.Template = IsSuccess ? _toDoTaskTemplate. TaskTemplate : _toDoTaskTemplate.TaskCompletedTemplate;
            _time.Template = IsSuccess ? _toDoTaskTemplate.TaskTemplate : _toDoTaskTemplate.TaskCompletedTemplate;
            IsSuccess = !IsSuccess;
        }
    }
}
