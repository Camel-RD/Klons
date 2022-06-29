using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlonsLIB.Misc
{
	public class HslColor
	{
		public int Hue
		{
			get
			{
				return this.hue;
			}
			set
			{
				this.hue = Math.Min(240, Math.Max(0, value));
			}
		}

		public int Saturation
		{
			get
			{
				return this.saturation;
			}
			set
			{
				this.saturation = Math.Min(240, Math.Max(0, value));
			}
		}

		public int Luminosity
		{
			get
			{
				return this.luminosity;
			}
			set
			{
				this.luminosity = Math.Min(240, Math.Max(0, value));
			}
		}

		public HslColor(int hue, int saturation, int luminosity)
		{
			this.Hue = hue;
			this.Saturation = saturation;
			this.Luminosity = luminosity;
		}

		public HslColor()
		{
		}

		public Color ToRgbColor()
		{
			int red = 0;
			int green = 0;
			int blue = 0;
			if (this.luminosity != 0)
			{
				if (this.saturation == 0)
				{
					int num = this.luminosity * 255 / 240;
					red = num;
					green = num;
					blue = num;
				}
				else
				{
					int num2;
					if (this.luminosity <= 120)
					{
						num2 = (this.luminosity * (240 + this.saturation) + 120) / 240;
					}
					else
					{
						num2 = this.luminosity + this.saturation - (this.luminosity * this.saturation + 120) / 240;
					}
					int m = 2 * this.luminosity - num2;
					red = HslColor.HueToRgb(m, num2, this.hue + 80);
					green = HslColor.HueToRgb(m, num2, this.hue);
					blue = HslColor.HueToRgb(m, num2, this.hue - 80);
				}
			}
			return Color.FromArgb(red, green, blue);
		}

		private static int HueToRgb(int m1, int m2, int hue)
		{
			if (hue < 0 && hue + 240 >= hue)
			{
				hue += 240;
			}
			if (hue > 240 && hue - 240 <= hue)
			{
				hue -= 240;
			}
			int num;
			if (6 * hue < 240)
			{
				num = m1 + ((m2 - m1) * hue + 20) / 40;
			}
			else if (2 * hue < 240)
			{
				num = m2;
			}
			else if (3 * hue < 480)
			{
				num = m1 + ((m2 - m1) * (160 - hue) + 20) / 40;
			}
			else
			{
				num = m1;
			}
			return (num * 255 + 120) / 240;
		}

		public static HslColor FromRgbColor(Color color)
		{
			HslColor hslColor = new HslColor();
			int num = (int)Math.Max(Math.Max(color.R, color.G), color.B);
			int num2 = (int)Math.Min(Math.Min(color.R, color.G), color.B);
			hslColor.Luminosity = ((num + num2) * 240 + 255) / 510;
			if (num == num2)
			{
				hslColor.Saturation = 0;
				hslColor.Hue = 160;
			}
			else
			{
				if (hslColor.Luminosity <= 120)
				{
					hslColor.Saturation = ((num - num2) * 240 + (num + num2) / 2) / (num + num2);
				}
				else
				{
					hslColor.Saturation = ((num - num2) * 240 + (510 - num - num2) / 2) / (510 - num - num2);
				}
				int num3 = ((num - (int)color.R) * 40 + (num - num2) / 2) / (num - num2);
				int num4 = ((num - (int)color.G) * 40 + (num - num2) / 2) / (num - num2);
				int num5 = ((num - (int)color.B) * 40 + (num - num2) / 2) / (num - num2);
				int num6;
				if ((int)color.R == num)
				{
					num6 = num5 - num4;
				}
				else if ((int)color.G == num)
				{
					num6 = 80 + num3 - num5;
				}
				else
				{
					num6 = 160 + num4 - num3;
				}
				if (num6 < 0)
				{
					hslColor.Hue = num6 + 240;
				}
				else if (num6 > 240)
				{
					hslColor.Hue = num6 - 240;
				}
				else
				{
					hslColor.Hue = num6;
				}
			}
			return hslColor;
		}

		public static Color Lighter(Color color, float r)
		{
			color = Color.FromArgb(color.ToArgb());
			r = Math.Min(0.3f, Math.Max(0f, r));
			int deltalum = (int)(240f * r);
			var hc1 = HslColor.FromRgbColor(color);
			int newlum = hc1.Luminosity;
			if (newlum > 160) newlum -= deltalum;
			else newlum += deltalum;
			hc1.Luminosity = newlum;
			var c = hc1.ToRgbColor();
			return c;
		}


		public static HslColor Black => black;

		public static HslColor White => white;

		static HslColor()
		{
		}

		private int hue;
		private int saturation;
		private int luminosity;
		private const int maxRGB = 255;
		private const int maxHSL = 240;
		private static HslColor black = new HslColor(160, 0, 0);
		private static HslColor white = new HslColor(160, 0, 240);
	}
}
 