using mRemoteNG.Themes;

using System.ComponentModel;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace mRemoteNG.UI.Controls
{
    [SupportedOSPlatform("windows")]
    public partial class MrngPictureBox : PictureBox
    {
        private ThemeManager _themeManager;

        public MrngPictureBox()
        {
            ThemeManager.getInstance().ThemeChanged += OnCreateControl;
        }

        public MrngPictureBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            _themeManager = ThemeManager.getInstance();
            if (!_themeManager.ActiveAndExtended) return;
            ForeColor = _themeManager.ActiveTheme.ExtendedPalette.getColor("TextBox_Foreground");
            BackColor = _themeManager.ActiveTheme.ExtendedPalette.getColor("TextBox_Background");
            Invalidate();
        }
    }
}