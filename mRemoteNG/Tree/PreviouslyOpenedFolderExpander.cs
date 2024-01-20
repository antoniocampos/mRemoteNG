using mRemoteNG.Container;
using mRemoteNG.UI.Controls.ConnectionTree;

using System.Linq;
using System.Runtime.Versioning;


namespace mRemoteNG.Tree
{
    [SupportedOSPlatform("windows")]
    public class PreviouslyOpenedFolderExpander : IConnectionTreeDelegate
    {
        public void Execute(IConnectionTree connectionTree)
        {
            var rootNode = connectionTree.GetRootConnectionNode();
            var containerList = connectionTree.ConnectionTreeModel.GetRecursiveChildList(rootNode)
                                              .OfType<ContainerInfo>();
            var previouslyExpandedNodes = containerList.Where(container => container.IsExpanded);
            connectionTree.ExpandedObjects = previouslyExpandedNodes;
            connectionTree.InvokeRebuildAll(true);
        }
    }
}