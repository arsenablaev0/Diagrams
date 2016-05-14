namespace Diagrams
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.miNew = new System.Windows.Forms.ToolStripMenuItem();
            this.miExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.miClose = new System.Windows.Forms.ToolStripMenuItem();
            this.sfdImage = new System.Windows.Forms.SaveFileDialog();
            this.cmSelectedFigure = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miEditText = new System.Windows.Forms.ToolStripMenuItem();
            this.miAddLedgeLine = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.bringToFrontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToBackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.selectTask = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCycleEndAdd = new System.Windows.Forms.Button();
            this.btnCycleStartAdd = new System.Windows.Forms.Button();
            this.btnStartEndAdd = new System.Windows.Forms.Button();
            this.btnParalelogrammAdd = new System.Windows.Forms.Button();
            this.btnRectAdd = new System.Windows.Forms.Button();
            this.btnRhombAdd = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTask = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.dbDiagram = new Diagrams.DiagramBox();
            this.menuStrip1.SuspendLayout();
            this.cmSelectedFigure.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(880, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNew,
            this.miExport,
            this.toolStripMenuItem2,
            this.miClose});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem1.Text = "Файл";
            // 
            // miNew
            // 
            this.miNew.Name = "miNew";
            this.miNew.Size = new System.Drawing.Size(206, 22);
            this.miNew.Text = "Новая схема";
            this.miNew.Click += new System.EventHandler(this.miNewDiagram_Click);
            // 
            // miExport
            // 
            this.miExport.Name = "miExport";
            this.miExport.Size = new System.Drawing.Size(206, 22);
            this.miExport.Text = "Сохранить как картинку";
            this.miExport.Click += new System.EventHandler(this.miExport_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(203, 6);
            // 
            // miClose
            // 
            this.miClose.Name = "miClose";
            this.miClose.Size = new System.Drawing.Size(206, 22);
            this.miClose.Text = "Выход";
            this.miClose.Click += new System.EventHandler(this.miExit_Click);
            // 
            // sfdImage
            // 
            this.sfdImage.Filter = "PNG Image(*.png)|*.png|Metafile(*.emf)|*.emf";
            // 
            // cmSelectedFigure
            // 
            this.cmSelectedFigure.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miEditText,
            this.miAddLedgeLine,
            this.toolStripSeparator1,
            this.miDelete,
            this.toolStripMenuItem1,
            this.bringToFrontToolStripMenuItem,
            this.sendToBackToolStripMenuItem});
            this.cmSelectedFigure.Name = "cmSelectedFigure";
            this.cmSelectedFigure.Size = new System.Drawing.Size(176, 148);
            // 
            // miEditText
            // 
            this.miEditText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.miEditText.Name = "miEditText";
            this.miEditText.Size = new System.Drawing.Size(175, 22);
            this.miEditText.Text = "Изменить текст...";
            this.miEditText.Click += new System.EventHandler(this.editTextToolStripMenuItem_Click);
            // 
            // miAddLedgeLine
            // 
            this.miAddLedgeLine.Name = "miAddLedgeLine";
            this.miAddLedgeLine.Size = new System.Drawing.Size(175, 22);
            this.miAddLedgeLine.Text = "Добавить связь";
            this.miAddLedgeLine.Click += new System.EventHandler(this.miAddLedgeLine_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(172, 6);
            // 
            // miDelete
            // 
            this.miDelete.Name = "miDelete";
            this.miDelete.Size = new System.Drawing.Size(175, 22);
            this.miDelete.Text = "Удалить";
            this.miDelete.Click += new System.EventHandler(this.miDelete_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(172, 6);
            // 
            // bringToFrontToolStripMenuItem
            // 
            this.bringToFrontToolStripMenuItem.Name = "bringToFrontToolStripMenuItem";
            this.bringToFrontToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.bringToFrontToolStripMenuItem.Text = "На передний план";
            this.bringToFrontToolStripMenuItem.Click += new System.EventHandler(this.bringToFrontToolStripMenuItem_Click);
            // 
            // sendToBackToolStripMenuItem
            // 
            this.sendToBackToolStripMenuItem.Name = "sendToBackToolStripMenuItem";
            this.sendToBackToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.sendToBackToolStripMenuItem.Text = "На задний план";
            this.sendToBackToolStripMenuItem.Click += new System.EventHandler(this.sendToBackToolStripMenuItem_Click);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Location = new System.Drawing.Point(349, 478);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(91, 23);
            this.textBox2.TabIndex = 5;
            this.textBox2.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Location = new System.Drawing.Point(3, 338);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 48);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Сохранить в БД";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Location = new System.Drawing.Point(3, 392);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 48);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Удалить из БД";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.button2_Click);
            // 
            // selectTask
            // 
            this.selectTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectTask.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.selectTask.Location = new System.Drawing.Point(690, 14);
            this.selectTask.Name = "selectTask";
            this.selectTask.Size = new System.Drawing.Size(75, 48);
            this.selectTask.TabIndex = 8;
            this.selectTask.Text = "Выбрать задание";
            this.selectTask.UseVisualStyleBackColor = true;
            this.selectTask.Click += new System.EventHandler(this.selectTask_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCheck.Location = new System.Drawing.Point(749, 478);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(119, 23);
            this.btnCheck.TabIndex = 9;
            this.btnCheck.Text = "Проверить";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.button3_Click);
            // 
            // tb_password
            // 
            this.tb_password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tb_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_password.Location = new System.Drawing.Point(591, 478);
            this.tb_password.Multiline = true;
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(152, 23);
            this.tb_password.TabIndex = 10;
            this.tb_password.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.btnCycleEndAdd);
            this.panel1.Controls.Add(this.btnCycleStartAdd);
            this.panel1.Controls.Add(this.btnStartEndAdd);
            this.panel1.Controls.Add(this.btnParalelogrammAdd);
            this.panel1.Controls.Add(this.btnRectAdd);
            this.panel1.Controls.Add(this.btnRhombAdd);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(3, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(96, 476);
            this.panel1.TabIndex = 11;
            // 
            // btnCycleEndAdd
            // 
            this.btnCycleEndAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnCycleEndAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCycleEndAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCycleEndAdd.Location = new System.Drawing.Point(3, 284);
            this.btnCycleEndAdd.Name = "btnCycleEndAdd";
            this.btnCycleEndAdd.Size = new System.Drawing.Size(91, 48);
            this.btnCycleEndAdd.TabIndex = 5;
            this.btnCycleEndAdd.Tag = "CycleEnd";
            this.btnCycleEndAdd.Text = "Конец цикла";
            this.btnCycleEndAdd.UseVisualStyleBackColor = false;
            this.btnCycleEndAdd.Click += new System.EventHandler(this.btnRectAdd_Click_1);
            // 
            // btnCycleStartAdd
            // 
            this.btnCycleStartAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnCycleStartAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCycleStartAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCycleStartAdd.Location = new System.Drawing.Point(3, 230);
            this.btnCycleStartAdd.Name = "btnCycleStartAdd";
            this.btnCycleStartAdd.Size = new System.Drawing.Size(91, 48);
            this.btnCycleStartAdd.TabIndex = 4;
            this.btnCycleStartAdd.Tag = "CycleStart";
            this.btnCycleStartAdd.Text = "Начало цикла";
            this.btnCycleStartAdd.UseVisualStyleBackColor = false;
            this.btnCycleStartAdd.Click += new System.EventHandler(this.btnRectAdd_Click_1);
            // 
            // btnStartEndAdd
            // 
            this.btnStartEndAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnStartEndAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStartEndAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartEndAdd.Location = new System.Drawing.Point(2, 14);
            this.btnStartEndAdd.Name = "btnStartEndAdd";
            this.btnStartEndAdd.Size = new System.Drawing.Size(91, 48);
            this.btnStartEndAdd.TabIndex = 3;
            this.btnStartEndAdd.Tag = "StartEnd";
            this.btnStartEndAdd.Text = "Начало и конец ";
            this.btnStartEndAdd.UseVisualStyleBackColor = false;
            this.btnStartEndAdd.Click += new System.EventHandler(this.btnRectAdd_Click_1);
            // 
            // btnParalelogrammAdd
            // 
            this.btnParalelogrammAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnParalelogrammAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnParalelogrammAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParalelogrammAdd.Location = new System.Drawing.Point(3, 122);
            this.btnParalelogrammAdd.Name = "btnParalelogrammAdd";
            this.btnParalelogrammAdd.Size = new System.Drawing.Size(91, 48);
            this.btnParalelogrammAdd.TabIndex = 2;
            this.btnParalelogrammAdd.Tag = "Paralelogramm";
            this.btnParalelogrammAdd.Text = "Ввод и вывод данных";
            this.btnParalelogrammAdd.UseVisualStyleBackColor = false;
            this.btnParalelogrammAdd.Click += new System.EventHandler(this.btnRectAdd_Click_1);
            // 
            // btnRectAdd
            // 
            this.btnRectAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnRectAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRectAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRectAdd.Location = new System.Drawing.Point(3, 176);
            this.btnRectAdd.Name = "btnRectAdd";
            this.btnRectAdd.Size = new System.Drawing.Size(91, 48);
            this.btnRectAdd.TabIndex = 0;
            this.btnRectAdd.Tag = "Rectangle";
            this.btnRectAdd.Text = "Выполнение операции";
            this.btnRectAdd.UseVisualStyleBackColor = false;
            this.btnRectAdd.Click += new System.EventHandler(this.btnRectAdd_Click_1);
            // 
            // btnRhombAdd
            // 
            this.btnRhombAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnRhombAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRhombAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRhombAdd.Location = new System.Drawing.Point(3, 68);
            this.btnRhombAdd.Name = "btnRhombAdd";
            this.btnRhombAdd.Size = new System.Drawing.Size(91, 48);
            this.btnRhombAdd.TabIndex = 1;
            this.btnRhombAdd.Tag = "Rhomb";
            this.btnRhombAdd.Text = "Ветвление";
            this.btnRhombAdd.UseVisualStyleBackColor = false;
            this.btnRhombAdd.Click += new System.EventHandler(this.btnRectAdd_Click_1);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClearAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClearAll.Location = new System.Drawing.Point(105, 477);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(91, 23);
            this.btnClearAll.TabIndex = 6;
            this.btnClearAll.Text = "Очистить поле";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(529, 477);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 12;
            this.label1.Text = "Пароль";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // lblTask
            // 
            this.lblTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTask.BackColor = System.Drawing.Color.Transparent;
            this.lblTask.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTask.ForeColor = System.Drawing.Color.Red;
            this.lblTask.Location = new System.Drawing.Point(3, 14);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(679, 48);
            this.lblTask.TabIndex = 13;
            this.lblTask.Tag = "";
            this.lblTask.Text = "ВЫБЕРИТЕ ЗАДАНИЕ ";
            this.lblTask.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.lblTask);
            this.panel2.Controls.Add(this.selectTask);
            this.panel2.Location = new System.Drawing.Point(103, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(777, 68);
            this.panel2.TabIndex = 14;
            // 
            // ssMain
            // 
            this.ssMain.Location = new System.Drawing.Point(0, 503);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(880, 22);
            this.ssMain.TabIndex = 0;
            this.ssMain.Text = "statusStrip1";
            // 
            // dbDiagram
            // 
            this.dbDiagram.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbDiagram.AutoScroll = true;
            this.dbDiagram.BackColor = System.Drawing.SystemColors.Control;
            this.dbDiagram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dbDiagram.Diagram = null;
            this.dbDiagram.Location = new System.Drawing.Point(106, 95);
            this.dbDiagram.Name = "dbDiagram";
            this.dbDiagram.SelectedFigure = null;
            this.dbDiagram.Size = new System.Drawing.Size(762, 376);
            this.dbDiagram.TabIndex = 3;
            this.dbDiagram.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dbDiagram_KeyDown);
            this.dbDiagram.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dbDiagram_MouseDoubleClick);
            this.dbDiagram.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dbDiagram_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 525);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.dbDiagram);
            this.Controls.Add(this.ssMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(896, 563);
            this.Name = "Form1";
            this.Text = "Algorithmization Training";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.cmSelectedFigure.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private DiagramBox dbDiagram;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miNew;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem miClose;
        private System.Windows.Forms.ToolStripMenuItem miExport;
        private System.Windows.Forms.SaveFileDialog sfdImage;
        private System.Windows.Forms.ContextMenuStrip cmSelectedFigure;
        private System.Windows.Forms.ToolStripMenuItem miEditText;
        private System.Windows.Forms.ToolStripMenuItem miAddLedgeLine;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bringToFrontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendToBackToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button selectTask;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCycleEndAdd;
        private System.Windows.Forms.Button btnCycleStartAdd;
        private System.Windows.Forms.Button btnStartEndAdd;
        private System.Windows.Forms.Button btnParalelogrammAdd;
        private System.Windows.Forms.Button btnRhombAdd;
        private System.Windows.Forms.Button btnRectAdd;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Label lblTask;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.StatusStrip ssMain;
    }
}

