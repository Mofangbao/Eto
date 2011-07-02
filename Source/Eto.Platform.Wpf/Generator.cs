﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eto.Drawing;

namespace Eto.Platform.Wpf
{
	public class Generator : Eto.Generator
	{
		public const string GeneratorID = "wpf";

		public override string ID
		{
			get { return GeneratorID; }
		}

		public override void ExecuteOnMainThread(Action action)
		{
			// TODO: use dispatcher
			
			base.ExecuteOnMainThread(action);
		}


		public static System.Windows.Media.Color Convert(Color value)
		{
			return new System.Windows.Media.Color { A = value.A, R = value.R, G = value.G, B = value.B };
		}

		public static Color Convert(System.Windows.Media.Color value)
		{
			return new Color { A = value.A, R = value.R, G = value.G, B = value.B };
		}

		public static Padding Convert (System.Windows.Thickness thickness)
		{
			return new Padding ((int)thickness.Left, (int)thickness.Top, (int)thickness.Right, (int)thickness.Bottom);
		}

		public static System.Windows.Thickness Convert (Padding value)
		{
			return new System.Windows.Thickness (value.Left, value.Top, value.Right, value.Bottom);
		}
	}
}