﻿using NIdenticon;
using NIdenticon.BrushGenerators;
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
            ColorGenBox.SelectedItem = "Random";
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            try
            {
                var bg = ColorGenBox.Text.Equals("Random") ? (IBrushGenerator)new RandomColorBrushGenerator() : new StaticColorBrushGenerator(StaticColorBrushGenerator.ColorFromText(ValueBox.Text));
                ResultBox.Image = new IdenticonGenerator(AlgorithmBox.Text)
                    .WithSize((int)WidthBox.Value, (int)HeightBox.Value)
                    .WithBackgroundColor(BackgroundColorBox.BackColor)
                    .WithBlocks((int)HorizontalBox.Value, (int)VerticalBox.Value)
                    .WithBlockGenerators(IdenticonGenerator.ExtendedBlockGeneratorsConfig)
                    .WithBrushGenerator(bg)
                    .Create(ValueBox.Text);
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
                {
                    BackgroundColorBox.BackColor = c.Color;
                }
            }
        }
    }
}
