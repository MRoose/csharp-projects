namespace Launcher
{
    partial class Launcher
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btEmployee = new System.Windows.Forms.Button();
            this.btManager = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.btRS = new System.Windows.Forms.Button();
            this.btZRO = new System.Windows.Forms.Button();
            this.btRO = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btEmployee);
            this.groupBox1.Controls.Add(this.btRO);
            this.groupBox1.Controls.Add(this.btZRO);
            this.groupBox1.Controls.Add(this.btRS);
            this.groupBox1.Controls.Add(this.btManager);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 275);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выберите вашу должность :";
            // 
            // btEmployee
            // 
            this.btEmployee.BackColor = System.Drawing.Color.Yellow;
            this.btEmployee.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btEmployee.Location = new System.Drawing.Point(6, 25);
            this.btEmployee.Name = "btEmployee";
            this.btEmployee.Size = new System.Drawing.Size(306, 74);
            this.btEmployee.TabIndex = 0;
            this.btEmployee.Text = "Сотрудник";
            this.btEmployee.UseVisualStyleBackColor = false;
            this.btEmployee.Click += new System.EventHandler(this.btEmployee_Click);
            // 
            // btManager
            // 
            this.btManager.BackColor = System.Drawing.Color.Yellow;
            this.btManager.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btManager.Location = new System.Drawing.Point(6, 107);
            this.btManager.Name = "btManager";
            this.btManager.Size = new System.Drawing.Size(147, 75);
            this.btManager.TabIndex = 1;
            this.btManager.Text = "РГ";
            this.btManager.UseVisualStyleBackColor = false;
            this.btManager.Click += new System.EventHandler(this.btManager_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(318, 275);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 277);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(312, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 303);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Жду выбор";
            // 
            // btRS
            // 
            this.btRS.BackColor = System.Drawing.Color.Yellow;
            this.btRS.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btRS.Location = new System.Drawing.Point(165, 107);
            this.btRS.Name = "btRS";
            this.btRS.Size = new System.Drawing.Size(147, 75);
            this.btRS.TabIndex = 1;
            this.btRS.Text = "РС";
            this.btRS.UseVisualStyleBackColor = false;
            this.btRS.Click += new System.EventHandler(this.btManager_Click);
            // 
            // btZRO
            // 
            this.btZRO.BackColor = System.Drawing.Color.Yellow;
            this.btZRO.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btZRO.Location = new System.Drawing.Point(6, 190);
            this.btZRO.Name = "btZRO";
            this.btZRO.Size = new System.Drawing.Size(147, 75);
            this.btZRO.TabIndex = 1;
            this.btZRO.Text = "Зам РО";
            this.btZRO.UseVisualStyleBackColor = false;
            this.btZRO.Click += new System.EventHandler(this.btManager_Click);
            // 
            // btRO
            // 
            this.btRO.BackColor = System.Drawing.Color.Yellow;
            this.btRO.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btRO.Location = new System.Drawing.Point(165, 190);
            this.btRO.Name = "btRO";
            this.btRO.Size = new System.Drawing.Size(147, 75);
            this.btRO.TabIndex = 1;
            this.btRO.Text = "РО";
            this.btRO.UseVisualStyleBackColor = false;
            this.btRO.Click += new System.EventHandler(this.btManager_Click);
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 322);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Launcher";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btEmployee;
        private System.Windows.Forms.Button btManager;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btRO;
        private System.Windows.Forms.Button btZRO;
        private System.Windows.Forms.Button btRS;
    }
}

