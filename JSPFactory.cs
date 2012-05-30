using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JspEdit
{
    class JSPFactory
    {
        /*
        Jamul Sprite - JSP

        header:
        count		1 word	how many frames in this sprite
        data:
        count structures:
	        width	1 word		width of sprite in pixels
	        height	1 word		height of sprite in pixels
	        ofsX	1 short		x-coord of hotspot relative to left
	        ofsY	1 short		y-coord of hotspot relative to top
	        size	1 dword		how big the sprite data is in bytes
	        data	size bytes	transparency RLE'd sprite data

	        The RLE format is as follows:

	        count	1 byte	if count is positive, this is considered
			        a run of data, negative is a run of
			        transparency.  If the run is data, it is
			        followed by count bytes of data.  If
			        it is transparent, the next RLE tag
			        simply follows it.
			        Runs do not cross line boundaries. */

        public JSP Load( BinaryReader stream )
        {
            int pos = 0;
            try
            {
                Int16 ImageCount = stream.ReadInt16();
                pos += 2;
                if ( ImageCount < 1 ) 
                    throw new InvalidDataException("Non-positive image count");

                JSP Collection = new JSP();

                for ( int im = 0; im < ImageCount; im++ )
                {
                    Int16 width = stream.ReadInt16(); 
                    Int16 height = stream.ReadInt16();
                    pos += 2 + 2;
                    if ( width < 1 || height < 1 ) 
                        throw new InvalidDataException( string.Format( "Image {0} has a height/width of {1},{2}. This doesn't make sense.", im, height, width ) );

                    Int16 ofsX = stream.ReadInt16();
                    Int16 ofsY = stream.ReadInt16();
                    pos += 2 + 2;

                    Int32 dataSize = stream.ReadInt32();
                    pos += 4;

                    byte[] compressedData = new byte[dataSize];
                    for ( int index = 0; index < compressedData.Length; index++ )
                    {
                        compressedData[index] = stream.ReadByte();
                        pos += 1;
                    }

                    List<byte> data = new List<byte>();

                    for ( int i = 0; i < compressedData.Length; i++ )
                    {
                        byte bytecount = compressedData[i];
                        if ( (bytecount & 128) >1) // bytecount is negative
                        {
                            for ( int a = 0; a < bytecount; a++ )
                            {
                                data.Add( 0 );
                            }
                        }
                        else
                        {
                            for ( int a = 0; a < bytecount; a++ )
                            {
                                i++;
                                data.Add( compressedData[i] );
                                 // Probably a better way of doing this, since advancing the 
                            }
                        }

                    }

                    
                    JSPImage Image = new JSPImage( width, height );
                    Image.SetData( data.ToArray() );
                    Image.SetOffSet( ofsX, ofsY );
                    Collection.Images.Add( Image );
                    
                }
                return Collection;
            }
            catch ( EndOfStreamException EoS )
            {
                EoS.Data["position"] = pos;
                throw EoS;
            }
        }

        public static void Save( JSP obj, Stream sout )
        {
            return;
        }

    }
}
