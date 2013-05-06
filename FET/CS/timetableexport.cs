using System.Diagnostics;
using System;

public static class GlobalMembersTimetableexport
{








	//#include <QDesktopWidget>

	#if ! FET_COMMAND_LINE
	#else
	#endif
	#if FET_COMMAND_LINE
	#else
	#endif
	#if FET_COMMAND_LINE
	#endif



	//Represents the current status of the simulation - running or stopped.
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern bool simulation_running;

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern bool students_schedule_ready;
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern bool teachers_schedule_ready;
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern bool rooms_schedule_ready;

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern Solution best_solution;
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern bool LANGUAGE_STYLE_RIGHT_TO_LEFT;
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern QString LANGUAGE_FOR_HTML;

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern Timetable gt;
	/*extern qint16 teachers_timetable_weekly[MAX_TEACHERS][MAX_DAYS_PER_WEEK][MAX_HOURS_PER_DAY];
	extern qint16 students_timetable_weekly[MAX_TOTAL_SUBGROUPS][MAX_DAYS_PER_WEEK][MAX_HOURS_PER_DAY];
	extern qint16 rooms_timetable_weekly[MAX_ROOMS][MAX_DAYS_PER_WEEK][MAX_HOURS_PER_DAY];*/
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern Matrix3D<qint16> teachers_timetable_weekly;
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern Matrix3D<qint16> students_timetable_weekly;
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern Matrix3D<qint16> rooms_timetable_weekly;

	//extern QList<qint16> teachers_free_periods_timetable_weekly[TEACHERS_FREE_PERIODS_N_CATEGORIES][MAX_DAYS_PER_WEEK][MAX_HOURS_PER_DAY];
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern Matrix3D<QList<qint16>> teachers_free_periods_timetable_weekly;

	//extern bool breakDayHour[MAX_DAYS_PER_WEEK][MAX_HOURS_PER_DAY];
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern Matrix2D<bool> breakDayHour;
	/*extern bool teacherNotAvailableDayHour[MAX_TEACHERS][MAX_DAYS_PER_WEEK][MAX_HOURS_PER_DAY];
	extern double notAllowedRoomTimePercentages[MAX_ROOMS][MAX_HOURS_PER_WEEK];
	extern bool subgroupNotAvailableDayHour[MAX_TOTAL_SUBGROUPS][MAX_DAYS_PER_WEEK][MAX_HOURS_PER_DAY];*/
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern Matrix3D<bool> teacherNotAvailableDayHour;
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern Matrix2D<double> notAllowedRoomTimePercentages;
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern Matrix3D<bool> subgroupNotAvailableDayHour;

	internal static QList<int>[,] activitiesForCurrentSubject = new QList[MAX_DAYS_PER_WEEK, MAX_HOURS_PER_DAY];

	internal static QList<int>[,] activitiesAtTime = new QList[MAX_DAYS_PER_WEEK, MAX_HOURS_PER_DAY];

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern Rules rules2;

	public const QString STRING_EMPTY_SLOT = "---";

	public const QString STRING_SEVERAL_ACTIVITIES_IN_LESS_DETAILED_TABLES = "???";

	public const QString STRING_NOT_AVAILABLE_TIME_SLOT = "-x-";

	public const QString STRING_BREAK_SLOT = "-X-";

	//these hashes are needed to get the IDs for html and css in timetableexport and statistics
	internal static QHash<QString, QString> hashSubjectIDsTimetable = new QHash<QString, QString>();
	internal static QHash<QString, QString> hashActivityTagIDsTimetable = new QHash<QString, QString>();
	internal static QHash<QString, QString> hashStudentIDsTimetable = new QHash<QString, QString>();
	internal static QHash<QString, QString> hashTeacherIDsTimetable = new QHash<QString, QString>();
	internal static QHash<QString, QString> hashRoomIDsTimetable = new QHash<QString, QString>();
	internal static QHash<QString, QString> hashDayIDsTimetable = new QHash<QString, QString>();

	//this hash is needed to care about sctivities with same starting time
	internal static QHash<int, QList<int>> activitiesWithSameStartingTime = new QHash<int, QList<int>>();

	//Now the filenames of the output files are following (for xml and all html tables)
	public const QString SUBGROUPS_TIMETABLE_FILENAME_XML = "subgroups.xml";
	public const QString TEACHERS_TIMETABLE_FILENAME_XML = "teachers.xml";
	public const QString ACTIVITIES_TIMETABLE_FILENAME_XML = "activities.xml";
	public const QString ROOMS_TIMETABLE_FILENAME_XML = "rooms.xml";

	public const QString CONFLICTS_FILENAME = "soft_conflicts.txt";
	public const QString INDEX_HTML = "index.html";
	public const QString STYLESHEET_CSS = "stylesheet.css";

	public const QString SUBGROUPS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML = "subgroups_days_horizontal.html";
	public const QString SUBGROUPS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML = "subgroups_days_vertical.html";
	public const QString SUBGROUPS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML = "subgroups_time_horizontal.html";
	public const QString SUBGROUPS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML = "subgroups_time_vertical.html";

	public const QString GROUPS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML = "groups_days_horizontal.html";
	public const QString GROUPS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML = "groups_days_vertical.html";
	public const QString GROUPS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML = "groups_time_horizontal.html";
	public const QString GROUPS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML = "groups_time_vertical.html";

	public const QString YEARS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML = "years_days_horizontal.html";
	public const QString YEARS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML = "years_days_vertical.html";
	public const QString YEARS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML = "years_time_horizontal.html";
	public const QString YEARS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML = "years_time_vertical.html";

	public const QString TEACHERS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML = "teachers_days_horizontal.html";
	public const QString TEACHERS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML = "teachers_days_vertical.html";
	public const QString TEACHERS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML = "teachers_time_horizontal.html";
	public const QString TEACHERS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML = "teachers_time_vertical.html";

	public const QString ROOMS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML = "rooms_days_horizontal.html";
	public const QString ROOMS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML = "rooms_days_vertical.html";
	public const QString ROOMS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML = "rooms_time_horizontal.html";
	public const QString ROOMS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML = "rooms_time_vertical.html";

	public const QString SUBJECTS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML = "subjects_days_horizontal.html";
	public const QString SUBJECTS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML = "subjects_days_vertical.html";
	public const QString SUBJECTS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML = "subjects_time_horizontal.html";
	public const QString SUBJECTS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML = "subjects_time_vertical.html";

	public const QString ALL_ACTIVITIES_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML = "activities_days_horizontal.html";
	public const QString ALL_ACTIVITIES_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML = "activities_days_vertical.html";
	public const QString ALL_ACTIVITIES_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML = "activities_time_horizontal.html";
	public const QString ALL_ACTIVITIES_TIMETABLE_TIME_VERTICAL_FILENAME_HTML = "activities_time_vertical.html";

	public const QString TEACHERS_FREE_PERIODS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML = "teachers_free_periods_days_horizontal.html";
	public const QString TEACHERS_FREE_PERIODS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML = "teachers_free_periods_days_vertical.html";

	public const QString MULTIPLE_TIMETABLE_DATA_RESULTS_FILE = "data_and_timetable.fet";

	//now the XML tags used for identification of the output file (is that comment correct? it's the old comment)
	public const QString STUDENTS_TIMETABLE_TAG = "Students_Timetable";
	public const QString TEACHERS_TIMETABLE_TAG = "Teachers_Timetable";
	public const QString ACTIVITIES_TIMETABLE_TAG = "Activities_Timetable";
	public const QString ROOMS_TIMETABLE_TAG = "Rooms_Timetable";

	public const QString RANDOM_SEED_FILENAME_BEFORE = "random_seed_before.txt";
	public const QString RANDOM_SEED_FILENAME_AFTER = "random_seed_after.txt";

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern int XX;
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern int YY;

	public static QString generationLocalizedTime = new QString(""); //to be used in timetableprintform.cpp
}

/*
File timetableexport.cpp
*/

/***************************************************************************
                          timetableexport.cpp  -  description
                          -------------------
    begin                : Tue Apr 22 2003
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

//**********************************************************************************************************************/
//August 2007
//XHTML generation code by Volker Dirr (timetabling.de)
//Features:   - XHTML 1.0 strict valid
//            - using colspan and rowspan
//            - table of contents with hyperlinks
//            - CSS and JavaScript support
//            - index HTML file
//            - TIMETABLE_HTML_LEVEL
//            - days/time horizontal/vertical
//            - subgroups, groups, years, teachers, rooms, subjects, activities timetable
//            - teachers free periods
//            - daily timetable
//            - activities with same starting time
//            - reorganized functions. now they can be also used for printing
//            - split times tables after X names (TIMETABLE_HTML_SPLIT?) and choose if activity tags should be printed (TIMETABLE_HTML_PRINT_ACTIVITY_TAGS?)

//TODO: all must be internal here. so maybe also do daysOfTheWeek and hoursPerDay also internal
//maybe TODO: use back_odd and back_even (or back0 and back1, because easier to code!) like in printing. so don't use the table_odd and table_even anymore
//maybe TODO: make printActivityTags as a global setting in FET for html export? (TIMETABLE_HTML_PRINT_ACTIVITY_TAGS?)
//maybe TODO: make TIMETABLE_HTML_SPLIT? (similar to TIMETABLE_HTML_LEVEL)
//maybe TODO: rename augmentedYearsList into internalYearsList to have it similar to others?
//maybe TODO: some "stg" stuff can be replaced by gt.rules.internalGroupsList. I don't want to do that now, because id-s will change. That is not critical, but I want to diff tables with old release.

#if NDEBUG
#endif
/*
File timetableexport.h
*/

