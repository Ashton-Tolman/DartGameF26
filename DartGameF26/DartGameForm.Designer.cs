namespace DartGameF26
{
    partial class DartGameForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            components = new System.ComponentModel.Container();
            DartPictureBox = new PictureBox();
            ExitButton = new Button();
            NewRoundButton = new Button();
            ReviewButton = new Button();
            ToolTip = new ToolTip(components);
            RoundListBox = new ListBox();
            ModeLabel = new Label();
            RoundLabel = new Label();
            ThrowLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)DartPictureBox).BeginInit();
            SuspendLayout();
            // 
            // DartPictureBox
            // 
            DartPictureBox.Location = new Point(14, 12);
            DartPictureBox.Name = "DartPictureBox";
            DartPictureBox.Size = new Size(600, 600);
            DartPictureBox.TabIndex = 1;
            DartPictureBox.TabStop = false;
            ToolTip.SetToolTip(DartPictureBox, "Try to hit a bullseye!");
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(400, 631);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(142, 69);
            ExitButton.TabIndex = 3;
            ExitButton.Text = "E&xit";
            ToolTip.SetToolTip(ExitButton, "Exit the game");
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // NewRoundButton
            // 
            NewRoundButton.Location = new Point(252, 631);
            NewRoundButton.Name = "NewRoundButton";
            NewRoundButton.Size = new Size(142, 69);
            NewRoundButton.TabIndex = 1;
            NewRoundButton.Text = "New Round";
            ToolTip.SetToolTip(NewRoundButton, "Save Throws and Start New Round");
            NewRoundButton.UseVisualStyleBackColor = true;
            NewRoundButton.Click += NewRoundButton_Click;
            // 
            // ReviewButton
            // 
            ReviewButton.Location = new Point(104, 631);
            ReviewButton.Name = "ReviewButton";
            ReviewButton.Size = new Size(142, 69);
            ReviewButton.TabIndex = 0;
            ReviewButton.Text = "&Review";
            ToolTip.SetToolTip(ReviewButton, "Load old games into list box");
            ReviewButton.UseVisualStyleBackColor = true;
            ReviewButton.Click += ReviewButton_Click;
            // 
            // RoundListBox
            // 
            RoundListBox.FormattingEnabled = true;
            RoundListBox.Location = new Point(623, 12);
            RoundListBox.Name = "RoundListBox";
            RoundListBox.Size = new Size(343, 598);
            RoundListBox.TabIndex = 4;
            RoundListBox.SelectedIndexChanged += RoundListBox_SelectedIndexChanged;
            // 
            // ModeLabel
            // 
            ModeLabel.AutoSize = true;
            ModeLabel.Location = new Point(584, 652);
            ModeLabel.Name = "ModeLabel";
            ModeLabel.Size = new Size(78, 27);
            ModeLabel.TabIndex = 5;
            ModeLabel.Text = "Mode:-";
            // 
            // RoundLabel
            // 
            RoundLabel.AutoSize = true;
            RoundLabel.Location = new Point(716, 652);
            RoundLabel.Name = "RoundLabel";
            RoundLabel.Size = new Size(89, 27);
            RoundLabel.TabIndex = 6;
            RoundLabel.Text = "Round:-";
            // 
            // ThrowLabel
            // 
            ThrowLabel.AutoSize = true;
            ThrowLabel.Location = new Point(853, 652);
            ThrowLabel.Name = "ThrowLabel";
            ThrowLabel.Size = new Size(89, 27);
            ThrowLabel.TabIndex = 7;
            ThrowLabel.Text = "Throw:-";
            // 
            // DartGameForm
            // 
            AutoScaleDimensions = new SizeF(11F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(978, 742);
            Controls.Add(ThrowLabel);
            Controls.Add(RoundLabel);
            Controls.Add(ModeLabel);
            Controls.Add(RoundListBox);
            Controls.Add(ReviewButton);
            Controls.Add(NewRoundButton);
            Controls.Add(ExitButton);
            Controls.Add(DartPictureBox);
            Font = new Font("Source Code Pro", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MaximumSize = new Size(1000, 1000);
            MinimumSize = new Size(651, 798);
            Name = "DartGameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dart Game Simulator";
            ((System.ComponentModel.ISupportInitialize)DartPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox DartPictureBox;
        private Button ExitButton;
        private Button NewRoundButton;
        private Button ReviewButton;
        private ToolTip ToolTip;
        private ListBox RoundListBox;
        private Label ModeLabel;
        private Label RoundLabel;
        private Label ThrowLabel;
    }
}
