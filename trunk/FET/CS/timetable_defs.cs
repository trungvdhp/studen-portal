using System.Diagnostics;

public static class GlobalMembersTimetable_defs
{

	/**
	The version number
	*/
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern const QString FET_VERSION;

	/**
	The language
	*/
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern QString FET_LANGUAGE;

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern bool LANGUAGE_STYLE_RIGHT_TO_LEFT;

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern QString LANGUAGE_FOR_HTML;

	/**
	Timetable html css javaScript Level, added by Volker Dirr
	*/
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern int TIMETABLE_HTML_LEVEL;

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern bool PRINT_NOT_AVAILABLE_TIME_SLOTS;

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern bool PRINT_BREAK_TIME_SLOTS;

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern bool DIVIDE_HTML_TIMETABLES_WITH_TIME_AXIS_BY_DAYS;

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern bool PRINT_ACTIVITIES_WITH_SAME_STARTING_TIME;

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern bool USE_GUI_COLORS;

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern bool SHOW_SHORTCUTS_ON_MAIN_WINDOW;

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern bool ENABLE_ACTIVITY_TAG_MAX_HOURS_DAILY;
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern bool ENABLE_STUDENTS_MAX_GAPS_PER_DAY;

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern bool SHOW_WARNING_FOR_NOT_PERFECT_CONSTRAINTS;

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern bool ENABLE_STUDENTS_MIN_HOURS_DAILY_WITH_ALLOW_EMPTY_DAYS;
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern bool SHOW_WARNING_FOR_STUDENTS_MIN_HOURS_DAILY_WITH_ALLOW_EMPTY_DAYS;

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern bool CONFIRM_ACTIVITY_PLANNING;
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern bool CONFIRM_SPREAD_ACTIVITIES;
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern bool CONFIRM_REMOVE_REDUNDANT;
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern bool CONFIRM_SAVE_TIMETABLE;

	/**
	The maximum total number of different subgroups of students
	*/
	public const int MAX_TOTAL_SUBGROUPS = 30000; //MAX_YEARS*MAX_GROUPS_PER_YEAR*MAX_SUBGROUPS_PER_GROUP;

	public const int MAX_ROOM_CAPACITY = 30000;

	/**
	The maximum number of different teachers
	*/
	public const int MAX_TEACHERS = 6000;

	/**
	The maximum number of activities
	IMPORTANT: must be qint16 (max 32767), because we are using qint16 for each activity index and for
	unallocated activity = max_activities
	*/
	public const int MAX_ACTIVITIES = 30000;

	//if you want to increase this, you also need to modify the add/modify activity dialogs, to permit larger values
	//(add more pages in the subactivities tab).
	public const int MAX_SPLIT_OF_AN_ACTIVITY = 35;

	/**
	The maximum number of rooms
	IMPORTANT: max_rooms+1 must be qint16 (max 32766 for max_rooms), because we are using qint16 for each room index and
	for unallocated space = max_rooms and for unspecified room = max_rooms+1
	*/
	public const int MAX_ROOMS = 6000;

	/**
	The maximum number of buildings
	*/
	public const int MAX_BUILDINGS = 6000;

	/**
	This constant represents an unallocated activity
	*/
	public const qint16 UNALLOCATED_ACTIVITY = MAX_ACTIVITIES;

	/**
	The maximum number of working hours per day.
	IMPORTANT: max hours per day * max days per week = max hours per week must be qint16 (max 32767),
	because each time is qint16 and unallocated time is qint16
	*/
	public const int MAX_HOURS_PER_DAY = 60;

	/**
	The maximum number of working days per week.
	IMPORTANT: max hours per day * max days per week = max hours per week must be qint16 (max 32767)
	because each time is qint16 and unallocated time is qint16
	*/
	public const int MAX_DAYS_PER_WEEK = 35;

	/**
	The predefined names of the days of the week
	*/
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern const QString PREDEFINED_DAYS_OF_THE_WEEK[];

