using System;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace BWViewerCSharp
{
    /// <summary>
    /// Main form of application
    /// </summary>
    public class MainForm : Form
    {
        #region Designer Variables

        private MenuItem helpMenuItem;
        private MenuItem helpAboutMenuItem;
        private OpenFileDialog openFileDialog;
        private MenuItem fileMenuItem;
        private MenuItem editMenuItem;
        private MenuItem editBlurMenuItem;
        private MenuItem openFileMenuItem;
        private MenuItem exitFileMenuItem;
        private MenuItem windowMenuItem;
        private MenuItem cascaedWindowMenuItem;
        private MenuItem tileWindowMenuItem;
        private MenuItem arrangeWindowMenuItem;
        private MenuItem windowNewWindowMenuItem;
        private MenuItem viewZoomInMenuItem;
        private MenuItem viewZoomOutMenuItem;
        private MenuItem stretchBublicMenuItem;
        private MenuItem stretchNeigborMenuItem;
        private MenuItem separatorMenuItem2;
        private MenuItem viewMenuItem;
        private MenuItem editCountourMenuItem;
        private MenuItem editSharpMenuItem;
        private MenuItem editDenoiseMenuItem;
        private MenuItem editHalfMenuItem;
        private MenuItem editSeparatorMenuItem;
        private MenuItem editSeparatorMenuItem2;
        private MenuItem editInvertColorsMenuItem;
        private MenuItem editUndoMenuItem;
        private MainMenu mainMenu;
        private MenuItem editStopMenuItem;
        private MenuItem editSeparatorMenuItem3;
        private MenuItem editHistogramMenuItem;
        private MenuItem editConstrastMenuItem;
        private MenuItem editEmbossMenuItem;
        private MenuItem fileCloseMenuItem;
        private MenuItem fileSaveMenuItem;
        private MenuItem fileSaveAsMenuItem;
        private ImageList imageList;
        private SaveFileDialog saveFileDialog;
        private System.Windows.Forms.MenuItem filePrintPreviewMenuItem;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Windows.Forms.MenuItem filePrintSetupMenuItem;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog;
        private System.Windows.Forms.MenuItem fileSeparatorMenuItem2;
        private System.Windows.Forms.MenuItem filePrintMenuItem;
        private System.Windows.Forms.MenuItem fileSeparatorMenuItem1;
        private IContainer components;
        
        private PrintDocument prDoc = new PrintDocument();

        #endregion

        public MainForm()
        {
            InitializeComponent();
            
            // initialize openFileDialog.Filter property
            StringBuilder openFileFilter = new StringBuilder();
            foreach(ImageCodecInfo codecInfo in ImageCodecInfo.GetImageEncoders())
            {
                openFileFilter.AppendFormat("{0} ({1})|{1}|",codecInfo.FormatDescription,codecInfo.FilenameExtension);                
            }
            // filter to save file dialog without Save All
            this.saveFileDialog.Filter = openFileFilter.ToString().Remove(openFileFilter.Length-1,1);

            openFileFilter.Append("All Files (*.*)|*.*");
            this.openFileDialog.Filter = openFileFilter.ToString();            

            this.UpdateMainMenu();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if (components != null) 
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.fileMenuItem = new System.Windows.Forms.MenuItem();
            this.openFileMenuItem = new System.Windows.Forms.MenuItem();
            this.fileCloseMenuItem = new System.Windows.Forms.MenuItem();
            this.fileSaveMenuItem = new System.Windows.Forms.MenuItem();
            this.fileSaveAsMenuItem = new System.Windows.Forms.MenuItem();
            this.fileSeparatorMenuItem1 = new System.Windows.Forms.MenuItem();
            this.filePrintMenuItem = new System.Windows.Forms.MenuItem();
            this.filePrintPreviewMenuItem = new System.Windows.Forms.MenuItem();
            this.filePrintSetupMenuItem = new System.Windows.Forms.MenuItem();
            this.fileSeparatorMenuItem2 = new System.Windows.Forms.MenuItem();
            this.exitFileMenuItem = new System.Windows.Forms.MenuItem();
            this.editMenuItem = new System.Windows.Forms.MenuItem();
            this.editUndoMenuItem = new System.Windows.Forms.MenuItem();
            this.editStopMenuItem = new System.Windows.Forms.MenuItem();
            this.editSeparatorMenuItem3 = new System.Windows.Forms.MenuItem();
            this.editHalfMenuItem = new System.Windows.Forms.MenuItem();
            this.editSeparatorMenuItem2 = new System.Windows.Forms.MenuItem();
            this.editHistogramMenuItem = new System.Windows.Forms.MenuItem();
            this.editConstrastMenuItem = new System.Windows.Forms.MenuItem();
            this.editInvertColorsMenuItem = new System.Windows.Forms.MenuItem();
            this.editEmbossMenuItem = new System.Windows.Forms.MenuItem();
            this.editSeparatorMenuItem = new System.Windows.Forms.MenuItem();
            this.editBlurMenuItem = new System.Windows.Forms.MenuItem();
            this.editCountourMenuItem = new System.Windows.Forms.MenuItem();
            this.editSharpMenuItem = new System.Windows.Forms.MenuItem();
            this.editDenoiseMenuItem = new System.Windows.Forms.MenuItem();
            this.viewMenuItem = new System.Windows.Forms.MenuItem();
            this.viewZoomInMenuItem = new System.Windows.Forms.MenuItem();
            this.viewZoomOutMenuItem = new System.Windows.Forms.MenuItem();
            this.separatorMenuItem2 = new System.Windows.Forms.MenuItem();
            this.stretchBublicMenuItem = new System.Windows.Forms.MenuItem();
            this.stretchNeigborMenuItem = new System.Windows.Forms.MenuItem();
            this.windowMenuItem = new System.Windows.Forms.MenuItem();
            this.windowNewWindowMenuItem = new System.Windows.Forms.MenuItem();
            this.cascaedWindowMenuItem = new System.Windows.Forms.MenuItem();
            this.tileWindowMenuItem = new System.Windows.Forms.MenuItem();
            this.arrangeWindowMenuItem = new System.Windows.Forms.MenuItem();
            this.helpMenuItem = new System.Windows.Forms.MenuItem();
            this.helpAboutMenuItem = new System.Windows.Forms.MenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.pageSetupDialog = new System.Windows.Forms.PageSetupDialog();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.fileMenuItem,
            this.editMenuItem,
            this.viewMenuItem,
            this.windowMenuItem,
            this.helpMenuItem});
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.Index = 0;
            this.fileMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.openFileMenuItem,
            this.fileCloseMenuItem,
            this.fileSaveMenuItem,
            this.fileSaveAsMenuItem,
            this.fileSeparatorMenuItem1,
            this.filePrintMenuItem,
            this.filePrintPreviewMenuItem,
            this.filePrintSetupMenuItem,
            this.fileSeparatorMenuItem2,
            this.exitFileMenuItem});
            this.fileMenuItem.Text = "&File";
            // 
            // openFileMenuItem
            // 
            this.openFileMenuItem.Index = 0;
            this.openFileMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.openFileMenuItem.Text = "&Open...";
            this.openFileMenuItem.Click += new System.EventHandler(this.openFileMenuItem_Click);
            // 
            // fileCloseMenuItem
            // 
            this.fileCloseMenuItem.Index = 1;
            this.fileCloseMenuItem.Text = "&Close";
            this.fileCloseMenuItem.Click += new System.EventHandler(this.fileCloseMenuItem_Click);
            // 
            // fileSaveMenuItem
            // 
            this.fileSaveMenuItem.Index = 2;
            this.fileSaveMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.fileSaveMenuItem.Text = "&Save";
            // 
            // fileSaveAsMenuItem
            // 
            this.fileSaveAsMenuItem.Index = 3;
            this.fileSaveAsMenuItem.Text = "Save &As...";
            this.fileSaveAsMenuItem.Click += new System.EventHandler(this.fileSaveAsMenuItem_Click);
            // 
            // fileSeparatorMenuItem1
            // 
            this.fileSeparatorMenuItem1.Index = 4;
            this.fileSeparatorMenuItem1.Text = "-";
            // 
            // filePrintMenuItem
            // 
            this.filePrintMenuItem.Index = 5;
            this.filePrintMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
            this.filePrintMenuItem.Text = "&Print...";
            this.filePrintMenuItem.Click += new System.EventHandler(this.filePrintMenuItem_Click);
            // 
            // filePrintPreviewMenuItem
            // 
            this.filePrintPreviewMenuItem.Index = 6;
            this.filePrintPreviewMenuItem.Text = "Print Pre&view...";
            this.filePrintPreviewMenuItem.Click += new System.EventHandler(this.filePrintPreviewMenuItem_Click);
            // 
            // filePrintSetupMenuItem
            // 
            this.filePrintSetupMenuItem.Index = 7;
            this.filePrintSetupMenuItem.Text = "Pa&ge Setup...";
            this.filePrintSetupMenuItem.Click += new System.EventHandler(this.filePrintSetupMenuItem_Click);
            // 
            // fileSeparatorMenuItem2
            // 
            this.fileSeparatorMenuItem2.Index = 8;
            this.fileSeparatorMenuItem2.Text = "-";
            // 
            // exitFileMenuItem
            // 
            this.exitFileMenuItem.Index = 9;
            this.exitFileMenuItem.Text = "&Exit";
            this.exitFileMenuItem.Click += new System.EventHandler(this.exitFileMenuItem_Click);
            // 
            // editMenuItem
            // 
            this.editMenuItem.Index = 1;
            this.editMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.editUndoMenuItem,
            this.editStopMenuItem,
            this.editSeparatorMenuItem3,
            this.editHalfMenuItem,
            this.editSeparatorMenuItem2,
            this.editHistogramMenuItem,
            this.editConstrastMenuItem,
            this.editInvertColorsMenuItem,
            this.editEmbossMenuItem,
            this.editSeparatorMenuItem,
            this.editBlurMenuItem,
            this.editCountourMenuItem,
            this.editSharpMenuItem,
            this.editDenoiseMenuItem});
            this.editMenuItem.Text = "&Edit";
            this.editMenuItem.Click += new System.EventHandler(this.editMenuItem_Click);
            this.editMenuItem.Popup += new System.EventHandler(this.editMenuItem_Popup);
            // 
            // editUndoMenuItem
            // 
            this.editUndoMenuItem.Index = 0;
            this.editUndoMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
            this.editUndoMenuItem.Text = "&Undo";
            this.editUndoMenuItem.Click += new System.EventHandler(this.editUndoMenuItem_Click);
            // 
            // editStopMenuItem
            // 
            this.editStopMenuItem.Index = 1;
            this.editStopMenuItem.Shortcut = System.Windows.Forms.Shortcut.F10;
            this.editStopMenuItem.Text = "&Stop";
            this.editStopMenuItem.Click += new System.EventHandler(this.editStopMenuItem_Click);
            // 
            // editSeparatorMenuItem3
            // 
            this.editSeparatorMenuItem3.Index = 2;
            this.editSeparatorMenuItem3.Text = "-";
            // 
            // editHalfMenuItem
            // 
            this.editHalfMenuItem.Index = 3;
            this.editHalfMenuItem.Text = "Edit Half";
            this.editHalfMenuItem.Click += new System.EventHandler(this.editHalfMenuItem_Click);
            // 
            // editSeparatorMenuItem2
            // 
            this.editSeparatorMenuItem2.Index = 4;
            this.editSeparatorMenuItem2.Text = "-";
            // 
            // editHistogramMenuItem
            // 
            this.editHistogramMenuItem.Index = 5;
            this.editHistogramMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlH;
            this.editHistogramMenuItem.Text = "&Histrogram...";
            this.editHistogramMenuItem.Click += new System.EventHandler(this.editHistogramMenuItem_Click);
            // 
            // editConstrastMenuItem
            // 
            this.editConstrastMenuItem.Index = 6;
            this.editConstrastMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlB;
            this.editConstrastMenuItem.Text = "&Brightness and Contrast...";
            this.editConstrastMenuItem.Click += new System.EventHandler(this.editConstrastMenuItem_Click);
            // 
            // editInvertColorsMenuItem
            // 
            this.editInvertColorsMenuItem.Index = 7;
            this.editInvertColorsMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlI;
            this.editInvertColorsMenuItem.Text = "Invert Colors";
            this.editInvertColorsMenuItem.Click += new System.EventHandler(this.editInvertColorsMenuItem_Click);
            // 
            // editEmbossMenuItem
            // 
            this.editEmbossMenuItem.Index = 8;
            this.editEmbossMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlE;
            this.editEmbossMenuItem.Text = "&Emboss";
            this.editEmbossMenuItem.Click += new System.EventHandler(this.editEmbossMenuItem_Click);
            // 
            // editSeparatorMenuItem
            // 
            this.editSeparatorMenuItem.Index = 9;
            this.editSeparatorMenuItem.Text = "-";
            // 
            // editBlurMenuItem
            // 
            this.editBlurMenuItem.Index = 10;
            this.editBlurMenuItem.Text = "B&lur";
            this.editBlurMenuItem.Click += new System.EventHandler(this.editBlurMenuItem_Click);
            // 
            // editCountourMenuItem
            // 
            this.editCountourMenuItem.Index = 11;
            this.editCountourMenuItem.Text = "Contour";
            this.editCountourMenuItem.Click += new System.EventHandler(this.editCountourMenuItem_Click);
            // 
            // editSharpMenuItem
            // 
            this.editSharpMenuItem.Index = 12;
            this.editSharpMenuItem.Text = "Sharp";
            this.editSharpMenuItem.Click += new System.EventHandler(this.editSharpMenuItem_Click);
            // 
            // editDenoiseMenuItem
            // 
            this.editDenoiseMenuItem.Index = 13;
            this.editDenoiseMenuItem.Text = "DeNoise...";
            this.editDenoiseMenuItem.Click += new System.EventHandler(this.editDenoiseMenuItem_Click);
            // 
            // viewMenuItem
            // 
            this.viewMenuItem.Index = 2;
            this.viewMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.viewZoomInMenuItem,
            this.viewZoomOutMenuItem,
            this.separatorMenuItem2,
            this.stretchBublicMenuItem,
            this.stretchNeigborMenuItem});
            this.viewMenuItem.Text = "&View";
            this.viewMenuItem.Popup += new System.EventHandler(this.viewMenuItem_Popup);
            // 
            // viewZoomInMenuItem
            // 
            this.viewZoomInMenuItem.Index = 0;
            this.viewZoomInMenuItem.Shortcut = System.Windows.Forms.Shortcut.Ctrl1;
            this.viewZoomInMenuItem.Text = "Zoom &In";
            this.viewZoomInMenuItem.Click += new System.EventHandler(this.viewZoomInMenuItem_Click);
            // 
            // viewZoomOutMenuItem
            // 
            this.viewZoomOutMenuItem.Index = 1;
            this.viewZoomOutMenuItem.Shortcut = System.Windows.Forms.Shortcut.Ctrl2;
            this.viewZoomOutMenuItem.Text = "Zoom &Out";
            this.viewZoomOutMenuItem.Click += new System.EventHandler(this.viewZoomOutMenuItem_Click);
            // 
            // separatorMenuItem2
            // 
            this.separatorMenuItem2.Index = 2;
            this.separatorMenuItem2.Text = "-";
            // 
            // stretchBublicMenuItem
            // 
            this.stretchBublicMenuItem.Checked = true;
            this.stretchBublicMenuItem.Index = 3;
            this.stretchBublicMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftB;
            this.stretchBublicMenuItem.Text = "Stretch &BICUBIC";
            this.stretchBublicMenuItem.Click += new System.EventHandler(this.stretchBublicMenuItem_Click);
            // 
            // stretchNeigborMenuItem
            // 
            this.stretchNeigborMenuItem.Index = 4;
            this.stretchNeigborMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftN;
            this.stretchNeigborMenuItem.Text = "Stretch &NEIGHBOR";
            this.stretchNeigborMenuItem.Click += new System.EventHandler(this.stretchNeigborMenuItem_Click);
            // 
            // windowMenuItem
            // 
            this.windowMenuItem.Index = 3;
            this.windowMenuItem.MdiList = true;
            this.windowMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.windowNewWindowMenuItem,
            this.cascaedWindowMenuItem,
            this.tileWindowMenuItem,
            this.arrangeWindowMenuItem});
            this.windowMenuItem.Text = "&Window";
            // 
            // windowNewWindowMenuItem
            // 
            this.windowNewWindowMenuItem.Index = 0;
            this.windowNewWindowMenuItem.Text = "&New Window";
            this.windowNewWindowMenuItem.Click += new System.EventHandler(this.windowNewWindowMenuItem_Click);
            // 
            // cascaedWindowMenuItem
            // 
            this.cascaedWindowMenuItem.Index = 1;
            this.cascaedWindowMenuItem.Text = "&Cascade";
            this.cascaedWindowMenuItem.Click += new System.EventHandler(this.cascaedWindowMenuItem_Click);
            // 
            // tileWindowMenuItem
            // 
            this.tileWindowMenuItem.Index = 2;
            this.tileWindowMenuItem.Text = "&Tile";
            this.tileWindowMenuItem.Click += new System.EventHandler(this.tileWindowMenuItem_Click);
            // 
            // arrangeWindowMenuItem
            // 
            this.arrangeWindowMenuItem.Index = 3;
            this.arrangeWindowMenuItem.Text = "&Arrange Icons";
            this.arrangeWindowMenuItem.Click += new System.EventHandler(this.arrangeWindowMenuItem_Click);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.Index = 4;
            this.helpMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.helpAboutMenuItem});
            this.helpMenuItem.Text = "&Help";
            // 
            // helpAboutMenuItem
            // 
            this.helpAboutMenuItem.Index = 0;
            this.helpAboutMenuItem.Text = "&About BWViewer...";
            this.helpAboutMenuItem.Click += new System.EventHandler(this.helpMenuItem_Click);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(712, 366);
            this.IsMdiContainer = true;
            this.Menu = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "BWViewer";
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            Application.Run(new MainForm());
        }

        #region Open/Close/Save

        /// <summary>
        /// Opens and add file
        /// </summary>
        /// <param name="fileName">name of the file</param>
        private void OpenFile(string fileName)
        {
            try
            {
                // create document
                BMDocument doc = new BMDocument(fileName);

                // create view
                ChildForm form = new ChildForm(doc);
                form.MdiParent = this;
                form.Show();
                // adding view to main form
                doc.AddView(form);
            }
            catch(Exception ex)
            {
                MessageBox.Show(String.Format("Image file {0} coouldn't be loaded due error : {1}",
                    fileName,ex.Message));              
            }           
        }


        private void openFileMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog()==DialogResult.OK)
            {
                this.OpenFile(this.openFileDialog.FileName);
            }
            // updates menu state
            this.UpdateMainMenu();
        }

        // file - > Save as ...
        private void fileSaveAsMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is ChildForm)
            {
                // get document
                BMDocument doc = (this.ActiveMdiChild as ChildForm).Document;

                Guid formatGuid;
                formatGuid = doc.CurrentBM.RawFormat.Guid;
                int n = 0; // filter index
                ImageCodecInfo[] codecList = ImageCodecInfo.GetImageEncoders();
                for (n = 1; n < codecList.Length; n++)
                {
                    if (codecList[n].FormatID == formatGuid)
                        break;
                }
                // set current filter (curent image type)
                this.saveFileDialog.FilterIndex = n + 1;

                // if User clicks ok in save file dialog
                if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // saves file in format, that user choose
                        doc.CurrentBM.Save(this.saveFileDialog.FileName, new ImageFormat(codecList[this.saveFileDialog.FilterIndex - 1].Clsid));                        
                        //doc.FileName = this.saveFileDialog.FileName; // dont set to docuemnt new file name
                        doc.Modified = false;// set modified flag to false
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(String.Format("Couldn't save file :  {0}", ex.Message), "BWViewer");
                    }
                }
            }
        }

        /// <summary>
        /// Closes the document view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileCloseMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is ChildForm)
            {
                this.ActiveMdiChild.Close();
            }

            this.UpdateMainMenu();
        }

        #endregion

        private void exitFileMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Layout MDI

        private void cascaedWindowMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void tileWindowMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void arrangeWindowMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        #endregion

        // add new window (yet another view for the document)
        private void windowNewWindowMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is ChildForm)
            {
                BMDocument doc = (this.ActiveMdiChild as ChildForm).Document;
                ChildForm form = new ChildForm(doc);
                form.MdiParent = this;              
                form.Show();

                doc.AddView(form);
            }
        }

        #region Zoom and stretch mode

        private void viewZoomInMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is ChildForm)
            {
                (this.ActiveMdiChild as ChildForm).ZoomIn();
            }
        }

        private void viewZoomOutMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is ChildForm)
            {
                (this.ActiveMdiChild as ChildForm).ZoomOut();
            }
        }

        private void stretchBublicMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.stretchBublicMenuItem.Checked )
            {
                this.stretchBublicMenuItem.Checked = true;
                this.stretchNeigborMenuItem.Checked = false;
                if (this.ActiveMdiChild is ChildForm)
                {
                    (this.ActiveMdiChild as ChildForm).StrecthBublic();
                }
            }
        }

        private void stretchNeigborMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.stretchNeigborMenuItem.Checked )
            {
                this.stretchBublicMenuItem.Checked = false;
                this.stretchNeigborMenuItem.Checked = true;
                if (this.ActiveMdiChild is ChildForm)
                {
                    (this.ActiveMdiChild as ChildForm).StrecthNeighbor();
                }
            }
        }

        #endregion

        #region Updating Menu

        private void viewMenuItem_Popup(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is ChildForm)
            {
                // set mode of the current view
                this.stretchBublicMenuItem.Checked = (this.ActiveMdiChild as ChildForm).CurrentMode == InterpolationMode.HighQualityBicubic;
                this.stretchNeigborMenuItem.Checked = (this.ActiveMdiChild as ChildForm).CurrentMode == InterpolationMode.NearestNeighbor;
            }
        }

        private void UpdateMainMenu()
        {
            // if one or more documents are opened
            if (this.MdiChildren.Length > 0)
            {
                // file menu
                this.fileCloseMenuItem.Enabled = true;
                this.fileSaveAsMenuItem.Enabled = true;
                this.fileSaveMenuItem.Enabled = true;
                // edit menu
                this.editMenuItem.Visible = true;
                // view menu
                this.viewMenuItem.Visible = true;
                // window menu
                this.windowMenuItem.Visible = true;

                this.filePrintMenuItem.Visible = true;
                this.filePrintPreviewMenuItem.Visible = true;
            }
            else// if no documents are opened
            {
                // file menu
                this.fileCloseMenuItem.Enabled = false;
                this.fileSaveAsMenuItem.Enabled = false;
                this.fileSaveMenuItem.Enabled = false;
                this.filePrintMenuItem.Visible = false;
                this.filePrintPreviewMenuItem.Visible = false;

                // edit menu
                this.editMenuItem.Visible = false;
                
                // view menu
                this.viewMenuItem.Visible = false;
                this.windowMenuItem.Visible = false;
            }
        }
                

        private void editMenuItem_Popup(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is ChildForm)
            {
                BMDocument doc = (this.ActiveMdiChild as ChildForm).Document;
                
                // set properties of current document
                this.editHalfMenuItem.Checked = doc.EditHalf;
                this.editUndoMenuItem.Enabled = doc.UndoEnabled;
                // stop operation enable ?
                this.editStopMenuItem.Enabled = !doc.Editable;
                // disable or enable filter operations
                this.editBlurMenuItem.Enabled = doc.Editable;
                this.editConstrastMenuItem.Enabled = doc.Editable;
                this.editCountourMenuItem.Enabled = doc.Editable;
                this.editDenoiseMenuItem.Enabled = doc.Editable;
                this.editEmbossMenuItem.Enabled = doc.Editable;
                this.editHistogramMenuItem.Enabled = doc.Editable;
                this.editInvertColorsMenuItem.Enabled = doc.Editable;
                this.editSharpMenuItem.Enabled = doc.Editable;
            }
        }

        #endregion

        // edit - > Edit Half
        private void editHalfMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is ChildForm)
            {
                this.editHalfMenuItem.Checked = !this.editHalfMenuItem.Checked;
                (this.ActiveMdiChild as ChildForm).Document.EditHalf = this.editHalfMenuItem.Checked;
            }
        }

        #region Applying filters

        private void editBlurMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is ChildForm)
            {
                (this.ActiveMdiChild as ChildForm).Document.Blur();
            }
        }

        private void editCountourMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is ChildForm)
            {
                (this.ActiveMdiChild as ChildForm).Document.Countor();
            }
        }

        private void editSharpMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is ChildForm)
            {
                (this.ActiveMdiChild as ChildForm).Document.Sharp();
            }
        }

        private void editDenoiseMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is ChildForm)
            {                               
                using (DeNoiseDialog dlg = new DeNoiseDialog())
                {
                    if (dlg.ShowDialog()==DialogResult.OK)
                        (this.ActiveMdiChild as ChildForm).Document.DeNoise(dlg.WhatToDo,dlg.DK);
                }
            }
        }

        private void editInvertColorsMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is ChildForm)
            {
                (this.ActiveMdiChild as ChildForm).Document.InvertColors();
            }
        }

        private void editUndoMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is ChildForm)
            {
                (this.ActiveMdiChild as ChildForm).Document.Undo();
            }
        }

        private void editEmbossMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is ChildForm)
            {
                (this.ActiveMdiChild as ChildForm).Document.Emboss();
            }
        }

        private void editHistogramMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is ChildForm)
            {
                int Range = 256;
                uint [] Hist;
                if (!(this.ActiveMdiChild as ChildForm).Document.GetHistogramm(Range,out Hist))
                    return;


                using (HistogramDialog dlg  = new HistogramDialog())
                {
                    dlg.SetData(Hist,Range);
                    if (dlg.ShowDialog()==DialogResult.OK)
                    {
                        (this.ActiveMdiChild as ChildForm).Document.Histogram(dlg.OffsetB,dlg.OffsetT,dlg.SelectedColor);
                    }
                }
            }
        }

        private void editConstrastMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is ChildForm)
            {
                using (BrightnessAndContrastDialog dlg = new BrightnessAndContrastDialog())
                {
                    if (dlg.ShowDialog()==DialogResult.OK)
                        (this.ActiveMdiChild as ChildForm).Document.BrightnessAndContrast(dlg.BrightnessOffset,
                            dlg.ContrastOffset);
                }
            }
        }

        #endregion

        // edit - > Stop 
        private void editStopMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is ChildForm)
            {
                (this.ActiveMdiChild as ChildForm).Document.EventDoTransform.Set();
            }
        }

        private void helpMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutForm form = new AboutForm())
            {
                form.ShowDialog();
            }
        }

        #region Printing

        private void filePrintPreviewMenuItem_Click(object sender, System.EventArgs e)
        {
            if (this.ActiveMdiChild is ChildForm)
            {                               
                BMDocument doc = (this.ActiveMdiChild as ChildForm).Document;               
                doc.SubscribeToPrint(prDoc);
                this.printPreviewDialog.Document = prDoc;                   
                this.printPreviewDialog.ShowDialog();
                doc.UnsubscribeToPrint(prDoc);
            }
        }

        private void filePrintSetupMenuItem_Click(object sender, System.EventArgs e)
        {
            this.pageSetupDialog.Document = this.prDoc;
            this.pageSetupDialog.ShowDialog();
        }

        private void filePrintMenuItem_Click(object sender, System.EventArgs e)
        {
            if (this.ActiveMdiChild is ChildForm)
            {                               
                BMDocument doc = (this.ActiveMdiChild as ChildForm).Document;               
                
                try
                {
                    doc.SubscribeToPrint(prDoc);
                    prDoc.Print();
                }
                finally
                {
                    doc.UnsubscribeToPrint(prDoc);
                }
            }
        }

        #endregion

        private void editMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
