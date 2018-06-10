using System;
using Gtk;
using KursachAttemp2.Models;

namespace KursachAttemp2.View
{
    public partial class FileNotFoundDialog : Gtk.Dialog
    {
        private IGraph _parent;
        public delegate void Process();
        private Process _process;
        private Label label;
        public void ProcessFileNotFound()
        {
            var w = new FileChoosing(_parent, MainWindow.BuildGraph_);
            w.Show();
        }
        public FileNotFoundDialog(IGraph parent, Process p = null, string text="Files can't be recognised, please choose another folder", string title = "Error")
        {
            this.Build();
            _parent = parent;
            if (p == null)
                _process = ProcessFileNotFound;
            else
                _process = p;
            label = new Label();
            label.LabelProp = text;
            vbox2.Add(label);
            Child.ShowAll();
            Title = title;
        }

        protected void OnCancelClicked(object sender, EventArgs e)
        {
            Destroy();
        }

        protected void OnOkClick(object sender, EventArgs e)
        {
            _process();
            Destroy();
        }
    }
}
