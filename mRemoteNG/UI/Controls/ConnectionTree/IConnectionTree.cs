using mRemoteNG.Connection;
using mRemoteNG.Tree;
using mRemoteNG.Tree.Root;

using System.Collections;

namespace mRemoteNG.UI.Controls.ConnectionTree
{
    public interface IConnectionTree
    {
        ConnectionTreeModel ConnectionTreeModel { get; set; }

        ConnectionInfo SelectedNode { get; }

        IEnumerable ExpandedObjects { get; set; }

        RootNodeInfo GetRootConnectionNode();

        void InvokeExpand(object model);

        void InvokeRebuildAll(bool preserveState);

        void ToggleExpansion(object model);
    }
}