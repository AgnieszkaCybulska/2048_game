using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            generate_start_numbers();
            change_color();
        }

        private void change_color()
        {
            int green;
            int power;
            foreach(Button button in buttons)
            {
                green = 255;
                if (button.Text == "")
                {
                    button.BackColor = Color.FromArgb(255, 255, 230);
                }
                else
                {
                    power = (int)(Math.Log(int.Parse(button.Text)) /Math.Log(2.0));
                    for (int n = 1; n < 12; n++)
                    {
                        green -= 20;
                        if (power == n)
                        {
                            button.BackColor = Color.FromArgb(255, green, 230);
                        }
                    }
                }
            }
        }
        public void generate_start_numbers()
        {
            Button[] buttons_table = { this.button1, this.button2, this.button3, this.button4,
                                        this.button8,this.button7, this.button6, this.button5,
                                        this.button12,this.button11, this.button10, this.button9,
                                        this.button16, this.button15, this.button14, this.button13};

            buttons = buttons_table;
            int button_number;
            Random random = new Random();
            random_index = random.Next(1);

            for (int draw_number = 0; draw_number < 2; draw_number++)
            {
                do
                {
                    button_number = random.Next(15);
                    random_number = start_numbers[random_index];

                    for (int i = 0; i < buttons.Length; i++)
                    {
                        if (i == button_number)
                        {
                            buttons[i].Text = random_number.ToString();
                        }
                    }
                } while (drawn_numbers.Contains(button_number));
                drawn_numbers.Add(button_number);
            }
        }

        public void generate_new_numbers()
        {
            int button_number;
            int empty_buttons_length;
            int empty_button_index;
            Random random = new Random();
            random_number = start_numbers[random_index];
            List<int> empty_buttons = new List<int>();

            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].Text == "")
                {
                    empty_buttons.Add(i);
                }
            }
            empty_buttons_length = empty_buttons.Count;
            empty_button_index = random.Next(empty_buttons_length);
            button_number = empty_buttons[empty_button_index];

            for (int i = 0; i < buttons.Length; i++)
            {
                if (button_number == i)
                {
                    buttons[i].Text = random_number.ToString();
                }
            }
        }

        public string[] combine(string[] sequence)
        {
            int sequence_index = 0;
            foreach (string element in sequence)
            {
                if (sequence_index >= 1)
                {
                    if (sequence[sequence_index] == sequence[sequence_index - 1] && sequence[sequence_index] != "")
                    {
                        sequence[sequence_index - 1] = (int.Parse(sequence[sequence_index]) * 2).ToString();
                        sequence[sequence_index] = "";
                        score += (int.Parse(sequence[sequence_index - 1]));
                        score_label.Text = "SCORE: " + score;
                        combined_numbers++;
                    }
                }
                sequence_index++;
            }
            return order(sequence);
        }

        public static string[] order(string[] sequence)
        {
            int index_number;
            string[] ordered_sequence = new string[4] { "", "", "", "" };
            
            if(direction[0] == true || direction[2] == true)
            {
                index_number = 3;
                for (int sequence_index = 0; sequence_index < sequence.Length; sequence_index++)
                {
                    if (sequence[sequence_index] != "")
                    {
                        ordered_sequence[index_number] = sequence[sequence_index];
                        index_number--;
                    }
                }
            }
            else if(direction[1] == true || direction[3] == true)
            {
                index_number = 0;
                for (int sequence_index = sequence.Length - 1; sequence_index >= 0; sequence_index--)
                {
                    if (sequence[sequence_index] != "")
                    {
                        ordered_sequence[index_number] = sequence[sequence_index];
                        index_number++;
                    }
                }
            }
            return ordered_sequence;
        }

        public string[,] enter_new_row(int i, string[] ordered_sequence)
        {
            int n = 0;
            for (int j = 3; j >= 0; j--)
            {
                new_row[i, j] = ordered_sequence[n];
                n++;
            }
            return new_row;
        }

        public void update_buttons(string[,] new_table)
        {
            int button_index = 0;
            if(direction[0] == true || direction[1] == true)
            {
                for (int i = 0; i < new_table.GetLength(0); i++)
                {
                    for (int j = 0; j < new_table.GetLength(1); j++)
                    {
                        buttons[button_index].Text = new_table[i, j];
                        button_index++;
                    }
                }
            }
            else if (direction[2] == true || direction[3] == true)
            {
                for (int i = 0; i < new_table.GetLength(0); i++)
                {
                    for (int j = 0; j < new_table.GetLength(1); j++)
                    {
                        buttons[button_index].Text = new_table[j, i];
                        button_index++;
                    }
                }
            }
        }
        public void move()
        {

            string[,] rows_table = { { this.button1.Text, this.button2.Text, this.button3.Text, this.button4.Text},
                                     { this.button8.Text, this.button7.Text, this.button6.Text, this.button5.Text},
                                     { this.button12.Text,this.button11.Text, this.button10.Text, this.button9.Text},
                                     { this.button16.Text, this.button15.Text, this.button14.Text, this.button13.Text}};

            buttons_structure = rows_table;

            for (int i = 0; i < rows_table.GetLength(0); i++)
            {
                for (int j = 0; j < rows_table.GetLength(1); j++)
                {
                    if(direction[0] == true || direction[1] == true)
                    {
                        if (rows_table[i, j] != "")
                        {
                            sequence[count] = rows_table[i, j];
                            count++;
                        }
                    }
                    else if(direction[2] == true || direction[3] == true)
                    {
                        if (rows_table[j, i] != "")
                        {
                            sequence[count] = rows_table[j, i];
                            count++;
                        }
                    }
                }
                count = 0;
                ordered_sequence = combine(sequence);
                new_table = enter_new_row(i, ordered_sequence);
                sequence = new string[4] { "", "", "", "" };
            }
            end_game_check();
            combined_numbers = 0;
            if(end == false)
            {
                update_buttons(new_table);
                generate_new_numbers();
                change_color();
            }
        }

        private void end_game_check()
        {
            int active_buttons = 0;
            foreach(Button button in buttons)
            {
                if(button.Text != "")
                {
                    active_buttons++;
                    if (active_buttons >= buttons.Length && combined_numbers == 0)
                    {
                        end = true;
                        your_score_label.Text = "SCORE: " + score;
                        lose_or_win_label.Text = "LOOSE";
                        end_game.Visible = lose_or_win_label.Visible = label1.Visible = your_score_label.Visible = try_again_button.Visible =
                            exit_game_button.Visible = try_again_button.Enabled = exit_game_button.Enabled = true;
                    }
                }
            }
            win();
        }

        private void win()
        {
            foreach(Button button in buttons)
            {
                if(button.Text == "2048")
                {
                    end = true;
                    your_score_label.Text = "SCORE: " + score;
                    lose_or_win_label.Text = "WIN!";
                    end_game.Visible = lose_or_win_label.Visible = label1.Visible = your_score_label.Visible = try_again_button.Visible =
                                exit_game_button.Visible = try_again_button.Enabled = exit_game_button.Enabled = true;
                }
            }
        }

        private void left_button_Click(object sender, EventArgs e)
        {
            direction[0] = true;
            move();
            direction[0] = false;
        }
        private void right_button_Click(object sender, EventArgs e)
        {
            direction[1] = true;
            move();
            direction[1] = false;
        }

        private void top_button_Click(object sender, EventArgs e)
        {
            direction[2] = true;
            move();
            direction[2] = false;
        }

        private void down_button_Click(object sender, EventArgs e)
        {
            direction[3] = true;
            move();
            direction[3] = false;
        }
        private void buttons_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'a':
                    direction[0] = true;
                    move();
                    direction[0] = false;
                    break;

                case 'd':
                    direction[1] = true;
                    move();
                    direction[1] = false;
                    break;
                case 'w':
                    direction[2] = true;
                    move();
                    direction[2] = false;
                    break;

                case 's':
                    direction[3] = true;
                    move();
                    direction[3] = false;
                    break;
            }
        }

        private void exit_game_button_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void try_again_button_Click(object sender, EventArgs e)
        {
            foreach(Button button in buttons)
            {
                button.Text = "";
                button.BackColor = Color.FromArgb(255, 255, 230);
            }
            score = 0;
            score_label.Text = "SCORE: " + score;
            end_game.Visible = lose_or_win_label.Visible = label1.Visible = your_score_label.Visible = try_again_button.Visible =
            exit_game_button.Visible = try_again_button.Enabled = exit_game_button.Enabled = false;
            generate_start_numbers();
            change_color();
        }
    }
}
