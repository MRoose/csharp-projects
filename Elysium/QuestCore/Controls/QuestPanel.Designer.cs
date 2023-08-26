namespace QuestCore
{
    partial class QuestPanel
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
            this.cbQuestType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnAlternatives = new System.Windows.Forms.FlowLayoutPanel();
            this.btAddAlt = new System.Windows.Forms.Button();
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
            this.tbId.Size = new System.Drawing.Size(74, 20);
            this.tbId.TabIndex = 0;
            this.tbId.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // tbTitle
            // 
            this.tbTitle.BackColor = System.Drawing.Color.White;
            this.tbTitle.Location = new System.Drawing.Point(3, 29);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(378, 20);
            this.tbTitle.TabIndex = 1;
            this.tbTitle.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // lbCondition
            // 
            this.lbCondition.AutoSize = true;
            this.lbCondition.Location = new System.Drawing.Point(95, 6);
            this.lbCondition.Name = "lbCondition";
            this.lbCondition.Size = new System.Drawing.Size(113, 13);
            this.lbCondition.TabIndex = 2;
            this.lbCondition.TabStop = true;
            this.lbCondition.Text = "Задать зависимость";
            this.lbCondition.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbCondition_LinkClicked);
            // 
            // cbQuestType
            // 
            this.cbQuestType.BackColor = System.Drawing.Color.White;
            this.cbQuestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQuestType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbQuestType.FormattingEnabled = true;
            this.cbQuestType.Location = new System.Drawing.Point(202, 55);
            this.cbQuestType.Name = "cbQuestType";
            this.cbQuestType.Size = new System.Drawing.Size(179, 21);
            this.cbQuestType.TabIndex = 3;
            this.cbQuestType.SelectedIndexChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Добавить вариант ответа";
            // 
            // pnAlternatives
            // 
            this.pnAlternatives.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnAlternatives.AutoScroll = true;
            this.pnAlternatives.AutoSize = true;
            this.pnAlternatives.BackColor = System.Drawing.Color.Transparent;
            this.pnAlternatives.Location = new System.Drawing.Point(3, 81);
            this.pnAlternatives.Name = "pnAlternatives";
            this.pnAlternatives.Size = new System.Drawing.Size(380, 0);
            this.pnAlternatives.TabIndex = 9;
            // 
            // btAddAlt
            // 
            this.btAddAlt.BackColor = System.Drawing.Color.White;
            this.btAddAlt.Image = global::QuestCore.Properties.Resources.list_add;
            this.btAddAlt.Location = new System.Drawing.Point(3, 53);
            this.btAddAlt.Name = "btAddAlt";
            this.btAddAlt.Size = new System.Drawing.Size(29, 28);
            this.btAddAlt.TabIndex = 7;
            this.btAddAlt.UseVisualStyleBackColor = false;
            this.btAddAlt.Click += new System.EventHandler(this.btAddAlt_Click);
            // 
            // btDelete
            // 
            this.btDelete.BackColor = System.Drawing.Color.White;
            this.btDelete.Image = global::QuestCore.Properties.Resources.icons8_delete_24;
            this.btDelete.Location = new System.Drawing.Point(355, 3);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(26, 23);
            this.btDelete.TabIndex = 6;
            this.btDelete.UseVisualStyleBackColor = false;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btDown
            // 
            this.btDown.BackColor = System.Drawing.Color.White;
            this.btDown.Image = global::QuestCore.Properties.Resources.icons8_sort_down_16;
            this.btDown.Location = new System.Drawing.Point(325, 3);
            this.btDown.Name = "btDown";
            this.btDown.Size = new System.Drawing.Size(24, 23);
            this.btDown.TabIndex = 5;
            this.btDown.UseVisualStyleBackColor = false;
            this.btDown.Click += new System.EventHandler(this.btDown_Click);
            // 
            // btUp
            // 
            this.btUp.BackColor = System.Drawing.Color.White;
            this.btUp.Image = global::QuestCore.Properties.Resources.icons8_sort_up_16;
            this.btUp.Location = new System.Drawing.Point(295, 3);
            this.btUp.Name = "btUp";
            this.btUp.Size = new System.Drawing.Size(24, 23);
            this.btUp.TabIndex = 4;
            this.btUp.UseVisualStyleBackColor = false;
            this.btUp.Click += new System.EventHandler(this.btUp_Click);
            // 
            // QuestPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Yellow;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnAlternatives);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btAddAlt);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btDown);
            this.Controls.Add(this.btUp);
            this.Controls.Add(this.cbQuestType);
            this.Controls.Add(this.lbCondition);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.tbId);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "QuestPanel";
            this.Size = new System.Drawing.Size(380, 84);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.LinkLabel lbCondition;
        private System.Windows.Forms.ComboBox cbQuestType;
        private System.Windows.Forms.Button btUp;
        private System.Windows.Forms.Button btDown;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btAddAlt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel pnAlternatives;
    }
}
