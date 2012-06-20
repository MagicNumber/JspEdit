using System;
using System.Collections.Generic;
using System.IO;

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

        /*
         * 00:52 - SpaceManiac: for each image you read its metadata then its data
00:52 - SpaceManiac: you want to read all the metadata first
00:52 - Blue Canary: ...oh.
00:52 - Blue Canary: And then all the data is contiguous?
00:52 - SpaceManiac: yeah
00:52 - SpaceManiac: thought I mentioned that before
00:52 - Blue Canary: ..no
00:52 - Blue Canary: the opposite is implied by your spec
*/

        public static JSP Load( BinaryReader stream )
        {
            int pos = 0;

            Int16 ImageCount = stream.ReadInt16();
            pos += 2;
            if ( ImageCount < 1 )
                throw new InvalidDataException( "Non-positive image count" );

            int[] dataLengths = new int[ImageCount];

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

                stream.ReadInt32(); // Four blank bytes.
                pos += 4;

                dataLengths[im] = dataSize;

                JSPImage Image = new JSPImage( width, height );
                Image.SetOffSet( ofsX, ofsY );
                Collection.Images.Add( Image );

            }

            for ( int ImageNum = 0; ImageNum < ImageCount; ImageNum++ )
            {
                List<byte> imgdata = new List<byte>();

                for ( int byteIndex = 0; byteIndex < dataLengths[ImageNum]; byteIndex++ )
                {
                    byte sb = stream.ReadByte();
                    pos += 1;
                    bool negative = sb > 128;
                    byte usb = (byte) ( sb & 0x7F );

                    if ( negative )
                    {
                        for ( int i = 0; i < usb; i++ )
                        {
                            imgdata.Add( 0 );
                        }
                    }
                    else
                    {
                        for ( int i = 0; i < usb; i++ )
                        {
                            imgdata.Add( stream.ReadByte() );
                            pos += 1;
                            byteIndex++;
                        }
                    }
                }

                Collection.Images[ImageNum].SetData( imgdata.ToArray() );
            }

            return Collection;
        }

        public static void Save( JSP obj, BinaryWriter stdout )
        {
            List<List<byte>> datas = new List<List<byte>>();
            for ( int imIndex = 0; imIndex < obj.Images.Count; imIndex++ )
            {
                datas.Insert( imIndex, new List<byte>() );


                List<byte> buffer = new List<byte>();

                for ( int dataIndex = 1; // Skip the first byte
                    dataIndex < obj.Images[imIndex].Data.Length; dataIndex++ )
                {
                    byte curByte = obj.Images[imIndex].Data[dataIndex];
                    byte prevByte = obj.Images[imIndex].Data[dataIndex-1];

                    if ( curByte == prevByte )
                    {
                        buffer.Add( curByte );
                    }
                    else
                    {
                        if ( prevByte == 0 ) // Transparent blocks get condensed.
                        {
                            datas[imIndex].Add( (byte) ( buffer.Count | 128 ) );
                        }
                        else
                        {
                            datas[imIndex].Add( (byte) buffer.Count );
                            datas[imIndex].AddRange( buffer );
                            buffer = new List<byte>();
                        }
                    }

                }
            }


            stdout.Write( (ushort) obj.Images.Count );
            for ( int i = 0; i < obj.Images.Count; i++ )
            {
                var im = obj.Images[i];
                stdout.Write( (ushort) im.Width );
                stdout.Write( (ushort) im.Height );
                stdout.Write( (short) im.OfsX );
                stdout.Write( (short) im.OfsY );
                stdout.Write( (short) datas[i].Count );
                stdout.Write( (int) 0 ); // Write four blank bytes. Because that's what the spec says.
            }
            for ( int j = 0; j < obj.Images.Count; j++ )
            {
                stdout.Write( datas[j].ToArray() );
            }
        }

    }
}