	/**
	The maximum number of working hours in a week.
	
	Hours in a week are arranged like this:
	         Mo Tu We Th Fr
	1        0  1  2  3  4
	2        5  6  7  8  9
	3        10 11 12 13 14
	4        15 16 17 18 19
	5        20 21 22 23 24
	6        25 26 27 28 29 etc.
	
	IMPORTANT: MAX_HOURS_PER_DAY * MAX_DAYS_PER_WEEK == MAX_HOURS_PER_WEEK must be qint16 (max 32767)
	because each time is qint16 and unallocated time is qint16
	*/
	public static int MAX_HOURS_PER_WEEK = MAX_HOURS_PER_DAY * MAX_DAYS_PER_WEEK;

	/**
	This constant represents unallocated time for an activity
	*/
	public static qint16 UNALLOCATED_TIME = MAX_HOURS_PER_WEEK;

	/**
	This constant represents unallocated space for an activity
	*/
	public const qint16 UNALLOCATED_SPACE = MAX_ROOMS;

	public static qint16 UNSPECIFIED_ROOM = MAX_ROOMS + 1;

	/**
	The maximum number of time constraints
	*/
	//const int MAX_TIME_CONSTRAINTS = 60000;

	/**
	The maximum number of space constraints
	*/
	//const int MAX_SPACE_CONSTRAINTS = 60000;

	/**
	File and directory separator
	*/
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern const QString FILE_SEP;

	/**
	The timetable's rules input file name
	*/
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern QString INPUT_FILENAME_XML;

	/**
	The working directory
	*/
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern QString WORKING_DIRECTORY;

	/**
	The import directory
	*/
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern QString IMPORT_DIRECTORY;

	//OUTPUT FILES

	/**
	The output directory. Please be careful when editing it,
	because the functions add a FILE_SEP sign at the end of it
	and then the name of a file. If you make OUTPUT_DIR="",
	there might be problems.
	*/
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern QString OUTPUT_DIR;

	/**
	A log file explaining how the xml input file was parsed
	*/
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern const QString XML_PARSING_LOG_FILENAME;

	/**
	A function used in xml saving
	*/
	public static QString protect(QString str)
	{
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: QString p=str;
		QString p = new QString(str);
		p.replace("&", "&amp;");
		p.replace("\"", "&quot;");
		p.replace(">", "&gt;");
		p.replace("<", "&lt;");
		p.replace("'", "&apos;");
		return p;
	}

	/**
	A function used in html saving
	*/
	public static QString protect2(QString str)
	{
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: QString p=str;
		QString p = new QString(str);
		p.replace("&", "&amp;");
		p.replace("\"", "&quot;");
		p.replace(">", "&gt;");
		p.replace("<", "&lt;");
		//p.replace("'", "&apos;");
		return p;
	}

	/**
	A function used in html saving
	*/
	public static QString protect2vert(QString str)
	{
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: QString p=str;
		QString p = new QString(str);
		p.replace("&", "&amp;");
		p.replace("\"", "&quot;");
		p.replace(">", "&gt;");
		p.replace("<", "&lt;");
		//p.replace("'", "&apos;");

		QString returnstring = new QString();
		for (int i = 0; i < p.size();i++)
		{
			QString a = p.at(i);
			QString b = "<br />";
			returnstring.append(a);
			returnstring.append(b);
		}
		return returnstring;
	}

	/**
	A function used in html saving
	*/
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//QString protect2id(QString str);

	/**
	A function used in html saving
	*/
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//QString protect2java(QString str);

	/**
	This constants represents free periods of a teacher in the teachers free periods timetable
	*/
	public const qint16 TEACHER_HAS_SINGLE_GAP = 0;
	public const qint16 TEACHER_HAS_BORDER_GAP = 1;
	public const qint16 TEACHER_HAS_BIG_GAP = 2;

	public const qint16 TEACHER_MUST_COME_EARLIER = 4;
	public const qint16 TEACHER_MUST_COME_MUCH_EARLIER = 6;

