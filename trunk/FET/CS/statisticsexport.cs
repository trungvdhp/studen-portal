using System.Diagnostics;

public static class GlobalMembersStatisticsexport
{



	// BE CAREFUL: DON'T USE INTERNAL VARIABLES HERE, because maybe computeInternalStructure() is not done!






	//#include <QApplication>
	//extern QApplication* pqapplication;

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern Timetable gt;

	internal static QHash<QString, QString> hashSubjectIDsStatistics = new QHash<QString, QString>();
	internal static QHash<QString, QString> hashActivityTagIDsStatistics = new QHash<QString, QString>();
	internal static QHash<QString, QString> hashStudentIDsStatistics = new QHash<QString, QString>();
	internal static QHash<QString, QString> hashTeacherIDsStatistics = new QHash<QString, QString>();
	internal static QHash<QString, QString> hashRoomIDsStatistics = new QHash<QString, QString>();
	internal static QHash<QString, QString> hashDayIDsStatistics = new QHash<QString, QString>();

	//extern bool simulation_running;	//needed?

	public static QHash <QString, int> teachersTotalNumberOfHours = new QHash();
	public static QHash <QString, int> teachersTotalNumberOfHours2 = new QHash();
	public static QHash <QString, int> studentsTotalNumberOfHours = new QHash();
	public static QHash <QString, int> studentsTotalNumberOfHours2 = new QHash();
	public static QHash <QString, int> subjectsTotalNumberOfHours = new QHash();
	public static QHash <QString, int> subjectsTotalNumberOfHours4 = new QHash();
	public static QStringList allStudentsNames = new QStringList(); //NOT QSet <QString>!!! Because that do an incorrect order of the lists!
	public static QStringList allTeachersNames = new QStringList(); //NOT QSet <QString>!!! Because that do an incorrect order of the lists!
	public static QStringList allSubjectsNames = new QStringList(); //NOT QSet <QString>!!! Because that do an incorrect order of the lists!
	internal static QMultiHash <QString, int> studentsActivities = new QMultiHash();
	internal static QMultiHash <QString, int> teachersActivities = new QMultiHash();
	internal static QMultiHash <QString, int> subjectsActivities = new QMultiHash();

	//TODO: use the external string!!!
	//extern const QString STRING_EMPTY_SLOT;
	public const QString STRING_EMPTY_SLOT_STATISTICS = "---";

	public const string TEACHERS_STUDENTS_STATISTICS = "teachers_students.html";
	public const string TEACHERS_SUBJECTS_STATISTICS = "teachers_subjects.html";
	public const string STUDENTS_TEACHERS_STATISTICS = "students_teachers.html";
	public const string STUDENTS_SUBJECTS_STATISTICS = "students_subjects.html";
	public const string SUBJECTS_TEACHERS_STATISTICS = "subjects_teachers.html";
	public const string SUBJECTS_STUDENTS_STATISTICS = "subjects_students.html";
	public const string STYLESHEET_STATISTICS = "stylesheet.css";
	public const string INDEX_STATISTICS = "index.html";

	public static QString DIRECTORY_STATISTICS = new QString();
	public static QString PREFIX_STATISTICS = new QString();
}

/*
File statisticsexport.cpp
*/

/***************************************************************************
                                FET
                          -------------------
   copyright            : (C) by Lalescu Liviu
    email                : Please see http://lalescu.ro/liviu/ for details about contacting Liviu Lalescu (in particular, you can find here the e-mail address)
 ***************************************************************************
                      statisticsexport.cpp  -  description
                             -------------------
    begin                : Sep 2008
    copyright            : (C) by Volker Dirr
                         : http://www.timetabling.de/
 ***************************************************************************
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 ***************************************************************************/

// Code contributed by Volker Dirr ( http://www.timetabling.de/ )
// Many thanks to Liviu Lalescu. He told me some speed optimizations.

#if NDEBUG
#endif
/*
File statisticsexport.h
*/

/***************************************************************************
                                FET
                          -------------------
   copyright            : (C) by Lalescu Liviu
    email                : Please see http://lalescu.ro/liviu/ for details about contacting Liviu Lalescu (in particular, you can find here the e-mail address)
 ***************************************************************************
                      statisticsexport.h  -  description
                             -------------------
    begin                : Sep 2008
    copyright            : (C) by Volker Dirr
                         : http://www.timetabling.de/
 ***************************************************************************
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 ***************************************************************************/




public partial class StatisticsExport: QObject
{
	Q_OBJECT public: StatisticsExport();
	public void Dispose()
	{
	}

	private static void exportStatistics(QWidget parent)
	{
		Debug.Assert(gt.rules.initialized);
		Debug.Assert(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 0);
		Debug.Assert(GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL <= 6);

		computeHashForIDsStatistics();

		GlobalMembersStatisticsexport.DIRECTORY_STATISTICS = GlobalMembersTimetable_defs.OUTPUT_DIR + GlobalMembersTimetable_defs.FILE_SEP + "statistics";

		if (INPUT_FILENAME_XML == "")
			GlobalMembersStatisticsexport.DIRECTORY_STATISTICS.append(GlobalMembersTimetable_defs.FILE_SEP + "unnamed");
		else
		{
			GlobalMembersStatisticsexport.DIRECTORY_STATISTICS.append(GlobalMembersTimetable_defs.FILE_SEP + INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1));

			if (GlobalMembersStatisticsexport.DIRECTORY_STATISTICS.right(4) == ".fet")
				GlobalMembersStatisticsexport.DIRECTORY_STATISTICS = GlobalMembersStatisticsexport.DIRECTORY_STATISTICS.left(GlobalMembersStatisticsexport.DIRECTORY_STATISTICS.length() - 4);
			//else if(INPUT_FILENAME_XML!="")
			//	cout<<"Minor problem - input file does not end in .fet extension - might be a problem when saving the timetables"<<" (file:"<<__FILE__<<", line:"<<__LINE__<<")"<<endl;
		}

		GlobalMembersStatisticsexport.PREFIX_STATISTICS = GlobalMembersStatisticsexport.DIRECTORY_STATISTICS + GlobalMembersTimetable_defs.FILE_SEP;

		int ok = QMessageBox.question(parent, tr("FET Question"), StatisticsExport.tr("Do you want to export detailed statistic files into directory %1 as html files?").arg(QDir.toNativeSeparators(GlobalMembersStatisticsexport.DIRECTORY_STATISTICS)), QMessageBox.Yes | QMessageBox.No);
		if (ok == QMessageBox.No)
			return;

		/* need if i use iTeachersList. Currently unneeded. please remove commented asserts in other functions if this is needed again!
		bool tmp=gt.rules.computeInternalStructure();
		if(!tmp){
			QMessageBox::critical(parent, tr("FET critical"),
			StatisticsExport::tr("Incorrect data")+"\n");
			return;
			assert(0==1);
		}*/

		QDir dir = new QDir();
		if (!dir.exists(GlobalMembersTimetable_defs.OUTPUT_DIR))
			dir.mkpath(GlobalMembersTimetable_defs.OUTPUT_DIR);
		if (!dir.exists(GlobalMembersStatisticsexport.DIRECTORY_STATISTICS))
			dir.mkpath(GlobalMembersStatisticsexport.DIRECTORY_STATISTICS);

		QSet<QString> allStudentsNamesSet = new QSet<QString>();
		GlobalMembersStatisticsexport.allStudentsNames.clear();
		foreach (StudentsYear * sty, gt.rules.yearsList)
		{
			if (!allStudentsNamesSet.contains(sty.name))
			{
				GlobalMembersStatisticsexport.allStudentsNames << sty.name;
				allStudentsNamesSet.insert(sty.name);
			}
			foreach (StudentsGroup * stg, sty.groupsList)
			{
				if (!allStudentsNamesSet.contains(stg.name))
				{
					GlobalMembersStatisticsexport.allStudentsNames << stg.name;
					allStudentsNamesSet.insert(stg.name);
				}
				foreach (StudentsSubgroup * sts, stg.subgroupsList)
				{
					if (!allStudentsNamesSet.contains(sts.name))
					{
						GlobalMembersStatisticsexport.allStudentsNames << sts.name;
						allStudentsNamesSet.insert(sts.name);
					}
				}
			}
		}

		GlobalMembersStatisticsexport.allTeachersNames.clear(); // just needed, because i don't need to care about correct iTeacherList if i do it this way.
		foreach (Teacher * t, gt.rules.teachersList) //  So i don't need gt.rules.computeInternalStructure();
		{
			GlobalMembersStatisticsexport.allTeachersNames << t.name;
		}

		GlobalMembersStatisticsexport.allSubjectsNames.clear(); // just done, because i always want to do it the same way + it is faster
		foreach (Subject * s, gt.rules.subjectsList) // Also don't display empty subjects is easier
		{
			GlobalMembersStatisticsexport.allSubjectsNames << s.name;
		}

		GlobalMembersStatisticsexport.studentsTotalNumberOfHours.clear();
		GlobalMembersStatisticsexport.studentsTotalNumberOfHours2.clear();

		GlobalMembersStatisticsexport.subjectsTotalNumberOfHours.clear();
		GlobalMembersStatisticsexport.subjectsTotalNumberOfHours4.clear();

		GlobalMembersStatisticsexport.teachersTotalNumberOfHours.clear();
		GlobalMembersStatisticsexport.teachersTotalNumberOfHours2.clear();

		GlobalMembersStatisticsexport.studentsActivities.clear();
		GlobalMembersStatisticsexport.subjectsActivities.clear();
		GlobalMembersStatisticsexport.teachersActivities.clear();

		Activity act;

		//QProgressDialog progress(parent);
		//progress.setLabelText(tr("Processing activities...please wait"));
		//progress.setRange(0,gt.rules.activitiesList.count());
		//progress.setModal(true);

		for (int ai = 0; ai < gt.rules.activitiesList.size(); ai++)
		{
			//progress.setValue(ai);
			//pqapplication->processEvents();

			act = gt.rules.activitiesList[ai];
			if (act.active)
			{
					GlobalMembersStatisticsexport.subjectsActivities.insert(act.subjectName, ai);
					int tmp = GlobalMembersStatisticsexport.subjectsTotalNumberOfHours.value(act.subjectName) + act.duration;
					GlobalMembersStatisticsexport.subjectsTotalNumberOfHours.insert(act.subjectName, tmp); // (1) so teamlearning-teaching is not counted twice!
					foreach (QString t, act.teachersNames)
					{
						GlobalMembersStatisticsexport.teachersActivities.insert(t, ai);
						tmp = GlobalMembersStatisticsexport.teachersTotalNumberOfHours.value(t) + act.duration;
						GlobalMembersStatisticsexport.teachersTotalNumberOfHours.insert(t, tmp); // (3)
						//subjectstTotalNumberOfHours2[act->subjectIndex]+=duration;				// (1) so teamteaching is counted twice!
					}
					foreach (QString st, act.studentsNames)
					{
						GlobalMembersStatisticsexport.studentsActivities.insert(st, ai);
						tmp = GlobalMembersStatisticsexport.studentsTotalNumberOfHours.value(st) + act.duration;
						GlobalMembersStatisticsexport.studentsTotalNumberOfHours.insert(st, tmp); // (2)
						//subjectstTotalNumberOfHours3[act->subjectIndex]+=duration;				// (1) so teamlearning is counted twice!
					}
					foreach (QString t, act.teachersNames)
					{
						tmp = GlobalMembersStatisticsexport.teachersTotalNumberOfHours2.value(t);
						tmp += act.duration * act.studentsNames.count();
						GlobalMembersStatisticsexport.teachersTotalNumberOfHours2.insert(t, tmp); // (3)
					}
					foreach (QString st, act.studentsNames)
					{
						tmp = GlobalMembersStatisticsexport.studentsTotalNumberOfHours2.value(st);
						tmp += act.duration * act.teachersNames.count();
						GlobalMembersStatisticsexport.studentsTotalNumberOfHours2.insert(st, tmp); // (2)
					}
					tmp = GlobalMembersStatisticsexport.subjectsTotalNumberOfHours4.value(act.subjectName);
					tmp += act.duration * act.studentsNames.count() * act.teachersNames.count();
					GlobalMembersStatisticsexport.subjectsTotalNumberOfHours4.insert(act.subjectName, tmp); // (1) so teamlearning-teaching is counted twice!
			}
		}
		//progress.setValue(gt.rules.activitiesList.count());
		QStringList tmp = new QStringList();
		tmp.clear();
		foreach (QString students, GlobalMembersStatisticsexport.allStudentsNames)
		{
			if (GlobalMembersStatisticsexport.studentsTotalNumberOfHours.value(students) == 0 && GlobalMembersStatisticsexport.studentsTotalNumberOfHours2.value(students) == 0)
			{
				GlobalMembersStatisticsexport.studentsTotalNumberOfHours.remove(students);
				GlobalMembersStatisticsexport.studentsTotalNumberOfHours2.remove(students);
			}
			else
				tmp << students;
		}
		GlobalMembersStatisticsexport.allStudentsNames = tmp;
		tmp.clear();
		foreach (QString teachers, GlobalMembersStatisticsexport.allTeachersNames)
		{
			if (GlobalMembersStatisticsexport.teachersTotalNumberOfHours.value(teachers) == 0 && GlobalMembersStatisticsexport.teachersTotalNumberOfHours2.value(teachers) == 0)
			{
					GlobalMembersStatisticsexport.teachersTotalNumberOfHours.remove(teachers);
					GlobalMembersStatisticsexport.teachersTotalNumberOfHours2.remove(teachers);
			}
			else
				tmp << teachers;
		}
		GlobalMembersStatisticsexport.allTeachersNames = tmp;
		tmp.clear();
		foreach (QString subjects, GlobalMembersStatisticsexport.allSubjectsNames)
		{
			if (GlobalMembersStatisticsexport.subjectsTotalNumberOfHours.value(subjects) == 0 && GlobalMembersStatisticsexport.subjectsTotalNumberOfHours4.value(subjects) == 0)
			{
				GlobalMembersStatisticsexport.subjectsTotalNumberOfHours.remove(subjects);
				GlobalMembersStatisticsexport.subjectsTotalNumberOfHours4.remove(subjects);
			}
			else
				tmp << subjects;
		}
		GlobalMembersStatisticsexport.allSubjectsNames = tmp;
		tmp.clear();

