using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToDoList.Components;
using WPFTools;

namespace ToDoList
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            new ToDoTaskControl(Resources, ToDoTaskContainer, Container);
        }
    }

    internal class ToDoTaskControl
    {
        private readonly StackPanel _toDoTaskContainer;
        public ToDoTaskControl(ResourceDictionary resources, StackPanel toDoTaskContainer, StackPanel container)
        {
            _toDoTaskContainer = toDoTaskContainer;

            ControlTemplate taskTextTemplate = resources["taskTextTemplate"] as ControlTemplate;
            ControlTemplate taskTextSuccessTemplate = resources["taskTextSuccessTemplate"] as ControlTemplate;
            ControlTemplate taskDeleteButton = resources["taskDeleteButton"] as ControlTemplate;
            ControlTemplate taskSuccessButton = resources["taskSuccessButton"] as ControlTemplate;

            ControlTemplate taskBoxTemplate = resources["taskTextBoxTemplate"] as ControlTemplate;

            ToDoTaskTemplates toDoTaskTemplates = new(taskSuccessButton, taskTextSuccessTemplate, taskDeleteButton, taskTextTemplate);

            ToDoTaskCreator tdtaskcreator = new(ToDoTaskDeleteHandler)
            {
                TextTemplate = taskBoxTemplate,
                ToDoTaskTemplate = toDoTaskTemplates
            };

            tdtaskcreator.ToDoTaskAddEvent += ToDoTaskAddHandler;

            container.Children.Add(tdtaskcreator);

        }
        private void ToDoTaskDeleteHandler(ToDoTask sender) => _toDoTaskContainer.Children.Remove(sender);
        private void ToDoTaskAddHandler(ToDoTask sender) => _toDoTaskContainer.Children.Add(sender);
    }
}
