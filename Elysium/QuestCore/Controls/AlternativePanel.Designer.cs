namespace QuestCore
{
    partial class AlternativePanel
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
            this.tbId = new System.Windows.Forms.TextBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.lbCondition = new System.Windows.Forms.LinkLabel();
            this.btDelete = new System.Windows.Forms.Button();
            this.btDown = new System.Windows.Forms.Button();
            this.btUp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbId
            // 
            this.tbId.BackColor = System.Drawing.Color.White;
            this.tbId.Location = new System.Drawing.Point(3, 3);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(36, 20);
            this.tbId.TabIndex = 0;
            this.tbId.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // tbTitle
            // 
            this.tbTitle.BackColor = System.Drawing.Color.White;
            this.tbTitle.Location = new System.Drawing.Point(42, 3);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(246, 20);
            this.tbTitle.TabIndex = 1;
            this.tbTitle.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // lbCondition
            // 
            this.lbCondition.AutoSize = true;
            this.lbCondition.Location = new System.Drawing.Point(40, 23);
            this.lbCondition.Name = "lbCondition";
            this.lbCondition.Size = new System.Drawing.Size(113, 13);
            this.lbCondition.TabIndex = 2;
            this.lbCondition.TabStop = true;
            this.lbCondition.Text = "Задать зависимость";
            this.lbCondition.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbCondition_LinkClicked);
            // 
            // btDelete
            // 
            this.btDelete.BackColor = System.Drawing.Color.Transparent;
            this.btDelete.Image = global::QuestCore.Properties.Resources.icons8_delete_24;
            this.btDelete.Location = new System.Drawing.Point(354, 2);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(24, 24);
            this.btDelete.TabIndex = 5;
            this.btDelete.UseVisualStyleBackColor = false;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btDown
            // 
            this.btDown.BackColor = System.Drawing.Color.Transparent;
            this.btDown.Image = global::QuestCore.Properties.Resources.icons8_sort_down_16;
            this.btDown.Location = new System.Drawing.Point(324, 2);
            this.btDown.Name = "btDown";
            this.btDown.Size = new System.Drawing.Size(24, 24);
            this.btDown.TabIndex = 4;
            this.btDown.UseVisualStyleBackColor = false;
            this.btDown.Click += new System.EventHandler(this.btDown_Click);
            // 
            // btUp
            // 
            this.btUp.BackColor = System.Drawing.Color.Transparent;
            this.btUp.Image = global::QuestCore.Properties.Resources.icons8_sort_up_16;
            this.btUp.Location = new System.Drawing.Point(294, 2);
            this.btUp.Name = "btUp";
            this.btUp.Size = new System.Drawing.Size(24, 24);
            this.btUp.TabIndex = 3;
            this.btUp.UseVisualStyleBackColor = false;
            this.btUp.Click += new System.EventHandler(this.btUp_Click);
            // 
            // AlternativePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Yellow;
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btDown);
            this.Controls.Add(this.btUp);
            this.Controls.Add(this.lbCondition);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.tbId);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AlternativePanel";
            this.Size = new System.Drawing.Size(384, 41);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.LinkLabel lbCondition;
        private System.Windows.Forms.Button btUp;
        private System.Windows.Forms.Button btDown;
        private System.Windows.Forms.Button btDelete;
    }
}
