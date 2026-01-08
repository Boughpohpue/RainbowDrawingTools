using RainbowDrawingTools.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RainbowDrawingTools.WinformsClient
{
    public partial class RainbowColorsEditForm : Form
    {
        private List<Color> _colors;
        public List<Color> Colors => _colors;

        private DialogResult _result;
        private DialogResult Result => _result;

        public RainbowColorsEditForm()
        {
            InitializeComponent();

            _colors = new List<Color>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // remove
            if (listView1.SelectedItems.Count <= 0)
            {
                return;                
            }

            for (var x = listView1.SelectedItems.Count - 1; x >= 0; x--)
            {
                if (listView1.Items[x].Selected)
                {
                    _colors.RemoveAt(x);

                    UpdateListbox();
                    UpdatePanel();

                    break;
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            // add
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                _colors.Add(colorDialog1.Color);

                UpdateListbox();
                UpdatePanel();
            }
        }

        private void UpdateListbox()
        {
            listView1.Items.Clear();

            foreach (var c in _colors)
            {
                var item = new ListViewItem($"R={c.R} G={c.G} B={c.B}");
                item.BackColor = c;
                listView1.Items.Add(item);
            }
        }

        private void UpdatePanel()
        {
            using (var g = previewPanel.CreateGraphics())
            {
                if (_colors.Count < 2)
                {
                    g.Clear(previewPanel.BackColor);
                    return;
                }
                
                var brush = new RainbowBrush(ColorHelper.GetTransitionColors(_colors, 1));
                var rect = new Rectangle(0, 0, previewPanel.Width, previewPanel.Height);
                g.FillRectangle(brush, rect, BrushOrientation.Horizontal, FillMode.Stretch);
            }

            Invalidate();
        }
    }
}
