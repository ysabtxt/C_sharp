// event handler is a method na bounded
// object holds address kung sno nag invoke ng object
// eventargsclass that represents the base class of other event handlers
// para maiba start uop project, click name ng file tas click startup project


using System;
using System.Windows.Forms;
using System.Drawing;
namespace Module_5_Disucssion_Cont_TX21
{
    internal class MyGUIApp : Form
    {
        Label lblDisplay;
        Button btnGameDesign, btnAgd;
        RadioButton rbRed, rbGreen;
        CheckBox cbBold, cbItalic;
        TextBox txtMessage;
        ComboBox cbxFontSize;
        ListBox lsbFontFace;
        MainMenu mnuAppBar;
        MenuItem miFile,miNew,miClose;
        int ctr;
        
        public MyGUIApp()
        {
            ctr = 0;
            lblDisplay = new Label();
            btnGameDesign = new Button();
            btnAgd = new Button();
            rbRed = new RadioButton();
            rbGreen = new RadioButton();
            cbBold = new CheckBox();
            cbItalic = new CheckBox();
            txtMessage = new TextBox();
            cbxFontSize = new ComboBox();
            lsbFontFace = new ListBox();
            mnuAppBar = new MainMenu();
            miFile = new MenuItem("File");
            miNew = new MenuItem("New");
            miClose = new MenuItem("Close");
        }
        public void launch()
        {
            Size = new Size(400, 600); //size of the form upon opening
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false; // wala si maximize button
            FormBorderStyle = FormBorderStyle.Fixed3D; // unchangeable
            Text = "My Form"; //label sa title bar

            // menu - para syang title bar
            mnuAppBar.MenuItems.Add(miFile);
            miFile.MenuItems.Add(miNew); // dropdown from menu item file; if not dropdown then: mnuApp.MenuItems.Add(miNew)
            miFile.MenuItems.Add(miClose); // dropdown from menu item file
            Menu = mnuAppBar; //property from a fom class
            miClose.Click += CloseApp;

            //Label
            lblDisplay.Text = "Sample Message";
            lblDisplay.Font = new Font("Arial", 20, FontStyle.Regular);
            lblDisplay.Bounds = new Rectangle(20, 30, 400, 60);
            lblDisplay.ForeColor = Color.Red;
            Controls.Add(lblDisplay);

            //Button 1
            btnAgd.Text = "AGD";
            btnAgd.Font = new Font("Arial", 12, FontStyle.Bold);
            btnAgd.Bounds = new Rectangle(20, 100, 150, 40);
            Controls.Add(btnAgd);
            btnAgd.Click += ChangeMessage; // change label display

            // Button 2
            btnGameDesign.Text = "Game Design";
            btnGameDesign.Font = new Font("Arial", 12, FontStyle.Bold);
            btnGameDesign.Bounds = new Rectangle(180, 100, 150, 40);
            Controls.Add(btnGameDesign);
            btnGameDesign.Click += ChangeMessage;// change label display

            // & allows to have shortcut key
            rbRed.Text = "R&ed"; // alt + e
            rbRed.Bounds = new Rectangle(20, 160, 100, 30);
            rbRed.Checked = true;
            rbRed.Font = new Font("Arial", 12, FontStyle.Bold);
            rbRed.ForeColor = Color.Red;
            Controls.Add(rbRed);
            rbRed.CheckedChanged += ChangeColor; // CheckhedChanged automatically invokes the event handler => generate method

            
            rbGreen.Text = "&Green";// alt + g
            rbGreen.Bounds = new Rectangle(130, 160, 100, 30);
            rbGreen.Font = new Font("Arial", 12, FontStyle.Bold);
            rbGreen.ForeColor = Color.Green;
            Controls.Add(rbGreen);
            rbGreen.CheckedChanged += ChangeColor;

            // cb can select both; nag iiba value pag cliniclick
            // alt + b
            cbBold.Text = "&Bold";
            cbBold.Bounds = new Rectangle(20, 200, 100, 30);
            cbBold.Font = new Font("Arial",12, FontStyle.Bold);
            Controls.Add(cbBold);
            cbBold.CheckedChanged += ChangeFontStyle;

             // alt + i
            cbItalic.Text = "&Italic";
            cbItalic.Bounds = new Rectangle(130, 200, 100, 30);
            cbItalic.Font = new Font("Arial", 12, FontStyle.Italic);
            Controls.Add(cbItalic);
            cbItalic.CheckedChanged += ChangeFontStyle;

            // region is statement from VStudio; allows u to group different activities
            #region Sample
            txtMessage.Bounds = new Rectangle(20, 250, 200, 40);
            txtMessage.Font = new Font("Arial", 15, FontStyle.Regular);
            Controls.Add(txtMessage);
            //txtMessage.KeyPress += TxtMessage_KeyPress; invoked when may visible presentation ung priness like letters n nums then pag priness shift wala mangyari; space backspace ung acceptable na walang visual rep
            //txtMessage.KeyDown += TxtMessage_KeyDown;
            //txtMessage.KeyUp += TxtMessage_KeyUp;

            // fontsize ng label display
            cbxFontSize.Bounds = new Rectangle(30, 300, 100, 30);
            cbxFontSize.Font = new Font("Arial", 15, FontStyle.Regular);
            for (int i = 9; i <= 72; i++)
            {
                cbxFontSize.Items.Add(i.ToString());
            }
            cbxFontSize.SelectedIndex = 0;
            Controls.Add(cbxFontSize);
            cbxFontSize.SelectedIndexChanged += ChangeSize;
            
            lsbFontFace.Bounds = new Rectangle(150, 300, 200, 150);
            foreach (FontFamily font in FontFamily.Families)
            {
                lsbFontFace.Items.Add(font.Name);
            }
            lsbFontFace.SelectedIndex = 0;
            Controls.Add(lsbFontFace);
            lsbFontFace.SelectedIndexChanged += ChangeFace;

            #endregion
            
            ShowDialog();
        }

