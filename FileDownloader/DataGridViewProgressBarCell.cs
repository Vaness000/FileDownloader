using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileDownloader
{
    public class DataGridViewProgressBarCell : DataGridViewButtonCell
    {
        public int Progress { get; set; }
        private int width;

        public DataGridViewProgressBarCell()
        {
            Progress = 0;
        }
        public override object Clone()
        {
            DataGridViewProgressBarCell cell = (DataGridViewProgressBarCell)base.Clone();
            cell.Progress = this.Progress;
            return cell;
        }

        protected override void Paint(Graphics graphics,
            Rectangle clipBounds, 
            Rectangle cellBounds, 
            int rowIndex,
            DataGridViewElementStates elementState, 
            object value, object formattedValue, 
            string errorText,
            DataGridViewCellStyle cellStyle, 
            DataGridViewAdvancedBorderStyle
            advancedBorderStyle, 
            DataGridViewPaintParts paintParts)
        {
            //if ((paintParts & DataGridViewPaintParts.Background) ==
            //    DataGridViewPaintParts.Background)
            //{
            //    SolidBrush cellBackground =
            //        new SolidBrush(cellStyle.BackColor);
            //    graphics.FillRectangle(cellBackground, cellBounds);
            //    cellBackground.Dispose();
            //}

            //if ((paintParts & DataGridViewPaintParts.Border) ==
            //    DataGridViewPaintParts.Border)
            //{
            //    PaintBorder(graphics, clipBounds, cellBounds, cellStyle,
            //        advancedBorderStyle);
            //}

            Rectangle progressBarArea = cellBounds;
            Rectangle progressBarAdjustment =
                this.BorderWidths(advancedBorderStyle);
            progressBarArea.X += progressBarAdjustment.X;
            progressBarArea.Y += progressBarAdjustment.Y;
            progressBarArea.Height -= progressBarAdjustment.Height;
            progressBarArea.Width -= progressBarAdjustment.Width;
            width = progressBarArea.Width;
            width = Convert.ToInt32((width / 100d) * Progress);
            Rectangle progressBar = new Rectangle(progressBarArea.Location, new Size(width, progressBarArea.Height));
            //ProgressBarRenderer.DrawHorizontalBar(graphics, progressBarArea);
            //ProgressBarRenderer.DrawHorizontalChunks(graphics, progressBar);
            graphics.FillRectangle(new SolidBrush(Color.Green), progressBar);
        }
    }
}
