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

        public JSP Load( StreamReader stream )
        {
            UInt16 frames = stream.Read() as UInt16;


            return null;
        }

    }
}
