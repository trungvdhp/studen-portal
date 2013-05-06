using System.Diagnostics;

//
//
// Description: This file is part of FET
//
//
// Author: Liviu Lalescu <Please see http://lalescu.ro/liviu/ for details about contacting Liviu Lalescu (in particular, you can find here the e-mail address)>
// Copyright (C) 2009 Liviu Lalescu <http://lalescu.ro/liviu/>
//
/***************************************************************************
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 ***************************************************************************/

//REFERENCES:
//
//		Hints from Ted Jensen's Tutorial on Pointers and Arrays in C -
//			- Chapter 9: Pointers and Dynamic Allocation of Memory - improvement so that the elements of a matrix are in a contiguous memory location.
//
//		Hints from C++ FAQ LITE by Marshall Cline -
//			- Section [13] - Operator overloading, article [13.12] - advice about the () operator for matrices.
//
//		You may find more information on the FET documentation web page, http://lalescu.ro/liviu/fet/doc/


#if NDEBUG
#endif

//C++ TO C# CONVERTER TODO TASK: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template <typename T>
public class Matrix3D <T>
{
	private int d1;
	private int d2;
	private int d3;

	private T[][] a;
	private T[] content;

	public Matrix3D()
	{
		d1 = d2 = d3 = -1;
	}
	public void Dispose()
	{
		this.clear();
	}

	public void clear()
	{
		if (d1 >= 0 || d2 >= 0 || d3 >= 0)
		{
			Debug.Assert(d1 > 0 && d2 > 0 && d3 > 0);

			for (int i = 0; i < d1; i++)
				a[i] = null;
			a = null;

			content = null;
		}
		d1 = d2 = d3 = -1;
	}
	public void resize(int _d1, int _d2, int _d3)
	{
		if (_d1 <= 0 || _d2 <= 0 || _d3 <= 0)
		{
			this.clear();
			return;
		}

		if (d1 != _d1 || d2 != _d2 || d3 != _d3)
		{
			this.clear();

			d1 = _d1;
			d2 = _d2;
			d3 = _d3;

			content = new T[d1 * d2 * d3];
			a = new T * [d1];
			for (int i = 0; i < d1; i++)
			{
				a[i] = new T[d2];
				for (int j = 0; j < d2; j++)
					a[i][j] = content + i * d2 * d3 + j * d3;
			}
		}
	}
   public [] T this[int i]
   {
	   get
	   {
			return a[i];
	   }
   }
//C++ TO C# CONVERTER TODO TASK: The () operator cannot be overloaded in C#:
	public static T operator ()(int i, int j, int k)
	{
		//return content[i*d2*d3+j*d3+k];
		return content[(i * d2 + j) * d3 + k];
	}
}

//C++ TO C# CONVERTER TODO TASK: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template <typename T>
public class Matrix2D <T>
{
	private int d1;
	private int d2;

	private T[] a;
	private T[] content;

	public Matrix2D()
	{
		d1 = d2 = -1;
	}
	public void Dispose()
	{
		this.clear();
	}

	public void clear()
	{
		if (d1 >= 0 || d2 >= 0)
		{
			Debug.Assert(d1 > 0 && d2 > 0);

			a = null;

			content = null;
		}
		d1 = d2 = -1;
	}
	public void resize(int _d1, int _d2)
	{
		if (_d1 <= 0 || _d2 <= 0)
		{
			this.clear();
			return;
		}

		if (d1 != _d1 || d2 != _d2)
		{
			this.clear();

			d1 = _d1;
			d2 = _d2;

			content = new T[d1 * d2];
			a = new T[d1];
			for (int i = 0; i < d1; i++)
				a[i] = content + i * d2;
		}
	}
	public T this[int i]
	{
		get
		{
			return a[i];
		}
	}
//C++ TO C# CONVERTER TODO TASK: The () operator cannot be overloaded in C#:
	public static T operator ()(int i, int j)
	{
		return content[i * d2 + j];
	}
}

//C++ TO C# CONVERTER TODO TASK: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template <typename T>
public class Matrix1D <T>
{
	private int d1;

	private T[] a;

	public Matrix1D()
	{
		d1 = -1;
	}
	public void Dispose()
	{
		this.clear();
	}

	public void clear()
	{
		if (d1 >= 0)
		{
			Debug.Assert(d1 > 0);
			a = null;
		}
		d1 = -1;
	}
	public void resize(int _d1)
	{
		if (_d1 <= 0)
		{
			this.clear();
			return;
		}

		if (d1 != _d1)
		{
			this.clear();

			d1 = _d1;

			a = new T[d1];
		}
	}
	public T this[int i]
	{
		get
		{
			return a[i];
		}
		set
		{
//C++ TO C# CONVERTER TODO TASK: C++ to C# Converter cannot determine the 'set' logic for this indexer:
		}
	}
	//T& operator()(int i);
}

/*template <typename T> inline T& Matrix1D<T>::operator()(int i)
{
	return a[i];
}*/