        // EVENT HANDLERS
        
        private void CloseApp(object sender, EventArgs e)
        {
            Close();
        }

        // changes font of the label display
        private void ChangeFace(object sender, EventArgs e)
        {
            lblDisplay.Font =
                new Font(lsbFontFace.SelectedItem.ToString(),
                lblDisplay.Font.Size,
                lblDisplay.Font.Style);
        }

        // changes size of the label display
        private void ChangeSize(object sender, EventArgs e)
        {
            lblDisplay.Font = 
                new Font(lblDisplay.Font.FontFamily, 
                int.Parse(cbxFontSize.SelectedItem.ToString()), // converts to string
                lblDisplay.Font.Style);
        }
        
        private void TxtMessage_KeyUp(object sender, KeyEventArgs e)
        {
            Console.WriteLine("UP : " + (char)e.KeyValue); // keyvakue => properties ng event; display equivalent ascii value
        }
        private void TxtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("Down: "+(char)e.KeyValue); // value for them in char is always in uppercase
        }
        private void TxtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("Press: " + e.KeyChar); // shows value ng pinepress na letter
        }

        // nagchachange font ng label
        private void ChangeFontStyle(object sender, EventArgs e)
        {
            FontStyle fontStyle = FontStyle.Regular; //FontStyle is enum/int so cinosombine lng; default is regular
            if (cbBold.Checked)
            {
                fontStyle |= FontStyle.Bold; // | is used to combine enum to the bold font
            }
            if (cbItalic.Checked)
            {
                fontStyle |= FontStyle.Italic;
            }
            lblDisplay.Font = new Font(lblDisplay.Font.FontFamily, lblDisplay.Font.Size, fontStyle);
        }

        // iniiba color ng label display
        private void ChangeColor(object sender, EventArgs e)
        {
            if (rbGreen.Checked)
            {
                lblDisplay.ForeColor = Color.Green;
            }else if (rbRed.Checked)
            {
                lblDisplay.ForeColor= Color.Red;
            }
        }
        
        private void ChangeMessage(object sender, EventArgs e) // event handler when user clicked the button
        {
          /*ctr++; => pag clinick yung button mag increment yung counter sa label
          lblDisplay.Text = ctr.ToString(); => transforms into string para ma output  */ 
            if(sender == btnAgd)
            {
                lblDisplay.Text = "AGD!!!";
            }else if(sender == btnGameDesign)
            {
                lblDisplay.Text = "Game Design!!!";
            }
        }
    }
}






// main class
namespace Module_5_Discussion_Cont_TX21 {
  internal class TestForm{
    static void Main(){
      new MyGUIApp().launch();
    }
  }
  
}