	public const qint16 TEACHER_MUST_STAY_LONGER = 3;
	public const qint16 TEACHER_MUST_STAY_MUCH_LONGER = 5; // BE CAREFULL, I just print into LESS_DETAILED timetable, if it's smaller then TEACHER_MUST_STAY_MUCH_LONGER

	public const qint16 TEACHER_HAS_A_FREE_DAY = 7;

	public const qint16 TEACHER_IS_NOT_AVAILABLE = 8;

	public const int TEACHERS_FREE_PERIODS_N_CATEGORIES = 9;

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern bool checkForUpdates;

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern QString internetVersion;

	///////tricks to save work to reconvert old code
	public const int CUSTOM_DOUBLE_PRECISION = 6; //number of digits after the decimal dot for the weights

///////begin tricks

	public static void weight_sscanf(QString str, string fmt, double result)
	{
		Debug.Assert(new QString(fmt) == new QString("%lf"));

		bool ok;
		double myres = GlobalMembersTimetable_defs.customFETStrToDouble(str, ok);
		if (!ok)
			result = -2.5; //any value that does not belong to {>=0.0 and <=100.0} or {-1.0}
							//not -1.0 because of modify multiple constraints min days between activities,
							//-1 there represents any weight
							//potential bug found by Volker Dirr
		else
			result = myres;
	}
public static double customFETStrToDouble(QString str)
{
	return customFETStrToDouble(str, 0);
}

//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double customFETStrToDouble(const QString& str, bool* ok =0)
	public static double customFETStrToDouble(QString str, bool ok)
	{
		QLocale c = new QLocale(QLocale.C);

		//tricks to convert numbers like 97.123456789 to 97.123457, to CUSTOM_DOUBLE_PRECISION (6) decimal digits after decimal point
		double tmpd = c.toDouble(str, ok);
		if (ok != 0)
			if ((ok) == false)
				return tmpd;
		QString tmps = CustomFETString.number(tmpd);
		return c.toDouble(tmps, ok);
	}
	///////end tricks

	//for random Knuth - from Knuth TAOCP Vol. 2 Seminumerical Algorithms section 3.6
	//these numbers are really important - please do not change them, NEVER!!!
	//if you want, write a new random number generator routine, with other name
	//I think I found a minor possible improvement, the author said: if(Z<=0) then Z+=MM,
	//but I think this would be better: if(Z<=0) then Z+=MM-1. - Yes, the author confirmed
	//extern int XX;
	//extern int YY;
	public const int MM = 2147483647;
	public const int AA = 48271;
	public const int QQ = 44488;
	public const int RR = 3399;

	public const int MMM = 2147483399;
	public const int AAA = 40692;
	public const int QQQ = 52774;
	public const int RRR = 3791;

//random routines

