using System.Diagnostics;

public static class GlobalMembersImport
{

	internal const int DO_NOT_IMPORT = -2;
	internal const int IMPORT_DEFAULT_ITEM = -1;

	internal const int FIELD_LINE_NUMBER = 0;

	internal const int FIELD_YEAR_NAME = 1;
	internal const int FIELD_YEAR_NUMBER_OF_STUDENTS = 2;
	internal const int FIELD_GROUP_NAME = 3;
	internal const int FIELD_GROUP_NUMBER_OF_STUDENTS = 4;
	internal const int FIELD_SUBGROUP_NAME = 5;
	internal const int FIELD_SUBGROUP_NUMBER_OF_STUDENTS = 6;

	internal const int FIELD_SUBJECT_NAME = 7;

	internal const int FIELD_ACTIVITY_TAG_NAME = 8;

	internal const int FIELD_TEACHER_NAME = 9;

	internal const int FIELD_BUILDING_NAME = 10;
	internal const int FIELD_ROOM_NAME = 11;
	internal const int FIELD_ROOM_CAPACITY = 12;

	internal const int FIELD_ACTIVITY_TAGS_SET = 13;

	internal const int FIELD_STUDENTS_SET = 14;
	internal const int FIELD_TEACHERS_SET = 15;

	internal const int FIELD_TOTAL_DURATION = 16;
	internal const int FIELD_SPLIT_DURATION = 17;
	internal const int FIELD_MIN_DAYS = 18;
	internal const int FIELD_MIN_DAYS_WEIGHT = 19;
	internal const int FIELD_MIN_DAYS_CONSECUTIVE = 20;

	internal const int NUMBER_OF_FIELDS = 21;




	//C++ TO C# CONVERTER TODO TASK: C# does not allow setting or comparing #define constants:
	#if QT_VERSION >= 0x050000
	#else
	#endif



//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern Timetable gt;

	// maybe I can add some of them again as parameter into function name?
	// it is not possible with fieldNumber and fieldName, because that conflicts with the using of command connect with chooseFieldsDialogUpdate (there are no parameters possible)
	internal static QString fileName = new QString(); // file name of the csv file

	internal static QString fieldSeparator = ",";
	internal static QString textquote = "\"";
	internal static QString setSeparator = "+";

	internal static QString importThing = new QString();

	internal static int numberOfFields; // number of fields per line of the csv file
	internal static QStringList fields = new QStringList(); // list of the fields of the first line of the csv file
	internal static bool head; // true = first line of csv file contain heading, so skip this line
	internal static QString[] fieldName = new QString[NUMBER_OF_FIELDS]; // field name (normally similar to the head)
	internal static int[] fieldNumber = new int[NUMBER_OF_FIELDS]; // field number in the csv file
								// fieldNumber >= 0 is the number of the field
								// fieldNumber can also be IMPORT_DEFAULT_ITEM (==IMPORT_DEFAULT_ITEM). That mean that items of fieldList get the name of fieldDefaultItem (not of field[fieldNumber] from csv
								// fieldNumber can also be DO_NOT_IMPORT (==-2). That mean that items are not imported into fieldList.
	internal static QStringList[] fieldList = new QStringList[NUMBER_OF_FIELDS]; // items of the fields (items from "field number")
	internal static QString[] fieldDefaultItem = new QString[NUMBER_OF_FIELDS]; // used, if fieldNumber == IMPORT_DEFAULT_ITEM
	internal static QString warnText = new QString(); // warnings about the csv file
	internal static QStringList dataWarning = new QStringList(); // warnings about the current conflicts between the csv file and the data that is already in memory
	internal static QString lastWarning = new QString();
}

/*
File import.cpp
*/

/***************************************************************************
                                FET
                          -------------------
   copyright            : (C) by Lalescu Liviu
    email                : Please see http://lalescu.ro/liviu/ for details about contacting Liviu Lalescu (in particular, you can find here the e-mail address)
 ***************************************************************************
                          import.cpp  -  description
                             -------------------
    begin                : Mar 2008
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

//TODO: import days per week
//TODO: import hours per day

/*
File import.h
*/

