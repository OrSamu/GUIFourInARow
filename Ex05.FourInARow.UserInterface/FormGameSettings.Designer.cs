
namespace Ex05.FourInARow.UserInterface
{
    partial class FormGameSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelPlayerOne = new System.Windows.Forms.Label();
            this.labelRows = new System.Windows.Forms.Label();
            this.labelCols = new System.Windows.Forms.Label();
            this.numericUpDownRows = new System.Windows.Forms.NumericUpDown();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelPlayers = new System.Windows.Forms.Label();
            this.labelBoardSize = new System.Windows.Forms.Label();
            this.checkBoxPlayerTwo = new System.Windows.Forms.CheckBox();
            this.textBoxPlayerOneName = new System.Windows.Forms.TextBox();
            this.textBoxPlayerTwoName = new System.Windows.Forms.TextBox();
            this.numericUpDownCols = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCols)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPlayerOne
            // 
            this.labelPlayerOne.AutoSize = true;
            this.labelPlayerOne.Location = new System.Drawing.Point(30, 31);
            this.labelPlayerOne.Name = "labelPlayerOne";
            this.labelPlayerOne.Size = new System.Drawing.Size(48, 13);
            this.labelPlayerOne.TabIndex = 2;
            this.labelPlayerOne.Text = "Player 1:";
            // 
            // labelRows
            // 
            this.labelRows.AutoSize = true;
            this.labelRows.Location = new System.Drawing.Point(30, 124);
            this.labelRows.Name = "labelRows";
            this.labelRows.Size = new System.Drawing.Size(37, 13);
            this.labelRows.TabIndex = 7;
            this.labelRows.Text = "Rows:";
            // 
            // labelCols
            // 
            this.labelCols.AutoSize = true;
            this.labelCols.Location = new System.Drawing.Point(112, 124);
            this.labelCols.Name = "labelCols";
            this.labelCols.Size = new System.Drawing.Size(50, 13);
            this.labelCols.TabIndex = 9;
            this.labelCols.Text = "Columns:";
            // 
            // numericUpDownRows
            // 
            this.numericUpDownRows.Location = new System.Drawing.Point(70, 122);
            this.numericUpDownRows.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownRows.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownRows.Name = "numericUpDownRows";
            this.numericUpDownRows.Size = new System.Drawing.Size(39, 20);
            this.numericUpDownRows.TabIndex = 6;
            this.numericUpDownRows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 160);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(213, 23);
            this.buttonStart.TabIndex = 10;
            this.buttonStart.Text = "Start!";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelPlayers
            // 
            this.labelPlayers.AutoSize = true;
            this.labelPlayers.Location = new System.Drawing.Point(12, 9);
            this.labelPlayers.Name = "labelPlayers";
            this.labelPlayers.Size = new System.Drawing.Size(44, 13);
            this.labelPlayers.TabIndex = 0;
            this.labelPlayers.Text = "Players:";
            // 
            // labelBoardSize
            // 
            this.labelBoardSize.AutoSize = true;
            this.labelBoardSize.Location = new System.Drawing.Point(12, 99);
            this.labelBoardSize.Name = "labelBoardSize";
            this.labelBoardSize.Size = new System.Drawing.Size(61, 13);
            this.labelBoardSize.TabIndex = 5;
            this.labelBoardSize.Text = "Board Size:";
            // 
            // checkBoxPlayerTwo
            // 
            this.checkBoxPlayerTwo.AutoSize = true;
            this.checkBoxPlayerTwo.Location = new System.Drawing.Point(15, 58);
            this.checkBoxPlayerTwo.Name = "checkBoxPlayerTwo";
            this.checkBoxPlayerTwo.Size = new System.Drawing.Size(67, 17);
            this.checkBoxPlayerTwo.TabIndex = 4;
            this.checkBoxPlayerTwo.Text = "Player 2:";
            this.checkBoxPlayerTwo.UseVisualStyleBackColor = true;
            this.checkBoxPlayerTwo.CheckedChanged += new System.EventHandler(this.checkBoxPlayerTwo_CheckedChanged);
            // 
            // textBoxPlayerOneName
            // 
            this.textBoxPlayerOneName.Location = new System.Drawing.Point(84, 28);
            this.textBoxPlayerOneName.Name = "textBoxPlayerOneName";
            this.textBoxPlayerOneName.Size = new System.Drawing.Size(100, 20);
            this.textBoxPlayerOneName.TabIndex = 1;
            // 
            // textBoxPlayerTwoName
            // 
            this.textBoxPlayerTwoName.Enabled = false;
            this.textBoxPlayerTwoName.Location = new System.Drawing.Point(84, 56);
            this.textBoxPlayerTwoName.Name = "textBoxPlayerTwoName";
            this.textBoxPlayerTwoName.Size = new System.Drawing.Size(100, 20);
            this.textBoxPlayerTwoName.TabIndex = 3;
            this.textBoxPlayerTwoName.Text = "[Computer]";
            // 
            // numericUpDownCols
            // 
            this.numericUpDownCols.Location = new System.Drawing.Point(165, 122);
            this.numericUpDownCols.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownCols.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownCols.Name = "numericUpDownCols";
            this.numericUpDownCols.Size = new System.Drawing.Size(39, 20);
            this.numericUpDownCols.TabIndex = 8;
            this.numericUpDownCols.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // FormGameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 197);
            this.Controls.Add(this.numericUpDownCols);
            this.Controls.Add(this.textBoxPlayerTwoName);
            this.Controls.Add(this.textBoxPlayerOneName);
            this.Controls.Add(this.checkBoxPlayerTwo);
            this.Controls.Add(this.labelBoardSize);
            this.Controls.Add(this.labelPlayers);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.numericUpDownRows);
            this.Controls.Add(this.labelCols);
            this.Controls.Add(this.labelRows);
            this.Controls.Add(this.labelPlayerOne);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormGameSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormGameSettings";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPlayerOne;
        private System.Windows.Forms.Label labelRows;
        private System.Windows.Forms.Label labelCols;
        private System.Windows.Forms.NumericUpDown numericUpDownRows;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelPlayers;
        private System.Windows.Forms.Label labelBoardSize;
        private System.Windows.Forms.CheckBox checkBoxPlayerTwo;
        private System.Windows.Forms.TextBox textBoxPlayerOneName;
        private System.Windows.Forms.TextBox textBoxPlayerTwoName;
        private System.Windows.Forms.NumericUpDown numericUpDownCols;
    }
}