	public static void initRandomKnuth()
	{
		Debug.Assert(MM == 2147483647);
		Debug.Assert(AA == 48271);
		Debug.Assert(QQ == 44488);
		Debug.Assert(RR == 3399);

		Debug.Assert(MMM == 2147483399);
		Debug.Assert(MMM == MM - 248);
		Debug.Assert(AAA == 40692);
		Debug.Assert(QQQ == 52774);
		Debug.Assert(RRR == 3791);

		//a few tests
		XX = 123;
		YY = 123;
		int tttt = GlobalMembersTimetable_defs.randomKnuth1MM1();
		Debug.Assert(XX == 5937333);
		Debug.Assert(YY == 5005116);
		Debug.Assert(tttt == 932217);

		XX = 4321;
		YY = 54321;
		tttt = GlobalMembersTimetable_defs.randomKnuth1MM1();
		Debug.Assert(XX == 208578991);
		Debug.Assert(YY == 62946733);
		Debug.Assert(tttt == 145632258);

		XX = 87654321;
		YY = 987654321;
		tttt = GlobalMembersTimetable_defs.randomKnuth1MM1();
		Debug.Assert(XX == 618944401);
		Debug.Assert(YY == 1625301246);
		Debug.Assert(tttt == 1141126801);

		XX = 1;
		YY = 1;
		tttt = GlobalMembersTimetable_defs.randomKnuth1MM1();
		Debug.Assert(XX == 48271);
		Debug.Assert(YY == 40692);
		Debug.Assert(tttt == 7579);

		XX = MM - 1;
		YY = MMM - 1;
		tttt = GlobalMembersTimetable_defs.randomKnuth1MM1();
		Debug.Assert(XX == 2147435376);
		Debug.Assert(YY == 2147442707);
		Debug.Assert(tttt == 2147476315);

		XX = 100;
		YY = 1000;
		tttt = GlobalMembersTimetable_defs.randomKnuth1MM1();
		Debug.Assert(XX == 4827100);
		Debug.Assert(YY == 40692000);
		Debug.Assert(tttt == 2111618746);
		//////////

		//unsigned tt=unsigned(time(NULL));
		qint64 tt = new qint64(time(null));

		//XX is the current time
		//XX = 1 + ( (unsigned(tt)) % (unsigned(MM-1)) );
		XX = 1 + (int)(tt % (qint64(MM - 1)));
		Debug.Assert(XX > 0);
		Debug.Assert(XX < MM);

		//YY is the next random, after initializing YY with the current time
		//YY = 1 + ( (unsigned(tt)) % (unsigned(MMM-1)) );
		YY = 1 + (int)(tt % (qint64(MMM - 1)));
		Debug.Assert(YY > 0);
		Debug.Assert(YY < MMM);
		YY = AAA * (YY % QQQ) - RRR * (YY / QQQ);
		if (YY < 0)
			YY += MMM;
		Debug.Assert(YY > 0);
		Debug.Assert(YY < MMM);

		ZZ = XX - YY;
		if (ZZ <= 0)
			ZZ += MM - 1; //-1 is not written in Knuth TAOCP vol. 2 third edition; I think it would be an improvement. (Later edit: yes, the author confirmed that).
		Debug.Assert(ZZ > 0);
		Debug.Assert(ZZ < MM); //again, modified from Knuth TAOCP vol. 2 third edition, ZZ is strictly lower than MM (the author confirmed that, too).
	}
	public static int randomKnuth1MM1()
	{
		Debug.Assert(XX > 0);
		Debug.Assert(XX < MM);

		XX = AA * (XX % QQ) - RR * (XX / QQ);
		if (XX < 0)
			XX += MM;

		Debug.Assert(XX > 0);
		Debug.Assert(XX < MM);

		Debug.Assert(YY > 0);
		Debug.Assert(YY < MMM);

		YY = AAA * (YY % QQQ) - RRR * (YY / QQQ);
		if (YY < 0)
			YY += MMM;

		Debug.Assert(YY > 0);
		Debug.Assert(YY < MMM);

		ZZ = XX - YY;
		if (ZZ <= 0)
			ZZ += MM - 1; //-1 is not written in Knuth TAOCP vol. 2 third edition; I think it would be an improvement. (Later edit: yes, the author confirmed that).
		Debug.Assert(ZZ > 0);
		Debug.Assert(ZZ < MM); //again, modified from Knuth TAOCP vol. 2 third edition, ZZ is strictly lower than MM (the author confirmed that, too).

		return ZZ;
	}
	public static int randomKnuth(int k)
	{
		//like in Knuth TAOCP vol.2, reject some numbers (very few), so that the distribution is perfectly uniform
		for (;;)
		{
			int U = GlobalMembersTimetable_defs.randomKnuth1MM1();
			if (U <= k * ((MM - 1) / k))
				return U % k;
		}
	}






	public static bool checkForUpdates;

	public static QString internetVersion = new QString();

	/**
	FET version
	*/
	public const QString FET_VERSION = "5.19.0";

	/**
	FET language
	*/
	public static QString FET_LANGUAGE = "en_US";

