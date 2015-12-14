using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace TabAndTab
{
    public partial class LeftFavoritesBar : UserControl
    {
        public class NativeTreeView : TreeView
        {
            [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
            private extern static int SetWindowTheme(IntPtr hWnd, string pszSubAppName,
                                                    string pszSubIdList);

            protected override void CreateHandle()
            {
                base.CreateHandle();
                SetWindowTheme(this.Handle, "explorer", null);
            }
        }
        NativeTreeView treeViewer = new NativeTreeView();
        public LeftFavoritesBar()
        {
            InitializeComponent();
            this.Controls.Add(treeViewer);
            treeViewer.Dock = DockStyle.Fill;
            this.Dock = DockStyle.Fill;
            //ListDirectory(@"C:\");
        }
        private void ListDirectory(string path)
        {
            treeViewer.Nodes.Clear();

            var stack = new Stack<TreeNode>();
            var rootDirectory = new DirectoryInfo(path);
            var node = new TreeNode(rootDirectory.Name) { Tag = rootDirectory };
            stack.Push(node);

            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();
                var directoryInfo = (DirectoryInfo)currentNode.Tag;
                foreach (var directory in directoryInfo.GetDirectories())
                {
                    var childDirectoryNode = new TreeNode(directory.Name) { Tag = directory };
                    currentNode.Nodes.Add(childDirectoryNode);
                    stack.Push(childDirectoryNode);
                }
                foreach (var file in directoryInfo.GetFiles())
                    currentNode.Nodes.Add(new TreeNode(file.Name));
            }

            treeViewer.Nodes.Add(node);
        }
    }
}
