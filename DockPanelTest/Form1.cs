using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace DockPanelTest {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            tbxs = Enumerable.Range(0, 4).Select(n => {
                var tbx = new TextBox();
                tbx.ScrollBars = ScrollBars.Both;
                tbx.WordWrap = false;
                tbx.Multiline = true;
                return tbx;
            }).ToArray();
            
            for (int i = 0; i < tbxs.Length; i++) {
                DockPanelAdd(dock, tbxs[i], $"{i}. {tbxs[i].GetType().Name}");
            }
        }

        TextBox[] tbxs;

        private void DockPanelAdd(DockPanel dock, Control ctrl, string text) {
            ctrl.Dock = DockStyle.Fill;
            var docCts = new DockContent();
            docCts.CloseButtonVisible = false;
            docCts.Text = text;
            docCts.Controls.Add(ctrl);
            docCts.Show(dock);
        }
    }
}
