using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace JspEdit
{
    class JSP
    {
        public List<JSPImage> Images;
    }

    class JSPImage
    {
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

        public JSPImage( UInt32 width, UInt32 height )
        {
            this.Width = (UInt16) width;
            this.Height = (UInt16) height;
        }

        public void SetData( byte[] newData )
        {
            if ( newData.Length != ( Width * Height ) )
                throw new ArgumentException( "Data wrong length" );
            
            this.Data = newData;
        }

    }

}
