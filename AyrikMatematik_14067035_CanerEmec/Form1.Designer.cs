namespace AyrikMatematik_14067035_CanerEmec
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.gboxMethod = new System.Windows.Forms.GroupBox();
            this.cmbMethods = new System.Windows.Forms.ComboBox();
            this.gboxInput = new System.Windows.Forms.GroupBox();
            this.gboxOutput = new System.Windows.Forms.GroupBox();
            this.gboxRun = new System.Windows.Forms.GroupBox();
            this.gboxMethod.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-3, 482);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(804, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "CANER EMEÇ 14067035 -- ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gboxMethod
            // 
            this.gboxMethod.BackColor = System.Drawing.SystemColors.GrayText;
            this.gboxMethod.Controls.Add(this.cmbMethods);
            this.gboxMethod.ForeColor = System.Drawing.Color.White;
            this.gboxMethod.Location = new System.Drawing.Point(12, 12);
            this.gboxMethod.Name = "gboxMethod";
            this.gboxMethod.Size = new System.Drawing.Size(289, 56);
            this.gboxMethod.TabIndex = 1;
            this.gboxMethod.TabStop = false;
            this.gboxMethod.Text = "Methods";
            // 
            // cmbMethods
            // 
            this.cmbMethods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMethods.FormattingEnabled = true;
            this.cmbMethods.Items.AddRange(new object[] {
            "Newton Raphson",
            "Secant",
            "Simple Iteration",
            "False Position",
            "BiSection",
            "Matrix İnverse",
            "Graphical",
            "Gauss Elimination",
            "Gauss Jordan Elimination",
            "Simpson 1/3",
            "Simpson 3/8",
            "Trapezoidal",
            "Jacobi Iteration",
            "Gauss Seidel"});
            this.cmbMethods.Location = new System.Drawing.Point(6, 19);
            this.cmbMethods.Name = "cmbMethods";
            this.cmbMethods.Size = new System.Drawing.Size(277, 21);
            this.cmbMethods.TabIndex = 0;
            this.cmbMethods.SelectedIndexChanged += new System.EventHandler(this.CmbMethods_SelectedIndexChanged);
            // 
            // gboxInput
            // 
            this.gboxInput.BackColor = System.Drawing.SystemColors.GrayText;
            this.gboxInput.ForeColor = System.Drawing.Color.White;
            this.gboxInput.Location = new System.Drawing.Point(12, 83);
            this.gboxInput.Name = "gboxInput";
            this.gboxInput.Size = new System.Drawing.Size(289, 333);
            this.gboxInput.TabIndex = 2;
            this.gboxInput.TabStop = false;
            this.gboxInput.Text = "Inputs";
            // 
            // gboxOutput
            // 
            this.gboxOutput.BackColor = System.Drawing.SystemColors.GrayText;
            this.gboxOutput.ForeColor = System.Drawing.Color.White;
            this.gboxOutput.Location = new System.Drawing.Point(307, 12);
            this.gboxOutput.Name = "gboxOutput";
            this.gboxOutput.Size = new System.Drawing.Size(481, 404);
            this.gboxOutput.TabIndex = 3;
            this.gboxOutput.TabStop = false;
            this.gboxOutput.Text = "Outputs";
            // 
            // gboxRun
            // 
            this.gboxRun.BackColor = System.Drawing.SystemColors.GrayText;
            this.gboxRun.ForeColor = System.Drawing.Color.White;
            this.gboxRun.Location = new System.Drawing.Point(12, 422);
            this.gboxRun.Name = "gboxRun";
            this.gboxRun.Size = new System.Drawing.Size(776, 57);
            this.gboxRun.TabIndex = 4;
            this.gboxRun.TabStop = false;
            this.gboxRun.Text = "Confirm And Run";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(800, 505);
            this.Controls.Add(this.gboxRun);
            this.Controls.Add(this.gboxOutput);
            this.Controls.Add(this.gboxInput);
            this.Controls.Add(this.gboxMethod);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Caner Emec - Ayrik Matematik Odevi";
            this.gboxMethod.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gboxMethod;
        private System.Windows.Forms.ComboBox cmbMethods;
        private System.Windows.Forms.GroupBox gboxInput;
        private System.Windows.Forms.GroupBox gboxOutput;
        private System.Windows.Forms.GroupBox gboxRun;
    }
}

