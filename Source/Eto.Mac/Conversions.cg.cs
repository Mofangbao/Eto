using System;
using Eto.Drawing;

#if XAMMAC2
using AppKit;
using Foundation;
using CoreGraphics;
using ObjCRuntime;
using CoreAnimation;
#elif OSX
using MonoMac.AppKit;
using MonoMac.Foundation;
using MonoMac.CoreGraphics;
using MonoMac.ObjCRuntime;
using MonoMac.CoreAnimation;
#if Mac64
using CGSize = MonoMac.Foundation.NSSize;
using CGRect = MonoMac.Foundation.NSRect;
using CGPoint = MonoMac.Foundation.NSPoint;
using nfloat = System.Single;
using nint = System.Int64;
using nuint = System.UInt64;
#else
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
using CGPoint = System.Drawing.PointF;
using nfloat = System.Single;
using nint = System.Int32;
using nuint = System.UInt32;
#endif
#endif

#if OSX
using Eto.Mac.Drawing;

namespace Eto.Mac
#elif IOS

using CoreGraphics;
using Eto.iOS.Drawing;

namespace Eto.iOS
#endif
{
	public static partial class Conversions
	{
		static CGColorSpace deviceRGB;
		
		static CGColorSpace CreateDeviceRGB ()
		{
			if (deviceRGB != null)
				return deviceRGB;

			deviceRGB = CGColorSpace.CreateDeviceRGB ();
			return deviceRGB;
		}
		
		public static CGColor ToCGColor (this Color color)
		{
			return new CGColor (CreateDeviceRGB (), new nfloat[] { color.R, color.G, color.B, color.A });
		}
		
		public static Color ToEtoColor (this CGColor color)
		{
			return new Color ((float)color.Components [0], (float)color.Components [1], (float)color.Components [2], (float)color.Alpha);
		}
		
		public static CGInterpolationQuality ToCG (this ImageInterpolation value)
		{
			switch (value) {
			case ImageInterpolation.Default:
				return CGInterpolationQuality.Default;
			case ImageInterpolation.None:
				return CGInterpolationQuality.None;
			case ImageInterpolation.Low:
				return CGInterpolationQuality.Low;
			case ImageInterpolation.Medium:
				return CGInterpolationQuality.Medium;
			case ImageInterpolation.High:
				return CGInterpolationQuality.High;
			default:
				throw new NotSupportedException();
			}
		}
		
		public static ImageInterpolation ToEto (this CGInterpolationQuality value)
		{
			switch (value) {
			case CGInterpolationQuality.Default:
				return ImageInterpolation.Default;
			case CGInterpolationQuality.None:
				return ImageInterpolation.None;
			case CGInterpolationQuality.Low:
				return ImageInterpolation.Low;
			case CGInterpolationQuality.Medium:
				return ImageInterpolation.Medium;
			case CGInterpolationQuality.High:
				return ImageInterpolation.High;
			default:
				throw new NotSupportedException();
			}
		}

		public static IMatrix ToEto (this CGAffineTransform matrix)
		{
			return new MatrixHandler(matrix);
		}

		public static CGAffineTransform ToCG (this IMatrix matrix)
		{
			if (matrix == null) return CGAffineTransform.MakeIdentity();
			return (CGAffineTransform)matrix.ControlObject;
		}
		
		public static float DegreesToRadians (float angle)
		{
			return (float)Math.PI * angle / 180.0f;
		}

		public static CGLineJoin ToCG (this PenLineJoin value)
		{
			switch (value) {
			case PenLineJoin.Bevel:
				return CGLineJoin.Bevel;
			case PenLineJoin.Miter:
				return CGLineJoin.Miter;
			case PenLineJoin.Round:
				return CGLineJoin.Round;
			default:
				throw new NotSupportedException ();
			}
		}

		public static PenLineJoin ToEto (this CGLineJoin value)
		{
			switch (value) {
			case CGLineJoin.Bevel:
				return PenLineJoin.Bevel;
			case CGLineJoin.Miter:
				return PenLineJoin.Miter;
			case CGLineJoin.Round:
				return PenLineJoin.Round;
			default:
				throw new NotSupportedException ();
			}
		}

		public static CGLineCap ToCG (this PenLineCap value)
		{
			switch (value) {
			case PenLineCap.Butt:
				return CGLineCap.Butt;
			case PenLineCap.Round:
				return CGLineCap.Round;
			case PenLineCap.Square:
				return CGLineCap.Square;
			default:
				throw new NotSupportedException ();
			}
		}
		
		public static PenLineCap ToEto (this CGLineCap value)
		{
			switch (value) {
			case CGLineCap.Butt:
				return PenLineCap.Butt;
			case CGLineCap.Round:
				return PenLineCap.Round;
			case CGLineCap.Square:
				return PenLineCap.Square;
			default:
				throw new NotSupportedException ();
			}
		}

		public static void Apply (this Pen pen, GraphicsHandler graphics)
		{
			((PenHandler)pen.Handler).Apply (pen, graphics);
		}
		
		public static void Apply (this Brush brush, GraphicsHandler graphics)
		{
			((BrushHandler)brush.Handler).Apply (brush.ControlObject, graphics);
		}

		public static GraphicsPathHandler ToHandler (this IGraphicsPath path)
		{
			return ((GraphicsPathHandler)path.ControlObject);
		}

		public static CGPath ToCG (this IGraphicsPath path)
		{
			return ((GraphicsPathHandler)path.ControlObject).Control;
		}
	}
}

