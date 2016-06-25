namespace HUB
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
            this.btnGenerateOrch = new System.Windows.Forms.Button();
            this.btnLoadExtractTables = new System.Windows.Forms.Button();
            this.brnContainersOrch = new System.Windows.Forms.Button();
            this.btnGenerateSinglePackages = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGenerateOrch
            // 
            this.btnGenerateOrch.Location = new System.Drawing.Point(481, 14);
            this.btnGenerateOrch.Name = "btnGenerateOrch";
            this.btnGenerateOrch.Size = new System.Drawing.Size(159, 35);
            this.btnGenerateOrch.TabIndex = 0;
            this.btnGenerateOrch.Text = "Generate Orchestration";
            this.btnGenerateOrch.UseVisualStyleBackColor = true;
            this.btnGenerateOrch.Click += new System.EventHandler(this.btnGenerateOrch_Click_1);
            // 
            // btnLoadExtractTables
            // 
            this.btnLoadExtractTables.Location = new System.Drawing.Point(12, 12);
            this.btnLoadExtractTables.Name = "btnLoadExtractTables";
            this.btnLoadExtractTables.Size = new System.Drawing.Size(119, 38);
            this.btnLoadExtractTables.TabIndex = 1;
            this.btnLoadExtractTables.Text = "LoadExtractTables";
            this.btnLoadExtractTables.UseVisualStyleBackColor = true;
            this.btnLoadExtractTables.Click += new System.EventHandler(this.btnLoadExtractTables_Click);
            // 
            // brnContainersOrch
            // 
            this.brnContainersOrch.Location = new System.Drawing.Point(137, 12);
            this.brnContainersOrch.Name = "brnContainersOrch";
            this.brnContainersOrch.Size = new System.Drawing.Size(121, 38);
            this.brnContainersOrch.TabIndex = 2;
            this.brnContainersOrch.Text = "LoadContainersOrch";
            this.brnContainersOrch.UseVisualStyleBackColor = true;
            this.brnContainersOrch.Click += new System.EventHandler(this.brnContainersOrch_Click);
            // 
            // btnGenerateSinglePackages
            // 
            this.btnGenerateSinglePackages.Location = new System.Drawing.Point(264, 14);
            this.btnGenerateSinglePackages.Name = "btnGenerateSinglePackages";
            this.btnGenerateSinglePackages.Size = new System.Drawing.Size(168, 35);
            this.btnGenerateSinglePackages.TabIndex = 3;
            this.btnGenerateSinglePackages.Text = "Generate Single Packages";
            this.btnGenerateSinglePackages.UseVisualStyleBackColor = true;
            this.btnGenerateSinglePackages.Click += new System.EventHandler(this.btnGenerateSinglePackages_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(684, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 36);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 73);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnGenerateSinglePackages);
            this.Controls.Add(this.brnContainersOrch);
            this.Controls.Add(this.btnLoadExtractTables);
            this.Controls.Add(this.btnGenerateOrch);
            this.Name = "Form1";
            this.Text = "BIML Administration";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateOrch;
        private System.Windows.Forms.Button btnLoadExtractTables;
        private System.Windows.Forms.Button brnContainersOrch;
        private System.Windows.Forms.Button btnGenerateSinglePackages;
        private System.Windows.Forms.Button button1;
    }
}