/***************************************************************************
                                FET
                          -------------------
   copyright            : (C) by Lalescu Liviu
    email                : Please see http://lalescu.ro/liviu/ for details about contacting Liviu Lalescu (in particular, you can find here the e-mail address)
 ***************************************************************************
                          import.h  -  description
                             -------------------
    begin                : Mar 2008
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



#if NDEBUG
#endif

//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class QGroupBox;
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class QLineEdit;
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class QRadioButton;
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class QComboBox;
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class QPushButton;
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class QSpinBox;
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class QHBoxLayout;

public class Import: QObject
{
	private static int chooseWidth(int w)
	{
		int ww = w;
		if (ww > 1000)
			ww = 1000;

		return ww;
	}
	private static int chooseHeight(int h)
	{
		int hh = h;
		if (hh > 650)
			hh = 650;

		return hh;
	}

	public Import()
	{
	}
	public void Dispose()
	{
	}

	public static void importCSVActivities(QWidget parent)
	{
		prearrangement();
		GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_STUDENTS_SET] = GlobalMembersImport.IMPORT_DEFAULT_ITEM;
		GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_SUBJECT_NAME] = GlobalMembersImport.IMPORT_DEFAULT_ITEM;
		GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_TEACHERS_SET] = GlobalMembersImport.IMPORT_DEFAULT_ITEM;
		GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_ACTIVITY_TAGS_SET] = GlobalMembersImport.IMPORT_DEFAULT_ITEM;
		GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_TOTAL_DURATION] = GlobalMembersImport.IMPORT_DEFAULT_ITEM;
		GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_SPLIT_DURATION] = GlobalMembersImport.IMPORT_DEFAULT_ITEM;
		GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_MIN_DAYS] = GlobalMembersImport.IMPORT_DEFAULT_ITEM;
		GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_MIN_DAYS_WEIGHT] = GlobalMembersImport.IMPORT_DEFAULT_ITEM;
		GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_MIN_DAYS_CONSECUTIVE] = GlobalMembersImport.IMPORT_DEFAULT_ITEM;

		int ok;

		QDialog newParent;
		ok = getFileSeparatorFieldsAndHead(parent, ref newParent);
		//DON'T ADD THIS! newParent->deleteLater();
		if (ok == 0)
			return;

		if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_SUBJECT_NAME] == GlobalMembersImport.IMPORT_DEFAULT_ITEM)
		{
			QDialog newParent2 = new ChooseFieldsDialog(newParent);
			QString settingsName = new QString("ImportActivitiesChooseFieldsDialog");
			//DON'T ADD THIS! newParent2->deleteLater();
			newParent = newParent2;
			ChooseFieldsDialog cfd = ((ChooseFieldsDialog)newParent);
			int w = chooseWidth(cfd.sizeHint().width());
			int h = chooseHeight(cfd.sizeHint().height());
			cfd.resize(w,h);
			centerWidgetOnScreen(cfd);
			restoreFETDialogGeometry(cfd, settingsName);

			ok = cfd.exec();
			saveFETDialogGeometry(cfd, settingsName);
		}
		if (ok == 0)
			return;

		if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_SPLIT_DURATION] == GlobalMembersImport.DO_NOT_IMPORT GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_TOTAL_DURATION] == GlobalMembersImport.DO_NOT_IMPORT)
		{
			QMessageBox.warning(newParent, tr("FET warning"), Import.tr("FET need to know %1 or %2 if you import %3.").arg(GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_SPLIT_DURATION]).arg(GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_TOTAL_DURATION]).arg(GlobalMembersImport.importThing));
			return;
		}

		ok = readFields(newParent);
		if (ok == 0)
			return;

		//check number of fields (start) //because of bug reported 17.03.2008
		int checkNumber = 0;
		if (GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_STUDENTS_SET].size() > 0)
		{
			checkNumber = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_STUDENTS_SET].size();
		}
		if (GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SUBJECT_NAME].size() > 0)
		{
			if (checkNumber > 0)
			{
				Debug.Assert(checkNumber == GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SUBJECT_NAME].size());
			}
			checkNumber = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SUBJECT_NAME].size();
		}
		if (GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_TEACHERS_SET].size() > 0)
		{
			if (checkNumber > 0)
			{
				Debug.Assert(checkNumber == GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_TEACHERS_SET].size());
			}
			checkNumber = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_TEACHERS_SET].size();
		}
		if (GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_ACTIVITY_TAGS_SET].size() > 0)
		{
			if (checkNumber > 0)
			{
				Debug.Assert(checkNumber == GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_ACTIVITY_TAGS_SET].size());
			}
			checkNumber = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_ACTIVITY_TAGS_SET].size();
		}
		if (GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_TOTAL_DURATION].size() > 0)
		{
			if (checkNumber > 0)
			{
				Debug.Assert(checkNumber == GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_TOTAL_DURATION].size());
			}
			checkNumber = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_TOTAL_DURATION].size();
		}
		if (GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SPLIT_DURATION].size() > 0)
		{
			if (checkNumber > 0)
			{
				Debug.Assert(checkNumber == GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SPLIT_DURATION].size());
			}
			checkNumber = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SPLIT_DURATION].size();
		}
		if (GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_MIN_DAYS].size() > 0)
		{
			if (checkNumber > 0)
			{
				Debug.Assert(checkNumber == GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_MIN_DAYS].size());
			}
			checkNumber = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_MIN_DAYS].size();
		}
		if (GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_MIN_DAYS_WEIGHT].size() > 0)
		{
			if (checkNumber > 0)
			{
				Debug.Assert(checkNumber == GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_MIN_DAYS_WEIGHT].size());
			}
			checkNumber = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_MIN_DAYS_WEIGHT].size();
		}
		if (GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_MIN_DAYS_CONSECUTIVE].size() > 0)
		{
			if (checkNumber > 0)
			{
				Debug.Assert(checkNumber == GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_MIN_DAYS_CONSECUTIVE].size());
			}
			checkNumber = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_MIN_DAYS_CONSECUTIVE].size();
		}

		if (GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_STUDENTS_SET].size() == 0)
		{
			for (int i = 0; i < checkNumber; i++)
				GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_STUDENTS_SET] << "";
		}
		if (GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SUBJECT_NAME].size() == 0)
		{
			for (int i = 0; i < checkNumber; i++)
				GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SUBJECT_NAME] << "";
		}
		if (GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_TEACHERS_SET].size() == 0)
		{
			for (int i = 0; i < checkNumber; i++)
				GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_TEACHERS_SET] << "";
		}
		if (GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_ACTIVITY_TAGS_SET].size() == 0)
		{
			for (int i = 0; i < checkNumber; i++)
				GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_ACTIVITY_TAGS_SET] << "";
		}
		if (GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_TOTAL_DURATION].size() == 0)
		{
			for (int i = 0; i < checkNumber; i++)
				GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_TOTAL_DURATION] << "1";
		}
		if (GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SPLIT_DURATION].size() == 0)
		{
			for (int i = 0; i < checkNumber; i++)
				GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SPLIT_DURATION] << "1";
		}
		if (GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_MIN_DAYS].size() == 0)
		{
			for (int i = 0; i < checkNumber; i++)
				GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_MIN_DAYS] << "1";
		}
		if (GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_MIN_DAYS_WEIGHT].size() == 0)
		{
			for (int i = 0; i < checkNumber; i++)
				GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_MIN_DAYS_WEIGHT] << "95";
		}
		if (GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_MIN_DAYS_CONSECUTIVE].size() == 0)
		{
			for (int i = 0; i < checkNumber; i++)
				GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_MIN_DAYS_CONSECUTIVE] << "no";
		}

		//check number of fields (end) //because of bug reported 17.03.2008

		//check if already in memory (start)
		//check if students set is in memory
		GlobalMembersImport.lastWarning.clear();
		QString line = new QString();
		QStringList students = new QStringList();
		bool firstWarning = true;
		for (int i = 0; i < GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_STUDENTS_SET].size(); i++)
		{
			line.clear();
			line = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_STUDENTS_SET][i];
			students.clear();
			students = line.split("+");
			if (!GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_STUDENTS_SET][i].isEmpty())
			{
				for (int s = 0; s < students.size(); s++)
				{
					StudentsSet ss = gt.rules.searchStudentsSet(students[s]);
					if (ss == null)
					{
						if (firstWarning)
						{
							GlobalMembersImport.lastWarning += Import.tr("FET can't import activities, because FET needs to know the stucture of the " + "students sets. You must add (or import) years, groups and subgroups first.") + "\n" + tr("I recommend to import also teachers, rooms, buildings, subjects and activity tags before " + "importing activities. It is not needed, because FET will automatically do it, but you can " + "check the activity csv file by that.") + "\n";
							firstWarning = false;
						}
						GlobalMembersImport.lastWarning += Import.tr("Student set %1 doesn't exist. You must add (or import) years, groups and subgroups first.").arg(students[s]) + "\n";
					}
				}
			}
		}
		if (GlobalMembersImport.lastWarning.size() > 0)
		{
			QDialog newParent2 = new LastWarningsDialog(newParent);
			//DON'T ADD THIS! newParent2->deleteLater();
			newParent = newParent2;
			LastWarningsDialog lwd = ((LastWarningsDialog)newParent);
			int w = chooseWidth(lwd.sizeHint().width());
			int h = chooseHeight(lwd.sizeHint().height());
			lwd.resize(w,h);
			centerWidgetOnScreen(lwd);

			ok = lwd.exec();
			return;
		}
		//check if teacher is in memory
		Debug.Assert(GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_TEACHER_NAME].isEmpty());
		QStringList teachers = new QStringList();
		QStringList tmpList = new QStringList();
		tmpList.clear();
		for (int i = 0; i < gt.rules.teachersList.size(); i++)
		{
			Teacher t = gt.rules.teachersList[i];
			tmpList << t.name;
		}
		for (int i = 0; i < GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_TEACHERS_SET].size(); i++)
		{
			line.clear();
			line = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_TEACHERS_SET][i];
			teachers.clear();
			teachers = line.split("+");
			for (int t = 0; t < teachers.size(); t++)
			{
				bool add = true;
				if (tmpList.contains(teachers[t]) || teachers[t] == "")
					add = false;
				if (add)
				{
					GlobalMembersImport.dataWarning << Import.tr("%1 %2 will be added.", "For instance 'Subject Math will be added', so use singular").arg(GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_TEACHER_NAME]).arg(teachers[t]);
					tmpList << teachers[t];
					GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_TEACHER_NAME] << teachers[t];
				}
			}
		}
		//check is subject is in memory
		tmpList.clear();
		for (int i = 0; i < gt.rules.subjectsList.size(); i++)
		{
			Subject s = gt.rules.subjectsList[i];
			tmpList << s.name;
		}
		for (int sn = 0; sn < GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SUBJECT_NAME].size(); sn++)
		{
			bool add = true;
			if (tmpList.contains(GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SUBJECT_NAME][sn]) || GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SUBJECT_NAME][sn] == "")
				add = false;
			if (add)
			{
				GlobalMembersImport.dataWarning << Import.tr("%1 %2 will be added.", "For instance 'Subject Math will be added', so use singular").arg(GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_SUBJECT_NAME]).arg(GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SUBJECT_NAME][sn]);
				tmpList << GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SUBJECT_NAME][sn];
			}
		}
		//check is activity tag is in memory
		Debug.Assert(GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_ACTIVITY_TAG_NAME].isEmpty());
		QStringList activityTags = new QStringList();
		tmpList.clear();
		for (int i = 0; i < gt.rules.activityTagsList.size(); i++)
		{
			ActivityTag at = gt.rules.activityTagsList[i];
			tmpList << at.name;
		}
		for (int i = 0; i < GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_ACTIVITY_TAGS_SET].size(); i++)
		{
			line.clear();
			line = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_ACTIVITY_TAGS_SET][i];
			activityTags.clear();
			activityTags = line.split("+");
			for (int at = 0; at < activityTags.size(); at++)
			{
				bool add = true;
				if (tmpList.contains(activityTags[at]) || activityTags[at] == "")
					add = false;
				if (add)
				{
					GlobalMembersImport.dataWarning << Import.tr("%1 %2 will be added.", "For instance 'Subject Math will be added', so use singular").arg(GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_ACTIVITY_TAG_NAME]).arg(activityTags[at]);
					tmpList << activityTags[at];
					GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_ACTIVITY_TAG_NAME] << activityTags[at];
				}
			}
		}
		tmpList.clear();
		//check if already in memory (end)

		QDialog newParent2;
		ok = showFieldsAndWarnings(newParent, ref newParent2);
		//DON'T ADD THIS! newParent2->deleteLater();
		newParent = newParent2;
		if (ok == 0)
			return;

		//add teachers
		//maybe TODO write a function, so also import teacher csv can share this code
		int count = 0;
		for (int i = 0; i < GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_TEACHER_NAME].size(); i++)
		{
			if (!GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_TEACHER_NAME][i].isEmpty())
			{
				Teacher tch = new Teacher();
				tch.name = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_TEACHER_NAME][i];
				if (!gt.rules.addTeacher(tch))
				{
					if (tch != null)
						tch.Dispose();
				}
				else
					count++;
			}
		}
		GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_TEACHER_NAME].clear();
		if (count > 0)
			GlobalMembersImport.lastWarning += Import.tr("%1 teachers added. Please check teachers form.").arg(count) + "\n";
		//add subjects
		//maybe TODO write a function, so also import subjects csv can share this code
		count = 0;
		for (int i = 0; i < GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SUBJECT_NAME].size(); i++)
		{
			if (!GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SUBJECT_NAME][i].isEmpty())
			{
				Subject s = new Subject();
				s.name = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SUBJECT_NAME][i];
				if (!gt.rules.addSubject(s))
				{
					if (s != null)
						s.Dispose();
				}
				else
					count++;
			}
		}
		if (count > 0)
			GlobalMembersImport.lastWarning += Import.tr("%1 subjects added. Please check subjects form.").arg(count) + "\n";
		//add activity tags
		//maybe TODO write a function, so also import activity tags csv can share this code
		count = 0;
		for (int i = 0; i < GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_ACTIVITY_TAG_NAME].size(); i++)
		{
			if (!GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_ACTIVITY_TAG_NAME][i].isEmpty())
			{
				ActivityTag a = new ActivityTag();
				a.name = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_ACTIVITY_TAG_NAME][i];
				if (!gt.rules.addActivityTag(a))
				{
					if (a != null)
						a.Dispose();
				}
				else
					count++;
			}
		}
		if (count > 0)
			GlobalMembersImport.lastWarning += Import.tr("%1 activity tags added. Please check activity tags form.").arg(count) + "\n";

		//add activities (start) - similar to Livius code modified by Volker
		count = 0;
		int count2 = 0;
		int activityid = 0; //We set the id of this newly added activity = (the largest existing id + 1)
		for (int i = 0; i < gt.rules.activitiesList.size(); i++) //TODO: do it the same in addactivityfor.cpp (calculate activityid just one time)
		{
			Activity act = gt.rules.activitiesList[i];
			if (act.id > activityid)
				activityid = act.id;
		}
		activityid++;
		QProgressDialog _progress4 = new QProgressDialog(newParent);
		QProgressDialog progress4 = (_progress4);
		progress4.setWindowTitle(tr("Importing", "Title of a progress dialog"));
		progress4.setLabelText(tr("Importing activities"));
		progress4.setModal(true);
		progress4.setRange(0, GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SUBJECT_NAME].size());

		bool incorrect_bool_consecutive = false;

		for (int i = 0; i < GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SUBJECT_NAME].size(); i++)
		{
			progress4.setValue(i);
			if (progress4.wasCanceled())
			{
				QMessageBox.warning(newParent, "FET", Import.tr("Importing data canceled by user."));
				//return false;
				ok = false;
				goto ifUserCanceledProgress4;
			}
			bool ok2;
			QString tmpStr = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_MIN_DAYS_WEIGHT][i];
	//		double weight=tmpStr.toDouble(&ok2);
			double weight = GlobalMembersTimetable_defs.customFETStrToDouble(tmpStr, ok2);
			Debug.Assert(ok2);

			QStringList teachers_names = new QStringList();
			if (!GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_TEACHERS_SET][i].isEmpty())
				teachers_names = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_TEACHERS_SET][i].split("+");

			QString subject_name = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SUBJECT_NAME][i];

			QStringList activity_tags_names = new QStringList();
			if (!GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_ACTIVITY_TAGS_SET][i].isEmpty())
				activity_tags_names = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_ACTIVITY_TAGS_SET][i].split("+");

			QStringList students_names = new QStringList();
			if (!GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_STUDENTS_SET][i].isEmpty())
				students_names = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_STUDENTS_SET][i].split("+");
			QStringList splitDurationList = new QStringList();
			splitDurationList.clear();
			Debug.Assert(!GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SPLIT_DURATION][i].isEmpty());
			splitDurationList = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SPLIT_DURATION][i].split("+");
			int nsplit = splitDurationList.size();
			if (nsplit == 1)
			{
				int duration = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_TOTAL_DURATION][i].toInt(ok2, 10);
				Debug.Assert(ok2);
				bool active = true;
				//workaround only. Please rethink. (start)
				/*QStringList activity_tag_names;
				activity_tag_names<<activity_tag_name;*/
				//workaround only. Please rethink. (end)
				Activity a = new Activity(gt.rules, activityid, 0, teachers_names, subject_name, activity_tags_names, students_names, duration, duration, active, true, -1);

				bool already_existing = false;
				for (int i = 0; i < gt.rules.activitiesList.size(); i++)
				{
					Activity act = gt.rules.activitiesList[i];
					if ((act) == a)
						already_existing = true;
				}
				if (already_existing)
				{
					GlobalMembersImport.lastWarning += Import.tr("Activity %1 already exists. A duplicate activity is imported. Please check the dataset!").arg(activityid) + "\n";
				}
				bool tmp = gt.rules.addSimpleActivity(newParent, activityid, 0, teachers_names, subject_name, activity_tags_names, students_names, duration, duration, active, true, -1);
				activityid++;
				if (tmp)
				{
					count++;
					count2++;
				}
				else
					QMessageBox.critical(newParent, tr("FET information"), tr("Activity NOT added - please report error"));
			}
			else //split activity
			{
				int totalduration;
				int[] durations = new int[GlobalMembersTimetable_defs.MAX_SPLIT_OF_AN_ACTIVITY];
				bool[] active = new bool[GlobalMembersTimetable_defs.MAX_SPLIT_OF_AN_ACTIVITY];

				totalduration = 0;
				for (int s = 0; s < nsplit; s++)
				{
					durations[s] = splitDurationList[s].toInt(ok2);
					Debug.Assert(ok2);
					active[s] = true;
					totalduration += durations[s];
				}
				Debug.Assert(totalduration == GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_TOTAL_DURATION][i].toInt(ok2));
				Debug.Assert(ok2);

				int minD = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_MIN_DAYS][i].toInt(ok2);
				Debug.Assert(ok2);
				bool force;

				if (GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_MIN_DAYS_CONSECUTIVE][i].toUpper() == "YES" || GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_MIN_DAYS_CONSECUTIVE][i].toUpper() == "Y" || GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_MIN_DAYS_CONSECUTIVE][i].toUpper() == "TRUE" || GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_MIN_DAYS_CONSECUTIVE][i].toUpper() == "T" || GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_MIN_DAYS_CONSECUTIVE][i].toUpper() == "1")
					force = true;
				else if (GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_MIN_DAYS_CONSECUTIVE][i].toUpper() == "NO" || GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_MIN_DAYS_CONSECUTIVE][i].toUpper() == "N" || GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_MIN_DAYS_CONSECUTIVE][i].toUpper() == "FALSE" || GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_MIN_DAYS_CONSECUTIVE][i].toUpper() == "F" || GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_MIN_DAYS_CONSECUTIVE][i].toUpper() == "0")
					force = false;
				else
				{
					incorrect_bool_consecutive = true;
					force = true;
				}
				//workaround only. Please rethink. (start)
				/*QStringList activity_tag_names;
				activity_tag_names<<activity_tag_name;*/
				//workaround only. Please rethink. (end)
				bool tmp = gt.rules.addSplitActivity(newParent, activityid, activityid, teachers_names, subject_name, activity_tags_names, students_names, nsplit, totalduration, durations, active, minD, weight, force, true, -1);
				activityid += nsplit;
				if (tmp)
				{
					count++;
					count2 += nsplit;
				}
				else
					QMessageBox.critical(newParent, tr("FET information"), tr("Split activity NOT added - error???"));
			}
		}
		progress4.setValue(GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SUBJECT_NAME].size());
		//add activities (end) - similar to Livius code modified by Volker
	ifUserCanceledProgress4:

		if (incorrect_bool_consecutive)
		{
			GlobalMembersImport.lastWarning.insert(0, tr("Warning: found tags for the 'consecutive' field of min days which are not a valid boolean value (%1) - making them %2").arg("1, 0, yes, no, y, n, true, false, t, f").arg("true") + "\n");
		}

		if (!GlobalMembersImport.lastWarning.isEmpty())
			GlobalMembersImport.lastWarning.insert(0,Import.tr("Notes:") + "\n");
		if (count > 0)
			GlobalMembersImport.lastWarning.insert(0,Import.tr("%1 container activities (%2 total activities) added. Please check activity form.").arg(count).arg(count2) + "\n");

		QDialog newParent3 = new LastWarningsDialog(newParent);
		//DON'T ADD THIS! newParent3->deleteLater();
		newParent = newParent3;
		LastWarningsDialog lwd = ((LastWarningsDialog)newParent);
		int w = chooseWidth(lwd.sizeHint().width());
		int h = chooseHeight(lwd.sizeHint().height());
		lwd.resize(w,h);
		centerWidgetOnScreen(lwd);

		ok = lwd.exec();

		int tmp = GlobalMembersImport.fileName.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP);
		IMPORT_DIRECTORY = GlobalMembersImport.fileName.left(tmp);
		gt.rules.internalStructureComputed = false;
	}
	public static void importCSVActivityTags(QWidget parent)
	{
		prearrangement();
		GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_ACTIVITY_TAG_NAME] = GlobalMembersImport.IMPORT_DEFAULT_ITEM;
		int ok;

		QDialog newParent;
		ok = getFileSeparatorFieldsAndHead(parent, ref newParent);
		//DON'T ADD THIS! newParent->deleteLater();
		if (ok == 0)
			return;

		if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_ACTIVITY_TAG_NAME] == GlobalMembersImport.IMPORT_DEFAULT_ITEM)
		{
			QDialog newParent2 = new ChooseFieldsDialog(newParent);
			QString settingsName = new QString("ImportActivityTagsChooseFieldsDialog");
			//DON'T ADD THIS! newParent2->deleteLater();
			newParent = newParent2;
			ChooseFieldsDialog cfd = ((ChooseFieldsDialog)newParent);
			int w = chooseWidth(cfd.sizeHint().width());
			int h = chooseHeight(cfd.sizeHint().height());
			cfd.resize(w,h);
			centerWidgetOnScreen(cfd);
			restoreFETDialogGeometry(cfd, settingsName);

			ok = cfd.exec();
			saveFETDialogGeometry(cfd, settingsName);
			if (ok == 0)
				return;
		}

		ok = readFields(newParent);
		if (ok == 0)
			return;

		//check empty fields (start)
		for (int i = 0; i < GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_ACTIVITY_TAG_NAME].size(); i++)
		{
			if (GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_ACTIVITY_TAG_NAME][i].isEmpty())
				GlobalMembersImport.warnText += Import.tr("Skipped line %1: Field '%2' is empty.").arg(GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_LINE_NUMBER][i]).arg(GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_ACTIVITY_TAG_NAME]) + "\n";
		}
		//check empty fields (end)

		//check if already in memory (start)
		for (int i = 0; i < gt.rules.activityTagsList.size(); i++)
		{
			ActivityTag a = gt.rules.activityTagsList[i];
			if (GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_ACTIVITY_TAG_NAME].contains(a.name))
				GlobalMembersImport.dataWarning << Import.tr("%1 is already in FET data.").arg(a.name);
		}
		//check if already in memory (end)
		QDialog newParent2;
		ok = showFieldsAndWarnings(newParent, ref newParent2);
		//DON'T ADD THIS! newParent2->deleteLater();
		newParent = newParent2;
		if (ok == 0)
			return;

		//add subjects (start) - similar to teachersform.cpp by Liviu modified by Volker
		int count = 0;
		for (int i = 0; i < GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_ACTIVITY_TAG_NAME].size(); i++)
		{
			if (!GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_ACTIVITY_TAG_NAME][i].isEmpty())
			{
				ActivityTag a = new ActivityTag();
				a.name = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_ACTIVITY_TAG_NAME][i];
				if (!gt.rules.addActivityTag(a))
				{
					if (a != null)
						a.Dispose();
				}
				else
					count++;
			}
		}
		QMessageBox.information(newParent, tr("FET information"), Import.tr("%1 activity tags added. Please check activity tag form.").arg(count));
		//add subjects (end) - similar to teachersform.cpp by Liviu modified by Volker
		int tmp = GlobalMembersImport.fileName.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP);
		IMPORT_DIRECTORY = GlobalMembersImport.fileName.left(tmp);
		gt.rules.internalStructureComputed = false;
	}
	public static void importCSVRoomsAndBuildings(QWidget parent)
	{
		prearrangement();
		GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_ROOM_NAME] = GlobalMembersImport.IMPORT_DEFAULT_ITEM;
		GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_ROOM_CAPACITY] = GlobalMembersImport.IMPORT_DEFAULT_ITEM;
		GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_BUILDING_NAME] = GlobalMembersImport.IMPORT_DEFAULT_ITEM;
		int ok;

		QDialog newParent;
		ok = getFileSeparatorFieldsAndHead(parent, ref newParent);
		//DON'T ADD THIS! newParent->deleteLater();
		if (ok == 0)
			return;

		if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_ROOM_NAME] == GlobalMembersImport.IMPORT_DEFAULT_ITEM)
		{
			QDialog newParent2 = new ChooseFieldsDialog(newParent);
			QString settingsName = new QString("ImportRoomsBuildingsChooseFieldsDialog");
			//DON'T ADD THIS! newParent2->deleteLater();
			newParent = newParent2;
			ChooseFieldsDialog cfd = ((ChooseFieldsDialog)newParent);
			int w = chooseWidth(cfd.sizeHint().width());
			int h = chooseHeight(cfd.sizeHint().height());
			cfd.resize(w,h);
			centerWidgetOnScreen(cfd);
			restoreFETDialogGeometry(cfd, settingsName);

			ok = cfd.exec();
			saveFETDialogGeometry(cfd, settingsName);
		}

		if (ok == 0)
			return;

		ok = readFields(newParent);
		if (ok == 0)
			return;

		QStringList duplicatesCheck = new QStringList();
		//check duplicates of rooms in cvs
		if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_ROOM_NAME] != GlobalMembersImport.DO_NOT_IMPORT)
			for (int i = 0; i < GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_ROOM_NAME].size(); i++)
				if (duplicatesCheck.contains(GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_ROOM_NAME][i]))
					GlobalMembersImport.warnText += Import.tr("Skipped line %1: Field '%2' is already in a previous line.").arg(GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_LINE_NUMBER][i]).arg(GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_ROOM_NAME]) + "\n";
				else
					duplicatesCheck << GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_ROOM_NAME][i];
		duplicatesCheck.clear();
		//check duplicates of buildings in cvs. only if no room is imported.
		if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_ROOM_NAME] == GlobalMembersImport.DO_NOT_IMPORT GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_BUILDING_NAME] != GlobalMembersImport.DO_NOT_IMPORT)
			for (int i = 0; i < GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_BUILDING_NAME].size(); i++)
				if (duplicatesCheck.contains(GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_BUILDING_NAME][i]))
					GlobalMembersImport.warnText += Import.tr("Skipped line %1: Field '%2' is already in a previous line.").arg(GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_LINE_NUMBER][i]).arg(GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_BUILDING_NAME]) + "\n";
				else
					duplicatesCheck << GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_BUILDING_NAME][i];
		duplicatesCheck.clear();
		//check empty rooms (start)
		if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_ROOM_NAME != GlobalMembersImport.DO_NOT_IMPORT] != 0)
			for (int i = 0; i < GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_ROOM_NAME].size(); i++)
				if (GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_ROOM_NAME][i].isEmpty())
					GlobalMembersImport.warnText += Import.tr("Skipped line %1: Field '%2' is empty.").arg(GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_LINE_NUMBER][i]).arg(GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_ROOM_NAME]) + "\n";
		//check empty rooms (end)
		//check empty buildings (start)
		if ((GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_ROOM_NAME] == GlobalMembersImport.DO_NOT_IMPORT || GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_ROOM_NAME] == GlobalMembersImport.IMPORT_DEFAULT_ITEM) GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_BUILDING_NAME != GlobalMembersImport.DO_NOT_IMPORT])
			for (int i = 0; i < GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_BUILDING_NAME].size(); i++)
				if (GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_BUILDING_NAME][i].isEmpty())
					GlobalMembersImport.warnText += Import.tr("Skipped line %1: Field '%2' is empty.").arg(GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_LINE_NUMBER][i]).arg(GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_BUILDING_NAME]) + "\n";
		//check empty buildings (end)

		//check if rooms are already in memory (start)
		QStringList dataWarning = new QStringList();
		for (int i = 0; i < gt.rules.roomsList.size(); i++)
		{
			Room r = gt.rules.roomsList[i];
			if (GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_ROOM_NAME].contains(r.name))
				dataWarning << Import.tr("%1 is already in FET data.").arg(r.name);
		}
		//check if rooms are already in memory (end)

		//check if buildings are already in memory (start)
		if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_ROOM_NAME] < 0)
		{
			for (int i = 0; i < gt.rules.buildingsList.size(); i++)
			{
				Building b = gt.rules.buildingsList[i];
				if (GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_BUILDING_NAME].contains(b.name))
					dataWarning << Import.tr("%1 is already in FET data.").arg(b.name);
			}
		}
		//check if buildings are already in memory (end)

		QDialog newParent2;
		ok = showFieldsAndWarnings(newParent, ref newParent2);
		//DON'T ADD THIS! newParent2->deleteLater();
		newParent = newParent2;
		if (ok == 0)
			return;

		//add buildings (start) - similar to teachersform.cpp by Liviu modified by Volker
		int count = 0;
		for (int i = 0; i < GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_BUILDING_NAME].size(); i++)
		{
			if (!GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_BUILDING_NAME][i].isEmpty())
			{
				Building b = new Building();
				b.name = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_BUILDING_NAME][i];
				if (!gt.rules.addBuilding(b))
				{
					if (b != null)
						b.Dispose();
				}
				else
					count++;
			}
		}
		//add buildings (end) - similar to teachersform.cpp by Liviu modified by Volker

		//add rooms (start) - similar to teachersform.cpp by Liviu modified by Volker
		int countroom = 0;
		for (int i = 0; i < GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_BUILDING_NAME].size(); i++)
		{
			if (!GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_ROOM_NAME][i].isEmpty())
			{
				Room r = new Room();
				r.name = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_ROOM_NAME][i];
				if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_BUILDING_NAME] != GlobalMembersImport.DO_NOT_IMPORT)
					r.building = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_BUILDING_NAME][i];
				else
					r.building = "";
				if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_ROOM_CAPACITY] != GlobalMembersImport.DO_NOT_IMPORT)
				{
					QString tmpInt = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_ROOM_CAPACITY][i];
					r.capacity = tmpInt.toInt();
				}
				else
					Debug.Assert(0 == 1);
				if (!gt.rules.addRoom(r))
				{
					if (r != null)
						r.Dispose();
				}
				else
					countroom++;
			}
		}
		//add rooms (end) - similar to teachersform.cpp by Liviu modified by Volker
		QMessageBox.information(newParent, tr("FET information"), Import.tr("%1 buildings added. Please check rooms form.").arg(count) + "\n" + tr("%2 rooms added. Please check rooms form.").arg(countroom));

		int tmp = GlobalMembersImport.fileName.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP);
		IMPORT_DIRECTORY = GlobalMembersImport.fileName.left(tmp);
		gt.rules.internalStructureComputed = false;
	}
	public static void importCSVSubjects(QWidget parent)
	{
		prearrangement();
		GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_SUBJECT_NAME] = GlobalMembersImport.IMPORT_DEFAULT_ITEM;
		int ok;

		QDialog newParent;
		ok = getFileSeparatorFieldsAndHead(parent, ref newParent);
		//DON'T ADD THIS! newParent->deleteLater();
		if (ok == 0)
			return;

		if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_SUBJECT_NAME] == GlobalMembersImport.IMPORT_DEFAULT_ITEM)
		{
			QDialog newParent2 = new ChooseFieldsDialog(newParent);
			QString settingsName = new QString("ImportSubjectsChooseFieldsDialog");
			//DON'T ADD THIS! newParent2->deleteLater();
			newParent = newParent2;
			ChooseFieldsDialog cfd = ((ChooseFieldsDialog)newParent);
			int w = chooseWidth(cfd.sizeHint().width());
			int h = chooseHeight(cfd.sizeHint().height());
			cfd.resize(w,h);
			centerWidgetOnScreen(cfd);
			restoreFETDialogGeometry(cfd, settingsName);

			ok = cfd.exec();
			saveFETDialogGeometry(cfd, settingsName);
		}

		if (ok == 0)
			return;

		ok = readFields(newParent);
		if (ok == 0)
			return;

		//check empty fields (start)
		for (int i = 0; i < GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SUBJECT_NAME].size(); i++)
		{
			if (GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SUBJECT_NAME][i].isEmpty())
				GlobalMembersImport.warnText += Import.tr("Skipped line %1: Field '%2' is empty.").arg(GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_LINE_NUMBER][i]).arg(GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_SUBJECT_NAME]) + "\n";
		}
		//check empty fields (end)

		//check if already in memory (start)
		for (int i = 0; i < gt.rules.subjectsList.size(); i++)
		{
			Subject s = gt.rules.subjectsList[i];
			if (GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SUBJECT_NAME].contains(s.name))
				GlobalMembersImport.dataWarning << Import.tr("%1 is already in FET data.").arg(s.name);
		}
		//check if already in memory (end)

		QDialog newParent2;
		ok = showFieldsAndWarnings(newParent, ref newParent2);
		//DON'T ADD THIS! newParent2->deleteLater();
		newParent = newParent2;
		if (ok == 0)
			return;

		//add subjects (start) - similar to teachersform.cpp by Liviu modified by Volker
		int count = 0;
		for (int i = 0; i < GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SUBJECT_NAME].size(); i++)
		{
			if (!GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SUBJECT_NAME][i].isEmpty())
			{
				Subject s = new Subject();
				s.name = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SUBJECT_NAME][i];
				if (!gt.rules.addSubject(s))
				{
					if (s != null)
						s.Dispose();
				}
				else
					count++;
			}
		}
		//add subjects (end) - similar to teachersform.cpp by Liviu modified by Volker
		QMessageBox.information(newParent, tr("FET information"), Import.tr("%1 subjects added. Please check subjects form.").arg(count));
		int tmp = GlobalMembersImport.fileName.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP);
		IMPORT_DIRECTORY = GlobalMembersImport.fileName.left(tmp);
		gt.rules.internalStructureComputed = false;
	}
	public static void importCSVTeachers(QWidget parent)
	{
		prearrangement();
		GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_TEACHER_NAME] = GlobalMembersImport.IMPORT_DEFAULT_ITEM;
		int ok;

		QDialog newParent;
		ok = getFileSeparatorFieldsAndHead(parent, ref newParent);
		//DON'T ADD THIS! newParent->deleteLater();
		if (ok == 0)
			return;

		if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_TEACHER_NAME] == GlobalMembersImport.IMPORT_DEFAULT_ITEM)
		{
			QDialog newParent2 = new ChooseFieldsDialog(newParent);
			QString settingsName = new QString("ImportTeachersChooseFieldsDialog");
			//DON'T ADD THIS! newParent2->deleteLater();
			newParent = newParent2;
			ChooseFieldsDialog cfd = ((ChooseFieldsDialog)newParent);
			int w = chooseWidth(cfd.sizeHint().width());
			int h = chooseHeight(cfd.sizeHint().height());
			cfd.resize(w,h);
			centerWidgetOnScreen(cfd);
			restoreFETDialogGeometry(cfd, settingsName);

			ok = cfd.exec();
			saveFETDialogGeometry(cfd, settingsName);
		}

		if (ok == 0)
			return;

		ok = readFields(newParent);
		if (ok == 0)
			return;

		//check empty fields (start)
		for (int i = 0; i < GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_TEACHER_NAME].size(); i++)
		{
			if (GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_TEACHER_NAME][i].isEmpty())
				GlobalMembersImport.warnText += Import.tr("Skipped line %1: Field '%2' is empty.").arg(GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_LINE_NUMBER][i]).arg(GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_TEACHER_NAME]) + "\n";
		}
		//check empty fields (end)

		//check if already in memory (start)
		for (int i = 0; i < gt.rules.teachersList.size(); i++)
		{
			Teacher t = gt.rules.teachersList[i];
			if (GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_TEACHER_NAME].contains(t.name))
				GlobalMembersImport.dataWarning << Import.tr("%1 is already in FET data.").arg(t.name);
		}
		//check if already in memory (end)

		QDialog newParent2;
		ok = showFieldsAndWarnings(newParent, ref newParent2);
		//DON'T ADD THIS! newParent2->deleteLater();
		newParent = newParent2;
		if (ok == 0)
			return;

		//add teachers (start) - similar to teachersform.cpp by Liviu modified by Volker
		int count = 0;
		for (int i = 0; i < GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_TEACHER_NAME].size(); i++)
		{
			if (!GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_TEACHER_NAME][i].isEmpty())
			{
				Teacher tch = new Teacher();
				tch.name = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_TEACHER_NAME][i];
				if (!gt.rules.addTeacher(tch))
				{
					if (tch != null)
						tch.Dispose();
				}
				else
					count++;
			}
		}
		QMessageBox.information(newParent, tr("FET information"), Import.tr("%1 teachers added. Please check teachers form.").arg(count));
		//add teachers (end) - similar to teachersform.cpp by Liviu modified by Volker
		int tmp = GlobalMembersImport.fileName.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP);
		IMPORT_DIRECTORY = GlobalMembersImport.fileName.left(tmp);
		gt.rules.internalStructureComputed = false;
	}
	public static void importCSVStudents(QWidget parent)
	{
		prearrangement();
		GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_YEAR_NAME] = GlobalMembersImport.IMPORT_DEFAULT_ITEM;
		GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_YEAR_NUMBER_OF_STUDENTS] = GlobalMembersImport.IMPORT_DEFAULT_ITEM;
		GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_GROUP_NAME] = GlobalMembersImport.IMPORT_DEFAULT_ITEM;
		GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_GROUP_NUMBER_OF_STUDENTS] = GlobalMembersImport.IMPORT_DEFAULT_ITEM;
		GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_SUBGROUP_NAME] = GlobalMembersImport.IMPORT_DEFAULT_ITEM;
		GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_SUBGROUP_NUMBER_OF_STUDENTS] = GlobalMembersImport.IMPORT_DEFAULT_ITEM;
		int ok;

		QDialog newParent;
		ok = getFileSeparatorFieldsAndHead(parent, ref newParent);
		//DON'T ADD THIS! newParent->deleteLater();
		if (ok == 0)
			return;

		if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_YEAR_NAME] == GlobalMembersImport.IMPORT_DEFAULT_ITEM)
		{
			QDialog newParent2 = new ChooseFieldsDialog(newParent);
			QString settingsName = new QString("ImportYearsGroupsSubgroupsChooseFieldsDialog");
			//DON'T ADD THIS! newParent2->deleteLater();
			newParent = newParent2;
			ChooseFieldsDialog cfd = ((ChooseFieldsDialog)newParent);
			int w = chooseWidth(cfd.sizeHint().width());
			int h = chooseHeight(cfd.sizeHint().height());
			cfd.resize(w,h);

			centerWidgetOnScreen(cfd);
			restoreFETDialogGeometry(cfd, settingsName);

			ok = cfd.exec();
			saveFETDialogGeometry(cfd, settingsName);
			if (ok == 0)
				return;
		}

		ok = readFields(newParent);
		if (ok == 0)
			return;

		//check if already in memory (start) - similar to adding items by Liviu modified by Volker
		QString yearName = new QString();
		QString groupName = new QString();
		QString subgroupName = new QString();
		QSet<QString> usedCSVYearNames = new QSet<QString>(); // this is much fater then QStringList
		QSet<QString> usedCSVGroupNames = new QSet<QString>();
		QSet<QString> usedCSVSubgroupNames = new QSet<QString>();

		//check csv
		QProgressDialog _progress = new QProgressDialog(newParent);
		QProgressDialog progress = (_progress);
		progress.setWindowTitle(tr("Importing", "Title of a progress dialog"));
		//cout<<"progress in importCSVStudents starts, range="<<fieldList[FIELD_YEAR_NAME].size()<<endl;
		progress.setLabelText(tr("Checking CSV"));
		progress.setModal(true);
		progress.setRange(0, GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_YEAR_NAME].size());
		for (int i = 0; i < GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_YEAR_NAME].size(); i++)
		{
			progress.setValue(i);
			if (progress.wasCanceled())
			{
				QMessageBox.warning(newParent, "FET", Import.tr("Checking CSV canceled by user."));
				return;
			}
			if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_YEAR_NAME] >= 0)
				yearName = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_YEAR_NAME][i];
			else
				yearName = GlobalMembersImport.fieldDefaultItem[GlobalMembersImport.FIELD_YEAR_NAME];
			if ((GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_GROUP_NAME]) >= 0)
				groupName = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_GROUP_NAME][i];
			else
				groupName = GlobalMembersImport.fieldDefaultItem[GlobalMembersImport.FIELD_GROUP_NAME];
			if ((GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_SUBGROUP_NAME]) >= 0)
				subgroupName = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SUBGROUP_NAME][i];
			else
				subgroupName = GlobalMembersImport.fieldDefaultItem[GlobalMembersImport.FIELD_SUBGROUP_NAME];
			if ((GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_YEAR_NAME]) >= GlobalMembersImport.IMPORT_DEFAULT_ITEM)
			{
				if (!yearName.isEmpty())
					if (!usedCSVYearNames.contains(yearName))
						usedCSVYearNames << yearName;
			}
			if ((GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_GROUP_NAME]) >= GlobalMembersImport.IMPORT_DEFAULT_ITEM)
			{
				if (!groupName.isEmpty())
					if (!usedCSVGroupNames.contains(groupName))
						usedCSVGroupNames << groupName;
				if (usedCSVYearNames.contains(groupName))
					GlobalMembersImport.warnText += Import.tr("Problem in line %1: Group name %2 is taken for a year - please consider another name").arg(GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_LINE_NUMBER][i]).arg(groupName) + "\n";
				if (usedCSVGroupNames.contains(yearName))
					GlobalMembersImport.warnText += Import.tr("Problem in line %1: Year name %2 is taken for a group - please consider another name").arg(GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_LINE_NUMBER][i]).arg(yearName) + "\n";

			}
			if ((GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_SUBGROUP_NAME]) >= GlobalMembersImport.IMPORT_DEFAULT_ITEM)
			{
				if (!subgroupName.isEmpty())
					if (!usedCSVSubgroupNames.contains(subgroupName))
						usedCSVSubgroupNames << subgroupName;
				if (usedCSVYearNames.contains(subgroupName))
					GlobalMembersImport.warnText += Import.tr("Problem in line %1: Subgroup name %2 is taken for a year - please consider another name").arg(GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_LINE_NUMBER][i]).arg(subgroupName) + "\n";
				if (usedCSVGroupNames.contains(subgroupName))
					GlobalMembersImport.warnText += Import.tr("Problem in line %1: Subgroup name %2 is taken for a group - please consider another name").arg(GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_LINE_NUMBER][i]).arg(subgroupName) + "\n";
				if (usedCSVSubgroupNames.contains(groupName))
					GlobalMembersImport.warnText += Import.tr("Problem in line %1: Group name %2 is taken for a subgroup - please consider another name").arg(GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_LINE_NUMBER][i]).arg(groupName) + "\n";
				if (usedCSVSubgroupNames.contains(yearName))
					GlobalMembersImport.warnText += Import.tr("Problem in line %1: Year name %2 is taken for a subgroup - please consider another name").arg(GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_LINE_NUMBER][i]).arg(yearName) + "\n";
			}
		}
		progress.setValue(GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_YEAR_NAME].size());
		//cout<<"progress in importCSVStudents ends"<<endl;

		//check current data
		QProgressDialog _progress2 = new QProgressDialog(newParent);
		QProgressDialog progress2 = (_progress2);
		progress2.setWindowTitle(tr("Importing", "Title of a progress dialog"));
		progress2.setLabelText(tr("Checking data"));
		progress2.setModal(true);
		progress2.setRange(0, GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_YEAR_NAME].size());
		//cout<<"progress2 in importCSVStudents starts, range="<<fieldList[FIELD_YEAR_NAME].size()<<endl;
		int kk = 0;
		for (int i = 0; i < gt.rules.yearsList.size(); i++)
		{
			progress2.setValue(kk);
			kk++;
			if (progress2.wasCanceled())
			{
				QMessageBox.warning(newParent, "FET", Import.tr("Checking data canceled by user."));
				return;
			}
			StudentsYear sty = gt.rules.yearsList[i];
			if (usedCSVYearNames.contains(sty.name))
				GlobalMembersImport.dataWarning << Import.tr("Year %1 is already in FET data.").arg(sty.name);
			if (usedCSVGroupNames.contains(sty.name))
				GlobalMembersImport.dataWarning << Import.tr("Can't import group %1. Name is already taken for a year.").arg(sty.name);
			if (usedCSVSubgroupNames.contains(sty.name))
				GlobalMembersImport.dataWarning << Import.tr("Can't import subgroup %1. Name is already taken for a year.").arg(sty.name);
			for (int j = 0; j < sty.groupsList.size(); j++)
			{
				progress2.setValue(kk);
				kk++;
				if (progress2.wasCanceled())
				{
					QMessageBox.warning(newParent, "FET", Import.tr("Checking data canceled by user."));
					return;
				}

				StudentsGroup stg = sty.groupsList[j];
				if (usedCSVYearNames.contains(stg.name))
					GlobalMembersImport.dataWarning << Import.tr("Can't import year %1. Name is already taken for a group.").arg(stg.name);
				if (usedCSVGroupNames.contains(stg.name))
					GlobalMembersImport.dataWarning << Import.tr("Group name %1 is already in FET data (In the same or in an other year).").arg(stg.name);
				if (usedCSVSubgroupNames.contains(stg.name))
					GlobalMembersImport.dataWarning << Import.tr("Can't import subgroup %1. Name is already taken for a group.").arg(stg.name);
				for (int k = 0; k < stg.subgroupsList.size(); k++)
				{
					progress2.setValue(kk);
					kk++;

					if (progress2.wasCanceled())
					{
						QMessageBox.warning(newParent, "FET", Import.tr("Checking data canceled by user."));
						return;
					}

					StudentsSubgroup sts = stg.subgroupsList[k];
					if (usedCSVYearNames.contains(sts.name))
						GlobalMembersImport.dataWarning << Import.tr("Can't import year %1. Name is already taken for a subgroup.").arg(sts.name);
					if (usedCSVGroupNames.contains(sts.name))
						GlobalMembersImport.dataWarning << Import.tr("Can't import group %1. Name is taken for a subgroup.").arg(sts.name);
					if (usedCSVSubgroupNames.contains(sts.name))
						GlobalMembersImport.dataWarning << Import.tr("Subgroup name %1 is already in FET data (In the same or in an other group).").arg(sts.name);
				}
			}
		}
		progress2.setValue(GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_YEAR_NAME].size());
		//cout<<"progress2 in importCSVStudents ends"<<endl;

		QDialog newParent2;
		ok = showFieldsAndWarnings(newParent, ref newParent2);
		//DON'T ADD THIS! newParent2->deleteLater();
		newParent = newParent2;
		if (ok == 0)
			return;

		//add students (start) - similar to adding items by Liviu modified by Volker
		GlobalMembersImport.lastWarning.clear();
		int addedYears = 0;
		int addedGroups = 0;
		int addedSubgroups = 0;
		QProgressDialog _progress3 = new QProgressDialog(newParent);
		QProgressDialog progress3 = (_progress3);
		progress3.setWindowTitle(tr("Importing", "Title of a progress dialog"));
		progress3.setLabelText(tr("Importing data"));
		progress3.setModal(true);
		progress3.setRange(0, GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_YEAR_NAME].size());
		//cout<<"progress3 in importCSVStudents starts, range="<<fieldList[FIELD_YEAR_NAME].size()<<endl;

		for (int i = 0; i < GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_YEAR_NAME].size(); i++)
		{
			progress3.setValue(i);
			if (progress3.wasCanceled())
			{
				QMessageBox.warning(newParent, "FET", Import.tr("Importing data canceled by user."));
				//return false;
				ok = false;
				goto ifUserCanceledProgress3;
			}
			ok = true;
			bool tryNext = false;
			if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_YEAR_NAME] != GlobalMembersImport.IMPORT_DEFAULT_ITEM)
				yearName = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_YEAR_NAME][i];
			else
				yearName = GlobalMembersImport.fieldDefaultItem[GlobalMembersImport.FIELD_YEAR_NAME];
			Debug.Assert(!yearName.isEmpty());
			StudentsSet ss = gt.rules.searchStudentsSet(yearName);
			if (ss != null)
			{
				if (ss.type == GlobalMembersStudentsset.STUDENTS_SUBGROUP)
					ok = false;
				else if (ss.type == GlobalMembersStudentsset.STUDENTS_GROUP)
					ok = false;
				else if (ss.type == GlobalMembersStudentsset.STUDENTS_YEAR)
				{
					ok = false;
					tryNext = true;
				}
			}
			if (ok != 0)
			{
				StudentsYear sy = new StudentsYear();
				sy.name = yearName;
				QString tmpString = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_YEAR_NUMBER_OF_STUDENTS][i];
				sy.numberOfStudents = tmpString.toInt();
				Debug.Assert(!GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_YEAR_NUMBER_OF_STUDENTS].isEmpty());
				if (gt.rules.searchYear(yearName) >= 0)
					if (sy != null)
						sy.Dispose();
				else
				{
					bool tmp = gt.rules.addYear(sy);
					Debug.Assert(tmp);
					addedYears++;
				}
			}
			if ((tryNext || ok != 0) && GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_GROUP_NAME] != GlobalMembersImport.DO_NOT_IMPORT)
			{
				ok = true;
				tryNext = false;
				StudentsGroup sg;
				sg = null;
				if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_GROUP_NAME] != GlobalMembersImport.IMPORT_DEFAULT_ITEM)
					groupName = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_GROUP_NAME][i];
				else
					groupName = GlobalMembersImport.fieldDefaultItem[GlobalMembersImport.FIELD_GROUP_NAME];
				if (groupName.isEmpty())
					ok = false;
				else
				{
					if (ok != 0 && gt.rules.searchGroup(yearName, groupName) >= 0)
					{
						ok = false;
						tryNext = true;
					}
					StudentsSet ss = gt.rules.searchStudentsSet(groupName);
					if (ss != null && ss.type == GlobalMembersStudentsset.STUDENTS_YEAR)
						ok = false;
					if (ss != null && ss.type == GlobalMembersStudentsset.STUDENTS_SUBGROUP)
						ok = false;
					if (ss != null && ss.type == GlobalMembersStudentsset.STUDENTS_GROUP)
					{
						if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_SUBGROUP_NAME] == GlobalMembersImport.DO_NOT_IMPORT)
							GlobalMembersImport.lastWarning += Import.tr("Group name %1 exists in another year. It means that some years share the same group.").arg(groupName) + "\n";
						if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_SUBGROUP_NAME] != GlobalMembersImport.DO_NOT_IMPORT)
							if (GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SUBGROUP_NAME].isEmpty())
								GlobalMembersImport.lastWarning += Import.tr("Group name %1 exists in another year. It means that some years share the same group.").arg(groupName) + "\n";
					}
					if (ss != null && ok != 0)
					{
						sg = (StudentsGroup)ss;
					}
					if (ss == null && ok != 0)
					{
						sg = new StudentsGroup();
						sg.name = groupName;
						QString tmpString = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_GROUP_NUMBER_OF_STUDENTS][i];
						sg.numberOfStudents = tmpString.toInt();
						Debug.Assert(ok);
						Debug.Assert(!GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_GROUP_NUMBER_OF_STUDENTS].isEmpty());
					}
					if (ok != 0)
					{
						gt.rules.addGroup(yearName, sg);
						addedGroups++;
					}
				}
			}
			if ((tryNext || ok != 0) && GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_SUBGROUP_NAME] != GlobalMembersImport.DO_NOT_IMPORT)
			{
				ok = true;
				if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_SUBGROUP_NAME] != GlobalMembersImport.IMPORT_DEFAULT_ITEM)
					subgroupName = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SUBGROUP_NAME][i];
				else
					subgroupName = GlobalMembersImport.fieldDefaultItem[GlobalMembersImport.FIELD_SUBGROUP_NAME];
				if (subgroupName.isEmpty())
					ok = false;
				else
				{
					if (ok != 0 && gt.rules.searchSubgroup(yearName, groupName, subgroupName) >= 0)
					{
						ok = false;
					}
					StudentsSet ss = gt.rules.searchStudentsSet(subgroupName);
					StudentsSubgroup sts;
					sts = null;
					if (ss != null && ss.type == GlobalMembersStudentsset.STUDENTS_YEAR)
					{
						ok = false;
					}
					if (ss != null && ss.type == GlobalMembersStudentsset.STUDENTS_GROUP)
					{
						ok = false;
					}
					if (ss != null && ss.type == GlobalMembersStudentsset.STUDENTS_SUBGROUP)
					{
						GlobalMembersImport.lastWarning += Import.tr("Subgroup name %1 exists in another group. It means that some groups share the same subgroup.").arg(subgroupName) + "\n";
					}
					if (ss != null && ok != 0)
					{
						sts = (StudentsSubgroup)ss;
					}
					if (ss == null && ok != 0)
					{
						sts = new StudentsSubgroup();
						sts.name = subgroupName;
						QString tmpString = GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SUBGROUP_NUMBER_OF_STUDENTS][i];
						sts.numberOfStudents = tmpString.toInt();
						Debug.Assert(ok);
						Debug.Assert(!GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_SUBGROUP_NUMBER_OF_STUDENTS].isEmpty());
					}
					if (ok != 0)
					{
						gt.rules.addSubgroup(yearName, groupName, sts);
						addedSubgroups++;
					}
				}
			}
		}
		progress3.setValue(GlobalMembersImport.fieldList[GlobalMembersImport.FIELD_YEAR_NAME].size());
		//cout<<"progress3 in importCSVStudents ends"<<endl;
		//add students (end) - similar to adding items by Liviu modified by Volker

	ifUserCanceledProgress3:

		if (!GlobalMembersImport.lastWarning.isEmpty())
			GlobalMembersImport.lastWarning.insert(0,"\n" + Import.tr("Notes:") + "\n");
		GlobalMembersImport.lastWarning.insert(0,Import.tr("%1 subgroups added. Please check subgroups form.").arg(addedSubgroups) + "\n");
		GlobalMembersImport.lastWarning.insert(0,Import.tr("%1 groups added. Please check groups form.").arg(addedGroups) + "\n");
		GlobalMembersImport.lastWarning.insert(0,Import.tr("%1 years added. Please check years form.").arg(addedYears) + "\n");

		LastWarningsDialog lwd = new LastWarningsDialog(newParent);
		int w = chooseWidth(lwd.sizeHint().width());
		int h = chooseHeight(lwd.sizeHint().height());
		lwd.resize(w,h);
		centerWidgetOnScreen(lwd);

		ok = lwd.exec();

		int tmp = GlobalMembersImport.fileName.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP);
		IMPORT_DIRECTORY = GlobalMembersImport.fileName.left(tmp);
		gt.rules.internalStructureComputed = false;
	}

	private static void prearrangement()
	{
		Debug.Assert(gt.rules.initialized);

		GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_LINE_NUMBER] = Import.tr("Line");
		GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_YEAR_NAME] = Import.tr("Year");
		GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_YEAR_NUMBER_OF_STUDENTS] = Import.tr("Number of Students per Year");
		GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_GROUP_NAME] = Import.tr("Group");
		GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_GROUP_NUMBER_OF_STUDENTS] = Import.tr("Number of Students per Group");
		GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_SUBGROUP_NAME] = Import.tr("Subgroup");
		GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_SUBGROUP_NUMBER_OF_STUDENTS] = Import.tr("Number of Students per Subgroup");
		GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_SUBJECT_NAME] = Import.tr("Subject");
		GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_ACTIVITY_TAG_NAME] = Import.tr("Activity Tag");
		GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_TEACHER_NAME] = Import.tr("Teacher");
		GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_BUILDING_NAME] = Import.tr("Building");
		GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_ROOM_NAME] = Import.tr("Room Name");
		GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_ROOM_CAPACITY] = Import.tr("Room Capacity");
		GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_STUDENTS_SET] = Import.tr("Students Sets");
		GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_TEACHERS_SET] = Import.tr("Teachers");
		GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_TOTAL_DURATION] = Import.tr("Total Duration");
		GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_SPLIT_DURATION] = Import.tr("Split Duration");
		GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_MIN_DAYS] = Import.tr("Min Days");
		GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_MIN_DAYS_WEIGHT] = Import.tr("Min Days Weight");
		GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_MIN_DAYS_CONSECUTIVE] = Import.tr("Min Days Consecutive");
		GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_ACTIVITY_TAGS_SET] = Import.tr("Activity Tags");
		for (int i = 0; i < GlobalMembersImport.NUMBER_OF_FIELDS; i++)
		{
			GlobalMembersImport.fieldNumber[i] = GlobalMembersImport.DO_NOT_IMPORT;
			GlobalMembersImport.fieldDefaultItem[i] = "";
			GlobalMembersImport.fieldList[i].clear();
		}
		GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_LINE_NUMBER] = GlobalMembersImport.IMPORT_DEFAULT_ITEM;
		GlobalMembersImport.fieldDefaultItem[GlobalMembersImport.FIELD_LINE_NUMBER] = Import.tr("line");
		GlobalMembersImport.dataWarning.clear();
		GlobalMembersImport.warnText.clear();
		GlobalMembersImport.lastWarning.clear();
	}

	// private funtions ---------------------------------------------------------------------------------------------------
	private static int getFileSeparatorFieldsAndHead(QWidget parent, ref QDialog newParent)
	{
		Debug.Assert(gt.rules.initialized);

		newParent = ((QDialog)parent);

		QString settingsName = new QString();

		if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_ACTIVITY_TAG_NAME] == GlobalMembersImport.IMPORT_DEFAULT_ITEM)
		{
			GlobalMembersImport.importThing = Import.tr("activity tags");
			settingsName = new QString("ImportActivityTagsSelectSeparatorsDialog");
		}
		if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_ROOM_NAME] == GlobalMembersImport.IMPORT_DEFAULT_ITEM)
		{
			GlobalMembersImport.importThing = Import.tr("buildings and rooms");
			settingsName = new QString("ImportBuildingsRoomsSelectSeparatorsDialog");
		}
		if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_TEACHER_NAME] == GlobalMembersImport.IMPORT_DEFAULT_ITEM)
		{
			GlobalMembersImport.importThing = Import.tr("teachers");
			settingsName = new QString("ImportTeachersSelectSeparatorsDialog");
		}
		if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_SUBJECT_NAME] == GlobalMembersImport.IMPORT_DEFAULT_ITEM)
		{
			GlobalMembersImport.importThing = Import.tr("subjects");
			settingsName = new QString("ImportSubjectsSelectSeparatorsDialog");
		}
		if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_YEAR_NAME] == GlobalMembersImport.IMPORT_DEFAULT_ITEM)
		{
			GlobalMembersImport.importThing = Import.tr("years, groups and subgroups");
			settingsName = new QString("ImportYearsGroupsSubgroupsSelectSeparatorsDialog");
		}
		if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_STUDENTS_SET] == GlobalMembersImport.IMPORT_DEFAULT_ITEM)
		{
			GlobalMembersImport.importThing = Import.tr("activities");
			settingsName = new QString("ImportActivitiesSelectSeparatorsDialog");
		}

		GlobalMembersImport.fileName = QFileDialog.getOpenFileName(parent, Import.tr("FET - Import %1 from CSV file").arg(GlobalMembersImport.importThing), IMPORT_DIRECTORY, Import.tr("Text Files") + " (*.csv *.dat *.txt)" + ";;" + Import.tr("All Files") + " (*)");

		QString NO_SEPARATOR_TRANSLATED = Import.tr("no separator");
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: fieldSeparator=NO_SEPARATOR_TRANSLATED;
		GlobalMembersImport.fieldSeparator.CopyFrom(NO_SEPARATOR_TRANSLATED); //needed, because a csv file contain maybe just one field!
		QString NO_TEXTQUOTE_TRANSLATED = Import.tr("no textquote");
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: textquote=NO_TEXTQUOTE_TRANSLATED;
		GlobalMembersImport.textquote.CopyFrom(NO_TEXTQUOTE_TRANSLATED);
		GlobalMembersImport.fields.clear();
		QFile file = new QFile(GlobalMembersImport.fileName);
		if (GlobalMembersImport.fileName.isEmpty())
		{
			return false;
		}
		if (!file.open(QIODevice.ReadOnly | QIODevice.Text))
		{
			return false;
		}
		QTextStream @in = new QTextStream(file);
		@in.setCodec("UTF-8");
		QString line = @in.readLine();
		file.close();

		if (line.size() <= 0)
		{
			QMessageBox.warning(parent, tr("FET warning"), tr("The first line of the file is empty. Please fix this."));
			return false;
		}

		if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_ACTIVITY_TAG_NAME] == GlobalMembersImport.IMPORT_DEFAULT_ITEM && line.contains("\"Activity Tag\"") && line.size() <= new QString("\"Activity Tag\"").length() + 1 && line.size() >= new QString("\"Activity Tag\"").length())
		{
			GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_ACTIVITY_TAG_NAME] = 0;
			GlobalMembersImport.head = true;
			GlobalMembersImport.fieldSeparator = ",";
			GlobalMembersImport.textquote = "\"";
			GlobalMembersImport.fields << line;
			return true;
		}

		if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_ROOM_NAME] == GlobalMembersImport.IMPORT_DEFAULT_ITEM && line.contains("\"Room\",\"Room Capacity\",\"Building\"") && line.size() <= new QString("\"Room\",\"Room Capacity\",\"Building\"").length() + 1 && line.size() >= new QString("\"Room\",\"Room Capacity\",\"Building\"").length())
		{
			GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_BUILDING_NAME] = 2;
			GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_ROOM_NAME] = 0;
			GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_ROOM_CAPACITY] = 1;
			GlobalMembersImport.head = true;
			GlobalMembersImport.fieldSeparator = ",";
			GlobalMembersImport.textquote = "\"";
			GlobalMembersImport.fields = line.split(GlobalMembersImport.fieldSeparator);
			return true;
		}

		if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_TEACHER_NAME] == GlobalMembersImport.IMPORT_DEFAULT_ITEM && line.contains("\"Teacher\"") && line.size() <= new QString("\"Teacher\"").length() + 1 && line.size() >= new QString("\"Teacher\"").length())
		{
			GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_TEACHER_NAME] = 0;
			GlobalMembersImport.head = true;
			GlobalMembersImport.fieldSeparator = ",";
			GlobalMembersImport.textquote = "\"";
			GlobalMembersImport.fields << line;
			return true;
		}

		if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_SUBJECT_NAME] == GlobalMembersImport.IMPORT_DEFAULT_ITEM && line.contains("\"Subject\"") && line.size() <= new QString("\"Subject\"").length() + 1 && line.size() >= new QString("\"Subject\"").length())
		{
			GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_SUBJECT_NAME] = 0;
			GlobalMembersImport.head = true;
			GlobalMembersImport.fieldSeparator = ",";
			GlobalMembersImport.textquote = "\"";
			GlobalMembersImport.fields << line;
			return true;
		}

		if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_YEAR_NAME] == GlobalMembersImport.IMPORT_DEFAULT_ITEM && line.contains("\"Year\",\"Number of Students per Year\",\"Group\",\"Number of Students per Group\",\"Subgroup\",\"Number of Students per Subgroup\"") && line.size() <= new QString("\"Year\",\"Number of Students per Year\",\"Group\",\"Number of Students per Group\",\"Subgroup\",\"Number of Students per Subgroup\"").length() + 1 && line.size() >= new QString("\"Year\",\"Number of Students per Year\",\"Group\",\"Number of Students per Group\",\"Subgroup\",\"Number of Students per Subgroup\"").length())
		{
			GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_YEAR_NAME] = 0;
			GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_YEAR_NUMBER_OF_STUDENTS] = 1;
			GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_GROUP_NAME] = 2;
			GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_GROUP_NUMBER_OF_STUDENTS] = 3;
			GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_SUBGROUP_NAME] = 4;
			GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_SUBGROUP_NUMBER_OF_STUDENTS] = 5;
			GlobalMembersImport.head = true;
			GlobalMembersImport.fieldSeparator = ",";
			GlobalMembersImport.textquote = "\"";
			GlobalMembersImport.fields = line.split(GlobalMembersImport.fieldSeparator);
			return true;
		}

		if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_STUDENTS_SET] == GlobalMembersImport.IMPORT_DEFAULT_ITEM && line.contains("\"Students Sets\",\"Subject\",\"Teachers\",\"Activity Tags\",\"Total Duration\",\"Split Duration\",\"Min Days\",\"Weight\",\"Consecutive\"") && line.size() <= new QString("\"Students Sets\",\"Subject\",\"Teachers\",\"Activity Tags\",\"Total Duration\",\"Split Duration\",\"Min Days\",\"Weight\",\"Consecutive\"").length() + 1 && line.size() >= new QString("\"Students Sets\",\"Subject\",\"Teachers\",\"Activity Tags\",\"Total Duration\",\"Split Duration\",\"Min Days\",\"Weight\",\"Consecutive\"").length())
		{
			GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_ACTIVITY_TAGS_SET] = 3;
			GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_SUBJECT_NAME] = 1;
			GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_STUDENTS_SET] = 0;
			GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_TEACHERS_SET] = 2;
			GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_TOTAL_DURATION] = 4;
			GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_SPLIT_DURATION] = 5;
			GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_MIN_DAYS] = 6;
			GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_MIN_DAYS_WEIGHT] = 7;
			GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_MIN_DAYS_CONSECUTIVE] = 8;
			GlobalMembersImport.head = true;
			GlobalMembersImport.fieldSeparator = ",";
			GlobalMembersImport.textquote = "\"";
			GlobalMembersImport.fields = line.split(GlobalMembersImport.fieldSeparator);
			return true;
		}

		QStringList separators = new QStringList();
		QStringList textquotes = new QStringList();
		separators << GlobalMembersImport.fieldSeparator;
		const int NO_SEPARATOR_POS = 0; //it is the first element. It may have length > 1 QChar
		textquotes << GlobalMembersImport.textquote;
		const int NO_TEXTQUOTE_POS = 0; //it is the first element. It may have length > 1 QChar
		for (int i = 0; i < line.size();i++)
		{
			//if(!(line.at(i)>='A'&&line.at(i)<='Z')&&!(line.at(i)>='a'&&line.at(i)<='z')&&!(line.at(i)>='0'&&line.at(i)<='9')&&!separators.contains(line.at(i))){
			if (!(line.at(i).isLetterOrNumber()) && !separators.contains(line.at(i)))
			{
				separators << line.at(i);
				//careful: if you intend to add strings longer than one QChar, take care of assert in line 647 (below in the same function) (fieldSeparator.size()==1)
			}
			if (!(line.at(i).isLetterOrNumber()) && !textquotes.contains(line.at(i)))
			{
				textquotes << line.at(i);
				//careful: if you intend to add strings longer than one QChar, take care of assert in line 659 (below in the same function) (textquote.size()==1)
			}
		}

		newParent = new QDialog(parent);
		QDialog separatorsDialog = (newParent);
		separatorsDialog.setWindowTitle(Import.tr("FET - Import %1 from CSV file").arg(GlobalMembersImport.importThing));
		QVBoxLayout separatorsMainLayout = new QVBoxLayout(separatorsDialog);

		QHBoxLayout top = new QHBoxLayout();
		QLabel topText = new QLabel();

		int tmpi = GlobalMembersImport.fileName.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP);
		tmpi = GlobalMembersImport.fileName.size() - tmpi - 1;
		QString shortFileName = GlobalMembersImport.fileName.right(tmpi);
		topText.setText(Import.tr("The first line of file\n%1\nis:").arg(shortFileName));
		top.addWidget(topText);
		top.addStretch();
		QPlainTextEdit textOfFirstLine = new QPlainTextEdit();
		textOfFirstLine.setReadOnly(true);
		textOfFirstLine.setPlainText(line);

		QGroupBox separatorsGroupBox = new QGroupBox(Import.tr("Please specify the used separator between fields:"));
		QComboBox separatorsCB = null;
		if (separators.size() > 1)
		{
			QHBoxLayout separatorBoxChoose = new QHBoxLayout();
			separatorsCB = new QComboBox();

			QLabel separatorTextChoose = new QLabel();
			separatorTextChoose.setText(Import.tr("Used field separator:"));
			separatorsCB.insertItems(0,separators);
			separatorBoxChoose.addWidget(separatorTextChoose);
			separatorBoxChoose.addWidget(separatorsCB);
			separatorsGroupBox.setLayout(separatorBoxChoose);
		}

		QGroupBox textquoteGroupBox = new QGroupBox(Import.tr("Please specify the used text quote of text fields:"));
		QComboBox textquoteCB = null;
		if (separators.size() > 1)
		{
			QHBoxLayout textquoteBoxChoose = new QHBoxLayout();
			textquoteCB = new QComboBox();

			QLabel textquoteTextChoose = new QLabel();
			textquoteTextChoose.setText(Import.tr("Used textquote:"));
			textquoteCB.insertItems(0,textquotes);
			textquoteBoxChoose.addWidget(textquoteTextChoose);
			textquoteBoxChoose.addWidget(textquoteCB);
			textquoteGroupBox.setLayout(textquoteBoxChoose);
		}

		QGroupBox firstLineGroupBox = new QGroupBox(Import.tr("Please specify the contents of the first line:"));
		QVBoxLayout firstLineChooseBox = new QVBoxLayout();
		QRadioButton firstLineRadio1 = new QRadioButton(Import.tr("The first line is the heading. Don't import that line."));
		QRadioButton firstLineRadio2 = new QRadioButton(Import.tr("The first line contains data. Import that line."));
		firstLineRadio1.setChecked(true);
		firstLineChooseBox.addWidget(firstLineRadio1);
		firstLineChooseBox.addWidget(firstLineRadio2);
		firstLineGroupBox.setLayout(firstLineChooseBox);

		QPushButton pb = new QPushButton(tr("OK"));
		QPushButton cancelpb = new QPushButton(tr("Cancel"));
		QHBoxLayout hl = new QHBoxLayout();
		hl.addStretch();
		hl.addWidget(pb);
		hl.addWidget(cancelpb);

		separatorsMainLayout.addLayout(top);
		separatorsMainLayout.addWidget(textOfFirstLine);
		if (separators.size() > 1)
		{
			separatorsMainLayout.addWidget(separatorsGroupBox);
			separatorsMainLayout.addWidget(textquoteGroupBox);
		}
		else
		{
			if (separatorsGroupBox != null)
				separatorsGroupBox.Dispose();
			if (textquoteGroupBox != null)
				textquoteGroupBox.Dispose();
		}
		separatorsMainLayout.addWidget(firstLineGroupBox);
		separatorsMainLayout.addLayout(hl);
		QObject.connect(pb, SIGNAL(clicked()), separatorsDialog, SLOT(accept()));
		QObject.connect(cancelpb, SIGNAL(clicked()), separatorsDialog, SLOT(reject()));

		pb.setDefault(true);
		pb.setFocus();

		int w = chooseWidth(separatorsDialog.sizeHint().width());
		int h = chooseHeight(separatorsDialog.sizeHint().height());
		separatorsDialog.resize(w,h);
		centerWidgetOnScreen(separatorsDialog);
		restoreFETDialogGeometry(separatorsDialog, settingsName);

		int ok = separatorsDialog.exec();
		saveFETDialogGeometry(separatorsDialog, settingsName);
		if (ok == 0)
			return false;

		if (separators.size() > 1)
		{
			Debug.Assert(separatorsCB != null);
			Debug.Assert(textquoteCB != null);
			GlobalMembersImport.fieldSeparator = separatorsCB.currentText();

			if (separatorsCB.currentIndex() == NO_SEPARATOR_POS)
			{
				Debug.Assert(GlobalMembersImport.fieldSeparator == NO_SEPARATOR_TRANSLATED);
				GlobalMembersImport.fieldSeparator = new QString("no sep"); //must have length >= 2
			}
			else
			{
				Debug.Assert(GlobalMembersImport.fieldSeparator.size() == 1);
				//assert(!fieldSeparator.at(0).isLetterOrNumber());
			}

			GlobalMembersImport.textquote = textquoteCB.currentText();

			if (textquoteCB.currentIndex() == NO_TEXTQUOTE_POS)
			{
				Debug.Assert(GlobalMembersImport.textquote == NO_TEXTQUOTE_TRANSLATED);
				GlobalMembersImport.textquote = new QString("no tquote"); //must have length >= 2
			}
			else
			{
				Debug.Assert(GlobalMembersImport.textquote.size() == 1);
				//assert(!textquote.at(0).isLetterOrNumber());
			}
		}
		else
		{
			Debug.Assert(separatorsCB == null);
			Debug.Assert(textquoteCB == null);
			GlobalMembersImport.fieldSeparator = "";
			GlobalMembersImport.textquote = "";
		}
	//NEW start
				QString tmp = new QString();
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: QString tmpLine=line;
				QString tmpLine = new QString(line);
				while (!tmpLine.isEmpty())
				{
					tmp.clear();
					bool foundField = false;
					if (tmpLine.left(1) == GlobalMembersImport.textquote)
					{
						tmpLine.remove(0,1);
						while (!foundField && tmpLine.size() > 1)
						{
							if (tmpLine.left(1) != GlobalMembersImport.textquote)
							{
								tmp += tmpLine.left(1);
							}
							else
							{
								if (tmpLine.mid(1,1) == GlobalMembersImport.fieldSeparator)
								{
									foundField = true;
									tmpLine.remove(0,1);
								}
								else if (tmpLine.mid(1,1) == GlobalMembersImport.textquote)
								{
									tmp += GlobalMembersImport.textquote;
									tmpLine.remove(0,1);
								}
								else
								{
									QMessageBox.critical(newParent, tr("FET warning"), Import.tr("Missing field separator or text quote in first line. Import might be incorrect.") + "\n");
								}
							}
							tmpLine.remove(0,1);
						}
						if (!foundField && tmpLine.size() == 1)
						{
							if (tmpLine.left(1) == GlobalMembersImport.textquote)
							{
								tmpLine.remove(0,1);
							}
							else
							{
								QMessageBox.critical(newParent, tr("FET warning"), Import.tr("Missing closing text quote in first line. Import might be incorrect.") + "\n");
								tmp += tmpLine.left(1);
								tmpLine.remove(0,1);
							}

						}
					}
					else
					{
						while (!foundField && !tmpLine.isEmpty())
						{
							if (tmpLine.left(1) != GlobalMembersImport.fieldSeparator)
								tmp += tmpLine.left(1);
							else
								foundField = true;
							tmpLine.remove(0,1);
						}
					}
					GlobalMembersImport.fields << tmp;
					if (foundField && tmpLine.isEmpty())
						GlobalMembersImport.fields << "";
				}
	//NEW end

	/* OLD
		if(separators.size()>1){
			fieldSeparator=separatorsCB->currentText();
			fields=line.split(fieldSeparator);
		} else {
			fieldSeparator=separators.takeFirst();
			fields<<line;
		}
	OLD */

		if (firstLineRadio1.isChecked())
			GlobalMembersImport.head = true;
		else
			GlobalMembersImport.head = false;
		return true;
	}
	private static int readFields(QWidget parent)
	{
		QSet<QString> checkSet = new QSet<QString>();
		QString check = new QString();
		GlobalMembersImport.numberOfFields = GlobalMembersImport.fields.size();
		Debug.Assert(GlobalMembersImport.numberOfFields > 0);
		for (int i = 0; i < GlobalMembersImport.NUMBER_OF_FIELDS; i++)
		{
			Debug.Assert(GlobalMembersImport.fieldNumber[i] <= GlobalMembersImport.numberOfFields);
			Debug.Assert(GlobalMembersImport.fieldNumber[i] >= GlobalMembersImport.DO_NOT_IMPORT);
		}

		QFile file = new QFile(GlobalMembersImport.fileName);
		if (GlobalMembersImport.fileName.isEmpty())
		{
			QMessageBox.warning(parent, tr("FET warning"), tr("Empty filename."));
			return false;
		}
		if (!file.open(QIODevice.ReadOnly))
		{
			QMessageBox.warning(parent, tr("Error! Can't open file."),GlobalMembersImport.fileName);
			return false;
		}
		QTextStream @in = new QTextStream(file);
		@in.setCodec("UTF-8");

		qint64 size = file.size();
		QProgressDialog _progress = new QProgressDialog(parent);
		QProgressDialog progress = (_progress);
		progress.setWindowTitle(tr("Importing", "Title of a progress dialog"));
		progress.setLabelText(tr("Loading file"));
		progress.setModal(true);
		progress.setRange(0, size);
		//cout<<"progress in readFields starts"<<endl;
		qint64 crt = 0;

		QStringList fields = new QStringList();
		QString[] itemOfField = new QString[GlobalMembersImport.NUMBER_OF_FIELDS];
		int lineNumber = 0;
		while (!@in.atEnd())
		{
			progress.setValue(crt);
			QString line = @in.readLine();
			lineNumber++;
			crt += line.length();
			if (progress.wasCanceled())
			{
				QMessageBox.warning(parent, "FET", Import.tr("Loading canceled by user."));
				file.close();
				return false;
			}
			bool ok = true;
			if (!(lineNumber == 1 & GlobalMembersImport.head))
			{
				fields.clear();
				QString tmp = new QString();
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: QString tmpLine=line;
				QString tmpLine = new QString(line);
				while (!tmpLine.isEmpty())
				{
					tmp.clear();
					bool foundField = false;
					if (tmpLine.left(1) == GlobalMembersImport.textquote)
					{
						tmpLine.remove(0,1);
						while (!foundField && tmpLine.size() > 1)
						{
							if (tmpLine.left(1) != GlobalMembersImport.textquote)
							{
								tmp += tmpLine.left(1);
							}
							else
							{
								if (tmpLine.mid(1,1) == GlobalMembersImport.fieldSeparator)
								{
									foundField = true;
									tmpLine.remove(0,1);
								}
								else if (tmpLine.mid(1,1) == GlobalMembersImport.textquote)
								{
									tmp += GlobalMembersImport.textquote;
									tmpLine.remove(0,1);
								}
								else
									GlobalMembersImport.warnText += Import.tr("Warning: FET expected field separator or text separator in line %1. Import might be incorrect.").arg(lineNumber) + "\n";
							}
							tmpLine.remove(0,1);
						}
						if (!foundField && tmpLine.size() == 1)
						{
							if (tmpLine.left(1) == GlobalMembersImport.textquote)
							{
								tmpLine.remove(0,1);
							}
							else
							{
								GlobalMembersImport.warnText += Import.tr("Warning: FET expected closing text separator in line %1. Import might be incorrect.").arg(lineNumber) + "\n";
								tmp += tmpLine.left(1);
								tmpLine.remove(0,1);
							}

						}
					}
					else
					{
						while (!foundField && !tmpLine.isEmpty())
						{
							if (tmpLine.left(1) != GlobalMembersImport.fieldSeparator)
								tmp += tmpLine.left(1);
							else
								foundField = true;
							tmpLine.remove(0,1);
						}
					}
					fields << tmp;
					if (foundField && tmpLine.isEmpty())
						fields << "";
				}
	/*
				if(separator.size()==1){
					fields = line.split(separator);
				} else
					fields << line;
	*/
				if (GlobalMembersImport.numberOfFields != fields.size())
				{
					GlobalMembersImport.warnText += Import.tr("Skipped line %1: FET expected %2 fields but found %3 fields.").arg(lineNumber).arg(GlobalMembersImport.numberOfFields).arg(fields.size()) + "\n";
					ok = false;
				}
				else
				{
					for (int i = 0; i < GlobalMembersImport.NUMBER_OF_FIELDS; i++)
					{
						if (GlobalMembersImport.fieldNumber[i] >= 0)
						{
							itemOfField[i].clear();
							itemOfField[i] = fields[GlobalMembersImport.fieldNumber[i]];
							if (itemOfField[i].isEmpty())
							{
								if (i == GlobalMembersImport.FIELD_YEAR_NAME || i == GlobalMembersImport.FIELD_TEACHER_NAME || i == GlobalMembersImport.FIELD_SUBJECT_NAME)
								{
									GlobalMembersImport.warnText += Import.tr("Skipped line %1: Field '%2' is empty.").arg(lineNumber).arg(GlobalMembersImport.fieldName[i]) + "\n";
									ok = false;
								}
								if (i == GlobalMembersImport.FIELD_YEAR_NUMBER_OF_STUDENTS || i == GlobalMembersImport.FIELD_GROUP_NUMBER_OF_STUDENTS || i == GlobalMembersImport.FIELD_SUBGROUP_NUMBER_OF_STUDENTS)
								{
									itemOfField[i] = "0";
								}
								//if(i==FIELD_SUBGROUP_NAME) is OK
								//if(i==FIELD_ACTIVITY_TAG_NAME) is OK
								//if(i==FIELD_ROOM_NAME) is OK
								if (i == GlobalMembersImport.FIELD_ROOM_CAPACITY)
								{
									itemOfField[i] == GlobalMembersImport.fieldDefaultItem[i];
								}
								if (i == GlobalMembersImport.FIELD_MIN_DAYS)
								{
									itemOfField[i] = "0";
								}
								if (i == GlobalMembersImport.FIELD_MIN_DAYS_WEIGHT)
								{
									if (itemOfField[GlobalMembersImport.FIELD_MIN_DAYS].isEmpty())
									{
										ok = false;
										GlobalMembersImport.warnText += Import.tr("Skipped line %1: Field '%2' is empty.").arg(lineNumber).arg(GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_MIN_DAYS]) + "\n";
									}
									else
										itemOfField[i] = "95";
								}
								if (i == GlobalMembersImport.FIELD_MIN_DAYS_CONSECUTIVE)
								{
									if (itemOfField[GlobalMembersImport.FIELD_MIN_DAYS].isEmpty())
									{
										ok = false;
										GlobalMembersImport.warnText += Import.tr("Skipped line %1: Field '%2' is empty.").arg(lineNumber).arg(GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_MIN_DAYS]) + "\n";
									}
									else
										itemOfField[i] = "N";
								}
							}
							if (ok && i == GlobalMembersImport.FIELD_SUBGROUP_NAME && !itemOfField[GlobalMembersImport.FIELD_SUBGROUP_NAME].isEmpty() && itemOfField[GlobalMembersImport.FIELD_GROUP_NAME].isEmpty())
							{
								GlobalMembersImport.warnText += Import.tr("Skipped line %1: Field '%2' is empty.").arg(lineNumber).arg(GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_GROUP_NAME]) + "\n";
								ok = false;
							}
							if (ok && i == GlobalMembersImport.FIELD_SPLIT_DURATION)
							{
								if (itemOfField[GlobalMembersImport.FIELD_SPLIT_DURATION].isEmpty())
								{
									if (!itemOfField[GlobalMembersImport.FIELD_TOTAL_DURATION].isEmpty())
									{
										int totalInt = itemOfField[GlobalMembersImport.FIELD_TOTAL_DURATION].toInt(ok, 10);
										if (ok && totalInt >= 1)
										{
											if (totalInt <= GlobalMembersTimetable_defs.MAX_SPLIT_OF_AN_ACTIVITY)
											{
												QString tmpString = new QString();
												for (int n = 0; n < totalInt; n++)
												{
													if (n != 0)
														tmpString += "+";
													tmpString += "1";
												}
												itemOfField[GlobalMembersImport.FIELD_SPLIT_DURATION] = tmpString;
											}
											else
											{
												GlobalMembersImport.warnText += Import.tr("Skipped line %1: Field '%2' produces too many subactivities.").arg(lineNumber).arg(GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_TOTAL_DURATION]) + "\n";
												ok = false;
											}
										}
										else
										{
											GlobalMembersImport.warnText += Import.tr("Skipped line %1: Field '%2' contain incorrect data.").arg(lineNumber).arg(GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_TOTAL_DURATION]) + "\n";
											ok = false;
										}
									}
									else
									{
										GlobalMembersImport.warnText += Import.tr("Skipped line %1: Field '%2' is empty.").arg(lineNumber).arg(GlobalMembersImport.fieldName[i]) + "\n";
										ok = false;
									}
								}
								else
								{
									QStringList splittedList = new QStringList();
									if (itemOfField[GlobalMembersImport.FIELD_SPLIT_DURATION].count("+") < GlobalMembersTimetable_defs.MAX_SPLIT_OF_AN_ACTIVITY)
									{
										splittedList = itemOfField[GlobalMembersImport.FIELD_SPLIT_DURATION].split("+");
										int tmpInt = 0;
										QString splitted = new QString();
										while (ok && !splittedList.isEmpty())
										{
											splitted = splittedList.takeFirst();
											tmpInt += splitted.toInt(ok, 10);
											if (!ok)
												GlobalMembersImport.warnText += Import.tr("Skipped line %1: Field '%2' doesn't contain an integer value.").arg(lineNumber).arg(GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_SPLIT_DURATION]) + "\n";
										}
										if (itemOfField[GlobalMembersImport.FIELD_TOTAL_DURATION].isEmpty())
										{
											itemOfField[GlobalMembersImport.FIELD_TOTAL_DURATION] = CustomFETString.number(tmpInt);
										}
										else
										{
											int totalInt = itemOfField[GlobalMembersImport.FIELD_TOTAL_DURATION].toInt(ok, 10);
											if (totalInt != tmpInt)
											{
												GlobalMembersImport.warnText += Import.tr("Skipped line %1: Fields '%2' and '%3' haven't the same value.").arg(lineNumber).arg(GlobalMembersImport.fieldName[i]).arg(GlobalMembersImport.fieldName[GlobalMembersImport.FIELD_TOTAL_DURATION]) + "\n";
												ok = false;
											}
										}
									}
									else
									{
										GlobalMembersImport.warnText += Import.tr("Skipped line %1: Field '%2' contains too many subactivities.").arg(lineNumber).arg(GlobalMembersImport.fieldName[i]) + "\n";
										ok = false;
									}
								}
							}
							if (ok && !itemOfField[GlobalMembersImport.FIELD_BUILDING_NAME].isEmpty() && itemOfField[GlobalMembersImport.FIELD_ROOM_NAME].isEmpty() && i == GlobalMembersImport.FIELD_ROOM_NAME)
							{
								GlobalMembersImport.warnText += Import.tr("Warning in line %1: Field with building name doesn't affect to a room").arg(lineNumber) + "\n";
							}
							if (ok && (i == GlobalMembersImport.FIELD_YEAR_NUMBER_OF_STUDENTS || i == GlobalMembersImport.FIELD_GROUP_NUMBER_OF_STUDENTS || i == GlobalMembersImport.FIELD_SUBGROUP_NUMBER_OF_STUDENTS || i == GlobalMembersImport.FIELD_ROOM_CAPACITY || i == GlobalMembersImport.FIELD_TOTAL_DURATION || i == GlobalMembersImport.FIELD_MIN_DAYS))
							{
								if (!itemOfField[i].isEmpty())
								{
									int value = itemOfField[i].toInt(ok, 10);
									if (!ok)
										GlobalMembersImport.warnText += Import.tr("Skipped line %1: Field '%2' doesn't contain an integer value.").arg(lineNumber).arg(GlobalMembersImport.fieldName[i]) + "\n";
									else
									{
										if (value < 0)
										{
											GlobalMembersImport.warnText += Import.tr("Skipped line %1: Field '%2' contains an invalid integer value.").arg(lineNumber).arg(GlobalMembersImport.fieldName[i]) + "\n";
											ok = false;
										}
									}
								}
								else if (i == GlobalMembersImport.FIELD_TOTAL_DURATION)
								{
									 Debug.Assert(true);
								}
								else
								{
									ok = false;
									GlobalMembersImport.warnText += Import.tr("Skipped line %1: Field '%2' doesn't contain an integer value.").arg(lineNumber).arg(GlobalMembersImport.fieldName[i]) + "\n";
									//because of bug reported by murad on 25 May 2010, crash when importing rooms, if capacity is empty
									//assert(false);
								}
							}
							if (ok && i == GlobalMembersImport.FIELD_MIN_DAYS_WEIGHT)
							{
	//							double weight=itemOfField[i].toDouble(&ok);
								double weight = GlobalMembersTimetable_defs.customFETStrToDouble(itemOfField[i], ok);
								if (!ok)
									GlobalMembersImport.warnText += Import.tr("Skipped line %1: Field '%2' doesn't contain a number (double) value.").arg(lineNumber).arg(GlobalMembersImport.fieldName[i]) + "\n";
								else
								{
									if (weight<0.0 || weight>100.0)
									{
										GlobalMembersImport.warnText += Import.tr("Skipped line %1: Field '%2' contains an number (double) value.").arg(lineNumber).arg(GlobalMembersImport.fieldName[i]) + "\n";
										ok = false;
									}
								}
							}
							if (ok && i == GlobalMembersImport.FIELD_MIN_DAYS_CONSECUTIVE)
							{
								QString tmpString = new QString();
								tmpString = itemOfField[i];
								tmpString = tmpString.toUpper();
								if (tmpString == "Y" || tmpString == "YES" || tmpString == "T" || tmpString == "TRUE" || tmpString == "1")
									itemOfField[i] = "yes";
								else if (tmpString == "N" || tmpString == "NO" || tmpString == "F" || tmpString == "FALSE" || tmpString == "0")
									itemOfField[i] = "no";
								else
									ok = false;
								if (!ok)
									GlobalMembersImport.warnText += Import.tr("Skipped line %1: Field '%2' contain an unknown value.").arg(lineNumber).arg(GlobalMembersImport.fieldName[i]) + "\n";
							}
						}
						else if (GlobalMembersImport.fieldNumber[i] == GlobalMembersImport.IMPORT_DEFAULT_ITEM)
						{
							itemOfField[i].clear();
							itemOfField[i] = GlobalMembersImport.fieldDefaultItem[i];
							//Removed by Liviu - we may have empty default fields
							//assert(!fieldDefaultItem[i].isEmpty());
						}
					}
				}
				if (ok)
				{
					check.clear();
					for (int i = 0; i < GlobalMembersImport.NUMBER_OF_FIELDS; i++)
					{
						check += itemOfField[i] + " ";
					}
					if (checkSet.contains(check))
					{
						if (GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_SPLIT_DURATION] != GlobalMembersImport.DO_NOT_IMPORT || GlobalMembersImport.fieldNumber[GlobalMembersImport.FIELD_TOTAL_DURATION] != GlobalMembersImport.DO_NOT_IMPORT)
						{
							GlobalMembersImport.warnText += Import.tr("Note about line %1: Data was already in a previous line. So this data will be imported once again.").arg(lineNumber) + "\n";
						}
						else
						{
							GlobalMembersImport.warnText += Import.tr("Skipped line %1: Data was already in a previous line.").arg(lineNumber) + "\n";
							ok = false;
						}
					}
					else
						checkSet << check;
				}
				if (ok)
				{
					//QString tmp;
					//tmp=tr("%1").arg(lineNumber);
					//itemOfField[FIELD_LINE_NUMBER]=tmp;
					itemOfField[GlobalMembersImport.FIELD_LINE_NUMBER] = CustomFETString.number(lineNumber);
					for (int i = 0; i < GlobalMembersImport.NUMBER_OF_FIELDS; i++)
					{
						if (GlobalMembersImport.fieldNumber[i] != GlobalMembersImport.DO_NOT_IMPORT)
							GlobalMembersImport.fieldList[i] << itemOfField[i];
					}
				}
				else
					GlobalMembersImport.warnText += "   " + Import.tr("Line %1 is: %2").arg(lineNumber).arg(line) + "\n";
			}
		}
		progress.setValue(size);
		//cout<<"progress in readFields ends"<<endl;
		int max = 0;
		for (int i = 0; i < GlobalMembersImport.NUMBER_OF_FIELDS; i++)
		{
			if (max == 0)
				max = GlobalMembersImport.fieldList[i].size();
			if (GlobalMembersImport.fieldNumber[i] > GlobalMembersImport.DO_NOT_IMPORT)
			{
				Debug.Assert(GlobalMembersImport.fieldList[i].size() == max);
			}
			else
				Debug.Assert(GlobalMembersImport.fieldList[i].isEmpty());
		}
		file.close();
		return true;
	}
	private static int showFieldsAndWarnings(QWidget parent, ref QDialog newParent)
	{
		newParent = ((QDialog)parent);

		int ok = true;

		int max = 0;
		for (int i = 0; i < GlobalMembersImport.NUMBER_OF_FIELDS; i++)
		{
			if (GlobalMembersImport.fieldNumber[i] > GlobalMembersImport.DO_NOT_IMPORT)
			{
				if (max == 0)
					max = GlobalMembersImport.fieldList[i].size();
				Debug.Assert(GlobalMembersImport.fieldList[i].size() == max);
			}
			else
			{
				if (i != GlobalMembersImport.FIELD_TEACHER_NAME) //needed for activities!
				{
					//assert(fieldList[i].isEmpty());
					//because of bug reported 17.03.2008. Please add again?! compare add activities function
				}
			}
		}
		// Start Dialog
		newParent = new QDialog(parent);
		QDialog addItemsDialog = (newParent);
		addItemsDialog.setWindowTitle(Import.tr("FET import %1 question").arg(GlobalMembersImport.importThing));
		QVBoxLayout addItemsMainLayout = new QVBoxLayout(addItemsDialog);

		//Start Warnings
		QHBoxLayout headWarnings = new QHBoxLayout();
		QLabel headWarningsText = new QLabel();

		int tmp = GlobalMembersImport.fileName.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP);
		tmp = GlobalMembersImport.fileName.size() - tmp - 1;
		QString shortFileName = GlobalMembersImport.fileName.right(tmp);
		if (!GlobalMembersImport.warnText.isEmpty())
			headWarningsText.setText(Import.tr("There are several problems in file\n%1").arg(shortFileName));
		else
			headWarningsText.setText(Import.tr("There are no problems in file\n%1").arg(shortFileName));

	//TODO
	/*
	tr("There are no problems in file")
	+
	"\n"
	+
	FILE_STRIPPED_NAME
	*/

		headWarnings.addWidget(headWarningsText);
		headWarnings.addStretch();

		QPlainTextEdit textOfWarnings = new QPlainTextEdit();
		textOfWarnings.setMinimumWidth(500); //width
		textOfWarnings.setReadOnly(true);
		textOfWarnings.setWordWrapMode(QTextOption.NoWrap);
		textOfWarnings.setPlainText(GlobalMembersImport.warnText);

		//Start data table
		QLabel headTableText = new QLabel();
		if (max != 0)
			headTableText.setText(Import.tr("Following data found in the file:"));
		else
			headTableText.setText(Import.tr("There is no usable data in the file."));

		QTableWidget fieldsTable = new QTableWidget();
		fieldsTable.setRowCount(max);
		QStringList fieldsTabelLabel = new QStringList();

		int colums = 0;
		for (int i = 0; i < GlobalMembersImport.NUMBER_OF_FIELDS; i++)
		{
			if (GlobalMembersImport.fieldNumber[i] > GlobalMembersImport.DO_NOT_IMPORT)
			{
				fieldsTabelLabel << tr("%1").arg(GlobalMembersImport.fieldName[i]);
				colums++;
			}
		}
		fieldsTable.setColumnCount(colums);
		fieldsTable.setHorizontalHeaderLabels(fieldsTabelLabel);
		for (int i = 0; i < max; i++)
		{
			int colum = 0;
			for (int f = 0; f < GlobalMembersImport.NUMBER_OF_FIELDS; f++)
			{
				if (GlobalMembersImport.fieldNumber[f] > GlobalMembersImport.DO_NOT_IMPORT)
				{
					QTableWidgetItem newItem = new QTableWidgetItem(GlobalMembersImport.fieldList[f][i]);
					newItem.setFlags(Qt.ItemIsSelectable | Qt.ItemIsEnabled);
					fieldsTable.setItem(i, colum, newItem);
					colum++;
				}
			}
		}
		fieldsTable.resizeColumnsToContents();
		fieldsTable.resizeRowsToContents();

		//Start current data warning
		QVBoxLayout dataWarningBox = new QVBoxLayout();
		QLabel dataWarningText = new QLabel();
		if (GlobalMembersImport.dataWarning.size() == 1)
			dataWarningText.setText(Import.tr("FET noticed %1 warning with the current data.").arg(GlobalMembersImport.dataWarning.size()));
		else
			dataWarningText.setText(Import.tr("FET noticed %1 warnings with the current data.").arg(GlobalMembersImport.dataWarning.size()));
		dataWarningBox.addWidget(dataWarningText);

		QListWidget dataWarningItems = new QListWidget();
		dataWarningItems.addItems(GlobalMembersImport.dataWarning);
		if (GlobalMembersImport.dataWarning.size() > 0)
			dataWarningBox.addWidget(dataWarningItems);
		else
			dataWarningItems = null;

		//Start Buttons
		QPushButton pb1 = new QPushButton(tr("&Import"));
		QPushButton pb2 = new QPushButton(tr("&Cancel"));

		//TODO: why doesn't work this?
		//if((dataWarning.size()>0&&dataWarning.size()==max)||!warnText.isEmpty())
		//	pb2->setDefault(true);
		//else
		//	 pb1->setDefault(true);
		//	 pb1->setFocus();
			// pb1->setAutoDefault(true);

		QHBoxLayout hl = new QHBoxLayout();
		hl.addStretch();
		hl.addWidget(pb1);
		hl.addWidget(pb2);

		//Start adding all into main layout
		addItemsMainLayout.addLayout(headWarnings);
		if (!GlobalMembersImport.warnText.isEmpty())
			addItemsMainLayout.addWidget(textOfWarnings);
		else
			textOfWarnings = null;
		addItemsMainLayout.addWidget(headTableText);
		if (max != 0)
			addItemsMainLayout.addWidget(fieldsTable);
		else
			if (fieldsTable != null)
				fieldsTable.Dispose();
		addItemsMainLayout.addLayout(dataWarningBox);
		addItemsMainLayout.addLayout(hl);

		QObject.connect(pb1, SIGNAL(clicked()), addItemsDialog, SLOT(accept()));
		QObject.connect(pb2, SIGNAL(clicked()), addItemsDialog, SLOT(reject()));

		//pb1->setDefault(true);

		int w = chooseWidth(addItemsDialog.sizeHint().width());
		int h = chooseHeight(addItemsDialog.sizeHint().height());
		addItemsDialog.resize(w,h);

		QString settingsName = new QString();
		if (GlobalMembersImport.importThing == Import.tr("activity tags"))
			settingsName = new QString("ImportActivityTagsShowFieldsAndWarningsDialog");
		else if (GlobalMembersImport.importThing == Import.tr("buildings and rooms"))
			settingsName = new QString("ImportBuildingsRoomsShowFieldsAndWarningsDialog");
		else if (GlobalMembersImport.importThing == Import.tr("teachers"))
			settingsName = new QString("ImportTeachersShowFieldsAndWarningsDialog");
		else if (GlobalMembersImport.importThing == Import.tr("subjects"))
			settingsName = new QString("ImportSubjectsShowFieldsAndWarningsDialog");
		else if (GlobalMembersImport.importThing == Import.tr("years, groups and subgroups"))
			settingsName = new QString("ImportYearsGroupsSubgroupsShowFieldsAndWarningsDialog");
		else if (GlobalMembersImport.importThing == Import.tr("activities"))
			settingsName = new QString("ImportActivitiesShowFieldsAndWarningsDialog");

		pb1.setDefault(true);
		pb1.setFocus();

		centerWidgetOnScreen(addItemsDialog);
		restoreFETDialogGeometry(addItemsDialog, settingsName);

		ok = addItemsDialog.exec();
		saveFETDialogGeometry(addItemsDialog, settingsName);

		return ok;
	}
}