	/**
	The output directory. Please be careful when editing it,
	because the functions add a FILE_SEP sign at the end of it
	and then the name of a file. If you make OUTPUT_DIR="",
	there will be problems.
	*/
	public static QString OUTPUT_DIR = new QString();

	public static bool LANGUAGE_STYLE_RIGHT_TO_LEFT;

	public static QString LANGUAGE_FOR_HTML = new QString();

	/**
	Timetable html css javaScript Level, by Volker Dirr
	*/
	public static int TIMETABLE_HTML_LEVEL;

	public static bool PRINT_NOT_AVAILABLE_TIME_SLOTS;

	public static bool PRINT_BREAK_TIME_SLOTS;

	public static bool PRINT_ACTIVITIES_WITH_SAME_STARTING_TIME;

	public static bool DIVIDE_HTML_TIMETABLES_WITH_TIME_AXIS_BY_DAYS;

	//this hashs are needed to get the IDs for html and css in timetableexport and statistics
	public static QHash<QString, QString> hashSubjectIDs = new QHash<QString, QString>();
	public static QHash<QString, QString> hashActivityTagIDs = new QHash<QString, QString>();
	public static QHash<QString, QString> hashStudentIDs = new QHash<QString, QString>();
	public static QHash<QString, QString> hashTeacherIDs = new QHash<QString, QString>();
	public static QHash<QString, QString> hashRoomIDs = new QHash<QString, QString>();
	public static QHash<QString, QString> hashDayIDs = new QHash<QString, QString>();

	/**
	A log file explaining how the xml input file was parsed
	*/
	public const QString XML_PARSING_LOG_FILENAME = "file_open.log";
//C++ TO C# CONVERTER TODO TASK: The following line could not be converted:
const QString PREDEFINED_DAYS_OF_THE_WEEK[] = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday", "Monday2", "Tuesday2", "Wednesday2", "Thursday2", "Friday2", "Saturday2", "Sunday2", "Monday3", "Tuesday3", "Wednesday3", "Thursday3", "Friday3", "Saturday3", "Sunday3", "Monday4", "Tuesday4", "Wednesday4", "Thursday4", "Friday4", "Saturday4", "Sunday4"};

	/**
	The predefined names of the days of the week
	*/

	/**
	File and directory separator
	*/
	public const QString FILE_SEP = "/";
	///////end tricks

	public static int XX;
	public static int YY;
	public static int ZZ;
}

/*
File timetable_defs.cpp
*/

/***************************************************************************
                          timetable_defs.cpp  -  description
                             -------------------
    begin                : Sat Mar 15 2003
    copyright            : (C) 2003 by Lalescu Liviu
    email                : Please see http://lalescu.ro/liviu/ for details about contacting Liviu Lalescu (in particular, you can find here the e-mail address)
 ***************************************************************************/

/***************************************************************************
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 ***************************************************************************/

/*
File timetable_defs.h
*/

/***************************************************************************
                          timetable_defs.h  -  description
                             -------------------
    begin                : Sat Mar 15 2003
    copyright            : (C) 2003 by Lalescu Liviu
    email                : Please see http://lalescu.ro/liviu/ for details about contacting Liviu Lalescu (in particular, you can find here the e-mail address)
 ***************************************************************************/

/***************************************************************************
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 ***************************************************************************/


#if NDEBUG
#undef NDEBUG
#endif




//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class QWidget;

public class CustomFETString
{
	public static QString number(int n)
	{
		return QString.number(n);
	}
	public static QString number(double x)
	{
		QString tmp = QString.number(x, 'f', GlobalMembersTimetable_defs.CUSTOM_DOUBLE_PRECISION);

		//remove trailing zeroes AFTER decimal points
		if (tmp.contains('.'))
		{
			int n = tmp.length() - 1;
			int del = 0;
			while (tmp.at(n) == '0')
			{
				n--;
				del++;
			}
			if (tmp.at(n) == '.')
			{
				n--;
				del++;
			}
			tmp.chop(del);
		}

		return tmp;
	}
}
