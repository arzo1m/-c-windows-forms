using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            SetupUI();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void SetupUI()
        {
            this.Text = "Бей мышей";
            this.Size = new Size(816, 665);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Кнопка "Начать играть"
            Button startButton = new Button
            {
                Text = "Начать играть",
                Size = new Size(200, 50),
                Location = new Point((this.ClientSize.Width - 200) / 2, 240),
                FlatStyle = FlatStyle.Flat, // Убираем стандартный стиль
                Font = new Font("Arial", 16, FontStyle.Bold), // Шрифт текста
                ForeColor = Color.White, // Цвет текста
                BackColor = Color.Transparent, // Прозрачный фон
                FlatAppearance =
    {
        BorderSize = 2, // Толщина границы
        BorderColor = Color.White, // Цвет границы
        MouseOverBackColor = Color.FromArgb(100, 0, 120, 215), // Цвет при наведении
        MouseDownBackColor = Color.FromArgb(150, 0, 120, 215) // Цвет при нажатии
    }
            };
            startButton.Paint += (s, e) =>
            {
                // Добавление пользовательской графики
                Button btn = (Button)s;
                using (LinearGradientBrush brush = new LinearGradientBrush(btn.ClientRectangle, Color.Blue, Color.Cyan, 45F))
                {
                    e.Graphics.FillRectangle(brush, btn.ClientRectangle);
                }
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle, btn.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            };
            // Обработчик события Click для кнопки "Начать играть"
            startButton.Click += StartButton_Click;

            this.Controls.Add(startButton);

            // Кнопка "Выход"
            Button exitButton = new Button
            {
                Text = "Выход",
                Size = new Size(200, 50),
                Location = new Point((this.ClientSize.Width - 200) / 2, 300),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                FlatAppearance =
    {
        BorderSize = 2,
        BorderColor = Color.Red,
        MouseOverBackColor = Color.FromArgb(100, 200, 0, 0),
        MouseDownBackColor = Color.FromArgb(150, 200, 0, 0)
    }
            };
            exitButton.Paint += (s, e) =>
            {
                // Добавление пользовательской графики
                Button btn = (Button)s;
                using (LinearGradientBrush brush = new LinearGradientBrush(btn.ClientRectangle, Color.Red, Color.Orange, 45F))
                {
                    e.Graphics.FillRectangle(brush, btn.ClientRectangle);
                }
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle, btn.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            };
            // Обработчик события Click для кнопки "Выход"
            exitButton.Click += (s, e) => Application.Exit();

            this.Controls.Add(exitButton);

        }
        // Обработчик события для кнопки "Начать играть"
        private void StartButton_Click(object sender, EventArgs e)
        {
            // Переход на Form1
            Form1 form1 = new Form1();
            this.Hide(); // Скрыть текущую форму
            form1.ShowDialog(); // Показать Form1
            this.Close(); // Закрыть текущую форму после завершения Form1
        }

    }
}
