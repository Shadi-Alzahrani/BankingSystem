using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingSystem.Log_In_Screen.Controls
{
    public partial class ccProgressBar : Control
    {
        public ccProgressBar()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.Size = new Size(120, 120);
            this.DoubleBuffered = true;
        }

        private int _value = 0;
        private int _maximum = 100;
        private int _thickness = 10;
        private Color _progressColor = Color.Red;
        private Color _backgroundColor = Color.LightGray;

        [Category("Behavior")]
        public int Value
        {
            get => _value;
            set
            {
                if (value < 0) value = 0;
                if (value > _maximum) value = _maximum;
                _value = value;
                Invalidate();
            }
        }

        [Category("Behavior")]
        public int Maximum
        {
            get => _maximum;
            set
            {
                if (value <= 0) value = 1;
                _maximum = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        public int Thickness
        {
            get => _thickness;
            set
            {
                _thickness = Math.Max(1, value);
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color ProgressColor
        {
            get => _progressColor;
            set
            {
                _progressColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color BackgroundCircleColor
        {
            get => _backgroundColor;
            set
            {
                _backgroundColor = value;
                Invalidate();
            }
        }

       

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(
                _thickness,
                _thickness,
                this.Width - _thickness * 2,
                this.Height - _thickness * 2
            );

            // الخلفية الرمادية
            using (Pen backPen = new Pen(_backgroundColor, _thickness))
                e.Graphics.DrawArc(backPen, rect, -90, 360);

            // القوس الأحمر حسب القيمة
            float sweepAngle = 360f * _value / _maximum;
            using (Pen progressPen = new Pen(_progressColor, _thickness))
                e.Graphics.DrawArc(progressPen, rect, -90, sweepAngle);

            // النسبة في المنتصف
            string text = $"{_value}";
            SizeF textSize = e.Graphics.MeasureString(text, this.Font);
            PointF textPos = new PointF(
                (this.Width - textSize.Width) / 2,
                (this.Height - textSize.Height) / 2
            );
            e.Graphics.DrawString(text, this.Font, Brushes.Black, textPos);
        }
    }
}
