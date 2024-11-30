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
        SoundPlayer musicPlayer; // ��� ��������������� ������
        

        public Form1()
        {
            InitializeComponent();
            InitializeMusic(); // ������������� ������
            SetCustomCursor(); // ��������� ����������������� �������
            ShowStartMessage(); // ���������� ��������� � ���������
        }

        private void InitializeMusic()
        {
            try
            {
                // ��������� WAV-���� ��� ������� ������
                var musicStream = new System.IO.MemoryStream(Properties.Resources.pvz);
                musicPlayer = new SoundPlayer(musicStream); // �������������� ����� � �������
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� �������� ������: {ex.Message}");
            }
        }



        private void SetCustomCursor()
        {
            try
            {
                // ��������� ������ �� ��������
                var cursorStream = new System.IO.MemoryStream(Properties.Resources.cursor); // 
                this.Cursor = new Cursor(cursorStream); // ��������� ����������������� �������
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ��������� �������: {ex.Message}");
            }
        }


        private void ShowStartMessage()
        {
            Form startMessageForm = new Form
            {
                Text = "������� ����",
                Size = new Size(450, 250),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White, // ������������� ��� �� �����
                Icon = SystemIcons.Information, // ��������� ������
                Padding = new Padding(20)
            };

            Label rulesLabel = new Label
            {
                Text = "�������� 20 ���������, � �� ���������!\n�������� ������ 5 �������� � �� ���������.",
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Arial", 12, FontStyle.Regular),
                ForeColor = Color.FromArgb(50, 50, 50), // ����� ������ ���� ������
                Padding = new Padding(10)
            };

            Button startButton = new Button
            {
                Text = "������ ����",
                Dock = DockStyle.Bottom,
                Height = 45,
                BackColor = Color.FromArgb(0, 122, 204), // ����� ���� ������
                ForeColor = Color.White, // ����� �����
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 14, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            // ���������� ������� ������ "������ ����"
            startButton.Click += (s, e) =>
            {
                gameStarted = true; // ������������� ����, ��� ���� ��������
                musicPlayer.PlayLooping(); // ��������� ������� ������
                startMessageForm.Close(); // ��������� ���� � ���������
                timer1.Start(); // ��������� ������ ������ �����
                moveMouse(); // ������������� ��������� ��������� ����

               
            };

            startMessageForm.Controls.Add(rulesLabel);
            startMessageForm.Controls.Add(startButton);
            startMessageForm.ShowDialog();
        }

        
        

        private void EndGame(string resultMessage)
        {
            timer1.Stop(); // ������������� ������
            Mouse.Enabled = false; // ��������� ����
            musicPlayer.Stop(); // ������������� ������

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
                Text = "����������� ��� ���",
                Location = new Point(75, 100),
                Size = new Size(150, 30)
            };
            retryButton.Click += (s, e) => RestartGame(resultForm);

            Button exitButton = new Button
            {
                Text = "����� �� ����",
                Location = new Point(75, 150),
                Size = new Size(150, 30)
            };
            exitButton.Click += (s, e) => Application.Exit(); // ��������� ����������

            resultForm.Controls.Add(resultLabel);
            resultForm.Controls.Add(retryButton);
            resultForm.Controls.Add(exitButton);
            resultForm.ShowDialog();
        }

        private void RestartGame(Form resultForm)
        {
            resultForm.Close(); // ��������� ����� ����������
            score = 0;
            misses = 0;
            label1.Text = "���������: " + score;
            label2.Text = "�������: " + misses;
            gameStarted = true;
            musicPlayer.PlayLooping(); // ��������� ������
            timer1.Start(); // ������������� ������
            moveMouse(); // ������������� ��������� ��������� ����
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
                return; // ���� ���� �� ��������, ������ �� ������

            label1.Text = "���������: " + score;
            label2.Text = "�������: " + misses;

            if (isHit == false)
            {
                misses++;
            }

            if (score >= 20)
            {
                EndGame("������!");
            }
            else if (misses > 5)
            {
                EndGame("�� �������� :(");
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
