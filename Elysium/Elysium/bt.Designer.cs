namespace Elysium
{
    partial class bt
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.BackColor = System.Drawing.Color.Yellow;
            this.btOK.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btOK.Location = new System.Drawing.Point(2, 2);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(118, 43);
            this.btOK.TabIndex = 0;
            this.btOK.Text = "button1";
            this.btOK.UseVisualStyleBackColor = false;
            // 
            // bt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btOK);
            this.Name = "bt";
            this.Size = new System.Drawing.Size(122, 47);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btOK;
    }
}
