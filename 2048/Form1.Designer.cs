
using System.Collections.Generic;
using System.Windows.Forms;

namespace _2048
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        List<int> drawn_numbers = new List<int>();
        int[] start_numbers = { 2, 4 };
        static Button[] buttons = new Button[16];
        static bool[] direction = new bool[4] { false, false, false, false};    //left, right, top, down
        string[,] buttons_structure = new string[4,4];
        string[] sequence = new string[4] { "", "", "", "" };
        string[] ordered_sequence = new string[4] { "", "", "", "" };
        string[,] new_table = new string[4,4];
        string[,] new_row = new string[4, 4];
        int count = 0;
        int random_number;
        int random_index;
        int score = 0;
        int combined_numbers;
        bool end = false;


        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.top_button = new System.Windows.Forms.Button();
            this.down_button = new System.Windows.Forms.Button();
            this.left_button = new System.Windows.Forms.Button();
            this.right_button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.end_game = new System.Windows.Forms.PictureBox();
            this.lose_or_win_label = new System.Windows.Forms.Label();
            this.score_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.exit_game_button = new System.Windows.Forms.Button();
            this.try_again_button = new System.Windows.Forms.Button();
            this.your_score_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.end_game)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(47, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 70);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(123, 99);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(70, 70);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(199, 99);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(70, 70);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.button4.Enabled = false;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(275, 99);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(70, 70);
            this.button4.TabIndex = 3;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.button5.Enabled = false;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(275, 175);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(70, 70);
            this.button5.TabIndex = 7;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.button6.Enabled = false;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.button6.Location = new System.Drawing.Point(199, 175);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(70, 70);
            this.button6.TabIndex = 6;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.button7.Enabled = false;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button7.ForeColor = System.Drawing.Color.Black;
            this.button7.Location = new System.Drawing.Point(123, 175);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(70, 70);
            this.button7.TabIndex = 5;
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.button8.Enabled = false;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button8.ForeColor = System.Drawing.Color.Black;
            this.button8.Location = new System.Drawing.Point(47, 175);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(70, 70);
            this.button8.TabIndex = 4;
            this.button8.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.button9.Enabled = false;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button9.ForeColor = System.Drawing.Color.Black;
            this.button9.Location = new System.Drawing.Point(275, 251);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(70, 70);
            this.button9.TabIndex = 11;
            this.button9.UseVisualStyleBackColor = false;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.button10.Enabled = false;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button10.ForeColor = System.Drawing.Color.Black;
            this.button10.Location = new System.Drawing.Point(199, 251);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(70, 70);
            this.button10.TabIndex = 10;
            this.button10.UseVisualStyleBackColor = false;
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.button11.Enabled = false;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button11.ForeColor = System.Drawing.Color.Black;
            this.button11.Location = new System.Drawing.Point(123, 251);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(70, 70);
            this.button11.TabIndex = 9;
            this.button11.UseVisualStyleBackColor = false;
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.button12.Enabled = false;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button12.ForeColor = System.Drawing.Color.Black;
            this.button12.Location = new System.Drawing.Point(47, 251);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(70, 70);
            this.button12.TabIndex = 8;
            this.button12.UseVisualStyleBackColor = false;
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.button13.Enabled = false;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button13.ForeColor = System.Drawing.Color.Black;
            this.button13.Location = new System.Drawing.Point(275, 327);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(70, 70);
            this.button13.TabIndex = 15;
            this.button13.UseVisualStyleBackColor = false;
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.button14.Enabled = false;
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button14.ForeColor = System.Drawing.Color.Black;
            this.button14.Location = new System.Drawing.Point(199, 327);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(70, 70);
            this.button14.TabIndex = 14;
            this.button14.UseVisualStyleBackColor = false;
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.button15.Enabled = false;
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button15.ForeColor = System.Drawing.Color.Black;
            this.button15.Location = new System.Drawing.Point(123, 327);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(70, 70);
            this.button15.TabIndex = 13;
            this.button15.UseVisualStyleBackColor = false;
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.button16.Enabled = false;
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button16.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button16.ForeColor = System.Drawing.Color.Black;
            this.button16.Location = new System.Drawing.Point(47, 327);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(70, 70);
            this.button16.TabIndex = 12;
            this.button16.UseVisualStyleBackColor = false;
            // 
            // top_button
            // 
            this.top_button.BackColor = System.Drawing.Color.PeachPuff;
            this.top_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.top_button.Location = new System.Drawing.Point(503, 116);
            this.top_button.Name = "top_button";
            this.top_button.Size = new System.Drawing.Size(70, 70);
            this.top_button.TabIndex = 16;
            this.top_button.Text = "top";
            this.top_button.UseVisualStyleBackColor = false;
            this.top_button.Click += new System.EventHandler(this.top_button_Click);
            this.top_button.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.buttons_KeyPress);
            // 
            // down_button
            // 
            this.down_button.BackColor = System.Drawing.Color.PeachPuff;
            this.down_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.down_button.Location = new System.Drawing.Point(503, 268);
            this.down_button.Name = "down_button";
            this.down_button.Size = new System.Drawing.Size(70, 70);
            this.down_button.TabIndex = 17;
            this.down_button.Text = "down";
            this.down_button.UseVisualStyleBackColor = false;
            this.down_button.Click += new System.EventHandler(this.down_button_Click);
            this.down_button.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.buttons_KeyPress);
            // 
            // left_button
            // 
            this.left_button.BackColor = System.Drawing.Color.PeachPuff;
            this.left_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.left_button.Location = new System.Drawing.Point(430, 192);
            this.left_button.Name = "left_button";
            this.left_button.Size = new System.Drawing.Size(70, 70);
            this.left_button.TabIndex = 18;
            this.left_button.Text = "left";
            this.left_button.UseVisualStyleBackColor = false;
            this.left_button.Click += new System.EventHandler(this.left_button_Click);
            this.left_button.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.buttons_KeyPress);
            // 
            // right_button
            // 
            this.right_button.BackColor = System.Drawing.Color.PeachPuff;
            this.right_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.right_button.Location = new System.Drawing.Point(579, 192);
            this.right_button.Name = "right_button";
            this.right_button.Size = new System.Drawing.Size(70, 70);
            this.right_button.TabIndex = 19;
            this.right_button.Text = "right";
            this.right_button.UseVisualStyleBackColor = false;
            this.right_button.Click += new System.EventHandler(this.right_button_Click);
            this.right_button.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.buttons_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.PapayaWhip;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(37, 88);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 320);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // end_game
            // 
            this.end_game.BackColor = System.Drawing.Color.AntiqueWhite;
            this.end_game.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.end_game.Enabled = false;
            this.end_game.Location = new System.Drawing.Point(159, 19);
            this.end_game.Name = "end_game";
            this.end_game.Size = new System.Drawing.Size(343, 407);
            this.end_game.TabIndex = 21;
            this.end_game.TabStop = false;
            this.end_game.Visible = false;
            // 
            // lose_or_win_label
            // 
            this.lose_or_win_label.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lose_or_win_label.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lose_or_win_label.Location = new System.Drawing.Point(228, 34);
            this.lose_or_win_label.Name = "lose_or_win_label";
            this.lose_or_win_label.Size = new System.Drawing.Size(206, 62);
            this.lose_or_win_label.TabIndex = 22;
            this.lose_or_win_label.Text = "DEFAT";
            this.lose_or_win_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lose_or_win_label.Visible = false;
            // 
            // score_label
            // 
            this.score_label.BackColor = System.Drawing.Color.Transparent;
            this.score_label.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.score_label.Location = new System.Drawing.Point(123, 19);
            this.score_label.Name = "score_label";
            this.score_label.Size = new System.Drawing.Size(206, 46);
            this.score_label.TabIndex = 23;
            this.score_label.Text = "SCORE: ";
            this.score_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(175, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 37);
            this.label1.TabIndex = 24;
            this.label1.Text = "Do you want to try again?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // exit_game_button
            // 
            this.exit_game_button.BackColor = System.Drawing.Color.Wheat;
            this.exit_game_button.Enabled = false;
            this.exit_game_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit_game_button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.exit_game_button.Location = new System.Drawing.Point(363, 288);
            this.exit_game_button.Name = "exit_game_button";
            this.exit_game_button.Size = new System.Drawing.Size(93, 50);
            this.exit_game_button.TabIndex = 25;
            this.exit_game_button.Text = "NO";
            this.exit_game_button.UseVisualStyleBackColor = false;
            this.exit_game_button.Visible = false;
            this.exit_game_button.Click += new System.EventHandler(this.exit_game_button_Click);
            // 
            // try_again_button
            // 
            this.try_again_button.BackColor = System.Drawing.Color.Wheat;
            this.try_again_button.Enabled = false;
            this.try_again_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.try_again_button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.try_again_button.Location = new System.Drawing.Point(208, 288);
            this.try_again_button.Name = "try_again_button";
            this.try_again_button.Size = new System.Drawing.Size(93, 50);
            this.try_again_button.TabIndex = 26;
            this.try_again_button.Text = "YES";
            this.try_again_button.UseVisualStyleBackColor = false;
            this.try_again_button.Visible = false;
            this.try_again_button.Click += new System.EventHandler(this.try_again_button_Click);
            // 
            // your_score_label
            // 
            this.your_score_label.BackColor = System.Drawing.Color.AntiqueWhite;
            this.your_score_label.Enabled = false;
            this.your_score_label.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.your_score_label.Location = new System.Drawing.Point(208, 147);
            this.your_score_label.Name = "your_score_label";
            this.your_score_label.Size = new System.Drawing.Size(248, 58);
            this.your_score_label.TabIndex = 27;
            this.your_score_label.Text = "Your score: ";
            this.your_score_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.your_score_label.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(686, 450);
            this.Controls.Add(this.your_score_label);
            this.Controls.Add(this.try_again_button);
            this.Controls.Add(this.exit_game_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lose_or_win_label);
            this.Controls.Add(this.end_game);
            this.Controls.Add(this.right_button);
            this.Controls.Add(this.left_button);
            this.Controls.Add(this.down_button);
            this.Controls.Add(this.top_button);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.score_label);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.end_game)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private Button top_button;
        private Button down_button;
        private Button left_button;
        private Button right_button;
        private PictureBox pictureBox1;
        private PictureBox end_game;
        private Label lose_or_win_label;
        private Label score_label;
        private Label label1;
        private Button exit_game_button;
        private Button try_again_button;
        private Label your_score_label;
    }
}