public partial class ChooseFieldsDialog: QDialog
{
	Q_OBJECT public: ChooseFieldsDialog(QWidget * parent); //can be this done privat, too?
	public void Dispose()
	{
		//saveFETDialogGeometry(this, _settingsName);
	}

	private QGroupBox[] fieldGroupBox = new QGroupBox[NUMBER_OF_FIELDS];
	private QRadioButton[] fieldRadio1 = new QRadioButton[NUMBER_OF_FIELDS];
	private QRadioButton[] fieldRadio2 = new QRadioButton[NUMBER_OF_FIELDS];
	private QRadioButton[] fieldRadio3 = new QRadioButton[NUMBER_OF_FIELDS];
	private QRadioButton[] fieldRadio3b = new QRadioButton[NUMBER_OF_FIELDS];
	private QComboBox[] fieldLine2CB = new QComboBox[NUMBER_OF_FIELDS];
	private QLineEdit[] fieldLine3Text = new QLineEdit[NUMBER_OF_FIELDS];
	private QSpinBox[] fieldLine3bSpinBox = new QSpinBox[NUMBER_OF_FIELDS];
	private QPushButton pb;
	private QPushButton cancelpb;
	private QHBoxLayout buttonsLayout;

	private QString _settingsName = new QString();

internal slots: void chooseFieldsDialogClose();
	private void chooseFieldsDialogUpdateRadio1()
	{
		if (fieldRadio1[GlobalMembersImport.FIELD_GROUP_NAME].isChecked())
		{
			fieldRadio1[GlobalMembersImport.FIELD_GROUP_NUMBER_OF_STUDENTS].setChecked(true);
			fieldRadio1[GlobalMembersImport.FIELD_SUBGROUP_NAME].setChecked(true);
			fieldRadio1[GlobalMembersImport.FIELD_SUBGROUP_NUMBER_OF_STUDENTS].setChecked(true);
			fieldGroupBox[GlobalMembersImport.FIELD_GROUP_NUMBER_OF_STUDENTS].setDisabled(true);
			fieldGroupBox[GlobalMembersImport.FIELD_SUBGROUP_NUMBER_OF_STUDENTS].setDisabled(true);
			fieldGroupBox[GlobalMembersImport.FIELD_SUBGROUP_NAME].setDisabled(true);
		}
		if (fieldRadio1[GlobalMembersImport.FIELD_SUBGROUP_NAME].isChecked())
		{
			fieldRadio1[GlobalMembersImport.FIELD_SUBGROUP_NUMBER_OF_STUDENTS].setChecked(true);
			fieldGroupBox[GlobalMembersImport.FIELD_SUBGROUP_NUMBER_OF_STUDENTS].setDisabled(true);
		}
		if (fieldRadio1[GlobalMembersImport.FIELD_ROOM_NAME].isChecked())
		{
			fieldRadio1[GlobalMembersImport.FIELD_ROOM_CAPACITY].setChecked(true);
			fieldGroupBox[GlobalMembersImport.FIELD_ROOM_CAPACITY].setDisabled(true);
		}
		if (fieldRadio1[GlobalMembersImport.FIELD_BUILDING_NAME].isChecked() && fieldRadio1[GlobalMembersImport.FIELD_ROOM_NAME].isChecked())
		{
			pb.setDisabled(true);
		}
		if ((fieldRadio1[GlobalMembersImport.FIELD_BUILDING_NAME].isChecked() && !fieldRadio1[GlobalMembersImport.FIELD_ROOM_NAME].isChecked() && fieldLine3Text[GlobalMembersImport.FIELD_BUILDING_NAME].displayText() != "") || (!fieldRadio1[GlobalMembersImport.FIELD_BUILDING_NAME].isChecked() && fieldRadio1[GlobalMembersImport.FIELD_ROOM_NAME].isChecked() && fieldLine3Text[GlobalMembersImport.FIELD_BUILDING_NAME].displayText() != ""))
		{
			pb.setDisabled(false);
		}
	}
	private void chooseFieldsDialogUpdateRadio2()
	{
		if (fieldRadio2[GlobalMembersImport.FIELD_GROUP_NAME].isChecked())
		{
			fieldGroupBox[GlobalMembersImport.FIELD_SUBGROUP_NAME].setDisabled(false);
			fieldGroupBox[GlobalMembersImport.FIELD_SUBGROUP_NUMBER_OF_STUDENTS].setDisabled(false);
			fieldGroupBox[GlobalMembersImport.FIELD_GROUP_NUMBER_OF_STUDENTS].setDisabled(false);
			fieldGroupBox[GlobalMembersImport.FIELD_SUBGROUP_NUMBER_OF_STUDENTS].setDisabled(false);
			if (fieldRadio1[GlobalMembersImport.FIELD_GROUP_NUMBER_OF_STUDENTS].isChecked())
				fieldRadio3b[GlobalMembersImport.FIELD_GROUP_NUMBER_OF_STUDENTS].setChecked(true);
			if (fieldRadio1[GlobalMembersImport.FIELD_SUBGROUP_NUMBER_OF_STUDENTS].isChecked())
				fieldRadio3b[GlobalMembersImport.FIELD_SUBGROUP_NUMBER_OF_STUDENTS].setChecked(true);
		}
		if (fieldRadio2[GlobalMembersImport.FIELD_ROOM_NAME].isChecked())
		{
			if (fieldRadio1[GlobalMembersImport.FIELD_ROOM_CAPACITY].isChecked())
				fieldRadio3b[GlobalMembersImport.FIELD_ROOM_CAPACITY].setChecked(true);
			fieldGroupBox[GlobalMembersImport.FIELD_ROOM_CAPACITY].setDisabled(false);
		}
	}
	private void chooseFieldsDialogUpdateRadio3()
	{
		if (fieldRadio3[GlobalMembersImport.FIELD_GROUP_NAME].isChecked())
		{
			fieldGroupBox[GlobalMembersImport.FIELD_SUBGROUP_NAME].setDisabled(false);
			fieldGroupBox[GlobalMembersImport.FIELD_SUBGROUP_NUMBER_OF_STUDENTS].setDisabled(false);
			fieldGroupBox[GlobalMembersImport.FIELD_GROUP_NUMBER_OF_STUDENTS].setDisabled(false);
			fieldGroupBox[GlobalMembersImport.FIELD_SUBGROUP_NUMBER_OF_STUDENTS].setDisabled(false);
			if (fieldRadio1[GlobalMembersImport.FIELD_GROUP_NUMBER_OF_STUDENTS].isChecked())
				fieldRadio3b[GlobalMembersImport.FIELD_GROUP_NUMBER_OF_STUDENTS].setChecked(true);
			if (fieldRadio1[GlobalMembersImport.FIELD_SUBGROUP_NUMBER_OF_STUDENTS].isChecked())
				fieldRadio3b[GlobalMembersImport.FIELD_SUBGROUP_NUMBER_OF_STUDENTS].setChecked(true);
		}
		if (fieldRadio3[GlobalMembersImport.FIELD_ROOM_NAME].isChecked())
		{
			if (fieldRadio1[GlobalMembersImport.FIELD_ROOM_CAPACITY].isChecked())
				fieldRadio3b[GlobalMembersImport.FIELD_ROOM_CAPACITY].setChecked(true);
			fieldGroupBox[GlobalMembersImport.FIELD_ROOM_CAPACITY].setDisabled(false);
		}
	}
	private void chooseFieldsDialogUpdateRadio3b()
	{
		if (fieldRadio3b[GlobalMembersImport.FIELD_GROUP_NAME].isChecked())
		{
			fieldGroupBox[GlobalMembersImport.FIELD_SUBGROUP_NAME].setDisabled(false);
			fieldGroupBox[GlobalMembersImport.FIELD_SUBGROUP_NUMBER_OF_STUDENTS].setDisabled(false);
			fieldGroupBox[GlobalMembersImport.FIELD_GROUP_NUMBER_OF_STUDENTS].setDisabled(false);
			fieldGroupBox[GlobalMembersImport.FIELD_SUBGROUP_NUMBER_OF_STUDENTS].setDisabled(false);
			if (fieldRadio1[GlobalMembersImport.FIELD_GROUP_NUMBER_OF_STUDENTS].isChecked())
				fieldRadio3b[GlobalMembersImport.FIELD_GROUP_NUMBER_OF_STUDENTS].setChecked(true);
			if (fieldRadio1[GlobalMembersImport.FIELD_SUBGROUP_NUMBER_OF_STUDENTS].isChecked())
				fieldRadio3b[GlobalMembersImport.FIELD_SUBGROUP_NUMBER_OF_STUDENTS].setChecked(true);
		}
		if (fieldRadio3b[GlobalMembersImport.FIELD_ROOM_NAME].isChecked())
		{
			if (fieldRadio1[GlobalMembersImport.FIELD_ROOM_CAPACITY].isChecked())
				fieldRadio3b[GlobalMembersImport.FIELD_ROOM_CAPACITY].setChecked(true);
			fieldGroupBox[GlobalMembersImport.FIELD_ROOM_CAPACITY].setDisabled(false);
		}
	}
	private void chooseFieldsDialogUpdateLine3Text()
	{
		bool textOK = true;
		for (int i = 1; i < GlobalMembersImport.NUMBER_OF_FIELDS; i++)
		{
			if (fieldLine3Text[i].displayText() == "")
				textOK = false;
		}
		//by Liviu - always enabled
		if (1 || textOK)
			pb.setDisabled(false);
		else
			pb.setDisabled(true);
	}
}