/***************************************************************************
                          timetableexport.h  -  description
                             -------------------
    begin                : Tue Apr 22, 2003
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




//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class QWidget;

public partial class TimetableExport: QObject
{
	Q_OBJECT public: TimetableExport();
	public void Dispose()
	{
	}

	private static void getStudentsTimetable(ref Solution c)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);

		c.getSubgroupsTimetable(ref gt.rules, ref students_timetable_weekly);
		best_solution.copy(gt.rules, c);
		students_schedule_ready = true;
	}
	private static void getTeachersTimetable(ref Solution c)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);

		c.getTeachersTimetable(ref gt.rules, ref teachers_timetable_weekly, ref teachers_free_periods_timetable_weekly);
		best_solution.copy(gt.rules, c);
		teachers_schedule_ready = true;
	}
	private static void getRoomsTimetable(ref Solution c)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);

		c.getRoomsTimetable(ref gt.rules, ref rooms_timetable_weekly);
		best_solution.copy(gt.rules, c);
		rooms_schedule_ready = true;
	}
	private static void getNumberOfPlacedActivities(ref int number1, ref int number2)
	{
		number1 = 0;
		for (int i = 0; i < gt.rules.nInternalActivities; i++)
			if (best_solution.times[i] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				number1++;

		number2 = 0;
		for (int i = 0; i < gt.rules.nInternalActivities; i++)
			if (best_solution.rooms[i] != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
				number2++;
	}

	private static void writeSimulationResults(QWidget parent)
	{
		QDir dir = new QDir();

		QString OUTPUT_DIR_TIMETABLES = GlobalMembersTimetable_defs.OUTPUT_DIR + GlobalMembersTimetable_defs.FILE_SEP + "timetables";

		OUTPUT_DIR_TIMETABLES.append(GlobalMembersTimetable_defs.FILE_SEP);
		if (INPUT_FILENAME_XML == "")
			OUTPUT_DIR_TIMETABLES.append("unnamed");
		else
		{
			OUTPUT_DIR_TIMETABLES.append(INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1));
			if (OUTPUT_DIR_TIMETABLES.right(4) == ".fet")
				OUTPUT_DIR_TIMETABLES = OUTPUT_DIR_TIMETABLES.left(OUTPUT_DIR_TIMETABLES.length() - 4);
			//else if(INPUT_FILENAME_XML!="")
			//	cout<<"Minor problem - input file does not end in .fet extension - might be a problem when saving the timetables"<<" (file:"<<__FILE__<<", line:"<<__LINE__<<")"<<endl;
		}
		OUTPUT_DIR_TIMETABLES.append("-single");

		//make sure that the output directory exists
		if (!dir.exists(OUTPUT_DIR_TIMETABLES))
			dir.mkpath(OUTPUT_DIR_TIMETABLES);

		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);
		Debug.Assert(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 0);
		Debug.Assert(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL <= 6);

		computeHashForIDsTimetable();
		computeActivitiesAtTime();
		computeActivitiesWithSameStartingTime();

		QString s = new QString();
		QString bar = new QString();
		if (INPUT_FILENAME_XML == "")
			bar = "";
		else
			bar = "_";
		QString s2 = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1);
		if (s2.right(4) == ".fet")
			s2 = s2.left(s2.length() - 4);
		//else if(INPUT_FILENAME_XML!="")
		//	cout<<"Minor problem - input file does not end in .fet extension - might be a problem when saving the timetables"<<" (file:"<<__FILE__<<", line:"<<__LINE__<<")"<<endl;

		//now write the solution in xml files
		//subgroups
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_FILENAME_XML;
		writeSubgroupsTimetableXml(parent, s);
		//teachers
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_FILENAME_XML;
		writeTeachersTimetableXml(parent, s);
		//activities
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.ACTIVITIES_TIMETABLE_FILENAME_XML;
		writeActivitiesTimetableXml(parent, s);

		//now get the time. TODO: maybe write it in xml too? so do it a few lines earlier!
		QDate dat = QDate.currentDate();
		QTime tim = QTime.currentTime();
		QLocale loc = new QLocale(GlobalMembersTimetable_defs.FET_LANGUAGE);
		QString sTime = loc.toString(dat, QLocale.ShortFormat) + " " + loc.toString(tim, QLocale.ShortFormat);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: generationLocalizedTime=sTime;
		GlobalMembersTimetableexport.generationLocalizedTime.CopyFrom(sTime);

		//now get the number of placed activities. TODO: maybe write it in xml too? so do it a few lines earlier!
		int na = 0;
		int na2 = 0;
		getNumberOfPlacedActivities(ref na, ref na2);

		if (na == gt.rules.nInternalActivities && na == na2)
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.MULTIPLE_TIMETABLE_DATA_RESULTS_FILE;
			Console.Write("Since simulation is complete, FET will write also the timetable data file");
			Console.Write("\n");
			writeTimetableDataFile(parent, s);
		}

		//write the conflicts in txt mode
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.CONFLICTS_FILENAME;
		writeConflictsTxt(parent, s, sTime, na);

		//now write the solution in html files
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 1)
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.STYLESHEET_CSS;
			writeStylesheetCss(parent, s, sTime, na);
		}

		//indexHtml
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.INDEX_HTML;
		writeIndexHtml(parent, s, sTime, na);

		//subgroups
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		writeSubgroupsTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		writeSubgroupsTimetableDaysVerticalHtml(parent, s, sTime, na);
		if (!GlobalMembersTimetable_defs.DIVIDE_HTML_TIMETABLES_WITH_TIME_AXIS_BY_DAYS)
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeSubgroupsTimetableTimeHorizontalHtml(parent, s, sTime, na);
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeSubgroupsTimetableTimeVerticalHtml(parent, s, sTime, na);
		}
		else
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeSubgroupsTimetableTimeHorizontalDailyHtml(parent, s, sTime, na);
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeSubgroupsTimetableTimeVerticalDailyHtml(parent, s, sTime, na);
		}
		//groups
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.GROUPS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		writeGroupsTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.GROUPS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		writeGroupsTimetableDaysVerticalHtml(parent, s, sTime, na);
		if (!GlobalMembersTimetable_defs.DIVIDE_HTML_TIMETABLES_WITH_TIME_AXIS_BY_DAYS)
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.GROUPS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeGroupsTimetableTimeHorizontalHtml(parent, s, sTime, na);
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.GROUPS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeGroupsTimetableTimeVerticalHtml(parent, s, sTime, na);
		}
		else
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.GROUPS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeGroupsTimetableTimeHorizontalDailyHtml(parent, s, sTime, na);
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.GROUPS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeGroupsTimetableTimeVerticalDailyHtml(parent, s, sTime, na);
		}
		//years
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.YEARS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		writeYearsTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.YEARS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		writeYearsTimetableDaysVerticalHtml(parent, s, sTime, na);
		if (!GlobalMembersTimetable_defs.DIVIDE_HTML_TIMETABLES_WITH_TIME_AXIS_BY_DAYS)
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.YEARS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeYearsTimetableTimeHorizontalHtml(parent, s, sTime, na);
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.YEARS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeYearsTimetableTimeVerticalHtml(parent, s, sTime, na);
		}
		else
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.YEARS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeYearsTimetableTimeHorizontalDailyHtml(parent, s, sTime, na);
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.YEARS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeYearsTimetableTimeVerticalDailyHtml(parent, s, sTime, na);
		}
		//teachers
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		writeTeachersTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		writeTeachersTimetableDaysVerticalHtml(parent, s, sTime, na);
		if (!GlobalMembersTimetable_defs.DIVIDE_HTML_TIMETABLES_WITH_TIME_AXIS_BY_DAYS)
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeTeachersTimetableTimeHorizontalHtml(parent, s, sTime, na);
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeTeachersTimetableTimeVerticalHtml(parent, s, sTime, na);
		}
		else
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeTeachersTimetableTimeHorizontalDailyHtml(parent, s, sTime, na);
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeTeachersTimetableTimeVerticalDailyHtml(parent, s, sTime, na);
		}
		//rooms
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.ROOMS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		writeRoomsTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.ROOMS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		writeRoomsTimetableDaysVerticalHtml(parent, s, sTime, na);
		if (!GlobalMembersTimetable_defs.DIVIDE_HTML_TIMETABLES_WITH_TIME_AXIS_BY_DAYS)
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.ROOMS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeRoomsTimetableTimeHorizontalHtml(parent, s, sTime, na);
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.ROOMS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeRoomsTimetableTimeVerticalHtml(parent, s, sTime, na);
		}
		else
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.ROOMS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeRoomsTimetableTimeHorizontalDailyHtml(parent, s, sTime, na);
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.ROOMS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeRoomsTimetableTimeVerticalDailyHtml(parent, s, sTime, na);
		}
		//subjects
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.SUBJECTS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		writeSubjectsTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.SUBJECTS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		writeSubjectsTimetableDaysVerticalHtml(parent, s, sTime, na);
		if (!GlobalMembersTimetable_defs.DIVIDE_HTML_TIMETABLES_WITH_TIME_AXIS_BY_DAYS)
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.SUBJECTS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeSubjectsTimetableTimeHorizontalHtml(parent, s, sTime, na);
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.SUBJECTS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeSubjectsTimetableTimeVerticalHtml(parent, s, sTime, na);
		}
		else
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.SUBJECTS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeSubjectsTimetableTimeHorizontalDailyHtml(parent, s, sTime, na);
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.SUBJECTS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeSubjectsTimetableTimeVerticalDailyHtml(parent, s, sTime, na);
		}
		//all activities
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.ALL_ACTIVITIES_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		writeAllActivitiesTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.ALL_ACTIVITIES_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		writeAllActivitiesTimetableDaysVerticalHtml(parent, s, sTime, na);
		if (!GlobalMembersTimetable_defs.DIVIDE_HTML_TIMETABLES_WITH_TIME_AXIS_BY_DAYS)
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.ALL_ACTIVITIES_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeAllActivitiesTimetableTimeHorizontalHtml(parent, s, sTime, na);
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.ALL_ACTIVITIES_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeAllActivitiesTimetableTimeVerticalHtml(parent, s, sTime, na);
		}
		else
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.ALL_ACTIVITIES_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeAllActivitiesTimetableTimeHorizontalDailyHtml(parent, s, sTime, na);
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.ALL_ACTIVITIES_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeAllActivitiesTimetableTimeVerticalDailyHtml(parent, s, sTime, na);
		}
		//teachers free periods
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.TEACHERS_FREE_PERIODS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		writeTeachersFreePeriodsTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.TEACHERS_FREE_PERIODS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		writeTeachersFreePeriodsTimetableDaysVerticalHtml(parent, s, sTime, na);

		GlobalMembersTimetableexport.hashSubjectIDsTimetable.clear();
		GlobalMembersTimetableexport.hashActivityTagIDsTimetable.clear();
		GlobalMembersTimetableexport.hashStudentIDsTimetable.clear();
		GlobalMembersTimetableexport.hashTeacherIDsTimetable.clear();
		GlobalMembersTimetableexport.hashRoomIDsTimetable.clear();
		GlobalMembersTimetableexport.hashDayIDsTimetable.clear();

		Console.Write("Writing simulation results to disk completed successfully");
		Console.Write("\n");
	}
	private static void writeHighestStageResults(QWidget parent)
	{
		QDir dir = new QDir();

		QString OUTPUT_DIR_TIMETABLES = GlobalMembersTimetable_defs.OUTPUT_DIR + GlobalMembersTimetable_defs.FILE_SEP + "timetables";

		OUTPUT_DIR_TIMETABLES.append(GlobalMembersTimetable_defs.FILE_SEP);
		if (INPUT_FILENAME_XML == "")
			OUTPUT_DIR_TIMETABLES.append("unnamed");
		else
		{
			OUTPUT_DIR_TIMETABLES.append(INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1));
			if (OUTPUT_DIR_TIMETABLES.right(4) == ".fet")
				OUTPUT_DIR_TIMETABLES = OUTPUT_DIR_TIMETABLES.left(OUTPUT_DIR_TIMETABLES.length() - 4);
			//else if(INPUT_FILENAME_XML!="")
			//	cout<<"Minor problem - input file does not end in .fet extension - might be a problem when saving the timetables"<<" (file:"<<__FILE__<<", line:"<<__LINE__<<")"<<endl;
		}
		OUTPUT_DIR_TIMETABLES.append("-highest");

		//make sure that the output directory exists
		if (!dir.exists(OUTPUT_DIR_TIMETABLES))
			dir.mkpath(OUTPUT_DIR_TIMETABLES);

		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);
		Debug.Assert(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 0);
		Debug.Assert(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL <= 6);

		computeHashForIDsTimetable();
		computeActivitiesAtTime();
		computeActivitiesWithSameStartingTime();

		QString s = new QString();
		QString bar = new QString();
		if (INPUT_FILENAME_XML == "")
			bar = "";
		else
			bar = "_";
		QString s2 = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1);
		if (s2.right(4) == ".fet")
			s2 = s2.left(s2.length() - 4);
		//else if(INPUT_FILENAME_XML!="")
		//	cout<<"Minor problem - input file does not end in .fet extension - might be a problem when saving the timetables"<<" (file:"<<__FILE__<<", line:"<<__LINE__<<")"<<endl;

		//now write the solution in xml files
		//subgroups
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_FILENAME_XML;
		writeSubgroupsTimetableXml(parent, s);
		//teachers
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_FILENAME_XML;
		writeTeachersTimetableXml(parent, s);
		//activities
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.ACTIVITIES_TIMETABLE_FILENAME_XML;
		writeActivitiesTimetableXml(parent, s);

		//now get the time. TODO: maybe write it in xml too? so do it a few lines earlier!
		QDate dat = QDate.currentDate();
		QTime tim = QTime.currentTime();
		QLocale loc = new QLocale(GlobalMembersTimetable_defs.FET_LANGUAGE);
		QString sTime = loc.toString(dat, QLocale.ShortFormat) + " " + loc.toString(tim, QLocale.ShortFormat);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: generationLocalizedTime=sTime;
		GlobalMembersTimetableexport.generationLocalizedTime.CopyFrom(sTime);

		//now get the number of placed activities. TODO: maybe write it in xml too? so do it a few lines earlier!
		int na = 0;
		int na2 = 0;
		getNumberOfPlacedActivities(ref na, ref na2);

		if (na == gt.rules.nInternalActivities && na == na2)
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.MULTIPLE_TIMETABLE_DATA_RESULTS_FILE;
			Console.Write("Since simulation is complete, FET will write also the timetable data file");
			Console.Write("\n");
			writeTimetableDataFile(parent, s);
		}

		//write the conflicts in txt mode
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.CONFLICTS_FILENAME;
		writeConflictsTxt(parent, s, sTime, na);

		//now write the solution in html files
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 1)
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.STYLESHEET_CSS;
			writeStylesheetCss(parent, s, sTime, na);
		}

		//indexHtml
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.INDEX_HTML;
		writeIndexHtml(parent, s, sTime, na);

		//subgroups
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		writeSubgroupsTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		writeSubgroupsTimetableDaysVerticalHtml(parent, s, sTime, na);
		if (!GlobalMembersTimetable_defs.DIVIDE_HTML_TIMETABLES_WITH_TIME_AXIS_BY_DAYS)
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeSubgroupsTimetableTimeHorizontalHtml(parent, s, sTime, na);
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeSubgroupsTimetableTimeVerticalHtml(parent, s, sTime, na);
		}
		else
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeSubgroupsTimetableTimeHorizontalDailyHtml(parent, s, sTime, na);
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeSubgroupsTimetableTimeVerticalDailyHtml(parent, s, sTime, na);
		}
		//groups
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.GROUPS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		writeGroupsTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.GROUPS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		writeGroupsTimetableDaysVerticalHtml(parent, s, sTime, na);
		if (!GlobalMembersTimetable_defs.DIVIDE_HTML_TIMETABLES_WITH_TIME_AXIS_BY_DAYS)
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.GROUPS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeGroupsTimetableTimeHorizontalHtml(parent, s, sTime, na);
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.GROUPS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeGroupsTimetableTimeVerticalHtml(parent, s, sTime, na);
		}
		else
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.GROUPS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeGroupsTimetableTimeHorizontalDailyHtml(parent, s, sTime, na);
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.GROUPS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeGroupsTimetableTimeVerticalDailyHtml(parent, s, sTime, na);
		}
		//years
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.YEARS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		writeYearsTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.YEARS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		writeYearsTimetableDaysVerticalHtml(parent, s, sTime, na);
		if (!GlobalMembersTimetable_defs.DIVIDE_HTML_TIMETABLES_WITH_TIME_AXIS_BY_DAYS)
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.YEARS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeYearsTimetableTimeHorizontalHtml(parent, s, sTime, na);
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.YEARS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeYearsTimetableTimeVerticalHtml(parent, s, sTime, na);
		}
		else
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.YEARS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeYearsTimetableTimeHorizontalDailyHtml(parent, s, sTime, na);
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.YEARS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeYearsTimetableTimeVerticalDailyHtml(parent, s, sTime, na);
		}
		//teachers
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		writeTeachersTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		writeTeachersTimetableDaysVerticalHtml(parent, s, sTime, na);
		if (!GlobalMembersTimetable_defs.DIVIDE_HTML_TIMETABLES_WITH_TIME_AXIS_BY_DAYS)
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeTeachersTimetableTimeHorizontalHtml(parent, s, sTime, na);
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeTeachersTimetableTimeVerticalHtml(parent, s, sTime, na);
		}
		else
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeTeachersTimetableTimeHorizontalDailyHtml(parent, s, sTime, na);
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeTeachersTimetableTimeVerticalDailyHtml(parent, s, sTime, na);
		}
		//rooms
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.ROOMS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		writeRoomsTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.ROOMS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		writeRoomsTimetableDaysVerticalHtml(parent, s, sTime, na);
		if (!GlobalMembersTimetable_defs.DIVIDE_HTML_TIMETABLES_WITH_TIME_AXIS_BY_DAYS)
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.ROOMS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeRoomsTimetableTimeHorizontalHtml(parent, s, sTime, na);
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.ROOMS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeRoomsTimetableTimeVerticalHtml(parent, s, sTime, na);
		}
		else
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.ROOMS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeRoomsTimetableTimeHorizontalDailyHtml(parent, s, sTime, na);
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.ROOMS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeRoomsTimetableTimeVerticalDailyHtml(parent, s, sTime, na);
		}
		//subjects
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.SUBJECTS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		writeSubjectsTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.SUBJECTS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		writeSubjectsTimetableDaysVerticalHtml(parent, s, sTime, na);
		if (!GlobalMembersTimetable_defs.DIVIDE_HTML_TIMETABLES_WITH_TIME_AXIS_BY_DAYS)
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.SUBJECTS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeSubjectsTimetableTimeHorizontalHtml(parent, s, sTime, na);
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.SUBJECTS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeSubjectsTimetableTimeVerticalHtml(parent, s, sTime, na);
		}
		else
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.SUBJECTS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeSubjectsTimetableTimeHorizontalDailyHtml(parent, s, sTime, na);
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.SUBJECTS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeSubjectsTimetableTimeVerticalDailyHtml(parent, s, sTime, na);
		}
		//all activities
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.ALL_ACTIVITIES_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		writeAllActivitiesTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.ALL_ACTIVITIES_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		writeAllActivitiesTimetableDaysVerticalHtml(parent, s, sTime, na);
		if (!GlobalMembersTimetable_defs.DIVIDE_HTML_TIMETABLES_WITH_TIME_AXIS_BY_DAYS)
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.ALL_ACTIVITIES_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeAllActivitiesTimetableTimeHorizontalHtml(parent, s, sTime, na);
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.ALL_ACTIVITIES_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeAllActivitiesTimetableTimeVerticalHtml(parent, s, sTime, na);
		}
		else
		{
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.ALL_ACTIVITIES_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeAllActivitiesTimetableTimeHorizontalDailyHtml(parent, s, sTime, na);
			s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.ALL_ACTIVITIES_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeAllActivitiesTimetableTimeVerticalDailyHtml(parent, s, sTime, na);
		}
		//teachers free periods
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.TEACHERS_FREE_PERIODS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		writeTeachersFreePeriodsTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + GlobalMembersTimetableexport.TEACHERS_FREE_PERIODS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		writeTeachersFreePeriodsTimetableDaysVerticalHtml(parent, s, sTime, na);

		GlobalMembersTimetableexport.hashSubjectIDsTimetable.clear();
		GlobalMembersTimetableexport.hashActivityTagIDsTimetable.clear();
		GlobalMembersTimetableexport.hashStudentIDsTimetable.clear();
		GlobalMembersTimetableexport.hashTeacherIDsTimetable.clear();
		GlobalMembersTimetableexport.hashRoomIDsTimetable.clear();
		GlobalMembersTimetableexport.hashDayIDsTimetable.clear();

		Console.Write("Writing highest stage results to disk completed successfully");
		Console.Write("\n");
	}
	private static void writeSimulationResults(QWidget parent, int n)
	{
		QDir dir = new QDir();

		QString OUTPUT_DIR_TIMETABLES = GlobalMembersTimetable_defs.OUTPUT_DIR + GlobalMembersTimetable_defs.FILE_SEP + "timetables";

		//make sure that the output directory exists
		if (!dir.exists(OUTPUT_DIR_TIMETABLES))
			dir.mkpath(OUTPUT_DIR_TIMETABLES);

		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);
		Debug.Assert(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 0);
		Debug.Assert(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL <= 6);

		computeHashForIDsTimetable();
		computeActivitiesAtTime();
		computeActivitiesWithSameStartingTime();

		QString s = new QString();
		QString s2 = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1);
		if (s2.right(4) == ".fet")
			s2 = s2.left(s2.length() - 4);
		//else if(INPUT_FILENAME_XML!="")
		//	cout<<"Minor problem - input file does not end in .fet extension - might be a problem when saving the timetables"<<" (file:"<<__FILE__<<", line:"<<__LINE__<<")"<<endl;

		QString destDir = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + "-multi";

		if (!dir.exists(destDir))
			dir.mkpath(destDir);

		QString finalDestDir = destDir + GlobalMembersTimetable_defs.FILE_SEP + CustomFETString.number(n);

		if (!dir.exists(finalDestDir))
			dir.mkpath(finalDestDir);

		finalDestDir += GlobalMembersTimetable_defs.FILE_SEP;


		QString s3 = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1);

		if (s3.right(4) == ".fet")
			s3 = s3.left(s3.length() - 4);
		//else if(INPUT_FILENAME_XML!="")
		//	cout<<"Minor problem - input file does not end in .fet extension - might be a problem when saving the timetables"<<" (file:"<<__FILE__<<", line:"<<__LINE__<<")"<<endl;

		finalDestDir += s3 + "_";

		//write data+timetable in .fet format
		writeTimetableDataFile(parent, finalDestDir + GlobalMembersTimetableexport.MULTIPLE_TIMETABLE_DATA_RESULTS_FILE);

		//now write the solution in xml files
		//subgroups
		s = finalDestDir + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_FILENAME_XML;
		writeSubgroupsTimetableXml(parent, s);
		//teachers
		s = finalDestDir + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_FILENAME_XML;
		writeTeachersTimetableXml(parent, s);
		//activities
		s = finalDestDir + GlobalMembersTimetableexport.ACTIVITIES_TIMETABLE_FILENAME_XML;
		writeActivitiesTimetableXml(parent, s);

		//now get the time. TODO: maybe write it in xml too? so do it a few lines earlier!
		QDate dat = QDate.currentDate();
		QTime tim = QTime.currentTime();
		QLocale loc = new QLocale(GlobalMembersTimetable_defs.FET_LANGUAGE);
		QString sTime = loc.toString(dat, QLocale.ShortFormat) + " " + loc.toString(tim, QLocale.ShortFormat);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: generationLocalizedTime=sTime;
		GlobalMembersTimetableexport.generationLocalizedTime.CopyFrom(sTime);

		//now get the number of placed activities. TODO: maybe write it in xml too? so do it a few lines earlier!
		int na = 0;
		int na2 = 0;
		getNumberOfPlacedActivities(ref na, ref na2);

		//write the conflicts in txt mode
		s = finalDestDir + GlobalMembersTimetableexport.CONFLICTS_FILENAME;
		writeConflictsTxt(parent, s, sTime, na);

		//now write the solution in html files
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 1)
		{
			s = finalDestDir + GlobalMembersTimetableexport.STYLESHEET_CSS;
			writeStylesheetCss(parent, s, sTime, na);
		}
		//indexHtml
		s = finalDestDir + GlobalMembersTimetableexport.INDEX_HTML;
		writeIndexHtml(parent, s, sTime, na);
		//subgroups
		s = finalDestDir + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		writeSubgroupsTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = finalDestDir + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		writeSubgroupsTimetableDaysVerticalHtml(parent, s, sTime, na);
		if (!GlobalMembersTimetable_defs.DIVIDE_HTML_TIMETABLES_WITH_TIME_AXIS_BY_DAYS)
		{
			s = finalDestDir + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeSubgroupsTimetableTimeHorizontalHtml(parent, s, sTime, na);
			s = finalDestDir + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeSubgroupsTimetableTimeVerticalHtml(parent, s, sTime, na);
		}
		else
		{
			s = finalDestDir + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeSubgroupsTimetableTimeHorizontalDailyHtml(parent, s, sTime, na);
			s = finalDestDir + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeSubgroupsTimetableTimeVerticalDailyHtml(parent, s, sTime, na);
		}
		//groups
		s = finalDestDir + GlobalMembersTimetableexport.GROUPS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		writeGroupsTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = finalDestDir + GlobalMembersTimetableexport.GROUPS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		writeGroupsTimetableDaysVerticalHtml(parent, s, sTime, na);
		if (!GlobalMembersTimetable_defs.DIVIDE_HTML_TIMETABLES_WITH_TIME_AXIS_BY_DAYS)
		{
			s = finalDestDir + GlobalMembersTimetableexport.GROUPS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeGroupsTimetableTimeHorizontalHtml(parent, s, sTime, na);
			s = finalDestDir + GlobalMembersTimetableexport.GROUPS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeGroupsTimetableTimeVerticalHtml(parent, s, sTime, na);
		}
		else
		{
			s = finalDestDir + GlobalMembersTimetableexport.GROUPS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeGroupsTimetableTimeHorizontalDailyHtml(parent, s, sTime, na);
			s = finalDestDir + GlobalMembersTimetableexport.GROUPS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeGroupsTimetableTimeVerticalDailyHtml(parent, s, sTime, na);
		}
		//years
		s = finalDestDir + GlobalMembersTimetableexport.YEARS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		writeYearsTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = finalDestDir + GlobalMembersTimetableexport.YEARS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		writeYearsTimetableDaysVerticalHtml(parent, s, sTime, na);
		if (!GlobalMembersTimetable_defs.DIVIDE_HTML_TIMETABLES_WITH_TIME_AXIS_BY_DAYS)
		{
			s = finalDestDir + GlobalMembersTimetableexport.YEARS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeYearsTimetableTimeHorizontalHtml(parent, s, sTime, na);
			s = finalDestDir + GlobalMembersTimetableexport.YEARS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeYearsTimetableTimeVerticalHtml(parent, s, sTime, na);
		}
		else
		{
			s = finalDestDir + GlobalMembersTimetableexport.YEARS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeYearsTimetableTimeHorizontalDailyHtml(parent, s, sTime, na);
			s = finalDestDir + GlobalMembersTimetableexport.YEARS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeYearsTimetableTimeVerticalDailyHtml(parent, s, sTime, na);
		}
		//teachers
		s = finalDestDir + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		writeTeachersTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = finalDestDir + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		writeTeachersTimetableDaysVerticalHtml(parent, s, sTime, na);
		if (!GlobalMembersTimetable_defs.DIVIDE_HTML_TIMETABLES_WITH_TIME_AXIS_BY_DAYS)
		{
			s = finalDestDir + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeTeachersTimetableTimeHorizontalHtml(parent, s, sTime, na);
			s = finalDestDir + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeTeachersTimetableTimeVerticalHtml(parent, s, sTime, na);
		}
		else
		{
			s = finalDestDir + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeTeachersTimetableTimeHorizontalDailyHtml(parent, s, sTime, na);
			s = finalDestDir + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeTeachersTimetableTimeVerticalDailyHtml(parent, s, sTime, na);
		}
		//rooms
		s = finalDestDir + GlobalMembersTimetableexport.ROOMS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		writeRoomsTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = finalDestDir + GlobalMembersTimetableexport.ROOMS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		writeRoomsTimetableDaysVerticalHtml(parent, s, sTime, na);
		if (!GlobalMembersTimetable_defs.DIVIDE_HTML_TIMETABLES_WITH_TIME_AXIS_BY_DAYS)
		{
			s = finalDestDir + GlobalMembersTimetableexport.ROOMS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeRoomsTimetableTimeHorizontalHtml(parent, s, sTime, na);
			s = finalDestDir + GlobalMembersTimetableexport.ROOMS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeRoomsTimetableTimeVerticalHtml(parent, s, sTime, na);
		}
		else
		{
			s = finalDestDir + GlobalMembersTimetableexport.ROOMS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeRoomsTimetableTimeHorizontalDailyHtml(parent, s, sTime, na);
			s = finalDestDir + GlobalMembersTimetableexport.ROOMS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeRoomsTimetableTimeVerticalDailyHtml(parent, s, sTime, na);
		}
		//subjects
		s = finalDestDir + GlobalMembersTimetableexport.SUBJECTS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		writeSubjectsTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = finalDestDir + GlobalMembersTimetableexport.SUBJECTS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		writeSubjectsTimetableDaysVerticalHtml(parent, s, sTime, na);
		if (!GlobalMembersTimetable_defs.DIVIDE_HTML_TIMETABLES_WITH_TIME_AXIS_BY_DAYS)
		{
			s = finalDestDir + GlobalMembersTimetableexport.SUBJECTS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeSubjectsTimetableTimeHorizontalHtml(parent, s, sTime, na);
			s = finalDestDir + GlobalMembersTimetableexport.SUBJECTS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeSubjectsTimetableTimeVerticalHtml(parent, s, sTime, na);
		}
		else
		{
			s = finalDestDir + GlobalMembersTimetableexport.SUBJECTS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeSubjectsTimetableTimeHorizontalDailyHtml(parent, s, sTime, na);
			s = finalDestDir + GlobalMembersTimetableexport.SUBJECTS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeSubjectsTimetableTimeVerticalDailyHtml(parent, s, sTime, na);
		}
		//all activities
		s = finalDestDir + GlobalMembersTimetableexport.ALL_ACTIVITIES_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		writeAllActivitiesTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = finalDestDir + GlobalMembersTimetableexport.ALL_ACTIVITIES_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		writeAllActivitiesTimetableDaysVerticalHtml(parent, s, sTime, na);
		if (!GlobalMembersTimetable_defs.DIVIDE_HTML_TIMETABLES_WITH_TIME_AXIS_BY_DAYS)
		{
			s = finalDestDir + GlobalMembersTimetableexport.ALL_ACTIVITIES_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeAllActivitiesTimetableTimeHorizontalHtml(parent, s, sTime, na);
			s = finalDestDir + GlobalMembersTimetableexport.ALL_ACTIVITIES_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeAllActivitiesTimetableTimeVerticalHtml(parent, s, sTime, na);
		}
		else
		{
			s = finalDestDir + GlobalMembersTimetableexport.ALL_ACTIVITIES_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			writeAllActivitiesTimetableTimeHorizontalDailyHtml(parent, s, sTime, na);
			s = finalDestDir + GlobalMembersTimetableexport.ALL_ACTIVITIES_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			writeAllActivitiesTimetableTimeVerticalDailyHtml(parent, s, sTime, na);
		}
		//teachers free periods
		s = finalDestDir + GlobalMembersTimetableexport.TEACHERS_FREE_PERIODS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		writeTeachersFreePeriodsTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = finalDestDir + GlobalMembersTimetableexport.TEACHERS_FREE_PERIODS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		writeTeachersFreePeriodsTimetableDaysVerticalHtml(parent, s, sTime, na);

		GlobalMembersTimetableexport.hashSubjectIDsTimetable.clear();
		GlobalMembersTimetableexport.hashActivityTagIDsTimetable.clear();
		GlobalMembersTimetableexport.hashStudentIDsTimetable.clear();
		GlobalMembersTimetableexport.hashTeacherIDsTimetable.clear();
		GlobalMembersTimetableexport.hashRoomIDsTimetable.clear();
		GlobalMembersTimetableexport.hashDayIDsTimetable.clear();

		Console.Write("Writing multiple simulation results to disk completed successfully");
		Console.Write("\n");
	}
	private static void writeSimulationResultsCommandLine(QWidget parent, QString outputDirectory)
	{
		QString add = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1);
		if (add.right(4) == ".fet")
			add = add.left(add.length() - 4);
		//else if(INPUT_FILENAME_XML!="")
		//	cout<<"Minor problem - input file does not end in .fet extension - might be a problem when saving the timetables"<<" (file:"<<__FILE__<<", line:"<<__LINE__<<")"<<endl;

		if (add != "")
			add.append("_");

		/////////

		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);
		Debug.Assert(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 0);
		Debug.Assert(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL <= 6);

		computeHashForIDsTimetable();
		computeActivitiesAtTime();
		computeActivitiesWithSameStartingTime();

		TimetableExport.writeSubgroupsTimetableXml(parent, outputDirectory + add + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_FILENAME_XML);
		TimetableExport.writeTeachersTimetableXml(parent, outputDirectory + add + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_FILENAME_XML);
		TimetableExport.writeActivitiesTimetableXml(parent, outputDirectory + add + GlobalMembersTimetableexport.ACTIVITIES_TIMETABLE_FILENAME_XML);

		//get the time
		QDate dat = QDate.currentDate();
		QTime tim = QTime.currentTime();
		QLocale loc = new QLocale(GlobalMembersTimetable_defs.FET_LANGUAGE);
		QString sTime = loc.toString(dat, QLocale.ShortFormat) + " " + loc.toString(tim, QLocale.ShortFormat);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: generationLocalizedTime=sTime;
		GlobalMembersTimetableexport.generationLocalizedTime.CopyFrom(sTime); //really unneeded, but just to be similar to the other parts

		//now get the number of placed activities. TODO: maybe write it in xml too? so do it a few lines earlier!
		int na = 0;
		int na2 = 0;
		getNumberOfPlacedActivities(ref na, ref na2);

		if (na == gt.rules.nInternalActivities && na == na2)
		{
			QString s = outputDirectory + add + GlobalMembersTimetableexport.MULTIPLE_TIMETABLE_DATA_RESULTS_FILE;
			Console.Write("Since simulation is complete, FET will write also the timetable data file");
			Console.Write("\n");
			writeTimetableDataFile(parent, s);
		}

		//write the conflicts in txt mode
		QString s = add + GlobalMembersTimetableexport.CONFLICTS_FILENAME;
		s.prepend(outputDirectory);
		TimetableExport.writeConflictsTxt(parent, s, sTime, na);

		//now write the solution in html files
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 1)
		{
			s = add + GlobalMembersTimetableexport.STYLESHEET_CSS;
			s.prepend(outputDirectory);
			TimetableExport.writeStylesheetCss(parent, s, sTime, na);
		}
		//indexHtml
		s = add + GlobalMembersTimetableexport.INDEX_HTML;
		s.prepend(outputDirectory);
		writeIndexHtml(parent, s, sTime, na);
		//subgroups
		s = add + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		s.prepend(outputDirectory);
		TimetableExport.writeSubgroupsTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = add + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		s.prepend(outputDirectory);
		TimetableExport.writeSubgroupsTimetableDaysVerticalHtml(parent, s, sTime, na);
		if (!GlobalMembersTimetable_defs.DIVIDE_HTML_TIMETABLES_WITH_TIME_AXIS_BY_DAYS)
		{
			s = add + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			s.prepend(outputDirectory);
			TimetableExport.writeSubgroupsTimetableTimeHorizontalHtml(parent, s, sTime, na);
			s = add + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			s.prepend(outputDirectory);
			TimetableExport.writeSubgroupsTimetableTimeVerticalHtml(parent, s, sTime, na);
		}
		else
		{
			s = add + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			s.prepend(outputDirectory);
			TimetableExport.writeSubgroupsTimetableTimeHorizontalDailyHtml(parent, s, sTime, na);
			s = add + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			s.prepend(outputDirectory);
			TimetableExport.writeSubgroupsTimetableTimeVerticalDailyHtml(parent, s, sTime, na);
		}
		//groups
		s = add + GlobalMembersTimetableexport.GROUPS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		s.prepend(outputDirectory);
		TimetableExport.writeGroupsTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = add + GlobalMembersTimetableexport.GROUPS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		s.prepend(outputDirectory);
		TimetableExport.writeGroupsTimetableDaysVerticalHtml(parent, s, sTime, na);
		if (!GlobalMembersTimetable_defs.DIVIDE_HTML_TIMETABLES_WITH_TIME_AXIS_BY_DAYS)
		{
			s = add + GlobalMembersTimetableexport.GROUPS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			s.prepend(outputDirectory);
			TimetableExport.writeGroupsTimetableTimeHorizontalHtml(parent, s, sTime, na);
			s = add + GlobalMembersTimetableexport.GROUPS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			s.prepend(outputDirectory);
			TimetableExport.writeGroupsTimetableTimeVerticalHtml(parent, s, sTime, na);
		}
		else
		{
			s = add + GlobalMembersTimetableexport.GROUPS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			s.prepend(outputDirectory);
			TimetableExport.writeGroupsTimetableTimeHorizontalDailyHtml(parent, s, sTime, na);
			s = add + GlobalMembersTimetableexport.GROUPS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			s.prepend(outputDirectory);
			TimetableExport.writeGroupsTimetableTimeVerticalDailyHtml(parent, s, sTime, na);
		}
		//years
		s = add + GlobalMembersTimetableexport.YEARS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		s.prepend(outputDirectory);
		TimetableExport.writeYearsTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = add + GlobalMembersTimetableexport.YEARS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		s.prepend(outputDirectory);
		TimetableExport.writeYearsTimetableDaysVerticalHtml(parent, s, sTime, na);
		if (!GlobalMembersTimetable_defs.DIVIDE_HTML_TIMETABLES_WITH_TIME_AXIS_BY_DAYS)
		{
			s = add + GlobalMembersTimetableexport.YEARS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			s.prepend(outputDirectory);
			TimetableExport.writeYearsTimetableTimeHorizontalHtml(parent, s, sTime, na);
			s = add + GlobalMembersTimetableexport.YEARS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			s.prepend(outputDirectory);
			TimetableExport.writeYearsTimetableTimeVerticalHtml(parent, s, sTime, na);
		}
		else
		{
			s = add + GlobalMembersTimetableexport.YEARS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			s.prepend(outputDirectory);
			TimetableExport.writeYearsTimetableTimeHorizontalDailyHtml(parent, s, sTime, na);
			s = add + GlobalMembersTimetableexport.YEARS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			s.prepend(outputDirectory);
			TimetableExport.writeYearsTimetableTimeVerticalDailyHtml(parent, s, sTime, na);
		}
		//teachers
		s = add + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		s.prepend(outputDirectory);
		TimetableExport.writeTeachersTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = add + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		s.prepend(outputDirectory);
		TimetableExport.writeTeachersTimetableDaysVerticalHtml(parent, s, sTime, na);
		if (!GlobalMembersTimetable_defs.DIVIDE_HTML_TIMETABLES_WITH_TIME_AXIS_BY_DAYS)
		{
			s = add + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			s.prepend(outputDirectory);
			TimetableExport.writeTeachersTimetableTimeHorizontalHtml(parent, s, sTime, na);
			s = add + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			s.prepend(outputDirectory);
			TimetableExport.writeTeachersTimetableTimeVerticalHtml(parent, s, sTime, na);
		}
		else
		{
			s = add + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			s.prepend(outputDirectory);
			TimetableExport.writeTeachersTimetableTimeHorizontalDailyHtml(parent, s, sTime, na);
			s = add + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			s.prepend(outputDirectory);
			TimetableExport.writeTeachersTimetableTimeVerticalDailyHtml(parent, s, sTime, na);
		}
		//rooms
		s = add + GlobalMembersTimetableexport.ROOMS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		s.prepend(outputDirectory);
		TimetableExport.writeRoomsTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = add + GlobalMembersTimetableexport.ROOMS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		s.prepend(outputDirectory);
		TimetableExport.writeRoomsTimetableDaysVerticalHtml(parent, s, sTime, na);
		if (!GlobalMembersTimetable_defs.DIVIDE_HTML_TIMETABLES_WITH_TIME_AXIS_BY_DAYS)
		{
			s = add + GlobalMembersTimetableexport.ROOMS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			s.prepend(outputDirectory);
			TimetableExport.writeRoomsTimetableTimeHorizontalHtml(parent, s, sTime, na);
			s = add + GlobalMembersTimetableexport.ROOMS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			s.prepend(outputDirectory);
			TimetableExport.writeRoomsTimetableTimeVerticalHtml(parent, s, sTime, na);
		}
		else
		{
			s = add + GlobalMembersTimetableexport.ROOMS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			s.prepend(outputDirectory);
			TimetableExport.writeRoomsTimetableTimeHorizontalDailyHtml(parent, s, sTime, na);
			s = add + GlobalMembersTimetableexport.ROOMS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			s.prepend(outputDirectory);
			TimetableExport.writeRoomsTimetableTimeVerticalDailyHtml(parent, s, sTime, na);
		}
		//subjects
		s = add + GlobalMembersTimetableexport.SUBJECTS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		s.prepend(outputDirectory);
		TimetableExport.writeSubjectsTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = add + GlobalMembersTimetableexport.SUBJECTS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		s.prepend(outputDirectory);
		TimetableExport.writeSubjectsTimetableDaysVerticalHtml(parent, s, sTime, na);
		if (!GlobalMembersTimetable_defs.DIVIDE_HTML_TIMETABLES_WITH_TIME_AXIS_BY_DAYS)
		{
			s = add + GlobalMembersTimetableexport.SUBJECTS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			s.prepend(outputDirectory);
			TimetableExport.writeSubjectsTimetableTimeHorizontalHtml(parent, s, sTime, na);
			s = add + GlobalMembersTimetableexport.SUBJECTS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			s.prepend(outputDirectory);
			TimetableExport.writeSubjectsTimetableTimeVerticalHtml(parent, s, sTime, na);
		}
		else
		{
			s = add + GlobalMembersTimetableexport.SUBJECTS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			s.prepend(outputDirectory);
			TimetableExport.writeSubjectsTimetableTimeHorizontalDailyHtml(parent, s, sTime, na);
			s = add + GlobalMembersTimetableexport.SUBJECTS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			s.prepend(outputDirectory);
			TimetableExport.writeSubjectsTimetableTimeVerticalDailyHtml(parent, s, sTime, na);
		}
		//all activities
		s = add + GlobalMembersTimetableexport.ALL_ACTIVITIES_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		s.prepend(outputDirectory);
		TimetableExport.writeAllActivitiesTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = add + GlobalMembersTimetableexport.ALL_ACTIVITIES_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		s.prepend(outputDirectory);
		TimetableExport.writeAllActivitiesTimetableDaysVerticalHtml(parent, s, sTime, na);
		if (!GlobalMembersTimetable_defs.DIVIDE_HTML_TIMETABLES_WITH_TIME_AXIS_BY_DAYS)
		{
			s = add + GlobalMembersTimetableexport.ALL_ACTIVITIES_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			s.prepend(outputDirectory);
			TimetableExport.writeAllActivitiesTimetableTimeHorizontalHtml(parent, s, sTime, na);
			s = add + GlobalMembersTimetableexport.ALL_ACTIVITIES_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			s.prepend(outputDirectory);
			TimetableExport.writeAllActivitiesTimetableTimeVerticalHtml(parent, s, sTime, na);
		}
		else
		{
			s = add + GlobalMembersTimetableexport.ALL_ACTIVITIES_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML;
			s.prepend(outputDirectory);
			TimetableExport.writeAllActivitiesTimetableTimeHorizontalDailyHtml(parent, s, sTime, na);
			s = add + GlobalMembersTimetableexport.ALL_ACTIVITIES_TIMETABLE_TIME_VERTICAL_FILENAME_HTML;
			s.prepend(outputDirectory);
			TimetableExport.writeAllActivitiesTimetableTimeVerticalDailyHtml(parent, s, sTime, na);
		}
		//teachers free periods
		s = add + GlobalMembersTimetableexport.TEACHERS_FREE_PERIODS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML;
		s.prepend(outputDirectory);
		TimetableExport.writeTeachersFreePeriodsTimetableDaysHorizontalHtml(parent, s, sTime, na);
		s = add + GlobalMembersTimetableexport.TEACHERS_FREE_PERIODS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML;
		s.prepend(outputDirectory);
		TimetableExport.writeTeachersFreePeriodsTimetableDaysVerticalHtml(parent, s, sTime, na);

		GlobalMembersTimetableexport.hashSubjectIDsTimetable.clear();
		GlobalMembersTimetableexport.hashActivityTagIDsTimetable.clear();
		GlobalMembersTimetableexport.hashStudentIDsTimetable.clear();
		GlobalMembersTimetableexport.hashTeacherIDsTimetable.clear();
		GlobalMembersTimetableexport.hashRoomIDsTimetable.clear();
		GlobalMembersTimetableexport.hashDayIDsTimetable.clear();
	}

	private static void writeRandomSeed(QWidget parent, bool before)
	{
		QString RANDOM_SEED_FILENAME = new QString();
		if (before)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: RANDOM_SEED_FILENAME=RANDOM_SEED_FILENAME_BEFORE;
			RANDOM_SEED_FILENAME.CopyFrom(GlobalMembersTimetableexport.RANDOM_SEED_FILENAME_BEFORE);
		else
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: RANDOM_SEED_FILENAME=RANDOM_SEED_FILENAME_AFTER;
			RANDOM_SEED_FILENAME.CopyFrom(GlobalMembersTimetableexport.RANDOM_SEED_FILENAME_AFTER);

		QDir dir = new QDir();

		QString OUTPUT_DIR_TIMETABLES = GlobalMembersTimetable_defs.OUTPUT_DIR + GlobalMembersTimetable_defs.FILE_SEP + "timetables";

		OUTPUT_DIR_TIMETABLES.append(GlobalMembersTimetable_defs.FILE_SEP);
		if (INPUT_FILENAME_XML == "")
			OUTPUT_DIR_TIMETABLES.append("unnamed");
		else
		{
			OUTPUT_DIR_TIMETABLES.append(INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1));
			if (OUTPUT_DIR_TIMETABLES.right(4) == ".fet")
				OUTPUT_DIR_TIMETABLES = OUTPUT_DIR_TIMETABLES.left(OUTPUT_DIR_TIMETABLES.length() - 4);
			//else if(INPUT_FILENAME_XML!="")
			//	cout<<"Minor problem - input file does not end in .fet extension - might be a problem when saving the timetables"<<" (file:"<<__FILE__<<", line:"<<__LINE__<<")"<<endl;
		}
		OUTPUT_DIR_TIMETABLES.append("-single");

		//make sure that the output directory exists
		if (!dir.exists(OUTPUT_DIR_TIMETABLES))
			dir.mkpath(OUTPUT_DIR_TIMETABLES);

		QString s = new QString();
		QString bar = new QString();
		if (INPUT_FILENAME_XML == "")
			bar = "";
		else
			bar = "_";
		QString s2 = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1);
		if (s2.right(4) == ".fet")
			s2 = s2.left(s2.length() - 4);

		s = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + bar + RANDOM_SEED_FILENAME;

		writeRandomSeedFile(parent, s, before);
	}
	private static void writeRandomSeed(QWidget parent, int n, bool before)
	{
		QString RANDOM_SEED_FILENAME = new QString();
		if (before)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: RANDOM_SEED_FILENAME=RANDOM_SEED_FILENAME_BEFORE;
			RANDOM_SEED_FILENAME.CopyFrom(GlobalMembersTimetableexport.RANDOM_SEED_FILENAME_BEFORE);
		else
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: RANDOM_SEED_FILENAME=RANDOM_SEED_FILENAME_AFTER;
			RANDOM_SEED_FILENAME.CopyFrom(GlobalMembersTimetableexport.RANDOM_SEED_FILENAME_AFTER);

		QDir dir = new QDir();

		QString OUTPUT_DIR_TIMETABLES = GlobalMembersTimetable_defs.OUTPUT_DIR + GlobalMembersTimetable_defs.FILE_SEP + "timetables";

		//make sure that the output directory exists
		if (!dir.exists(OUTPUT_DIR_TIMETABLES))
			dir.mkpath(OUTPUT_DIR_TIMETABLES);

		QString s = new QString();
		QString s2 = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1);
		if (s2.right(4) == ".fet")
			s2 = s2.left(s2.length() - 4);
		//else if(INPUT_FILENAME_XML!="")
		//	cout<<"Minor problem - input file does not end in .fet extension - might be a problem when saving the timetables"<<" (file:"<<__FILE__<<", line:"<<__LINE__<<")"<<endl;

		QString destDir = OUTPUT_DIR_TIMETABLES + GlobalMembersTimetable_defs.FILE_SEP + s2 + "-multi";

		if (!dir.exists(destDir))
			dir.mkpath(destDir);

		QString finalDestDir = destDir + GlobalMembersTimetable_defs.FILE_SEP + CustomFETString.number(n);

		if (!dir.exists(finalDestDir))
			dir.mkpath(finalDestDir);

		finalDestDir += GlobalMembersTimetable_defs.FILE_SEP;

		QString s3 = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1);

		if (s3.right(4) == ".fet")
			s3 = s3.left(s3.length() - 4);
		//else if(INPUT_FILENAME_XML!="")
		//	cout<<"Minor problem - input file does not end in .fet extension - might be a problem when saving the timetables"<<" (file:"<<__FILE__<<", line:"<<__LINE__<<")"<<endl;

		finalDestDir += s3 + "_";

		s = finalDestDir + RANDOM_SEED_FILENAME;

		writeRandomSeedFile(parent, s, before);
	}
	private static void writeRandomSeedCommandLine(QWidget parent, QString outputDirectory, bool before)
	{
		QString RANDOM_SEED_FILENAME = new QString();
		if (before)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: RANDOM_SEED_FILENAME=RANDOM_SEED_FILENAME_BEFORE;
			RANDOM_SEED_FILENAME.CopyFrom(GlobalMembersTimetableexport.RANDOM_SEED_FILENAME_BEFORE);
		else
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: RANDOM_SEED_FILENAME=RANDOM_SEED_FILENAME_AFTER;
			RANDOM_SEED_FILENAME.CopyFrom(GlobalMembersTimetableexport.RANDOM_SEED_FILENAME_AFTER);

		QString add = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1);
		if (add.right(4) == ".fet")
			add = add.left(add.length() - 4);
		//else if(INPUT_FILENAME_XML!="")
		//	cout<<"Minor problem - input file does not end in .fet extension - might be a problem when saving the timetables"<<" (file:"<<__FILE__<<", line:"<<__LINE__<<")"<<endl;

		if (add != "")
			add.append("_");

		QString s = add + RANDOM_SEED_FILENAME;
		s.prepend(outputDirectory);

		writeRandomSeedFile(parent, s, before);
	}
	private static void writeRandomSeedFile(QWidget parent, QString filename, bool before)
	{
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: QString s=filename;
		QString s = new QString(filename);

		QFile file = new QFile(s);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(s));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		QDate dat = QDate.currentDate();
		QTime tim = QTime.currentTime();
		QLocale loc = new QLocale(GlobalMembersTimetable_defs.FET_LANGUAGE);
		QString sTime = loc.toString(dat, QLocale.ShortFormat) + " " + loc.toString(tim, QLocale.ShortFormat);

		if (before)
		{
			tos << tr("Generation started on: %1", "%1 is the time").arg(sTime);
			tos << "\n" << "\n";
			tos << tr("Random seed at the start of generation is: X=%1, Y=%2", "The random seed has two components, X and Y").arg(GlobalMembersTimetable_defs.XX).arg(GlobalMembersTimetable_defs.YY);
			tos << "\n" << "\n";
			tos << tr("This file was automatically generated by FET %1.").arg(GlobalMembersTimetable_defs.FET_VERSION);
			tos << "\n";
		}
		else
		{
			tos << tr("Generation ended on: %1", "%1 is the time").arg(sTime);
			tos << "\n" << "\n";
			tos << tr("Random seed at the end of generation is: X=%1, Y=%2", "The random seed has two components, X and Y").arg(GlobalMembersTimetable_defs.XX).arg(GlobalMembersTimetable_defs.YY);
			tos << "\n" << "\n";
			tos << tr("This file was automatically generated by FET %1.").arg(GlobalMembersTimetable_defs.FET_VERSION);
			tos << "\n";
		}

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(s).arg(file.error()));
		}
		file.close();
	}

	private static void writeTimetableDataFile(QWidget parent, QString filename)
	{
		if (!students_schedule_ready || !teachers_schedule_ready || !rooms_schedule_ready)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET - Critical"), tr("Timetable not generated - cannot save it - this should not happen (please report bug)"));
			return;
		}

		Solution tc = best_solution;

		for (int ai = 0; ai < gt.rules.nInternalActivities; ai++)
		{
			//Activity* act=&gt.rules.internalActivitiesList[ai];
			int time = tc.times[ai];
			if (time == GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
				IrreconcilableCriticalMessage.critical(parent, tr("FET - Critical"), tr("Incomplete timetable - this should not happen - please report bug"));
				return;
			}

			int ri = tc.rooms[ai];
			if (ri == GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
			{
				IrreconcilableCriticalMessage.critical(parent, tr("FET - Critical"), tr("Incomplete timetable - this should not happen - please report bug"));
				return;
			}
		}

		rules2.initialized = true;

		rules2.institutionName = gt.rules.institutionName;
		rules2.comments = gt.rules.comments;

		rules2.nHoursPerDay = gt.rules.nHoursPerDay;
		for (int i = 0; i < gt.rules.nHoursPerDay; i++)
			rules2.hoursOfTheDay[i] = gt.rules.hoursOfTheDay[i];

		rules2.nDaysPerWeek = gt.rules.nDaysPerWeek;
		for (int i = 0; i < gt.rules.nDaysPerWeek; i++)
			rules2.daysOfTheWeek[i] = gt.rules.daysOfTheWeek[i];

		rules2.yearsList = gt.rules.yearsList;

		rules2.teachersList = gt.rules.teachersList;

		rules2.subjectsList = gt.rules.subjectsList;

		rules2.activityTagsList = gt.rules.activityTagsList;

		rules2.activitiesList = gt.rules.activitiesList;

		rules2.buildingsList = gt.rules.buildingsList;

		rules2.roomsList = gt.rules.roomsList;

		rules2.timeConstraintsList = gt.rules.timeConstraintsList;

		rules2.spaceConstraintsList = gt.rules.spaceConstraintsList;


		//add locking constraints
		QList<TimeConstraint> lockTimeConstraintsList = new QList<TimeConstraint>();
		QList<SpaceConstraint> lockSpaceConstraintsList = new QList<SpaceConstraint>();


		bool report = false;

		int addedTime = 0;
		int duplicatesTime = 0;
		int addedSpace = 0;
		int duplicatesSpace = 0;

		//lock selected activities
		for (int ai = 0; ai < gt.rules.nInternalActivities; ai++)
		{
			Activity act = gt.rules.internalActivitiesList[ai];
			int time = tc.times[ai];
			if (time >= 0 && time < gt.rules.nDaysPerWeek * gt.rules.nHoursPerDay)
			{
				int hour = time / gt.rules.nDaysPerWeek;
				int day = time % gt.rules.nDaysPerWeek;

				ConstraintActivityPreferredStartingTime ctr = new ConstraintActivityPreferredStartingTime(100.0, act.id, day, hour, false); //permanently locked is false
				bool t = rules2.addTimeConstraint(ctr);

				if (t)
				{
					addedTime++;
					lockTimeConstraintsList.append(ctr);
				}
				else
					duplicatesTime++;

				QString s = new QString();

				if (t)
					s = tr("Added the following constraint to saved file:") + "\n" + ctr.getDetailedDescription(gt.rules);
				else
				{
					s = tr("Constraint\n%1 NOT added to saved file - duplicate").arg(ctr.getDetailedDescription(gt.rules));
					if (ctr != null)
						ctr.Dispose();
				}

				if (report)
				{
					int k;
					if (t)
						k = TimetableExportMessage.information(parent, tr("FET information"), s, tr("Skip information"), tr("See next"), new QString(), 1, 0);
					else
						k = TimetableExportMessage.warning(parent, tr("FET warning"), s, tr("Skip information"), tr("See next"), new QString(), 1, 0);
					 if (k == 0)
						report = false;
				}
			}

			int ri = tc.rooms[ai];
			if (ri != GlobalMembersTimetable_defs.UNALLOCATED_SPACE && ri != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM && ri >= 0 && ri < gt.rules.nInternalRooms)
			{
				ConstraintActivityPreferredRoom ctr = new ConstraintActivityPreferredRoom(100, act.id, (gt.rules.internalRoomsList[ri]).name, false); //permanently locked is false
				bool t = rules2.addSpaceConstraint(ctr);

				QString s = new QString();

				if (t)
				{
					addedSpace++;
					lockSpaceConstraintsList.append(ctr);
				}
				else
					duplicatesSpace++;

				if (t)
					s = tr("Added the following constraint to saved file:") + "\n" + ctr.getDetailedDescription(gt.rules);
				else
				{
					s = tr("Constraint\n%1 NOT added to saved file - duplicate").arg(ctr.getDetailedDescription(gt.rules));
					if (ctr != null)
						ctr.Dispose();
				}

				if (report)
				{
					int k;
					if (t)
						k = TimetableExportMessage.information(parent, tr("FET information"), s, tr("Skip information"), tr("See next"), new QString(), 1, 0);
					else
						k = TimetableExportMessage.warning(parent, tr("FET warning"), s, tr("Skip information"), tr("See next"), new QString(), 1, 0);
					if (k == 0)
						report = false;
				}
			}
		}

		//QMessageBox::information(parent, tr("FET information"), tr("Added %1 locking time constraints and %2 locking space constraints to saved file,"
		// " ignored %3 activities which were already fixed in time and %4 activities which were already fixed in space").arg(addedTime).arg(addedSpace).arg(duplicatesTime).arg(duplicatesSpace));

		bool result = rules2.write(parent, filename);

		while (!lockTimeConstraintsList.isEmpty())
			lockTimeConstraintsList.takeFirst() = null;
		while (!lockSpaceConstraintsList.isEmpty())
			lockSpaceConstraintsList.takeFirst() = null;

		//if(result)
		//	QMessageBox::information(parent, tr("FET information"),
		//		tr("File saved successfully. You can see it on the hard disk. Current data file remained untouched (of locking constraints),"
		//		" so you can save it also, or generate different timetables."));

		rules2.nHoursPerDay = 0;
		rules2.nDaysPerWeek = 0;

		rules2.yearsList.clear();

		rules2.teachersList.clear();

		rules2.subjectsList.clear();

		rules2.activityTagsList.clear();

		rules2.activitiesList.clear();

		rules2.buildingsList.clear();

		rules2.roomsList.clear();

		rules2.timeConstraintsList.clear();

		rules2.spaceConstraintsList.clear();

		if (!result)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), tr("Could not save the data + timetable file on the hard disk - maybe hard disk is full"));
		}
	}

	//the following functions return a single html table (needed for html file export and printing)

	//the following functions return a single html table (needed for html file export and printing)

	//by Volker Dirr
	private static QString singleSubgroupsTimetableDaysHorizontalHtml(int htmlLevel, int subgroup, QString saveTime, bool printActivityTags)
	{
		Debug.Assert(subgroup >= 0);
		Debug.Assert(subgroup < gt.rules.nInternalSubgroups);
		QString tmpString = new QString();
		QString subgroup_name = gt.rules.internalSubgroupsList[subgroup].name;
		tmpString += "    <table id=\"table_" + GlobalMembersTimetableexport.hashStudentIDsTimetable.value(subgroup_name) + "\" border=\"1\"";
		if (subgroup % 2 == 0)
			tmpString += " class=\"odd_table\"";
		else
			tmpString += " class=\"even_table\"";
		tmpString += ">\n";

		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";
		tmpString += "      <thead>\n        <tr><td rowspan=\"2\"></td><th colspan=\"" + QString.number(gt.rules.nDaysPerWeek) + "\">" + GlobalMembersTimetable_defs.protect2(subgroup_name) + "</th></tr>\n";
		tmpString += "        <tr>\n          <!-- span -->\n";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"xAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + "</th>\n";
		}
		tmpString += "        </tr>\n";
		tmpString += "      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td></td><td colspan=\""+gt.rules.nDaysPerWeek+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
		{
		tmpString += "        <tr>\n";
		if (htmlLevel >= 2)
				tmpString += "          <th class=\"yAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
			for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
			{
				QList<int> allActivities = new QList<int>();
				allActivities.clear();
				allActivities << students_timetable_weekly[subgroup][day][hour];
				bool activitiesWithSameStartingtime = addActivitiesWithSameStartingTime(ref allActivities, hour);
				if (allActivities.size() == 1 && !activitiesWithSameStartingtime) // because i am using colspan or rowspan!!!
				{
					tmpString += writeActivityStudents(htmlLevel, students_timetable_weekly[subgroup][day][hour], day, hour, GlobalMembersGenerate_pre.subgroupNotAvailableDayHour[subgroup][day][hour], false, true, printActivityTags);
				}
				else
				{
					tmpString += writeActivitiesStudents(htmlLevel, allActivities, printActivityTags);
				}
			}
			tmpString += "        </tr>\n";
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td></td><td colspan=\"" + QString.number(gt.rules.nDaysPerWeek) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleSubgroupsTimetableDaysVerticalHtml(int htmlLevel, int subgroup, QString saveTime, bool printActivityTags)
	{
		Debug.Assert(subgroup >= 0);
		Debug.Assert(subgroup < gt.rules.nInternalSubgroups);
		QString tmpString = new QString();
		QString subgroup_name = gt.rules.internalSubgroupsList[subgroup].name;
		tmpString += "    <table id=\"table_" + GlobalMembersTimetableexport.hashStudentIDsTimetable.value(subgroup_name) + "\" border=\"1\"";
		if (subgroup % 2 == 0)
			tmpString += " class=\"odd_table\"";
		else
			tmpString += " class=\"even_table\"";
		tmpString += ">\n";

		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";
			tmpString += "      <thead>\n        <tr><td rowspan=\"2\"></td><th colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2(subgroup_name) + "</th></tr>\n";
		tmpString += "        <tr>\n          <!-- span -->\n";
		for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
		{
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"xAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
		}
		tmpString += "        </tr>\n";
		tmpString += "      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td></td><td colspan=\""+gt.rules.nHoursPerDay+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			tmpString += "        <tr>\n";
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"yAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + "</th>\n";
				for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
				{
				QList<int> allActivities = new QList<int>();
				allActivities.clear();
				allActivities << students_timetable_weekly[subgroup][day][hour];
				bool activitiesWithSameStartingtime = addActivitiesWithSameStartingTime(ref allActivities, hour);
				if (allActivities.size() == 1 && !activitiesWithSameStartingtime) // because i am using colspan or rowspan!!!
				{
					tmpString += writeActivityStudents(htmlLevel, students_timetable_weekly[subgroup][day][hour], day, hour, GlobalMembersGenerate_pre.subgroupNotAvailableDayHour[subgroup][day][hour], true, false, printActivityTags);
				}
				else
				{
					tmpString += writeActivitiesStudents(htmlLevel, allActivities, printActivityTags);
				}
				}
			tmpString += "        </tr>\n";
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td></td><td colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleSubgroupsTimetableTimeHorizontalHtml(int htmlLevel, int maxSubgroups, ref QSet<int> excludedNames, QString saveTime, bool printActivityTags)
	{
		QString tmpString = new QString();
		tmpString += "    <table border=\"1\">\n";
		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";

		tmpString += "      <thead>\n        <tr><td rowspan=\"2\"></td>";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
			tmpString += "<th colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + "</th>";
		tmpString += "        </tr>\n";
		tmpString += "        <tr>\n          <!-- span -->\n";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
			for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
			{
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"xAxis\">";
				else
					tmpString += "          <th>";
				tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
			}
		tmpString += "        </tr>\n";
		tmpString += "      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td></td><td colspan=\""+gt.rules.nHoursPerDay*gt.rules.nDaysPerWeek+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";

		int currentCount = 0;
		for (int subgroup = 0; subgroup < gt.rules.nInternalSubgroups && currentCount < maxSubgroups; subgroup++)
		{
			if (!excludedNames.contains(subgroup))
			{
				currentCount++;
				excludedNames << subgroup;
				tmpString += "        <tr>\n";
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"yAxis\">";
				else
					tmpString += "          <th>";
				tmpString += gt.rules.internalSubgroupsList[subgroup].name + "</th>\n";
				for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
				{
					for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
					{
						QList<int> allActivities = new QList<int>();
						allActivities.clear();
						allActivities << students_timetable_weekly[subgroup][day][hour];
						bool activitiesWithSameStartingtime = addActivitiesWithSameStartingTime(ref allActivities, hour);
						if (allActivities.size() == 1 && !activitiesWithSameStartingtime) // because i am using colspan or rowspan!!!
						{
							tmpString += writeActivityStudents(htmlLevel, students_timetable_weekly[subgroup][day][hour], day, hour, GlobalMembersGenerate_pre.subgroupNotAvailableDayHour[subgroup][day][hour], true, false, printActivityTags);
						}
						else
						{
							tmpString += writeActivitiesStudents(htmlLevel, allActivities, printActivityTags);
						}
					}
				}
				tmpString += "        </tr>\n";
			}
		}
		//workaround begin.
		tmpString += "      <tr class=\"foot\"><td></td><td colspan=\"" + QString.number(gt.rules.nHoursPerDay * gt.rules.nDaysPerWeek) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n    </table>\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleSubgroupsTimetableTimeVerticalHtml(int htmlLevel, int maxSubgroups, ref QSet<int> excludedNames, QString saveTime, bool printActivityTags)
	{
		QString tmpString = new QString();
		tmpString += "    <table border=\"1\">\n";
		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";

		tmpString += "      <thead>\n        <tr><td colspan=\"2\"></td>";

		int currentCount = 0;
		for (int subgroup = 0; subgroup < gt.rules.nInternalSubgroups && currentCount < maxSubgroups; subgroup++)
		{
			if (!excludedNames.contains(subgroup))
			{
				currentCount++;
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"xAxis\">";
				else
					tmpString += "          <th>";
				tmpString += gt.rules.internalSubgroupsList[subgroup].name + "</th>";
			}
		}
		tmpString += "</tr>\n      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td colspan=\"2\"></td><td colspan=\""+QString::number(currentCount)+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
			{
				tmpString += "        <tr>\n";
				if (hour == 0)
					tmpString += "        <th rowspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2vert(gt.rules.daysOfTheWeek[day]) + "</th>\n";
				else
					tmpString += "          <!-- span -->\n";

				if (htmlLevel >= 2)
					tmpString += "          <th class=\"yAxis\">";
				else
					tmpString += "          <th>";
				tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
				currentCount = 0;
				for (int subgroup = 0; subgroup < gt.rules.nInternalSubgroups && currentCount < maxSubgroups; subgroup++)
				{
					if (!excludedNames.contains(subgroup))
					{
						currentCount++;
						if (day + 1 == gt.rules.nDaysPerWeek && hour + 1 == gt.rules.nHoursPerDay)
							excludedNames << subgroup;
						QList<int> allActivities = new QList<int>();
						allActivities.clear();
						allActivities << students_timetable_weekly[subgroup][day][hour];
						bool activitiesWithSameStartingtime = addActivitiesWithSameStartingTime(ref allActivities, hour);
						if (allActivities.size() == 1 && !activitiesWithSameStartingtime) // because i am using colspan or rowspan!!!
						{
							tmpString += writeActivityStudents(htmlLevel, students_timetable_weekly[subgroup][day][hour], day, hour, GlobalMembersGenerate_pre.subgroupNotAvailableDayHour[subgroup][day][hour], false, true, printActivityTags);
						}
						else
						{
							tmpString += writeActivitiesStudents(htmlLevel, allActivities, printActivityTags);
						}
					}
				}
				tmpString += "        </tr>\n";
			}
		}
		//workaround begin.
		tmpString += "      <tr class=\"foot\"><td colspan=\"2\"></td><td colspan=\"" + QString.number(currentCount) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n    </table>\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleSubgroupsTimetableTimeHorizontalDailyHtml(int htmlLevel, int day, int maxSubgroups, ref QSet<int> excludedNames, QString saveTime, bool printActivityTags)
	{
		Debug.Assert(day >= 0);
		Debug.Assert(day < gt.rules.nDaysPerWeek);
		QString tmpString = new QString();
		tmpString += "    <table id=\"table_" + GlobalMembersTimetableexport.hashDayIDsTimetable.value(gt.rules.daysOfTheWeek[day]) + "\" border=\"1\">\n";
		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";

		tmpString += "      <thead>\n        <tr><td rowspan=\"2\"></td>";
		tmpString += "<th colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + "</th>";
		tmpString += "        </tr>\n";
		tmpString += "        <tr>\n          <!-- span -->\n";
		for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
		{
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"xAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
		}
		tmpString += "        </tr>\n";
		tmpString += "      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td></td><td colspan=\""+gt.rules.nHoursPerDay+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		int currentCount = 0;
		for (int subgroup = 0; subgroup < gt.rules.nInternalSubgroups && currentCount < maxSubgroups; subgroup++)
		{
			if (!excludedNames.contains(subgroup))
			{
				currentCount++;
				excludedNames << subgroup;

				tmpString += "        <tr>\n";
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"yAxis\">";
				else
					tmpString += "          <th>";
				tmpString += gt.rules.internalSubgroupsList[subgroup].name + "</th>\n";
				for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
				{
					QList<int> allActivities = new QList<int>();
					allActivities.clear();
					allActivities << students_timetable_weekly[subgroup][day][hour];
					bool activitiesWithSameStartingtime = addActivitiesWithSameStartingTime(ref allActivities, hour);
					if (allActivities.size() == 1 && !activitiesWithSameStartingtime) // because i am using colspan or rowspan!!!
					{
						tmpString += writeActivityStudents(htmlLevel, students_timetable_weekly[subgroup][day][hour], day, hour, GlobalMembersGenerate_pre.subgroupNotAvailableDayHour[subgroup][day][hour], true, false, printActivityTags);
					}
					else
					{
						tmpString += writeActivitiesStudents(htmlLevel, allActivities, printActivityTags);
					}
				}
				tmpString += "        </tr>\n";
			}
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td></td><td colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleSubgroupsTimetableTimeVerticalDailyHtml(int htmlLevel, int day, int maxSubgroups, ref QSet<int> excludedNames, QString saveTime, bool printActivityTags)
	{
		Debug.Assert(day >= 0);
		Debug.Assert(day < gt.rules.nDaysPerWeek);

		QString tmpString = new QString();
		tmpString += "    <table id=\"table_" + GlobalMembersTimetableexport.hashDayIDsTimetable.value(gt.rules.daysOfTheWeek[day]) + "\" border=\"1\">\n";
		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";

		tmpString += "      <thead>\n        <tr><td colspan=\"2\"></td>";
		int currentCount = 0;
		for (int subgroup = 0; subgroup < gt.rules.nInternalSubgroups && currentCount < maxSubgroups; subgroup++)
		{
			if (!excludedNames.contains(subgroup))
			{
				currentCount++;
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"xAxis\">";
				else
					tmpString += "          <th>";
				tmpString += gt.rules.internalSubgroupsList[subgroup].name + "</th>";
			}
		}
		tmpString += "</tr>\n      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td colspan=\"2\"></td><td colspan=\""+QString::number(currentCount)+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
		{
			tmpString += "        <tr>\n";
			if (hour == 0)
				tmpString += "        <th rowspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2vert(gt.rules.daysOfTheWeek[day]) + "</th>\n";
			else
				tmpString += "          <!-- span -->\n";
				if (htmlLevel >= 2)
				tmpString += "          <th class=\"yAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
			currentCount = 0;
			for (int subgroup = 0; subgroup < gt.rules.nInternalSubgroups && currentCount < maxSubgroups; subgroup++)
			{
				if (!excludedNames.contains(subgroup))
				{
					currentCount++;
					if (hour + 1 == gt.rules.nHoursPerDay)
						excludedNames << subgroup;
					QList<int> allActivities = new QList<int>();
					allActivities.clear();
					allActivities << students_timetable_weekly[subgroup][day][hour];
					bool activitiesWithSameStartingtime = addActivitiesWithSameStartingTime(ref allActivities, hour);
					if (allActivities.size() == 1 && !activitiesWithSameStartingtime) // because i am using colspan or rowspan!!!
					{
						tmpString += writeActivityStudents(htmlLevel, students_timetable_weekly[subgroup][day][hour], day, hour, GlobalMembersGenerate_pre.subgroupNotAvailableDayHour[subgroup][day][hour], false, true, printActivityTags);
					}
					else
					{
						tmpString += writeActivitiesStudents(htmlLevel, allActivities, printActivityTags);
					}
				}
			}
			tmpString += "        </tr>\n";
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td colspan=\"2\"></td><td colspan=\"" + QString.number(currentCount) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleGroupsTimetableDaysHorizontalHtml(int htmlLevel, int group, QString saveTime, bool printActivityTags, bool detailed)
	{
		Debug.Assert(group >= 0);
		Debug.Assert(group < gt.rules.internalGroupsList.size());
		QString tmpString = new QString();
		tmpString += "    <table id=\"table_" + GlobalMembersTimetableexport.hashStudentIDsTimetable.value(gt.rules.internalGroupsList[group].name);
		if (detailed)
			tmpString += "_DETAILED";
		tmpString += "\" border=\"1\"";
		if (group % 2)
			tmpString += " class=\"even_table\"";
		else
			tmpString += " class=\"odd_table\"";
		tmpString += ">\n";

		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";
		tmpString += "      <thead>\n        <tr><td rowspan=\"2\"></td><th colspan=\"" + QString.number(gt.rules.nDaysPerWeek) + "\">" + GlobalMembersTimetable_defs.protect2(gt.rules.internalGroupsList[group].name) + "</th></tr>\n";
		tmpString += "        <tr>\n          <!-- span -->\n";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"xAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + "</th>\n";
		}
		tmpString += "        </tr>\n";
		tmpString += "      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td></td><td colspan=\""+gt.rules.nDaysPerWeek+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
		{
			tmpString += "        <tr>\n";
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"yAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
			for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
			{
				QList<int> allActivities = new QList<int>();
				allActivities.clear();
				bool isNotAvailable = true;
				for (int sg = 0; sg < gt.rules.internalGroupsList[group].subgroupsList.size(); sg++)
				{
					StudentsSubgroup sts = gt.rules.internalGroupsList[group].subgroupsList[sg];
					int subgroup = sts.indexInInternalSubgroupsList;
					if (!(allActivities.contains(students_timetable_weekly[subgroup][day][hour])))
						allActivities << students_timetable_weekly[subgroup][day][hour];
					if (!GlobalMembersGenerate_pre.subgroupNotAvailableDayHour[subgroup][day][hour])
						isNotAvailable = false;
				}
				Debug.Assert(!allActivities.isEmpty());
				bool activitiesWithSameStartingtime = addActivitiesWithSameStartingTime(ref allActivities, hour);
				if (allActivities.size() == 1 && !activitiesWithSameStartingtime) // because i am using colspan or rowspan!!!
				{
					tmpString += writeActivityStudents(htmlLevel, allActivities[0], day, hour, isNotAvailable, false, true, printActivityTags);
				}
				else
				{
					if (!detailed)
						tmpString += "          <td>" + GlobalMembersTimetable_defs.protect2(GlobalMembersTimetableexport.STRING_SEVERAL_ACTIVITIES_IN_LESS_DETAILED_TABLES) + "</td>\n";
					else
					{
						tmpString += writeActivitiesStudents(htmlLevel, allActivities, printActivityTags);
					}
				}
			}
			tmpString += "        </tr>\n";
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td></td><td colspan=\"" + QString.number(gt.rules.nDaysPerWeek) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleGroupsTimetableDaysVerticalHtml(int htmlLevel, int group, QString saveTime, bool printActivityTags, bool detailed)
	{
		Debug.Assert(group >= 0);
		Debug.Assert(group < gt.rules.internalGroupsList.size());
		QString tmpString = new QString();
		tmpString += "    <table id=\"table_" + GlobalMembersTimetableexport.hashStudentIDsTimetable.value(gt.rules.internalGroupsList.at(group).name);
		if (detailed)
			tmpString += "_DETAILED";
		tmpString += "\" border=\"1\"";
		if (group % 2)
			tmpString += " class=\"even_table\"";
		else
			tmpString += " class=\"odd_table\"";
		tmpString += ">\n";

		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";
		tmpString += "      <thead>\n        <tr><td rowspan=\"2\"></td><th colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2(gt.rules.internalGroupsList.at(group).name) + "</th></tr>\n";
		tmpString += "        <tr>\n          <!-- span -->\n";
		for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
		{
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"xAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
		}
		tmpString += "        </tr>\n";
		tmpString += "      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td></td><td colspan=\""+gt.rules.nHoursPerDay+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			tmpString += "        <tr>\n";
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"yAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + "</th>\n";
			for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
			{
				QList<int> allActivities = new QList<int>();
				allActivities.clear();
				bool isNotAvailable = true;
				for (int sg = 0; sg < gt.rules.internalGroupsList.at(group).subgroupsList.size(); sg++)
				{
					StudentsSubgroup sts = gt.rules.internalGroupsList.at(group).subgroupsList[sg];
					int subgroup = sts.indexInInternalSubgroupsList;
					if (!(allActivities.contains(students_timetable_weekly[subgroup][day][hour])))
						allActivities << students_timetable_weekly[subgroup][day][hour];
					if (!GlobalMembersGenerate_pre.subgroupNotAvailableDayHour[subgroup][day][hour])
						isNotAvailable = false;
				}
				Debug.Assert(!allActivities.isEmpty());
				bool activitiesWithSameStartingtime = addActivitiesWithSameStartingTime(ref allActivities, hour);
				if (allActivities.size() == 1 && !activitiesWithSameStartingtime) // because i am using colspan or rowspan!!!
				{
					tmpString += writeActivityStudents(htmlLevel, allActivities[0], day, hour, isNotAvailable, true, false, printActivityTags);
				}
				else
				{
					if (!detailed)
						tmpString += "          <td>" + GlobalMembersTimetable_defs.protect2(GlobalMembersTimetableexport.STRING_SEVERAL_ACTIVITIES_IN_LESS_DETAILED_TABLES) + "</td>\n";
					else
					{
						tmpString += writeActivitiesStudents(htmlLevel, allActivities, printActivityTags);
					}
				}
			}
			tmpString += "        </tr>\n";
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td></td><td colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleGroupsTimetableTimeHorizontalHtml(int htmlLevel, int maxGroups, ref QSet<int> excludedNames, QString saveTime, bool printActivityTags, bool detailed)
	{
		QString tmpString = new QString();
		tmpString += "    <table id=\"table";
		if (!detailed)
			tmpString += "_LESS";
		tmpString += "_DETAILED";
		tmpString += "\" border=\"1\">\n";
		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";
		tmpString += "      <thead>\n        <tr><td rowspan=\"2\"></td>";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
			tmpString += "<th colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + "</th>";
		tmpString += "</tr>\n";
		tmpString += "        <tr>\n          <!-- span -->\n";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
			for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
			{
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"xAxis\">";
				else
					tmpString += "          <th>";
				tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
			}
		tmpString += "        </tr>\n";
		tmpString += "      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td></td><td colspan=\""+gt.rules.nDaysPerWeek*gt.rules.nHoursPerDay+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";

		int currentCount = 0;
		for (int group = 0; group < gt.rules.internalGroupsList.size() && currentCount < maxGroups; group++)
		{
			if (!excludedNames.contains(group))
			{
				currentCount++;
				excludedNames << group;

				tmpString += "        <tr>\n";
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"yAxis\">";
				else
					tmpString += "          <th>";
				tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.internalGroupsList.at(group).name) + "</th>\n";
				for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
				{
					for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
					{
						QList<int> allActivities = new QList<int>();
						allActivities.clear();
						bool isNotAvailable = true;
						for (int sg = 0; sg < gt.rules.internalGroupsList.at(group).subgroupsList.size(); sg++)
						{
							StudentsSubgroup sts = gt.rules.internalGroupsList.at(group).subgroupsList[sg];
							int subgroup = sts.indexInInternalSubgroupsList;
							if (!(allActivities.contains(students_timetable_weekly[subgroup][day][hour])))
								allActivities << students_timetable_weekly[subgroup][day][hour];
							if (!GlobalMembersGenerate_pre.subgroupNotAvailableDayHour[subgroup][day][hour])
								isNotAvailable = false;
						}
						Debug.Assert(!allActivities.isEmpty());
						bool activitiesWithSameStartingtime = addActivitiesWithSameStartingTime(ref allActivities, hour);
						if (allActivities.size() == 1 && !activitiesWithSameStartingtime) // because i am using colspan or rowspan!!!
						{
							tmpString += writeActivityStudents(htmlLevel, allActivities[0], day, hour, isNotAvailable, true, false, printActivityTags);
						}
						else
						{
							if (!detailed)
								tmpString += "          <td>" + GlobalMembersTimetable_defs.protect2(GlobalMembersTimetableexport.STRING_SEVERAL_ACTIVITIES_IN_LESS_DETAILED_TABLES) + "</td>\n";
							else
							{
								tmpString += writeActivitiesStudents(htmlLevel, allActivities, printActivityTags);
							}
						}
					}
				}
			}
			tmpString += "        </tr>\n";
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td></td><td colspan=\"" + QString.number(gt.rules.nDaysPerWeek * gt.rules.nHoursPerDay) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleGroupsTimetableTimeVerticalHtml(int htmlLevel, int maxGroups, ref QSet<int> excludedNames, QString saveTime, bool printActivityTags, bool detailed)
	{
		QString tmpString = new QString();
		tmpString += "    <table id=\"table";
		if (!detailed)
			tmpString += "_LESS";
		tmpString += "_DETAILED";
		tmpString += "\" border=\"1\">\n";
			tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";
			tmpString += "      <thead>\n        <tr><td colspan=\"2\"></td>";
		int currentCount = 0;
		for (int group = 0; group < gt.rules.internalGroupsList.size() && currentCount < maxGroups; group++)
		{
			if (!excludedNames.contains(group))
			{
				currentCount++;
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"xAxis\">";
				else
					tmpString += "          <th>";
				tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.internalGroupsList.at(group).name) + "</th>";
			}
		}

		tmpString += "</tr>\n      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td colspan=\"2\"></td><td colspan=\""+QString::number(currentCount)+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
			{
				currentCount = 0;
				tmpString += "        <tr>\n";
				if (hour == 0)
					tmpString += "        <th rowspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2vert(gt.rules.daysOfTheWeek[day]) + "</th>\n";
				else
					tmpString += "          <!-- span -->\n";
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"yAxis\">";
				else
					tmpString += "          <th>";
				tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
				for (int group = 0; group < gt.rules.internalGroupsList.size() && currentCount < maxGroups; group++)
				{
					if (!excludedNames.contains(group))
					{
						currentCount++;
						if (day + 1 == gt.rules.nDaysPerWeek && hour + 1 == gt.rules.nHoursPerDay)
							excludedNames << group;
						QList<int> allActivities = new QList<int>();
						allActivities.clear();
						bool isNotAvailable = true;
						for (int sg = 0; sg < gt.rules.internalGroupsList.at(group).subgroupsList.size(); sg++)
						{
							StudentsSubgroup sts = gt.rules.internalGroupsList.at(group).subgroupsList[sg];
							int subgroup = sts.indexInInternalSubgroupsList;
							if (!(allActivities.contains(students_timetable_weekly[subgroup][day][hour])))
								allActivities << students_timetable_weekly[subgroup][day][hour];
							if (!GlobalMembersGenerate_pre.subgroupNotAvailableDayHour[subgroup][day][hour])
								isNotAvailable = false;
						}
						Debug.Assert(!allActivities.isEmpty());
						bool activitiesWithSameStartingtime = addActivitiesWithSameStartingTime(ref allActivities, hour);
						if (allActivities.size() == 1 && !activitiesWithSameStartingtime) // because i am using colspan or rowspan!!!
						{
							tmpString += writeActivityStudents(htmlLevel, allActivities[0], day, hour, isNotAvailable, false, true, printActivityTags);
						}
						else
						{
							if (!detailed)
								tmpString += "          <td>" + GlobalMembersTimetable_defs.protect2(GlobalMembersTimetableexport.STRING_SEVERAL_ACTIVITIES_IN_LESS_DETAILED_TABLES) + "</td>\n";
							else
							{
								tmpString += writeActivitiesStudents(htmlLevel, allActivities, printActivityTags);
							}
						}
					}
				}
				tmpString += "        </tr>\n";
			}
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td colspan=\"2\"></td><td colspan=\"" + QString.number(currentCount) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleGroupsTimetableTimeHorizontalDailyHtml(int htmlLevel, int day, int maxGroups, ref QSet<int> excludedNames, QString saveTime, bool printActivityTags, bool detailed)
	{
		Debug.Assert(day >= 0);
		Debug.Assert(day < gt.rules.nDaysPerWeek);
		QString tmpString = new QString();
		tmpString += "    <table id=\"table_" + GlobalMembersTimetableexport.hashDayIDsTimetable.value(gt.rules.daysOfTheWeek[day]);
		if (detailed)
			tmpString += "_DETAILED";
		tmpString += "\" border=\"1\">\n";
		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";
		tmpString += "      <thead>\n        <tr><td rowspan=\"2\"></td>";
		tmpString += "<th colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + "</th>";
		tmpString += "</tr>\n";
		tmpString += "        <tr>\n          <!-- span -->\n";
		for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
		{
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"xAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
		}
		tmpString += "        </tr>\n";
		tmpString += "      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td></td><td colspan=\""+gt.rules.nHoursPerDay+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";

		int currentCount = 0;
		for (int group = 0; group < gt.rules.internalGroupsList.size() && currentCount < maxGroups; group++)
		{
			if (!excludedNames.contains(group))
			{
				currentCount++;
				excludedNames << group;

				tmpString += "        <tr>\n";
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"yAxis\">";
				else
					tmpString += "          <th>";
				tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.internalGroupsList.at(group).name) + "</th>\n";
				for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
				{
					QList<int> allActivities = new QList<int>();
					allActivities.clear();
					bool isNotAvailable = true;
					for (int sg = 0; sg < gt.rules.internalGroupsList.at(group).subgroupsList.size(); sg++)
					{
						StudentsSubgroup sts = gt.rules.internalGroupsList.at(group).subgroupsList[sg];
						int subgroup = sts.indexInInternalSubgroupsList;
						if (!(allActivities.contains(students_timetable_weekly[subgroup][day][hour])))
							allActivities << students_timetable_weekly[subgroup][day][hour];
						if (!GlobalMembersGenerate_pre.subgroupNotAvailableDayHour[subgroup][day][hour])
							isNotAvailable = false;
					}
					Debug.Assert(!allActivities.isEmpty());
					bool activitiesWithSameStartingtime = addActivitiesWithSameStartingTime(ref allActivities, hour);
					if (allActivities.size() == 1 && !activitiesWithSameStartingtime) // because i am using colspan or rowspan!!!
					{
						tmpString += writeActivityStudents(htmlLevel, allActivities[0], day, hour, isNotAvailable, true, false, printActivityTags);
					}
					else
					{
						if (!detailed)
							tmpString += "          <td>" + GlobalMembersTimetable_defs.protect2(GlobalMembersTimetableexport.STRING_SEVERAL_ACTIVITIES_IN_LESS_DETAILED_TABLES) + "</td>\n";
						else
						{
							tmpString += writeActivitiesStudents(htmlLevel, allActivities, printActivityTags);
						}
					}
				}
				tmpString += "        </tr>\n";
			}
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td></td><td colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleGroupsTimetableTimeVerticalDailyHtml(int htmlLevel, int day, int maxGroups, ref QSet<int> excludedNames, QString saveTime, bool printActivityTags, bool detailed)
	{
		Debug.Assert(day >= 0);
		Debug.Assert(day < gt.rules.nDaysPerWeek);
		QString tmpString = new QString();
		tmpString += "    <table id=\"table_" + GlobalMembersTimetableexport.hashDayIDsTimetable.value(gt.rules.daysOfTheWeek[day]);
		if (detailed)
			tmpString += "_DETAILED";
		tmpString += "\" border=\"1\">\n";
		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";
		tmpString += "      <thead>\n        <tr><td colspan=\"2\"></td>";
		int currentCount = 0;
		for (int group = 0; group < gt.rules.internalGroupsList.size() && currentCount < maxGroups; group++)
		{
			if (!excludedNames.contains(group))
			{
				currentCount++;
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"xAxis\">";
				else
					tmpString += "          <th>";
				tmpString += gt.rules.internalGroupsList.at(group).name + "</th>";
			}
		}

		tmpString += "</tr>\n      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td colspan=\"2\"></td><td colspan=\""+QString::number(currentCount)+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
		{
			currentCount = 0;
			tmpString += "        <tr>\n";
			if (hour == 0)
				tmpString += "        <th rowspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2vert(gt.rules.daysOfTheWeek[day]) + "</th>\n";
			else
				tmpString += "          <!-- span -->\n";
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"yAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
			for (int group = 0; group < gt.rules.internalGroupsList.size() && currentCount < maxGroups; group++)
			{
				if (!excludedNames.contains(group))
				{
					currentCount++;
					if (hour + 1 == gt.rules.nHoursPerDay)
						excludedNames << group;
					QList<int> allActivities = new QList<int>();
					allActivities.clear();
					bool isNotAvailable = true;
					for (int sg = 0; sg < gt.rules.internalGroupsList.at(group).subgroupsList.size(); sg++)
					{
						StudentsSubgroup sts = gt.rules.internalGroupsList.at(group).subgroupsList[sg];
						int subgroup = sts.indexInInternalSubgroupsList;
						if (!(allActivities.contains(students_timetable_weekly[subgroup][day][hour])))
							allActivities << students_timetable_weekly[subgroup][day][hour];
						if (!GlobalMembersGenerate_pre.subgroupNotAvailableDayHour[subgroup][day][hour])
							isNotAvailable = false;
					}
					Debug.Assert(!allActivities.isEmpty());
					bool activitiesWithSameStartingtime = addActivitiesWithSameStartingTime(ref allActivities, hour);
					if (allActivities.size() == 1 && !activitiesWithSameStartingtime) // because i am using colspan or rowspan!!!
					{
						tmpString += writeActivityStudents(htmlLevel, allActivities[0], day, hour, isNotAvailable, false, true, printActivityTags);
					}
					else
					{
						if (!detailed)
							tmpString += "          <td>" + GlobalMembersTimetable_defs.protect2(GlobalMembersTimetableexport.STRING_SEVERAL_ACTIVITIES_IN_LESS_DETAILED_TABLES) + "</td>\n";
						else
						{
							tmpString += writeActivitiesStudents(htmlLevel, allActivities, printActivityTags);
						}
					}
				}
			}
			tmpString += "        </tr>\n";
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td colspan=\"2\"></td><td colspan=\"" + QString.number(currentCount) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleYearsTimetableDaysHorizontalHtml(int htmlLevel, int year, QString saveTime, bool printActivityTags, bool detailed)
	{
		Debug.Assert(year >= 0);
		Debug.Assert(year < gt.rules.augmentedYearsList.size());
		QString tmpString = new QString();
		tmpString += "    <table id=\"table_" + GlobalMembersTimetableexport.hashStudentIDsTimetable.value(gt.rules.augmentedYearsList.at(year).name);
		if (detailed)
			tmpString += "_DETAILED";
		tmpString += "\" border=\"1\"";
		if (year % 2)
			tmpString += " class=\"even_table\"";
		else
			tmpString += " class=\"odd_table\"";
		tmpString += ">\n";

		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";
		tmpString += "      <thead>\n        <tr><td rowspan=\"2\"></td><th colspan=\"" + QString.number(gt.rules.nDaysPerWeek) + "\">" + GlobalMembersTimetable_defs.protect2(gt.rules.augmentedYearsList.at(year).name) + "</th></tr>\n";
		tmpString += "        <tr>\n          <!-- span -->\n";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"xAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + "</th>\n";
		}
		tmpString += "        </tr>\n";
		tmpString += "      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td></td><td colspan=\""+gt.rules.nDaysPerWeek+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
		{
			tmpString += "        <tr>\n";
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"yAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
			for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
			{
				QList<int> allActivities = new QList<int>();
				allActivities.clear();
				bool isNotAvailable = true;
				for (int g = 0; g < gt.rules.augmentedYearsList.at(year).groupsList.size(); g++)
				{
					StudentsGroup stg = gt.rules.augmentedYearsList.at(year).groupsList[g];
					for (int sg = 0; sg < stg.subgroupsList.size(); sg++)
					{
						StudentsSubgroup sts = stg.subgroupsList[sg];
						int subgroup = sts.indexInInternalSubgroupsList;
						if (!(allActivities.contains(students_timetable_weekly[subgroup][day][hour])))
							allActivities << students_timetable_weekly[subgroup][day][hour];
						if (!GlobalMembersGenerate_pre.subgroupNotAvailableDayHour[subgroup][day][hour])
							isNotAvailable = false;
					}
				}
				Debug.Assert(!allActivities.isEmpty());
				bool activitiesWithSameStartingtime = addActivitiesWithSameStartingTime(ref allActivities, hour);
				if (allActivities.size() == 1 && !activitiesWithSameStartingtime) // because i am using colspan or rowspan!!!
				{
					tmpString += writeActivityStudents(htmlLevel, allActivities[0], day, hour, isNotAvailable, false, true, printActivityTags);
				}
				else
				{
					if (!detailed)
						tmpString += "          <td>" + GlobalMembersTimetable_defs.protect2(GlobalMembersTimetableexport.STRING_SEVERAL_ACTIVITIES_IN_LESS_DETAILED_TABLES) + "</td>\n";
					else
					{
						tmpString += writeActivitiesStudents(htmlLevel, allActivities, printActivityTags);
					}
				}
			}
			tmpString += "        </tr>\n";
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td></td><td colspan=\"" + QString.number(gt.rules.nDaysPerWeek) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleYearsTimetableDaysVerticalHtml(int htmlLevel, int year, QString saveTime, bool printActivityTags, bool detailed)
	{
		Debug.Assert(year >= 0);
		Debug.Assert(year < gt.rules.augmentedYearsList.size());
		QString tmpString = new QString();
		tmpString += "    <table id=\"table_" + GlobalMembersTimetableexport.hashStudentIDsTimetable.value(gt.rules.augmentedYearsList.at(year).name);
		if (detailed)
			tmpString += "_DETAILED";
		tmpString += "\" border=\"1\"";
		if (year % 2)
			tmpString += " class=\"even_table\"";
		else
			tmpString += " class=\"odd_table\"";
		tmpString += ">\n";

		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";

		tmpString += "      <thead>\n        <tr><td rowspan=\"2\"></td><th colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2(gt.rules.augmentedYearsList.at(year).name) + "</th></tr>\n";
		tmpString += "        <tr>\n          <!-- span -->\n";
		for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
		{
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"xAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
		}
		tmpString += "        </tr>\n";
		tmpString += "      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td></td><td colspan=\""+gt.rules.nHoursPerDay+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			tmpString += "        <tr>\n";
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"yAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + "</th>\n";

			for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
			{
				QList<int> allActivities = new QList<int>();
				allActivities.clear();
				bool isNotAvailable = true;
				for (int g = 0; g < gt.rules.augmentedYearsList.at(year).groupsList.size(); g++)
				{
					StudentsGroup stg = gt.rules.augmentedYearsList.at(year).groupsList[g];
					for (int sg = 0; sg < stg.subgroupsList.size(); sg++)
					{
						StudentsSubgroup sts = stg.subgroupsList[sg];
						int subgroup = sts.indexInInternalSubgroupsList;
						if (!(allActivities.contains(students_timetable_weekly[subgroup][day][hour])))
							allActivities << students_timetable_weekly[subgroup][day][hour];
						if (!GlobalMembersGenerate_pre.subgroupNotAvailableDayHour[subgroup][day][hour])
							isNotAvailable = false;
					}
				}
				Debug.Assert(!allActivities.isEmpty());
				bool activitiesWithSameStartingtime = addActivitiesWithSameStartingTime(ref allActivities, hour);
				if (allActivities.size() == 1 && !activitiesWithSameStartingtime) // because i am using colspan or rowspan!!!
				{
					tmpString += writeActivityStudents(htmlLevel, allActivities[0], day, hour, isNotAvailable, true, false, printActivityTags);
				}
				else
				{
					if (!detailed)
						tmpString += "          <td>" + GlobalMembersTimetable_defs.protect2(GlobalMembersTimetableexport.STRING_SEVERAL_ACTIVITIES_IN_LESS_DETAILED_TABLES) + "</td>\n";
					else
					{
						tmpString += writeActivitiesStudents(htmlLevel, allActivities, printActivityTags);
					}
				}
			}
			tmpString += "        </tr>\n";
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td></td><td colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleYearsTimetableTimeHorizontalHtml(int htmlLevel, int maxYears, ref QSet<int> excludedNames, QString saveTime, bool printActivityTags, bool detailed)
	{
		QString tmpString = new QString();
		tmpString += "    <table id=\"table";
		if (!detailed)
			tmpString += "_LESS";
		tmpString += "_DETAILED";
		tmpString += "\" border=\"1\">\n";

		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";

		tmpString += "      <thead>\n        <tr><td rowspan=\"2\"></td>";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
			tmpString += "<th colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + "</th>";
		tmpString += "</tr>\n";
		tmpString += "        <tr>\n          <!-- span -->\n";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
			for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
			{
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"xAxis\">";
				else
					tmpString += "          <th>";
				tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
			}
		tmpString += "        </tr>\n";
		tmpString += "      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td></td><td colspan=\""+gt.rules.nHoursPerDay*gt.rules.nDaysPerWeek+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";

		int currentCount = 0;
		for (int year = 0; year < gt.rules.augmentedYearsList.size() && currentCount < maxYears; year++)
		{
			StudentsYear sty = gt.rules.augmentedYearsList[year];
			if (!excludedNames.contains(year))
			{
				currentCount++;
				excludedNames << year;
				tmpString += "        <tr>\n";
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"yAxis\">";
				else
					tmpString += "          <th>";
				tmpString += GlobalMembersTimetable_defs.protect2(sty.name) + "</th>\n";
				for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
				{
					for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
					{
						QList<int> allActivities = new QList<int>();
						allActivities.clear();
						bool isNotAvailable = true;
						for (int g = 0; g < sty.groupsList.size(); g++)
						{
							StudentsGroup stg = sty.groupsList[g];
							for (int sg = 0; sg < stg.subgroupsList.size(); sg++)
							{
								StudentsSubgroup sts = stg.subgroupsList[sg];
								int subgroup = sts.indexInInternalSubgroupsList;
								if (!(allActivities.contains(students_timetable_weekly[subgroup][day][hour])))
									allActivities << students_timetable_weekly[subgroup][day][hour];
								if (!GlobalMembersGenerate_pre.subgroupNotAvailableDayHour[subgroup][day][hour])
									isNotAvailable = false;
							}
						}
						Debug.Assert(!allActivities.isEmpty());
						bool activitiesWithSameStartingtime = addActivitiesWithSameStartingTime(ref allActivities, hour);
						if (allActivities.size() == 1 && !activitiesWithSameStartingtime) // because i am using colspan or rowspan!!!
						{
							tmpString += writeActivityStudents(htmlLevel, allActivities[0], day, hour, isNotAvailable, true, false, printActivityTags);
						}
						else
						{
							if (!detailed)
								tmpString += "          <td>" + GlobalMembersTimetable_defs.protect2(GlobalMembersTimetableexport.STRING_SEVERAL_ACTIVITIES_IN_LESS_DETAILED_TABLES) + "</td>\n";
							else
							{
								tmpString += writeActivitiesStudents(htmlLevel, allActivities, printActivityTags);
							}
						}
					}
				}
				tmpString += "        </tr>\n";
			}
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td></td><td colspan=\"" + QString.number(gt.rules.nHoursPerDay * gt.rules.nDaysPerWeek) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleYearsTimetableTimeVerticalHtml(int htmlLevel, int maxYears, ref QSet<int> excludedNames, QString saveTime, bool printActivityTags, bool detailed)
	{
		QString tmpString = new QString();
		tmpString += "    <table id=\"table";
		if (!detailed)
			tmpString += "_LESS";
		tmpString += "_DETAILED";
		tmpString += "\" border=\"1\">\n";

		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";

		tmpString += "      <thead>\n        <tr><td colspan=\"2\"></td>";
		int currentCount = 0;
		for (int year = 0; year < gt.rules.augmentedYearsList.size() && currentCount < maxYears; year++)
		{
			if (!excludedNames.contains(year))
			{
				currentCount++;
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"xAxis\">";
				else
					tmpString += "          <th>";
				tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.augmentedYearsList.at(year).name) + "</th>";
			}
		}

		tmpString += "</tr>\n      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td colspan=\"2\"></td><td colspan=\""+QString::number(currentCount)+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
			{
				tmpString += "        <tr>\n";
				if (hour == 0)
					tmpString += "        <th rowspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2vert(gt.rules.daysOfTheWeek[day]) + "</th>\n";
				else
					tmpString += "          <!-- span -->\n";
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"yAxis\">";
				else
					tmpString += "          <th>";
				tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
				currentCount = 0;
				for (int year = 0; year < gt.rules.augmentedYearsList.size() && currentCount < maxYears; year++)
				{
					if (!excludedNames.contains(year))
					{
						currentCount++;
						if (day + 1 == gt.rules.nDaysPerWeek && hour + 1 == gt.rules.nHoursPerDay)
							excludedNames << year;
						QList<int> allActivities = new QList<int>();
						allActivities.clear();
						bool isNotAvailable = true;
						StudentsYear sty = gt.rules.augmentedYearsList[year];
						for (int g = 0; g < sty.groupsList.size(); g++)
						{
							StudentsGroup stg = sty.groupsList[g];
							for (int sg = 0; sg < stg.subgroupsList.size(); sg++)
							{
								StudentsSubgroup sts = stg.subgroupsList[sg];
								int subgroup = sts.indexInInternalSubgroupsList;
								if (!(allActivities.contains(students_timetable_weekly[subgroup][day][hour])))
									allActivities << students_timetable_weekly[subgroup][day][hour];
								if (!GlobalMembersGenerate_pre.subgroupNotAvailableDayHour[subgroup][day][hour])
									isNotAvailable = false;
							}
						}
						Debug.Assert(!allActivities.isEmpty());
						bool activitiesWithSameStartingtime = addActivitiesWithSameStartingTime(ref allActivities, hour);
						if (allActivities.size() == 1 && !activitiesWithSameStartingtime) // because i am using colspan or rowspan!!!
						{
							tmpString += writeActivityStudents(htmlLevel, allActivities[0], day, hour, isNotAvailable, false, true, printActivityTags);
						}
						else
						{
							if (!detailed)
								tmpString += "          <td>" + GlobalMembersTimetable_defs.protect2(GlobalMembersTimetableexport.STRING_SEVERAL_ACTIVITIES_IN_LESS_DETAILED_TABLES) + "</td>\n";
							else
							{
								tmpString += writeActivitiesStudents(htmlLevel, allActivities, printActivityTags);
							}
						}
					}
				}
				tmpString += "        </tr>\n";
			}
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td colspan=\"2\"></td><td colspan=\"" + QString.number(currentCount) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleYearsTimetableTimeHorizontalDailyHtml(int htmlLevel, int day, int maxYears, ref QSet<int> excludedNames, QString saveTime, bool printActivityTags, bool detailed)
	{
		Debug.Assert(day >= 0);
		Debug.Assert(day < gt.rules.nDaysPerWeek);
		QString tmpString = new QString();
		tmpString += "    <table id=\"table_" + GlobalMembersTimetableexport.hashDayIDsTimetable.value(gt.rules.daysOfTheWeek[day]);
		if (detailed)
			tmpString += "_DETAILED";
		tmpString += "\" border=\"1\">\n";

		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";

		tmpString += "      <thead>\n        <tr><td rowspan=\"2\"></td>";

		tmpString += "<th colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + "</th>";
		tmpString += "</tr>\n";
		tmpString += "        <tr>\n          <!-- span -->\n";
		for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
		{
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"xAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
		}
		tmpString += "        </tr>\n";
		tmpString += "      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td></td><td colspan=\""+gt.rules.nHoursPerDay+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		int currentCount = 0;
		for (int year = 0; year < gt.rules.augmentedYearsList.size() && currentCount < maxYears; year++)
		{
			if (!excludedNames.contains(year))
			{
				currentCount++;
				excludedNames << year;
				tmpString += "        <tr>\n";
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"yAxis\">";
				else
					tmpString += "          <th>";
				StudentsYear sty = gt.rules.augmentedYearsList[year];
				tmpString += GlobalMembersTimetable_defs.protect2(sty.name) + "</th>\n";
				for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
				{
					QList<int> allActivities = new QList<int>();
					allActivities.clear();
					bool isNotAvailable = true;
					for (int g = 0; g < sty.groupsList.size(); g++)
					{
						StudentsGroup stg = sty.groupsList[g];
						for (int sg = 0; sg < stg.subgroupsList.size(); sg++)
						{
							StudentsSubgroup sts = stg.subgroupsList[sg];
							int subgroup = sts.indexInInternalSubgroupsList;
							if (!(allActivities.contains(students_timetable_weekly[subgroup][day][hour])))
								allActivities << students_timetable_weekly[subgroup][day][hour];
							if (!GlobalMembersGenerate_pre.subgroupNotAvailableDayHour[subgroup][day][hour])
								isNotAvailable = false;
						}
					}
					Debug.Assert(!allActivities.isEmpty());
					bool activitiesWithSameStartingtime = addActivitiesWithSameStartingTime(ref allActivities, hour);
					if (allActivities.size() == 1 && !activitiesWithSameStartingtime) // because i am using colspan or rowspan!!!
					{
						tmpString += writeActivityStudents(htmlLevel, allActivities[0], day, hour, isNotAvailable, true, false, printActivityTags);
					}
					else
					{
						if (!detailed)
							tmpString += "          <td>" + GlobalMembersTimetable_defs.protect2(GlobalMembersTimetableexport.STRING_SEVERAL_ACTIVITIES_IN_LESS_DETAILED_TABLES) + "</td>\n";
						else
						{
							tmpString += writeActivitiesStudents(htmlLevel, allActivities, printActivityTags);
						}
					}
				}
				tmpString += "        </tr>\n";
			}
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td></td><td colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleYearsTimetableTimeVerticalDailyHtml(int htmlLevel, int day, int maxYears, ref QSet<int> excludedNames, QString saveTime, bool printActivityTags, bool detailed)
	{
		Debug.Assert(day >= 0);
		Debug.Assert(day < gt.rules.nDaysPerWeek);
		QString tmpString = new QString();
		tmpString += "    <table id=\"table_" + GlobalMembersTimetableexport.hashDayIDsTimetable.value(gt.rules.daysOfTheWeek[day]);
		if (detailed)
			tmpString += "_DETAILED";
		tmpString += "\" border=\"1\">\n";

		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";

		tmpString += "      <thead>\n        <tr><td colspan=\"2\"></td>";
		int currentCount = 0;
		for (int year = 0; year < gt.rules.augmentedYearsList.size() && currentCount < maxYears; year++)
		{
			if (!excludedNames.contains(year))
			{
				currentCount++;

				if (htmlLevel >= 2)
					tmpString += "          <th class=\"xAxis\">";
				else
					tmpString += "          <th>";
				tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.augmentedYearsList.at(year).name) + "</th>";
			}
		}

		tmpString += "</tr>\n      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td colspan=\"2\"></td><td colspan=\""+QString::number(currentCount)+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";

		for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
		{
			tmpString += "        <tr>\n";
			if (hour == 0)
				tmpString += "        <th rowspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2vert(gt.rules.daysOfTheWeek[day]) + "</th>\n";
			else
				tmpString += "          <!-- span -->\n";
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"yAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
			currentCount = 0;
			for (int year = 0; year < gt.rules.augmentedYearsList.size() && currentCount < maxYears; year++)
			{
				StudentsYear sty = gt.rules.augmentedYearsList[year];
				if (!excludedNames.contains(year))
				{
					currentCount++;
					if (hour + 1 == gt.rules.nHoursPerDay)
						excludedNames << year;
					QList<int> allActivities = new QList<int>();
					allActivities.clear();
					bool isNotAvailable = true;
					for (int g = 0; g < sty.groupsList.size(); g++)
					{
						StudentsGroup stg = sty.groupsList[g];
						for (int sg = 0; sg < stg.subgroupsList.size(); sg++)
						{
							StudentsSubgroup sts = stg.subgroupsList[sg];
							int subgroup = sts.indexInInternalSubgroupsList;
							if (!(allActivities.contains(students_timetable_weekly[subgroup][day][hour])))
								allActivities << students_timetable_weekly[subgroup][day][hour];
							if (!GlobalMembersGenerate_pre.subgroupNotAvailableDayHour[subgroup][day][hour])
								isNotAvailable = false;
						}
					}
					Debug.Assert(!allActivities.isEmpty());
					bool activitiesWithSameStartingtime = addActivitiesWithSameStartingTime(ref allActivities, hour);
					if (allActivities.size() == 1 && !activitiesWithSameStartingtime) // because i am using colspan or rowspan!!!
					{
						tmpString += writeActivityStudents(htmlLevel, allActivities[0], day, hour, isNotAvailable, false, true, printActivityTags);
					}
					else
					{
						if (!detailed)
							tmpString += "          <td>" + GlobalMembersTimetable_defs.protect2(GlobalMembersTimetableexport.STRING_SEVERAL_ACTIVITIES_IN_LESS_DETAILED_TABLES) + "</td>\n";
						else
						{
							tmpString += writeActivitiesStudents(htmlLevel, allActivities, printActivityTags);
						}
					}
				}
			}
			tmpString += "        </tr>\n";
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td colspan=\"2\"></td><td colspan=\"" + QString.number(currentCount) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleAllActivitiesTimetableDaysHorizontalHtml(int htmlLevel, QString saveTime, bool printActivityTags)
	{
		QString tmpString = new QString();
		tmpString += "    <table border=\"1\">\n";
		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";
		tmpString += "      <thead>\n        <tr><td rowspan=\"2\"></td><th colspan=\"" + QString.number(gt.rules.nDaysPerWeek) + "\">" + tr("All Activities") + "</th></tr>\n";
		tmpString += "        <tr>\n          <!-- span -->\n";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"xAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + "</th>\n";
		}
		tmpString += "        </tr>\n";
		tmpString += "      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td></td><td colspan=\""+gt.rules.nDaysPerWeek+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
		{
			tmpString += "        <tr>\n";
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"yAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
			for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
			{
				if (GlobalMembersGenerate.activitiesAtTime[day][hour].isEmpty())
				{
					if (GlobalMembersGenerate_pre.breakDayHour[day][hour] && GlobalMembersTimetable_defs.PRINT_BREAK_TIME_SLOTS)
					{
						tmpString += writeBreakSlot(htmlLevel, "");
					}
					else
					{
						tmpString += writeEmpty(htmlLevel);
					}
				}
				else
				{
					tmpString += writeActivitiesStudents(htmlLevel, GlobalMembersGenerate.activitiesAtTime[day][hour], printActivityTags);
				}
			}
			tmpString += "        </tr>\n";
		}
		//workaround begin.
		tmpString += "      <tr class=\"foot\"><td></td><td colspan=\"" + QString.number(gt.rules.nDaysPerWeek) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleAllActivitiesTimetableDaysVerticalHtml(int htmlLevel, QString saveTime, bool printActivityTags)
	{
		QString tmpString = new QString();
		tmpString += "    <table border=\"1\">\n";
		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";
		tmpString += "      <thead>\n        <tr><td rowspan=\"2\"></td><th colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + tr("All Activities") + "</th></tr>\n";
		tmpString += "        <tr>\n          <!-- span -->\n";
		for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
		{
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"xAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
		}
		tmpString += "        </tr>\n";
		tmpString += "      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td></td><td colspan=\""+gt.rules.nHoursPerDay+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			tmpString += "        <tr>\n";
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"yAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + "</th>\n";
			for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
			{
				if (GlobalMembersGenerate.activitiesAtTime[day][hour].isEmpty())
				{
					if (GlobalMembersGenerate_pre.breakDayHour[day][hour] && GlobalMembersTimetable_defs.PRINT_BREAK_TIME_SLOTS)
					{
						tmpString += writeBreakSlot(htmlLevel, "");
					}
					else
					{
						tmpString += writeEmpty(htmlLevel);
					}
				}
				else
				{
					tmpString += writeActivitiesStudents(htmlLevel, GlobalMembersGenerate.activitiesAtTime[day][hour], printActivityTags);
				}
			}
			tmpString += "        </tr>\n";
		}
		//workaround begin.
		tmpString += "      <tr class=\"foot\"><td></td><td colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleAllActivitiesTimetableTimeHorizontalHtml(int htmlLevel, QString saveTime, bool printActivityTags)
	{

		QString tmpString = new QString();
		tmpString += "    <table border=\"1\">\n";
		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";
		tmpString += "      <thead>\n        <tr><td rowspan=\"2\"></td>";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
			tmpString += "<th colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + "</th>";
		tmpString += "</tr>\n";
		tmpString += "        <tr>\n          <!-- span -->\n";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
			for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
			{
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"xAxis\">";
				else
					tmpString += "          <th>";
				tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
			}
		tmpString += "        </tr>\n";
		tmpString += "      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td></td><td colspan=\""+gt.rules.nHoursPerDay*gt.rules.nDaysPerWeek+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";

		tmpString += "        <tr>\n";
		if (htmlLevel >= 2)
			tmpString += "          <th class=\"yAxis\">";
		else
			tmpString += "          <th>";
		tmpString += tr("All Activities") + "</th>\n";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
			{
				if (GlobalMembersGenerate.activitiesAtTime[day][hour].isEmpty())
				{
					if (GlobalMembersGenerate_pre.breakDayHour[day][hour] && GlobalMembersTimetable_defs.PRINT_BREAK_TIME_SLOTS)
					{
						tmpString += writeBreakSlot(htmlLevel, "");
					}
					else
					{
						tmpString += writeEmpty(htmlLevel);
					}
				}
				else
				{
					tmpString += writeActivitiesStudents(htmlLevel, GlobalMembersGenerate.activitiesAtTime[day][hour], printActivityTags);
				}
			}
		}
		tmpString += "        </tr>\n";
		//workaround begin.
		tmpString += "      <tr class=\"foot\"><td></td><td colspan=\"" + QString.number(gt.rules.nHoursPerDay * gt.rules.nDaysPerWeek) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleAllActivitiesTimetableTimeVerticalHtml(int htmlLevel, QString saveTime, bool printActivityTags)
	{
	QString tmpString = new QString();
		tmpString += "    <table border=\"1\">\n";
		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";
		tmpString += "      <thead>\n        <tr><td colspan=\"2\"></td>";
		if (htmlLevel >= 2)
			tmpString += "          <th class=\"xAxis\">";
		else
			tmpString += "          <th>";
		tmpString += tr("All Activities");
		tmpString += "</th></tr>\n      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td colspan=\"2\"></td><td>"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
			{
				tmpString += "        <tr>\n";
				if (hour == 0)
					tmpString += "        <th rowspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2vert(gt.rules.daysOfTheWeek[day]) + "</th>\n";
				else
					tmpString += "          <!-- span -->\n";
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"yAxis\">";
				else
					tmpString += "          <th>";
				tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
				if (GlobalMembersGenerate.activitiesAtTime[day][hour].isEmpty())
				{
					if (GlobalMembersGenerate_pre.breakDayHour[day][hour] && GlobalMembersTimetable_defs.PRINT_BREAK_TIME_SLOTS)
					{
						tmpString += writeBreakSlot(htmlLevel, "");
					}
					else
					{
						tmpString += writeEmpty(htmlLevel);
					}
				}
				else
				{
					tmpString += writeActivitiesStudents(htmlLevel, GlobalMembersGenerate.activitiesAtTime[day][hour], printActivityTags);
				}
				tmpString += "        </tr>\n";
			}
		}
		//workaround begin.
		tmpString += "      <tr class=\"foot\"><td colspan=\"2\"></td><td>" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleAllActivitiesTimetableTimeHorizontalDailyHtml(int htmlLevel, int day, QString saveTime, bool printActivityTags)
	{
		Debug.Assert(day >= 0);
		Debug.Assert(day < gt.rules.nDaysPerWeek);
		QString tmpString = new QString();
		tmpString += "    <table id=\"table_" + GlobalMembersTimetableexport.hashDayIDsTimetable.value(gt.rules.daysOfTheWeek[day]) + "\" border=\"1\">\n";
		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";
		tmpString += "      <thead>\n        <tr><td rowspan=\"2\"></td>";
		tmpString += "<th colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + "</th>";
		tmpString += "</tr>\n";
		tmpString += "        <tr>\n          <!-- span -->\n";
		for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
		{
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"xAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
		}
		tmpString += "        </tr>\n";
		tmpString += "      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td></td><td colspan=\""+gt.rules.nHoursPerDay+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";

		tmpString += "        <tr>\n";
		if (htmlLevel >= 2)
			tmpString += "          <th class=\"yAxis\">";
		else
			tmpString += "          <th>";
		tmpString += tr("All Activities") + "</th>\n";
		for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
		{
			if (GlobalMembersGenerate.activitiesAtTime[day][hour].isEmpty())
			{
				if (GlobalMembersGenerate_pre.breakDayHour[day][hour] && GlobalMembersTimetable_defs.PRINT_BREAK_TIME_SLOTS)
				{
					tmpString += writeBreakSlot(htmlLevel, "");
				}
				else
				{
					tmpString += writeEmpty(htmlLevel);
				}
			}
			else
			{
				tmpString += writeActivitiesStudents(htmlLevel, GlobalMembersGenerate.activitiesAtTime[day][hour], printActivityTags);
			}
		}
		tmpString += "        </tr>\n";
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td></td><td colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleAllActivitiesTimetableTimeVerticalDailyHtml(int htmlLevel, int day, QString saveTime, bool printActivityTags)
	{
		Debug.Assert(day >= 0);
		Debug.Assert(day < gt.rules.nDaysPerWeek);
		QString tmpString = new QString();
		tmpString += "    <table id=\"table_" + GlobalMembersTimetableexport.hashDayIDsTimetable.value(gt.rules.daysOfTheWeek[day]) + "\" border=\"1\">\n";
		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";
		tmpString += "      <thead>\n        <tr><td colspan=\"2\"></td>";
		if (htmlLevel >= 2)
			tmpString += "          <th class=\"xAxis\">";
		else
			tmpString += "          <th>";
		tmpString += tr("All Activities");
		tmpString += "</th></tr>\n      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td colspan=\"2\"></td><td>"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";

		for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
		{
			tmpString += "        <tr>\n";
			if (hour == 0)
				tmpString += "        <th rowspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2vert(gt.rules.daysOfTheWeek[day]) + "</th>\n";
			else
				tmpString += "          <!-- span -->\n";
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"yAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
			if (GlobalMembersGenerate.activitiesAtTime[day][hour].isEmpty())
			{
				if (GlobalMembersGenerate_pre.breakDayHour[day][hour] && GlobalMembersTimetable_defs.PRINT_BREAK_TIME_SLOTS)
				{
					tmpString += writeBreakSlot(htmlLevel, "");
				}
				else
				{
					tmpString += writeEmpty(htmlLevel);
				}
			}
			else
			{
				tmpString += writeActivitiesStudents(htmlLevel, GlobalMembersGenerate.activitiesAtTime[day][hour], printActivityTags);
			}
			tmpString += "        </tr>\n";
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td colspan=\"2\"></td><td>" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleTeachersTimetableDaysHorizontalHtml(int htmlLevel, int teacher, QString saveTime, bool printActivityTags)
	{
		Debug.Assert(teacher >= 0);
		Debug.Assert(teacher < gt.rules.nInternalTeachers);
		QString tmpString = new QString();
		QString teacher_name = gt.rules.internalTeachersList[teacher].name;
		tmpString += "    <table id=\"table_" + GlobalMembersTimetableexport.hashTeacherIDsTimetable.value(teacher_name) + "\" border=\"1\"";
		if (teacher % 2 == 0)
			tmpString += " class=\"odd_table\"";
		else
			tmpString += " class=\"even_table\"";
		tmpString += ">\n";

		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";

		tmpString += "      <thead>\n        <tr><td rowspan=\"2\"></td><th colspan=\"" + QString.number(gt.rules.nDaysPerWeek) + "\">" + GlobalMembersTimetable_defs.protect2(teacher_name) + "</th></tr>\n";
		tmpString += "        <tr>\n          <!-- span -->\n";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"xAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + "</th>\n";
		}
		tmpString += "        </tr>\n";
		tmpString += "      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td></td><td colspan=\""+gt.rules.nDaysPerWeek+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
		{
			tmpString += "        <tr>\n";
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"yAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
			for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
			{
				QList<int> allActivities = new QList<int>();
				allActivities.clear();
				allActivities << teachers_timetable_weekly[teacher][day][hour];
				bool activitiesWithSameStartingtime = addActivitiesWithSameStartingTime(ref allActivities, hour);
				if (allActivities.size() == 1 && !activitiesWithSameStartingtime) // because i am using colspan or rowspan!!!
				{
					tmpString += writeActivityTeacher(htmlLevel, teacher, day, hour, false, true, printActivityTags);
				}
				else
				{
					tmpString += writeActivitiesTeachers(htmlLevel, allActivities, printActivityTags);
				}
			}
			tmpString += "        </tr>\n";
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td></td><td colspan=\"" + QString.number(gt.rules.nDaysPerWeek) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleTeachersTimetableDaysVerticalHtml(int htmlLevel, int teacher, QString saveTime, bool printActivityTags)
	{
		Debug.Assert(teacher >= 0);
		Debug.Assert(teacher < gt.rules.nInternalTeachers);
		QString tmpString = new QString();
		QString teacher_name = gt.rules.internalTeachersList[teacher].name;
		tmpString += "    <table id=\"table_" + GlobalMembersTimetableexport.hashTeacherIDsTimetable.value(teacher_name) + "\" border=\"1\"";
		if (teacher % 2 == 0)
			tmpString += " class=\"odd_table\"";
		else
			tmpString += " class=\"even_table\"";
		tmpString += ">\n";

		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";

		tmpString += "      <thead>\n";
		tmpString += "        <tr><td rowspan=\"2\"></td><th colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2(teacher_name) + "</th></tr>\n";
		tmpString += "        <tr>\n          <!-- span -->\n";
		for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
		{
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"xAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
		}
		tmpString += "        </tr>\n";
		tmpString += "      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td></td><td colspan=\""+gt.rules.nHoursPerDay+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			tmpString += "        <tr>\n";
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"yAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + "</th>\n";
			for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
			{
				QList<int> allActivities = new QList<int>();
				allActivities.clear();
				allActivities << teachers_timetable_weekly[teacher][day][hour];
				bool activitiesWithSameStartingtime = addActivitiesWithSameStartingTime(ref allActivities, hour);
				if (allActivities.size() == 1 && !activitiesWithSameStartingtime) // because i am using colspan or rowspan!!!
				{
					tmpString += writeActivityTeacher(htmlLevel, teacher, day, hour, true, false, printActivityTags);
				}
				else
				{
					tmpString += writeActivitiesTeachers(htmlLevel, allActivities, printActivityTags);
				}
			}
			tmpString += "        </tr>\n";
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td></td><td colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleTeachersTimetableTimeHorizontalHtml(int htmlLevel, int maxTeachers, ref QSet<int> excludedNames, QString saveTime, bool printActivityTags)
	{
		QString tmpString = new QString();
		tmpString += "    <table border=\"1\">\n";
		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";

		tmpString += "      <thead>\n        <tr><td rowspan=\"2\"></td>";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
			tmpString += "<th colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + "</th>";
		tmpString += "</tr>\n";
		tmpString += "        <tr>\n          <!-- span -->\n";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
			for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
			{
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"xAxis\">";
				else
					tmpString += "          <th>";
				tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
			}
		tmpString += "        </tr>\n";
		tmpString += "      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td></td><td colspan=\""+gt.rules.nHoursPerDay*gt.rules.nDaysPerWeek+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		int currentCount = 0;
		for (int teacher = 0; teacher < gt.rules.nInternalTeachers && currentCount < maxTeachers; teacher++)
		{
			if (!excludedNames.contains(teacher))
			{
				currentCount++;
				excludedNames << teacher;
				tmpString += "        <tr>\n";
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"yAxis\">";
				else
					tmpString += "          <th>";
				tmpString += gt.rules.internalTeachersList[teacher].name + "</th>\n";
				for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
				{
					for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
					{
						QList<int> allActivities = new QList<int>();
						allActivities.clear();
						allActivities << teachers_timetable_weekly[teacher][day][hour];
						bool activitiesWithSameStartingtime = addActivitiesWithSameStartingTime(ref allActivities, hour);
						if (allActivities.size() == 1 && !activitiesWithSameStartingtime) // because i am using colspan or rowspan!!!
						{
							tmpString += writeActivityTeacher(htmlLevel, teacher, day, hour, true, false, printActivityTags);
						}
						else
						{
							tmpString += writeActivitiesTeachers(htmlLevel, allActivities, printActivityTags);
						}
					}
				}
				tmpString += "        </tr>\n";
			}
		}
		//workaround begin.
		tmpString += "      <tr class=\"foot\"><td></td><td colspan=\"" + QString.number(gt.rules.nHoursPerDay * gt.rules.nDaysPerWeek) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n    </table>\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleTeachersTimetableTimeVerticalHtml(int htmlLevel, int maxTeachers, ref QSet<int> excludedNames, QString saveTime, bool printActivityTags)
	{
	QString tmpString = new QString();
		tmpString += "    <table border=\"1\">\n";
		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";

		tmpString += "      <thead>\n        <tr><td colspan=\"2\"></td>";
		int currentCount = 0;
		for (int teacher = 0; teacher < gt.rules.nInternalTeachers && currentCount < maxTeachers; teacher++)
		{
			if (!excludedNames.contains(teacher))
			{
				currentCount++;
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"xAxis\">";
				else
					tmpString += "          <th>";
				tmpString += gt.rules.internalTeachersList[teacher].name + "</th>";
			}
		}
		tmpString += "</tr>\n      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td colspan=\"2\"></td><td colspan=\""+QString::number(currentCount)+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
			{
				tmpString += "        <tr>\n";
				if (hour == 0)
					tmpString += "        <th rowspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2vert(gt.rules.daysOfTheWeek[day]) + "</th>\n";
				else
					tmpString += "          <!-- span -->\n";
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"yAxis\">";
				else
					tmpString += "          <th>";
				tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
				currentCount = 0;
				for (int teacher = 0; teacher < gt.rules.nInternalTeachers && currentCount < maxTeachers; teacher++)
				{
					if (!excludedNames.contains(teacher))
					{
						currentCount++;
						if (day + 1 == gt.rules.nDaysPerWeek && hour + 1 == gt.rules.nHoursPerDay)
							excludedNames << teacher;
						QList<int> allActivities = new QList<int>();
						allActivities.clear();
						allActivities << teachers_timetable_weekly[teacher][day][hour];
						bool activitiesWithSameStartingtime = addActivitiesWithSameStartingTime(ref allActivities, hour);
						if (allActivities.size() == 1 && !activitiesWithSameStartingtime) // because i am using colspan or rowspan!!!
						{
							tmpString += writeActivityTeacher(htmlLevel, teacher, day, hour, false, true, printActivityTags);
						}
						else
						{
							tmpString += writeActivitiesTeachers(htmlLevel, allActivities, printActivityTags);
						}
					}
				}
				tmpString += "        </tr>\n";
			}
		}
		//workaround begin.
		tmpString += "      <tr class=\"foot\"><td colspan=\"2\"></td><td colspan=\"" + QString.number(currentCount) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n    </table>\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleTeachersTimetableTimeHorizontalDailyHtml(int htmlLevel, int day, int maxTeachers, ref QSet<int> excludedNames, QString saveTime, bool printActivityTags)
	{
		Debug.Assert(day >= 0);
		Debug.Assert(day < gt.rules.nDaysPerWeek);
		QString tmpString = new QString();
		tmpString += "    <table id=\"table_" + GlobalMembersTimetableexport.hashDayIDsTimetable.value(gt.rules.daysOfTheWeek[day]) + "\" border=\"1\">\n";
		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";

		tmpString += "      <thead>\n        <tr><td rowspan=\"2\"></td>";
		tmpString += "<th colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + "</th>";
		tmpString += "</tr>\n";
		tmpString += "        <tr>\n          <!-- span -->\n";
		for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
		{
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"xAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
		}
		tmpString += "        </tr>\n";
		tmpString += "      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td></td><td colspan=\""+gt.rules.nHoursPerDay+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		int currentCount = 0;
		for (int teacher = 0; teacher < gt.rules.nInternalTeachers && currentCount < maxTeachers; teacher++)
		{
			if (!excludedNames.contains(teacher))
			{
				currentCount++;
				excludedNames << teacher;
				tmpString += "        <tr>\n";
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"yAxis\">";
				else
					tmpString += "          <th>";
				tmpString += gt.rules.internalTeachersList[teacher].name + "</th>\n";

				for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
				{
					QList<int> allActivities = new QList<int>();
					allActivities.clear();
					allActivities << teachers_timetable_weekly[teacher][day][hour];
					bool activitiesWithSameStartingtime = addActivitiesWithSameStartingTime(ref allActivities, hour);
					if (allActivities.size() == 1 && !activitiesWithSameStartingtime) // because i am using colspan or rowspan!!!
					{
						tmpString += writeActivityTeacher(htmlLevel, teacher, day, hour, true, false, printActivityTags);
					}
					else
					{
						tmpString += writeActivitiesTeachers(htmlLevel, allActivities, printActivityTags);
					}
				}
				tmpString += "        </tr>\n";
			}
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td></td><td colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleTeachersTimetableTimeVerticalDailyHtml(int htmlLevel, int day, int maxTeachers, ref QSet<int> excludedNames, QString saveTime, bool printActivityTags)
	{
		Debug.Assert(day >= 0);
		Debug.Assert(day < gt.rules.nDaysPerWeek);
		QString tmpString = new QString();
		tmpString += "    <table id=\"table_" + GlobalMembersTimetableexport.hashDayIDsTimetable.value(gt.rules.daysOfTheWeek[day]) + "\" border=\"1\">\n";
		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";

		tmpString += "      <thead>\n        <tr><td colspan=\"2\"></td>";
		int currentCount = 0;
		for (int teacher = 0; teacher < gt.rules.nInternalTeachers && currentCount < maxTeachers; teacher++)
		{
			if (!excludedNames.contains(teacher))
			{
				currentCount++;
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"xAxis\">";
				else
					tmpString += "          <th>";
				tmpString += gt.rules.internalTeachersList[teacher].name + "</th>";
			}
		}
		tmpString += "</tr>\n      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td colspan=\"2\"></td><td colspan=\""+QString::number(currentCount)+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";

		for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
		{
			tmpString += "        <tr>\n";
			if (hour == 0)
				tmpString += "        <th rowspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2vert(gt.rules.daysOfTheWeek[day]) + "</th>\n";
			else
				tmpString += "          <!-- span -->\n";
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"yAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
			currentCount = 0;
			for (int teacher = 0; teacher < gt.rules.nInternalTeachers && currentCount < maxTeachers; teacher++)
			{
				if (!excludedNames.contains(teacher))
				{
					currentCount++;
					if (hour + 1 == gt.rules.nHoursPerDay)
						excludedNames << teacher;
					QList<int> allActivities = new QList<int>();
					allActivities.clear();
					allActivities << teachers_timetable_weekly[teacher][day][hour];
					bool activitiesWithSameStartingtime = addActivitiesWithSameStartingTime(ref allActivities, hour);
					if (allActivities.size() == 1 && !activitiesWithSameStartingtime) // because i am using colspan or rowspan!!!
					{
						tmpString += writeActivityTeacher(htmlLevel, teacher, day, hour, false, true, printActivityTags);
					}
					else
					{
						tmpString += writeActivitiesTeachers(htmlLevel, allActivities, printActivityTags);
					}
				}
			}
			tmpString += "        </tr>\n";
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td colspan=\"2\"></td><td colspan=\"" + QString.number(currentCount) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleRoomsTimetableDaysHorizontalHtml(int htmlLevel, int room, QString saveTime, bool printActivityTags)
	{
		Debug.Assert(room >= 0);
		Debug.Assert(room < gt.rules.nInternalRooms);
		QString tmpString = new QString();
		QString room_name = gt.rules.internalRoomsList[room].name;
		tmpString += "    <table id=\"table_" + GlobalMembersTimetableexport.hashRoomIDsTimetable.value(room_name) + "\" border=\"1\"";
		if (room % 2 == 0)
			tmpString += " class=\"odd_table\"";
		else
			tmpString += " class=\"even_table\"";
		tmpString += ">\n";

		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";

		tmpString += "      <thead>\n        <tr><td rowspan=\"2\"></td><th colspan=\"" + QString.number(gt.rules.nDaysPerWeek) + "\">" + GlobalMembersTimetable_defs.protect2(room_name) + "</th></tr>\n";
		tmpString += "        <tr>\n          <!-- span -->\n";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"xAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + "</th>\n";
		}
		tmpString += "        </tr>\n";
		tmpString += "      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td></td><td colspan=\""+gt.rules.nDaysPerWeek+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
		{
			tmpString += "        <tr>\n";
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"yAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
			for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
			{
				QList<int> allActivities = new QList<int>();
				allActivities.clear();
				allActivities << rooms_timetable_weekly[room][day][hour];
				bool activitiesWithSameStartingtime = addActivitiesWithSameStartingTime(ref allActivities, hour);
				if (allActivities.size() == 1 && !activitiesWithSameStartingtime) // because i am using colspan or rowspan!!!
				{
					tmpString += writeActivityRoom(htmlLevel, room, day, hour, false, true, printActivityTags);
				}
				else
				{
					tmpString += writeActivitiesRooms(htmlLevel, allActivities, printActivityTags);
				}
			}
			tmpString += "        </tr>\n";
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td></td><td colspan=\"" + QString.number(gt.rules.nDaysPerWeek) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleRoomsTimetableDaysVerticalHtml(int htmlLevel, int room, QString saveTime, bool printActivityTags)
	{
		Debug.Assert(room >= 0);
		Debug.Assert(room < gt.rules.nInternalRooms);
		QString tmpString = new QString();
		QString room_name = gt.rules.internalRoomsList[room].name;
		tmpString += "    <table id=\"table_" + GlobalMembersTimetableexport.hashRoomIDsTimetable.value(room_name) + "\" border=\"1\"";
		if (room % 2 == 0)
			tmpString += " class=\"odd_table\"";
		else
			tmpString += " class=\"even_table\"";
		tmpString += ">\n";

		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";

		tmpString += "      <thead>\n";
		tmpString += "        <tr><td rowspan=\"2\"></td><th colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2(room_name) + "</th></tr>\n";
		tmpString += "        <tr>\n          <!-- span -->\n";
		for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
		{
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"xAxis\">";
				else
					tmpString += "          <th>";
				tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
		}
		tmpString += "        </tr>\n";
		tmpString += "      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td></td><td colspan=\""+gt.rules.nHoursPerDay+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			tmpString += "        <tr>\n";
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"yAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + "</th>\n";
			for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
			{
				QList<int> allActivities = new QList<int>();
				allActivities.clear();
				allActivities << rooms_timetable_weekly[room][day][hour];
				bool activitiesWithSameStartingtime = addActivitiesWithSameStartingTime(ref allActivities, hour);
				if (allActivities.size() == 1 && !activitiesWithSameStartingtime) // because i am using colspan or rowspan!!!
				{
					tmpString += writeActivityRoom(htmlLevel, room, day, hour, true, false, printActivityTags);
				}
				else
				{
					tmpString += writeActivitiesRooms(htmlLevel, allActivities, printActivityTags);
				}
			}
			tmpString += "        </tr>\n";
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td></td><td colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleRoomsTimetableTimeHorizontalHtml(int htmlLevel, int maxRooms, ref QSet<int> excludedNames, QString saveTime, bool printActivityTags)
	{
		QString tmpString = new QString();
		tmpString += "    <table border=\"1\">\n";
		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";

		tmpString += "      <thead>\n        <tr><td rowspan=\"2\"></td>";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
			tmpString += "<th colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + "</th>";
		tmpString += "</tr>\n";
		tmpString += "        <tr>\n          <!-- span -->\n";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
			for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
			{
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"xAxis\">";
				else
					tmpString += "          <th>";
				tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
			}
		tmpString += "        </tr>\n";
		tmpString += "      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td></td><td colspan=\""+gt.rules.nHoursPerDay*gt.rules.nDaysPerWeek+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		int currentCount = 0;
		for (int room = 0; room < gt.rules.nInternalRooms && currentCount < maxRooms; room++)
		{
			if (!excludedNames.contains(room))
			{
				currentCount++;
				excludedNames << room;

				tmpString += "        <tr>\n";
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"yAxis\">";
				else
					tmpString += "          <th>";
				tmpString += gt.rules.internalRoomsList[room].name + "</th>\n";
				for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
				{
					for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
					{
						QList<int> allActivities = new QList<int>();
						allActivities.clear();
						allActivities << rooms_timetable_weekly[room][day][hour];
						bool activitiesWithSameStartingtime = addActivitiesWithSameStartingTime(ref allActivities, hour);
						if (allActivities.size() == 1 && !activitiesWithSameStartingtime) // because i am using colspan or rowspan!!!
						{
							tmpString += writeActivityRoom(htmlLevel, room, day, hour, true, false, printActivityTags);
						}
						else
						{
							tmpString += writeActivitiesRooms(htmlLevel, allActivities, printActivityTags);
						}
					}
				}
				tmpString += "        </tr>\n";
			}
		}
		//workaround begin.
		tmpString += "      <tr class=\"foot\"><td></td><td colspan=\"" + QString.number(gt.rules.nHoursPerDay * gt.rules.nDaysPerWeek) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n    </table>\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleRoomsTimetableTimeVerticalHtml(int htmlLevel, int maxRooms, ref QSet<int> excludedNames, QString saveTime, bool printActivityTags)
	{
		QString tmpString = new QString();
		tmpString += "    <table border=\"1\">\n";
		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";

		tmpString += "      <thead>\n        <tr><td colspan=\"2\"></td>";
		int currentCount = 0;
		for (int room = 0; room < gt.rules.nInternalRooms && currentCount < maxRooms; room++)
		{
			if (!excludedNames.contains(room))
			{
				currentCount++;
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"xAxis\">";
				else
					tmpString += "          <th>";
				tmpString += gt.rules.internalRoomsList[room].name + "</th>";
			}
		}
		tmpString += "</tr>\n      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td colspan=\"2\"></td><td colspan=\""+QString::number(currentCount)+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
			{
				tmpString += "        <tr>\n";
				if (hour == 0)
					tmpString += "        <th rowspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2vert(gt.rules.daysOfTheWeek[day]) + "</th>\n";
				else
					tmpString += "          <!-- span -->\n";
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"yAxis\">";
				else
					tmpString += "          <th>";
				tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
				currentCount = 0;
				for (int room = 0; room < gt.rules.nInternalRooms && currentCount < maxRooms; room++)
				{
					if (!excludedNames.contains(room))
					{
						currentCount++;
						if (day + 1 == gt.rules.nDaysPerWeek && hour + 1 == gt.rules.nHoursPerDay)
							excludedNames << room;
						QList<int> allActivities = new QList<int>();
						allActivities.clear();
						allActivities << rooms_timetable_weekly[room][day][hour];
						bool activitiesWithSameStartingtime = addActivitiesWithSameStartingTime(ref allActivities, hour);
						if (allActivities.size() == 1 && !activitiesWithSameStartingtime) // because i am using colspan or rowspan!!!
						{
							tmpString += writeActivityRoom(htmlLevel, room, day, hour, false, true, printActivityTags);
						}
						else
						{
							tmpString += writeActivitiesRooms(htmlLevel, allActivities, printActivityTags);
						}
					}
				}
				tmpString += "        </tr>\n";
			}
		}
		//workaround begin.
		tmpString += "      <tr class=\"foot\"><td colspan=\"2\"></td><td colspan=\"" + QString.number(currentCount) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n    </table>\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleRoomsTimetableTimeHorizontalDailyHtml(int htmlLevel, int day, int maxRooms, ref QSet<int> excludedNames, QString saveTime, bool printActivityTags)
	{
		Debug.Assert(day >= 0);
		Debug.Assert(day < gt.rules.nDaysPerWeek);
		QString tmpString = new QString();
		tmpString += "    <table id=\"table_" + GlobalMembersTimetableexport.hashDayIDsTimetable.value(gt.rules.daysOfTheWeek[day]) + "\" border=\"1\">\n";
		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";

		tmpString += "      <thead>\n        <tr><td rowspan=\"2\"></td>";
		tmpString += "<th colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + "</th>";
		tmpString += "</tr>\n";
		tmpString += "        <tr>\n          <!-- span -->\n";
		for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
		{
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"xAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
		}
		tmpString += "        </tr>\n";
		tmpString += "      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td></td><td colspan=\""+gt.rules.nHoursPerDay+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		int currentCount = 0;
		for (int room = 0; room < gt.rules.nInternalRooms && currentCount < maxRooms; room++)
		{
			if (!excludedNames.contains(room))
			{
				currentCount++;
				excludedNames << room;
				tmpString += "        <tr>\n";
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"yAxis\">";
				else
					tmpString += "          <th>";
				tmpString += gt.rules.internalRoomsList[room].name + "</th>\n";
				for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
				{
					QList<int> allActivities = new QList<int>();
					allActivities.clear();
					allActivities << rooms_timetable_weekly[room][day][hour];
					bool activitiesWithSameStartingtime = addActivitiesWithSameStartingTime(ref allActivities, hour);
					if (allActivities.size() == 1 && !activitiesWithSameStartingtime) // because i am using colspan or rowspan!!!
					{
						tmpString += writeActivityRoom(htmlLevel, room, day, hour, true, false, printActivityTags);
					}
					else
					{
						tmpString += writeActivitiesRooms(htmlLevel, allActivities, printActivityTags);
					}
				}
				tmpString += "        </tr>\n";
			}
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td></td><td colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleRoomsTimetableTimeVerticalDailyHtml(int htmlLevel, int day, int maxRooms, ref QSet<int> excludedNames, QString saveTime, bool printActivityTags)
	{
		Debug.Assert(day >= 0);
		Debug.Assert(day < gt.rules.nDaysPerWeek);
		QString tmpString = new QString();
		tmpString += "    <table id=\"table_" + GlobalMembersTimetableexport.hashDayIDsTimetable.value(gt.rules.daysOfTheWeek[day]) + "\" border=\"1\">\n";
		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";

		tmpString += "      <thead>\n        <tr><td colspan=\"2\"></td>";
		int currentCount = 0;
		for (int room = 0; room < gt.rules.nInternalRooms && currentCount < maxRooms; room++)
		{
			if (!excludedNames.contains(room))
			{
				currentCount++;
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"xAxis\">";
				else
					tmpString += "          <th>";
				tmpString += gt.rules.internalRoomsList[room].name + "</th>";
			}
		}
		tmpString += "</tr>\n      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td colspan=\"2\"></td><td colspan=\""+QString::number(currentCount)+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";

		for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
		{
			tmpString += "        <tr>\n";
			if (hour == 0)
				tmpString += "        <th rowspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2vert(gt.rules.daysOfTheWeek[day]) + "</th>\n";
			else
				tmpString += "          <!-- span -->\n";
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"yAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
			currentCount = 0;
			for (int room = 0; room < gt.rules.nInternalRooms && currentCount < maxRooms; room++)
			{
				if (!excludedNames.contains(room))
				{
					currentCount++;
					if (hour + 1 == gt.rules.nHoursPerDay)
						excludedNames << room;
					QList<int> allActivities = new QList<int>();
					allActivities.clear();
					allActivities << rooms_timetable_weekly[room][day][hour];
					bool activitiesWithSameStartingtime = addActivitiesWithSameStartingTime(ref allActivities, hour);
					if (allActivities.size() == 1 && !activitiesWithSameStartingtime) // because i am using colspan or rowspan!!!
					{
						tmpString += writeActivityRoom(htmlLevel, room, day, hour, false, true, printActivityTags);
					}
					else
					{
						tmpString += writeActivitiesRooms(htmlLevel, allActivities, printActivityTags);
					}
				}
			}
			tmpString += "        </tr>\n";
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td colspan=\"2\"></td><td colspan=\"" + QString.number(currentCount) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleSubjectsTimetableDaysHorizontalHtml(int htmlLevel, int subject, QString saveTime, bool printActivityTags)
	{
		Debug.Assert(subject >= 0);
		Debug.Assert(subject < gt.rules.nInternalSubjects);
		QString tmpString = new QString();
		///////by Liviu Lalescu
		for (int d = 0; d < gt.rules.nDaysPerWeek; d++)
			for (int h = 0; h < gt.rules.nHoursPerDay; h++)
				GlobalMembersTimetableexport.activitiesForCurrentSubject[d, h].clear();
		foreach (int ai, gt.rules.activitiesForSubject[subject]) if (best_solution.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
		{
				int d = best_solution.times[ai] % gt.rules.nDaysPerWeek;
				int h = best_solution.times[ai] / gt.rules.nDaysPerWeek;
				Activity act = gt.rules.internalActivitiesList[ai];
				for (int dd = 0; dd < act.duration && h + dd < gt.rules.nHoursPerDay; dd++)
					GlobalMembersTimetableexport.activitiesForCurrentSubject[d, h + dd].append(ai);
		}
		///////end Liviu Lalescu
		tmpString += "    <table id=\"table_" + GlobalMembersTimetableexport.hashSubjectIDsTimetable.value(gt.rules.internalSubjectsList[subject].name);
		tmpString += "\" border=\"1\"";
		if (subject % 2 == 0)
			tmpString += " class=\"odd_table\"";
		else
			tmpString += " class=\"even_table\"";
		tmpString += ">\n";

		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";

		tmpString += "      <thead>\n        <tr><td rowspan=\"2\"></td><th colspan=\"" + QString.number(gt.rules.nDaysPerWeek) + "\">" + GlobalMembersTimetable_defs.protect2(gt.rules.internalSubjectsList[subject].name) + "</th></tr>\n";
		tmpString += "        <tr>\n          <!-- span -->\n";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"xAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + "</th>\n";
		}
		tmpString += "        </tr>\n";
		tmpString += "      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td></td><td colspan=\""+gt.rules.nDaysPerWeek+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
		{
			tmpString += "        <tr>\n";
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"yAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
			for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
			{
				QList<int> allActivities = new QList<int>();

				allActivities = GlobalMembersTimetableexport.activitiesForCurrentSubject[day, hour];

				/*
				allActivities.clear();
				//Now get the activitiy ids. I don't run through the InternalActivitiesList, even that is faster. I run through subgroupsList, because by that the activites are sorted by that in the html-table.
				for(int subgroup=0; subgroup<gt.rules.nInternalSubgroups; subgroup++){
					if(students_timetable_weekly[subgroup][day][hour]!=UNALLOCATED_ACTIVITY){
						Activity* act=&gt.rules.internalActivitiesList[students_timetable_weekly[subgroup][day][hour]];
						if(act->subjectName==gt.rules.internalSubjectsList[subject]->name)
							if(!(allActivities.contains(students_timetable_weekly[subgroup][day][hour]))){
								allActivities+students_timetable_weekly[subgroup][day][hour];
							}
					}
				}
				//Now run through the teachers timetable, because activities without a students set are still missing.
				for(int teacher=0; teacher<gt.rules.nInternalTeachers; teacher++){
					if(teachers_timetable_weekly[teacher][day][hour]!=UNALLOCATED_ACTIVITY){
						Activity* act=&gt.rules.internalActivitiesList[teachers_timetable_weekly[teacher][day][hour]];
						if(act->subjectName==gt.rules.internalSubjectsList[subject]->name)
							if(!(allActivities.contains(teachers_timetable_weekly[teacher][day][hour]))){
								assert(act->studentsNames.isEmpty());
								allActivities+teachers_timetable_weekly[teacher][day][hour];
							}
					}
				}*/
				addActivitiesWithSameStartingTime(ref allActivities, hour);
				tmpString += writeActivitiesSubjects(htmlLevel, allActivities, printActivityTags);
			}
			tmpString += "        </tr>\n";
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td></td><td colspan=\"" + QString.number(gt.rules.nDaysPerWeek) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//by Volker Dirr	
	private static QString singleSubjectsTimetableDaysVerticalHtml(int htmlLevel, int subject, QString saveTime, bool printActivityTags)
	{
		Debug.Assert(subject >= 0);
		Debug.Assert(subject < gt.rules.nInternalSubjects);
		QString tmpString = new QString();
		///////by Liviu Lalescu
		for (int d = 0; d < gt.rules.nDaysPerWeek; d++)
			for (int h = 0; h < gt.rules.nHoursPerDay; h++)
				GlobalMembersTimetableexport.activitiesForCurrentSubject[d, h].clear();
		foreach (int ai, gt.rules.activitiesForSubject[subject]) if (best_solution.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
		{
				int d = best_solution.times[ai] % gt.rules.nDaysPerWeek;
				int h = best_solution.times[ai] / gt.rules.nDaysPerWeek;
				Activity act = gt.rules.internalActivitiesList[ai];
				for (int dd = 0; dd < act.duration && h + dd < gt.rules.nHoursPerDay; dd++)
					GlobalMembersTimetableexport.activitiesForCurrentSubject[d, h + dd].append(ai);
		}
		///////end Liviu Lalescu
		tmpString += "    <table id=\"table_" + GlobalMembersTimetableexport.hashSubjectIDsTimetable.value(gt.rules.internalSubjectsList[subject].name);
		tmpString += "\" border=\"1\"";
		if (subject % 2 == 0)
			tmpString += " class=\"odd_table\"";
		else
			tmpString += " class=\"even_table\"";
		tmpString += ">\n";

		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";

		tmpString += "      <thead>\n        <tr><td rowspan=\"2\"></td><th colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2(gt.rules.internalSubjectsList[subject].name) + "</th></tr>\n";
		tmpString += "        <tr>\n          <!-- span -->\n";
		for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
		{
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"xAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
		}
		tmpString += "        </tr>\n";
		tmpString += "      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td></td><td colspan=\""+gt.rules.nHoursPerDay+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			tmpString += "        <tr>\n";
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"yAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + "</th>\n";
			for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
			{
				QList<int> allActivities = new QList<int>();

				allActivities = GlobalMembersTimetableexport.activitiesForCurrentSubject[day, hour];

				/*
				allActivities.clear();
				//Now get the activitiy ids. I don't run through the InternalActivitiesList, even that is faster. I run through subgroupsList, because by that the activites are sorted by that in the html-table.
				for(int subgroup=0; subgroup<gt.rules.nInternalSubgroups; subgroup++){
					if(students_timetable_weekly[subgroup][day][hour]!=UNALLOCATED_ACTIVITY){
						Activity* act=&gt.rules.internalActivitiesList[students_timetable_weekly[subgroup][day][hour]];
						if(act->subjectName==gt.rules.internalSubjectsList[subject]->name)
							if(!(allActivities.contains(students_timetable_weekly[subgroup][day][hour]))){
								allActivities+students_timetable_weekly[subgroup][day][hour];
							}
					}
				}
				//Now run through the teachers timetable, because activities without a students set are still missing.
				for(int teacher=0; teacher<gt.rules.nInternalTeachers; teacher++){
					if(teachers_timetable_weekly[teacher][day][hour]!=UNALLOCATED_ACTIVITY){
						Activity* act=&gt.rules.internalActivitiesList[teachers_timetable_weekly[teacher][day][hour]];
						if(act->subjectName==gt.rules.internalSubjectsList[subject]->name)
							if(!(allActivities.contains(teachers_timetable_weekly[teacher][day][hour]))){
								assert(act->studentsNames.isEmpty());
								allActivities+teachers_timetable_weekly[teacher][day][hour];
							}
					}
				}
				*/
				addActivitiesWithSameStartingTime(ref allActivities, hour);
				tmpString += writeActivitiesSubjects(htmlLevel, allActivities, printActivityTags);
			}
		tmpString += "        </tr>\n";
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td></td><td colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//by Volker Dirr	
	private static QString singleSubjectsTimetableTimeHorizontalHtml(int htmlLevel, int maxSubjects, ref QSet<int> excludedNames, QString saveTime, bool printActivityTags)
	{
		QString tmpString = new QString();
		tmpString += "    <table id=\"table\" border=\"1\">\n";

		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";

		tmpString += "      <thead>\n        <tr><td rowspan=\"2\"></td>";

		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
			tmpString += "<th colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + "</th>";
		tmpString += "</tr>\n";
		tmpString += "        <tr>\n          <!-- span -->\n";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
			for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
			{
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"xAxis\">";
				else
					tmpString += "          <th>";
				tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
			}
		tmpString += "        </tr>\n";
		tmpString += "      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td></td><td colspan=\""+gt.rules.nHoursPerDay*gt.rules.nDaysPerWeek+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		int currentCount = 0;
		for (int subject = 0; subject < gt.rules.nInternalSubjects && currentCount < maxSubjects; subject++)
		{
			if (!excludedNames.contains(subject))
			{
				currentCount++;
				excludedNames << subject;
				tmpString += "        <tr>\n";
				if (htmlLevel >= 2)
					tmpString += "        <th class=\"yAxis\">" + GlobalMembersTimetable_defs.protect2(gt.rules.internalSubjectsList[subject].name) + "</th>\n";
				else
					tmpString += "        <th>" + GlobalMembersTimetable_defs.protect2(gt.rules.internalSubjectsList[subject].name) + "</th>\n";

				///////by Liviu Lalescu
				for (int d = 0; d < gt.rules.nDaysPerWeek; d++)
					for (int h = 0; h < gt.rules.nHoursPerDay; h++)
						GlobalMembersTimetableexport.activitiesForCurrentSubject[d, h].clear();
				foreach (int ai, gt.rules.activitiesForSubject[subject]) if (best_solution.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				{
						int d = best_solution.times[ai] % gt.rules.nDaysPerWeek;
						int h = best_solution.times[ai] / gt.rules.nDaysPerWeek;
						Activity act = gt.rules.internalActivitiesList[ai];
						for (int dd = 0; dd < act.duration && h + dd < gt.rules.nHoursPerDay; dd++)
							GlobalMembersTimetableexport.activitiesForCurrentSubject[d, h + dd].append(ai);
				}
				///////end Liviu Lalescu

				for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
				{
					for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
					{
						QList<int> allActivities = new QList<int>();

						allActivities = GlobalMembersTimetableexport.activitiesForCurrentSubject[day, hour];


						/*allActivities.clear();
						//Now get the activitiy ids. I don't run through the InternalActivitiesList, even that is faster. I run through subgroupsList, because by that the activites are sorted by that in the html-table.
						for(int subgroup=0; subgroup<gt.rules.nInternalSubgroups; subgroup++){
							if(students_timetable_weekly[subgroup][day][hour]!=UNALLOCATED_ACTIVITY){
								Activity* act=&gt.rules.internalActivitiesList[students_timetable_weekly[subgroup][day][hour]];
								if(act->subjectName==gt.rules.internalSubjectsList[subject]->name)
									if(!(allActivities.contains(students_timetable_weekly[subgroup][day][hour]))){
										allActivities+students_timetable_weekly[subgroup][day][hour];
									}
							}
						}
						//Now run through the teachers timetable, because activities without a students set are still missing.
						for(int teacher=0; teacher<gt.rules.nInternalTeachers; teacher++){
							if(teachers_timetable_weekly[teacher][day][hour]!=UNALLOCATED_ACTIVITY){
								Activity* act=&gt.rules.internalActivitiesList[teachers_timetable_weekly[teacher][day][hour]];
								if(act->subjectName==gt.rules.internalSubjectsList[subject]->name)
									if(!(allActivities.contains(teachers_timetable_weekly[teacher][day][hour]))){
										assert(act->studentsNames.isEmpty());
										allActivities+teachers_timetable_weekly[teacher][day][hour];
									}
							}
						}*/
						addActivitiesWithSameStartingTime(ref allActivities, hour);
						tmpString += writeActivitiesSubjects(htmlLevel, allActivities, printActivityTags);
					}
				}
				tmpString += "        </tr>\n";
			}
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td></td><td colspan=\"" + QString.number(gt.rules.nHoursPerDay * gt.rules.nDaysPerWeek) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n    </table>\n";
		return tmpString;
	}

	//by Volker Dirr	
	private static QString singleSubjectsTimetableTimeVerticalHtml(int htmlLevel, int maxSubjects, ref QSet<int> excludedNames, QString saveTime, bool printActivityTags)
	{
		QString tmpString = new QString();
		tmpString += "    <table id=\"table\" border=\"1\">\n";

		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";

		tmpString += "      <thead>\n        <tr><td colspan=\"2\"></td>";
		int currentCount = 0;
		for (int subject = 0; subject < gt.rules.nInternalSubjects && currentCount < maxSubjects; subject++)
		{
			if (!excludedNames.contains(subject))
			{
				currentCount++;
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"xAxis\">";
				else
					tmpString += "          <th>";
				tmpString += gt.rules.internalSubjectsList[subject].name + "</th>";
			}
		}

		tmpString += "</tr>\n      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td colspan=\"2\"></td><td colspan=\""+QString::number(currentCount)+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";

		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
			{
				tmpString += "        <tr>\n";
				if (hour == 0)
					tmpString += "        <th rowspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2vert(gt.rules.daysOfTheWeek[day]) + "</th>\n";
				else
					tmpString += "          <!-- span -->\n";
				if (htmlLevel >= 2)
					tmpString += "          <th class=\"yAxis\">";
				else
					tmpString += "          <th>";
				tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";

				currentCount = 0;
				for (int subject = 0; subject < gt.rules.nInternalSubjects && currentCount < maxSubjects; subject++)
				{
					currentCount++;
					if (!excludedNames.contains(subject))
					{
						if (day + 1 == gt.rules.nDaysPerWeek && hour + 1 == gt.rules.nHoursPerDay)
							excludedNames << subject;
						QList<int> allActivities = new QList<int>();
						allActivities.clear();

						foreach (int ai, gt.rules.activitiesForSubject[subject]) if (GlobalMembersGenerate.activitiesAtTime[day][hour].contains(ai))
						{
								Debug.Assert(!allActivities.contains(ai));
								allActivities.append(ai);
						}

						/* //Now get the activitiy ids. I don't run through the InternalActivitiesList, even that is faster. I run through subgroupsList, because by that the activites are sorted by that in the html-table.
						for(int subgroup=0; subgroup<gt.rules.nInternalSubgroups; subgroup++){
							if(students_timetable_weekly[subgroup][day][hour]!=UNALLOCATED_ACTIVITY){
								Activity* act=&gt.rules.internalActivitiesList[students_timetable_weekly[subgroup][day][hour]];
								if(act->subjectName==gt.rules.internalSubjectsList[subject]->name)
									if(!(allActivities.contains(students_timetable_weekly[subgroup][day][hour]))){
										allActivities+students_timetable_weekly[subgroup][day][hour];
									}
							}
						}
						//Now run through the teachers timetable, because activities without a students set are still missing.
						for(int teacher=0; teacher<gt.rules.nInternalTeachers; teacher++){
							if(teachers_timetable_weekly[teacher][day][hour]!=UNALLOCATED_ACTIVITY){
								Activity* act=&gt.rules.internalActivitiesList[teachers_timetable_weekly[teacher][day][hour]];
								if(act->subjectName==gt.rules.internalSubjectsList[subject]->name)
									if(!(allActivities.contains(teachers_timetable_weekly[teacher][day][hour]))){
										assert(act->studentsNames.isEmpty());
										allActivities+teachers_timetable_weekly[teacher][day][hour];
									}
							}
						}*/
						addActivitiesWithSameStartingTime(ref allActivities, hour);
						tmpString += writeActivitiesSubjects(htmlLevel, allActivities, printActivityTags);
					}
				}
				tmpString += "        </tr>\n";
			}
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td colspan=\"2\"></td><td colspan=\"" + QString.number(currentCount) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n    </table>\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleSubjectsTimetableTimeHorizontalDailyHtml(int htmlLevel, int day, int maxSubjects, ref QSet<int> excludedNames, QString saveTime, bool printActivityTags)
	{
		Debug.Assert(day >= 0);
		Debug.Assert(day < gt.rules.nDaysPerWeek);
		QString tmpString = new QString();
		tmpString += "    <table id=\"table_" + GlobalMembersTimetableexport.hashDayIDsTimetable.value(gt.rules.daysOfTheWeek[day]) + "\" border=\"1\">\n";
		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";
		tmpString += "      <thead>\n        <tr><td rowspan=\"2\"></td>";

		tmpString += "<th colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + "</th>";
		tmpString += "</tr>\n";
		tmpString += "        <tr>\n          <!-- span -->\n";
		for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
		{
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"xAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
		}
		tmpString += "        </tr>\n";
		tmpString += "      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td></td><td colspan=\""+gt.rules.nHoursPerDay+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		int currentCount = 0;
		for (int subject = 0; subject < gt.rules.nInternalSubjects && currentCount < maxSubjects; subject++)
		{
			currentCount++;
			if (!excludedNames.contains(subject))
			{
				excludedNames << subject;
				tmpString += "        <tr>\n";
				if (htmlLevel >= 2)
					tmpString += "        <th class=\"yAxis\">" + GlobalMembersTimetable_defs.protect2(gt.rules.internalSubjectsList[subject].name) + "</th>\n";
				else
					tmpString += "        <th>" + GlobalMembersTimetable_defs.protect2(gt.rules.internalSubjectsList[subject].name) + "</th>\n";

				///////by Liviu Lalescu
				for (int d = 0; d < gt.rules.nDaysPerWeek; d++)
					for (int h = 0; h < gt.rules.nHoursPerDay; h++)
						GlobalMembersTimetableexport.activitiesForCurrentSubject[d, h].clear();
				foreach (int ai, gt.rules.activitiesForSubject[subject]) if (best_solution.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				{
						int d = best_solution.times[ai] % gt.rules.nDaysPerWeek;
						int h = best_solution.times[ai] / gt.rules.nDaysPerWeek;
						Activity act = gt.rules.internalActivitiesList[ai];
						for (int dd = 0; dd < act.duration && h + dd < gt.rules.nHoursPerDay; dd++)
							GlobalMembersTimetableexport.activitiesForCurrentSubject[d, h + dd].append(ai);
				}
				///////end Liviu Lalescu

				for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
				{
					QList<int> allActivities = new QList<int>();

					allActivities = GlobalMembersTimetableexport.activitiesForCurrentSubject[day, hour];


					/*allActivities.clear();
					//Now get the activitiy ids. I don't run through the InternalActivitiesList, even that is faster. I run through subgroupsList, because by that the activites are sorted by that in the html-table.
					for(int subgroup=0; subgroup<gt.rules.nInternalSubgroups; subgroup++){
						if(students_timetable_weekly[subgroup][day][hour]!=UNALLOCATED_ACTIVITY){
							Activity* act=&gt.rules.internalActivitiesList[students_timetable_weekly[subgroup][day][hour]];
							if(act->subjectName==gt.rules.internalSubjectsList[subject]->name)
								if(!(allActivities.contains(students_timetable_weekly[subgroup][day][hour]))){
									allActivities+students_timetable_weekly[subgroup][day][hour];
								}
						}
					}
					//Now run through the teachers timetable, because activities without a students set are still missing.
					for(int teacher=0; teacher<gt.rules.nInternalTeachers; teacher++){
						if(teachers_timetable_weekly[teacher][day][hour]!=UNALLOCATED_ACTIVITY){
							Activity* act=&gt.rules.internalActivitiesList[teachers_timetable_weekly[teacher][day][hour]];
							if(act->subjectName==gt.rules.internalSubjectsList[subject]->name)
								if(!(allActivities.contains(teachers_timetable_weekly[teacher][day][hour]))){
									assert(act->studentsNames.isEmpty());
									allActivities+teachers_timetable_weekly[teacher][day][hour];
								}
						}
					}*/
					addActivitiesWithSameStartingTime(ref allActivities, hour);
					tmpString += writeActivitiesSubjects(htmlLevel, allActivities, printActivityTags);
				}
				tmpString += "        </tr>\n";
			}
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td></td><td colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleSubjectsTimetableTimeVerticalDailyHtml(int htmlLevel, int day, int maxSubjects, ref QSet<int> excludedNames, QString saveTime, bool printActivityTags)
	{
		Debug.Assert(day >= 0);
		Debug.Assert(day < gt.rules.nDaysPerWeek);
		QString tmpString = new QString();
		tmpString += "    <table id=\"table_" + GlobalMembersTimetableexport.hashDayIDsTimetable.value(gt.rules.daysOfTheWeek[day]) + "\" border=\"1\">\n";
		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";
		tmpString += "      <thead>\n        <tr><td colspan=\"2\"></td>";
		int currentCount = 0;
		for (int subject = 0; subject < gt.rules.nInternalSubjects && currentCount < maxSubjects; subject++)
		{
			if (!excludedNames.contains(subject))
			{
				currentCount++;

				if (htmlLevel >= 2)
					tmpString += "          <th class=\"xAxis\">";
				else
					tmpString += "          <th>";
				tmpString += gt.rules.internalSubjectsList[subject].name + "</th>";
			}
		}
		tmpString += "</tr>\n      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td colspan=\"2\"></td><td colspan=\""+QString::number(currentCount)+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
		{
			tmpString += "        <tr>\n";
			if (hour == 0)
				tmpString += "        <th rowspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + GlobalMembersTimetable_defs.protect2vert(gt.rules.daysOfTheWeek[day]) + "</th>\n";
			else
				tmpString += "          <!-- span -->\n";
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"yAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";

			currentCount = 0;
			for (int subject = 0; subject < gt.rules.nInternalSubjects && currentCount < maxSubjects; subject++)
			{
				currentCount++;
				if (!excludedNames.contains(subject))
				{
					if (hour + 1 == gt.rules.nHoursPerDay)
						excludedNames << subject;
					QList<int> allActivities = new QList<int>();
					allActivities.clear();

					foreach (int ai, gt.rules.activitiesForSubject[subject]) if (GlobalMembersGenerate.activitiesAtTime[day][hour].contains(ai))
					{
							Debug.Assert(!allActivities.contains(ai));
							allActivities.append(ai);
					}

					/*//Now get the activitiy ids. I don't run through the InternalActivitiesList, even that is faster. I run through subgroupsList, because by that the activites are sorted by that in the html-table.
					for(int subgroup=0; subgroup<gt.rules.nInternalSubgroups; subgroup++){
						if(students_timetable_weekly[subgroup][day][hour]!=UNALLOCATED_ACTIVITY){
							Activity* act=&gt.rules.internalActivitiesList[students_timetable_weekly[subgroup][day][hour]];
							if(act->subjectName==gt.rules.internalSubjectsList[subject]->name)
								if(!(allActivities.contains(students_timetable_weekly[subgroup][day][hour]))){
									allActivities+students_timetable_weekly[subgroup][day][hour];
								}
						}
					}
					//Now run through the teachers timetable, because activities without a students set are still missing.
					for(int teacher=0; teacher<gt.rules.nInternalTeachers; teacher++){
						if(teachers_timetable_weekly[teacher][day][hour]!=UNALLOCATED_ACTIVITY){
							Activity* act=&gt.rules.internalActivitiesList[teachers_timetable_weekly[teacher][day][hour]];
							if(act->subjectName==gt.rules.internalSubjectsList[subject]->name)
								if(!(allActivities.contains(teachers_timetable_weekly[teacher][day][hour]))){
									assert(act->studentsNames.isEmpty());
									allActivities+teachers_timetable_weekly[teacher][day][hour];
								}
						}
					}*/
					addActivitiesWithSameStartingTime(ref allActivities, hour);
					tmpString += writeActivitiesSubjects(htmlLevel, allActivities, printActivityTags);
				}
			}
			tmpString += "        </tr>\n";
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td colspan=\"2\"></td><td colspan=\"" + QString.number(currentCount) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleTeachersFreePeriodsTimetableDaysHorizontalHtml(int htmlLevel, QString saveTime, bool detailed)
	{
		QString tmpString = new QString();
		if (detailed)
			tmpString += "    <table id=\"table_DETAILED\" border=\"1\">\n";
		else
			tmpString += "    <table id=\"table_LESS_DETAILED\" border=\"1\">\n";

		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";

		if (detailed)
			tmpString += "      <thead>\n        <tr><td rowspan=\"2\"></td><th colspan=\"" + QString.number(gt.rules.nDaysPerWeek) + "\">" + TimetableExport.tr("Teachers' Free Periods") + " (" + tr("Detailed") + ")</th></tr>\n";
		else
			tmpString += "      <thead>\n        <tr><td rowspan=\"2\"></td><th colspan=\"" + QString.number(gt.rules.nDaysPerWeek) + "\">" + TimetableExport.tr("Teachers' Free Periods") + " (" + tr("Less detailed") + ")</th></tr>\n";

		tmpString += "        <tr>\n          <!-- span -->\n";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"xAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + "</th>\n";
		}
		tmpString += "        </tr>\n";
		tmpString += "      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td></td><td colspan=\""+gt.rules.nDaysPerWeek+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
		{
			tmpString += "        <tr>\n";
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"yAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
			for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
			{
				bool empty_slot;
				empty_slot = true;
				for (int tfp = 0; tfp < GlobalMembersTimetable_defs.TEACHERS_FREE_PERIODS_N_CATEGORIES; tfp++)
				{
					if (teachers_free_periods_timetable_weekly[tfp][day][hour].size() > 0)
					{
						empty_slot = false;
					}
					if (!detailed && tfp >= GlobalMembersTimetable_defs.TEACHER_MUST_COME_EARLIER)
						break;
				}
				if (!empty_slot)
					tmpString += "          <td>";
				for (int tfp = 0; tfp < GlobalMembersTimetable_defs.TEACHERS_FREE_PERIODS_N_CATEGORIES; tfp++)
				{
					if (teachers_free_periods_timetable_weekly[tfp][day][hour].size() > 0)
					{
						if (htmlLevel >= 2)
							tmpString += "<div class=\"DESCRIPTION\">";
						switch (tfp)
						{
							case GlobalMembersTimetable_defs.TEACHER_HAS_SINGLE_GAP :
								tmpString += TimetableExport.tr("Single gap");
								break;
							case GlobalMembersTimetable_defs.TEACHER_HAS_BORDER_GAP :
								tmpString += TimetableExport.tr("Border gap");
								break;
							case GlobalMembersTimetable_defs.TEACHER_HAS_BIG_GAP :
								tmpString += TimetableExport.tr("Big gap");
								break;
							case GlobalMembersTimetable_defs.TEACHER_MUST_COME_EARLIER :
								tmpString += TimetableExport.tr("Must come earlier");
								break;
							case GlobalMembersTimetable_defs.TEACHER_MUST_STAY_LONGER :
								tmpString += TimetableExport.tr("Must stay longer");
								break;
							case GlobalMembersTimetable_defs.TEACHER_MUST_COME_MUCH_EARLIER :
								tmpString += TimetableExport.tr("Must come much earlier");
								break;
							case GlobalMembersTimetable_defs.TEACHER_MUST_STAY_MUCH_LONGER :
								tmpString += TimetableExport.tr("Must stay much longer");
								break;
							case GlobalMembersTimetable_defs.TEACHER_HAS_A_FREE_DAY :
								tmpString += TimetableExport.tr("Free day");
								break;
							case GlobalMembersTimetable_defs.TEACHER_IS_NOT_AVAILABLE :
								tmpString += TimetableExport.tr("Not available");
								break;
							default:
								Debug.Assert(0 == 1);
								break;
						}
						if (htmlLevel >= 2)
							tmpString += ":</div>";
						else
							tmpString += ":<br />";
						if (htmlLevel >= 3)
							switch (tfp)
							{
								case GlobalMembersTimetable_defs.TEACHER_HAS_SINGLE_GAP :
									tmpString += "<div class=\"TEACHER_HAS_SINGLE_GAP\">";
									break;
								case GlobalMembersTimetable_defs.TEACHER_HAS_BORDER_GAP :
									tmpString += "<div class=\"TEACHER_HAS_BORDER_GAP\">";
									break;
								case GlobalMembersTimetable_defs.TEACHER_HAS_BIG_GAP :
									tmpString += "<div class=\"TEACHER_HAS_BIG_GAP\">";
									break;
								case GlobalMembersTimetable_defs.TEACHER_MUST_COME_EARLIER :
									tmpString += "<div class=\"TEACHER_MUST_COME_EARLIER\">";
									break;
								case GlobalMembersTimetable_defs.TEACHER_MUST_STAY_LONGER :
									tmpString += "<div class=\"TEACHER_MUST_STAY_LONGER\">";
									break;
								case GlobalMembersTimetable_defs.TEACHER_MUST_COME_MUCH_EARLIER :
									tmpString += "<div class=\"TEACHER_MUST_COME_MUCH_EARLIER\">";
									break;
								case GlobalMembersTimetable_defs.TEACHER_MUST_STAY_MUCH_LONGER :
									tmpString += "<div class=\"TEACHER_MUST_STAY_MUCH_LONGER\">";
									break;
								case GlobalMembersTimetable_defs.TEACHER_HAS_A_FREE_DAY :
									tmpString += "<div class=\"TEACHER_HAS_A_FREE_DAY\">";
									break;
								case GlobalMembersTimetable_defs.TEACHER_IS_NOT_AVAILABLE :
									tmpString += "<div class=\"TEACHER_IS_NOT_AVAILABLE\">";
									break;
								default:
									Debug.Assert(0 == 1);
									break;
							}
						for (int t = 0; t < teachers_free_periods_timetable_weekly[tfp][day][hour].size(); t++)
						{
							QString teacher_name = gt.rules.internalTeachersList[teachers_free_periods_timetable_weekly[tfp][day][hour].at(t)].name;
								switch (htmlLevel)
								{
									case 4 :
										tmpString += "<span class=\"t_" + GlobalMembersTimetableexport.hashTeacherIDsTimetable.value(teacher_name) + "\">" + GlobalMembersTimetable_defs.protect2(teacher_name) + "</span>";
										break;
									case 5 :
										;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
									case 6 :
										tmpString += "<span class=\"t_" + GlobalMembersTimetableexport.hashTeacherIDsTimetable.value(teacher_name) + "\" onmouseover=\"highlight('t_" + GlobalMembersTimetableexport.hashTeacherIDsTimetable.value(teacher_name) + "')\">" + GlobalMembersTimetable_defs.protect2(teacher_name) + "</span>";
										break;
									default:
										tmpString += GlobalMembersTimetable_defs.protect2(teacher_name);
										break;
								}
							tmpString += "<br />";
						}
						if (htmlLevel >= 3)
							tmpString += "</div>";
					}
					if (!detailed && tfp >= GlobalMembersTimetable_defs.TEACHER_MUST_COME_EARLIER)
						break;
				}
				if (!empty_slot)
				{
					tmpString += "</td>\n";
				}
				else
				{
					tmpString += writeEmpty(htmlLevel);
				}
			}
			tmpString += "        </tr>\n";
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td></td><td colspan=\"" + QString.number(gt.rules.nDaysPerWeek) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//by Volker Dirr
	private static QString singleTeachersFreePeriodsTimetableDaysVerticalHtml(int htmlLevel, QString saveTime, bool detailed)
	{
		QString tmpString = new QString();
		if (detailed)
			tmpString += "    <table id=\"table_DETAILED\" border=\"1\">\n";
		else
			tmpString += "    <table id=\"table_LESS_DETAILED\" border=\"1\">\n";

		tmpString += "      <caption>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</caption>\n";

		if (detailed)
			tmpString += "      <thead>\n        <tr><td rowspan=\"2\"></td><th colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + TimetableExport.tr("Teachers' Free Periods") + " (" + tr("Detailed") + ")</th></tr>\n";
		else
			tmpString += "      <thead>\n        <tr><td rowspan=\"2\"></td><th colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + TimetableExport.tr("Teachers' Free Periods") + " (" + tr("Less detailed") + ")</th></tr>\n";

		tmpString += "        <tr>\n          <!-- span -->\n";
		for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
		{
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"xAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.hoursOfTheDay[hour]) + "</th>\n";
		}
		tmpString += "        </tr>\n";
		tmpString += "      </thead>\n";
		/*workaround
		tmpString+="      <tfoot><tr><td></td><td colspan=\""+gt.rules.nHoursPerDay+"\">"+TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)+"</td></tr></tfoot>\n";
		*/
		tmpString += "      <tbody>\n";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			tmpString += "        <tr>\n";
			if (htmlLevel >= 2)
				tmpString += "          <th class=\"yAxis\">";
			else
				tmpString += "          <th>";
			tmpString += GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + "</th>\n";
			for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
			{
				bool empty_slot;
				empty_slot = true;
				for (int tfp = 0; tfp < GlobalMembersTimetable_defs.TEACHERS_FREE_PERIODS_N_CATEGORIES; tfp++)
				{
					if (teachers_free_periods_timetable_weekly[tfp][day][hour].size() > 0)
					{
						empty_slot = false;
					}
					if (!detailed && tfp >= GlobalMembersTimetable_defs.TEACHER_MUST_COME_EARLIER)
						break;
				}
				if (!empty_slot)
					tmpString += "          <td>";
				for (int tfp = 0; tfp < GlobalMembersTimetable_defs.TEACHERS_FREE_PERIODS_N_CATEGORIES; tfp++)
				{
					if (teachers_free_periods_timetable_weekly[tfp][day][hour].size() > 0)
					{
						if (htmlLevel >= 2)
							tmpString += "<div class=\"DESCRIPTION\">";
						switch (tfp)
						{
							case GlobalMembersTimetable_defs.TEACHER_HAS_SINGLE_GAP :
								tmpString += TimetableExport.tr("Single gap");
								break;
							case GlobalMembersTimetable_defs.TEACHER_HAS_BORDER_GAP :
								tmpString += TimetableExport.tr("Border gap");
								break;
							case GlobalMembersTimetable_defs.TEACHER_HAS_BIG_GAP :
								tmpString += TimetableExport.tr("Big gap");
								break;
							case GlobalMembersTimetable_defs.TEACHER_MUST_COME_EARLIER :
								tmpString += TimetableExport.tr("Must come earlier");
								break;
							case GlobalMembersTimetable_defs.TEACHER_MUST_STAY_LONGER :
								tmpString += TimetableExport.tr("Must stay longer");
								break;
							case GlobalMembersTimetable_defs.TEACHER_MUST_COME_MUCH_EARLIER :
								tmpString += TimetableExport.tr("Must come much earlier");
								break;
							case GlobalMembersTimetable_defs.TEACHER_MUST_STAY_MUCH_LONGER :
								tmpString += TimetableExport.tr("Must stay much longer");
								break;
							case GlobalMembersTimetable_defs.TEACHER_HAS_A_FREE_DAY :
								tmpString += TimetableExport.tr("Free day");
								break;
							case GlobalMembersTimetable_defs.TEACHER_IS_NOT_AVAILABLE :
								tmpString += TimetableExport.tr("Not available");
								break;
							default:
								Debug.Assert(0 == 1);
								break;
						}
						if (htmlLevel >= 2)
							tmpString += ":</div>";
						else
							tmpString += ":<br />";
						if (htmlLevel >= 3)
							switch (tfp)
							{
								case GlobalMembersTimetable_defs.TEACHER_HAS_SINGLE_GAP :
									tmpString += "<div class=\"TEACHER_HAS_SINGLE_GAP\">";
									break;
								case GlobalMembersTimetable_defs.TEACHER_HAS_BORDER_GAP :
									tmpString += "<div class=\"TEACHER_HAS_BORDER_GAP\">";
									break;
								case GlobalMembersTimetable_defs.TEACHER_HAS_BIG_GAP :
									tmpString += "<div class=\"TEACHER_HAS_BIG_GAP\">";
									break;
								case GlobalMembersTimetable_defs.TEACHER_MUST_COME_EARLIER :
									tmpString += "<div class=\"TEACHER_MUST_COME_EARLIER\">";
									break;
								case GlobalMembersTimetable_defs.TEACHER_MUST_STAY_LONGER :
									tmpString += "<div class=\"TEACHER_MUST_STAY_LONGER\">";
									break;
								case GlobalMembersTimetable_defs.TEACHER_MUST_COME_MUCH_EARLIER :
									tmpString += "<div class=\"TEACHER_MUST_COME_MUCH_EARLIER\">";
									break;
								case GlobalMembersTimetable_defs.TEACHER_MUST_STAY_MUCH_LONGER :
									tmpString += "<div class=\"TEACHER_MUST_STAY_MUCH_LONGER\">";
									break;
								case GlobalMembersTimetable_defs.TEACHER_HAS_A_FREE_DAY :
									tmpString += "<div class=\"TEACHER_HAS_A_FREE_DAY\">";
									break;
								case GlobalMembersTimetable_defs.TEACHER_IS_NOT_AVAILABLE :
									tmpString += "<div class=\"TEACHER_IS_NOT_AVAILABLE\">";
									break;
								default:
									Debug.Assert(0 == 1);
									break;
							}
						for (int t = 0; t < teachers_free_periods_timetable_weekly[tfp][day][hour].size(); t++)
						{
							QString teacher_name = gt.rules.internalTeachersList[teachers_free_periods_timetable_weekly[tfp][day][hour].at(t)].name;
								switch (htmlLevel)
								{
									case 4 :
										tmpString += "<span class=\"t_" + GlobalMembersTimetableexport.hashTeacherIDsTimetable.value(teacher_name) + "\">" + GlobalMembersTimetable_defs.protect2(teacher_name) + "</span>";
										break;
									case 5 :
										;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
									case 6 :
										tmpString += "<span class=\"t_" + GlobalMembersTimetableexport.hashTeacherIDsTimetable.value(teacher_name) + "\" onmouseover=\"highlight('t_" + GlobalMembersTimetableexport.hashTeacherIDsTimetable.value(teacher_name) + "')\">" + GlobalMembersTimetable_defs.protect2(teacher_name) + "</span>";
										break;
									default:
										tmpString += GlobalMembersTimetable_defs.protect2(teacher_name);
										break;
								}
							tmpString += "<br />";
						}
						if (htmlLevel >= 3)
							tmpString += "</div>";
					}
					if (!detailed && tfp >= GlobalMembersTimetable_defs.TEACHER_MUST_COME_EARLIER)
						break;
				}
				if (!empty_slot)
				{
					tmpString += "</td>\n";
				}
				else
					tmpString += writeEmpty(htmlLevel);
			}
			tmpString += "        </tr>\n";
		}
		//workaround begin.
		tmpString += "        <tr class=\"foot\"><td></td><td colspan=\"" + QString.number(gt.rules.nHoursPerDay) + "\">" + TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) + "</td></tr>\n";
		//workaround end.
		tmpString += "      </tbody>\n";
		tmpString += "    </table>\n\n";
		return tmpString;
	}

	//this function must be called before export html files, because it compute the IDs

	//------------------------------------------------------------------
	//------------------------------------------------------------------

	private static void computeHashForIDsTimetable()
	{
	// by Volker Dirr

	//TODO if an use a relational data base this is unneded, because we can use the primary key id of the database
	//This is very similar to statistics compute hash. so always check it if you change something here!

	/*	QSet<QString> usedStudents;
		for(int i=0; i<gt.rules.nInternalActivities; i++){
			foreach(QString st, gt.rules.internalActivitiesList[i].studentsNames){
				if(!usedStudents.contains(st))
					usedStudents<<st;
			}
		}*/
		GlobalMembersTimetableexport.hashStudentIDsTimetable.clear();
		int cnt = 1;
		for (int i = 0; i < gt.rules.augmentedYearsList.size(); i++)
		{
			StudentsYear sty = gt.rules.augmentedYearsList[i];
			//if(usedStudents.contains(sty->name)){
			if (!GlobalMembersTimetableexport.hashStudentIDsTimetable.contains(sty.name))
			{
				GlobalMembersTimetableexport.hashStudentIDsTimetable.insert(sty.name, CustomFETString.number(cnt));
				cnt++;
			}
			//}
			for (int j = 0; j < sty.groupsList.size(); j++)
			{
				StudentsGroup stg = sty.groupsList[j];
			//	if(usedStudents.contains(stg->name)){
				if (!GlobalMembersTimetableexport.hashStudentIDsTimetable.contains(stg.name))
				{
					GlobalMembersTimetableexport.hashStudentIDsTimetable.insert(stg.name, CustomFETString.number(cnt));
					cnt++;
				}
			//	}
				for (int k = 0; k < stg.subgroupsList.size(); k++)
				{
					StudentsSubgroup sts = stg.subgroupsList[k];
			//		if(usedStudents.contains(sts->name)){
					if (!GlobalMembersTimetableexport.hashStudentIDsTimetable.contains(sts.name))
					{
						GlobalMembersTimetableexport.hashStudentIDsTimetable.insert(sts.name, CustomFETString.number(cnt));
						cnt++;
					}
			//		}
				}
			}
		}

		GlobalMembersTimetableexport.hashSubjectIDsTimetable.clear();
		for (int i = 0; i < gt.rules.nInternalSubjects; i++)
		{
			GlobalMembersTimetableexport.hashSubjectIDsTimetable.insert(gt.rules.internalSubjectsList[i].name, CustomFETString.number(i + 1));
		}
		GlobalMembersTimetableexport.hashActivityTagIDsTimetable.clear();
		for (int i = 0; i < gt.rules.nInternalActivityTags; i++)
		{
			GlobalMembersTimetableexport.hashActivityTagIDsTimetable.insert(gt.rules.internalActivityTagsList[i].name, CustomFETString.number(i + 1));
		}
		GlobalMembersTimetableexport.hashTeacherIDsTimetable.clear();
		for (int i = 0; i < gt.rules.nInternalTeachers; i++)
		{
			GlobalMembersTimetableexport.hashTeacherIDsTimetable.insert(gt.rules.internalTeachersList[i].name, CustomFETString.number(i + 1));
		}
		GlobalMembersTimetableexport.hashRoomIDsTimetable.clear();
		for (int room = 0; room < gt.rules.nInternalRooms; room++)
		{
			GlobalMembersTimetableexport.hashRoomIDsTimetable.insert(gt.rules.internalRoomsList[room].name, CustomFETString.number(room + 1));
		}
		GlobalMembersTimetableexport.hashDayIDsTimetable.clear();
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			GlobalMembersTimetableexport.hashDayIDsTimetable.insert(gt.rules.daysOfTheWeek[day], CustomFETString.number(day + 1));
		}
	}

	//this function must be called before export html files, because it is needed for the allActivities tables
	private static void computeActivitiesAtTime()
	{
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
			for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
				GlobalMembersGenerate.activitiesAtTime[day][hour].clear();
		for (int i = 0; i < gt.rules.nInternalActivities; i++) //maybe TODO: maybe it is better to do this sorted by students or teachers?
		{
			Activity act = gt.rules.internalActivitiesList[i];
			if (best_solution.times[i] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
				int hour = best_solution.times[i] / gt.rules.nDaysPerWeek;
				int day = best_solution.times[i] % gt.rules.nDaysPerWeek;
				for (int dd = 0; dd < act.duration && hour + dd < gt.rules.nHoursPerDay; dd++)
					GlobalMembersGenerate.activitiesAtTime[day][hour + dd].append(i);
			}
		}
	}

	//this function must be called before export html files, because it is needed to add activities with same starting time (simultanious activities)
	private static void computeActivitiesWithSameStartingTime()
	{
	// by Volker Dirr
		GlobalMembersTimetableexport.activitiesWithSameStartingTime.clear();

		if (GlobalMembersTimetable_defs.PRINT_ACTIVITIES_WITH_SAME_STARTING_TIME)
		{
			for (int i = 0; i < gt.rules.nInternalTimeConstraints; i++)
			{
				TimeConstraint tc = gt.rules.internalTimeConstraintsList[i];
				if (tc.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_SAME_STARTING_TIME) //not needed anymore:  && tc->weightPercentage==100
				{
					ConstraintActivitiesSameStartingTime c = (ConstraintActivitiesSameStartingTime) tc;
					for (int a = 0; a < c._n_activities; a++)
					{
						//speed improvement
						QList<int> tmpList = GlobalMembersTimetableexport.activitiesWithSameStartingTime[c._activities[a]];
						for (int b = 0; b < c._n_activities; b++)
						{
							if (a != b)
							{
								if (best_solution.times[c._activities[a]] == best_solution.times[c._activities[b]]) //because constraint is maybe not with 100% weight and failed
								{
									if (!tmpList.contains(c._activities[b]))
									{
										tmpList << c._activities[b];
									}
								}
							}
						}
						/*
						QList<int> tmpList;
						if(activitiesWithSameStartingTime.contains(c->_activities[a]))
							tmpList=activitiesWithSameStartingTime.value(c->_activities[a]);
						for(int b=0; b<c->_n_activities; b++){
							if(a!=b){
								if(best_solution.times[c->_activities[a]]==best_solution.times[c->_activities[b]]){ 	//because constraint is maybe not with 100% weight and failed
									if(!tmpList.contains(c->_activities[b])){
										tmpList<<c->_activities[b];
									}
								}
							}
						}
						activitiesWithSameStartingTime.insert(c->_activities[a], tmpList);
						*/
					}
				}
			}
		}
	}
	//this function add activities with same starting time into the allActivities list
	private static bool addActivitiesWithSameStartingTime(ref QList<int> allActivities, int hour)
	{
	// by Volker Dirr
		if (GlobalMembersTimetable_defs.PRINT_ACTIVITIES_WITH_SAME_STARTING_TIME)
		{
			bool activitiesWithSameStartingtime = false;
			QList<int> allActivitiesNew = new QList<int>();
			foreach (int tmpAct, allActivities)
			{
				allActivitiesNew << tmpAct;
				if (GlobalMembersTimetableexport.activitiesWithSameStartingTime.contains(tmpAct))
				{
					QList<int> sameTimeList = GlobalMembersTimetableexport.activitiesWithSameStartingTime.value(tmpAct);
					foreach (int sameTimeAct, sameTimeList)
					{
						if (!allActivitiesNew.contains(sameTimeAct) && !allActivities.contains(sameTimeAct))
						{
							if (best_solution.times[sameTimeAct] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
							{
								Activity act = gt.rules.internalActivitiesList[sameTimeAct];
								Debug.Assert(best_solution.times[tmpAct] == best_solution.times[sameTimeAct]); //{
									if ((best_solution.times[sameTimeAct] / gt.rules.nDaysPerWeek + (act.duration - 1)) >= hour)
									{
										allActivitiesNew << sameTimeAct;
									}
									activitiesWithSameStartingtime = true; //don't add this line in previous if command because of activities with different duration!
								//}
							}
						}
					}
				}
			}
			//allActivities.clear();
			allActivities = allActivitiesNew;
			//allActivitiesNew.clear();
			return activitiesWithSameStartingtime;
		}
		else
			return false;
	}

	//the following functions write the conflicts text and the xml files
	private static void writeSubgroupsTimetableXml(QWidget parent, QString xmlfilename)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an XML file
		QFile file = new QFile(xmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(xmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);
		tos << "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n";
		tos << "<" << GlobalMembersTimetable_defs.protect(GlobalMembersTimetableexport.STUDENTS_TIMETABLE_TAG) << ">\n";

		for (int subgroup = 0; subgroup < gt.rules.nInternalSubgroups; subgroup++)
		{
			tos << "  <Subgroup name=\"";
			QString subgroup_name = gt.rules.internalSubgroupsList[subgroup].name;
			tos << GlobalMembersTimetable_defs.protect(subgroup_name) << "\">\n";

			for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
			{
				tos << "   <Day name=\"" << GlobalMembersTimetable_defs.protect(gt.rules.daysOfTheWeek[day]) << "\">\n";
				for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
				{
					tos << "    <Hour name=\"" << GlobalMembersTimetable_defs.protect(gt.rules.hoursOfTheDay[hour]) << "\">\n";
					tos << "     ";
					int ai = students_timetable_weekly[subgroup][day][hour]; //activity index
					if (ai != GlobalMembersTimetable_defs.UNALLOCATED_ACTIVITY)
					{
						//Activity* act=gt.rules.activitiesList.at(ai);
						Activity act = gt.rules.internalActivitiesList[ai];
						for (QStringList.Iterator it = act.teachersNames.begin(); it != act.teachersNames.end(); it++)
							tos << " <Teacher name=\"" << GlobalMembersTimetable_defs.protect(*it) << "\"></Teacher>";
						tos << "<Subject name=\"" << GlobalMembersTimetable_defs.protect(act.subjectName) << "\"></Subject>";
						foreach (QString atn, act.activityTagsNames) tos << "<Activity_Tag name=\"" << GlobalMembersTimetable_defs.protect(atn) << "\"></Activity_Tag>";

						int r = best_solution.rooms[ai];
						if (r != GlobalMembersTimetable_defs.UNALLOCATED_SPACE && r != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM)
						{
							tos << "<Room name=\"" << GlobalMembersTimetable_defs.protect(gt.rules.internalRoomsList[r].name) << "\"></Room>";
						}
					}
					tos << "\n";
					tos << "    </Hour>\n";
				}
				tos << "   </Day>\n";
			}
			tos << "  </Subgroup>\n";
		}

		tos << "</" << GlobalMembersTimetable_defs.protect(GlobalMembersTimetableexport.STUDENTS_TIMETABLE_TAG) << ">\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(xmlfilename).arg(file.error()));
		}
		file.close();
	}
	private static void writeTeachersTimetableXml(QWidget parent, QString xmlfilename)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Writing the timetable in xml format
		QFile file = new QFile(xmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(xmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);
		tos << "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n";
		tos << "<" << GlobalMembersTimetable_defs.protect(GlobalMembersTimetableexport.TEACHERS_TIMETABLE_TAG) << ">\n";

		for (int i = 0; i < gt.rules.nInternalTeachers; i++)
		{
			tos << "  <Teacher name=\"" << GlobalMembersTimetable_defs.protect(gt.rules.internalTeachersList[i].name) << "\">\n";
			for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
			{
				tos << "   <Day name=\"" << GlobalMembersTimetable_defs.protect(gt.rules.daysOfTheWeek[day]) << "\">\n";
				for (int hour = 0; hour < gt.rules.nHoursPerDay; hour++)
				{
					tos << "    <Hour name=\"" << GlobalMembersTimetable_defs.protect(gt.rules.hoursOfTheDay[hour]) << "\">\n";

					tos << "     ";
					int ai = teachers_timetable_weekly[i][day][hour]; //activity index
					//Activity* act=gt.rules.activitiesList.at(ai);
					if (ai != GlobalMembersTimetable_defs.UNALLOCATED_ACTIVITY)
					{
						Activity act = gt.rules.internalActivitiesList[ai];
						tos << "<Subject name=\"" << GlobalMembersTimetable_defs.protect(act.subjectName) << "\"></Subject>";
						foreach (QString atn, act.activityTagsNames) tos << "<Activity_Tag name=\"" << GlobalMembersTimetable_defs.protect(atn) << "\"></Activity_Tag>";
						for (QStringList.Iterator it = act.studentsNames.begin(); it != act.studentsNames.end(); it++)
							tos << "<Students name=\"" << GlobalMembersTimetable_defs.protect(*it) << "\"></Students>";

						int r = best_solution.rooms[ai];
						if (r != GlobalMembersTimetable_defs.UNALLOCATED_SPACE && r != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM)
						{
							tos << "<Room name=\"" << GlobalMembersTimetable_defs.protect(gt.rules.internalRoomsList[r].name) << "\"></Room>";
						}
					}
					tos << "\n";
					tos << "    </Hour>\n";
				}
				tos << "   </Day>\n";
			}
			tos << "  </Teacher>\n";
		}

		tos << "</" << GlobalMembersTimetable_defs.protect(GlobalMembersTimetableexport.TEACHERS_TIMETABLE_TAG) << ">\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(xmlfilename).arg(file.error()));
		}
		file.close();
	}
	private static void writeActivitiesTimetableXml(QWidget parent, QString xmlfilename)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Writing the timetable in xml format
		QFile file = new QFile(xmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(xmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);
		tos << "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n";
		tos << "<" << GlobalMembersTimetable_defs.protect(GlobalMembersTimetableexport.ACTIVITIES_TIMETABLE_TAG) << ">\n";

		for (int i = 0; i < gt.rules.nInternalActivities; i++)
		{
			tos << "<Activity>" << "\n";

			tos << "	<Id>" << gt.rules.internalActivitiesList[i].id << "</Id>" << "\n";

			QString day = "";
			if (best_solution.times[i] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
				int d = best_solution.times[i] % gt.rules.nDaysPerWeek;
				day = gt.rules.daysOfTheWeek[d];
			}
			tos << "	<Day>" << GlobalMembersTimetable_defs.protect(day) << "</Day>" << "\n";

			QString hour = "";
			if (best_solution.times[i] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
				int h = best_solution.times[i] / gt.rules.nDaysPerWeek;
				hour = gt.rules.hoursOfTheDay[h];
			}
			tos << "	<Hour>" << GlobalMembersTimetable_defs.protect(hour) << "</Hour>" << "\n";

			QString room = "";
			if (best_solution.rooms[i] != GlobalMembersTimetable_defs.UNALLOCATED_SPACE && best_solution.rooms[i] != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM)
			{
				int r = best_solution.rooms[i];
				room = gt.rules.internalRoomsList[r].name;
			}
			tos << "	<Room>" << GlobalMembersTimetable_defs.protect(room) << "</Room>" << "\n";

			tos << "</Activity>" << "\n";
		}

		tos << "</" << GlobalMembersTimetable_defs.protect(GlobalMembersTimetableexport.ACTIVITIES_TIMETABLE_TAG) << ">\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(xmlfilename).arg(file.error()));
		}
		file.close();
	}

	//by Volker Dirr (timetabling.de)
	private static void writeConflictsTxt(QWidget parent, QString filename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		QFile file = new QFile(filename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(filename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		if (placedActivities == gt.rules.nInternalActivities)
		{
			QString tt = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1);
			if (INPUT_FILENAME_XML == "")
				tt = tr("unnamed");
			tos << TimetableExport.tr("Soft conflicts of %1", "%1 is the file name").arg(tt);
			tos << "\n";
			tos << TimetableExport.tr("Generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) << "\n\n";

			tos << TimetableExport.tr("Total soft conflicts:") << new QString(" ") << best_solution.conflictsTotal << "\n" << "\n";
			tos << TimetableExport.tr("Soft conflicts list (in decreasing order):") << "\n" << "\n";
			foreach (QString t, best_solution.conflictsDescriptionList) tos << t << "\n";
			tos << "\n" << TimetableExport.tr("End of file.") << "\n";
		}
		else
		{
			QString tt = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1);
			if (INPUT_FILENAME_XML == "")
				tt = tr("unnamed");
			tos << TimetableExport.tr("Conflicts of %1").arg(tt);
			tos << "\n";
			tos << TimetableExport.tr("Warning! Only %1 out of %2 activities placed!").arg(placedActivities).arg(gt.rules.nInternalActivities) << "\n";
			tos << TimetableExport.tr("Generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) << "\n\n";

			tos << TimetableExport.tr("Total conflicts:") << new QString(" ") << best_solution.conflictsTotal << "\n" << "\n";
			tos << TimetableExport.tr("Conflicts list (in decreasing order):") << "\n" << "\n";
			foreach (QString t, best_solution.conflictsDescriptionList) tos << t << "\n";
			tos << "\n" << TimetableExport.tr("End of file.") << "\n";
		}

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(filename).arg(file.error()));
		}
		file.close();
	}

	//the following functions write the css and html timetable files

	// writing the index html file by Volker Dirr.
	private static void writeIndexHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(false, placedActivities, true);

		QString bar = new QString();
		QString s2 = "";
		if (INPUT_FILENAME_XML == "")
			bar = "";
		else
		{
			bar = "_";
			s2 = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1);

			if (s2.right(4) == ".fet")
				s2 = s2.left(s2.length() - 4);
			//else if(INPUT_FILENAME_XML!="")
			//	cout<<"Minor problem - input file does not end in .fet extension - might be a problem when saving the timetables"<<" (file:"<<__FILE__<<", line:"<<__LINE__<<")"<<endl;
		}
		tos << "    <p>\n";

		tos << "      <a href=\"" << s2 + bar + GlobalMembersTimetableexport.CONFLICTS_FILENAME << "\">" << tr("View the soft conflicts list.") << "</a><br />\n";
		//	tos<<"    </p>\n";
		//	tos<<"    <p>\n";

		QString tmp1 = "<a href=\"" + s2 + bar + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_FILENAME_XML + "\">" + tr("subgroups") + "</a>";
		QString tmp2 = "<a href=\"" + s2 + bar + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_FILENAME_XML + "\">" + tr("teachers") + "</a>";
		QString tmp3 = "<a href=\"" + s2 + bar + GlobalMembersTimetableexport.ACTIVITIES_TIMETABLE_FILENAME_XML + "\">" + tr("activities") + "</a>";
		QString tmp4 = TimetableExport.tr("View XML: %1, %2, %3.", "%1, %2 and %3 are three files in XML format, subgroups, teachers and activities timetables. The user can click on one file to view it").arg(tmp1).arg(tmp2).arg(tmp3);
		tos << "      " << tmp4 << "\n";

		tos << "    </p>\n\n";

		tos << "    <table border=\"1\">\n";

		tos << "      <caption>" << GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) << "</caption>\n";

		tos << "      <thead>\n        <tr><td rowspan=\"2\"></td><th colspan=\"4\">" + tr("Timetables") + "</th></tr>\n";
		tos << "        <tr>\n          <!-- span -->\n";
		tos << "          <th>" + tr("Days Horizontal") + "</th><th>" + tr("Days Vertical") + "</th><th>" + tr("Time Horizontal") + "</th><th>" + tr("Time Vertical") + "</th>";
		tos << "        </tr>\n";
		tos << "      </thead>\n";
		tos << "      <tbody>\n";

		/* workaround
		tos<<"      <tfoot><tr><td></td><td colspan=\"4\">"<<TimetableExport::tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(FET_VERSION).arg(saveTime)<<"</td></tr></tfoot>\n";
		*/

		tos << "        <tr>\n";
		tos << "          <th>" + tr("Subgroups") + "</th>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML << "\">" + tr("view") + "</a></td>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML << "\">" + tr("view") + "</a></td>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML << "\">" + tr("view") + "</a></td>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersTimetableexport.SUBGROUPS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML << "\">" + tr("view") + "</a></td>\n";
		tos << "        </tr>\n";
		tos << "        <tr>\n";
		tos << "          <th>" + tr("Groups") + "</th>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersTimetableexport.GROUPS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML << "\">" + tr("view") + "</a></td>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersTimetableexport.GROUPS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML << "\">" + tr("view") + "</a></td>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersTimetableexport.GROUPS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML << "\">" + tr("view") + "</a></td>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersTimetableexport.GROUPS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML << "\">" + tr("view") + "</a></td>\n";
		tos << "        </tr>\n";
		tos << "        <tr>\n";
		tos << "          <th>" + tr("Years") + "</th>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersTimetableexport.YEARS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML << "\">" + tr("view") + "</a></td>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersTimetableexport.YEARS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML << "\">" + tr("view") + "</a></td>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersTimetableexport.YEARS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML << "\">" + tr("view") + "</a></td>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersTimetableexport.YEARS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML << "\">" + tr("view") + "</a></td>\n";
		tos << "        </tr>\n";
		tos << "        <tr>\n";
		tos << "          <th>" + tr("Teachers") + "</th>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML << "\">" + tr("view") + "</a></td>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML << "\">" + tr("view") + "</a></td>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML << "\">" + tr("view") + "</a></td>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersTimetableexport.TEACHERS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML << "\">" + tr("view") + "</a></td>\n";
		tos << "        </tr>\n";
		tos << "        <tr>\n";
		tos << "          <th>" + tr("Teachers Free Periods") + "</th>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersTimetableexport.TEACHERS_FREE_PERIODS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML << "\">" + tr("view") + "</a></td>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersTimetableexport.TEACHERS_FREE_PERIODS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML << "\">" + tr("view") + "</a></td>\n";
		tos << "          <td>" << GlobalMembersTimetable_defs.protect2(GlobalMembersTimetableexport.STRING_EMPTY_SLOT) << "</td>\n";
		tos << "          <td>" << GlobalMembersTimetable_defs.protect2(GlobalMembersTimetableexport.STRING_EMPTY_SLOT) << "</td>\n";
		tos << "        </tr>\n";
		tos << "        <tr>\n";
		tos << "          <th>" + tr("Rooms") + "</th>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersTimetableexport.ROOMS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML << "\">" + tr("view") + "</a></td>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersTimetableexport.ROOMS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML << "\">" + tr("view") + "</a></td>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersTimetableexport.ROOMS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML << "\">" + tr("view") + "</a></td>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersTimetableexport.ROOMS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML << "\">" + tr("view") + "</a></td>\n";
		tos << "        </tr>\n";
		tos << "        <tr>\n";
		tos << "          <th>" + tr("Subjects") + "</th>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersTimetableexport.SUBJECTS_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML << "\">" + tr("view") + "</a></td>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersTimetableexport.SUBJECTS_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML << "\">" + tr("view") + "</a></td>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersTimetableexport.SUBJECTS_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML << "\">" + tr("view") + "</a></td>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersTimetableexport.SUBJECTS_TIMETABLE_TIME_VERTICAL_FILENAME_HTML << "\">" + tr("view") + "</a></td>\n";
		tos << "        </tr>\n";
		tos << "        <tr>\n";
		tos << "          <th>" + tr("Activities") + "</th>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersTimetableexport.ALL_ACTIVITIES_TIMETABLE_DAYS_HORIZONTAL_FILENAME_HTML << "\">" + tr("view") + "</a></td>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersTimetableexport.ALL_ACTIVITIES_TIMETABLE_DAYS_VERTICAL_FILENAME_HTML << "\">" + tr("view") + "</a></td>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersTimetableexport.ALL_ACTIVITIES_TIMETABLE_TIME_HORIZONTAL_FILENAME_HTML << "\">" + tr("view") + "</a></td>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersTimetableexport.ALL_ACTIVITIES_TIMETABLE_TIME_VERTICAL_FILENAME_HTML << "\">" + tr("view") + "</a></td>\n";
		tos << "        </tr>\n";
		//workaround begin.
		tos << "      <tr class=\"foot\"><td></td><td colspan=\"4\">" << TimetableExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) << "</td></tr>\n";
		//workaround end.
		tos << "      </tbody>\n";
		tos << "    </table>\n";

		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	// writing the stylesheet in css format to a file by Volker Dirr.
	private static void writeStylesheetCss(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//get used students	//TODO: do it the same way in statistics.cpp
		QSet<QString> usedStudents = new QSet<QString>();
		for (int i = 0; i < gt.rules.nInternalActivities; i++)
		{
			foreach (QString st, gt.rules.internalActivitiesList[i].studentsNames)
			{
				if (!usedStudents.contains(st))
					usedStudents << st;
			}
		}

		//Now we print the results to an CSS file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << "@charset \"UTF-8\";" << "\n\n";

		QString tt = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1);
		if (INPUT_FILENAME_XML == "")
			tt = tr("unnamed");
		tos << "/* " << TimetableExport.tr("CSS Stylesheet of %1", "%1 is the file name").arg(tt);
		tos << "\n";
		if (placedActivities != gt.rules.nInternalActivities)
			tos << "   " << TimetableExport.tr("Warning! Only %1 out of %2 activities placed!").arg(placedActivities).arg(gt.rules.nInternalActivities) << "\n";
		tos << "   " << TimetableExport.tr("Stylesheet generated with FET %1 on %2", "%1 is FET version, %2 is date and time").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) << " */\n\n";

		tos << "/* " << TimetableExport.tr("To do a page-break only after every second timetable, delete \"page-break-before: always;\" in \"table.even_table\".", "Please keep fields in quotes as they are, untranslated.") << " */\n";
		tos << "/* " << TimetableExport.tr("To hide an element just write the following phrase into the element: %1 (without quotes).", "%1 is a short phrase beginning and ending with quotes, and we want the user to be able to add it, but without quotes").arg("\"display:none;\"") << " */\n\n";
		tos << "p.back {\n  margin-top: 4ex;\n  margin-bottom: 5ex;\n}\n\n";
		tos << "table {\n  text-align: center;\n}\n\n";
		tos << "table.odd_table {\n  page-break-before: always;\n}\n\n";
		tos << "table.even_table {\n  page-break-before: always;\n}\n\n";
		tos << "table.detailed {\n  margin-left:auto; margin-right:auto;\n  text-align: center;\n  border: 0px;\n  border-spacing: 0;\n  border-collapse: collapse;\n}\n\n";
		tos << "caption {\n\n}\n\n";
		tos << "thead {\n\n}\n\n";

		//workaround begin.
		tos << "/* " << TimetableExport.tr("Some programs import \"tfoot\" incorrectly. So we use \"tr.foot\" instead of \"tfoot\".", "Please keep tfoot and tr.foot untranslated, as they are in the original English phrase") << " */\n\n";
		//tos<<"tfoot {\n\n}\n\n";
		tos << "tr.foot {\n\n}\n\n";
		//workaround end

		tos << "tbody {\n\n}\n\n";
		tos << "th {\n\n}\n\n";
		tos << "td {\n\n}\n\n";
		tos << "td.detailed {\n  border: 1px dashed silver;\n  border-bottom: 0;\n  border-top: 0;\n}\n\n";
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 2)
		{
			tos << "th.xAxis {\n/* width: 8em; */\n}\n\n";
			tos << "th.yAxis {\n  height: 8ex;\n}\n\n";
		}
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 4) // must be written before LEVEL 3, because LEVEL 3 should have higher priority
		{
			for (int i = 0; i < gt.rules.nInternalSubjects; i++)
			{
				tos << "span.s_" << GlobalMembersTimetableexport.hashSubjectIDsTimetable.value(gt.rules.internalSubjectsList[i].name) << " { /* subject " << gt.rules.internalSubjectsList[i].name << " */\n\n}\n\n";
			}
			for (int i = 0; i < gt.rules.nInternalActivityTags; i++)
			{
				tos << "span.at_" << GlobalMembersTimetableexport.hashActivityTagIDsTimetable.value(gt.rules.internalActivityTagsList[i].name) << " { /* activity tag " << gt.rules.internalActivityTagsList[i].name << " */\n\n}\n\n";
			}
			for (int i = 0; i < gt.rules.augmentedYearsList.size(); i++)
			{
				StudentsYear sty = gt.rules.augmentedYearsList[i];
				if (usedStudents.contains(sty.name))
					tos << "span.ss_" << GlobalMembersTimetableexport.hashStudentIDsTimetable.value(sty.name) << " { /* students set " << sty.name << " */\n\n}\n\n";
				for (int j = 0; j < sty.groupsList.size(); j++)
				{
					StudentsGroup stg = sty.groupsList[j];
					if (usedStudents.contains(stg.name))
						tos << "span.ss_" << GlobalMembersTimetableexport.hashStudentIDsTimetable.value(stg.name) << " { /* students set " << stg.name << " */\n\n}\n\n";
					for (int k = 0; k < stg.subgroupsList.size(); k++)
					{
						StudentsSubgroup sts = stg.subgroupsList[k];
						if (usedStudents.contains(sts.name))
							tos << "span.ss_" << GlobalMembersTimetableexport.hashStudentIDsTimetable.value(sts.name) << " { /* students set " << sts.name << " */\n\n}\n\n";
					}
				}
			}
			for (int i = 0; i < gt.rules.nInternalTeachers; i++)
			{
				tos << "span.t_" << GlobalMembersTimetableexport.hashTeacherIDsTimetable.value(gt.rules.internalTeachersList[i].name) << " { /* teacher " << gt.rules.internalTeachersList[i].name << " */\n\n}\n\n";
			}
			for (int room = 0; room < gt.rules.nInternalRooms; room++)
			{
				tos << "span.r_" << GlobalMembersTimetableexport.hashRoomIDsTimetable.value(gt.rules.internalRoomsList[room].name) << " { /* room " << gt.rules.internalRoomsList[room].name << " */\n\n}\n\n";
			}
		}
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 3)
		{
			tos << "span.subject {\n\n}\n\n";
			tos << "span.activitytag {\n\n}\n\n";

			tos << "span.empty {\n  color: gray;\n}\n\n";
			tos << "td.empty {\n  border-color:silver;\n  border-right-style:none;\n  border-bottom-style:none;\n  border-left-style:dotted;\n  border-top-style:dotted;\n}\n\n";

			tos << "span.notAvailable {\n  color: gray;\n}\n\n";
			tos << "td.notAvailable {\n  border-color:silver;\n  border-right-style:none;\n  border-bottom-style:none;\n  border-left-style:dotted;\n  border-top-style:dotted;\n}\n\n";

			tos << "span.break {\n  color: gray;\n}\n\n";
			tos << "td.break {\n  border-color:silver;\n  border-right-style:none;\n  border-bottom-style:none;\n  border-left-style:dotted;\n  border-top-style:dotted;\n}\n\n";

			tos << "td.student, div.student {\n\n}\n\n";
			tos << "td.teacher, div.teacher {\n\n}\n\n";
			tos << "td.room, div.room {\n\n}\n\n";
			tos << "tr.line0 {\n  font-size: smaller;\n}\n\n";
			tos << "tr.line1, div.line1 {\n\n}\n\n";
			tos << "tr.line2, div.line2 {\n  font-size: smaller;\n  color: gray;\n}\n\n";
			tos << "tr.line3, div.line3 {\n  font-size: smaller;\n  color: silver;\n}\n\n";
		}
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL == 6)
		{
			tos << "\n" << "/* " << TimetableExport.tr("Be careful. You might get mutual and ambiguous styles. CSS means that the last definition will be used.") << " */\n\n";
			for (int i = 0; i < gt.rules.nInternalSubjects; i++)
			{
				tos << "td.s_" << GlobalMembersTimetableexport.hashSubjectIDsTimetable.value(gt.rules.internalSubjectsList[i].name) << " { /* subject " << gt.rules.internalSubjectsList[i].name << " */\n\n}\n\n";
			}
			for (int i = 0; i < gt.rules.nInternalActivityTags; i++)
			{
				tos << "td.at_" << GlobalMembersTimetableexport.hashActivityTagIDsTimetable.value(gt.rules.internalActivityTagsList[i].name) << " { /* activity tag " << gt.rules.internalActivityTagsList[i].name << " */\n\n}\n\n";
			}
			for (int i = 0; i < gt.rules.augmentedYearsList.size(); i++)
			{
				StudentsYear sty = gt.rules.augmentedYearsList[i];
				if (usedStudents.contains(sty.name))
					tos << "td.ss_" << GlobalMembersTimetableexport.hashStudentIDsTimetable.value(sty.name) << " { /* students set " << sty.name << " */\n\n}\n\n";
				for (int j = 0; j < sty.groupsList.size(); j++)
				{
					StudentsGroup stg = sty.groupsList[j];
					if (usedStudents.contains(stg.name))
						tos << "td.ss_" << GlobalMembersTimetableexport.hashStudentIDsTimetable.value(stg.name) << " { /* students set " << stg.name << " */\n\n}\n\n";
					for (int k = 0; k < stg.subgroupsList.size(); k++)
					{
						StudentsSubgroup sts = stg.subgroupsList[k];
						if (usedStudents.contains(sts.name))
							tos << "td.ss_" << GlobalMembersTimetableexport.hashStudentIDsTimetable.value(sts.name) << " { /* students set " << sts.name << " */\n\n}\n\n";
					}
				}
			}
			for (int i = 0; i < gt.rules.nInternalTeachers; i++)
			{
				tos << "td.t_" << GlobalMembersTimetableexport.hashTeacherIDsTimetable.value(gt.rules.internalTeachersList[i].name) << " { /* teacher " << gt.rules.internalTeachersList[i].name << " */\n\n}\n\n";
			}

			//not included yet
			//for(int room=0; room<gt.rules.nInternalRooms; room++){
			//	tos << "span.r_"<<hashRoomIDsTimetable.value(gt.rules.internalRoomsList[room]->name)<<" { /* room "<<gt.rules.internalRoomsList[room]->name<<" */\n\n}\n\n";
			//}
		}
		tos << "/* " << TimetableExport.tr("Style the teachers free periods") << " */\n\n";
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 2)
		{
			tos << "div.DESCRIPTION {\n  text-align: left;\n  font-size: smaller;\n}\n\n";
		}
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 3)
		{
			tos << "div.TEACHER_HAS_SINGLE_GAP {\n  color: black;\n}\n\n";
			tos << "div.TEACHER_HAS_BORDER_GAP {\n  color: gray;\n}\n\n";
			tos << "div.TEACHER_HAS_BIG_GAP {\n  color: silver;\n}\n\n";
			tos << "div.TEACHER_MUST_COME_EARLIER {\n  color: purple;\n}\n\n";
			tos << "div.TEACHER_MUST_COME_MUCH_EARLIER {\n  font-size: smaller;\n  color: fuchsia;\n}\n\n";
			tos << "div.TEACHER_MUST_STAY_LONGER {\n  color: teal;\n}\n\n";
			tos << "div.TEACHER_MUST_STAY_MUCH_LONGER {\n  font-size: smaller;\n  color: aqua;\n}\n\n";
			tos << "div.TEACHER_HAS_A_FREE_DAY {\n  font-size: smaller;\n  color: red;\n}\n\n";
			tos << "div.TEACHER_IS_NOT_AVAILABLE {\n  font-size: smaller;\n  color: olive;\n}\n\n";
		}
		tos << "/* " << TimetableExport.tr("End of file.") << " */\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//XHTML generation code modified by Volker Dirr (timetabling.de) from old html generation code
	private static void writeSubgroupsTimetableDaysHorizontalHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, true);

		tos << "    <p><strong>" << TimetableExport.tr("Table of contents") << "</strong></p>\n";
		tos << "    <ul>\n";
		for (int i = 0; i < gt.rules.augmentedYearsList.size(); i++)
		{
			StudentsYear sty = gt.rules.augmentedYearsList[i];
			tos << "      <li>\n        " << TimetableExport.tr("Year") << " " << GlobalMembersTimetable_defs.protect2(sty.name) << "\n        <ul>\n";
			for (int j = 0; j < sty.groupsList.size(); j++)
			{
				StudentsGroup stg = sty.groupsList[j];
				tos << "          <li>\n            " << TimetableExport.tr("Group") << " " << GlobalMembersTimetable_defs.protect2(stg.name) << ": \n";
				for (int k = 0; k < stg.subgroupsList.size(); k++)
				{
					StudentsSubgroup sts = stg.subgroupsList[k];
					tos << "              <a href=\"" << "#table_" << GlobalMembersTimetableexport.hashStudentIDsTimetable.value(sts.name) << "\">" << GlobalMembersTimetable_defs.protect2(sts.name) << "</a>\n";
				}
				tos << "          </li>\n";
			}
			tos << "        </ul>\n      </li>\n";
		}
		tos << "    </ul>\n    <p>&nbsp;</p>\n\n";

		for (int subgroup = 0; subgroup < gt.rules.nInternalSubgroups; subgroup++)
		{
			tos << singleSubgroupsTimetableDaysHorizontalHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, subgroup, saveTime, true);
			tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
		}
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//XHTML generation code modified by Volker Dirr (timetabling.de) from old html generation code
	private static void writeSubgroupsTimetableDaysVerticalHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, true);

		tos << "    <p><strong>" << TimetableExport.tr("Table of contents") << "</strong></p>\n";
		tos << "    <ul>\n";
		for (int i = 0; i < gt.rules.augmentedYearsList.size(); i++)
		{
			StudentsYear sty = gt.rules.augmentedYearsList[i];
			tos << "      <li>\n        " << TimetableExport.tr("Year") << " " << GlobalMembersTimetable_defs.protect2(sty.name) << "\n        <ul>\n";
			for (int j = 0; j < sty.groupsList.size(); j++)
			{
				StudentsGroup stg = sty.groupsList[j];
				tos << "          <li>\n            " << TimetableExport.tr("Group") << " " << GlobalMembersTimetable_defs.protect2(stg.name) << ": \n";
				for (int k = 0; k < stg.subgroupsList.size(); k++)
				{
					StudentsSubgroup sts = stg.subgroupsList[k];
					tos << "              <a href=\"" << "#table_" << GlobalMembersTimetableexport.hashStudentIDsTimetable.value(sts.name) << "\">" << GlobalMembersTimetable_defs.protect2(sts.name) << "</a>\n";
				}
				tos << "          </li>\n";
			}
			tos << "        </ul>\n      </li>\n";
		}
		tos << "    </ul>\n    <p>&nbsp;</p>\n";

		for (int subgroup = 0; subgroup < gt.rules.nInternalSubgroups; subgroup++)
		{
			tos << singleSubgroupsTimetableDaysVerticalHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, subgroup, saveTime, true);
			tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
		}

		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//XHTML generation code modified by Volker Dirr (timetabling.de) from old html generation code
	private static void writeSubgroupsTimetableTimeHorizontalHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, false);

		QSet<int> tmp = new QSet<int>();
		tos << singleSubgroupsTimetableTimeHorizontalHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, gt.rules.nInternalSubgroups, ref tmp, saveTime, true);

		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//XHTML generation code by Volker Dirr (http://timetabling.de/)
	private static void writeSubgroupsTimetableTimeVerticalHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, false);

		QSet<int> tmp = new QSet<int>();
		tos << singleSubgroupsTimetableTimeVerticalHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, gt.rules.nInternalSubgroups, ref tmp, saveTime, true);

		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	// by Volker Dirr
	private static void writeSubgroupsTimetableTimeHorizontalDailyHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, true);
		tos << writeTOCDays(false);

		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			QSet<int> tmp = new QSet<int>();
			tos << singleSubgroupsTimetableTimeHorizontalDailyHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, day, gt.rules.nInternalSubgroups, ref tmp, saveTime, true);
			tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
		}
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	// by Volker Dirr
	private static void writeSubgroupsTimetableTimeVerticalDailyHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, true);
		tos << writeTOCDays(false);

		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			QSet<int> tmp = new QSet<int>();
			tos << singleSubgroupsTimetableTimeVerticalDailyHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, day, gt.rules.nInternalSubgroups, ref tmp, saveTime, true);
			tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
		}

		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//Now print the groups
	//XHTML generation code by Volker Dirr (http://timetabling.de/)
	private static void writeGroupsTimetableDaysHorizontalHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, true);

		tos << "    <p><strong>" << TimetableExport.tr("Table of contents") << "</strong></p>\n";
		tos << "    <ul>\n";
		for (int i = 0; i < gt.rules.augmentedYearsList.size(); i++)
		{
			StudentsYear sty = gt.rules.augmentedYearsList[i];
			tos << "      <li>\n        " << TimetableExport.tr("Year") << " " << GlobalMembersTimetable_defs.protect2(sty.name) << "\n        <ul>\n";
			for (int j = 0; j < sty.groupsList.size(); j++)
			{
				StudentsGroup stg = sty.groupsList[j];
				tos << "          <li>\n            " << TimetableExport.tr("Group");
				tos << " <a href=\"" << "#table_" << GlobalMembersTimetableexport.hashStudentIDsTimetable.value(stg.name) << "_DETAILED\">" << GlobalMembersTimetable_defs.protect2(stg.name) << " (" << tr("Detailed") << ")</a> /";
				tos << " <a href=\"" << "#table_" << GlobalMembersTimetableexport.hashStudentIDsTimetable.value(stg.name) << "\">" << GlobalMembersTimetable_defs.protect2(stg.name) << " (" << tr("Less detailed") << ")</a>\n";
				tos << "          </li>\n";
			}
			tos << "        </ul>\n      </li>\n";
		}
		tos << "    </ul>\n    <p>&nbsp;</p>\n\n";

		bool PRINT_DETAILED = true;
		do
		{
			for (int group = 0; group < gt.rules.internalGroupsList.size(); group++)
			{
				tos << singleGroupsTimetableDaysHorizontalHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, group, saveTime, true, PRINT_DETAILED);
				tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
			}
			if (PRINT_DETAILED)
				PRINT_DETAILED = false;
			else
				PRINT_DETAILED = true;
		} while (!PRINT_DETAILED);
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//XHTML generation code by Volker Dirr (http://timetabling.de/)
	private static void writeGroupsTimetableDaysVerticalHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, true);

		tos << "    <p><strong>" << TimetableExport.tr("Table of contents") << "</strong></p>\n";
		tos << "    <ul>\n";
		for (int i = 0; i < gt.rules.augmentedYearsList.size(); i++)
		{
			StudentsYear sty = gt.rules.augmentedYearsList[i];
			tos << "      <li>\n        " << TimetableExport.tr("Year") << " " << GlobalMembersTimetable_defs.protect2(sty.name) << "\n        <ul>\n";
			for (int j = 0; j < sty.groupsList.size(); j++)
			{
				StudentsGroup stg = sty.groupsList[j];
				tos << "          <li>\n            " << TimetableExport.tr("Group");
				tos << " <a href=\"" << "#table_" << GlobalMembersTimetableexport.hashStudentIDsTimetable.value(stg.name) << "_DETAILED\">" << GlobalMembersTimetable_defs.protect2(stg.name) << " (" << tr("Detailed") << ")</a> /";
				tos << " <a href=\"" << "#table_" << GlobalMembersTimetableexport.hashStudentIDsTimetable.value(stg.name) << "\">" << GlobalMembersTimetable_defs.protect2(stg.name) << " (" << tr("Less detailed") << ")</a>\n";
				tos << "          </li>\n";
			}
			tos << "        </ul>\n      </li>\n";
		}
		tos << "    </ul>\n    <p>&nbsp;</p>\n";

		bool PRINT_DETAILED = true;
		do
		{
			for (int group = 0; group < gt.rules.internalGroupsList.size(); group++)
			{
				tos << singleGroupsTimetableDaysVerticalHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, group, saveTime, true, PRINT_DETAILED);
				tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
			}
			if (PRINT_DETAILED)
				PRINT_DETAILED = false;
			else
				PRINT_DETAILED = true;
		} while (!PRINT_DETAILED);
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//XHTML generation code by Volker Dirr (http://timetabling.de/)
	private static void writeGroupsTimetableTimeHorizontalHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, false);

		bool PRINT_DETAILED = true;
		do
		{
			QSet<int> tmp = new QSet<int>();
			tos << singleGroupsTimetableTimeHorizontalHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, gt.rules.internalGroupsList.size(), ref tmp, saveTime, true, PRINT_DETAILED);
			tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
			if (PRINT_DETAILED)
				PRINT_DETAILED = false;
			else
				PRINT_DETAILED = true;
		} while (!PRINT_DETAILED);
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//XHTML generation code by Volker Dirr (http://timetabling.de/)
	private static void writeGroupsTimetableTimeVerticalHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, false);

		bool PRINT_DETAILED = true;
		do
		{
			QSet<int> tmp = new QSet<int>();
			tos << singleGroupsTimetableTimeVerticalHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, gt.rules.internalGroupsList.size(), ref tmp, saveTime, true, PRINT_DETAILED);

			tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
			if (PRINT_DETAILED)
				PRINT_DETAILED = false;
			else
				PRINT_DETAILED = true;
		} while (!PRINT_DETAILED);
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//XHTML generation code by Volker Dirr (http://timetabling.de/)
	private static void writeGroupsTimetableTimeHorizontalDailyHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, true);
		tos << writeTOCDays(true);

		bool PRINT_DETAILED = true;
		do
		{
			for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
			{
				QSet<int> tmp = new QSet<int>();
				tos << singleGroupsTimetableTimeHorizontalDailyHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, day, gt.rules.internalGroupsList.size(), ref tmp, saveTime, true, PRINT_DETAILED);

				tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
			}
			if (PRINT_DETAILED)
				PRINT_DETAILED = false;
			else
				PRINT_DETAILED = true;
		} while (!PRINT_DETAILED);
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//XHTML generation code by Volker Dirr (http://timetabling.de/)
	private static void writeGroupsTimetableTimeVerticalDailyHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, true);
		tos << writeTOCDays(true);

		bool PRINT_DETAILED = true;
		do
		{
			for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
			{
				QSet<int> tmp = new QSet<int>();
				tos << singleGroupsTimetableTimeVerticalDailyHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, day, gt.rules.internalGroupsList.size(), ref tmp, saveTime, true, PRINT_DETAILED);

				tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
			}
			if (PRINT_DETAILED)
				PRINT_DETAILED = false;
			else
				PRINT_DETAILED = true;
		} while (!PRINT_DETAILED);
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//Now print the years

	//XHTML generation code by Volker Dirr (http://timetabling.de/)
	private static void writeYearsTimetableDaysHorizontalHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, true);

		tos << "    <p><strong>" << TimetableExport.tr("Table of contents") << "</strong></p>\n";
		tos << "    <ul>\n";
		for (int year = 0; year < gt.rules.augmentedYearsList.size(); year++)
		{
			StudentsYear sty = gt.rules.augmentedYearsList[year];
			tos << "      <li>\n        " << TimetableExport.tr("Year");
			tos << " <a href=\"" << "#table_" << GlobalMembersTimetableexport.hashStudentIDsTimetable.value(sty.name) << "_DETAILED\">" << GlobalMembersTimetable_defs.protect2(sty.name) << " (" << tr("Detailed") << ")</a> /";
			tos << " <a href=\"" << "#table_" << GlobalMembersTimetableexport.hashStudentIDsTimetable.value(sty.name) << "\">" << GlobalMembersTimetable_defs.protect2(sty.name) << " (" << tr("Less detailed") << ")</a>\n";
			tos << "      </li>\n";
		}
		tos << "    </ul>\n    <p>&nbsp;</p>\n\n";

		bool PRINT_DETAILED = true;
		do
		{
			for (int year = 0; year < gt.rules.augmentedYearsList.size(); year++)
			{
				tos << singleYearsTimetableDaysHorizontalHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, year, saveTime, true, PRINT_DETAILED);
				tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
			}
			if (PRINT_DETAILED)
				PRINT_DETAILED = false;
			else
				PRINT_DETAILED = true;
		} while (!PRINT_DETAILED);
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//XHTML generation code by Volker Dirr (http://timetabling.de/)
	private static void writeYearsTimetableDaysVerticalHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, true);

		tos << "    <p><strong>" << TimetableExport.tr("Table of contents") << "</strong></p>\n";
		tos << "    <ul>\n";
		for (int year = 0; year < gt.rules.augmentedYearsList.size(); year++)
		{
			StudentsYear sty = gt.rules.augmentedYearsList[year];
			tos << "      <li>\n        " << TimetableExport.tr("Year");
			tos << " <a href=\"" << "#table_" << GlobalMembersTimetableexport.hashStudentIDsTimetable.value(sty.name) << "_DETAILED\">" << GlobalMembersTimetable_defs.protect2(sty.name) << " (" << tr("Detailed") << ")</a> /";
			tos << " <a href=\"" << "#table_" << GlobalMembersTimetableexport.hashStudentIDsTimetable.value(sty.name) << "\">" << GlobalMembersTimetable_defs.protect2(sty.name) << " (" << tr("Less detailed") << ")</a>\n";
			tos << "      </li>\n";
		}
		tos << "    </ul>\n    <p>&nbsp;</p>\n\n";

		bool PRINT_DETAILED = true;
		do
		{
			for (int year = 0; year < gt.rules.augmentedYearsList.size(); year++)
			{
				tos << singleYearsTimetableDaysVerticalHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, year, saveTime, true, PRINT_DETAILED);
				tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
			}
			if (PRINT_DETAILED)
				PRINT_DETAILED = false;
			else
				PRINT_DETAILED = true;
		} while (!PRINT_DETAILED);
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//XHTML generation code by Volker Dirr (http://timetabling.de/)
	private static void writeYearsTimetableTimeHorizontalHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, false);

		bool PRINT_DETAILED = true;
		do
		{
			QSet<int> tmp = new QSet<int>();
			tos << singleYearsTimetableTimeHorizontalHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, gt.rules.augmentedYearsList.size(), ref tmp, saveTime, true, PRINT_DETAILED);

			tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
			if (PRINT_DETAILED)
				PRINT_DETAILED = false;
			else
				PRINT_DETAILED = true;
		} while (!PRINT_DETAILED);
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//XHTML generation code by Volker Dirr (http://timetabling.de/)
	private static void writeYearsTimetableTimeVerticalHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, false);

		bool PRINT_DETAILED = true;
		do
		{
			QSet<int> tmp = new QSet<int>();
			tos << singleYearsTimetableTimeVerticalHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, gt.rules.augmentedYearsList.size(), ref tmp, saveTime, true, PRINT_DETAILED);

			tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
			if (PRINT_DETAILED)
				PRINT_DETAILED = false;
			else
				PRINT_DETAILED = true;
		} while (!PRINT_DETAILED);
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//XHTML generation code by Volker Dirr (http://timetabling.de/)
	private static void writeYearsTimetableTimeHorizontalDailyHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, true);
		tos << writeTOCDays(true);

		bool PRINT_DETAILED = true;
		do
		{
			for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
			{
				QSet<int> tmp = new QSet<int>();
				tos << singleYearsTimetableTimeHorizontalDailyHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, day, gt.rules.augmentedYearsList.size(), ref tmp, saveTime, true, PRINT_DETAILED);

				tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
			}
			if (PRINT_DETAILED)
				PRINT_DETAILED = false;
			else
				PRINT_DETAILED = true;
		} while (!PRINT_DETAILED);
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//XHTML generation code by Volker Dirr (http://timetabling.de/)
	private static void writeYearsTimetableTimeVerticalDailyHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, true);
		tos << writeTOCDays(true);

		bool PRINT_DETAILED = true;
		do
		{
			for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
			{
				QSet<int> tmp = new QSet<int>();
				tos << singleYearsTimetableTimeVerticalDailyHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, day, gt.rules.augmentedYearsList.size(), ref tmp, saveTime, true, PRINT_DETAILED);

				tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
			}
			if (PRINT_DETAILED)
				PRINT_DETAILED = false;
			else
				PRINT_DETAILED = true;
		} while (!PRINT_DETAILED);
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//Print all activities

	//XHTML generation code by Volker Dirr (http://timetabling.de/)
	private static void writeAllActivitiesTimetableDaysHorizontalHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, true);
		tos << singleAllActivitiesTimetableDaysHorizontalHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, saveTime, true);
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//XHTML generation code by Volker Dirr (http://timetabling.de/)
	private static void writeAllActivitiesTimetableDaysVerticalHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, true);
		tos << singleAllActivitiesTimetableDaysVerticalHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, saveTime, true);
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//XHTML generation code by Volker Dirr (http://timetabling.de/)
	private static void writeAllActivitiesTimetableTimeHorizontalHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, false);

		tos << singleAllActivitiesTimetableTimeHorizontalHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, saveTime, true);

		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//XHTML generation code by Volker Dirr (http://timetabling.de/)
	private static void writeAllActivitiesTimetableTimeVerticalHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, false);

	tos << singleAllActivitiesTimetableTimeVerticalHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, saveTime, true);

		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//XHTML generation code by Volker Dirr (http://timetabling.de/)
	private static void writeAllActivitiesTimetableTimeHorizontalDailyHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, true);
		tos << writeTOCDays(false);

		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			tos << singleAllActivitiesTimetableTimeHorizontalDailyHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, day, saveTime, true);

			tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
		}

		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//XHTML generation code by Volker Dirr (http://timetabling.de/)
	private static void writeAllActivitiesTimetableTimeVerticalDailyHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, true);
		tos << writeTOCDays(false);

		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			tos << singleAllActivitiesTimetableTimeVerticalDailyHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, day, saveTime, true);
			tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
		}
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//Print the teachers

	//XHTML generation code modified by Volker Dirr (timetabling.de) from old html generation code
	private static void writeTeachersTimetableDaysHorizontalHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, true);

		tos << "    <p><strong>" << TimetableExport.tr("Table of contents") << "</strong></p>\n";
		tos << "    <ul>\n";
		for (int teacher = 0; teacher < gt.rules.nInternalTeachers; teacher++)
		{
			QString teacher_name = gt.rules.internalTeachersList[teacher].name;
			tos << "      <li><a href=\"" << "#table_" << GlobalMembersTimetableexport.hashTeacherIDsTimetable.value(teacher_name) << "\">" << GlobalMembersTimetable_defs.protect2(teacher_name) << "</a></li>\n";
		}
		tos << "    </ul>\n    <p>&nbsp;</p>\n\n";

		for (int teacher = 0; teacher < gt.rules.nInternalTeachers; teacher++)
		{
			tos << singleTeachersTimetableDaysHorizontalHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, teacher, saveTime, true);

			tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
		}
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//XHTML generation code modified by Volker Dirr (timetabling.de) from old html generation code
	private static void writeTeachersTimetableDaysVerticalHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, true);

		tos << "    <p><strong>" << TimetableExport.tr("Table of contents") << "</strong></p>\n";
		tos << "    <ul>\n";
		for (int teacher = 0; teacher < gt.rules.nInternalTeachers; teacher++)
		{
			QString teacher_name = gt.rules.internalTeachersList[teacher].name;
			tos << "      <li><a href=\"" << "#table_" << GlobalMembersTimetableexport.hashTeacherIDsTimetable.value(teacher_name) << "\">" << GlobalMembersTimetable_defs.protect2(teacher_name) << "</a></li>\n";
		}
		tos << "    </ul>\n    <p>&nbsp;</p>\n\n";

		for (int teacher = 0; teacher < gt.rules.nInternalTeachers; teacher++)
		{
			tos << singleTeachersTimetableDaysVerticalHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, teacher, saveTime, true);
			tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
		}
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//XHTML generation code modified by Volker Dirr (timetabling.de) from old html generation code
	private static void writeTeachersTimetableTimeHorizontalHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, false);
		QSet<int> tmp = new QSet<int>();
		tos << singleTeachersTimetableTimeHorizontalHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, gt.rules.nInternalTeachers, ref tmp, saveTime, true);
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//XHTML generation code by Volker Dirr (http://timetabling.de/)
	private static void writeTeachersTimetableTimeVerticalHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, false);
		QSet<int> tmp = new QSet<int>();
		tos << singleTeachersTimetableTimeVerticalHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, gt.rules.nInternalTeachers, ref tmp, saveTime, true);
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//by Volker Dirr
	private static void writeTeachersTimetableTimeHorizontalDailyHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, true);
		tos << writeTOCDays(false);

		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			QSet<int> tmp = new QSet<int>();
			tos << singleTeachersTimetableTimeHorizontalDailyHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, day, gt.rules.nInternalTeachers, ref tmp, saveTime, true);
			tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
		}

		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//by Volker Dirr
	private static void writeTeachersTimetableTimeVerticalDailyHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, true);
		tos << writeTOCDays(false);

		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			QSet<int> tmp = new QSet<int>();
			tos << singleTeachersTimetableTimeVerticalDailyHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, day, gt.rules.nInternalTeachers, ref tmp, saveTime, true);
			tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
		}
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//writing the rooms' timetable html format to a file by Volker Dirr
	private static void writeRoomsTimetableDaysHorizontalHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, true);

		if (gt.rules.nInternalRooms == 0)
			tos << "    <h1>" << TimetableExport.tr("No rooms recorded in FET for %1.", "%1 is the institution name").arg(GlobalMembersTimetable_defs.protect2(gt.rules.institutionName)) << "</h1>\n";
		else
		{
			tos << "    <p><strong>" << TimetableExport.tr("Table of contents") << "</strong></p>\n";
			tos << "    <ul>\n";
			for (int room = 0; room < gt.rules.nInternalRooms; room++)
			{
				QString room_name = gt.rules.internalRoomsList[room].name;
				tos << "      <li><a href=\"" << "#table_" << GlobalMembersTimetableexport.hashRoomIDsTimetable.value(room_name) << "\">" << GlobalMembersTimetable_defs.protect2(room_name) << "</a></li>\n";
			}
			tos << "    </ul>\n    <p>&nbsp;</p>\n\n";

			for (int room = 0; room < gt.rules.nInternalRooms; room++)
			{
				tos << singleRoomsTimetableDaysHorizontalHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, room, saveTime, true);
				tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
			}
		}
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//writing the rooms' timetable html format to a file by Volker Dirr
	private static void writeRoomsTimetableDaysVerticalHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;

			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, true);

		if (gt.rules.nInternalRooms == 0)
			tos << "    <h1>" << TimetableExport.tr("No rooms recorded in FET for %1.", "%1 is the institution name").arg(GlobalMembersTimetable_defs.protect2(gt.rules.institutionName)) << "</h1>\n";
		else
		{
			tos << "    <p><strong>" << TimetableExport.tr("Table of contents") << "</strong></p>\n";
			tos << "    <ul>\n";
			for (int room = 0; room < gt.rules.nInternalRooms; room++)
			{
				QString room_name = gt.rules.internalRoomsList[room].name;
				tos << "      <li><a href=\"" << "#table_" << GlobalMembersTimetableexport.hashRoomIDsTimetable.value(room_name) << "\">" << GlobalMembersTimetable_defs.protect2(room_name) << "</a></li>\n";
			}
			tos << "    </ul>\n    <p>&nbsp;</p>\n\n";

			for (int room = 0; room < gt.rules.nInternalRooms; room++)
			{
				tos << singleRoomsTimetableDaysVerticalHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, room, saveTime, true);
				tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
			}
		}
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	// writing the rooms' timetable html format to a file by Volker Dirr
	private static void writeRoomsTimetableTimeHorizontalHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, false);

		if (gt.rules.nInternalRooms == 0)
			tos << "    <h1>" << TimetableExport.tr("No rooms recorded in FET for %1.", "%1 is the institution name").arg(GlobalMembersTimetable_defs.protect2(gt.rules.institutionName)) << "</h1>\n";
		else
		{
			QSet<int> tmp = new QSet<int>();
			tos << singleRoomsTimetableTimeHorizontalHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, gt.rules.nInternalRooms, ref tmp, saveTime, true);

		}
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//writing the rooms' timetable html format to a file by Volker Dirr
	private static void writeRoomsTimetableTimeVerticalHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, false);

		if (gt.rules.nInternalRooms == 0)
			tos << "    <h1>" << TimetableExport.tr("No rooms recorded in FET for %1.", "%1 is the institution name").arg(GlobalMembersTimetable_defs.protect2(gt.rules.institutionName)) << "</h1>\n";
		else
		{
			QSet<int> tmp = new QSet<int>();
			tos << singleRoomsTimetableTimeVerticalHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, gt.rules.nInternalRooms, ref tmp, saveTime, true);
		}
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//by Volker Dirr
	private static void writeRoomsTimetableTimeHorizontalDailyHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, true);
		tos << writeTOCDays(false);

		if (gt.rules.nInternalRooms == 0)
			tos << "    <h1>" << TimetableExport.tr("No rooms recorded in FET for %1.", "%1 is the institution name").arg(GlobalMembersTimetable_defs.protect2(gt.rules.institutionName)) << "</h1>\n";
		else
		{
			for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
			{
				QSet<int> tmp = new QSet<int>();
				tos << singleRoomsTimetableTimeHorizontalDailyHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, day, gt.rules.nInternalRooms, ref tmp, saveTime, true);

				tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
			}

		}
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//by Volker Dirr
	private static void writeRoomsTimetableTimeVerticalDailyHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, true);
		tos << writeTOCDays(false);

		if (gt.rules.nInternalRooms == 0)
			tos << "    <h1>" << TimetableExport.tr("No rooms recorded in FET for %1.", "%1 is the institution name").arg(GlobalMembersTimetable_defs.protect2(gt.rules.institutionName)) << "</h1>\n";
		else
		{
			for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
			{
				QSet<int> tmp = new QSet<int>();
				tos << singleRoomsTimetableTimeVerticalDailyHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, day, gt.rules.nInternalRooms, ref tmp, saveTime, true);

				tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
			}
		}
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//Print the subjects

	//XHTML generation code by Volker Dirr (http://timetabling.de/)
	private static void writeSubjectsTimetableDaysHorizontalHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, true);

		tos << "    <p><strong>" << TimetableExport.tr("Table of contents") << "</strong></p>\n";
		tos << "    <ul>\n";
		for (int i = 0; i < gt.rules.nInternalSubjects; i++)
		{
			tos << "      <li>\n        " << TimetableExport.tr("Subject");
			tos << " <a href=\"" << "#table_" << GlobalMembersTimetableexport.hashSubjectIDsTimetable.value(gt.rules.internalSubjectsList[i].name) << "\">" << gt.rules.internalSubjectsList[i].name << "</a>\n";
			tos << "      </li>\n";
		}
		tos << "    </ul>\n    <p>&nbsp;</p>\n\n";


		for (int subject = 0; subject < gt.rules.nInternalSubjects; subject++)
		{
			tos << singleSubjectsTimetableDaysHorizontalHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, subject, saveTime, true);
			tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
		}
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//XHTML generation code by Volker Dirr (http://timetabling.de/)
	private static void writeSubjectsTimetableDaysVerticalHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, true);

		tos << "    <p><strong>" << TimetableExport.tr("Table of contents") << "</strong></p>\n";
		tos << "    <ul>\n";
		for (int i = 0; i < gt.rules.nInternalSubjects; i++)
		{
			tos << "      <li>\n        " << TimetableExport.tr("Subject");
			tos << " <a href=\"" << "#table_" << GlobalMembersTimetableexport.hashSubjectIDsTimetable.value(gt.rules.internalSubjectsList[i].name) << "\">" << gt.rules.internalSubjectsList[i].name << "</a>\n";
			tos << "      </li>\n";
		}
		tos << "    </ul>\n    <p>&nbsp;</p>\n\n";

		for (int subject = 0; subject < gt.rules.nInternalSubjects; subject++)
		{
			tos << singleSubjectsTimetableDaysVerticalHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, subject, saveTime, true);
			tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
		}
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//XHTML generation code by Volker Dirr (http://timetabling.de/)
	private static void writeSubjectsTimetableTimeHorizontalHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, false);

		QSet<int> tmp = new QSet<int>();
		tos << singleSubjectsTimetableTimeHorizontalHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, gt.rules.nInternalSubjects, ref tmp, saveTime, true);

		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//XHTML generation code by Volker Dirr (http://timetabling.de/)
	private static void writeSubjectsTimetableTimeVerticalHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, false);

		QSet<int> tmp = new QSet<int>();
		tos << singleSubjectsTimetableTimeVerticalHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, gt.rules.nInternalSubjects, ref tmp, saveTime, true);
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//XHTML generation code by Volker Dirr (http://timetabling.de/)
	private static void writeSubjectsTimetableTimeHorizontalDailyHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, true);
		tos << writeTOCDays(false);

		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			QSet<int> tmp = new QSet<int>();
			tos << singleSubjectsTimetableTimeHorizontalDailyHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, day, gt.rules.nInternalSubjects, ref tmp, saveTime, true);

			tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
		}
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//XHTML generation code by Volker Dirr (http://timetabling.de/)
	private static void writeSubjectsTimetableTimeVerticalDailyHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, true);
		tos << writeTOCDays(false);

		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			QSet<int> tmp = new QSet<int>();
			tos << singleSubjectsTimetableTimeVerticalDailyHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, day, gt.rules.nInternalSubjects, ref tmp, saveTime, true);

			tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
		}

		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//Print the teachers free periods. Code by Volker Dirr (http://timetabling.de/)
	private static void writeTeachersFreePeriodsTimetableDaysHorizontalHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, true);

		tos << "    <ul>\n";
		tos << "      <li><a href=\"" << "#table_DETAILED\">" << TimetableExport.tr("Teachers' Free Periods") << " (" << tr("Detailed") << ")</a></li>\n";
		tos << "      <li><a href=\"" << "#table_LESS_DETAILED\">" << TimetableExport.tr("Teachers' Free Periods") << " (" << tr("Less detailed") << ")</a></li>\n";
		tos << "    </ul>\n    <p>&nbsp;</p>\n\n";

		tos << "    <div class=\"TEACHER_HAS_SINGLE_GAP\">" << TimetableExport.tr("Teacher has a single gap") << "</div>\n";
		tos << "    <div class=\"TEACHER_HAS_BORDER_GAP\">" << TimetableExport.tr("Teacher has a border gap") << "</div>\n";
		tos << "    <div class=\"TEACHER_HAS_BIG_GAP\">" << TimetableExport.tr("Teacher has a big gap") << "</div>\n";
		tos << "    <div class=\"TEACHER_MUST_COME_EARLIER\">" << TimetableExport.tr("Teacher must come earlier") << "</div>\n";
		tos << "    <div class=\"TEACHER_MUST_COME_MUCH_EARLIER\">" << TimetableExport.tr("Teacher must come much earlier") << "</div>\n";
		tos << "    <div class=\"TEACHER_MUST_STAY_LONGER\">" << TimetableExport.tr("Teacher must stay longer") << "</div>\n";
		tos << "    <div class=\"TEACHER_MUST_STAY_MUCH_LONGER\">" << TimetableExport.tr("Teacher must stay much longer") << "</div>\n";
		tos << "    <div class=\"TEACHER_HAS_A_FREE_DAY\">" << TimetableExport.tr("Teacher has a free day") << "</div>\n";
		tos << "    <div class=\"TEACHER_IS_NOT_AVAILABLE\">" << TimetableExport.tr("Teacher is not available") << "</div>\n";

		tos << "    <p>&nbsp;</p>\n\n";

		bool PRINT_DETAILED = true;
		do
		{
			tos << singleTeachersFreePeriodsTimetableDaysHorizontalHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, saveTime, PRINT_DETAILED);
			tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
			if (PRINT_DETAILED)
				PRINT_DETAILED = false;
			else
				PRINT_DETAILED = true;
		} while (!PRINT_DETAILED);
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//XHTML generation code by Volker Dirr (http://timetabling.de/)
	private static void writeTeachersFreePeriodsTimetableDaysVerticalHtml(QWidget parent, QString htmlfilename, QString saveTime, int placedActivities)
	{
		Debug.Assert(gt.rules.initialized && gt.rules.internalStructureComputed);
		Debug.Assert(students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready);

		//Now we print the results to an HTML file
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << writeHead(true, placedActivities, true);

		tos << "    <ul>\n";
		tos << "      <li><a href=\"" << "#table_DETAILED\">" << TimetableExport.tr("Teachers' Free Periods") << " (" << tr("Detailed") << ")</a></li>\n";
		tos << "      <li><a href=\"" << "#table_LESS_DETAILED\">" << TimetableExport.tr("Teachers' Free Periods") << " (" << tr("Less detailed") << ")</a></li>\n";
		tos << "    </ul>\n    <p>&nbsp;</p>\n\n";

		tos << "    <div class=\"TEACHER_HAS_SINGLE_GAP\">" << TimetableExport.tr("Teacher has a single gap") << "</div>\n";
		tos << "    <div class=\"TEACHER_HAS_BORDER_GAP\">" << TimetableExport.tr("Teacher has a border gap") << "</div>\n";
		tos << "    <div class=\"TEACHER_HAS_BIG_GAP\">" << TimetableExport.tr("Teacher has a big gap") << "</div>\n";
		tos << "    <div class=\"TEACHER_MUST_COME_EARLIER\">" << TimetableExport.tr("Teacher must come earlier") << "</div>\n";
		tos << "    <div class=\"TEACHER_MUST_COME_MUCH_EARLIER\">" << TimetableExport.tr("Teacher must come much earlier") << "</div>\n";
		tos << "    <div class=\"TEACHER_MUST_STAY_LONGER\">" << TimetableExport.tr("Teacher must stay longer") << "</div>\n";
		tos << "    <div class=\"TEACHER_MUST_STAY_MUCH_LONGER\">" << TimetableExport.tr("Teacher must stay much longer") << "</div>\n";
		tos << "    <div class=\"TEACHER_HAS_A_FREE_DAY\">" << TimetableExport.tr("Teacher has a free day") << "</div>\n";
		tos << "    <div class=\"TEACHER_IS_NOT_AVAILABLE\">" << TimetableExport.tr("Teacher is not available") << "</div>\n";

		tos << "    <p>&nbsp;</p>\n\n";

		bool PRINT_DETAILED = true;
		do
		{
			tos << singleTeachersFreePeriodsTimetableDaysVerticalHtml(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL, saveTime, PRINT_DETAILED);

			tos << "    <p class=\"back\"><a href=\"" << "#top\">" << TimetableExport.tr("back to the top") << "</a></p>\n\n";
			if (PRINT_DETAILED)
				PRINT_DETAILED = false;
			else
				PRINT_DETAILED = true;
		} while (!PRINT_DETAILED);
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), TimetableExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
		}
		file.close();
	}

	//the following functions return QStrings, because they are 'only' subfunctions to the writeXxxHtml functions

	//by Volker Dirr
	private static QString writeActivityStudents(int htmlLevel, int ai, int day, int hour, bool notAvailable, bool colspan, bool rowspan, bool printActivityTags)
	{
		QString tmp = new QString();
		int currentTime = day + gt.rules.nDaysPerWeek * hour;
		if (ai != GlobalMembersTimetable_defs.UNALLOCATED_ACTIVITY)
		{
			if (best_solution.times[ai] == currentTime)
			{
				Activity act = gt.rules.internalActivitiesList[ai];
				tmp += writeStartTagTDofActivities(htmlLevel, act, false, colspan, rowspan);
				tmp += writeSubjectAndActivityTags(htmlLevel, act, "div", " class=\"line1\"", false, printActivityTags);
				tmp += writeTeachers(htmlLevel, act, "div", " class=\"teacher line2\"");
				tmp += writeRoom(htmlLevel, ai, "div", " class=\"room line3\"");
				tmp += "</td>\n";
			}
			else
				tmp += "          <!-- span -->\n";
		}
		else
		{
			if (notAvailable && GlobalMembersTimetable_defs.PRINT_NOT_AVAILABLE_TIME_SLOTS)
			{
				tmp += writeNotAvailableSlot(htmlLevel, "");
			}
			else if (GlobalMembersGenerate_pre.breakDayHour[day][hour] && GlobalMembersTimetable_defs.PRINT_BREAK_TIME_SLOTS)
			{
				tmp += writeBreakSlot(htmlLevel, "");
			}
			else
			{
				tmp += writeEmpty(htmlLevel);
			}
		}
		return tmp;
	}

	//by Volker Dirr
	private static QString writeActivitiesStudents(int htmlLevel, QList<int> allActivities, bool printActivityTags)
	{
		QString tmp = new QString();
		if (htmlLevel >= 1)
			tmp += "          <td><table class=\"detailed\">";
		else
			tmp += "          <td><table>";
		if (htmlLevel >= 3)
			tmp += "<tr class=\"student line0\">";
		else
			tmp += "<tr>";
		for (int a = 0; a < allActivities.size(); a++)
		{
			int ai = allActivities[a];
			if (ai != GlobalMembersTimetable_defs.UNALLOCATED_ACTIVITY)
			{
				Activity act = gt.rules.internalActivitiesList[ai];
				tmp += writeStartTagTDofActivities(htmlLevel, act, true, false, false) + writeStudents(htmlLevel, act, "", "") + "</td>";
			}
		}
		tmp += "</tr>";
		if (htmlLevel >= 3)
			tmp += "<tr class=\"line1\">";
		else
			tmp += "<tr>";
		for (int a = 0; a < allActivities.size(); a++)
		{
			int ai = allActivities[a];
			if (ai != GlobalMembersTimetable_defs.UNALLOCATED_ACTIVITY)
			{
				Activity act = gt.rules.internalActivitiesList[ai];
				tmp += writeStartTagTDofActivities(htmlLevel, act, true, false, false) + writeSubjectAndActivityTags(htmlLevel, act, "", "", false, printActivityTags) + "</td>";
			}
		}
		tmp += "</tr>";
		if (htmlLevel >= 3)
			tmp += "<tr class=\"teacher line2\">";
		else
			tmp += "<tr>";
		for (int a = 0; a < allActivities.size(); a++)
		{
			int ai = allActivities[a];
			if (ai != GlobalMembersTimetable_defs.UNALLOCATED_ACTIVITY)
			{
				Activity act = gt.rules.internalActivitiesList[ai];
				tmp += writeStartTagTDofActivities(htmlLevel, act, true, false, false) + writeTeachers(htmlLevel, act, "", "") + "</td>";
			}
		}
		tmp += "</tr>";
		if (htmlLevel >= 3)
			tmp += "<tr class=\"room line3\">";
		else
			tmp += "<tr>";
		for (int a = 0; a < allActivities.size(); a++)
		{
			int ai = allActivities[a];
			if (ai != GlobalMembersTimetable_defs.UNALLOCATED_ACTIVITY)
			{
				Activity act = gt.rules.internalActivitiesList[ai];
				tmp += writeStartTagTDofActivities(htmlLevel, act, true, false, false) + writeRoom(htmlLevel, ai, "", "") + "</td>";
			}
		}
		tmp += "</tr>";
		tmp += "</table></td>\n";
		return tmp;
	}

	//by Volker Dirr
	private static QString writeActivityTeacher(int htmlLevel, int teacher, int day, int hour, bool colspan, bool rowspan, bool printActivityTags)
	{
		QString tmp = new QString();
		int ai = teachers_timetable_weekly[teacher][day][hour];
		int currentTime = day + gt.rules.nDaysPerWeek * hour;
		if (ai != GlobalMembersTimetable_defs.UNALLOCATED_ACTIVITY)
		{
			if (best_solution.times[ai] == currentTime)
			{
				Activity act = gt.rules.internalActivitiesList[ai];
				tmp += writeStartTagTDofActivities(htmlLevel, act, false, colspan, rowspan);
				tmp += writeStudents(htmlLevel, act, "div", " class=\"student line1\"");
				tmp += writeSubjectAndActivityTags(htmlLevel, act, "div", " class=\"line2\"", false, printActivityTags);
				tmp += writeRoom(htmlLevel, ai, "div", " class=\"room line3\"");
				tmp += "</td>\n";
			}
			else
				tmp += "          <!-- span -->\n";
		}
		else
		{
			if (GlobalMembersGenerate_pre.teacherNotAvailableDayHour[teacher][day][hour] && GlobalMembersTimetable_defs.PRINT_NOT_AVAILABLE_TIME_SLOTS)
			{
				tmp += writeNotAvailableSlot(htmlLevel, "");
			}
			else if (GlobalMembersGenerate_pre.breakDayHour[day][hour] && GlobalMembersTimetable_defs.PRINT_BREAK_TIME_SLOTS)
			{
				tmp += writeBreakSlot(htmlLevel, "");
			}
			else
			{
				tmp += writeEmpty(htmlLevel);
			}
		}
		return tmp;
	}

	//by Volker Dirr
	private static QString writeActivitiesTeachers(int htmlLevel, QList<int> allActivities, bool printActivityTags)
	{
		QString tmp = new QString();
		if (htmlLevel >= 1)
			tmp += "          <td><table class=\"detailed\">";
		else
			tmp += "          <td><table>";
		if (htmlLevel >= 3)
			tmp += "<tr class=\"teacher line0\">";
		else
			tmp += "<tr>";
		for (int a = 0; a < allActivities.size(); a++)
		{
			int ai = allActivities[a];
			if (ai != GlobalMembersTimetable_defs.UNALLOCATED_ACTIVITY)
			{
				Activity act = gt.rules.internalActivitiesList[ai];
				tmp += writeStartTagTDofActivities(htmlLevel, act, true, false, false) + writeTeachers(htmlLevel, act, "", "") + "</td>";
			}
		}
		tmp += "</tr>";
		if (htmlLevel >= 3)
			tmp += "<tr class=\"student line1\">";
		else
			tmp += "<tr>";
		for (int a = 0; a < allActivities.size(); a++)
		{
			int ai = allActivities[a];
			if (ai != GlobalMembersTimetable_defs.UNALLOCATED_ACTIVITY)
			{
				Activity act = gt.rules.internalActivitiesList[ai];
				tmp += writeStartTagTDofActivities(htmlLevel, act, true, false, false) + writeStudents(htmlLevel, act, "", "") + "</td>";
			}
		}
		tmp += "</tr>";
		if (htmlLevel >= 3)
			tmp += "<tr class=\"line2\">";
		else
			tmp += "<tr>";
		for (int a = 0; a < allActivities.size(); a++)
		{
			int ai = allActivities[a];
			if (ai != GlobalMembersTimetable_defs.UNALLOCATED_ACTIVITY)
			{
				Activity act = gt.rules.internalActivitiesList[ai];
				tmp += writeStartTagTDofActivities(htmlLevel, act, true, false, false) + writeSubjectAndActivityTags(htmlLevel, act, "", "", false, printActivityTags) + "</td>";
			}
		}
		tmp += "</tr>";

		if (htmlLevel >= 3)
			tmp += "<tr class=\"room line3\">";
		else
			tmp += "<tr>";
		for (int a = 0; a < allActivities.size(); a++)
		{
			int ai = allActivities[a];
			if (ai != GlobalMembersTimetable_defs.UNALLOCATED_ACTIVITY)
			{
				Activity act = gt.rules.internalActivitiesList[ai];
				tmp += writeStartTagTDofActivities(htmlLevel, act, true, false, false) + writeRoom(htmlLevel, ai, "", "") + "</td>";
			}
		}
		tmp += "</tr>";
		tmp += "</table></td>\n";
		return tmp;
	}

	//by Volker Dirr
	private static QString writeActivityRoom(int htmlLevel, int room, int day, int hour, bool colspan, bool rowspan, bool printActivityTags)
	{
		QString tmp = new QString();
		int ai = rooms_timetable_weekly[room][day][hour];
		int currentTime = day + gt.rules.nDaysPerWeek * hour;
		if (ai != GlobalMembersTimetable_defs.UNALLOCATED_ACTIVITY)
		{
			if (best_solution.times[ai] == currentTime)
			{
				Activity act = gt.rules.internalActivitiesList[ai];
				tmp += writeStartTagTDofActivities(htmlLevel, act, false, colspan, rowspan);
				tmp += writeStudents(htmlLevel, act, "div", " class=\"student line1\"");
				tmp += writeTeachers(htmlLevel, act, "div", " class=\"teacher line2\"");
				tmp += writeSubjectAndActivityTags(htmlLevel, act, "div", " class=\"line3\"", false, printActivityTags);
				tmp += "</td>\n";
			}
			else
				tmp += "          <!-- span -->\n";
		}
		else
		{
			if (GlobalMembersGenerate_pre.notAllowedRoomTimePercentages[room][day + hour * gt.rules.nDaysPerWeek] >= 0 && GlobalMembersTimetable_defs.PRINT_NOT_AVAILABLE_TIME_SLOTS)
			{
				tmp += writeNotAvailableSlot(htmlLevel, "");
			}
			else if (GlobalMembersGenerate_pre.breakDayHour[day][hour] && GlobalMembersTimetable_defs.PRINT_BREAK_TIME_SLOTS)
			{
				tmp += writeBreakSlot(htmlLevel, "");
			}
			else
			{
				tmp += writeEmpty(htmlLevel);
			}
		}
		return tmp;
	}

	//by Volker Dirr
	private static QString writeActivitiesRooms(int htmlLevel, QList<int> allActivities, bool printActivityTags)
	{
		QString tmp = new QString();
		if (htmlLevel >= 1)
			tmp += "          <td><table class=\"detailed\">";
		else
			tmp += "          <td><table>";
		if (htmlLevel >= 3)
			tmp += "<tr class=\"room line0\">";
		else
			tmp += "<tr>";
		for (int a = 0; a < allActivities.size(); a++)
		{
			int ai = allActivities[a];
			if (ai != GlobalMembersTimetable_defs.UNALLOCATED_ACTIVITY)
			{
				Activity act = gt.rules.internalActivitiesList[ai];
				tmp += writeStartTagTDofActivities(htmlLevel, act, true, false, false) + writeRoom(htmlLevel, ai, "", "") + "</td>";
			}
		}
		tmp += "</tr>";
		if (htmlLevel >= 3)
			tmp += "<tr class=\"student line1\">";
		else
			tmp += "<tr>";
		for (int a = 0; a < allActivities.size(); a++)
		{
			int ai = allActivities[a];
			if (ai != GlobalMembersTimetable_defs.UNALLOCATED_ACTIVITY)
			{
				Activity act = gt.rules.internalActivitiesList[ai];
				tmp += writeStartTagTDofActivities(htmlLevel, act, true, false, false) + writeStudents(htmlLevel, act, "", "") + "</td>";
			}
		}
		tmp += "</tr>";
		if (htmlLevel >= 3)
			tmp += "<tr class=\"teacher line2\">";
		else
			tmp += "<tr>";
		for (int a = 0; a < allActivities.size(); a++)
		{
			int ai = allActivities[a];
			if (ai != GlobalMembersTimetable_defs.UNALLOCATED_ACTIVITY)
			{
				Activity act = gt.rules.internalActivitiesList[ai];
				tmp += writeStartTagTDofActivities(htmlLevel, act, true, false, false) + writeTeachers(htmlLevel, act, "", "") + "</td>";
			}
		}
		tmp += "</tr>";
		if (htmlLevel >= 3)
			tmp += "<tr class=\"line3\">";
		else
			tmp += "<tr>";
		for (int a = 0; a < allActivities.size(); a++)
		{
			int ai = allActivities[a];
			if (ai != GlobalMembersTimetable_defs.UNALLOCATED_ACTIVITY)
			{
				Activity act = gt.rules.internalActivitiesList[ai];
				tmp += writeStartTagTDofActivities(htmlLevel, act, true, false, false) + writeSubjectAndActivityTags(htmlLevel, act, "", "", false, printActivityTags) + "</td>";
			}
		}
		tmp += "</tr>";

		tmp += "</table></td>\n";
		return tmp;
	}

	//by Volker Dirr
	private static QString writeActivitiesSubjects(int htmlLevel, QList<int> allActivities, bool printActivityTags)
	{
		QString tmp = new QString();
		if (allActivities.isEmpty())
		{
			tmp += writeEmpty(htmlLevel);
		}
		else
		{
			if (htmlLevel >= 1)
				tmp += "          <td><table class=\"detailed\">";
			else
							tmp += "          <td><table>";
			if (printActivityTags)
			{
				if (htmlLevel >= 3)
					tmp += "<tr class=\"line0 activitytag\">";
				else
					tmp += "<tr>";
				for (int a = 0; a < allActivities.size(); a++)
				{
					Activity act = gt.rules.internalActivitiesList[allActivities[a]];
					tmp += writeStartTagTDofActivities(htmlLevel, act, true, false, false) + writeSubjectAndActivityTags(htmlLevel, act, "", "", true, printActivityTags) + "</td>";
				}
				tmp += "</tr>";
			}
			if (htmlLevel >= 3)
				tmp += "<tr class=\"student line1\">";
			else
				tmp += "<tr>";
			for (int a = 0; a < allActivities.size(); a++)
			{
				Activity act = gt.rules.internalActivitiesList[allActivities[a]];
				tmp += writeStartTagTDofActivities(htmlLevel, act, true, false, false) + writeStudents(htmlLevel, act, "", "") + "</td>";
			}
			tmp += "</tr>";
			if (htmlLevel >= 3)
				tmp += "<tr class=\"teacher line2\">";
			else
				tmp += "<tr>";
			for (int a = 0; a < allActivities.size(); a++)
			{
				Activity act = gt.rules.internalActivitiesList[allActivities[a]];
				tmp += writeStartTagTDofActivities(htmlLevel, act, true, false, false) + writeTeachers(htmlLevel, act, "", "") + "</td>";
			}
			tmp += "</tr>";
			if (htmlLevel >= 3)
				tmp += "<tr class=\"room line3\">";
			else
				tmp += "<tr>";
			for (int a = 0; a < allActivities.size(); a++)
			{
				int ai = allActivities[a];
				Activity act = gt.rules.internalActivitiesList[ai];
				tmp += writeStartTagTDofActivities(htmlLevel, act, true, false, false) + writeRoom(htmlLevel, ai, "", "") + "</td>";
			}
			tmp += "</tr>";
			tmp += "</table></td>\n";
		}
		return tmp;
	}

	//the following functions return QStrings, because they are 'only' subfunctions to the writeActivity-iesXxx functions

	// by Volker Dirr
	private static QString writeHead(bool java, int placedActivities, bool printInstitution)
	{
		QString tmp = new QString();
		tmp += "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Strict//EN\"\n";
		tmp += "  \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\">\n\n";

		if (!GlobalMembersTimetable_defs.LANGUAGE_STYLE_RIGHT_TO_LEFT)
			tmp += "<html xmlns=\"http://www.w3.org/1999/xhtml\" lang=\"" + GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML + "\" xml:lang=\"" + GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML + "\">\n";
		else
			tmp += "<html xmlns=\"http://www.w3.org/1999/xhtml\" lang=\"" + GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML + "\" xml:lang=\"" + GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML + "\" dir=\"rtl\">\n";
		tmp += "  <head>\n";
		tmp += "    <title>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</title>\n";
		tmp += "    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\n";
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 1)
		{
			QString cssfilename = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1);

			if (cssfilename.right(4) == ".fet")
				cssfilename = cssfilename.left(cssfilename.length() - 4);
			//else if(INPUT_FILENAME_XML!="")
			//	cout<<"Minor problem - input file does not end in .fet extension - might be a problem when saving the timetables"<<" (file:"<<__FILE__<<", line:"<<__LINE__<<")"<<endl;

			cssfilename += "_" + GlobalMembersTimetableexport.STYLESHEET_CSS;
			if (INPUT_FILENAME_XML == "")
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: cssfilename=STYLESHEET_CSS;
				cssfilename.CopyFrom(GlobalMembersTimetableexport.STYLESHEET_CSS);
			tmp += "    <link rel=\"stylesheet\" media=\"all\" href=\"" + cssfilename + "\" type=\"text/css\" />\n";
		}
		if (java)
		{
			if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 5) // the following JavaScript code is pretty similar to an example of Les Richardson
			{
				tmp += "    <meta http-equiv=\"Content-Script-Type\" content=\"text/javascript\" />\n";
				tmp += "    <script type=\"text/javascript\">\n";
				tmp += "      function highlight(classval) {\n";
				tmp += "        var spans = document.getElementsByTagName('span');\n";
				tmp += "        for(var i=0; spans.length>i; i++) {\n";
				tmp += "          if (spans[i].className == classval) {\n";
				tmp += "            spans[i].style.backgroundColor = 'lime';\n";
				tmp += "          } else {\n";
				tmp += "            spans[i].style.backgroundColor = 'white';\n";
				tmp += "          }\n";
				tmp += "        }\n";
				tmp += "      }\n";
				tmp += "    </script>\n";
			}
		}
		tmp += "  </head>\n\n";
		tmp += "  <body id=\"top\">\n";
		if (placedActivities != gt.rules.nInternalActivities)
			tmp += "    <h1>" + TimetableExport.tr("Warning! Only %1 out of %2 activities placed!").arg(placedActivities).arg(gt.rules.nInternalActivities) + "</h1>\n";
		if (printInstitution)
		{
			tmp += "    <table>\n      <tr align=\"left\" valign=\"top\">\n        <th>" + TimetableExport.tr("Institution name") + ":</th>\n        <td>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</td>\n      </tr>\n    </table>\n";
			tmp += "    <table>\n      <tr align=\"left\" valign=\"top\">\n        <th>" + TimetableExport.tr("Comments") + ":</th>\n        <td>" + GlobalMembersTimetable_defs.protect2(gt.rules.comments).replace(new QString("\n"), new QString("<br />\n")) + "</td>\n      </tr>\n    </table>\n";
		}
		return tmp;
	}

	// by Volker Dirr
	private static QString writeTOCDays(bool detailed)
	{
		QString tmp = new QString();
		tmp += "    <p><strong>" + TimetableExport.tr("Table of contents") + "</strong></p>\n";
		tmp += "    <ul>\n";
		for (int day = 0; day < gt.rules.nDaysPerWeek; day++)
		{
			tmp += "      <li>\n        ";
			if (detailed)
			{
				tmp += " <a href=\"";
				tmp += "#table_" + GlobalMembersTimetableexport.hashDayIDsTimetable.value(gt.rules.daysOfTheWeek[day]) + "_DETAILED\">" + GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + " (" + tr("Detailed") + ")</a> /";
				tmp += " <a href=\"";
				tmp += "#table_" + GlobalMembersTimetableexport.hashDayIDsTimetable.value(gt.rules.daysOfTheWeek[day]) + "\">" + GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + " (" + tr("Less detailed") + ")</a>\n";
			}
			else
			{
				tmp += " <a href=\"";
				tmp += "#table_" + GlobalMembersTimetableexport.hashDayIDsTimetable.value(gt.rules.daysOfTheWeek[day]) + "\">" + GlobalMembersTimetable_defs.protect2(gt.rules.daysOfTheWeek[day]) + "</a>\n";
			}
			tmp += "          </li>\n";
		}
		tmp += "    </ul>\n    <p>&nbsp;</p>\n";
		return tmp;
	}

	// by Volker Dirr
	private static QString writeStartTagTDofActivities(int htmlLevel, Activity act, bool detailed, bool colspan, bool rowspan)
	{
		QString tmp = new QString();
		Debug.Assert(!(colspan && rowspan));
		if (detailed)
			Debug.Assert(!colspan && !rowspan);
		else
			tmp += "          ";
		tmp += "<td";
		if (rowspan && act.duration > 1)
			tmp += " rowspan=\"" + CustomFETString.number(act.duration) + "\"";
		if (colspan && act.duration > 1)
			tmp += " colspan=\"" + CustomFETString.number(act.duration) + "\"";
		if (htmlLevel == 6)
		{
			tmp += " class=\"";
			if (act.subjectName.size() > 0)
			{
				tmp += "s_" + GlobalMembersTimetableexport.hashSubjectIDsTimetable.value(act.subjectName);
			}
			if (act.activityTagsNames.size() > 0)
			{
				foreach (QString atn, act.activityTagsNames) tmp += " at_" + GlobalMembersTimetableexport.hashActivityTagIDsTimetable.value(atn);
			}
			if (act.studentsNames.size() > 0)
			{
				foreach (QString st, act.studentsNames) tmp += " ss_" + GlobalMembersTimetableexport.hashStudentIDsTimetable.value(st);
			}
			if (act.teachersNames.size() > 0)
			{
				foreach (QString t, act.teachersNames) tmp += " t_" + GlobalMembersTimetableexport.hashTeacherIDsTimetable.value(t);
			}
			//i need ai for this!!! so i need a parameter ai?! //TODO
			/*int r=best_solution.rooms[ai];
			if(r!=UNALLOCATED_SPACE && r!=UNSPECIFIED_ROOM){
				tmp+=" room_"+protect2id(gt.rules.internalRoomsList[r]->name);
			}*/
			if (detailed)
				tmp += " detailed";
			tmp += "\"";
		}
		if (detailed && htmlLevel >= 1 && htmlLevel <= 5)
			tmp += " class=\"detailed\"";
		tmp += ">";
		return tmp;
	}

	// by Volker Dirr
	private static QString writeSubjectAndActivityTags(int htmlLevel, Activity act, QString startTag, QString startTagAttribute, bool activityTagsOnly, bool printActivityTags)
	{
		QString tmp = new QString();
		if (act.subjectName.size() > 0 || act.activityTagsNames.size() > 0)
		{
			if (startTag == "div" && htmlLevel >= 3)
				tmp += "<" + startTag + startTagAttribute + ">";
			if (act.subjectName.size() > 0 && !activityTagsOnly)
			{
				switch (htmlLevel)
				{
					case 3 :
						tmp += "<span class=\"subject\">" + GlobalMembersTimetable_defs.protect2(act.subjectName) + "</span>";
						break;
					case 4 :
						tmp += "<span class=\"subject\"><span class=\"s_" + GlobalMembersTimetableexport.hashSubjectIDsTimetable.value(act.subjectName) + "\">" + GlobalMembersTimetable_defs.protect2(act.subjectName) + "</span></span>";
						break;
					case 5 :
						;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
					case 6 :
						tmp += "<span class=\"subject\"><span class=\"s_" + GlobalMembersTimetableexport.hashSubjectIDsTimetable.value(act.subjectName) + "\" onmouseover=\"highlight('s_" + GlobalMembersTimetableexport.hashSubjectIDsTimetable.value(act.subjectName) + "')\">" + GlobalMembersTimetable_defs.protect2(act.subjectName) + "</span></span>";
						break;
					default:
						tmp += GlobalMembersTimetable_defs.protect2(act.subjectName);
						break;
				}
				if (act.activityTagsNames.size() > 0 && printActivityTags)
				{
					tmp += " ";
				}
			}
			if (act.activityTagsNames.size() > 0 && printActivityTags)
			{
				if (!activityTagsOnly)
				{
					if (htmlLevel >= 3)
					{
						tmp += "<span class=\"activitytag\">";
					}
				}
				foreach (QString atn, act.activityTagsNames)
				{
					switch (htmlLevel)
					{
						case 3 :
							tmp += GlobalMembersTimetable_defs.protect2(atn);
							break;
						case 4 :
							tmp += "<span class=\"at_" + GlobalMembersTimetableexport.hashActivityTagIDsTimetable.value(atn) + "\">" + GlobalMembersTimetable_defs.protect2(atn) + "</span>";
							break;
						case 5 :
							;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
						case 6 :
							tmp += "<span class=\"at_" + GlobalMembersTimetableexport.hashActivityTagIDsTimetable.value(atn) + "\" onmouseover=\"highlight('at_" + GlobalMembersTimetableexport.hashActivityTagIDsTimetable.value(atn) + "')\">" + GlobalMembersTimetable_defs.protect2(atn) + "</span>";
							break;
						default:
							tmp += GlobalMembersTimetable_defs.protect2(atn);
							break;
					}
					tmp += ", ";
				}
				tmp.remove(tmp.size() - 2, 2);
				if (!activityTagsOnly)
				{
					if (htmlLevel >= 3)
					{
						tmp += "</span>";
					}
				}
			}
			if (startTag == "div")
			{
				if (htmlLevel >= 3)
					tmp += "</div>";
				else
					tmp += "<br />";
			}
		}
		return tmp;
	}

	// by Volker Dirr
	private static QString writeStudents(int htmlLevel, Activity act, QString startTag, QString startTagAttribute)
	{
		QString tmp = new QString();
		if (act.studentsNames.size() > 0)
		{
			if (startTag == "div" && htmlLevel >= 3)
				tmp += "<" + startTag + startTagAttribute + ">";
			foreach (QString st, act.studentsNames)
			{
				switch (htmlLevel)
				{
					case 4 :
						tmp += "<span class=\"ss_" + GlobalMembersTimetableexport.hashStudentIDsTimetable.value(st) + "\">" + GlobalMembersTimetable_defs.protect2(st) + "</span>";
						break;
					case 5 :
						;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
					case 6 :
						tmp += "<span class=\"ss_" + GlobalMembersTimetableexport.hashStudentIDsTimetable.value(st) + "\" onmouseover=\"highlight('ss_" + GlobalMembersTimetableexport.hashStudentIDsTimetable.value(st) + "')\">" + GlobalMembersTimetable_defs.protect2(st) + "</span>";
						break;
					default:
						tmp += GlobalMembersTimetable_defs.protect2(st);
						break;
				}
				tmp += ", ";
			}
			tmp.remove(tmp.size() - 2, 2);
			if (startTag == "div")
			{
				if (htmlLevel >= 3)
					tmp += "</div>";
				else
					tmp += "<br />";
			}
		}
		return tmp;
	}

	// by Volker Dirr
	private static QString writeTeachers(int htmlLevel, Activity act, QString startTag, QString startTagAttribute)
	{
		QString tmp = new QString();
		if (act.teachersNames.size() > 0)
		{
			if (startTag == "div" && htmlLevel >= 3)
				tmp += "<" + startTag + startTagAttribute + ">";
			foreach (QString t, act.teachersNames)
			{
				switch (htmlLevel)
				{
					case 4 :
						tmp += "<span class=\"t_" + GlobalMembersTimetableexport.hashTeacherIDsTimetable.value(t) + "\">" + GlobalMembersTimetable_defs.protect2(t) + "</span>";
						break;
					case 5 :
						;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
					case 6 :
						tmp += "<span class=\"t_" + GlobalMembersTimetableexport.hashTeacherIDsTimetable.value(t) + "\" onmouseover=\"highlight('t_" + GlobalMembersTimetableexport.hashTeacherIDsTimetable.value(t) + "')\">" + GlobalMembersTimetable_defs.protect2(t) + "</span>";
						break;
					default:
						tmp += GlobalMembersTimetable_defs.protect2(t);
						break;
				}
				tmp += ", ";
			}
			tmp.remove(tmp.size() - 2, 2);
			if (startTag == "div")
			{
				if (htmlLevel >= 3)
					tmp += "</div>";
				else
					tmp += "<br />";
			}
		}
		return tmp;
	}

	// by Volker Dirr
	private static QString writeRoom(int htmlLevel, int ai, QString startTag, QString startTagAttribute)
	{
		QString tmp = new QString();
		int r = best_solution.rooms[ai];
		if (r != GlobalMembersTimetable_defs.UNALLOCATED_SPACE && r != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM)
		{
			if (startTag == "div" && htmlLevel >= 3)
				tmp += "<" + startTag + startTagAttribute + ">";
			switch (htmlLevel)
			{
				case 4 :
					tmp += "<span class=\"r_" + GlobalMembersTimetableexport.hashRoomIDsTimetable.value(gt.rules.internalRoomsList[r].name) + "\">" + GlobalMembersTimetable_defs.protect2(gt.rules.internalRoomsList[r].name) + "</span>";
					break;
				case 5 :
					;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
				case 6 :
					tmp += "<span class=\"r_" + GlobalMembersTimetableexport.hashRoomIDsTimetable.value(gt.rules.internalRoomsList[r].name) + "\" onmouseover=\"highlight('r_" + GlobalMembersTimetableexport.hashRoomIDsTimetable.value(gt.rules.internalRoomsList[r].name) + "')\">" + GlobalMembersTimetable_defs.protect2(gt.rules.internalRoomsList[r].name) + "</span>";
					break;
				default:
					tmp += GlobalMembersTimetable_defs.protect2(gt.rules.internalRoomsList[r].name);
					break;
			}
			if (startTag == "div")
			{
				if (htmlLevel >= 3)
					tmp += "</div>";
				else
					tmp += "<br />";
			}
		}
		return tmp;
	}

	// by Volker Dirr
	private static QString writeNotAvailableSlot(int htmlLevel, QString weight)
	{
		QString tmp = new QString();
		//weight=" "+weight;
		switch (htmlLevel)
		{
			case 3 :
				;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
			case 4 :
				tmp = "          <td class=\"notAvailable\"><span class=\"notAvailable\">" + GlobalMembersTimetable_defs.protect2(GlobalMembersTimetableexport.STRING_NOT_AVAILABLE_TIME_SLOT) + weight + "</span></td>\n";
				break;
			case 5 :
				;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
			case 6 :
				tmp = "          <td class=\"notAvailable\"><span class=\"notAvailable\" onmouseover=\"highlight('notAvailable')\">" + GlobalMembersTimetable_defs.protect2(GlobalMembersTimetableexport.STRING_NOT_AVAILABLE_TIME_SLOT) + weight + "</span></td>\n";
				break;
			default:
				tmp = "          <td>" + GlobalMembersTimetable_defs.protect2(GlobalMembersTimetableexport.STRING_NOT_AVAILABLE_TIME_SLOT) + weight + "</td>\n";
				break;
		}
		return tmp;
	}

	// by Volker Dirr
	private static QString writeBreakSlot(int htmlLevel, QString weight)
	{
		QString tmp = new QString();
		//weight=" "+weight;
		switch (htmlLevel)
		{
			case 3 :
				;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
			case 4 :
				tmp = "          <td class=\"break\"><span class=\"break\">" + GlobalMembersTimetable_defs.protect2(GlobalMembersTimetableexport.STRING_BREAK_SLOT) + weight + "</span></td>\n";
				break;
			case 5 :
				;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
			case 6 :
				tmp = "          <td class=\"break\"><span class=\"break\" onmouseover=\"highlight('break')\">" + GlobalMembersTimetable_defs.protect2(GlobalMembersTimetableexport.STRING_BREAK_SLOT) + weight + "</span></td>\n";
				break;
			default:
				tmp = "          <td>" + GlobalMembersTimetable_defs.protect2(GlobalMembersTimetableexport.STRING_BREAK_SLOT) + weight + "</td>\n";
				break;
		}
		return tmp;
	}

	// by Volker Dirr
	private static QString writeEmpty(int htmlLevel)
	{
		QString tmp = new QString();
		switch (htmlLevel)
		{
			case 3 :
				;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
			case 4 :
				tmp = "          <td class=\"empty\"><span class=\"empty\">" + GlobalMembersTimetable_defs.protect2(GlobalMembersTimetableexport.STRING_EMPTY_SLOT) + "</span></td>\n";
				break;
			case 5 :
				;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
			case 6 :
				tmp = "          <td class=\"empty\"><span class=\"empty\" onmouseover=\"highlight('empty')\">" + GlobalMembersTimetable_defs.protect2(GlobalMembersTimetableexport.STRING_EMPTY_SLOT) + "</span></td>\n";
				break;
			default:
				tmp = "          <td>" + GlobalMembersTimetable_defs.protect2(GlobalMembersTimetableexport.STRING_EMPTY_SLOT) + "</td>\n";
				break;
		}
		return tmp;
	}
}

//C++ TO C# CONVERTER WARNING: The declaration of the following method implementation was not found:
//ORIGINAL LINE: TimetableExport::TimetableExport()


public partial class TimetableExport
{
	public TimetableExport()
	{
	}
}