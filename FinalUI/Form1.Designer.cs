namespace FinalUI
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
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.clear = new System.Windows.Forms.Button();
            this.listen = new System.Windows.Forms.Button();
            this.control = new System.Windows.Forms.GroupBox();
            this.speech = new System.Windows.Forms.Button();
            this.display = new System.Windows.Forms.Button();
            this.resume = new System.Windows.Forms.Button();
            this.pause = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fileName = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.browse = new System.Windows.Forms.Button();
            this.width = new System.Windows.Forms.Label();
            this.height = new System.Windows.Forms.Label();
            this.result = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.breakApart = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.recognise = new System.Windows.Forms.Button();
            this.listType = new System.Windows.Forms.ComboBox();
            this.content = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.edit = new System.Windows.Forms.Button();
            this.text = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.statusBar.SuspendLayout();
            this.control.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status,
            this.toolStripProgressBar1});
            this.statusBar.Location = new System.Drawing.Point(0, 603);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1173, 22);
            this.statusBar.TabIndex = 4;
            this.statusBar.Text = "statusStrip1";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(38, 17);
            this.status.Text = "Ready";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 577);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "(c) Adroit. All rights reserved.";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // clear
            // 
            this.clear.ForeColor = System.Drawing.Color.DarkRed;
            this.clear.Location = new System.Drawing.Point(246, 338);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(98, 23);
            this.clear.TabIndex = 8;
            this.clear.Text = "Reset";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // listen
            // 
            this.listen.Location = new System.Drawing.Point(57, 29);
            this.listen.Name = "listen";
            this.listen.Size = new System.Drawing.Size(83, 23);
            this.listen.TabIndex = 9;
            this.listen.Text = "Listen";
            this.listen.UseVisualStyleBackColor = true;
            this.listen.Click += new System.EventHandler(this.listen_Click);
            // 
            // control
            // 
            this.control.Controls.Add(this.save);
            this.control.Controls.Add(this.edit);
            this.control.Controls.Add(this.text);
            this.control.Location = new System.Drawing.Point(12, 425);
            this.control.Name = "control";
            this.control.Size = new System.Drawing.Size(354, 63);
            this.control.TabIndex = 11;
            this.control.TabStop = false;
            this.control.Text = "Final Contents";
            this.control.Enter += new System.EventHandler(this.control_Enter);
            // 
            // speech
            // 
            this.speech.Location = new System.Drawing.Point(281, 563);
            this.speech.Name = "speech";
            this.speech.Size = new System.Drawing.Size(75, 25);
            this.speech.TabIndex = 17;
            this.speech.Text = "Speech";
            this.speech.UseVisualStyleBackColor = true;
            this.speech.Visible = false;
            this.speech.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // display
            // 
            this.display.Location = new System.Drawing.Point(194, 562);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(81, 25);
            this.display.TabIndex = 16;
            this.display.Text = "Display text";
            this.display.UseVisualStyleBackColor = true;
            this.display.Visible = false;
            this.display.Click += new System.EventHandler(this.button1_Click);
            // 
            // resume
            // 
            this.resume.Location = new System.Drawing.Point(238, 28);
            this.resume.Name = "resume";
            this.resume.Size = new System.Drawing.Size(25, 23);
            this.resume.TabIndex = 14;
            this.resume.UseVisualStyleBackColor = true;
            this.resume.Click += new System.EventHandler(this.resume_Click);
            // 
            // pause
            // 
            this.pause.Location = new System.Drawing.Point(180, 29);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(26, 23);
            this.pause.TabIndex = 13;
            this.pause.UseVisualStyleBackColor = true;
            this.pause.Click += new System.EventHandler(this.pause_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.recognise);
            this.groupBox2.Controls.Add(this.listType);
            this.groupBox2.Controls.Add(this.clear);
            this.groupBox2.Controls.Add(this.breakApart);
            this.groupBox2.Controls.Add(this.fileName);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.browse);
            this.groupBox2.Controls.Add(this.width);
            this.groupBox2.Controls.Add(this.height);
            this.groupBox2.Location = new System.Drawing.Point(12, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(354, 379);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Image";
            // 
            // fileName
            // 
            this.fileName.Location = new System.Drawing.Point(87, 264);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(146, 20);
            this.fileName.TabIndex = 7;
            this.fileName.TextChanged += new System.EventHandler(this.fileName_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(6, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(331, 227);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(6, 264);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(75, 23);
            this.browse.TabIndex = 6;
            this.browse.Text = "Browse";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // width
            // 
            this.width.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.width.Location = new System.Drawing.Point(290, 264);
            this.width.Name = "width";
            this.width.Size = new System.Drawing.Size(45, 20);
            this.width.TabIndex = 2;
            this.width.Text = "Width";
            // 
            // height
            // 
            this.height.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.height.Location = new System.Drawing.Point(239, 264);
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(45, 20);
            this.height.TabIndex = 1;
            this.height.Text = "Height";
            // 
            // result
            // 
            this.result.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.result.Enabled = false;
            this.result.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.result.Location = new System.Drawing.Point(6, 296);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(373, 99);
            this.result.TabIndex = 15;
            this.result.Text = "Recognised Text for Characters";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.content);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Controls.Add(this.pictureBox4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.result);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Location = new System.Drawing.Point(372, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(792, 553);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Processing";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox4.Location = new System.Drawing.Point(385, 19);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(400, 268);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox3.Location = new System.Drawing.Point(6, 19);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(373, 268);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // breakApart
            // 
            this.breakApart.Location = new System.Drawing.Point(125, 338);
            this.breakApart.Name = "breakApart";
            this.breakApart.Size = new System.Drawing.Size(98, 23);
            this.breakApart.TabIndex = 1;
            this.breakApart.Text = "Break Apart";
            this.breakApart.UseVisualStyleBackColor = true;
            this.breakApart.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(369, 462);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(400, 121);
            this.listBox1.TabIndex = 2;
            this.listBox1.Visible = false;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(385, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(400, 99);
            this.label2.TabIndex = 16;
            this.label2.Text = "Recognised Text for Paragraph";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 298);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Read";
            // 
            // recognise
            // 
            this.recognise.Location = new System.Drawing.Point(6, 338);
            this.recognise.Name = "recognise";
            this.recognise.Size = new System.Drawing.Size(96, 23);
            this.recognise.TabIndex = 19;
            this.recognise.Text = "Contour";
            this.recognise.UseVisualStyleBackColor = true;
            this.recognise.Click += new System.EventHandler(this.recognise_Click_1);
            // 
            // listType
            // 
            this.listType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listType.FormattingEnabled = true;
            this.listType.Items.AddRange(new object[] {
            "Character",
            "Paragraph",
            "Barcode",
            "Identify images"});
            this.listType.Location = new System.Drawing.Point(91, 295);
            this.listType.Name = "listType";
            this.listType.Size = new System.Drawing.Size(146, 23);
            this.listType.TabIndex = 18;
            this.listType.Text = "Character";
            // 
            // content
            // 
            this.content.Location = new System.Drawing.Point(6, 418);
            this.content.Name = "content";
            this.content.ReadOnly = true;
            this.content.Size = new System.Drawing.Size(779, 129);
            this.content.TabIndex = 17;
            this.content.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listen);
            this.groupBox3.Controls.Add(this.pause);
            this.groupBox3.Controls.Add(this.resume);
            this.groupBox3.Location = new System.Drawing.Point(12, 494);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(354, 62);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Listen contents";
            // 
            // edit
            // 
            this.edit.Location = new System.Drawing.Point(126, 22);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(98, 23);
            this.edit.TabIndex = 18;
            this.edit.Text = "Edit Contents";
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // text
            // 
            this.text.Location = new System.Drawing.Point(6, 22);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(96, 23);
            this.text.TabIndex = 17;
            this.text.Text = "View text file";
            this.text.UseVisualStyleBackColor = true;
            this.text.Click += new System.EventHandler(this.text_Click_1);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(246, 22);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(98, 23);
            this.save.TabIndex = 19;
            this.save.Text = "Save Contents";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 395);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Final Contents";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 625);
            this.Controls.Add(this.speech);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.display);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.control);
            this.Name = "Form1";
            this.Text = "Construe";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.control.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button listen;
        private System.Windows.Forms.GroupBox control;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox fileName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.Label width;
        private System.Windows.Forms.Label height;
        private System.Windows.Forms.Button pause;
        private System.Windows.Forms.Button resume;
        private System.Windows.Forms.Label result;
        private System.Windows.Forms.Button display;
        private System.Windows.Forms.Button speech;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button breakApart;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button recognise;
        private System.Windows.Forms.ComboBox listType;
        private System.Windows.Forms.RichTextBox content;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button text;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Label label4;
    }
}

