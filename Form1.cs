using System;
using System.Windows.Forms;
using lab7.list;

namespace lab7
{
    public partial class Form1 : Form
    {
        private SinglyLinkedList<int> list = new SinglyLinkedList<int>();

        private TextBox inputBox;
        private Button addButton;
        private Button findButton;
        private Button sumButton;
        private Button printButton;
        private Button deleteButton;
        private Button newListButton;
        private ListBox listDisplay;

        private const int buttonWidth = 340;

        public Form1()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "lab7";
            this.Width = 400;
            this.Height = 400;

            inputBox = new TextBox()
            {
                Top = 20,
                Left = 20,
                Width = buttonWidth,
                ForeColor = System.Drawing.Color.MidnightBlue
            };

            addButton = new Button()
            {
                Text = "Додати в список",
                Top = 60,
                Left = 20,
                Width = buttonWidth,
                BackColor = System.Drawing.Color.AliceBlue,
                ForeColor = System.Drawing.Color.MidnightBlue
            };
            addButton.Click += AddButton_Click;

            findButton = new Button()
            {
                Text = "Знайти елемент більший за заданий",
                Top = 80,
                Left = 20,
                Width = buttonWidth,
                BackColor = System.Drawing.Color.MintCream,
                ForeColor = System.Drawing.Color.MidnightBlue
            };
            findButton.Click += FindButton_Click;

            sumButton = new Button()
            {
                Text = "Порахувати суму елементів менших за значення",
                Top = 100,
                Left = 20,
                Width = buttonWidth,
                BackColor = System.Drawing.Color.AliceBlue,
                ForeColor = System.Drawing.Color.MidnightBlue
            };
            sumButton.Click += SumButton_Click;

            newListButton = new Button()
            {
                Text = "Створити новий список з елементами меншими за заданий",
                Top = 120,
                Left = 20,
                Width = buttonWidth,
                BackColor = System.Drawing.Color.MintCream,
                ForeColor = System.Drawing.Color.MidnightBlue
            };
            newListButton.Click += NewListButton_Click;

            deleteButton = new Button()
            {
                Text = "Видалиити елементи після максимального",
                Top = 140,
                Left = 20,
                Width = buttonWidth,
                BackColor = System.Drawing.Color.AliceBlue,
                ForeColor = System.Drawing.Color.MidnightBlue,
            };
            deleteButton.Click += DeleteButton_Click;

            printButton = new Button()
            {
                Text = "Вивести список",
                Top = 160,
                Left = 20,
                Width = buttonWidth,
                BackColor = System.Drawing.Color.MintCream,
                ForeColor = System.Drawing.Color.MidnightBlue
            };
            printButton.Click += PrintButton_Click;

            listDisplay = new ListBox()
            {
                Top = 200,
                Left = 20,
                Width = 340,
                Height = 120,
                ForeColor = System.Drawing.Color.MidnightBlue
            };

            this.Controls.Add(inputBox);
            this.Controls.Add(addButton);
            this.Controls.Add(findButton);
            this.Controls.Add(sumButton);
            this.Controls.Add(newListButton);
            this.Controls.Add(deleteButton);
            this.Controls.Add(printButton);
            this.Controls.Add(listDisplay);
        }

        private bool TryGetInput(out int value)
        {
            if (int.TryParse(inputBox.Text, out value))
            {
                inputBox.Clear();
                return true;
            }

            MessageBox.Show("Введіть ціле число!");
            return false;
        }

        private void DisplayList(SinglyLinkedList<int> targetList)
        {
            listDisplay.Items.Add(targetList.Print());
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (!TryGetInput(out int value)) return;

            list.AddAfterFirst(value);
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            ClearOutput();
            DisplayList(list);
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            if (!TryGetInput(out int value)) return;

            ClearOutput();

            listDisplay.Items.Add(list.FindHigherElement(value));
        }

        private void SumButton_Click(object sender, EventArgs e)
        {
            if (!TryGetInput(out int value)) return;
            ClearOutput();
            listDisplay.Items.Add(list.FindSum(value));
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            ClearOutput();
            listDisplay.Items.Add(list.DeleteAfterMax());
        }

        private void NewListButton_Click(object sender, EventArgs e)
        {
            if (!TryGetInput(out int value)) return;
            string message;
            var newList = list.CreateNewList(value, out message);
            ClearOutput();
            listDisplay.Items.Add(message);
            DisplayList(newList);
        }

        private void ClearOutput()
        {
            listDisplay.Items.Clear();
        }
    }
}