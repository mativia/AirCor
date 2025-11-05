using System.Drawing;
using System.Windows.Forms;

namespace tp_pav1_grupo10.InterfacesDeUsuario
{
    public class LightProfessionalColorTable : ProfessionalColorTable
    {
        public override Color ToolStripGradientBegin => Color.White;
        public override Color ToolStripGradientEnd => Color.White;
        public override Color ToolStripBorder => Color.Gainsboro;

        // Use very subtle grays for selected/pressed to avoid blue tones
        public override Color MenuItemSelectedGradientBegin => Color.FromArgb(245, 245, 245);
        public override Color MenuItemSelectedGradientEnd => Color.FromArgb(245, 245, 245);
        public override Color MenuItemPressedGradientBegin => Color.FromArgb(235, 235, 235);
        public override Color MenuItemPressedGradientEnd => Color.FromArgb(235, 235, 235);

        public override Color ToolStripDropDownBackground => Color.White;
        public override Color ImageMarginGradientBegin => Color.White;
        public override Color ImageMarginGradientEnd => Color.White;
        public override Color ImageMarginGradientMiddle => Color.White;

        public override Color MenuItemSelected => Color.FromArgb(220, 220, 220);
        public override Color MenuItemBorder => Color.FromArgb(200, 200, 200);
    }
}
