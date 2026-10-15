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
            pictureBox1 = new PictureBox();
            ExitButton = new Button();
            NewRoundButton = new Button();
            ReviewButton = new Button();
            ToolTip = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1150, 501);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(631, 519);
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
            NewRoundButton.Location = new Point(483, 519);
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
            ReviewButton.Location = new Point(335, 519);
            ReviewButton.Name = "ReviewButton";
            ReviewButton.Size = new Size(142, 69);
            ReviewButton.TabIndex = 0;
            ReviewButton.Text = "Review";
            ToolTip.SetToolTip(ReviewButton, "Check Past Rounds ");
            ReviewButton.UseVisualStyleBackColor = true;
            ReviewButton.Click += ReviewButton_Click;
            // 
            // DartGameForm
            // 
            AutoScaleDimensions = new SizeF(11F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1176, 594);
            Controls.Add(ReviewButton);
            Controls.Add(NewRoundButton);
            Controls.Add(ExitButton);
            Controls.Add(pictureBox1);
            Font = new Font("Source Code Pro", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "DartGameForm";
            Text = "Dart Game Simulator";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox1;
        private Button ExitButton;
        private Button NewRoundButton;
        private Button ReviewButton;
        private ToolTip ToolTip;
    }
}
