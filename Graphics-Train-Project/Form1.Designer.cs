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
            this.simulation_group = new System.Windows.Forms.GroupBox();
            this.speed_minus_button = new System.Windows.Forms.Button();
            this.speed_plus_button = new System.Windows.Forms.Button();
            this.speed_label = new System.Windows.Forms.Label();
            this.clear_button = new System.Windows.Forms.Button();
            this.start_button = new System.Windows.Forms.Button();
            this.customize_group = new System.Windows.Forms.GroupBox();
            this.rotate_right_button = new System.Windows.Forms.Button();
            this.rotate_left_button = new System.Windows.Forms.Button();
            this.height_plus_button = new System.Windows.Forms.Button();
            this.height_minus_button = new System.Windows.Forms.Button();
            this.radius_plus_button = new System.Windows.Forms.Button();
            this.radius_minus_button = new System.Windows.Forms.Button();
            this.length_plus_button = new System.Windows.Forms.Button();
            this.length_minus_button = new System.Windows.Forms.Button();
            this.path_list = new System.Windows.Forms.ListBox();
            this.select_label = new System.Windows.Forms.Label();
            this.title_label = new System.Windows.Forms.Label();
            this.scroll_panel = new System.Windows.Forms.Panel();
            this.pic = new System.Windows.Forms.PictureBox();
            this.line_button = new System.Windows.Forms.Button();
            this.circle_button = new System.Windows.Forms.Button();
            this.curve_button = new System.Windows.Forms.Button();
            this.add_group = new System.Windows.Forms.GroupBox();
            this.side_bar.SuspendLayout();
            this.simulation_group.SuspendLayout();
            this.customize_group.SuspendLayout();
            this.scroll_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.add_group.SuspendLayout();
            this.SuspendLayout();
            // 
            // side_bar
            // 
            this.side_bar.AutoScroll = false;
            this.side_bar.BackColor = System.Drawing.SystemColors.Control;
            this.side_bar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.side_bar.Controls.Add(this.simulation_group);
            this.side_bar.Controls.Add(this.customize_group);
            this.side_bar.Controls.Add(this.path_list);
            this.side_bar.Controls.Add(this.select_label);
            this.side_bar.Controls.Add(this.add_group);
            this.side_bar.Controls.Add(this.title_label);
            this.side_bar.Dock = System.Windows.Forms.DockStyle.Left;
            this.side_bar.Location = new System.Drawing.Point(0, 0);
            this.side_bar.Name = "side_bar";
            this.side_bar.Size = new System.Drawing.Size(250, 741);
            this.side_bar.TabIndex = 0;
            // 
            // simulation_group
            // 
            this.simulation_group.Controls.Add(this.speed_minus_button);
            this.simulation_group.Controls.Add(this.speed_plus_button);
            this.simulation_group.Controls.Add(this.speed_label);
            this.simulation_group.Controls.Add(this.clear_button);
            this.simulation_group.Controls.Add(this.start_button);
            this.simulation_group.Location = new System.Drawing.Point(12, 540);
            this.simulation_group.Name = "simulation_group";
            this.simulation_group.Size = new System.Drawing.Size(222, 140);
            this.simulation_group.TabIndex = 6;
            this.simulation_group.TabStop = false;
            this.simulation_group.Text = "Simulation";
            // 
            // speed_minus_button
            // 
            this.speed_minus_button.Location = new System.Drawing.Point(10, 22);
            this.speed_minus_button.Name = "speed_minus_button";
            this.speed_minus_button.Size = new System.Drawing.Size(65, 28);
            this.speed_minus_button.TabIndex = 0;
            this.speed_minus_button.Text = "Speed -";
            this.speed_minus_button.UseVisualStyleBackColor = true;
            this.speed_minus_button.Click += new System.EventHandler(this.btnSpeedMinus_Click);
            // 
            // speed_plus_button
            // 
            this.speed_plus_button.Location = new System.Drawing.Point(147, 22);
            this.speed_plus_button.Name = "speed_plus_button";
            this.speed_plus_button.Size = new System.Drawing.Size(65, 28);
            this.speed_plus_button.TabIndex = 2;
            this.speed_plus_button.Text = "Speed +";
            this.speed_plus_button.UseVisualStyleBackColor = true;
            this.speed_plus_button.Click += new System.EventHandler(this.btnSpeedPlus_Click);
            // 
            // speed_label
            // 
            this.speed_label.AutoSize = true;
            this.speed_label.Location = new System.Drawing.Point(84, 30);
            this.speed_label.Name = "speed_label";
            this.speed_label.Size = new System.Drawing.Size(50, 13);
            this.speed_label.TabIndex = 1;
            this.speed_label.Text = "Speed: 7";
            // 
            // clear_button
            // 
            this.clear_button.Location = new System.Drawing.Point(10, 99);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(202, 28);
            this.clear_button.TabIndex = 2;
            this.clear_button.Text = "Clear";
            this.clear_button.UseVisualStyleBackColor = true;
            this.clear_button.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(10, 63);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(202, 30);
            this.start_button.TabIndex = 0;
            this.start_button.Text = "Start / Restart";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // customize_group
            // 
            this.customize_group.Controls.Add(this.rotate_right_button);
            this.customize_group.Controls.Add(this.rotate_left_button);
            this.customize_group.Controls.Add(this.height_plus_button);
            this.customize_group.Controls.Add(this.height_minus_button);
            this.customize_group.Controls.Add(this.radius_plus_button);
            this.customize_group.Controls.Add(this.radius_minus_button);
            this.customize_group.Controls.Add(this.length_plus_button);
            this.customize_group.Controls.Add(this.length_minus_button);
            this.customize_group.Location = new System.Drawing.Point(12, 352);
            this.customize_group.Name = "customize_group";
            this.customize_group.Size = new System.Drawing.Size(222, 180);
            this.customize_group.TabIndex = 5;
            this.customize_group.TabStop = false;
            this.customize_group.Text = "Customize Selected";
            // 
            // rotate_right_button
            // 
            this.rotate_right_button.Location = new System.Drawing.Point(114, 138);
            this.rotate_right_button.Name = "rotate_right_button";
            this.rotate_right_button.Size = new System.Drawing.Size(98, 28);
            this.rotate_right_button.TabIndex = 7;
            this.rotate_right_button.Text = "Rotate +";
            this.rotate_right_button.UseVisualStyleBackColor = true;
            this.rotate_right_button.Click += new System.EventHandler(this.btnRotateRight_Click);
            // 
            // rotate_left_button
            // 
            this.rotate_left_button.Location = new System.Drawing.Point(10, 138);
            this.rotate_left_button.Name = "rotate_left_button";
            this.rotate_left_button.Size = new System.Drawing.Size(98, 28);
            this.rotate_left_button.TabIndex = 6;
            this.rotate_left_button.Text = "Rotate -";
            this.rotate_left_button.UseVisualStyleBackColor = true;
            this.rotate_left_button.Click += new System.EventHandler(this.btnRotateLeft_Click);
            // 
            // height_plus_button
            // 
            this.height_plus_button.Location = new System.Drawing.Point(114, 104);
            this.height_plus_button.Name = "height_plus_button";
            this.height_plus_button.Size = new System.Drawing.Size(98, 28);
            this.height_plus_button.TabIndex = 5;
            this.height_plus_button.Text = "Height +";
            this.height_plus_button.UseVisualStyleBackColor = true;
            this.height_plus_button.Click += new System.EventHandler(this.btnHeightPlus_Click);
            // 
            // height_minus_button
            // 
            this.height_minus_button.Location = new System.Drawing.Point(10, 104);
            this.height_minus_button.Name = "height_minus_button";
            this.height_minus_button.Size = new System.Drawing.Size(98, 28);
            this.height_minus_button.TabIndex = 4;
            this.height_minus_button.Text = "Height -";
            this.height_minus_button.UseVisualStyleBackColor = true;
            this.height_minus_button.Click += new System.EventHandler(this.btnHeightMinus_Click);
            // 
            // radius_plus_button
            // 
            this.radius_plus_button.Location = new System.Drawing.Point(114, 70);
            this.radius_plus_button.Name = "radius_plus_button";
            this.radius_plus_button.Size = new System.Drawing.Size(98, 28);
            this.radius_plus_button.TabIndex = 3;
            this.radius_plus_button.Text = "Radius +";
            this.radius_plus_button.UseVisualStyleBackColor = true;
            this.radius_plus_button.Click += new System.EventHandler(this.btnRadiusPlus_Click);
            // 
            // radius_minus_button
            // 
            this.radius_minus_button.Location = new System.Drawing.Point(10, 70);
            this.radius_minus_button.Name = "radius_minus_button";
            this.radius_minus_button.Size = new System.Drawing.Size(98, 28);
            this.radius_minus_button.TabIndex = 2;
            this.radius_minus_button.Text = "Radius -";
            this.radius_minus_button.UseVisualStyleBackColor = true;
            this.radius_minus_button.Click += new System.EventHandler(this.btnRadiusMinus_Click);
            // 
            // length_plus_button
            // 
            this.length_plus_button.Location = new System.Drawing.Point(114, 36);
            this.length_plus_button.Name = "length_plus_button";
            this.length_plus_button.Size = new System.Drawing.Size(98, 28);
            this.length_plus_button.TabIndex = 1;
            this.length_plus_button.Text = "Length +";
            this.length_plus_button.UseVisualStyleBackColor = true;
            this.length_plus_button.Click += new System.EventHandler(this.btnLengthPlus_Click);
            // 
            // length_minus_button
            // 
            this.length_minus_button.Location = new System.Drawing.Point(10, 36);
            this.length_minus_button.Name = "length_minus_button";
            this.length_minus_button.Size = new System.Drawing.Size(98, 28);
            this.length_minus_button.TabIndex = 0;
            this.length_minus_button.Text = "Length -";
            this.length_minus_button.UseVisualStyleBackColor = true;
            this.length_minus_button.Click += new System.EventHandler(this.btnLengthMinus_Click);
            // 
            // path_list
            // 
            this.path_list.FormattingEnabled = true;
            this.path_list.Location = new System.Drawing.Point(12, 239);
            this.path_list.Name = "path_list";
            this.path_list.Size = new System.Drawing.Size(222, 95);
            this.path_list.TabIndex = 4;
            this.path_list.SelectedIndexChanged += new System.EventHandler(this.path_list_SelectedIndexChanged);
            // 
            // select_label
            // 
            this.select_label.AutoSize = true;
            this.select_label.Location = new System.Drawing.Point(12, 220);
            this.select_label.Name = "select_label";
            this.select_label.Size = new System.Drawing.Size(94, 13);
            this.select_label.TabIndex = 3;
            this.select_label.Text = "Select a Segment:";
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.title_label.Location = new System.Drawing.Point(11, 14);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(155, 19);
            this.title_label.TabIndex = 0;
            this.title_label.Text = "ROLLERCOASTER";
            // 
            // scroll_panel
            // 
            this.scroll_panel.AutoScroll = true;
            this.scroll_panel.BackColor = System.Drawing.Color.LightSkyBlue;
            this.scroll_panel.Controls.Add(this.pic);
            this.scroll_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scroll_panel.Location = new System.Drawing.Point(250, 0);
            this.scroll_panel.Name = "scroll_panel";
            this.scroll_panel.Size = new System.Drawing.Size(984, 741);
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
            // line_button
            // 
            this.line_button.Location = new System.Drawing.Point(10, 24);
            this.line_button.Name = "line_button";
            this.line_button.Size = new System.Drawing.Size(202, 28);
            this.line_button.TabIndex = 0;
            this.line_button.Text = "Add Line";
            this.line_button.UseVisualStyleBackColor = true;
            this.line_button.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // circle_button
            // 
            this.circle_button.Location = new System.Drawing.Point(10, 58);
            this.circle_button.Name = "circle_button";
            this.circle_button.Size = new System.Drawing.Size(202, 28);
            this.circle_button.TabIndex = 1;
            this.circle_button.Text = "Add Circle";
            this.circle_button.UseVisualStyleBackColor = true;
            this.circle_button.Click += new System.EventHandler(this.btnCircle_Click);
            // 
            // curve_button
            // 
            this.curve_button.Location = new System.Drawing.Point(10, 92);
            this.curve_button.Name = "curve_button";
            this.curve_button.Size = new System.Drawing.Size(202, 28);
            this.curve_button.TabIndex = 2;
            this.curve_button.Text = "Add Curve";
            this.curve_button.UseVisualStyleBackColor = true;
            this.curve_button.Click += new System.EventHandler(this.btnCurve_Click);
            // 
            // add_group
            // 
            this.add_group.Controls.Add(this.curve_button);
            this.add_group.Controls.Add(this.circle_button);
            this.add_group.Controls.Add(this.line_button);
            this.add_group.Location = new System.Drawing.Point(12, 75);
            this.add_group.Name = "add_group";
            this.add_group.Size = new System.Drawing.Size(222, 158);
            this.add_group.TabIndex = 2;
            this.add_group.TabStop = false;
            this.add_group.Text = "Add Track";
            this.add_group.Enter += new System.EventHandler(this.add_group_Enter);
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
            this.Text = "Custom Rollercoaster Path Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.side_bar.ResumeLayout(false);
            this.side_bar.PerformLayout();
            this.simulation_group.ResumeLayout(false);
            this.simulation_group.PerformLayout();
            this.customize_group.ResumeLayout(false);
            this.scroll_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.add_group.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel side_bar;
        private System.Windows.Forms.Label title_label;
        private System.Windows.Forms.Label select_label;
        private System.Windows.Forms.ListBox path_list;
        private System.Windows.Forms.GroupBox customize_group;
        private System.Windows.Forms.Button length_minus_button;
        private System.Windows.Forms.Button length_plus_button;
        private System.Windows.Forms.Button radius_minus_button;
        private System.Windows.Forms.Button radius_plus_button;
        private System.Windows.Forms.Button height_minus_button;
        private System.Windows.Forms.Button height_plus_button;
        private System.Windows.Forms.Button rotate_left_button;
        private System.Windows.Forms.Button rotate_right_button;
        private System.Windows.Forms.GroupBox simulation_group;
        private System.Windows.Forms.Label speed_label;
        private System.Windows.Forms.Button speed_minus_button;
        private System.Windows.Forms.Button speed_plus_button;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.Panel scroll_panel;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.GroupBox add_group;
        private System.Windows.Forms.Button curve_button;
        private System.Windows.Forms.Button circle_button;
        private System.Windows.Forms.Button line_button;
    }
}