public partial class LastWarningsDialog: QDialog
{
	Q_OBJECT public: LastWarningsDialog(QWidget * parent); //can be this done privat, too?
	public void Dispose()
	{
	}
}


//TODO: add this into the first function!? form to full?!
//C++ TO C# CONVERTER WARNING: The declaration of the following method implementation was not found:
//ORIGINAL LINE: ChooseFieldsDialog::ChooseFieldsDialog(QWidget *parent): QDialog(parent)


//C++ TO C# CONVERTER WARNING: The declaration of the following method implementation was not found:
//ORIGINAL LINE: void ChooseFieldsDialog::chooseFieldsDialogClose()


//C++ TO C# CONVERTER WARNING: The declaration of the following method implementation was not found:
//ORIGINAL LINE: LastWarningsDialog::LastWarningsDialog(QWidget *parent): QDialog(parent)


public partial class ChooseFieldsDialog
{
	public ChooseFieldsDialog(QWidget parent)
	{
		QDialog = parent;
		Debug.Assert(fields.size() > 0);
    
		this.setWindowTitle(tr("FET - Import from CSV file"));
		QGridLayout chooseFieldsMainLayout = new QGridLayout(this);
    
		QVBoxLayout[] fieldBox = new QVBoxLayout[NUMBER_OF_FIELDS];
		QHBoxLayout[] fieldLine1 = new QHBoxLayout[NUMBER_OF_FIELDS];
		QHBoxLayout[] fieldLine2 = new QHBoxLayout[NUMBER_OF_FIELDS];
		QHBoxLayout[] fieldLine3 = new QHBoxLayout[NUMBER_OF_FIELDS];
		QHBoxLayout[] fieldLine3b = new QHBoxLayout[NUMBER_OF_FIELDS];
    
		int gridRow = 0;
		int gridColumn = 0;
		for (int i = 1; i < NUMBER_OF_FIELDS; i++)
		{
			Debug.Assert(fieldNumber[i] == DO_NOT_IMPORT || fieldNumber[i] == IMPORT_DEFAULT_ITEM);
			fieldGroupBox[i] = new QGroupBox(Import.tr("Please specify the %1 field:").arg(fieldName[i]));
			fieldBox[i] = new QVBoxLayout();
			fieldRadio1[i] = new QRadioButton(Import.tr("Don't import \"%1\".").arg(fieldName[i]));
			fieldRadio2[i] = new QRadioButton(Import.tr("Import this field from CSV:"));
    
			//trick to keep the translation active, maybe we need it in the future
			QString s = Import.tr("Set always the same name:");
			Q_UNUSED(s);
    
			//fieldRadio3[i] = new QRadioButton(Import::tr("Set always the same name:"));
			fieldRadio3[i] = new QRadioButton(Import.tr("Set always the same value:")); //modified by Liviu on 18 March 2009
			fieldRadio3b[i] = new QRadioButton(Import.tr("Set always the same value:"));
    
			fieldLine1[i] = new QHBoxLayout();
			fieldLine1[i].addWidget(fieldRadio1[i]);
			fieldBox[i].addLayout(fieldLine1[i]);
    
			fieldLine2CB[i] = new QComboBox();
			fieldLine2CB[i].setMaximumWidth(220); //max
			fieldLine2CB[i].insertItems(0,fields);
			fieldLine2[i] = new QHBoxLayout();
			fieldLine2[i].addWidget(fieldRadio2[i]);
			fieldLine2[i].addWidget(fieldLine2CB[i]);
			fieldBox[i].addLayout(fieldLine2[i]);
			fieldRadio2[i].setChecked(true);
    
			fieldLine3Text[i] = new QLineEdit(Import.tr("Please modify this text."));
	//		fieldLine3Text[i]->setMaximumWidth(220);		//max
			fieldLine3[i] = new QHBoxLayout();
			fieldLine3[i].addWidget(fieldRadio3[i]);
    
			//Added by Liviu - 18 March 2009, so that the dialog looks nice when dialog is maximized
    
			//TODO: add this line or not???
			fieldLine3[i].addStretch();
			//fieldLine3Text[i]->setSizePolicy(QSizePolicy::MinimumExpanding, QSizePolicy::Maximum);
    
			fieldLine3[i].addWidget(fieldLine3Text[i]);
			fieldBox[i].addLayout(fieldLine3[i]);
    
			fieldLine3bSpinBox[i] = new QSpinBox();
			fieldLine3bSpinBox[i].setMaximumWidth(220); //max
			fieldLine3b[i] = new QHBoxLayout();
			fieldLine3b[i].addWidget(fieldRadio3b[i]);
			fieldLine3b[i].addWidget(fieldLine3bSpinBox[i]);
			fieldBox[i].addLayout(fieldLine3b[i]);
    
			fieldGroupBox[i].setLayout(fieldBox[i]);
			chooseFieldsMainLayout.addWidget(fieldGroupBox[i], gridRow, gridColumn);
			if (fieldNumber[i] == DO_NOT_IMPORT)
				fieldGroupBox[i].hide();
			else
			{
				if (gridColumn == 1)
				{
					gridColumn = 0;
					gridRow++;
				}
				else
					gridColumn++;
			}
    
			if (i == FIELD_YEAR_NAME || i == FIELD_TEACHER_NAME)
				fieldRadio1[i].hide();
			if (i == FIELD_ROOM_CAPACITY)
			{
				fieldRadio1[i].hide();
				fieldLine3bSpinBox[i].setMaximum(GlobalMembersTimetable_defs.MAX_ROOM_CAPACITY);
				fieldLine3bSpinBox[i].setMinimum(0);
				fieldLine3bSpinBox[i].setValue(GlobalMembersTimetable_defs.MAX_ROOM_CAPACITY);
				fieldRadio3b[i].setChecked(true);
				fieldRadio3[i].hide();
				fieldLine3Text[i].hide();
			}
			else if (i == FIELD_YEAR_NUMBER_OF_STUDENTS || i == FIELD_GROUP_NUMBER_OF_STUDENTS || i == FIELD_SUBGROUP_NUMBER_OF_STUDENTS)
			{
				fieldRadio1[i].hide();
				fieldLine3bSpinBox[i].setMaximum(GlobalMembersTimetable_defs.MAX_TOTAL_SUBGROUPS);
				fieldLine3bSpinBox[i].setMinimum(0);
				fieldLine3bSpinBox[i].setValue(0);
				fieldRadio3b[i].setChecked(true);
				fieldRadio3[i].hide();
				fieldLine3Text[i].hide();
			}
			else
			{
				fieldRadio3b[i].hide();
				fieldLine3bSpinBox[i].hide();
			}
			if (i == FIELD_SUBJECT_NAME)
			{
				fieldRadio1[i].hide();
				fieldRadio3[i].hide();
				fieldLine3Text[i].hide();
			}
			if (i == FIELD_ACTIVITY_TAG_NAME)
			{
				fieldRadio1[i].hide();
				fieldRadio3[i].hide();
				fieldLine3Text[i].hide();
			}
			if (i == FIELD_ROOM_NAME)
			{
				fieldRadio3[i].hide();
				fieldLine3Text[i].hide();
			}
    
			if (i == FIELD_TOTAL_DURATION)
			{
				fieldRadio1[i].hide();
				fieldLine3Text[i].setText("1");
			}
			if (i == FIELD_SPLIT_DURATION)
			{
				fieldRadio1[i].hide();
				fieldLine3Text[i].setText("1");
			}
			if (i == FIELD_MIN_DAYS)
			{
				fieldRadio1[i].hide();
				fieldLine3Text[i].setText("1");
			}
			if (i == FIELD_MIN_DAYS_WEIGHT)
			{
				fieldRadio1[i].hide();
				fieldLine3Text[i].setText("95");
			}
			if (i == FIELD_MIN_DAYS_CONSECUTIVE)
			{
				fieldRadio1[i].hide();
				fieldLine3Text[i].setText("1");
			}
		}
    
		gridRow++;
		/*
		pb=new QPushButton(tr("OK"));
		chooseFieldsMainLayout->addWidget(pb,gridRow,1);
		cancelpb=new QPushButton(tr("Cancel"));
		chooseFieldsMainLayout->addWidget(cancelpb,gridRow,2);*/
		pb = new QPushButton(tr("OK"));
		cancelpb = new QPushButton(tr("Cancel"));
		buttonsLayout = new QHBoxLayout();
		buttonsLayout.addStretch();
		buttonsLayout.addWidget(pb);
		buttonsLayout.addWidget(cancelpb);
		chooseFieldsMainLayout.addLayout(buttonsLayout,gridRow,1);
    
		chooseFieldsDialogUpdateRadio1();
		chooseFieldsDialogUpdateRadio2();
		chooseFieldsDialogUpdateRadio3();
		chooseFieldsDialogUpdateRadio3b();
    
		//connect(pb, SIGNAL(clicked()), this, SLOT(accept()));
		connect(pb, SIGNAL(clicked()), this, SLOT(chooseFieldsDialogClose()));
		connect(cancelpb, SIGNAL(clicked()), this, SLOT(reject()));
		for (int i = 1; i < NUMBER_OF_FIELDS; i++)
		{
			connect(fieldRadio1[i], SIGNAL(toggled(bool)), this, SLOT(chooseFieldsDialogUpdateRadio1()));
			connect(fieldRadio2[i], SIGNAL(toggled(bool)), this, SLOT(chooseFieldsDialogUpdateRadio2()));
			connect(fieldRadio3[i], SIGNAL(toggled(bool)), this, SLOT(chooseFieldsDialogUpdateRadio3()));
			connect(fieldRadio3b[i], SIGNAL(toggled(bool)), this, SLOT(chooseFieldsDialogUpdateRadio3b()));
			connect(fieldLine3Text[i], SIGNAL(textChanged(QString)), this, SLOT(chooseFieldsDialogUpdateLine3Text()));
		}
    
		pb.setDefault(true);
		pb.setFocus();
    
		//_settingsName=settingsName;
		//restoreFETDialogGeometry(this, _settingsName);
	}
	public void chooseFieldsDialogClose()
	{
		for (int i = 1; i < NUMBER_OF_FIELDS; i++)
		{
			if (fieldNumber[i] != DO_NOT_IMPORT)
			{
				if (fieldRadio1[i].isChecked())
				{
					fieldNumber[i] = DO_NOT_IMPORT;
				}
				if (fieldRadio2[i].isChecked())
				{
					fieldNumber[i] = fieldLine2CB[i].currentIndex();
					Debug.Assert(fieldNumber[i] < fields.size());
					Debug.Assert(fieldNumber[i] >= 0);
				}
				if (fieldRadio3[i].isChecked())
				{
					fieldNumber[i] = IMPORT_DEFAULT_ITEM;
					//fieldName[i]=fieldLine3CB[i]->currentText();
					fieldDefaultItem[i] = fieldLine3Text[i].displayText();
				}
				if (fieldRadio3b[i].isChecked())
				{
					fieldNumber[i] = IMPORT_DEFAULT_ITEM;
					fieldDefaultItem[i] = fieldLine3bSpinBox[i].cleanText();
				}
			}
		}
    
		this.accept();
	}
}

