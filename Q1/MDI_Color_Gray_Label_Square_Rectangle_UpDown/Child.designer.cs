namespace MDI_Color_Gray_Label_Square_Rectangle_UpDown
{
    partial class Child
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
            this.labelMaxOrMin = new System.Windows.Forms.Label();
            this.Min_Max_label = new System.Windows.Forms.Label();
            this.comboBoxRecOrSqr = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelMaxOrMin
            // 
            this.labelMaxOrMin.BackColor = System.Drawing.Color.White;
            this.labelMaxOrMin.Location = new System.Drawing.Point(1, 1);
            this.labelMaxOrMin.Name = "labelMaxOrMin";
            this.labelMaxOrMin.Size = new System.Drawing.Size(31, 37);
            this.labelMaxOrMin.TabIndex = 15;
            // 
            // Min_Max_label
            // 
            this.Min_Max_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Min_Max_label.Location = new System.Drawing.Point(947, 18);
            this.Min_Max_label.Name = "Min_Max_label";
            this.Min_Max_label.Size = new System.Drawing.Size(84, 47);
            this.Min_Max_label.TabIndex = 13;
            // 
            // comboBoxRecOrSqr
            // 
            this.comboBoxRecOrSqr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRecOrSqr.FormattingEnabled = true;
            this.comboBoxRecOrSqr.Location = new System.Drawing.Point(1085, 22);
            this.comboBoxRecOrSqr.Name = "comboBoxRecOrSqr";
            this.comboBoxRecOrSqr.Size = new System.Drawing.Size(121, 28);
            this.comboBoxRecOrSqr.TabIndex = 16;
            // 
            // Child
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1243, 284);
            this.Controls.Add(this.comboBoxRecOrSqr);
            this.Controls.Add(this.labelMaxOrMin);
            this.Controls.Add(this.Min_Max_label);
            this.Name = "Child";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Child_FormClosing);
            this.ResumeLayout(false);

        }


        #endregion
        public System.Windows.Forms.Label labelMaxOrMin;
        public System.Windows.Forms.Label Min_Max_label;
        private System.Windows.Forms.ComboBox comboBoxRecOrSqr;
    }
}