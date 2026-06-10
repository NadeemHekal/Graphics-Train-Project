namespace Graphics_Train_Project
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.side_bar = new System.Windows.Forms.Panel();
            this.clear_button = new System.Windows.Forms.Button();
            this.speed_minus_button = new System.Windows.Forms.Button();
            this.start_button = new System.Windows.Forms.Button();
            this.radius_plus_button = new System.Windows.Forms.Button();
            this.speed_label = new System.Windows.Forms.Label();
            this.speed_plus_button = new System.Windows.Forms.Button();
            this.rotate_left_button = new System.Windows.Forms.Button();
            this.rotate_right_button = new System.Windows.Forms.Button();
            this.height_plus_button = new System.Windows.Forms.Button();
            this.curve_button = new System.Windows.Forms.Button();
            this.height_minus_button = new System.Windows.Forms.Button();
            this.circle_button = new System.Windows.Forms.Button();
            this.line_button = new System.Windows.Forms.Button();
            this.radius_minus_button = new System.Windows.Forms.Button();
            this.path_list = new System.Windows.Forms.ListBox();
            this.length_minus_button = new System.Windows.Forms.Button();
            this.length_plus_button = new System.Windows.Forms.Button();
            this.select_label = new System.Windows.Forms.Label();
            this.title_label = new System.Windows.Forms.Label();
            this.scroll_panel = new System.Windows.Forms.Panel();
            this.pic = new System.Windows.Forms.PictureBox();
            this.side_bar.SuspendLayout();
            this.scroll_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // side_bar
            // 
            this.side_bar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.side_bar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.side_bar.Controls.Add(this.clear_button);
            this.side_bar.Controls.Add(this.speed_minus_button);
            this.side_bar.Controls.Add(this.start_button);
            this.side_bar.Controls.Add(this.radius_plus_button);
            this.side_bar.Controls.Add(this.speed_label);
            this.side_bar.Controls.Add(this.speed_plus_button);
            this.side_bar.Controls.Add(this.rotate_left_button);
            this.side_bar.Controls.Add(this.rotate_right_button);
            this.side_bar.Controls.Add(this.height_plus_button);
            this.side_bar.Controls.Add(this.curve_button);
            this.side_bar.Controls.Add(this.height_minus_button);
            this.side_bar.Controls.Add(this.circle_button);
            this.side_bar.Controls.Add(this.line_button);
            this.side_bar.Controls.Add(this.radius_minus_button);
            this.side_bar.Controls.Add(this.path_list);
            this.side_bar.Controls.Add(this.length_minus_button);
            this.side_bar.Controls.Add(this.length_plus_button);
            this.side_bar.Controls.Add(this.select_label);
            this.side_bar.Controls.Add(this.title_label);
            this.side_bar.Dock = System.Windows.Forms.DockStyle.Left;
            this.side_bar.Location = new System.Drawing.Point(0, 0);
            this.side_bar.Name = "side_bar";
            this.side_bar.Size = new System.Drawing.Size(253, 741);
            this.side_bar.TabIndex = 0;
            // 
            // clear_button
            // 
            this.clear_button.Location = new System.Drawing.Point(15, 638);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(72, 23);
            this.clear_button.TabIndex = 2;
            this.clear_button.Text = "clear";
            this.clear_button.UseVisualStyleBackColor = true;
            this.clear_button.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // speed_minus_button
            // 
            this.speed_minus_button.Location = new System.Drawing.Point(174, 633);
            this.speed_minus_button.Name = "speed_minus_button";
            this.speed_minus_button.Size = new System.Drawing.Size(65, 28);
            this.speed_minus_button.TabIndex = 0;
            this.speed_minus_button.Text = "Speed -";
            this.speed_minus_button.UseVisualStyleBackColor = true;
            this.speed_minus_button.Click += new System.EventHandler(this.btnSpeedMinus_Click);
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(15, 599);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(72, 26);
            this.start_button.TabIndex = 0;
            this.start_button.Text = "start & restart";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // radius_plus_button
            // 
            this.radius_plus_button.Location = new System.Drawing.Point(11, 420);
            this.radius_plus_button.Name = "radius_plus_button";
            this.radius_plus_button.Size = new System.Drawing.Size(98, 28);
            this.radius_plus_button.TabIndex = 3;
            this.radius_plus_button.Text = "Radius +";
            this.radius_plus_button.UseVisualStyleBackColor = true;
            this.radius_plus_button.Click += new System.EventHandler(this.btnRadiusPlus_Click);
            // 
            // speed_label
            // 
            this.speed_label.AutoSize = true;
            this.speed_label.Location = new System.Drawing.Point(184, 675);
            this.speed_label.Name = "speed_label";
            this.speed_label.Size = new System.Drawing.Size(50, 13);
            this.speed_label.TabIndex = 1;
            this.speed_label.Text = "Speed: 7";
            // 
            // speed_plus_button
            // 
            this.speed_plus_button.Location = new System.Drawing.Point(174, 599);
            this.speed_plus_button.Name = "speed_plus_button";
            this.speed_plus_button.Size = new System.Drawing.Size(65, 28);
            this.speed_plus_button.TabIndex = 2;
            this.speed_plus_button.Text = "Speed +";
            this.speed_plus_button.UseVisualStyleBackColor = true;
            this.speed_plus_button.Click += new System.EventHandler(this.btnSpeedPlus_Click);
            // 
            // rotate_left_button
            // 
            this.rotate_left_button.Location = new System.Drawing.Point(126, 465);
            this.rotate_left_button.Name = "rotate_left_button";
            this.rotate_left_button.Size = new System.Drawing.Size(98, 28);
            this.rotate_left_button.TabIndex = 6;
            this.rotate_left_button.Text = "Rotate -";
            this.rotate_left_button.UseVisualStyleBackColor = true;
            this.rotate_left_button.Click += new System.EventHandler(this.btnRotateLeft_Click);
            // 
            // rotate_right_button
            // 
            this.rotate_right_button.Location = new System.Drawing.Point(11, 465);
            this.rotate_right_button.Name = "rotate_right_button";
            this.rotate_right_button.Size = new System.Drawing.Size(98, 28);
            this.rotate_right_button.TabIndex = 7;
            this.rotate_right_button.Text = "Rotate +";
            this.rotate_right_button.UseVisualStyleBackColor = true;
            this.rotate_right_button.Click += new System.EventHandler(this.btnRotateRight_Click);
            // 
            // height_plus_button
            // 
            this.height_plus_button.Location = new System.Drawing.Point(15, 512);
            this.height_plus_button.Name = "height_plus_button";
            this.height_plus_button.Size = new System.Drawing.Size(98, 28);
            this.height_plus_button.TabIndex = 5;
            this.height_plus_button.Text = "Height +";
            this.height_plus_button.UseVisualStyleBackColor = true;
            this.height_plus_button.Click += new System.EventHandler(this.btnHeightPlus_Click);
            // 
            // curve_button
            // 
            this.curve_button.Location = new System.Drawing.Point(22, 119);
            this.curve_button.Name = "curve_button";
            this.curve_button.Size = new System.Drawing.Size(202, 28);
            this.curve_button.TabIndex = 2;
            this.curve_button.Text = "Add Curve";
            this.curve_button.UseVisualStyleBackColor = true;
            this.curve_button.Click += new System.EventHandler(this.btnCurve_Click);
            // 
            // height_minus_button
            // 
            this.height_minus_button.Location = new System.Drawing.Point(126, 512);
            this.height_minus_button.Name = "height_minus_button";
            this.height_minus_button.Size = new System.Drawing.Size(98, 28);
            this.height_minus_button.TabIndex = 4;
            this.height_minus_button.Text = "Height -";
            this.height_minus_button.UseVisualStyleBackColor = true;
            this.height_minus_button.Click += new System.EventHandler(this.btnHeightMinus_Click);
            // 
            // circle_button
            // 
            this.circle_button.Location = new System.Drawing.Point(22, 167);
            this.circle_button.Name = "circle_button";
            this.circle_button.Size = new System.Drawing.Size(202, 28);
            this.circle_button.TabIndex = 1;
            this.circle_button.Text = "Add Circle";
            this.circle_button.UseVisualStyleBackColor = true;
            this.circle_button.Click += new System.EventHandler(this.btnCircle_Click);
            // 
            // line_button
            // 
            this.line_button.Location = new System.Drawing.Point(22, 71);
            this.line_button.Name = "line_button";
            this.line_button.Size = new System.Drawing.Size(202, 28);
            this.line_button.TabIndex = 0;
            this.line_button.Text = "Add Line";
            this.line_button.UseVisualStyleBackColor = true;
            this.line_button.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // radius_minus_button
            // 
            this.radius_minus_button.Location = new System.Drawing.Point(126, 420);
            this.radius_minus_button.Name = "radius_minus_button";
            this.radius_minus_button.Size = new System.Drawing.Size(98, 28);
            this.radius_minus_button.TabIndex = 2;
            this.radius_minus_button.Text = "Radius -";
            this.radius_minus_button.UseVisualStyleBackColor = true;
            this.radius_minus_button.Click += new System.EventHandler(this.btnRadiusMinus_Click);
            // 
            // path_list
            // 
            this.path_list.FormattingEnabled = true;
            this.path_list.Location = new System.Drawing.Point(34, 220);
            this.path_list.Name = "path_list";
            this.path_list.Size = new System.Drawing.Size(176, 134);
            this.path_list.TabIndex = 4;
            this.path_list.SelectedIndexChanged += new System.EventHandler(this.path_list_SelectedIndexChanged);
            // 
            // length_minus_button
            // 
            this.length_minus_button.Location = new System.Drawing.Point(126, 373);
            this.length_minus_button.Name = "length_minus_button";
            this.length_minus_button.Size = new System.Drawing.Size(98, 28);
            this.length_minus_button.TabIndex = 0;
            this.length_minus_button.Text = "Length -";
            this.length_minus_button.UseVisualStyleBackColor = true;
            this.length_minus_button.Click += new System.EventHandler(this.btnLengthMinus_Click);
            // 
            // length_plus_button
            // 
            this.length_plus_button.Location = new System.Drawing.Point(11, 373);
            this.length_plus_button.Name = "length_plus_button";
            this.length_plus_button.Size = new System.Drawing.Size(98, 28);
            this.length_plus_button.TabIndex = 1;
            this.length_plus_button.Text = "Length +";
            this.length_plus_button.UseVisualStyleBackColor = true;
            this.length_plus_button.Click += new System.EventHandler(this.btnLengthPlus_Click);
            // 
            // select_label
            // 
            this.select_label.AutoSize = true;
            this.select_label.Location = new System.Drawing.Point(19, 204);
            this.select_label.Name = "select_label";
            this.select_label.Size = new System.Drawing.Size(38, 13);
            this.select_label.TabIndex = 3;
            this.select_label.Text = "select:";
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.title_label.Location = new System.Drawing.Point(11, 14);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(159, 19);
            this.title_label.TabIndex = 0;
            this.title_label.Text = "ROLLER COASTER";
            // 
            // scroll_panel
            // 
            this.scroll_panel.AutoScroll = true;
            this.scroll_panel.BackColor = System.Drawing.Color.LightSkyBlue;
            this.scroll_panel.Controls.Add(this.pic);
            this.scroll_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scroll_panel.Location = new System.Drawing.Point(253, 0);
            this.scroll_panel.Name = "scroll_panel";
            this.scroll_panel.Size = new System.Drawing.Size(981, 741);
            this.scroll_panel.TabIndex = 1;
            // 
            // pic
            // 
            this.pic.BackColor = System.Drawing.Color.White;
            this.pic.Location = new System.Drawing.Point(0, 0);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(6000, 1200);
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            this.pic.Paint += new System.Windows.Forms.PaintEventHandler(this.pic_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1234, 741);
            this.Controls.Add(this.scroll_panel);
            this.Controls.Add(this.side_bar);
            this.MinimumSize = new System.Drawing.Size(1050, 700);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "rollercoasters simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.side_bar.ResumeLayout(false);
            this.side_bar.PerformLayout();
            this.scroll_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel side_bar;
        private System.Windows.Forms.Label title_label;
        private System.Windows.Forms.Label select_label;
        private System.Windows.Forms.ListBox path_list;
        private System.Windows.Forms.Button length_minus_button;
        private System.Windows.Forms.Button length_plus_button;
        private System.Windows.Forms.Button radius_minus_button;
        private System.Windows.Forms.Button radius_plus_button;
        private System.Windows.Forms.Button height_minus_button;
        private System.Windows.Forms.Button height_plus_button;
        private System.Windows.Forms.Button rotate_left_button;
        private System.Windows.Forms.Button rotate_right_button;
        private System.Windows.Forms.Label speed_label;
        private System.Windows.Forms.Button speed_minus_button;
        private System.Windows.Forms.Button speed_plus_button;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.Panel scroll_panel;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Button curve_button;
        private System.Windows.Forms.Button circle_button;
        private System.Windows.Forms.Button line_button;
    }
}
