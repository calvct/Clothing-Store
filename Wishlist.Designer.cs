namespace ALP_AD
{
    partial class Wishlist
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbox_name = new System.Windows.Forms.TextBox();
            this.tbox_harga = new System.Windows.Forms.TextBox();
            this.tbox_warna = new System.Windows.Forms.TextBox();
            this.tbox_ukuran = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(849, 286);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nama Produk";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 355);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Harga";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 385);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Warna";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 415);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ukuran";
            // 
            // tbox_name
            // 
            this.tbox_name.Location = new System.Drawing.Point(90, 322);
            this.tbox_name.Name = "tbox_name";
            this.tbox_name.ReadOnly = true;
            this.tbox_name.Size = new System.Drawing.Size(153, 20);
            this.tbox_name.TabIndex = 5;
            // 
            // tbox_harga
            // 
            this.tbox_harga.Location = new System.Drawing.Point(90, 352);
            this.tbox_harga.Name = "tbox_harga";
            this.tbox_harga.ReadOnly = true;
            this.tbox_harga.Size = new System.Drawing.Size(153, 20);
            this.tbox_harga.TabIndex = 6;
            // 
            // tbox_warna
            // 
            this.tbox_warna.Location = new System.Drawing.Point(90, 382);
            this.tbox_warna.Name = "tbox_warna";
            this.tbox_warna.ReadOnly = true;
            this.tbox_warna.Size = new System.Drawing.Size(153, 20);
            this.tbox_warna.TabIndex = 7;
            // 
            // tbox_ukuran
            // 
            this.tbox_ukuran.Location = new System.Drawing.Point(90, 412);
            this.tbox_ukuran.Name = "tbox_ukuran";
            this.tbox_ukuran.ReadOnly = true;
            this.tbox_ukuran.Size = new System.Drawing.Size(153, 20);
            this.tbox_ukuran.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 450);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 61);
            this.button1.TabIndex = 9;
            this.button1.Text = "Remove From Wishlist";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Wishlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(874, 533);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbox_ukuran);
            this.Controls.Add(this.tbox_warna);
            this.Controls.Add(this.tbox_harga);
            this.Controls.Add(this.tbox_name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Wishlist";
            this.Text = "Wishlist";
            this.Load += new System.EventHandler(this.Wishlist_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbox_name;
        private System.Windows.Forms.TextBox tbox_harga;
        private System.Windows.Forms.TextBox tbox_warna;
        private System.Windows.Forms.TextBox tbox_ukuran;
        private System.Windows.Forms.Button button1;
    }
}