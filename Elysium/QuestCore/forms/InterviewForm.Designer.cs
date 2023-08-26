namespace QuestCore
{
    partial class InterviewForm
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
            this.pnAnswers = new System.Windows.Forms.FlowLayoutPanel();
            this.btNext = new System.Windows.Forms.Button();
            this.btBack = new System.Windows.Forms.Button();
            this.btFinish = new System.Windows.Forms.Button();
            this.pnAnswers.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnAnswers
            // 
            this.pnAnswers.AutoScroll = true;
            this.pnAnswers.BackColor = System.Drawing.Color.White;
            this.pnAnswers.Controls.Add(this.btNext);
            this.pnAnswers.Controls.Add(this.btBack);
            this.pnAnswers.Controls.Add(this.btFinish);
            this.pnAnswers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnAnswers.Location = new System.Drawing.Point(0, 0);
            this.pnAnswers.Name = "pnAnswers";
            this.pnAnswers.Size = new System.Drawing.Size(392, 588);
            this.pnAnswers.TabIndex = 0;
            // 
            // btNext
            // 
            this.btNext.BackColor = System.Drawing.Color.Yellow;
            this.btNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btNext.ForeColor = System.Drawing.Color.Black;
            this.btNext.Location = new System.Drawing.Point(3, 3);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(144, 26);
            this.btNext.TabIndex = 1;
            this.btNext.Text = "Следующий вопрос";
            this.btNext.UseVisualStyleBackColor = false;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // btBack
            // 
            this.btBack.BackColor = System.Drawing.Color.Yellow;
            this.btBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btBack.ForeColor = System.Drawing.Color.Black;
            this.btBack.Location = new System.Drawing.Point(153, 3);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(98, 26);
            this.btBack.TabIndex = 3;
            this.btBack.Text = "Назад";
            this.btBack.UseVisualStyleBackColor = false;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // btFinish
            // 
            this.btFinish.BackColor = System.Drawing.Color.Lime;
            this.btFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btFinish.ForeColor = System.Drawing.Color.White;
            this.btFinish.Location = new System.Drawing.Point(3, 35);
            this.btFinish.Name = "btFinish";
            this.btFinish.Size = new System.Drawing.Size(167, 26);
            this.btFinish.TabIndex = 2;
            this.btFinish.Text = "Отправить пожелание";
            this.btFinish.UseVisualStyleBackColor = false;
            this.btFinish.Click += new System.EventHandler(this.btFinish_Click);
            // 
            // InterviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(392, 588);
            this.Controls.Add(this.pnAnswers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InterviewForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.pnAnswers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnAnswers;
        private System.Windows.Forms.Button btNext;
        private System.Windows.Forms.Button btFinish;
        private System.Windows.Forms.Button btBack;
    }
}