		QDate dat = QDate.currentDate();
		QTime tim = QTime.currentTime();
		QLocale loc = new QLocale(GlobalMembersTimetable_defs.FET_LANGUAGE);
		QString sTime = loc.toString(dat, QLocale.ShortFormat) + " " + loc.toString(tim, QLocale.ShortFormat);

		ok = true;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: ok=exportStatisticsStylesheetCss(parent, sTime);
		ok = exportStatisticsStylesheetCss(parent, new QString(sTime));
		if (ok != 0)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: ok=exportStatisticsIndex(parent, sTime);
			ok = exportStatisticsIndex(parent, new QString(sTime));
		if (ok != 0)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: ok=exportStatisticsTeachersSubjects(parent, sTime);
			ok = exportStatisticsTeachersSubjects(parent, new QString(sTime));
		if (ok != 0)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: ok=exportStatisticsSubjectsTeachers(parent, sTime);
			ok = exportStatisticsSubjectsTeachers(parent, new QString(sTime));
		if (ok != 0)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: ok=exportStatisticsTeachersStudents(parent, sTime);
			ok = exportStatisticsTeachersStudents(parent, new QString(sTime));
		if (ok != 0)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: ok=exportStatisticsStudentsTeachers(parent, sTime);
			ok = exportStatisticsStudentsTeachers(parent, new QString(sTime));
		if (ok != 0)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: ok=exportStatisticsSubjectsStudents(parent, sTime);
			ok = exportStatisticsSubjectsStudents(parent, new QString(sTime));
		if (ok != 0)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: ok=exportStatisticsStudentsSubjects(parent, sTime);
			ok = exportStatisticsStudentsSubjects(parent, new QString(sTime));

		if (ok != 0)
		{
			QMessageBox.information(parent, tr("FET Information"), StatisticsExport.tr("Statistic files were exported to directory %1 as html files.").arg(QDir.toNativeSeparators(GlobalMembersStatisticsexport.DIRECTORY_STATISTICS)));
		}
		else
		{
			QMessageBox.warning(parent, tr("FET warning"), StatisticsExport.tr("Statistic export incomplete") + "\n");
		}
		GlobalMembersStatisticsexport.teachersTotalNumberOfHours.clear();
		GlobalMembersStatisticsexport.teachersTotalNumberOfHours2.clear();
		GlobalMembersStatisticsexport.studentsTotalNumberOfHours.clear();
		GlobalMembersStatisticsexport.studentsTotalNumberOfHours2.clear();
		GlobalMembersStatisticsexport.subjectsTotalNumberOfHours.clear();
		GlobalMembersStatisticsexport.subjectsTotalNumberOfHours4.clear();
		GlobalMembersStatisticsexport.allStudentsNames.clear();
		GlobalMembersStatisticsexport.allTeachersNames.clear();
		GlobalMembersStatisticsexport.allSubjectsNames.clear();
		GlobalMembersStatisticsexport.studentsActivities.clear();
		GlobalMembersStatisticsexport.teachersActivities.clear();
		GlobalMembersStatisticsexport.subjectsActivities.clear();

