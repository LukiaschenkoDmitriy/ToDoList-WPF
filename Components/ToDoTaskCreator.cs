using System;
using System.Windows;
using System.Windows.Controls;
using WPFTools;

namespace ToDoList.Components
{
    internal class ToDoTaskCreator : StackPanel
    {
        private readonly TextBox _text = new();
        private readonly TimePicker _time  = new();
        private readonly Button _buttonSuccess = new();

        public ToDoTaskButtonHandler _toDoDeleteHandler;
        public event ToDoTaskButtonHandler ToDoTaskAddEvent;

        public ControlTemplate TextTemplate
        {
            get { return _text.Template; }
            set { _text.Template = value; }
        }

        private ToDoTaskTemplates _toDoTaskTemplate;
        public ToDoTaskTemplates ToDoTaskTemplate
        {
            get { return _toDoTaskTemplate; }
            set
            {
                _toDoTaskTemplate = value;
                _buttonSuccess.Template = _toDoTaskTemplate.ButtonSuccesstemplate;
            }
        }

        ~ToDoTaskCreator()
        {
            _buttonSuccess.Click -= CreateNewTask;
        }

        public ToDoTaskCreator(ToDoTaskButtonHandler deleteHandler)
        {
            Orientation = Orientation.Horizontal;

            Margin = new Thickness(0, 30, 0, 0);

            _text.Width = 700;
            _time.Width = 100;

            Children.Add(_text);
            Children.Add(_time);
            Children.Add(_buttonSuccess);

            _toDoDeleteHandler = deleteHandler;
            _buttonSuccess.Click += CreateNewTask;
        }

        private void CreateNewTask(object sender, RoutedEventArgs e)
        {
            try
            {
                ToDoTask toDoTask = new ToDoTask(_text.Text, new TimeSpan(0, _time.Hours, _time.Minutes))
                {
                    ToDoTaskTemplate = _toDoTaskTemplate
                };

                (_time.Hours, _time.Minutes) = (0, 0);

                toDoTask.ToDoTaskDeleteEvent += _toDoDeleteHandler;
                ToDoTaskAddEvent?.Invoke(toDoTask);
            }
            catch { }
        }
    }
}
