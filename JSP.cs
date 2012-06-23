using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace JspEdit
{
    public class JSP
    {
        public List<JSPImage> Images = new List<JSPImage>();
    }

    public class JSPImage
    {
        #region Colors
        public static readonly Color[] colors = new Color[]{
                    Color.FromArgb(0,0,0),
                    Color.FromArgb(8,8,8),
                    Color.FromArgb(16,16,16),
                    Color.FromArgb(24,24,24),
                    Color.FromArgb(33,33,33),
                    Color.FromArgb(41,41,41),
                    Color.FromArgb(49,49,49),
                    Color.FromArgb(57,57,57),
                    Color.FromArgb(65,65,65),
                    Color.FromArgb(73,73,73),
                    Color.FromArgb(81,81,81),
                    Color.FromArgb(89,89,89),
                    Color.FromArgb(98,98,98),
                    Color.FromArgb(106,106,106),
                    Color.FromArgb(114,114,114),
                    Color.FromArgb(122,122,122),
                    Color.FromArgb(130,130,130),
                    Color.FromArgb(138,138,138),
                    Color.FromArgb(146,146,146),
                    Color.FromArgb(154,154,154),
                    Color.FromArgb(163,163,163),
                    Color.FromArgb(171,171,171),
                    Color.FromArgb(179,179,179),
                    Color.FromArgb(187,187,187),
                    Color.FromArgb(195,195,195),
                    Color.FromArgb(203,203,203),
                    Color.FromArgb(211,211,211),
                    Color.FromArgb(219,219,219),
                    Color.FromArgb(228,228,228),
                    Color.FromArgb(236,236,236),
                    Color.FromArgb(244,244,244),
                    Color.FromArgb(252,252,252),
                    Color.FromArgb(0,0,0),
                    Color.FromArgb(0,17,0),
                    Color.FromArgb(0,34,0),
                    Color.FromArgb(0,50,0),
                    Color.FromArgb(0,67,0),
                    Color.FromArgb(0,84,0),
                    Color.FromArgb(0,101,0),
                    Color.FromArgb(0,118,0),
                    Color.FromArgb(0,134,0),
                    Color.FromArgb(0,151,0),
                    Color.FromArgb(0,168,0),
                    Color.FromArgb(0,185,0),
                    Color.FromArgb(0,202,0),
                    Color.FromArgb(0,218,0),
                    Color.FromArgb(0,235,0),
                    Color.FromArgb(0,252,0),
                    Color.FromArgb(16,252,16),
                    Color.FromArgb(32,252,32),
                    Color.FromArgb(47,252,47),
                    Color.FromArgb(63,252,63),
                    Color.FromArgb(79,252,79),
                    Color.FromArgb(95,252,95),
                    Color.FromArgb(110,252,110),
                    Color.FromArgb(126,252,126),
                    Color.FromArgb(142,252,142),
                    Color.FromArgb(158,252,158),
                    Color.FromArgb(173,252,173),
                    Color.FromArgb(189,252,189),
                    Color.FromArgb(205,252,205),
                    Color.FromArgb(221,252,221),
                    Color.FromArgb(236,252,236),
                    Color.FromArgb(252,252,252),
                    Color.FromArgb(0,0,0),
                    Color.FromArgb(9,7,3),
                    Color.FromArgb(19,13,6),
                    Color.FromArgb(28,20,10),
                    Color.FromArgb(37,27,13),
                    Color.FromArgb(47,33,16),
                    Color.FromArgb(56,40,19),
                    Color.FromArgb(65,47,22),
                    Color.FromArgb(75,53,26),
                    Color.FromArgb(84,60,29),
                    Color.FromArgb(93,67,32),
                    Color.FromArgb(103,73,35),
                    Color.FromArgb(112,80,38),
                    Color.FromArgb(121,87,42),
                    Color.FromArgb(131,93,45),
                    Color.FromArgb(140,100,48),
                    Color.FromArgb(147,110,61),
                    Color.FromArgb(154,119,74),
                    Color.FromArgb(161,129,86),
                    Color.FromArgb(168,138,99),
                    Color.FromArgb(175,148,112),
                    Color.FromArgb(182,157,125),
                    Color.FromArgb(189,167,137),
                    Color.FromArgb(196,176,150),
                    Color.FromArgb(203,186,163),
                    Color.FromArgb(210,195,176),
                    Color.FromArgb(217,205,188),
                    Color.FromArgb(224,214,201),
                    Color.FromArgb(231,224,214),
                    Color.FromArgb(238,233,227),
                    Color.FromArgb(245,243,239),
                    Color.FromArgb(252,252,252),
                    Color.FromArgb(0,0,0),
                    Color.FromArgb(0,0,17),
                    Color.FromArgb(0,0,34),
                    Color.FromArgb(0,0,51),
                    Color.FromArgb(0,0,68),
                    Color.FromArgb(0,0,85),
                    Color.FromArgb(0,0,102),
                    Color.FromArgb(0,0,119),
                    Color.FromArgb(0,0,136),
                    Color.FromArgb(0,0,153),
                    Color.FromArgb(0,0,170),
                    Color.FromArgb(0,0,187),
                    Color.FromArgb(0,0,204),
                    Color.FromArgb(0,0,221),
                    Color.FromArgb(0,0,238),
                    Color.FromArgb(0,0,255),
                    Color.FromArgb(16,16,255),
                    Color.FromArgb(32,32,255),
                    Color.FromArgb(47,47,254),
                    Color.FromArgb(63,63,254),
                    Color.FromArgb(79,79,254),
                    Color.FromArgb(95,95,254),
                    Color.FromArgb(110,110,254),
                    Color.FromArgb(126,126,254),
                    Color.FromArgb(142,142,253),
                    Color.FromArgb(158,158,253),
                    Color.FromArgb(173,173,253),
                    Color.FromArgb(189,189,253),
                    Color.FromArgb(205,205,253),
                    Color.FromArgb(221,221,252),
                    Color.FromArgb(236,236,252),
                    Color.FromArgb(252,252,252),
                    Color.FromArgb(0,0,0),
                    Color.FromArgb(17,0,0),
                    Color.FromArgb(34,0,0),
                    Color.FromArgb(50,0,0),
                    Color.FromArgb(67,0,0),
                    Color.FromArgb(84,0,0),
                    Color.FromArgb(101,0,0),
                    Color.FromArgb(118,0,0),
                    Color.FromArgb(134,0,0),
                    Color.FromArgb(151,0,0),
                    Color.FromArgb(168,0,0),
                    Color.FromArgb(185,0,0),
                    Color.FromArgb(202,0,0),
                    Color.FromArgb(218,0,0),
                    Color.FromArgb(235,0,0),
                    Color.FromArgb(252,0,0),
                    Color.FromArgb(252,16,16),
                    Color.FromArgb(252,32,32),
                    Color.FromArgb(252,47,47),
                    Color.FromArgb(252,63,63),
                    Color.FromArgb(252,79,79),
                    Color.FromArgb(252,95,95),
                    Color.FromArgb(252,110,110),
                    Color.FromArgb(252,126,126),
                    Color.FromArgb(252,142,142),
                    Color.FromArgb(252,158,158),
                    Color.FromArgb(252,173,173),
                    Color.FromArgb(252,189,189),
                    Color.FromArgb(252,205,205),
                    Color.FromArgb(252,221,221),
                    Color.FromArgb(252,236,236),
                    Color.FromArgb(252,252,252),
                    Color.FromArgb(0,0,0),
                    Color.FromArgb(17,17,0),
                    Color.FromArgb(34,34,0),
                    Color.FromArgb(51,51,0),
                    Color.FromArgb(68,68,0),
                    Color.FromArgb(85,85,0),
                    Color.FromArgb(102,102,0),
                    Color.FromArgb(119,119,0),
                    Color.FromArgb(136,136,0),
                    Color.FromArgb(153,153,0),
                    Color.FromArgb(170,170,0),
                    Color.FromArgb(187,187,0),
                    Color.FromArgb(204,204,0),
                    Color.FromArgb(221,221,0),
                    Color.FromArgb(238,238,0),
                    Color.FromArgb(255,255,0),
                    Color.FromArgb(255,255,16),
                    Color.FromArgb(255,255,32),
                    Color.FromArgb(254,254,47),
                    Color.FromArgb(254,254,63),
                    Color.FromArgb(254,254,79),
                    Color.FromArgb(254,254,95),
                    Color.FromArgb(254,254,110),
                    Color.FromArgb(254,254,126),
                    Color.FromArgb(253,253,142),
                    Color.FromArgb(253,253,158),
                    Color.FromArgb(253,253,173),
                    Color.FromArgb(253,253,189),
                    Color.FromArgb(253,253,205),
                    Color.FromArgb(252,252,221),
                    Color.FromArgb(252,252,236),
                    Color.FromArgb(252,252,252),
                    Color.FromArgb(0,0,0),
                    Color.FromArgb(17,0,17),
                    Color.FromArgb(34,0,34),
                    Color.FromArgb(51,0,51),
                    Color.FromArgb(68,0,68),
                    Color.FromArgb(85,0,85),
                    Color.FromArgb(102,0,102),
                    Color.FromArgb(119,0,119),
                    Color.FromArgb(136,0,136),
                    Color.FromArgb(153,0,153),
                    Color.FromArgb(170,0,170),
                    Color.FromArgb(187,0,187),
                    Color.FromArgb(204,0,204),
                    Color.FromArgb(221,0,221),
                    Color.FromArgb(238,0,238),
                    Color.FromArgb(255,0,255),
                    Color.FromArgb(255,16,255),
                    Color.FromArgb(255,32,255),
                    Color.FromArgb(254,47,254),
                    Color.FromArgb(254,63,254),
                    Color.FromArgb(254,79,254),
                    Color.FromArgb(254,95,254),
                    Color.FromArgb(254,110,254),
                    Color.FromArgb(254,126,254),
                    Color.FromArgb(253,142,253),
                    Color.FromArgb(253,158,253),
                    Color.FromArgb(253,173,253),
                    Color.FromArgb(253,189,253),
                    Color.FromArgb(253,205,253),
                    Color.FromArgb(252,221,252),
                    Color.FromArgb(252,236,252),
                    Color.FromArgb(252,252,252),
                    Color.FromArgb(0,0,0),
                    Color.FromArgb(0,17,17),
                    Color.FromArgb(0,34,34),
                    Color.FromArgb(0,51,51),
                    Color.FromArgb(0,68,68),
                    Color.FromArgb(0,85,85),
                    Color.FromArgb(0,102,102),
                    Color.FromArgb(0,119,119),
                    Color.FromArgb(0,136,136),
                    Color.FromArgb(0,153,153),
                    Color.FromArgb(0,170,170),
                    Color.FromArgb(0,187,187),
                    Color.FromArgb(0,204,204),
                    Color.FromArgb(0,221,221),
                    Color.FromArgb(0,238,238),
                    Color.FromArgb(0,255,255),
                    Color.FromArgb(16,255,255),
                    Color.FromArgb(32,255,255),
                    Color.FromArgb(47,254,254),
                    Color.FromArgb(63,254,254),
                    Color.FromArgb(79,254,254),
                    Color.FromArgb(95,254,254),
                    Color.FromArgb(110,254,254),
                    Color.FromArgb(126,254,254),
                    Color.FromArgb(142,253,253),
                    Color.FromArgb(158,253,253),
                    Color.FromArgb(173,253,253),
                    Color.FromArgb(189,253,253),
                    Color.FromArgb(205,253,253),
                    Color.FromArgb(221,252,252),
                    Color.FromArgb(236,252,252),
                    Color.FromArgb(252,252,252)
        };
        #endregion


        public UInt16 Width
        {
            get;
            protected set;
        }
        public UInt16 Height
        {
            get;
            protected set;
        }
        public Int16 OfsX
        {
            get;
            protected set;
        }
        public Int16 OfsY
        {
            get;
            protected set;
        }

        public byte[] Data
        {
            get; 
            protected set;
        }

        public JSPImage( Int16 width, Int16 height )
        {
            this.Width = (UInt16) width;
            this.Height = (UInt16) height;
        }

        public void SetOffSet( Int16 X, Int16 Y )
        {
            this.OfsX = X;
            this.OfsY = Y;
        }

        public void SetData( byte[] newData )
        {
            if ( newData.Length != ( Width * Height ) )
                throw new ArgumentException( "Data wrong length" );
            
            this.Data = newData;
        }

        /// <summary>
        /// Returns this sprite as a 32-colour bitmap.
        /// </summary>
        /// <returns></returns>
        public Bitmap ToBitmap()
        {
            Bitmap B = new Bitmap( Width, Height, PixelFormat.Format24bppRgb );

            byte[] bitdata = new byte[this.Data.Length * 3]; // The raw BGR data of the bitmap. 
            
            for ( int i = 0; i < this.Data.Length; i++ )
            {
                Color c = colors[this.Data[i]];
                bitdata[i * 3] = c.B;
                bitdata[i * 3 + 1] = c.G;
                bitdata[i * 3 + 2] = c.R;
            }
            // Because this.Data is actually a set of indices into the color palette, we need the BGR data to construct the image from it.

            // OK, this turned out to be more complicated than it looked. We need to blit the data per row, instead of all at once.
            // See http://bobpowell.net/lockingbits.htm
            BitmapData imgdata = B.LockBits( new Rectangle( 0, 0, Width, Height ), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb );

            int numRows = B.Height;
            int numBytesPerRow = B.Width * 3;

            for ( int n = 0; n < numRows; n++ )
            {
                Marshal.Copy(
                source: bitdata,
                startIndex: n*numBytesPerRow,
                destination: new IntPtr(imgdata.Scan0.ToInt64() + n*imgdata.Stride),
                length: numBytesPerRow
                );
            }
            
            B.MakeTransparent( Color.Black );
            return B;
        }

        public override string ToString()
        {
            return string.Format( "W={0},H={1},Ox={2},Oy={3}", Width, Height, OfsX, OfsY );
        }


        public static JSPImage FromBitmap( Bitmap image )
        {
            BitmapData imgdata = image.LockBits( new Rectangle( 0, 0, image.Width, image.Height ), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb );

            byte[] imagebytes = new byte[3 * image.Width * image.Height];
            int numRows = image.Height;
            int numBytesPerRow = image.Width * 3;

            for ( int n = 0; n < image.Height; n++ )
            {
                Marshal.Copy(
                source: new IntPtr( imgdata.Scan0.ToInt64() + n * imgdata.Stride ),
                startIndex: n * numBytesPerRow,
                destination: imagebytes,
                length: numBytesPerRow
                );
            }

            byte[] JSPbytes = new byte[image.Width * image.Height];

            for ( int i = 0; i < JSPbytes.Length; i++ )
            {
                byte r, g, b;
                b = imagebytes[3 * i];
                g = imagebytes[3 * i + 1];
                r = imagebytes[3 * i + 2];

                JSPbytes[i] = (byte) CalculateNearestColor( r, g, b );
            }
            image.UnlockBits( imgdata );

            JSPImage output = new JSPImage( (short) image.Width, (short) image.Height );
            output.SetData( JSPbytes );
            output.SetOffSet( 0, 0 );
            return output;
        }

        /// <summary>
        /// Calculates the closest match to an arbitarary 24-bit color. Returns the index in the palette.
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static int CalculateNearestColor( int r, int g, int b )
        {
            double[] distances = Array.ConvertAll( colors,
                C => Math.Pow( C.B - b, 2 ) + Math.Pow( C.G - g, 2 ) + Math.Pow( C.R - r, 2 )
                );


            double min = 0;
            for ( int i = 0; i < distances.Length; i++ )
            {
                if (distances[i] < min)
                    min = distances[i];
            }
            
            return Array.FindIndex(distances, f => f == min);
        }


    }

}
