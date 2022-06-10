using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace KlonsA.Classes
{
    public class MyStyleDefs : Component
    {
        public Color HeaderWeekEndFore { get; set; } = Color.White;
        public Color HeaderWeekEndBack { get; set; } = Color.DarkBlue;
        public Color HeaderHolyDayFore { get; set; } = Color.White;
        public Color HeaderHolyDayBack { get; set; } = Color.DarkOrange;
        public Color VacationFore { get; set; } = Color.White;
        public Color VacationBack { get; set; } = Color.DarkGreen;
        public Color SickDayFore { get; set; } = Color.White;
        public Color SickDayBack { get; set; } = Color.Brown;
        public Color FreeDayFore { get; set; } = Color.White;
        public Color FreeDayBack { get; set; } = Color.LightBlue;
        public Color HolyDayFore { get; set; } = Color.White;
        public Color HolyDayBack { get; set; } = Color.LightBlue;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewCellStyle HeaderWeekEnd = null;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewCellStyle HeaderHolyDay = null;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewCellStyle Vacation = null;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewCellStyle SickDay = null;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewCellStyle FreeDay = null;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewCellStyle HolyDay = null;

        public void MakeStyles(DataGridView dgv)
        {
            HeaderWeekEnd = new DataGridViewCellStyle(dgv.ColumnHeadersDefaultCellStyle);
            HeaderWeekEnd.ForeColor = HeaderWeekEndFore;
            HeaderWeekEnd.BackColor = HeaderWeekEndBack;
            HeaderWeekEnd.Alignment = DataGridViewContentAlignment.MiddleCenter;

            HeaderHolyDay = new DataGridViewCellStyle(dgv.ColumnHeadersDefaultCellStyle);
            HeaderHolyDay.ForeColor = HeaderHolyDayFore;
            HeaderHolyDay.BackColor = HeaderHolyDayBack;
            HeaderHolyDay.Alignment = DataGridViewContentAlignment.MiddleCenter;

            Vacation = new DataGridViewCellStyle(dgv.DefaultCellStyle);
            Vacation.ForeColor = VacationFore;
            Vacation.BackColor = VacationBack;
            Vacation.Alignment = DataGridViewContentAlignment.MiddleCenter;

            SickDay = new DataGridViewCellStyle(dgv.DefaultCellStyle);
            SickDay.ForeColor = SickDayFore;
            SickDay.BackColor = SickDayBack;
            SickDay.Alignment = DataGridViewContentAlignment.MiddleCenter;

            FreeDay = new DataGridViewCellStyle(dgv.DefaultCellStyle);
            FreeDay.ForeColor = FreeDayFore;
            FreeDay.BackColor = FreeDayBack;
            FreeDay.Alignment = DataGridViewContentAlignment.MiddleCenter;

            HolyDay = new DataGridViewCellStyle(dgv.DefaultCellStyle);
            HolyDay.ForeColor = HolyDayFore;
            HolyDay.BackColor = HolyDayBack;
            HolyDay.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

    }
}