public partial class LastWarningsDialog
{
	public LastWarningsDialog(QWidget parent)
	{
		QDialog = parent;
		this.setWindowTitle(tr("FET - import %1 comment", "The comment of the importing of the category named %1").arg(importThing));
		QVBoxLayout lastWarningsMainLayout = new QVBoxLayout(this);
    
		QPlainTextEdit lastWarningsText = new QPlainTextEdit();
		lastWarningsText.setMinimumWidth(500); //width
		lastWarningsText.setMinimumHeight(250);
		lastWarningsText.setReadOnly(true);
		lastWarningsText.setWordWrapMode(QTextOption.NoWrap);
		lastWarningsText.setPlainText(lastWarning);
    
		//Start Buttons
		QPushButton pb1 = new QPushButton(tr("&OK"));
		//pb1->setAutoDefault(true);
    
		QHBoxLayout hl = new QHBoxLayout();
		hl.addStretch();
		hl.addWidget(pb1);
    
		//Start adding all into main layout
		lastWarningsMainLayout.addWidget(lastWarningsText);
		lastWarningsMainLayout.addLayout(hl);
    
		QObject.connect(pb1, SIGNAL(clicked()), this, SLOT(accept()));
    
		//pb1->setDefault(true);
    
		pb1.setDefault(true);
		pb1.setFocus();
	}
}