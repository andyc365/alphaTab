﻿/*
 * This file is part of alphaTab.
 * Copyright (c) 2014, Daniel Kuschny and Contributors, All rights reserved.
 * 
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3.0 of the License, or at your option any later version.
 * 
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library.
 */
using AlphaTab.Rendering.Glyphs;

namespace AlphaTab.Platform.Svg
{
    /// <summary>
    ///  A canvas implementation storing SVG data
    /// </summary>
    public class FontSvgCanvas : SvgCanvas
    {
        public override void FillMusicFontSymbol(float x, float y, float scale, MusicFontSymbol symbol)
        {
            if (symbol == MusicFontSymbol.None)
            {
                return;
            }

            Buffer.Append("<svg x=\"");
            Buffer.Append(x - BlurCorrection);
            Buffer.Append("\" y=\"");
            Buffer.Append(y - BlurCorrection);
            Buffer.Append("\" class=\"at\" >");

            Buffer.Append("<text style=\"fill:");
            Buffer.Append(Color.ToRgbaString());
            Buffer.Append("; ");
            if (scale != 1)
            {
                Buffer.Append("font-size: ");
                Buffer.Append(scale * 100);
                Buffer.Append("%");
            }
            Buffer.Append("\" text-anchor=\"start\"");
            Buffer.Append(">&#x");
            Buffer.Append(Std.ToHexString((int)symbol));
            Buffer.Append(";</text>\n");

            Buffer.Append("</svg>");
        }
    }
}