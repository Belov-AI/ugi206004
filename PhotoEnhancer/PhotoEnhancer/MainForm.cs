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
        Photo originalPhoto;
        Photo resultPhoto;
        List<NumericUpDown> parameterControls;

        const int lineHeight = 20;
        const int linesGap = 10;
        const int inputFieldWidth = 50;

        public MainForm()
        {
            InitializeComponent();

            var orig = Image.FromFile("cat.jpg") as Bitmap;
            originalPhoto = Convertors.Bimap2Photo(orig);
            pictureBoxOriginal.Image = orig;
        }

        private void comboBoxFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (parametersPanel != null)
                Controls.Remove(parametersPanel);

            parametersPanel = new Panel();

            parametersPanel.Left = comboBoxFilters.Left;
            parametersPanel.Top = comboBoxFilters.Bottom + linesGap;
            parametersPanel.Width = comboBoxFilters.Width;
            parametersPanel.Height = buttonApply.Top - comboBoxFilters.Bottom - lineHeight;

            var filter = comboBoxFilters.SelectedItem as IFilter;

            if (filter == null) return;

            parameterControls = new List<NumericUpDown>();

            var filterParameters = filter.GetParametersInfo();

            for(var i = 0; i < filterParameters.Length; i++)
            {
                var label = new Label();
                label.Height = lineHeight;
                label.Left = 0;
                label.Top = i * (label.Height + linesGap);
                label.Width = parametersPanel.Width - inputFieldWidth;
                label.Text = filterParameters[i].Name;
                parametersPanel.Controls.Add(label);

                var inputBox = new NumericUpDown();
                inputBox.Left = label.Right;
                inputBox.Top = label.Top;
                inputBox.Width = inputFieldWidth;
                inputBox.Height = label.Height;
                inputBox.DecimalPlaces = 2;
                inputBox.Minimum = (decimal)filterParameters[i].MinValue;
                inputBox.Maximum = (decimal)filterParameters[i].MaxValue;
                inputBox.Increment = (decimal)filterParameters[i].Increment;
                inputBox.Value = (decimal)filterParameters[i].DefaultValue;
                parameterControls.Add(inputBox);
                parametersPanel.Controls.Add(inputBox);
            }

            Controls.Add(parametersPanel);
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            var filter = comboBoxFilters.SelectedItem as IFilter;

            var parameters = new double[parameterControls.Count];

            for (var i = 0; i < parameters.Length; i++)
                parameters[i] = (double)parameterControls[i].Value;

            resultPhoto = filter.Process(originalPhoto, parameters);
            pictureBoxResult.Image = Convertors.Photo2Bitmap(resultPhoto);
        }

        public void AddFilter(IFilter filter)
        {
            comboBoxFilters.Items.Add(filter);

            if(comboBoxFilters.SelectedIndex == -1)
                comboBoxFilters.SelectedIndex = 0;
        }
    }
}