		GlobalMembersStatisticsexport.hashSubjectIDsStatistics.clear();
		GlobalMembersStatisticsexport.hashActivityTagIDsStatistics.clear();
		GlobalMembersStatisticsexport.hashStudentIDsStatistics.clear();
		GlobalMembersStatisticsexport.hashTeacherIDsStatistics.clear();
		GlobalMembersStatisticsexport.hashRoomIDsStatistics.clear();
		GlobalMembersStatisticsexport.hashDayIDsStatistics.clear();
	}
	//this function must be called before export html files, because it compute the IDs
	private static void computeHashForIDsStatistics()
	{
		//TODO if an use a relational data base this is unneded, because we can use the primary key id of the database
		//This is very similar to timetable compute hash. so always check it if you change something here!

		GlobalMembersStatisticsexport.hashStudentIDsStatistics.clear();
		int cnt = 1;
		for (int i = 0; i < gt.rules.yearsList.size(); i++)
		{
			StudentsYear sty = gt.rules.yearsList[i];
			if (!GlobalMembersStatisticsexport.hashStudentIDsStatistics.contains(sty.name))
			{
				GlobalMembersStatisticsexport.hashStudentIDsStatistics.insert(sty.name, CustomFETString.number(cnt));
				cnt++;
			}
			for (int j = 0; j < sty.groupsList.size(); j++)
			{
				StudentsGroup stg = sty.groupsList[j];
				if (!GlobalMembersStatisticsexport.hashStudentIDsStatistics.contains(stg.name))
				{
					GlobalMembersStatisticsexport.hashStudentIDsStatistics.insert(stg.name, CustomFETString.number(cnt));
					cnt++;
				}
				for (int k = 0; k < stg.subgroupsList.size(); k++)
				{
					StudentsSubgroup sts = stg.subgroupsList[k];
					if (!GlobalMembersStatisticsexport.hashStudentIDsStatistics.contains(sts.name))
					{
						GlobalMembersStatisticsexport.hashStudentIDsStatistics.insert(sts.name, CustomFETString.number(cnt));
						cnt++;
					}
				}
			}
		}

		GlobalMembersStatisticsexport.hashSubjectIDsStatistics.clear();
		for (int i = 0; i < gt.rules.subjectsList.size(); i++)
		{
			GlobalMembersStatisticsexport.hashSubjectIDsStatistics.insert(gt.rules.subjectsList[i].name, CustomFETString.number(i + 1));
		}
		GlobalMembersStatisticsexport.hashActivityTagIDsStatistics.clear();
		for (int i = 0; i < gt.rules.activityTagsList.size(); i++)
		{
			GlobalMembersStatisticsexport.hashActivityTagIDsStatistics.insert(gt.rules.activityTagsList[i].name, CustomFETString.number(i + 1));
		}
		GlobalMembersStatisticsexport.hashTeacherIDsStatistics.clear();
		for (int i = 0; i < gt.rules.teachersList.size(); i++)
		{
			GlobalMembersStatisticsexport.hashTeacherIDsStatistics.insert(gt.rules.teachersList[i].name, CustomFETString.number(i + 1));
		}
		GlobalMembersStatisticsexport.hashRoomIDsStatistics.clear();
		for (int room = 0; room < gt.rules.roomsList.size(); room++)
		{
			GlobalMembersStatisticsexport.hashRoomIDsStatistics.insert(gt.rules.roomsList[room].name, CustomFETString.number(room + 1));
		}
		GlobalMembersStatisticsexport.hashDayIDsStatistics.clear();
		for (int k = 0; k < gt.rules.nDaysPerWeek; k++)
		{
			GlobalMembersStatisticsexport.hashDayIDsStatistics.insert(gt.rules.daysOfTheWeek[k], CustomFETString.number(k + 1));
		}
	}

	//the following functions write the css and html statistics files
	private static bool exportStatisticsStylesheetCss(QWidget parent, QString saveTime)
	{
		Debug.Assert(gt.rules.initialized); // && gt.rules.internalStructureComputed);
		QString s2 = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1); //TODO: remove s2, because to long filenames!

		if (s2.right(4) == ".fet")
			s2 = s2.left(s2.length() - 4);
		//else if(INPUT_FILENAME_XML!="")
		//	cout<<"Minor problem - input file does not end in .fet extension - might be a problem when saving the timetables"<<" (file:"<<__FILE__<<", line:"<<__LINE__<<")"<<endl;

		QString bar = new QString();
		if (INPUT_FILENAME_XML == "")
			bar = "";
		else
			bar = "_";

		QString htmlfilename = GlobalMembersStatisticsexport.PREFIX_STATISTICS + s2 + bar + GlobalMembersStatisticsexport.STYLESHEET_STATISTICS;

		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			QMessageBox.critical(parent, tr("FET critical"), StatisticsExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return false;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		//get used students	//similar to timetableexport.cpp, so maybe use a function?
		QSet<QString> usedStudents = new QSet<QString>();
		for (int i = 0; i < gt.rules.activitiesList.size(); i++)
		{
			foreach (QString st, gt.rules.activitiesList[i].studentsNames)
			{
				if (gt.rules.activitiesList[i].active)
				{
					if (!usedStudents.contains(st))
						usedStudents << st;
				}
			}
		}

		tos << "@charset \"UTF-8\";" << "\n\n";

		QString tt = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1);
		if (INPUT_FILENAME_XML == "")
			tt = tr("unnamed");
		tos << "/* " << StatisticsExport.tr("CSS Stylesheet of %1", "%1 is the file name").arg(tt);
		tos << "\n";
		tos << "   " << StatisticsExport.tr("Stylesheet generated with FET %1 on %2", "%1 is FET version, %2 is date and time").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) << " */\n\n";

		tos << "/* " << StatisticsExport.tr("To hide an element just write the following phrase into the element: %1 (without quotes).", "%1 is a short phrase beginning and ending with quotes, and we want the user to be able to add it, but without quotes").arg("\"display:none;\"") << " */\n\n";
		tos << "table {\n  text-align: center;\n}\n\n";
		tos << "caption {\n\n}\n\n";
		tos << "thead {\n\n}\n\n";

		//workaround begin.
		tos << "/* " << StatisticsExport.tr("Some programs import \"tfoot\" incorrectly. So we use \"tr.foot\" instead of \"tfoot\".", "Please keep tfoot and tr.foot untranslated, as they are in the original English phrase") << " */\n\n";
		//tos<<"tfoot {\n\n}\n\n";
		tos << "tr.foot {\n\n}\n\n";
		//workaround end

		tos << "tbody {\n\n}\n\n";
		tos << "th {\n\n}\n\n";
		tos << "td {\n\n}\n\n";
		tos << "td.detailed {\n  border: 1px dashed silver;\n  border-bottom: 0;\n  border-top: 0;\n}\n\n";
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 2)
		{
			tos << "th.xAxis {\n/*width: 8em; */\n}\n\n";
			tos << "th.yAxis {\n  height: 8ex;\n}\n\n";
		}
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 4) // must be written before LEVEL 3, because LEVEL 3 should have higher priority
		{
			for (int i = 0; i < gt.rules.subjectsList.size(); i++)
			{
				tos << "span.s_" << GlobalMembersStatisticsexport.hashSubjectIDsStatistics.value(gt.rules.subjectsList[i].name) << " { /* subject " << gt.rules.subjectsList[i].name << " */\n\n}\n\n";
			}
			for (int i = 0; i < gt.rules.activityTagsList.size(); i++)
			{
				tos << "span.at_" << GlobalMembersStatisticsexport.hashActivityTagIDsStatistics.value(gt.rules.activityTagsList[i].name) << " { /* activity tag " << gt.rules.activityTagsList[i].name << " */\n\n}\n\n";
			}
			for (int i = 0; i < gt.rules.yearsList.size(); i++)
			{
				StudentsYear sty = gt.rules.yearsList[i];
				if (usedStudents.contains(sty.name))
					tos << "span.ss_" << GlobalMembersStatisticsexport.hashStudentIDsStatistics.value(sty.name) << " { /* students set " << sty.name << " */\n\n}\n\n";
				for (int j = 0; j < sty.groupsList.size(); j++)
				{
					StudentsGroup stg = sty.groupsList[j];
					if (usedStudents.contains(stg.name))
						tos << "span.ss_" << GlobalMembersStatisticsexport.hashStudentIDsStatistics.value(stg.name) << " { /* students set " << stg.name << " */\n\n}\n\n";
					for (int k = 0; k < stg.subgroupsList.size(); k++)
					{
						StudentsSubgroup sts = stg.subgroupsList[k];
						if (usedStudents.contains(sts.name))
							tos << "span.ss_" << GlobalMembersStatisticsexport.hashStudentIDsStatistics.value(sts.name) << " { /* students set " << sts.name << " */\n\n}\n\n";
					}
				}
			}
			for (int i = 0; i < gt.rules.teachersList.size(); i++)
			{
				tos << "span.t_" << GlobalMembersStatisticsexport.hashTeacherIDsStatistics.value(gt.rules.teachersList[i].name) << " { /* teacher " << gt.rules.teachersList[i].name << " */\n\n}\n\n";
			}
			for (int room = 0; room < gt.rules.roomsList.size(); room++)
			{
				tos << "span.r_" << GlobalMembersStatisticsexport.hashRoomIDsStatistics.value(gt.rules.roomsList[room].name) << " { /* room " << gt.rules.roomsList[room].name << " */\n\n}\n\n";
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
			tos << "td.student, div.student {\n\n}\n\n";
			tos << "td.teacher, div.teacher {\n\n}\n\n";
			tos << "td.room, div.room {\n\n}\n\n";
			tos << "tr.line0 {\n  font-size: smaller;\n}\n\n";
			tos << "tr.line1, div.line1 {\n\n}\n\n";
			tos << "tr.line2, div.line2 {\n  font-size: smaller;\n  color: gray;\n}\n\n";
			tos << "tr.line3, div.line3 {\n  font-size: smaller;\n  color: silver;\n}\n\n";
		}

		tos << "/* " << StatisticsExport.tr("End of file.") << " */\n";

		if (file.error() > 0)
		{
			QMessageBox.critical(parent, tr("FET critical"), StatisticsExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
			return false;
		}
		file.close();
		return true;
	}
	private static bool exportStatisticsIndex(QWidget parent, QString saveTime)
	{
		Debug.Assert(gt.rules.initialized); // && gt.rules.internalStructureComputed);
		QString s2 = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1); //TODO: remove s2, because to long filenames!

		if (s2.right(4) == ".fet")
			s2 = s2.left(s2.length() - 4);
		//else if(INPUT_FILENAME_XML!="")
		//	cout<<"Minor problem - input file does not end in .fet extension - might be a problem when saving the timetables"<<" (file:"<<__FILE__<<", line:"<<__LINE__<<")"<<endl;

		QString bar = new QString();
		if (INPUT_FILENAME_XML == "")
			bar = "";
		else
			bar = "_";

		QString htmlfilename = GlobalMembersStatisticsexport.PREFIX_STATISTICS + s2 + bar + GlobalMembersStatisticsexport.INDEX_STATISTICS;
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			QMessageBox.critical(parent, tr("FET critical"), StatisticsExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return false;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Strict//EN\"\n";
		tos << "  \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\">\n\n";

		if (GlobalMembersTimetable_defs.LANGUAGE_STYLE_RIGHT_TO_LEFT == false)
			tos << "<html xmlns=\"http://www.w3.org/1999/xhtml\" lang=\"" << GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML << "\" xml:lang=\"" << GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML << "\">\n";
		else
			tos << "<html xmlns=\"http://www.w3.org/1999/xhtml\" lang=\"" << GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML << "\" xml:lang=\"" << GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML << "\" dir=\"rtl\">\n";
		tos << "  <head>\n";
		tos << "    <title>" << GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) << "</title>\n";
		tos << "    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\n";

		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 1)
		{
			QString bar = new QString();
			if (INPUT_FILENAME_XML == "")
				bar = "";
			else
				bar = "_";

			QString cssfilename = s2 + bar + GlobalMembersStatisticsexport.STYLESHEET_STATISTICS;
			tos << "    <link rel=\"stylesheet\" media=\"all\" href=\"" << cssfilename << "\" type=\"text/css\" />\n";
		}
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 5) // the following JavaScript code is pretty similar to an example of Les Richardson
		{
			tos << "    <meta http-equiv=\"Content-Script-Type\" content=\"text/javascript\" />\n";
			tos << "    <script type=\"text/javascript\">\n";
			tos << "      function highlight(classval) {\n";
			tos << "        var spans = document.getElementsByTagName('span');\n";
			tos << "        for(var i=0; spans.length>i; i++) {\n";
			tos << "          if (spans[i].className == classval) {\n";
			tos << "            spans[i].style.backgroundColor = 'lime';\n";
			tos << "          } else {\n";
			tos << "            spans[i].style.backgroundColor = 'white';\n";
			tos << "          }\n";
			tos << "        }\n";
			tos << "      }\n";
			tos << "    </script>\n";
		}
		tos << "  </head>\n\n";

		tos << "  <body>\n";

		tos << "    <table>\n      <tr align=\"left\" valign=\"top\">\n        <th>" + tr("Institution name") + ":</th>\n        <td>" + GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) + "</td>\n      </tr>\n    </table>\n";
		tos << "    <table>\n      <tr align=\"left\" valign=\"top\">\n        <th>" + tr("Comments") + ":</th>\n        <td>" + GlobalMembersTimetable_defs.protect2(gt.rules.comments).replace(new QString("\n"), new QString("<br />\n")) + "</td>\n      </tr>\n    </table>\n";
		tos << "    <p>\n";
		tos << "    </p>\n";

		tos << "    <table border=\"1\">\n";
		tos << "      <caption>" << GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) << "</caption>\n";
		tos << "      <thead>\n        <tr><td rowspan=\"2\"></td><th colspan=\"3\">" + tr("Statistics") + "</th></tr>\n";
		tos << "        <tr>\n          <!-- span -->\n";
		tos << "          <th>" + tr("Teachers") + "</th><th>" + tr("Students") + "</th><th>" + tr("Subjects") + "</th>\n";
		tos << "        </tr>\n";
		tos << "      </thead>\n";
		tos << "      <tbody>\n";
		tos << "        <tr>\n";
		tos << "          <th>" + tr("Teachers") + "</th>\n";
		tos << "          <td>" << GlobalMembersTimetable_defs.protect2(GlobalMembersStatisticsexport.STRING_EMPTY_SLOT_STATISTICS) << "</td>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersStatisticsexport.TEACHERS_STUDENTS_STATISTICS << "\">" + tr("view") + "</a></td>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersStatisticsexport.TEACHERS_SUBJECTS_STATISTICS << "\">" + tr("view") + "</a></td>\n";
		tos << "        </tr>\n";
		tos << "        <tr>\n";
		tos << "          <th>" + tr("Students") + "</th>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersStatisticsexport.STUDENTS_TEACHERS_STATISTICS << "\">" + tr("view") + "</a></td>\n";
		tos << "          <td>" << GlobalMembersTimetable_defs.protect2(GlobalMembersStatisticsexport.STRING_EMPTY_SLOT_STATISTICS) << "</td>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersStatisticsexport.STUDENTS_SUBJECTS_STATISTICS << "\">" + tr("view") + "</a></td>\n";
		tos << "        </tr>\n";
		tos << "        <tr>\n";
		tos << "          <th>" + tr("Subjects") + "</th>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersStatisticsexport.SUBJECTS_TEACHERS_STATISTICS << "\">" + tr("view") + "</a></td>\n";
		tos << "          <td><a href=\"" << s2 + bar + GlobalMembersStatisticsexport.SUBJECTS_STUDENTS_STATISTICS << "\">" + tr("view") + "</a></td>\n";
		tos << "          <td>" << GlobalMembersTimetable_defs.protect2(GlobalMembersStatisticsexport.STRING_EMPTY_SLOT_STATISTICS) << "</td>\n";
		tos << "        </tr>\n";
		//workaround begin.
		tos << "      <tr class=\"foot\"><td></td><td colspan=\"3\">" << StatisticsExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) << "</td></tr>\n";
		//workaround end.
		tos << "      </tbody>\n";
		tos << "    </table>\n";
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			QMessageBox.critical(parent, tr("FET critical"), StatisticsExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
			return false;
		}
		file.close();
		return true;
	}
	private static bool exportStatisticsTeachersSubjects(QWidget parent, QString saveTime)
	{
		Debug.Assert(gt.rules.initialized); // && gt.rules.internalStructureComputed);
		QString s2 = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1); //TODO: remove s2, because to long filenames!

		if (s2.right(4) == ".fet")
			s2 = s2.left(s2.length() - 4);
		//else if(INPUT_FILENAME_XML!="")
		//	cout<<"Minor problem - input file does not end in .fet extension - might be a problem when saving the timetables"<<" (file:"<<__FILE__<<", line:"<<__LINE__<<")"<<endl;

		QString bar = new QString();
		if (INPUT_FILENAME_XML == "")
			bar = "";
		else
			bar = "_";

		QString htmlfilename = GlobalMembersStatisticsexport.PREFIX_STATISTICS + s2 + bar + GlobalMembersStatisticsexport.TEACHERS_SUBJECTS_STATISTICS;
		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			QMessageBox.critical(parent, tr("FET critical"), StatisticsExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return false;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Strict//EN\"\n";
		tos << "  \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\">\n\n";

		if (GlobalMembersTimetable_defs.LANGUAGE_STYLE_RIGHT_TO_LEFT == false)
			tos << "<html xmlns=\"http://www.w3.org/1999/xhtml\" lang=\"" << GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML << "\" xml:lang=\"" << GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML << "\">\n";
		else
			tos << "<html xmlns=\"http://www.w3.org/1999/xhtml\" lang=\"" << GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML << "\" xml:lang=\"" << GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML << "\" dir=\"rtl\">\n";
		tos << "  <head>\n";
		tos << "    <title>" << GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) << "</title>\n";
		tos << "    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\n";
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 1)
		{
			QString bar = new QString();
			if (INPUT_FILENAME_XML == "")
				bar = "";
			else
				bar = "_";

			QString cssfilename = s2 + bar + GlobalMembersStatisticsexport.STYLESHEET_STATISTICS;
			tos << "    <link rel=\"stylesheet\" media=\"all\" href=\"" << cssfilename << "\" type=\"text/css\" />\n";
		}
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 5) // the following JavaScript code is pretty similar to an example of Les Richardson
		{
			tos << "    <meta http-equiv=\"Content-Script-Type\" content=\"text/javascript\" />\n";
			tos << "    <script type=\"text/javascript\">\n";
			tos << "      function highlight(classval) {\n";
			tos << "        var spans = document.getElementsByTagName('span');\n";
			tos << "        for(var i=0;spans.length>i;i++) {\n";
			tos << "          if (spans[i].className == classval) {\n";
			tos << "            spans[i].style.backgroundColor = 'lime';\n";
			tos << "          } else {\n";
			tos << "            spans[i].style.backgroundColor = 'white';\n";
			tos << "          }\n";
			tos << "        }\n";
			tos << "      }\n";
			tos << "    </script>\n";
		}
		tos << "  </head>\n\n";

		tos << "  <body>\n";
		tos << "    <table border=\"1\">\n";
		tos << "      <caption>" << GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) << "</caption>\n";
		tos << "      <thead>\n        <tr><td rowspan=\"2\"></td><th colspan=\"" << GlobalMembersStatisticsexport.allTeachersNames.size() + 1 << "\">" << tr("Teachers - Subjects Matrix") << "</th></tr>\n";
		tos << "        <tr>\n          <!-- span -->\n";
		foreach (QString teachers, GlobalMembersStatisticsexport.allTeachersNames)
		{
			if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 2)
				tos << "          <th class=\"xAxis\">";
			else
				tos << "          <th>";
			tos << GlobalMembersTimetable_defs.protect2(teachers) << "</th>\n";
		}
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 2)
			tos << "          <th class=\"xAxis\">";
		else
			tos << "          <th>";
		tos << GlobalMembersTimetable_defs.protect2(tr("Sum", "This means the sum of more values, the total")) << "</th>\n";
		tos << "        </tr>\n";
		tos << "      </thead>\n";
		tos << "      <tbody>\n";

		QProgressDialog progress = new QProgressDialog(parent);
		progress.setWindowTitle(tr("Exporting statistics", "Title of a progress dialog"));
		progress.setLabelText(tr("Processing teachers with subjects...please wait"));
		progress.setRange(0, GlobalMembersStatisticsexport.allSubjectsNames.count());
		progress.setModal(true);

		int ttt = 0;

		foreach (QString subjects, GlobalMembersStatisticsexport.allSubjectsNames)
		{
			progress.setValue(ttt);
			//pqapplication->processEvents();
			if (progress.wasCanceled())
			{
				QMessageBox.warning(parent, tr("FET warning"), tr("Canceled"));
				return false;
			}
			ttt++;

			QList<int> tmpSubjects = new QList<int>();
			QMultiHash<QString, int> tmpTeachers = new QMultiHash<QString, int>();
			tmpSubjects.clear();
			tmpTeachers.clear();
			tmpSubjects = GlobalMembersStatisticsexport.subjectsActivities.values(subjects);
			foreach (int aidx, tmpSubjects)
			{
				Activity act = gt.rules.activitiesList.at(aidx);
				foreach (QString teacher, act.teachersNames)
				{
					tmpTeachers.insert(teacher, aidx);
				}
			}
			tos << "        <tr>\n";
			if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 2)
				tos << "          <th class=\"yAxis\">";
			else
				tos << "          <th>";
			tos << GlobalMembersTimetable_defs.protect2(subjects) << "</th>\n";
			foreach (QString teachers, GlobalMembersStatisticsexport.allTeachersNames)
			{
				QList<int> tmpActivities = new QList<int>();
				tmpActivities.clear();
				tmpActivities = tmpTeachers.values(teachers);
				if (tmpActivities.isEmpty())
				{
					switch (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL)
					{
						case 3 :
							;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
						case 4 :
							tos << "          <td class=\"empty\"><span class=\"empty\">" << GlobalMembersTimetable_defs.protect2(GlobalMembersStatisticsexport.STRING_EMPTY_SLOT_STATISTICS) << "</span></td>\n";
							break;
						case 5 :
							;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
						case 6 :
							tos << "          <td class=\"empty\"><span class=\"empty\" onmouseover=\"highlight('empty')\">" << GlobalMembersTimetable_defs.protect2(GlobalMembersStatisticsexport.STRING_EMPTY_SLOT_STATISTICS) << "</span></td>\n";
							break;
						default:
							tos << "          <td>" << GlobalMembersTimetable_defs.protect2(GlobalMembersStatisticsexport.STRING_EMPTY_SLOT_STATISTICS) << "</td>\n";
							break;
					}
				}
				else
				{
					QMap<QString, int> tmpStudentDuration = new QMap<QString, int>(); //not QHash, because i need the correct order of the activities
					foreach (int tmpAct, tmpActivities)
					{
						Activity act = gt.rules.activitiesList[tmpAct];
						int tmpD = act.duration;
						QString tmpSt = new QString();
						if (act.studentsNames.size() > 0)
						{
							for (QStringList.Iterator st = act.studentsNames.begin(); st != act.studentsNames.end(); st++)
							{
								switch (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL)
								{
									case 4 :
										tmpSt += "<span class=\"ss_" + GlobalMembersStatisticsexport.hashStudentIDsStatistics.value(*st) + "\">" + GlobalMembersTimetable_defs.protect2(*st) + "</span>";
										break;
									case 5 :
										;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
									case 6 :
										tmpSt += "<span class=\"ss_" + GlobalMembersStatisticsexport.hashStudentIDsStatistics.value(*st) + "\" onmouseover=\"highlight('ss_" + GlobalMembersStatisticsexport.hashStudentIDsStatistics.value(*st) + "')\">" + GlobalMembersTimetable_defs.protect2(*st) + "</span>";
										break;
									default:
										tmpSt += GlobalMembersTimetable_defs.protect2(*st);
										break;
								}
								if (st != act.studentsNames.end() - 1)
									tmpSt += ", ";
							}
						}
						else
							tmpSt = " ";
						tmpD += tmpStudentDuration.value(tmpSt);
						tmpStudentDuration.insert(tmpSt, tmpD);
					}
					if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 1)
						tos << "          <td><table class=\"detailed\">";
					else
						tos << "          <td><table>";
					if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 3)
						tos << "<tr class=\"duration line1\">";
					else
						tos << "<tr>";
					QMapIterator<QString, int> it = new QMapIterator<QString, int>(tmpStudentDuration);
					while (it.hasNext())
					{
						it.next();
						if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 1)
							tos << "<td class=\"detailed\">";
						else
							tos << "<td>";
						tos << it.value() << "</td>";
					}
					tos << "</tr>";
					if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 3)
						tos << "<tr class=\"student line2\">";
					else
						tos << "<tr>";
					QMapIterator<QString, int> it2 = new QMapIterator<QString, int>(tmpStudentDuration); //do it with the same iterator
					while (it2.hasNext())
					{
						it2.next();
						if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 1)
							tos << "<td class=\"detailed\">";
						else
							tos << "<td>";
						tos << it2.key() << "</td>";
					}
					tos << "</tr>";
					tos << "</table></td>\n";
				}
			}
			tos << "          <th>";
			tos << CustomFETString.number(GlobalMembersStatisticsexport.subjectsTotalNumberOfHours.value(subjects));
			if (GlobalMembersStatisticsexport.subjectsTotalNumberOfHours.value(subjects) != GlobalMembersStatisticsexport.subjectsTotalNumberOfHours4.value(subjects))
				tos << "<br />(" << CustomFETString.number(GlobalMembersStatisticsexport.subjectsTotalNumberOfHours4.value(subjects)) << ")";
			tos << "</th>\n";
			tos << "        </tr>\n";
		}

		progress.setValue(GlobalMembersStatisticsexport.allSubjectsNames.count());

		tos << "        <tr>\n";
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 2)
			tos << "          <th class=\"xAxis\">";
		else
			tos << "          <th>";
		tos << GlobalMembersTimetable_defs.protect2(tr("Sum", "This means the sum of more values, the total")) << "</th>\n";
		foreach (QString teachers, GlobalMembersStatisticsexport.allTeachersNames)
		{
			tos << "          <th>" << CustomFETString.number(GlobalMembersStatisticsexport.teachersTotalNumberOfHours.value(teachers));
			if (GlobalMembersStatisticsexport.teachersTotalNumberOfHours.value(teachers) != GlobalMembersStatisticsexport.teachersTotalNumberOfHours2.value(teachers))
				tos << "<br />(" << CustomFETString.number(GlobalMembersStatisticsexport.teachersTotalNumberOfHours2.value(teachers)) << ")";
			tos << "</th>\n";
		}
		tos << "          <th></th>\n        </tr>\n";
		//workaround begin.
		tos << "      <tr class=\"foot\"><td></td><td colspan=\"" << GlobalMembersStatisticsexport.allTeachersNames.size() + 1 << "\">" << StatisticsExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) << "</td></tr>\n";
		//workaround end.
		tos << "      </tbody>\n";
		tos << "    </table>\n";
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			QMessageBox.critical(parent, tr("FET critical"), StatisticsExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
			return false;
		}
		file.close();
		return true;
	}
	private static bool exportStatisticsSubjectsTeachers(QWidget parent, QString saveTime)
	{
		Debug.Assert(gt.rules.initialized); // && gt.rules.internalStructureComputed);
		QString s2 = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1); //TODO: remove s2, because to long filenames!

		if (s2.right(4) == ".fet")
			s2 = s2.left(s2.length() - 4);
		//else if(INPUT_FILENAME_XML!="")
		//	cout<<"Minor problem - input file does not end in .fet extension - might be a problem when saving the timetables"<<" (file:"<<__FILE__<<", line:"<<__LINE__<<")"<<endl;

		QString bar = new QString();
		if (INPUT_FILENAME_XML == "")
			bar = "";
		else
			bar = "_";

		QString htmlfilename = GlobalMembersStatisticsexport.PREFIX_STATISTICS + s2 + bar + GlobalMembersStatisticsexport.SUBJECTS_TEACHERS_STATISTICS;

		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			QMessageBox.critical(parent, tr("FET critical"), StatisticsExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return false;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Strict//EN\"\n";
		tos << "  \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\">\n\n";

		if (GlobalMembersTimetable_defs.LANGUAGE_STYLE_RIGHT_TO_LEFT == false)
			tos << "<html xmlns=\"http://www.w3.org/1999/xhtml\" lang=\"" << GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML << "\" xml:lang=\"" << GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML << "\">\n";
		else
			tos << "<html xmlns=\"http://www.w3.org/1999/xhtml\" lang=\"" << GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML << "\" xml:lang=\"" << GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML << "\" dir=\"rtl\">\n";
		tos << "  <head>\n";
		tos << "    <title>" << GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) << "</title>\n";
		tos << "    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\n";
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 1)
		{
			QString bar = new QString();
			if (INPUT_FILENAME_XML == "")
				bar = "";
			else
				bar = "_";

			QString cssfilename = s2 + bar + GlobalMembersStatisticsexport.STYLESHEET_STATISTICS;
			tos << "    <link rel=\"stylesheet\" media=\"all\" href=\"" << cssfilename << "\" type=\"text/css\" />\n";
		}
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 5) // the following JavaScript code is pretty similar to an example of Les Richardson
		{
			tos << "    <meta http-equiv=\"Content-Script-Type\" content=\"text/javascript\" />\n";
			tos << "    <script type=\"text/javascript\">\n";
			tos << "      function highlight(classval) {\n";
			tos << "        var spans = document.getElementsByTagName('span');\n";
			tos << "        for(var i=0;spans.length>i;i++) {\n";
			tos << "          if (spans[i].className == classval) {\n";
			tos << "            spans[i].style.backgroundColor = 'lime';\n";
			tos << "          } else {\n";
			tos << "            spans[i].style.backgroundColor = 'white';\n";
			tos << "          }\n";
			tos << "        }\n";
			tos << "      }\n";
			tos << "    </script>\n";
		}
		tos << "  </head>\n\n";

		tos << "  <body>\n";
		tos << "    <table border=\"1\">\n";
		tos << "      <caption>" << GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) << "</caption>\n";
		tos << "      <thead>\n        <tr><td rowspan=\"2\"></td><th colspan=\"" << GlobalMembersStatisticsexport.allSubjectsNames.size() + 1 << "\">" << tr("Subjects - Teachers Matrix") << "</th></tr>\n";
		tos << "        <tr>\n          <!-- span -->\n";
		foreach (QString subjects, GlobalMembersStatisticsexport.allSubjectsNames)
		{
			if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 2)
				tos << "          <th class=\"xAxis\">";
			else
				tos << "          <th>";
			tos << GlobalMembersTimetable_defs.protect2(subjects) << "</th>\n";
		}
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 2)
			tos << "          <th class=\"xAxis\">";
		else
			tos << "          <th>";
		tos << GlobalMembersTimetable_defs.protect2(tr("Sum", "This means the sum of more values, the total")) << "</th>\n";
		tos << "        </tr>\n";
		tos << "      </thead>\n";
		tos << "      <tbody>\n";

		QProgressDialog progress = new QProgressDialog(parent);
		progress.setWindowTitle(tr("Exporting statistics", "Title of a progress dialog"));
		progress.setLabelText(tr("Processing subject with teachers...please wait"));
		progress.setRange(0, GlobalMembersStatisticsexport.allTeachersNames.count());
		progress.setModal(true);

		int ttt = 0;

		foreach (QString teachers, GlobalMembersStatisticsexport.allTeachersNames)
		{
			progress.setValue(ttt);
			//pqapplication->processEvents();
			if (progress.wasCanceled())
			{
				QMessageBox.warning(parent, tr("FET warning"), tr("Canceled"));
				return false;
			}
			ttt++;

			QList<int> tmpTeachers = new QList<int>();
			QMultiHash<QString, int> tmpSubjects = new QMultiHash<QString, int>();
			tmpTeachers.clear();
			tmpSubjects.clear();
			tmpTeachers = GlobalMembersStatisticsexport.teachersActivities.values(teachers);
			foreach (int aidx, tmpTeachers)
			{
				Activity act = gt.rules.activitiesList.at(aidx);
				tmpSubjects.insert(act.subjectName, aidx);
			}
			tos << "        <tr>\n";
			if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 2)
				tos << "          <th class=\"yAxis\">";
			else
				tos << "          <th>";
			tos << GlobalMembersTimetable_defs.protect2(teachers) << "</th>\n";
			foreach (QString subjects, GlobalMembersStatisticsexport.allSubjectsNames)
			{
				QList<int> tmpActivities = new QList<int>();
				tmpActivities.clear();
				tmpActivities = tmpSubjects.values(subjects);
				if (tmpActivities.isEmpty())
				{
					switch (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL)
					{
						case 3 :
							;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
						case 4 :
							tos << "          <td class=\"empty\"><span class=\"empty\">" << GlobalMembersTimetable_defs.protect2(GlobalMembersStatisticsexport.STRING_EMPTY_SLOT_STATISTICS) << "</span></td>\n";
							break;
						case 5 :
							;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
						case 6 :
							tos << "          <td class=\"empty\"><span class=\"empty\" onmouseover=\"highlight('empty')\">" << GlobalMembersTimetable_defs.protect2(GlobalMembersStatisticsexport.STRING_EMPTY_SLOT_STATISTICS) << "</span></td>\n";
							break;
						default:
							tos << "          <td>" << GlobalMembersTimetable_defs.protect2(GlobalMembersStatisticsexport.STRING_EMPTY_SLOT_STATISTICS) << "</td>\n";
							break;
					}
				}
				else
				{
					QMap<QString, int> tmpStudentDuration = new QMap<QString, int>(); //not QHash, because i need the correct order of the activities
					foreach (int tmpAct, tmpActivities)
					{
						Activity act = gt.rules.activitiesList[tmpAct];
						int tmpD = act.duration;
						QString tmpSt = new QString();
						if (act.studentsNames.size() > 0)
						{
							for (QStringList.Iterator st = act.studentsNames.begin(); st != act.studentsNames.end(); st++)
							{
								switch (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL)
								{
									case 4 :
										tmpSt += "<span class=\"ss_" + GlobalMembersStatisticsexport.hashStudentIDsStatistics.value(*st) + "\">" + GlobalMembersTimetable_defs.protect2(*st) + "</span>";
										break;
									case 5 :
										;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
									case 6 :
										tmpSt += "<span class=\"ss_" + GlobalMembersStatisticsexport.hashStudentIDsStatistics.value(*st) + "\" onmouseover=\"highlight('ss_" + GlobalMembersStatisticsexport.hashStudentIDsStatistics.value(*st) + "')\">" + GlobalMembersTimetable_defs.protect2(*st) + "</span>";
										break;
									default:
										tmpSt += GlobalMembersTimetable_defs.protect2(*st);
										break;
								}
								if (st != act.studentsNames.end() - 1)
									tmpSt += ", ";
							}
						}
						else
							tmpSt = " ";
						tmpD += tmpStudentDuration.value(tmpSt);
						tmpStudentDuration.insert(tmpSt, tmpD);
					}
					if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 1)
						tos << "          <td><table class=\"detailed\">";
					else
						tos << "          <td><table>";
					if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 3)
						tos << "<tr class=\"duration line1\">";
					else
						tos << "<tr>";
					QMapIterator<QString, int> it = new QMapIterator<QString, int>(tmpStudentDuration);
					while (it.hasNext())
					{
						it.next();
						if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 1)
							tos << "<td class=\"detailed\">";
						else
							tos << "<td>";
						tos << it.value() << "</td>";
					}
					tos << "</tr>";
					if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 3)
						tos << "<tr class=\"student line2\">";
					else
						tos << "<tr>";
					QMapIterator<QString, int> it2 = new QMapIterator<QString, int>(tmpStudentDuration); //do it with the same iterator
					while (it2.hasNext())
					{
						it2.next();
						if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 1)
							tos << "<td class=\"detailed\">";
						else
							tos << "<td>";
						tos << it2.key() << "</td>";
					}
					tos << "</tr>";
					tos << "</table></td>\n";
				}
			}
			tos << "          <th>";
			tos << CustomFETString.number(GlobalMembersStatisticsexport.teachersTotalNumberOfHours.value(teachers));
			if (GlobalMembersStatisticsexport.teachersTotalNumberOfHours.value(teachers) != GlobalMembersStatisticsexport.teachersTotalNumberOfHours2.value(teachers))
				tos << "<br />(" << CustomFETString.number(GlobalMembersStatisticsexport.teachersTotalNumberOfHours2.value(teachers)) << ")";
			tos << "</th>\n";
			tos << "        </tr>\n";
		}

		progress.setValue(GlobalMembersStatisticsexport.allTeachersNames.count());

		tos << "        <tr>\n";
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 2)
			tos << "          <th class=\"xAxis\">";
		else
			tos << "          <th>";
		tos << GlobalMembersTimetable_defs.protect2(tr("Sum", "This means the sum of more values, the total")) << "</th>\n";
		foreach (QString subjects, GlobalMembersStatisticsexport.allSubjectsNames)
		{
			tos << "          <th>" << CustomFETString.number(GlobalMembersStatisticsexport.subjectsTotalNumberOfHours.value(subjects));
			if (GlobalMembersStatisticsexport.subjectsTotalNumberOfHours.value(subjects) != GlobalMembersStatisticsexport.subjectsTotalNumberOfHours4.value(subjects))
				tos << "<br />(" << CustomFETString.number(GlobalMembersStatisticsexport.subjectsTotalNumberOfHours4.value(subjects)) << ")";
			tos << "</th>\n";
		}
		tos << "          <th></th>\n        </tr>\n";
		//workaround begin.
		tos << "      <tr class=\"foot\"><td></td><td colspan=\"" << GlobalMembersStatisticsexport.allSubjectsNames.size() + 1 << "\">" << StatisticsExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) << "</td></tr>\n";
		//workaround end.
		tos << "      </tbody>\n";
		tos << "    </table>\n";
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			QMessageBox.critical(parent, tr("FET critical"), StatisticsExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
			return false;
		}
		file.close();
		return true;
	}
	private static bool exportStatisticsTeachersStudents(QWidget parent, QString saveTime)
	{
		Debug.Assert(gt.rules.initialized); // && gt.rules.internalStructureComputed);
		QString s2 = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1); //TODO: remove s2, because to long filenames!

		if (s2.right(4) == ".fet")
			s2 = s2.left(s2.length() - 4);
		//else if(INPUT_FILENAME_XML!="")
		//	cout<<"Minor problem - input file does not end in .fet extension - might be a problem when saving the timetables"<<" (file:"<<__FILE__<<", line:"<<__LINE__<<")"<<endl;

		QString bar = new QString();
		if (INPUT_FILENAME_XML == "")
			bar = "";
		else
			bar = "_";

		QString htmlfilename = GlobalMembersStatisticsexport.PREFIX_STATISTICS + s2 + bar + GlobalMembersStatisticsexport.TEACHERS_STUDENTS_STATISTICS;

		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			QMessageBox.critical(parent, tr("FET critical"), StatisticsExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return false;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Strict//EN\"\n";
		tos << "  \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\">\n\n";

		if (GlobalMembersTimetable_defs.LANGUAGE_STYLE_RIGHT_TO_LEFT == false)
			tos << "<html xmlns=\"http://www.w3.org/1999/xhtml\" lang=\"" << GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML << "\" xml:lang=\"" << GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML << "\">\n";
		else
			tos << "<html xmlns=\"http://www.w3.org/1999/xhtml\" lang=\"" << GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML << "\" xml:lang=\"" << GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML << "\" dir=\"rtl\">\n";
		tos << "  <head>\n";
		tos << "    <title>" << GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) << "</title>\n";
		tos << "    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\n";
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 1)
		{
			QString bar = new QString();
			if (INPUT_FILENAME_XML == "")
				bar = "";
			else
				bar = "_";

			QString cssfilename = s2 + bar + GlobalMembersStatisticsexport.STYLESHEET_STATISTICS;
			tos << "    <link rel=\"stylesheet\" media=\"all\" href=\"" << cssfilename << "\" type=\"text/css\" />\n";
		}
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 5) // the following JavaScript code is pretty similar to an example of Les Richardson
		{
			tos << "    <meta http-equiv=\"Content-Script-Type\" content=\"text/javascript\" />\n";
			tos << "    <script type=\"text/javascript\">\n";
			tos << "      function highlight(classval) {\n";
			tos << "        var spans = document.getElementsByTagName('span');\n";
			tos << "        for(var i=0;spans.length>i;i++) {\n";
			tos << "          if (spans[i].className == classval) {\n";
			tos << "            spans[i].style.backgroundColor = 'lime';\n";
			tos << "          } else {\n";
			tos << "            spans[i].style.backgroundColor = 'white';\n";
			tos << "          }\n";
			tos << "        }\n";
			tos << "      }\n";
			tos << "    </script>\n";
		}
		tos << "  </head>\n\n";

		tos << "  <body>\n";
		tos << "    <table border=\"1\">\n";
		tos << "      <caption>" << GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) << "</caption>\n";
		tos << "      <thead>\n        <tr><td rowspan=\"2\"></td><th colspan=\"" << GlobalMembersStatisticsexport.allTeachersNames.size() + 1 << "\">" << tr("Teachers - Students Matrix") << "</th></tr>\n";
		tos << "        <tr>\n          <!-- span -->\n";
		foreach (QString teachers, GlobalMembersStatisticsexport.allTeachersNames)
		{
			if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 2)
				tos << "          <th class=\"xAxis\">";
			else
				tos << "          <th>";
			tos << GlobalMembersTimetable_defs.protect2(teachers) << "</th>\n";
		}
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 2)
			tos << "          <th class=\"xAxis\">";
		else
			tos << "          <th>";
		tos << GlobalMembersTimetable_defs.protect2(tr("Sum", "This means the sum of more values, the total")) << "</th>\n";
		tos << "        </tr>\n";
		tos << "      </thead>\n";
		tos << "      <tbody>\n";

		QProgressDialog progress = new QProgressDialog(parent);
		progress.setWindowTitle(tr("Exporting statistics", "Title of a progress dialog"));
		progress.setLabelText(tr("Processing teachers with students...please wait"));
		progress.setRange(0, GlobalMembersStatisticsexport.allStudentsNames.count());
		progress.setModal(true);

		int ttt = 0;

		foreach (QString students, GlobalMembersStatisticsexport.allStudentsNames)
		{
			progress.setValue(ttt);
			//pqapplication->processEvents();
			if (progress.wasCanceled())
			{
				QMessageBox.warning(parent, tr("FET warning"), tr("Canceled"));
				return false;
			}
			ttt++;

			QList<int> tmpStudents = new QList<int>();
			QMultiHash<QString, int> tmpTeachers = new QMultiHash<QString, int>();
			tmpStudents.clear();
			tmpTeachers.clear();
			tmpStudents = GlobalMembersStatisticsexport.studentsActivities.values(students);
			foreach (int aidx, tmpStudents)
			{
				Activity act = gt.rules.activitiesList.at(aidx);
				foreach (QString teacher, act.teachersNames)
				{
					tmpTeachers.insert(teacher, aidx);
				}
			}
			tos << "        <tr>\n";
			if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 2)
				tos << "          <th class=\"yAxis\">";
			else
				tos << "          <th>";
			tos << GlobalMembersTimetable_defs.protect2(students) << "</th>\n";
			foreach (QString teachers, GlobalMembersStatisticsexport.allTeachersNames)
			{
				QList<int> tmpActivities = new QList<int>();
				tmpActivities.clear();
				tmpActivities = tmpTeachers.values(teachers);
				if (tmpActivities.isEmpty())
				{
					switch (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL)
					{
						case 3 :
							;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
						case 4 :
							tos << "          <td class=\"empty\"><span class=\"empty\">" << GlobalMembersTimetable_defs.protect2(GlobalMembersStatisticsexport.STRING_EMPTY_SLOT_STATISTICS) << "</span></td>\n";
							break;
						case 5 :
							;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
						case 6 :
							tos << "          <td class=\"empty\"><span class=\"empty\" onmouseover=\"highlight('empty')\">" << GlobalMembersTimetable_defs.protect2(GlobalMembersStatisticsexport.STRING_EMPTY_SLOT_STATISTICS) << "</span></td>\n";
							break;
						default:
							tos << "          <td>" << GlobalMembersTimetable_defs.protect2(GlobalMembersStatisticsexport.STRING_EMPTY_SLOT_STATISTICS) << "</td>\n";
							break;
					}
				}
				else
				{
					QMap<QString, int> tmpSubjectDuration = new QMap<QString, int>(); //not QHash, because i need the correct order of the activities
					foreach (int tmpAct, tmpActivities)
					{
						Activity act = gt.rules.activitiesList[tmpAct];
						int tmpD = act.duration;
						QString tmpS = new QString();
						if (act.subjectName.size() > 0 || act.activityTagsNames.size() > 0)
						{
							if (act.subjectName.size() > 0)
								switch (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL)
								{
									case 3 :
										tmpS += "<span class=\"subject\">" + GlobalMembersTimetable_defs.protect2(act.subjectName) + "</span>";
										break;
									case 4 :
										tmpS += "<span class=\"subject\"><span class=\"s_" + GlobalMembersStatisticsexport.hashSubjectIDsStatistics.value(act.subjectName) + "\">" + GlobalMembersTimetable_defs.protect2(act.subjectName) + "</span></span>";
										break;
									case 5 :
										;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
									case 6 :
										tmpS += "<span class=\"subject\"><span class=\"s_" + GlobalMembersStatisticsexport.hashSubjectIDsStatistics.value(act.subjectName) + "\" onmouseover=\"highlight('s_" + GlobalMembersStatisticsexport.hashSubjectIDsStatistics.value(act.subjectName) + "')\">" + GlobalMembersTimetable_defs.protect2(act.subjectName) + "</span></span>";
										break;
									default:
										tmpS += GlobalMembersTimetable_defs.protect2(act.subjectName);
										break;
								}
							for (QStringList.Iterator atn = act.activityTagsNames.begin(); atn != act.activityTagsNames.end(); atn++)
							{
								switch (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL)
								{
									case 3 :
										tmpS += " <span class=\"activitytag\">" + GlobalMembersTimetable_defs.protect2(*atn) + "</span>";
										break;
									case 4 :
										tmpS += " <span class=\"activitytag\"><span class=\"at_" + GlobalMembersStatisticsexport.hashActivityTagIDsStatistics.value(*atn) + "\">" + GlobalMembersTimetable_defs.protect2(*atn) + "</span></span>";
										break;
									case 5 :
										;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
									case 6 :
										tmpS += " <span class=\"activitytag\"><span class=\"at_" + GlobalMembersStatisticsexport.hashActivityTagIDsStatistics.value(*atn) + "\" onmouseover=\"highlight('at_" + GlobalMembersStatisticsexport.hashActivityTagIDsStatistics.value(*atn) + "')\">" + GlobalMembersTimetable_defs.protect2(*atn) + "</span></span>";
										break;
									default:
										tmpS += " " + GlobalMembersTimetable_defs.protect2(*atn);
										break;
								}
								if (atn != act.activityTagsNames.end() - 1)
									tmpS += ", ";
							}
						}
						else
							tmpS = " ";
						tmpD += tmpSubjectDuration.value(tmpS);
						tmpSubjectDuration.insert(tmpS, tmpD);
					}
					if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 1)
						tos << "          <td><table class=\"detailed\">";
					else
						tos << "          <td><table>";
					if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 3)
						tos << "<tr class=\"duration line1\">";
					else
						tos << "<tr>";
					QMapIterator<QString, int> it = new QMapIterator<QString, int>(tmpSubjectDuration);
					while (it.hasNext())
					{
						it.next();
						if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 1)
							tos << "<td class=\"detailed\">";
						else
							tos << "<td>";
						tos << it.value() << "</td>";
					}
					tos << "</tr>";
					if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 3)
						tos << "<tr class=\"subject line2\">";
					else
						tos << "<tr>";
					QMapIterator<QString, int> it2 = new QMapIterator<QString, int>(tmpSubjectDuration); //do it with the same iterator
					while (it2.hasNext())
					{
						it2.next();
						if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 1)
							tos << "<td class=\"detailed\">";
						else
							tos << "<td>";
						tos << it2.key() << "</td>";
					}
					tos << "</tr>";
					tos << "</table></td>\n";
				}
			}
			tos << "          <th>";
			tos << CustomFETString.number(GlobalMembersStatisticsexport.studentsTotalNumberOfHours.value(students));
			if (GlobalMembersStatisticsexport.studentsTotalNumberOfHours.value(students) != GlobalMembersStatisticsexport.studentsTotalNumberOfHours2.value(students))
				tos << "<br />(" << CustomFETString.number(GlobalMembersStatisticsexport.studentsTotalNumberOfHours2.value(students)) << ")";
			tos << "</th>\n";
			tos << "        </tr>\n";
		}

		progress.setValue(GlobalMembersStatisticsexport.allStudentsNames.count());

		tos << "        <tr>\n";
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 2)
			tos << "          <th class=\"xAxis\">";
		else
			tos << "          <th>";
		tos << GlobalMembersTimetable_defs.protect2(tr("Sum", "This means the sum of more values, the total")) << "</th>\n";
		foreach (QString teachers, GlobalMembersStatisticsexport.allTeachersNames)
		{
			tos << "          <th>" << CustomFETString.number(GlobalMembersStatisticsexport.teachersTotalNumberOfHours.value(teachers));
			if (GlobalMembersStatisticsexport.teachersTotalNumberOfHours.value(teachers) != GlobalMembersStatisticsexport.teachersTotalNumberOfHours2.value(teachers))
				tos << "<br />(" << CustomFETString.number(GlobalMembersStatisticsexport.teachersTotalNumberOfHours2.value(teachers)) << ")";
			tos << "</th>\n";
		}
		tos << "          <th></th>\n        </tr>\n";
		//workaround begin.
		tos << "      <tr class=\"foot\"><td></td><td colspan=\"" << GlobalMembersStatisticsexport.allTeachersNames.size() + 1 << "\">" << StatisticsExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) << "</td></tr>\n";
		//workaround end.
		tos << "      </tbody>\n";
		tos << "    </table>\n";
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			QMessageBox.critical(parent, tr("FET critical"), StatisticsExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
			return false;
		}
		file.close();
		return true;
	}
	private static bool exportStatisticsStudentsTeachers(QWidget parent, QString saveTime)
	{
		Debug.Assert(gt.rules.initialized); // && gt.rules.internalStructureComputed);
		QString s2 = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1); //TODO: remove s2, because to long filenames!

		if (s2.right(4) == ".fet")
			s2 = s2.left(s2.length() - 4);
		//else if(INPUT_FILENAME_XML!="")
		//	cout<<"Minor problem - input file does not end in .fet extension - might be a problem when saving the timetables"<<" (file:"<<__FILE__<<", line:"<<__LINE__<<")"<<endl;

		QString bar = new QString();
		if (INPUT_FILENAME_XML == "")
			bar = "";
		else
			bar = "_";

		QString htmlfilename = GlobalMembersStatisticsexport.PREFIX_STATISTICS + s2 + bar + GlobalMembersStatisticsexport.STUDENTS_TEACHERS_STATISTICS;

		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			QMessageBox.critical(parent, tr("FET critical"), StatisticsExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return false;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Strict//EN\"\n";
		tos << "  \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\">\n\n";

		if (GlobalMembersTimetable_defs.LANGUAGE_STYLE_RIGHT_TO_LEFT == false)
			tos << "<html xmlns=\"http://www.w3.org/1999/xhtml\" lang=\"" << GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML << "\" xml:lang=\"" << GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML << "\">\n";
		else
			tos << "<html xmlns=\"http://www.w3.org/1999/xhtml\" lang=\"" << GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML << "\" xml:lang=\"" << GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML << "\" dir=\"rtl\">\n";
		tos << "  <head>\n";
		tos << "    <title>" << GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) << "</title>\n";
		tos << "    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\n";
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 1)
		{
			QString bar = new QString();
			if (INPUT_FILENAME_XML == "")
				bar = "";
			else
				bar = "_";

			QString cssfilename = s2 + bar + GlobalMembersStatisticsexport.STYLESHEET_STATISTICS;
			tos << "    <link rel=\"stylesheet\" media=\"all\" href=\"" << cssfilename << "\" type=\"text/css\" />\n";
		}
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 5) // the following JavaScript code is pretty similar to an example of Les Richardson
		{
			tos << "    <meta http-equiv=\"Content-Script-Type\" content=\"text/javascript\" />\n";
			tos << "    <script type=\"text/javascript\">\n";
			tos << "      function highlight(classval) {\n";
			tos << "        var spans = document.getElementsByTagName('span');\n";
			tos << "        for(var i=0;spans.length>i;i++) {\n";
			tos << "          if (spans[i].className == classval) {\n";
			tos << "            spans[i].style.backgroundColor = 'lime';\n";
			tos << "          } else {\n";
			tos << "            spans[i].style.backgroundColor = 'white';\n";
			tos << "          }\n";
			tos << "        }\n";
			tos << "      }\n";
			tos << "    </script>\n";
		}
		tos << "  </head>\n\n";

		tos << "  <body>\n";
		tos << "    <table border=\"1\">\n";
		tos << "      <caption>" << GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) << "</caption>\n";
		tos << "      <thead>\n        <tr><td rowspan=\"2\"></td><th colspan=\"" << GlobalMembersStatisticsexport.allStudentsNames.size() + 1 << "\">" << tr("Students -Teachers Matrix") << "</th></tr>\n";
		tos << "        <tr>\n          <!-- span -->\n";
		foreach (QString students, GlobalMembersStatisticsexport.allStudentsNames)
		{
			if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 2)
				tos << "          <th class=\"xAxis\">";
			else
				tos << "          <th>";
			tos << GlobalMembersTimetable_defs.protect2(students) << "</th>\n";
		}
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 2)
			tos << "          <th class=\"xAxis\">";
		else
			tos << "          <th>";
		tos << GlobalMembersTimetable_defs.protect2(tr("Sum", "This means the sum of more values, the total")) << "</th>\n";
		tos << "        </tr>\n";
		tos << "      </thead>\n";
		tos << "      <tbody>\n";

		QProgressDialog progress = new QProgressDialog(parent);
		progress.setWindowTitle(tr("Exporting statistics", "Title of a progress dialog"));
		progress.setLabelText(tr("Processing students with teachers...please wait"));
		progress.setRange(0, GlobalMembersStatisticsexport.allTeachersNames.count());
		progress.setModal(true);

		int ttt = 0;

		foreach (QString teachers, GlobalMembersStatisticsexport.allTeachersNames)
		{
			progress.setValue(ttt);
			//pqapplication->processEvents();
			if (progress.wasCanceled())
			{
				QMessageBox.warning(parent, tr("FET warning"), tr("Canceled"));
				return false;
			}
			ttt++;

			QList<int> tmpTeachers = new QList<int>();
			QMultiHash<QString, int> tmpStudents = new QMultiHash<QString, int>();
			tmpTeachers.clear();
			tmpStudents.clear();
			tmpTeachers = GlobalMembersStatisticsexport.teachersActivities.values(teachers);
			foreach (int aidx, tmpTeachers)
			{
				Activity act = gt.rules.activitiesList.at(aidx);
				foreach (QString students, act.studentsNames)
				{
					tmpStudents.insert(students, aidx);
				}
			}
			tos << "        <tr>\n";
			if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 2)
				tos << "          <th class=\"yAxis\">";
			else
				tos << "          <th>";
			tos << GlobalMembersTimetable_defs.protect2(teachers) << "</th>\n";
			foreach (QString students, GlobalMembersStatisticsexport.allStudentsNames)
			{
				QList<int> tmpActivities = new QList<int>();
				tmpActivities.clear();
				tmpActivities = tmpStudents.values(students);
				if (tmpActivities.isEmpty())
				{
					switch (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL)
					{
						case 3 :
							;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
						case 4 :
							tos << "          <td class=\"empty\"><span class=\"empty\">" << GlobalMembersTimetable_defs.protect2(GlobalMembersStatisticsexport.STRING_EMPTY_SLOT_STATISTICS) << "</span></td>\n";
							break;
						case 5 :
							;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
						case 6 :
							tos << "          <td class=\"empty\"><span class=\"empty\" onmouseover=\"highlight('empty')\">" << GlobalMembersTimetable_defs.protect2(GlobalMembersStatisticsexport.STRING_EMPTY_SLOT_STATISTICS) << "</span></td>\n";
							break;
						default:
							tos << "          <td>" << GlobalMembersTimetable_defs.protect2(GlobalMembersStatisticsexport.STRING_EMPTY_SLOT_STATISTICS) << "</td>\n";
							break;
					}
				}
				else
				{
					QMap<QString, int> tmpSubjectDuration = new QMap<QString, int>(); //not QHash, because i need the correct order of the activities
					foreach (int tmpAct, tmpActivities)
					{
						Activity act = gt.rules.activitiesList[tmpAct];
						int tmpD = act.duration;
						QString tmpS = new QString();
						if (act.subjectName.size() > 0 || act.activityTagsNames.size() > 0)
						{
							if (act.subjectName.size() > 0)
								switch (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL)
								{
									case 3 :
										tmpS += "<span class=\"subject\">" + GlobalMembersTimetable_defs.protect2(act.subjectName) + "</span>";
										break;
									case 4 :
										tmpS += "<span class=\"subject\"><span class=\"s_" + GlobalMembersStatisticsexport.hashSubjectIDsStatistics.value(act.subjectName) + "\">" + GlobalMembersTimetable_defs.protect2(act.subjectName) + "</span></span>";
										break;
									case 5 :
										;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
									case 6 :
										tmpS += "<span class=\"subject\"><span class=\"s_" + GlobalMembersStatisticsexport.hashSubjectIDsStatistics.value(act.subjectName) + "\" onmouseover=\"highlight('s_" + GlobalMembersStatisticsexport.hashSubjectIDsStatistics.value(act.subjectName) + "')\">" + GlobalMembersTimetable_defs.protect2(act.subjectName) + "</span></span>";
										break;
									default:
										tmpS += GlobalMembersTimetable_defs.protect2(act.subjectName);
										break;
								}
							for (QStringList.Iterator atn = act.activityTagsNames.begin(); atn != act.activityTagsNames.end(); atn++)
							{
								switch (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL)
								{
									case 3 :
										tmpS += " <span class=\"activitytag\">" + GlobalMembersTimetable_defs.protect2(*atn) + "</span>";
										break;
									case 4 :
										tmpS += " <span class=\"activitytag\"><span class=\"at_" + GlobalMembersStatisticsexport.hashActivityTagIDsStatistics.value(*atn) + "\">" + GlobalMembersTimetable_defs.protect2(*atn) + "</span></span>";
										break;
									case 5 :
										;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
									case 6 :
										tmpS += " <span class=\"activitytag\"><span class=\"at_" + GlobalMembersStatisticsexport.hashActivityTagIDsStatistics.value(*atn) + "\" onmouseover=\"highlight('at_" + GlobalMembersStatisticsexport.hashActivityTagIDsStatistics.value(*atn) + "')\">" + GlobalMembersTimetable_defs.protect2(*atn) + "</span></span>";
										break;
									default:
										tmpS += " " + GlobalMembersTimetable_defs.protect2(*atn);
										break;
								}
								if (atn != act.activityTagsNames.end() - 1)
									tmpS += ", ";
							}
						}
						else
							tmpS = " ";
						tmpD += tmpSubjectDuration.value(tmpS);
						tmpSubjectDuration.insert(tmpS, tmpD);
					}
					if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 1)
						tos << "          <td><table class=\"detailed\">";
					else
						tos << "          <td><table>";
					if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 3)
						tos << "<tr class=\"duration line1\">";
					else
						tos << "<tr>";
					QMapIterator<QString, int> it = new QMapIterator<QString, int>(tmpSubjectDuration);
					while (it.hasNext())
					{
						it.next();
						if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 1)
							tos << "<td class=\"detailed\">";
						else
							tos << "<td>";
						tos << it.value() << "</td>";
					}
					tos << "</tr>";
					if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 3)
						tos << "<tr class=\"subject line2\">";
					else
						tos << "<tr>";
					QMapIterator<QString, int> it2 = new QMapIterator<QString, int>(tmpSubjectDuration); //do it with the same iterator
					while (it2.hasNext())
					{
						it2.next();
						if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 1)
							tos << "<td class=\"detailed\">";
						else
							tos << "<td>";
						tos << it2.key() << "</td>";
					}
					tos << "</tr>";
					tos << "</table></td>\n";
				}
			}
			tos << "          <th>";
			tos << CustomFETString.number(GlobalMembersStatisticsexport.teachersTotalNumberOfHours.value(teachers));
			if (GlobalMembersStatisticsexport.teachersTotalNumberOfHours.value(teachers) != GlobalMembersStatisticsexport.teachersTotalNumberOfHours2.value(teachers))
				tos << "<br />(" << CustomFETString.number(GlobalMembersStatisticsexport.teachersTotalNumberOfHours2.value(teachers)) << ")";
			tos << "</th>\n";
			tos << "        </tr>\n";
		}

		progress.setValue(GlobalMembersStatisticsexport.allTeachersNames.count());

		tos << "        <tr>\n";
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 2)
			tos << "          <th class=\"xAxis\">";
		else
			tos << "          <th>";
		tos << GlobalMembersTimetable_defs.protect2(tr("Sum", "This means the sum of more values, the total")) << "</th>\n";
		foreach (QString students, GlobalMembersStatisticsexport.allStudentsNames)
		{
			tos << "          <th>" << CustomFETString.number(GlobalMembersStatisticsexport.studentsTotalNumberOfHours.value(students));
			if (GlobalMembersStatisticsexport.studentsTotalNumberOfHours.value(students) != GlobalMembersStatisticsexport.studentsTotalNumberOfHours2.value(students))
				tos << "<br />(" << CustomFETString.number(GlobalMembersStatisticsexport.studentsTotalNumberOfHours2.value(students)) << ")";
			tos << "</th>\n";
		}
		tos << "          <th></th>\n        </tr>\n";
		//workaround begin.
		tos << "      <tr class=\"foot\"><td></td><td colspan=\"" << GlobalMembersStatisticsexport.allStudentsNames.size() + 1 << "\">" << StatisticsExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) << "</td></tr>\n";
		//workaround end.
		tos << "      </tbody>\n";
		tos << "    </table>\n";
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			QMessageBox.critical(parent, tr("FET critical"), StatisticsExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
			return false;
		}
		file.close();
		return true;
	}
	private static bool exportStatisticsSubjectsStudents(QWidget parent, QString saveTime)
	{
		Debug.Assert(gt.rules.initialized); // && gt.rules.internalStructureComputed);
		QString s2 = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1); //TODO: remove s2, because to long filenames!

		if (s2.right(4) == ".fet")
			s2 = s2.left(s2.length() - 4);
		//else if(INPUT_FILENAME_XML!="")
		//	cout<<"Minor problem - input file does not end in .fet extension - might be a problem when saving the timetables"<<" (file:"<<__FILE__<<", line:"<<__LINE__<<")"<<endl;

		QString bar = new QString();
		if (INPUT_FILENAME_XML == "")
			bar = "";
		else
			bar = "_";

		QString htmlfilename = GlobalMembersStatisticsexport.PREFIX_STATISTICS + s2 + bar + GlobalMembersStatisticsexport.SUBJECTS_STUDENTS_STATISTICS;

		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			QMessageBox.critical(parent, tr("FET critical"), StatisticsExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return false;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);

		tos << "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Strict//EN\"\n";
		tos << "  \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\">\n\n";

		if (GlobalMembersTimetable_defs.LANGUAGE_STYLE_RIGHT_TO_LEFT == false)
			tos << "<html xmlns=\"http://www.w3.org/1999/xhtml\" lang=\"" << GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML << "\" xml:lang=\"" << GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML << "\">\n";
		else
			tos << "<html xmlns=\"http://www.w3.org/1999/xhtml\" lang=\"" << GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML << "\" xml:lang=\"" << GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML << "\" dir=\"rtl\">\n";
		tos << "  <head>\n";
		tos << "    <title>" << GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) << "</title>\n";
		tos << "    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\n";
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 1)
		{
			QString bar = new QString();
			if (INPUT_FILENAME_XML == "")
				bar = "";
			else
				bar = "_";

			QString cssfilename = s2 + bar + GlobalMembersStatisticsexport.STYLESHEET_STATISTICS;
			tos << "    <link rel=\"stylesheet\" media=\"all\" href=\"" << cssfilename << "\" type=\"text/css\" />\n";
		}
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 5) // the following JavaScript code is pretty similar to an example of Les Richardson
		{
			tos << "    <meta http-equiv=\"Content-Script-Type\" content=\"text/javascript\" />\n";
			tos << "    <script type=\"text/javascript\">\n";
			tos << "      function highlight(classval) {\n";
			tos << "        var spans = document.getElementsByTagName('span');\n";
			tos << "        for(var i=0;spans.length>i;i++) {\n";
			tos << "          if (spans[i].className == classval) {\n";
			tos << "            spans[i].style.backgroundColor = 'lime';\n";
			tos << "          } else {\n";
			tos << "            spans[i].style.backgroundColor = 'white';\n";
			tos << "          }\n";
			tos << "        }\n";
			tos << "      }\n";
			tos << "    </script>\n";
		}
		tos << "  </head>\n\n";

		tos << "  <body>\n";
		tos << "    <table border=\"1\">\n";
		tos << "      <caption>" << GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) << "</caption>\n";
		tos << "      <thead>\n        <tr><td rowspan=\"2\"></td><th colspan=\"" << GlobalMembersStatisticsexport.allSubjectsNames.size() + 1 << "\">" << tr("Subjects - Students Matrix") << "</th></tr>\n";
		tos << "        <tr>\n          <!-- span -->\n";
		foreach (QString subjects, GlobalMembersStatisticsexport.allSubjectsNames)
		{
			if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 2)
				tos << "          <th class=\"xAxis\">";
			else
				tos << "          <th>";
			tos << GlobalMembersTimetable_defs.protect2(subjects) << "</th>\n";
		}
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 2)
			tos << "          <th class=\"xAxis\">";
		else
			tos << "          <th>";
		tos << GlobalMembersTimetable_defs.protect2(tr("Sum", "This means the sum of more values, the total")) << "</th>\n";
		tos << "        </tr>\n";
		tos << "      </thead>\n";
		tos << "      <tbody>\n";

		QProgressDialog progress = new QProgressDialog(parent);
		progress.setWindowTitle(tr("Exporting statistics", "Title of a progress dialog"));
		progress.setLabelText(tr("Processing subjects with students...please wait"));
		progress.setRange(0, GlobalMembersStatisticsexport.allStudentsNames.count());
		progress.setModal(true);

		int ttt = 0;

		foreach (QString students, GlobalMembersStatisticsexport.allStudentsNames)
		{
			progress.setValue(ttt);
			//pqapplication->processEvents();
			if (progress.wasCanceled())
			{
				QMessageBox.warning(parent, tr("FET warning"), tr("Canceled"));
				return false;
			}
			ttt++;

			QList<int> tmpStudents = new QList<int>();
			QMultiHash<QString, int> tmpSubjects = new QMultiHash<QString, int>();
			tmpStudents.clear();
			tmpSubjects.clear();
			tmpStudents = GlobalMembersStatisticsexport.studentsActivities.values(students);
			foreach (int aidx, tmpStudents)
			{
				Activity act = gt.rules.activitiesList.at(aidx);
				tmpSubjects.insert(act.subjectName, aidx);
			}
			tos << "        <tr>\n";
			if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 2)
				tos << "          <th class=\"yAxis\">";
			else
				tos << "          <th>";
			tos << GlobalMembersTimetable_defs.protect2(students) << "</th>\n";
			foreach (QString subjects, GlobalMembersStatisticsexport.allSubjectsNames)
			{
				QList<int> tmpActivities = new QList<int>();
				tmpActivities.clear();
				tmpActivities = tmpSubjects.values(subjects);
				if (tmpActivities.isEmpty())
				{
					switch (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL)
					{
						case 3 :
							;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
						case 4 :
							tos << "          <td class=\"empty\"><span class=\"empty\">" << GlobalMembersTimetable_defs.protect2(GlobalMembersStatisticsexport.STRING_EMPTY_SLOT_STATISTICS) << "</span></td>\n";
							break;
						case 5 :
							;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
						case 6 :
							tos << "          <td class=\"empty\"><span class=\"empty\" onmouseover=\"highlight('empty')\">" << GlobalMembersTimetable_defs.protect2(GlobalMembersStatisticsexport.STRING_EMPTY_SLOT_STATISTICS) << "</span></td>\n";
							break;
						default:
							tos << "          <td>" << GlobalMembersTimetable_defs.protect2(GlobalMembersStatisticsexport.STRING_EMPTY_SLOT_STATISTICS) << "</td>\n";
							break;
					}
				}
				else
				{
					QMap<QString, int> tmpTeacherDuration = new QMap<QString, int>(); //not QHash, because i need the correct order of the activities
					foreach (int tmpAct, tmpActivities)
					{
						Activity act = gt.rules.activitiesList[tmpAct];
						int tmpD = act.duration;
						QString tmpT = new QString();
						if (act.teachersNames.size() > 0)
						{
							for (QStringList.Iterator it = act.teachersNames.begin(); it != act.teachersNames.end(); it++)
							{
								switch (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL)
								{
									case 4 :
										tmpT += "<span class=\"t_" + GlobalMembersStatisticsexport.hashTeacherIDsStatistics.value(*it) + "\">" + GlobalMembersTimetable_defs.protect2(*it) + "</span>";
										break;
									case 5 :
										;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
									case 6 :
										tmpT += "<span class=\"t_" + GlobalMembersStatisticsexport.hashTeacherIDsStatistics.value(*it) + "\" onmouseover=\"highlight('t_" + GlobalMembersStatisticsexport.hashTeacherIDsStatistics.value(*it) + "')\">" + GlobalMembersTimetable_defs.protect2(*it) + "</span>";
										break;
									default:
										tmpT += GlobalMembersTimetable_defs.protect2(*it);
										break;
								}
								if (it != act.teachersNames.end() - 1)
									tmpT += ", ";
							}
						}
						else
							tmpT = " ";
						tmpD += tmpTeacherDuration.value(tmpT);
						tmpTeacherDuration.insert(tmpT, tmpD);
					}
					if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 1)
						tos << "          <td><table class=\"detailed\">";
					else
						tos << "          <td><table>";
					if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 3)
						tos << "<tr class=\"duration line1\">";
					else
						tos << "<tr>";
					QMapIterator<QString, int> it = new QMapIterator<QString, int>(tmpTeacherDuration);
					while (it.hasNext())
					{
						it.next();
						if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 1)
							tos << "<td class=\"detailed\">";
						else
							tos << "<td>";
						tos << it.value() << "</td>";
					}
					tos << "</tr>";
					if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 3)
						tos << "<tr class=\"teacher line2\">";
					else
						tos << "<tr>";
					QMapIterator<QString, int> it2 = new QMapIterator<QString, int>(tmpTeacherDuration); //do it with the same iterator
					while (it2.hasNext())
					{
						it2.next();
						if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 1)
							tos << "<td class=\"detailed\">";
						else
							tos << "<td>";
						tos << it2.key() << "</td>";
					}
					tos << "</tr>";
					tos << "</table></td>\n";
				}
			}
			tos << "          <th>";
			tos << CustomFETString.number(GlobalMembersStatisticsexport.studentsTotalNumberOfHours.value(students));
			if (GlobalMembersStatisticsexport.studentsTotalNumberOfHours.value(students) != GlobalMembersStatisticsexport.studentsTotalNumberOfHours2.value(students))
				tos << "<br />(" << CustomFETString.number(GlobalMembersStatisticsexport.studentsTotalNumberOfHours2.value(students)) << ")";
			tos << "</th>\n";
			tos << "        </tr>\n";
		}

		progress.setValue(GlobalMembersStatisticsexport.allStudentsNames.count());

		tos << "        <tr>\n";
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 2)
			tos << "          <th class=\"xAxis\">";
		else
			tos << "          <th>";
		tos << GlobalMembersTimetable_defs.protect2(tr("Sum", "This means the sum of more values, the total")) << "</th>\n";
		foreach (QString subjects, GlobalMembersStatisticsexport.allSubjectsNames)
		{
			tos << "          <th>" << CustomFETString.number(GlobalMembersStatisticsexport.subjectsTotalNumberOfHours.value(subjects));
			if (GlobalMembersStatisticsexport.subjectsTotalNumberOfHours.value(subjects) != GlobalMembersStatisticsexport.subjectsTotalNumberOfHours4.value(subjects))
				tos << "<br />(" << CustomFETString.number(GlobalMembersStatisticsexport.subjectsTotalNumberOfHours4.value(subjects)) << ")";
			tos << "</th>\n";
		}
		tos << "          <th></th>\n        </tr>\n";
		//workaround begin.
		tos << "      <tr class=\"foot\"><td></td><td colspan=\"" << GlobalMembersStatisticsexport.allTeachersNames.size() + 1 << "\">" << StatisticsExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) << "</td></tr>\n";
		//workaround end.
		tos << "      </tbody>\n";
		tos << "    </table>\n";
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			QMessageBox.critical(parent, tr("FET critical"), StatisticsExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
			return false;
		}
		file.close();
		return true;
	}
	private static bool exportStatisticsStudentsSubjects(QWidget parent, QString saveTime)
	{
		Debug.Assert(gt.rules.initialized); // && gt.rules.internalStructureComputed);
		QString s2 = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1); //TODO: remove s2, because to long filenames!

		if (s2.right(4) == ".fet")
			s2 = s2.left(s2.length() - 4);
		//else if(INPUT_FILENAME_XML!="")
		//	cout<<"Minor problem - input file does not end in .fet extension - might be a problem when saving the timetables"<<" (file:"<<__FILE__<<", line:"<<__LINE__<<")"<<endl;

		QString bar = new QString();
		if (INPUT_FILENAME_XML == "")
			bar = "";
		else
			bar = "_";

		QString htmlfilename = GlobalMembersStatisticsexport.PREFIX_STATISTICS + s2 + bar + GlobalMembersStatisticsexport.STUDENTS_SUBJECTS_STATISTICS;

		QFile file = new QFile(htmlfilename);
		if (!file.open(QIODevice.WriteOnly))
		{
			QMessageBox.critical(parent, tr("FET critical"), StatisticsExport.tr("Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(htmlfilename));
			return false;
			Debug.Assert(0);
		}
		QTextStream tos = new QTextStream(file);
		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);
		tos << "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Strict//EN\"\n";
		tos << "  \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\">\n\n";

		if (GlobalMembersTimetable_defs.LANGUAGE_STYLE_RIGHT_TO_LEFT == false)
			tos << "<html xmlns=\"http://www.w3.org/1999/xhtml\" lang=\"" << GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML << "\" xml:lang=\"" << GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML << "\">\n";
		else
			tos << "<html xmlns=\"http://www.w3.org/1999/xhtml\" lang=\"" << GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML << "\" xml:lang=\"" << GlobalMembersTimetable_defs.LANGUAGE_FOR_HTML << "\" dir=\"rtl\">\n";
		tos << "  <head>\n";
		tos << "    <title>" << GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) << "</title>\n";
		tos << "    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\n";
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 1)
		{
			QString bar = new QString();
			if (INPUT_FILENAME_XML == "")
				bar = "";
			else
				bar = "_";

			QString cssfilename = s2 + bar + GlobalMembersStatisticsexport.STYLESHEET_STATISTICS;
			tos << "    <link rel=\"stylesheet\" media=\"all\" href=\"" << cssfilename << "\" type=\"text/css\" />\n";
		}
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 5) // the following JavaScript code is pretty similar to an example of Les Richardson
		{
			tos << "    <meta http-equiv=\"Content-Script-Type\" content=\"text/javascript\" />\n";
			tos << "    <script type=\"text/javascript\">\n";
			tos << "      function highlight(classval) {\n";
			tos << "        var spans = document.getElementsByTagName('span');\n";
			tos << "        for(var i=0;spans.length>i;i++) {\n";
			tos << "          if (spans[i].className == classval) {\n";
			tos << "            spans[i].style.backgroundColor = 'lime';\n";
			tos << "          } else {\n";
			tos << "            spans[i].style.backgroundColor = 'white';\n";
			tos << "          }\n";
			tos << "        }\n";
			tos << "      }\n";
			tos << "    </script>\n";
		}
		tos << "  </head>\n\n";

		tos << "  <body>\n";
		tos << "    <table border=\"1\">\n";
		tos << "      <caption>" << GlobalMembersTimetable_defs.protect2(gt.rules.institutionName) << "</caption>\n";
		tos << "      <thead>\n        <tr><td rowspan=\"2\"></td><th colspan=\"" << GlobalMembersStatisticsexport.allStudentsNames.size() + 1 << "\">" << tr("Students -Subjects Matrix") << "</th></tr>\n";
		tos << "        <tr>\n          <!-- span -->\n";

		foreach (QString students, GlobalMembersStatisticsexport.allStudentsNames)
		{
			if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 2)
				tos << "          <th class=\"xAxis\">";
			else
				tos << "          <th>";
			tos << GlobalMembersTimetable_defs.protect2(students) << "</th>\n";
		}
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 2)
			tos << "          <th class=\"xAxis\">";
		else
			tos << "          <th>";
		tos << GlobalMembersTimetable_defs.protect2(tr("Sum", "This means the sum of more values, the total")) << "</th>\n";
		tos << "        </tr>\n";
		tos << "      </thead>\n";
		tos << "      <tbody>\n";

		QProgressDialog progress = new QProgressDialog(parent);
		progress.setWindowTitle(tr("Exporting statistics", "Title of a progress dialog"));
		progress.setLabelText(tr("Processing students with subjects...please wait"));
		progress.setRange(0, GlobalMembersStatisticsexport.allSubjectsNames.count());
		progress.setModal(true);

		int ttt = 0;

		foreach (QString subjects, GlobalMembersStatisticsexport.allSubjectsNames)
		{
			progress.setValue(ttt);
			//pqapplication->processEvents();
			if (progress.wasCanceled())
			{
				QMessageBox.warning(parent, tr("FET warning"), tr("Canceled"));
				return false;
			}
			ttt++;

			QList<int> tmpSubjects = new QList<int>();
			QMultiHash<QString, int> tmpStudents = new QMultiHash<QString, int>();
			tmpSubjects.clear();
			tmpStudents.clear();
			tmpSubjects = GlobalMembersStatisticsexport.subjectsActivities.values(subjects);
			foreach (int aidx, tmpSubjects)
			{
				Activity act = gt.rules.activitiesList.at(aidx);
				foreach (QString students, act.studentsNames)
				{
					tmpStudents.insert(students, aidx);
				}
			}
			tos << "        <tr>\n";
			if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 2)
				tos << "          <th class=\"yAxis\">";
			else
				tos << "          <th>";
			tos << GlobalMembersTimetable_defs.protect2(subjects) << "</th>\n";
			foreach (QString students, GlobalMembersStatisticsexport.allStudentsNames)
			{
				QList<int> tmpActivities = new QList<int>();
				tmpActivities.clear();
				tmpActivities = tmpStudents.values(students);
				if (tmpActivities.isEmpty())
				{
					switch (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL)
					{
						case 3 :
							;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
						case 4 :
							tos << "          <td class=\"empty\"><span class=\"empty\">" << GlobalMembersTimetable_defs.protect2(GlobalMembersStatisticsexport.STRING_EMPTY_SLOT_STATISTICS) << "</span></td>\n";
							break;
						case 5 :
							;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
						case 6 :
							tos << "          <td class=\"empty\"><span class=\"empty\" onmouseover=\"highlight('empty')\">" << GlobalMembersTimetable_defs.protect2(GlobalMembersStatisticsexport.STRING_EMPTY_SLOT_STATISTICS) << "</span></td>\n";
							break;
						default:
							tos << "          <td>" << GlobalMembersTimetable_defs.protect2(GlobalMembersStatisticsexport.STRING_EMPTY_SLOT_STATISTICS) << "</td>\n";
							break;
					}
				}
				else
				{
					QMap<QString, int> tmpTeacherDuration = new QMap<QString, int>(); //not QHash, because i need the correct order of the activities
					foreach (int tmpAct, tmpActivities)
					{
						Activity act = gt.rules.activitiesList[tmpAct];
						int tmpD = act.duration;
						QString tmpT = new QString();
						if (act.teachersNames.size() > 0)
						{
							for (QStringList.Iterator it = act.teachersNames.begin(); it != act.teachersNames.end(); it++)
							{
								switch (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL)
								{
									case 4 :
										tmpT += "<span class=\"t_" + GlobalMembersStatisticsexport.hashTeacherIDsStatistics.value(*it) + "\">" + GlobalMembersTimetable_defs.protect2(*it) + "</span>";
										break;
									case 5 :
										;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
									case 6 :
										tmpT += "<span class=\"t_" + GlobalMembersStatisticsexport.hashTeacherIDsStatistics.value(*it) + "\" onmouseover=\"highlight('t_" + GlobalMembersStatisticsexport.hashTeacherIDsStatistics.value(*it) + "')\">" + GlobalMembersTimetable_defs.protect2(*it) + "</span>";
										break;
									default:
										tmpT += GlobalMembersTimetable_defs.protect2(*it);
										break;
								}
								if (it != act.teachersNames.end() - 1)
									tmpT += ", ";
							}
						}
						else
							tmpT = " ";
						tmpD += tmpTeacherDuration.value(tmpT);
						tmpTeacherDuration.insert(tmpT, tmpD);
					}
					if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 1)
						tos << "          <td><table class=\"detailed\">";
					else
						tos << "          <td><table>";
					if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 3)
						tos << "<tr class=\"duration line1\">";
					else
						tos << "<tr>";
					QMapIterator<QString, int> it = new QMapIterator<QString, int>(tmpTeacherDuration);
					while (it.hasNext())
					{
						it.next();
						if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 1)
							tos << "<td class=\"detailed\">";
						else
							tos << "<td>";
						tos << it.value() << "</td>";
					}
					tos << "</tr>";
					if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 3)
						tos << "<tr class=\"teacher line2\">";
					else
						tos << "<tr>";
					QMapIterator<QString, int> it2 = new QMapIterator<QString, int>(tmpTeacherDuration); //do it with the same iterator
					while (it2.hasNext())
					{
						it2.next();
						if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 1)
							tos << "<td class=\"detailed\">";
						else
							tos << "<td>";
						tos << it2.key() << "</td>";
					}
					tos << "</tr>";
					tos << "</table></td>\n";
				}
			}
			tos << "          <th>";
			tos << CustomFETString.number(GlobalMembersStatisticsexport.subjectsTotalNumberOfHours.value(subjects));
			if (GlobalMembersStatisticsexport.subjectsTotalNumberOfHours.value(subjects) != GlobalMembersStatisticsexport.subjectsTotalNumberOfHours4.value(subjects))
				tos << "<br />(" << CustomFETString.number(GlobalMembersStatisticsexport.subjectsTotalNumberOfHours4.value(subjects)) << ")";
			tos << "</th>\n";
			tos << "        </tr>\n";
		}

		progress.setValue(GlobalMembersStatisticsexport.allSubjectsNames.count());

		tos << "        <tr>\n";
		if (GlobalMembersTimetable_defs.TIMETABLE_HTML_LEVEL >= 2)
			tos << "          <th class=\"xAxis\">";
		else
			tos << "          <th>";
		tos << GlobalMembersTimetable_defs.protect2(tr("Sum", "This means the sum of more values, the total")) << "</th>\n";
		foreach (QString students, GlobalMembersStatisticsexport.allStudentsNames)
		{
			tos << "          <th>" << CustomFETString.number(GlobalMembersStatisticsexport.studentsTotalNumberOfHours.value(students));
			if (GlobalMembersStatisticsexport.studentsTotalNumberOfHours.value(students) != GlobalMembersStatisticsexport.studentsTotalNumberOfHours2.value(students))
				tos << "<br />(" << CustomFETString.number(GlobalMembersStatisticsexport.studentsTotalNumberOfHours2.value(students)) << ")";
			tos << "</th>\n";
		}
		tos << "          <th></th>\n        </tr>\n";
		//workaround begin.
		tos << "      <tr class=\"foot\"><td></td><td colspan=\"" << GlobalMembersStatisticsexport.allStudentsNames.size() + 1 << "\">" << StatisticsExport.tr("Timetable generated with FET %1 on %2", "%1 is FET version, %2 is the date and time of generation").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(saveTime) << "</td></tr>\n";
		//workaround end.
		tos << "      </tbody>\n";
		tos << "    </table>\n";
		tos << "  </body>\n</html>\n";

		if (file.error() > 0)
		{
			QMessageBox.critical(parent, tr("FET critical"), StatisticsExport.tr("Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(htmlfilename).arg(file.error()));
			return false;
		}
		file.close();
		return true;
	}
}

//C++ TO C# CONVERTER WARNING: The declaration of the following method implementation was not found:
//ORIGINAL LINE: StatisticsExport::StatisticsExport()


public partial class StatisticsExport
{
	public StatisticsExport()
	{
	}
}