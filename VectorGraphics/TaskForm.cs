using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Diagrams
{
    public partial class TaskForm : Form
    {

        public int TaskNumber { get; private set; }
        public string TaskText { get; private set; }
        private int _temp = 70;
        public TaskForm()
        {
            InitializeComponent();
        }

        public void ChangeTask(string labelName)
        {

            TaskNumber = Convert.ToInt32(labelName);
            this.Close();
            
        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            ChangeTask((((Label)sender).TabIndex).ToString());

            TaskText = (((Label) sender).Text);
        }


        public void CreateButton()
        {
            Button button = new Button();

            button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button.FlatStyle = FlatStyle.Popup;
            button.Location = new Point(600, 220);
            button.Name = "button2";
            button.Size = new Size(75, 45);
            button.TabIndex = 12;
            button.Tag = "3";
            button.Text = "Delete";
            button.UseVisualStyleBackColor = true;
            Controls.Add(button);
        }
     
    }


}
