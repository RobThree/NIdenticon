using Devcorner.NIdenticon;
using Devcorner.NIdenticon.BrushGenerators;
using System;
using System.Windows.Forms;

namespace TestApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            AlgorithmBox.SelectedItem = "SHA512";
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            try
            {
                var g = new IdenticonGenerator(AlgorithmBox.Text);
                ResultBox.Image = g.Create(
                    ValueBox.Text,
                    (int)WidthBox.Value,
                    (int)HeightBox.Value,
                    BackgroundColorBox.BackColor,
                    (int)HorizontalBox.Value,
                    (int)VerticalBox.Value,
                    g.DefaultEncoding,
                    IdenticonGenerator.ExtendedBlockGeneratorsConfig,
                    new StaticColorBrushGenerator(StaticColorBrushGenerator.ColorFromText(ValueBox.Text))
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Uh oh!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BackgroundColorBox_Click(object sender, EventArgs e)
        {
            using (var c = new ColorDialog())
            {
                c.Color = BackgroundColorBox.BackColor;
                c.FullOpen = true;
                if (c.ShowDialog() == DialogResult.OK)
                    BackgroundColorBox.BackColor = c.Color;
            }
        }
    }
}
