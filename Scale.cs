﻿//   Scale.cs
//
//  Author:
//       Allis Tauri <allista@gmail.com>
//
//  Copyright (c) 2016 Allis Tauri

using System;

namespace AT_Utils
{
	public class Scale
	{
		public class SimpleScale
		{
			public float scale  { get; private set; }
			public float aspect { get; private set; }
			public float sqrt { get; private set; }
			public float quad { get; private set; }
			public float cube { get; private set; }

			public SimpleScale(float scale, float aspect)
			{ 
				this.scale = scale; 
				this.aspect = aspect;
				sqrt = (float)Math.Sqrt(scale);
				quad = scale*scale;
				cube = quad*scale;
			}

			public static implicit operator float(SimpleScale s) { return s.scale; }
		}

		readonly public SimpleScale absolute;
		readonly public SimpleScale relative;
		readonly public bool FirstTime;

		public float size { get; private set; }
		public float orig_size { get; private set; }
		public float aspect { get { return absolute.aspect; } }

		public Scale(float size, float old_size, float orig_size, float aspect, float old_aspect, bool first_time)
		{ 
			this.size      = size; 
			this.orig_size = orig_size; 
			absolute	   = new SimpleScale(size/orig_size, aspect);
			relative	   = new SimpleScale(size/old_size, aspect/old_aspect);
			FirstTime      = first_time;
		}

		public static implicit operator float(Scale s) { return s.absolute; }
	}
}

