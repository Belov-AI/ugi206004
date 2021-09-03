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
        Bitmap originalBmp;
        Bitmap resultBmp;
        public MainForm()
        {
            InitializeComponent();

            comboBoxFilters.Items.Add("Осветление/затемнение");
            originalBmp = Image.FromFile("cat.jpg") as Bitmap;
            pictureBoxOriginal.Image = originalBmp;
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
            resultBmp = new Bitmap(originalBmp.Width, originalBmp.Height);
            
            if(comboBoxFilters.SelectedItem.ToString() == "Осветление/затемнение")
            {
                for (int x = 0; x < originalBmp.Width; x++)
                    for(int y = 0; y < originalBmp.Height; y++)
                    {
                        var pixelColor = originalBmp.GetPixel(x, y);

                        var k = (double)(parametersPanel.Controls["coefficient"] as NumericUpDown).Value;

                        var newR = (int)(pixelColor.R * k);
                        if (newR > 255) newR = 255;

                        var newG = (int)(pixelColor.G * k);
                        if (newG > 255) newG = 255;

                        var newB = (int)(pixelColor.B * k);
                        if (newB > 255) newB = 255;

                        resultBmp.SetPixel(x, y, Color.FromArgb(newR, newG, newB));
                    }

                pictureBoxResult.Image = resultBmp;
            }
        }
    }
}
