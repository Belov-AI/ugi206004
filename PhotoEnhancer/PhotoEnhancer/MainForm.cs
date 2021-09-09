using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoEnhancer
{
    public partial class MainForm : Form
    {
        Panel parametersPanel;
        //Bitmap originalBmp;
        //Bitmap resultBmp;

        Photo originalPhoto;
        Photo resultPhoto;
        public MainForm()
        {
            InitializeComponent();

            comboBoxFilters.Items.Add("Осветление/затемнение");
            var orig = Image.FromFile("cat.jpg") as Bitmap;
            originalPhoto = Convertors.Bimap2Photo(orig);
            pictureBoxOriginal.Image = orig;
        }

        private void comboBoxFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (parametersPanel != null)
                Controls.Remove(parametersPanel);

            parametersPanel = new Panel();
            //parametersPanel.BackColor = Color.DarkGray;
            parametersPanel.Left = comboBoxFilters.Left;
            parametersPanel.Top = comboBoxFilters.Bottom + 10;
            parametersPanel.Width = comboBoxFilters.Width;
            parametersPanel.Height = buttonApply.Top - comboBoxFilters.Bottom - 20;

            var filter = comboBoxFilters.SelectedItem;

            if(filter.ToString() == "Осветление/затемнение")
            {
                var label = new Label();
                label.Left = 0;
                label.Top = 0;
                label.Width = parametersPanel.Width - 50;
                label.Height = 20;
                label.Text = "Коэффициент";
                parametersPanel.Controls.Add(label);

                var inputBox = new NumericUpDown();
                inputBox.Left = label.Right;
                inputBox.Top = label.Top;
                inputBox.Width = 50;
                inputBox.Height = label.Height;
                inputBox.Minimum = 0;
                inputBox.Maximum = 10;
                inputBox.Increment = (decimal)0.05;
                inputBox.DecimalPlaces = 2;
                inputBox.Value = 1;
                inputBox.Name = "coefficient";
                parametersPanel.Controls.Add(inputBox);
            }

            Controls.Add(parametersPanel);
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            //resultBmp = new Bitmap(originalBmp.Width, originalBmp.Height);
            var newPhoto = new Photo(originalPhoto.Width, originalPhoto.Height);
            
            if(comboBoxFilters.SelectedItem.ToString() == "Осветление/затемнение")
            {
                for (int x = 0; x < originalPhoto.Width; x++)
                    for(int y = 0; y < originalPhoto.Height; y++)
                    {
                        var pixel = originalPhoto.Data[x, y];

                        var k = (double)(parametersPanel.Controls["coefficient"] as NumericUpDown).Value;

                        var newR = pixel.R * k;
                        if (newR > 1) newR = 1;

                        var newG = pixel.G * k;
                        if (newG > 1) newG = 1;

                        var newB = pixel.B * k;
                        if (newB > 1) newB = 1;

                        newPhoto.Data[x, y].R = newR;
                        newPhoto.Data[x, y].B = newB;
                        newPhoto.Data[x, y].G = newG;

                    }

                pictureBoxResult.Image = Convertors.Photo2Bitmap(newPhoto);
            }
        }
    }
}
