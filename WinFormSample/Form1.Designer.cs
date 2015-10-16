namespace WinFormSample
{
    partial class FrameDataForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /*protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }*/

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.displayID = new System.Windows.Forms.Label();
			this.displayTimestamp = new System.Windows.Forms.Label();
			this.displayIsValid = new System.Windows.Forms.Label();
			this.displayFPS = new System.Windows.Forms.Label();
			this.displayImageCount = new System.Windows.Forms.Label();
			this.displayGestureCount = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.display_idx = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// displayID
			// 
			this.displayID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.displayID.AutoSize = true;
			this.displayID.Location = new System.Drawing.Point(785, 21);
			this.displayID.Name = "displayID";
			this.displayID.Size = new System.Drawing.Size(33, 12);
			this.displayID.TabIndex = 0;
			this.displayID.Text = "label1";
			// 
			// displayTimestamp
			// 
			this.displayTimestamp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.displayTimestamp.AutoSize = true;
			this.displayTimestamp.Location = new System.Drawing.Point(785, 47);
			this.displayTimestamp.Name = "displayTimestamp";
			this.displayTimestamp.Size = new System.Drawing.Size(33, 12);
			this.displayTimestamp.TabIndex = 1;
			this.displayTimestamp.Text = "label2";
			// 
			// displayIsValid
			// 
			this.displayIsValid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.displayIsValid.AutoSize = true;
			this.displayIsValid.Location = new System.Drawing.Point(785, 95);
			this.displayIsValid.Name = "displayIsValid";
			this.displayIsValid.Size = new System.Drawing.Size(33, 12);
			this.displayIsValid.TabIndex = 3;
			this.displayIsValid.Text = "label3";
			// 
			// displayFPS
			// 
			this.displayFPS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.displayFPS.AutoSize = true;
			this.displayFPS.Location = new System.Drawing.Point(785, 69);
			this.displayFPS.Name = "displayFPS";
			this.displayFPS.Size = new System.Drawing.Size(33, 12);
			this.displayFPS.TabIndex = 2;
			this.displayFPS.Text = "label4";
			// 
			// displayImageCount
			// 
			this.displayImageCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.displayImageCount.AutoSize = true;
			this.displayImageCount.Location = new System.Drawing.Point(785, 141);
			this.displayImageCount.Name = "displayImageCount";
			this.displayImageCount.Size = new System.Drawing.Size(33, 12);
			this.displayImageCount.TabIndex = 6;
			this.displayImageCount.Text = "label6";
			// 
			// displayGestureCount
			// 
			this.displayGestureCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.displayGestureCount.AutoSize = true;
			this.displayGestureCount.Location = new System.Drawing.Point(785, 118);
			this.displayGestureCount.Name = "displayGestureCount";
			this.displayGestureCount.Size = new System.Drawing.Size(33, 12);
			this.displayGestureCount.TabIndex = 4;
			this.displayGestureCount.Text = "label8";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.Location = new System.Drawing.Point(12, 21);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(729, 288);
			this.pictureBox1.TabIndex = 7;
			this.pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox2.Location = new System.Drawing.Point(12, 325);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(729, 263);
			this.pictureBox2.TabIndex = 8;
			this.pictureBox2.TabStop = false;
			// 
			// display_idx
			// 
			this.display_idx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.display_idx.AutoSize = true;
			this.display_idx.Location = new System.Drawing.Point(785, 164);
			this.display_idx.Name = "display_idx";
			this.display_idx.Size = new System.Drawing.Size(33, 12);
			this.display_idx.TabIndex = 9;
			this.display_idx.Text = "label1";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(785, 190);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 12);
			this.label1.TabIndex = 10;
			this.label1.Text = "label1";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(785, 218);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(33, 12);
			this.label2.TabIndex = 11;
			this.label2.Text = "label2";
			// 
			// FrameDataForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(915, 600);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.display_idx);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.displayImageCount);
			this.Controls.Add(this.displayGestureCount);
			this.Controls.Add(this.displayIsValid);
			this.Controls.Add(this.displayFPS);
			this.Controls.Add(this.displayTimestamp);
			this.Controls.Add(this.displayID);
			this.Name = "FrameDataForm";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.FrameDataForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        /*private void FrameDataForm_Load(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }*/

        #endregion

        private System.Windows.Forms.Label displayID;
        private System.Windows.Forms.Label displayTimestamp;
        private System.Windows.Forms.Label displayIsValid;
        private System.Windows.Forms.Label displayFPS;
        private System.Windows.Forms.Label displayImageCount;
        private System.Windows.Forms.Label displayGestureCount;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label display_idx;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
    }
}

