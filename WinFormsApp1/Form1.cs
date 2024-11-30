using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        int locationNum = 0;
        int score = 0;
        int misses = 0;
        bool isHit = false;
        bool gameStarted = false;
        SoundPlayer musicPlayer; // Для воспроизведения музыки
        

        public Form1()
        {
            InitializeComponent();
            InitializeMusic(); // Инициализация музыки
            SetCustomCursor(); // Установка пользовательского курсора
            ShowStartMessage(); // Показываем сообщение с правилами
        }

        private void InitializeMusic()
        {
            try
            {
                // Загружаем WAV-файл для фоновой музыки
                var musicStream = new System.IO.MemoryStream(Properties.Resources.pvz);
                musicPlayer = new SoundPlayer(musicStream); // Инициализируем плеер с потоком
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке музыки: {ex.Message}");
            }
        }



        private void SetCustomCursor()
        {
            try
            {
                // Загружаем курсор из ресурсов
                var cursorStream = new System.IO.MemoryStream(Properties.Resources.cursor); // 
                this.Cursor = new Cursor(cursorStream); // Установка пользовательского курсора
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при установке курсора: {ex.Message}");
            }
        }


        private void ShowStartMessage()
        {
            Form startMessageForm = new Form
            {
                Text = "Правила игры",
                Size = new Size(450, 250),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White, // Устанавливаем фон на белый
                Icon = SystemIcons.Information, // Добавляем иконку
                Padding = new Padding(20)
            };

            Label rulesLabel = new Label
            {
                Text = "Наберите 20 попаданий, и вы выиграете!\nНаберете больше 5 промахов — вы проиграли.",
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Arial", 12, FontStyle.Regular),
                ForeColor = Color.FromArgb(50, 50, 50), // Более темный цвет текста
                Padding = new Padding(10)
            };

            Button startButton = new Button
            {
                Text = "Начать игру",
                Dock = DockStyle.Bottom,
                Height = 45,
                BackColor = Color.FromArgb(0, 122, 204), // Синий цвет кнопки
                ForeColor = Color.White, // Белый текст
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 14, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            // Обработчик события кнопки "Начать игру"
            startButton.Click += (s, e) =>
            {
                gameStarted = true; // Устанавливаем флаг, что игра началась
                musicPlayer.PlayLooping(); // Запускаем фоновую музыку
                startMessageForm.Close(); // Закрываем окно с правилами
                timer1.Start(); // Запускаем таймер только здесь
                moveMouse(); // Устанавливаем начальное положение мыши

               
            };

            startMessageForm.Controls.Add(rulesLabel);
            startMessageForm.Controls.Add(startButton);
            startMessageForm.ShowDialog();
        }

        
        

        private void EndGame(string resultMessage)
        {
            timer1.Stop(); // Останавливаем таймер
            Mouse.Enabled = false; // Отключаем мышь
            musicPlayer.Stop(); // Останавливаем музыку

            Form resultForm = new Form
            {
                Text = resultMessage,
                Size = new Size(300, 250),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label resultLabel = new Label
            {
                Text = resultMessage,
                AutoSize = true,
                Location = new Point(90, 50),
                Font = new Font("Arial", 14, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Button retryButton = new Button
            {
                Text = "Попробовать еще раз",
                Location = new Point(75, 100),
                Size = new Size(150, 30)
            };
            retryButton.Click += (s, e) => RestartGame(resultForm);

            Button exitButton = new Button
            {
                Text = "Выйти из игры",
                Location = new Point(75, 150),
                Size = new Size(150, 30)
            };
            exitButton.Click += (s, e) => Application.Exit(); // Завершаем приложение

            resultForm.Controls.Add(resultLabel);
            resultForm.Controls.Add(retryButton);
            resultForm.Controls.Add(exitButton);
            resultForm.ShowDialog();
        }

        private void RestartGame(Form resultForm)
        {
            resultForm.Close(); // Закрываем форму результата
            score = 0;
            misses = 0;
            label1.Text = "Попадание: " + score;
            label2.Text = "Промахи: " + misses;
            gameStarted = true;
            musicPlayer.PlayLooping(); // Запускаем музыку
            timer1.Start(); // Перезапускаем таймер
            moveMouse(); // Устанавливаем начальное положение мыши
        }

        private void gotMouse(object sender, EventArgs e)
        {
            score++;
            Mouse.Image = Properties.Resources.dead;
            isHit = true;
            Mouse.Enabled = false;

        }

        private void moveMouse(object sender, EventArgs e)
        {
            if (!gameStarted)
                return; // Если игра не началась, ничего не делаем

            label1.Text = "Попадание: " + score;
            label2.Text = "Промахи: " + misses;

            if (isHit == false)
            {
                misses++;
            }

            if (score >= 20)
            {
                EndGame("Победа!");
            }
            else if (misses > 5)
            {
                EndGame("Ты проиграл :(");
            }
            else
            {
                moveMouse();
            }
        }

        private void moveMouse()
        {
            isHit = false;
            Mouse.Enabled = true;
            Mouse.Image = Properties.Resources.alive;
            Mouse.BackColor = System.Drawing.Color.Transparent;

            locationNum = rnd.Next(1, 7);
            switch (locationNum)
            {
                case 1:
                    Mouse.Left = 340;
                    Mouse.Top = 216;
                    break;
                case 2:
                    Mouse.Left = 579;
                    Mouse.Top = 258;
                    break;
                case 3:
                    Mouse.Left = 553;
                    Mouse.Top = 340;
                    break;
                case 4:
                    Mouse.Left = 343;
                    Mouse.Top = 385;
                    break;
                case 5:
                    Mouse.Left = 107;
                    Mouse.Top = 329;
                    break;
                case 6:
                    Mouse.Left = 79;
                    Mouse.Top = 249;
                    break;
                default:
                    break;
            }
        }
    }
}
