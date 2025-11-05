using System.Drawing;
using System.Windows.Forms;

namespace tp_pav1_grupo10.InterfacesDeUsuario
{
    // Custom color table for professional renderer to give dark menu and white text
    public class CustomProfessionalColorTable : ProfessionalColorTable
    {
        public override Color ToolStripGradientBegin => Color.FromArgb(13, 71, 161);
        public override Color ToolStripGradientEnd => Color.FromArgb(13, 71, 161);
        public override Color ToolStripBorder => Color.FromArgb(10, 57, 130);

        public override Color MenuItemSelectedGradientBegin => Color.FromArgb(30, 115, 240);
        public override Color MenuItemSelectedGradientEnd => Color.FromArgb(13, 71, 161);
        public override Color MenuItemPressedGradientBegin => Color.FromArgb(10, 56, 120);
        public override Color MenuItemPressedGradientEnd => Color.FromArgb(13, 71, 161);

        public override Color ToolStripDropDownBackground => Color.FromArgb(13, 71, 161);
        public override Color ImageMarginGradientBegin => Color.FromArgb(13, 71, 161);
        public override Color ImageMarginGradientEnd => Color.FromArgb(13, 71, 161);
        public override Color ImageMarginGradientMiddle => Color.FromArgb(13, 71, 161);

        public override Color MenuItemSelected => Color.FromArgb(30, 115, 240);
        public override Color MenuItemBorder => Color.FromArgb(100, 100, 100);
    }
}
