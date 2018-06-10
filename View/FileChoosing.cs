using System;
using KursachAttemp2.Models;

namespace KursachAttemp2.View
{
    public partial class FileChoosing : Gtk.Window
    {
        private IGraph _parent;
        public delegate void ProcessPath(IGraph w);
        private ProcessPath _process;
        public FileChoosing(IGraph parent, ProcessPath process) :
                base(Gtk.WindowType.Toplevel)
        {
            Build();
            _parent = parent;
            _process = process;
        }

        protected void return_path(object sender, EventArgs e)
        {
            //Parent.Path_ = filechooserwidget4.Filename;
            _parent.Path_ = filechooserwidget4.Filename+"/";
            _process(_parent);
            Destroy();
            }
    }
}
