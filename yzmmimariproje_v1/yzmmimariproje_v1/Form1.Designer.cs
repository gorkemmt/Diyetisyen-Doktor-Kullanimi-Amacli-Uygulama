
namespace yzmmimariproje_v1
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.giriskimlik = new System.Windows.Forms.TextBox();
            this.girisparola = new System.Windows.Forms.TextBox();
            this.girisyap = new System.Windows.Forms.Button();
            this.adminradiobuton = new System.Windows.Forms.RadioButton();
            this.diyetisyenradiobuton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // giriskimlik
            // 
            this.giriskimlik.Location = new System.Drawing.Point(161, 76);
            this.giriskimlik.Name = "giriskimlik";
            this.giriskimlik.Size = new System.Drawing.Size(121, 20);
            this.giriskimlik.TabIndex = 0;
            // 
            // girisparola
            // 
            this.girisparola.Location = new System.Drawing.Point(161, 125);
            this.girisparola.Name = "girisparola";
            this.girisparola.Size = new System.Drawing.Size(121, 20);
            this.girisparola.TabIndex = 1;
            // 
            // girisyap
            // 
            this.girisyap.Location = new System.Drawing.Point(76, 222);
            this.girisyap.Name = "girisyap";
            this.girisyap.Size = new System.Drawing.Size(206, 44);
            this.girisyap.TabIndex = 2;
            this.girisyap.Text = "OTURUM AÇ";
            this.girisyap.UseVisualStyleBackColor = true;
            this.girisyap.Click += new System.EventHandler(this.button1_Click);
            // 
            // adminradiobuton
            // 
            this.adminradiobuton.AutoSize = true;
            this.adminradiobuton.Location = new System.Drawing.Point(76, 180);
            this.adminradiobuton.Name = "adminradiobuton";
            this.adminradiobuton.Size = new System.Drawing.Size(54, 17);
            this.adminradiobuton.TabIndex = 3;
            this.adminradiobuton.Text = "Admin";
            this.adminradiobuton.UseVisualStyleBackColor = true;
            // 
            // diyetisyenradiobuton
            // 
            this.diyetisyenradiobuton.AutoSize = true;
            this.diyetisyenradiobuton.Checked = true;
            this.diyetisyenradiobuton.Location = new System.Drawing.Point(161, 180);
            this.diyetisyenradiobuton.Name = "diyetisyenradiobuton";
            this.diyetisyenradiobuton.Size = new System.Drawing.Size(73, 17);
            this.diyetisyenradiobuton.TabIndex = 4;
            this.diyetisyenradiobuton.TabStop = true;
            this.diyetisyenradiobuton.Text = "Diyetisyen";
            this.diyetisyenradiobuton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Parola :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tc Kimlik No :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 350);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.diyetisyenradiobuton);
            this.Controls.Add(this.adminradiobuton);
            this.Controls.Add(this.girisyap);
            this.Controls.Add(this.girisparola);
            this.Controls.Add(this.giriskimlik);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox giriskimlik;
        private System.Windows.Forms.TextBox girisparola;
        private System.Windows.Forms.Button girisyap;
        private System.Windows.Forms.RadioButton adminradiobuton;
        private System.Windows.Forms.RadioButton diyetisyenradiobuton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

