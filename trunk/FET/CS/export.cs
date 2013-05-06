using System.Diagnostics;

public static class GlobalMembersExport
{
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//void centerWidgetOnScreen(QWidget widget);



//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern Timetable gt;
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern Solution best_solution;
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern bool teachers_schedule_ready;
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern bool students_schedule_ready;
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern bool rooms_schedule_ready;

	public const string CSVActivities = "activities.csv";
	public const string CSVActivitiesStatistic = "statistics_activities.csv";
	public const string CSVActivityTags = "activity_tags.csv";
	public const string CSVRoomsAndBuildings = "rooms_and_buildings.csv";
	public const string CSVSubjects = "subjects.csv";
	public const string CSVTeachers = "teachers.csv";
	public const string CSVStudents = "students.csv";
	public const string CSVTimetable = "timetable.csv";
	public static QString DIRECTORY_CSV = new QString();
	public static QString PREFIX_CSV = new QString();
}

/*
File export.cpp
*/

/***************************************************************************
                                FET
                          -------------------
   copyright            : (C) by Lalescu Liviu
    email                : Please see http://lalescu.ro/liviu/ for details about contacting Liviu Lalescu (in particular, you can find here the e-mail address)
 ***************************************************************************
                          export.cpp  -  description
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

//TODO: protect export strings. textquote must be dubbled
//TODO: count skipped min day constraints?
//TODO: add cancel button


//C++ TO C# CONVERTER TODO TASK: C# does not allow setting or comparing #define constants:
#if QT_VERSION >= 0x050000
#else
#endif


//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class QWidget;

#if NDEBUG
#endif
/*
File export.h
*/

/***************************************************************************
                                FET
                          -------------------
   copyright            : (C) by Lalescu Liviu
    email                : Please see http://lalescu.ro/liviu/ for details about contacting Liviu Lalescu (in particular, you can find here the e-mail address)
 ***************************************************************************
                          export.h  -  description
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





public partial class Export: QObject
{
	Q_OBJECT public: Export();
	public void Dispose()
	{
	}

	private static void exportCSV(QWidget parent)
	{
		QString fieldSeparator = ",";
		QString textquote = "\"";
		QString setSeparator = "+";
		bool head = true;
		bool ok = true;

		GlobalMembersExport.DIRECTORY_CSV = GlobalMembersTimetable_defs.OUTPUT_DIR + GlobalMembersTimetable_defs.FILE_SEP + "csv";

		QString s2 = new QString();
		if (INPUT_FILENAME_XML == "")
			s2 = "unnamed";
		else
		{
			s2 = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1); //TODO: remove s2, because to long filenames!

			if (s2.right(4) == ".fet")
				s2 = s2.left(s2.length() - 4);
			//else if(INPUT_FILENAME_XML!="")
			//	cout<<"Minor problem - input file does not end in .fet extension - might be a problem when saving the timetables"<<" (file:"<<__FILE__<<", line:"<<__LINE__<<")"<<endl;
		}
		GlobalMembersExport.DIRECTORY_CSV.append(GlobalMembersTimetable_defs.FILE_SEP);
		GlobalMembersExport.DIRECTORY_CSV.append(s2);


		GlobalMembersExport.PREFIX_CSV = GlobalMembersExport.DIRECTORY_CSV + GlobalMembersTimetable_defs.FILE_SEP;

		QDir dir = new QDir();
		if (!dir.exists(GlobalMembersTimetable_defs.OUTPUT_DIR))
			dir.mkpath(GlobalMembersTimetable_defs.OUTPUT_DIR);
		if (!dir.exists(GlobalMembersExport.DIRECTORY_CSV))
			dir.mkpath(GlobalMembersExport.DIRECTORY_CSV);

		QDialog newParent;
		ok = selectSeparatorAndTextquote(parent, ref newParent, ref textquote, ref fieldSeparator, ref head);

		QString lastWarnings = new QString();
		if (!ok)
		{
			lastWarnings.insert(0,Export.tr("Export aborted") + "\n");
		}
		else
		{
			bool okat;
			bool okr;
			bool oks;
			bool okt;
			bool okst;
			bool okact;
			bool okacts;
			bool oktim;

			QMessageBox.StandardButton msgBoxButton = QMessageBox.NoButton;

//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: okat=exportCSVActivityTags(newParent, lastWarnings, textquote, head, setSeparator, msgBoxButton);
			okat = exportCSVActivityTags(newParent, ref lastWarnings, new QString(textquote), head, new QString(setSeparator), ref msgBoxButton);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: okr=exportCSVRoomsAndBuildings(newParent, lastWarnings, textquote, fieldSeparator, head, msgBoxButton);
			okr = exportCSVRoomsAndBuildings(newParent, ref lastWarnings, new QString(textquote), new QString(fieldSeparator), head, ref msgBoxButton);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: oks=exportCSVSubjects(newParent, lastWarnings, textquote, head, msgBoxButton);
			oks = exportCSVSubjects(newParent, ref lastWarnings, new QString(textquote), head, ref msgBoxButton);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: okt=exportCSVTeachers(newParent, lastWarnings, textquote, head, setSeparator, msgBoxButton);
			okt = exportCSVTeachers(newParent, ref lastWarnings, new QString(textquote), head, new QString(setSeparator), ref msgBoxButton);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: okst=exportCSVStudents(newParent, lastWarnings, textquote, fieldSeparator, head, setSeparator, msgBoxButton);
			okst = exportCSVStudents(newParent, ref lastWarnings, new QString(textquote), new QString(fieldSeparator), head, new QString(setSeparator), ref msgBoxButton);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: okact=exportCSVActivities(newParent, lastWarnings, textquote, fieldSeparator, head, msgBoxButton);
			okact = exportCSVActivities(newParent, ref lastWarnings, new QString(textquote), new QString(fieldSeparator), head, ref msgBoxButton);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: okacts=exportCSVActivitiesStatistic(newParent, lastWarnings, textquote, fieldSeparator, head, msgBoxButton);
			okacts = exportCSVActivitiesStatistic(newParent, ref lastWarnings, new QString(textquote), new QString(fieldSeparator), head, ref msgBoxButton);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: oktim=exportCSVTimetable(newParent, lastWarnings, textquote, fieldSeparator, head, msgBoxButton);
			oktim = exportCSVTimetable(newParent, ref lastWarnings, new QString(textquote), new QString(fieldSeparator), head, ref msgBoxButton);

			ok = okat && okr && oks && okt && okst && okact && okacts && oktim;

			lastWarnings.insert(0,Export.tr("CSV files were exported to directory %1.").arg(QDir.toNativeSeparators(GlobalMembersExport.DIRECTORY_CSV)) + "\n");
			if (ok)
				lastWarnings.insert(0,Export.tr("Exported complete") + "\n");
			else
				lastWarnings.insert(0,Export.tr("Export incomplete") + "\n");
		}

		LastWarningsDialogE lwd = new LastWarningsDialogE(newParent, lastWarnings);
		int w = lwd.sizeHint().width();
		int h = lwd.sizeHint().height();
		lwd.resize(w,h);
		centerWidgetOnScreen(lwd);

		ok = lwd.exec();
	}
	private static bool okToWrite(QWidget parent, QString file, ref QMessageBox.StandardButton msgBoxButton)
	{
		if (QFile.exists(file))
		{
			if (msgBoxButton == QMessageBox.YesToAll)
			{
				return true;
			}
			else if (msgBoxButton == QMessageBox.NoToAll)
			{
				return false;
			}
			else if (msgBoxButton == QMessageBox.No || msgBoxButton == QMessageBox.Yes || msgBoxButton == QMessageBox.NoButton)
			{

				QMessageBox msgBox = new QMessageBox(parent);
				msgBox.setWindowTitle(tr("FET warning"));
				msgBox.setIcon(QMessageBox.Warning);
				msgBox.setText(tr("File %1 exists - are you sure you want to overwrite existing file?").arg(file));
				msgBox.setStandardButtons(QMessageBox.Yes | QMessageBox.No | QMessageBox.YesToAll | QMessageBox.NoToAll);
				msgBox.setDefaultButton(QMessageBox.Yes);

				msgBoxButton = ((QMessageBox.StandardButton)(msgBox.exec()));

	/*			msgBoxButton=QMessageBox::warning(parent, tr("FET warning"),
				 tr("File %1 exists - are you sure you want to overwrite existing file?")
				 .arg(file),
				 QMessageBox::Yes|QMessageBox::No|QMessageBox::YesToAll|QMessageBox::NoToAll,
				 QMessageBox::Yes
				 );*/

				if (msgBoxButton == QMessageBox.No || msgBoxButton == QMessageBox.NoToAll)
					return false;
				else
					return true;
			}
			else
			{
				Debug.Assert(0);
				return false;
			}
		}
		else
			return true;
	}

	private static bool checkSetSeparator(QString str, QString setSeparator)
	{
		if (str.contains(setSeparator))
			return false;
		return true;
	}
	private static QString protectCSV(QString str)
	{
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: QString p=str;
		QString p = new QString(str);
		p.replace("\"", "\"\"");
		return p;
	}

	private static bool isActivityNotManualyEdited(int activityIndex, ref bool diffTeachers, ref bool diffSubject, ref bool diffActivityTags, ref bool diffStudents, ref bool diffCompNStud, ref bool diffNStud, ref bool diffActive)
	{
		diffTeachers = diffSubject = diffActivityTags = diffStudents = diffCompNStud = diffNStud = diffActive = false;

		Debug.Assert(activityIndex >= 0);
		Debug.Assert(activityIndex < gt.rules.activitiesList.size());

		Activity act = gt.rules.activitiesList[activityIndex];
		Debug.Assert(act != null);

		QStringList teachers = act.teachersNames;
		QString subject = act.subjectName;
		QStringList activityTags = act.activityTagsNames;
		QStringList students = act.studentsNames;

		int nTotalStudents = act.nTotalStudents;

		bool computeNTotalStudents = act.computeNTotalStudents;
		bool active = act.active;

		if (act.isSplit())
		{
			for (int i = activityIndex; i < gt.rules.activitiesList.size(); i++) //possible speed improvement: not i=0. do i=act->activityGroupId
			{
				Activity act2 = gt.rules.activitiesList[i]; //possible speed improvement: if(act2->activityGroupId changed) break;
				if (act2.activityGroupId != 0 && act2.activityGroupId == act.activityGroupId)
				{
					if (teachers != act2.teachersNames)
					{
						//return false;
						diffTeachers = true;
					}
					if (subject != act2.subjectName)
					{
						//return false;
						diffSubject = true;
					}
					if (activityTags != act2.activityTagsNames)
					{
						diffActivityTags = true;
						//return false;
					}
					if (students != act2.studentsNames)
					{
						diffStudents = true;
						//return false;
					}
					if (nTotalStudents != act2.nTotalStudents) // !computeNTotalStudents && !act2->computeNTotalStudents &&
					{
						diffNStud = true;
						//return false;
					}
					if (computeNTotalStudents != act2.computeNTotalStudents)
					{
						diffCompNStud = true;
						//return false;
					}
					if (active != act2.active)
					{
						diffActive = true;
						//return false;
					}
				}
				else
					i = gt.rules.activitiesList.size();
			}
		}
		if (!diffTeachers && !diffSubject && !diffActivityTags && !diffStudents && !diffCompNStud && !diffNStud && !diffActive)
			return true;
		else
			return false;
	}

	private static bool selectSeparatorAndTextquote(QWidget parent, ref QDialog newParent, ref QString textquote, ref QString fieldSeparator, ref bool head)
	{
		Debug.Assert(gt.rules.initialized);

		newParent = ((QDialog)parent);

		QStringList separators = new QStringList();
		QStringList textquotes = new QStringList();
		separators << "," << ";" << "|";
		//textquotes<<"\""<<"'"<<Export::tr("no textquote", "The translated field must contain at least 2 characters (normally it should), otherwise the export filter does not work");
		QString NO_TEXTQUOTE_TRANSLATED = Export.tr("no textquote", "Please use at least 2 characters for the translation of this field, so that the program works OK");
		textquotes << "\"" << "'" << NO_TEXTQUOTE_TRANSLATED;
		const int NO_TEXTQUOTE_POS = 2; //if you modify line above, modify also this variable to be the position of the no textquote (starts from 0)
		//also, if you add textquotes longer than one character, take care of line 309 (later in the same function) (assert textquote.size()==1)
		//it is permitted for position NO_TEXTQUOTE_POS to have a string longer than 1 QChar

		/*if(textquotes[2].size()<=1){
			QMessageBox::warning(parent, tr("FET warning"), tr("Translation is wrong, because translation of 'no textquote' is too short - falling back to English words. Please report bug"));
			textquote=QString("no textquote");
		}
		assert(textquotes[2].size()>1);*/

		QString settingsName = new QString("ExportSelectSeparatorsDialog");

		newParent = new QDialog(parent);
		QDialog separatorsDialog = (newParent);

		separatorsDialog.setWindowTitle(tr("FET question"));
		QVBoxLayout separatorsMainLayout = new QVBoxLayout(separatorsDialog);

		QHBoxLayout top = new QHBoxLayout();
		QLabel topText = new QLabel();
		topText.setText(Export.tr("Please keep the default settings.\nImport of data will be easier with these settings."));
		top.addWidget(topText);

		QGroupBox separatorsGroupBox = new QGroupBox(Export.tr("Please specify the separator between fields:"));
		QComboBox separatorsCB = null;
		if (separators.size() > 1)
		{
			QHBoxLayout separatorBoxChoose = new QHBoxLayout();
			separatorsCB = new QComboBox();

			QLabel separatorTextChoose = new QLabel();
			separatorTextChoose.setText(Export.tr("Use field separator:"));
			separatorsCB.insertItems(0,separators);
			separatorBoxChoose.addWidget(separatorTextChoose);
			separatorBoxChoose.addWidget(separatorsCB);
			separatorsGroupBox.setLayout(separatorBoxChoose);
		}

		QGroupBox textquoteGroupBox = new QGroupBox(Export.tr("Please specify the text quote of text fields:"));
		QComboBox textquoteCB = null;
		if (separators.size() > 1)
		{
			QHBoxLayout textquoteBoxChoose = new QHBoxLayout();
			textquoteCB = new QComboBox();

			QLabel textquoteTextChoose = new QLabel();
			textquoteTextChoose.setText(Export.tr("Use textquote:"));
			textquoteCB.insertItems(0,textquotes);
			textquoteBoxChoose.addWidget(textquoteTextChoose);
			textquoteBoxChoose.addWidget(textquoteCB);
			textquoteGroupBox.setLayout(textquoteBoxChoose);
		}

		QGroupBox firstLineGroupBox = new QGroupBox(Export.tr("Please specify the contents of the first line:"));
		QVBoxLayout firstLineChooseBox = new QVBoxLayout();
		QRadioButton firstLineRadio1 = new QRadioButton(Export.tr("The first line is the heading."));
		QRadioButton firstLineRadio2 = new QRadioButton(Export.tr("The first line contains data. Don't export heading."));
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
		separatorsMainLayout.addWidget(separatorsGroupBox);
		separatorsMainLayout.addWidget(textquoteGroupBox);

		separatorsMainLayout.addWidget(firstLineGroupBox);
		separatorsMainLayout.addLayout(hl);

		pb.setDefault(true);
		pb.setFocus();

		QObject.connect(pb, SIGNAL(clicked()), separatorsDialog, SLOT(accept()));
		QObject.connect(cancelpb, SIGNAL(clicked()), separatorsDialog, SLOT(reject()));

		int w = separatorsDialog.sizeHint().width();
		int h = separatorsDialog.sizeHint().height();
		separatorsDialog.resize(w,h);

		centerWidgetOnScreen(separatorsDialog);
		restoreFETDialogGeometry(separatorsDialog, settingsName);

		int ok = separatorsDialog.exec();
		saveFETDialogGeometry(separatorsDialog, settingsName);
		if (ok != QDialog.Accepted)
			return false;

		// TODO: if is always true. maybe clean source (also 2 previous if)
		if (separators.size() > 1)
		{
			Debug.Assert(separatorsCB != null);
			Debug.Assert(textquoteCB != null);
			fieldSeparator = separatorsCB.currentText();
			textquote = textquoteCB.currentText();
			if (textquoteCB.currentIndex() == NO_TEXTQUOTE_POS)
			{
				Debug.Assert(textquote == NO_TEXTQUOTE_TRANSLATED);
				textquote = new QString("no tquote"); //must have length >= 2
			}
			else
			{
				Debug.Assert(textquote.size() == 1);
				//assert(textquote=="\"" || textquote=="'");
			}
		}
		else
		{
			Debug.Assert(separatorsCB == null);
			Debug.Assert(textquoteCB == null);
			fieldSeparator = "";
			textquote = "";
		}

		if (textquote.size() != 1)
			textquote = "";

		if (firstLineRadio1.isChecked())
			head = true;
		else
			head = false;
		return true;
	}

	private static bool exportCSVActivities(QWidget parent, ref QString lastWarnings, QString textquote, QString fieldSeparator, bool head, ref QMessageBox.StandardButton msgBoxButton)
	{
		QString s2 = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1); //TODO: remove s2, because to long filenames!

		if (s2.right(4) == ".fet")
			s2 = s2.left(s2.length() - 4);
		//else if(INPUT_FILENAME_XML!="")
		//	cout<<"Minor problem - input file does not end in .fet extension - might be a problem when saving the timetables"<<" (file:"<<__FILE__<<", line:"<<__LINE__<<")"<<endl;

		QString UNDERSCORE = "_";
		if (INPUT_FILENAME_XML == "")
			UNDERSCORE = "";
		QString file = GlobalMembersExport.PREFIX_CSV + s2 + UNDERSCORE + GlobalMembersExport.CSVActivities;

		if (!Export.okToWrite(parent, file, ref msgBoxButton))
			return false;

		QFile fileExport = new QFile(file);
		if (!fileExport.open(QIODevice.WriteOnly))
		{
			lastWarnings += Export.tr("FET critical. Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(file) + "\n";
			return false;
			Debug.Assert(0);
		}
		QTextStream tosExport = new QTextStream(fileExport);
		tosExport.setCodec("UTF-8");
		tosExport.setGenerateByteOrderMark(true);

		if (head)
			tosExport << textquote << "Students Sets" << textquote << fieldSeparator << textquote << "Subject" << textquote << fieldSeparator << textquote << "Teachers" << textquote << fieldSeparator << textquote << "Activity Tags" << textquote << fieldSeparator << textquote << "Total Duration" << textquote << fieldSeparator << textquote << "Split Duration" << textquote << fieldSeparator << textquote << "Min Days" << textquote << fieldSeparator << textquote << "Weight" << textquote << fieldSeparator << textquote << "Consecutive" << textquote << "\n";

		//code by Liviu Lalescu (begin)
		//better detection of min day constraint
		QHash<int, int> activitiesRepresentant = new QHash<int, int>();
		QHash<int, int> activitiesNumberOfSubactivities = new QHash<int, int>();
		QHash<int, ConstraintMinDaysBetweenActivities> activitiesConstraints = new QHash<int, ConstraintMinDaysBetweenActivities>();

		activitiesRepresentant.clear();
		activitiesNumberOfSubactivities.clear();
		activitiesConstraints.clear();

		foreach (Activity * act, gt.rules.activitiesList)
		{
			Debug.Assert(!activitiesRepresentant.contains(act.id));
			activitiesRepresentant.insert(act.id, act.activityGroupId); //act->id is key, act->agid is value

			if (act.activityGroupId > 0)
			{
				int n = activitiesNumberOfSubactivities.value(act.activityGroupId, 0); //0 here means default value
				n++;
				activitiesNumberOfSubactivities.insert(act.activityGroupId, n); //overwrites old value
			}
		}
		foreach (TimeConstraint * tc, gt.rules.timeConstraintsList)
		{
			if (tc.type == GlobalMembersTimeconstraint.CONSTRAINT_MIN_DAYS_BETWEEN_ACTIVITIES && tc.active)
			{
				ConstraintMinDaysBetweenActivities c = (ConstraintMinDaysBetweenActivities) tc;

				QSet<int> aset = new QSet<int>();
				int repres = -1;

				for (int i = 0; i < c.n_activities; i++)
				{
					int aid = c.activitiesId[i];
					aset.insert(aid);

					if (activitiesRepresentant.value(aid,0) == aid)
						repres = aid; //does not matter if there are more representants in this constraint, the constraint will be skipped anyway in this case
				}

				bool oktmp = false;

				if (repres > 0)
				{
					if (aset.count() == activitiesNumberOfSubactivities.value(repres, 0))
					{
						oktmp = true;
						foreach (int aid, aset) if (activitiesRepresentant.value(aid, 0) != repres)
						{
								oktmp = false;
								break;
						}
					}
				}

				if (!oktmp)
				{
					lastWarnings += Export.tr("Note: Constraint") + " " + c.getDescription(gt.rules) + " " + tr("was skipped, because" + " it refers not to a whole larger container activity") + "\n";
				}

				if (oktmp)
				{
					ConstraintMinDaysBetweenActivities oldc = activitiesConstraints.value(repres, null);
					if (oldc != null)
					{
						if (oldc.weightPercentage < c.weightPercentage)
						{
							activitiesConstraints.insert(repres, c); //overwrites old value
							lastWarnings += Export.tr("Note: Constraint") + " " + oldc.getDescription(gt.rules) + " " + tr("was skipped, because" + " there exists another constraint of this type with larger weight percentage, referring to the same activities") + "\n";
						}
						else if (oldc.weightPercentage > c.weightPercentage)
						{
							lastWarnings += Export.tr("Note: Constraint") + " " + c.getDescription(gt.rules) + " " + tr("was skipped, because" + " there exists another constraint of this type with larger weight percentage, referring to the same activities") + "\n";
						}

						//equal weights - choose the lowest number of min days
						else if (oldc.minDays > c.minDays)
						{
							lastWarnings += Export.tr("Note: Constraint") + " " + c.getDescription(gt.rules) + " " + tr("was skipped, because" + " there exists another constraint of this type with same weight percentage and higher number of min days, referring to the same activities") + "\n";
						}
						else if (oldc.minDays < c.minDays)
						{
							activitiesConstraints.insert(repres, c); //overwrites old value
							lastWarnings += Export.tr("Note: Constraint") + " " + oldc.getDescription(gt.rules) + " " + tr("was skipped, because" + " there exists another constraint of this type with same weight percentage and higher number of min days, referring to the same activities") + "\n";
						}

						//equal weights and min days - choose the one with consecutive is same day true
						else if (oldc.consecutiveIfSameDay == true)
						{
							lastWarnings += Export.tr("Note: Constraint") + " " + c.getDescription(gt.rules) + " " + tr("was skipped, because" + " there exists another constraint of this type with same weight percentage and same number of min days and" + " consecutive if same day true, referring to the same activities") + "\n";
						}
						else if (c.consecutiveIfSameDay == true)
						{
							activitiesConstraints.insert(repres, c); //overwrites old value
							lastWarnings += Export.tr("Note: Constraint") + " " + oldc.getDescription(gt.rules) + " " + tr("was skipped, because" + " there exists another constraint of this type with same weight percentage and same number of min days and" + " consecutive if same day true, referring to the same activities") + "\n";
						}

					}
					else
						activitiesConstraints.insert(repres, c);
				}
			}
		}
		//code by Liviu Lalescu (end)

		bool manuallyEdited = false;

		Activity acti;
		Activity actiNext;
		int countExportedActivities = 0;
		for (int ai = 0; ai < gt.rules.activitiesList.size(); ai++)
		{
			acti = gt.rules.activitiesList[ai];
			//if(acti->active){
				if ((acti.activityGroupId == acti.id) || (acti.activityGroupId == 0))
				{
					bool diffTeachers;
					bool diffSubject;
					bool diffActivityTag;
					bool diffStudents;
					bool diffCompNStud;
					bool diffNStud;
					bool diffActive;
					if (isActivityNotManualyEdited(ai, ref diffTeachers, ref diffSubject, ref diffActivityTag, ref diffStudents, ref diffCompNStud, ref diffNStud, ref diffActive))
					{
					}
					else
					{
						QStringList s = new QStringList();
						if (diffTeachers)
							s.append(tr("different teachers"));
						if (diffSubject)
							s.append(tr("different subject"));
						if (diffActivityTag)
							s.append(tr("different activity tags"));
						if (diffStudents)
							s.append(tr("different students"));
						if (diffCompNStud)
							s.append(tr("different boolean variable 'must compute n total students'"));
						if (diffNStud)
							s.append(tr("different number of students"));
						if (diffActive)
							s.append(tr("different active flag"));

						manuallyEdited = true;

						lastWarnings += tr("Subactivities with activity group id %1 are different between themselves (they were separately edited)," + " so the export will not be very accurate. The fields which are different will be considered those of the representative subactivity. Fields which were" + " different are: %2").arg(CustomFETString.number(acti.activityGroupId)).arg(s.join(", ")) + "\n";
					}
					if (!acti.active)
					{
						if (acti.activityGroupId == 0)
							lastWarnings += tr("Activity with id %1 has disabled active flag but it is exported.").arg(CustomFETString.number(acti.id)) + "\n";
						else
							lastWarnings += tr("Subactivities with activity group id %1 have disabled active flag but they are exported.").arg(CustomFETString.number(acti.activityGroupId)) + "\n";
					}

					countExportedActivities++;
					//students set
					tosExport << textquote;
					for (int s = 0; s < acti.studentsNames.size(); s++)
					{
						if (s != 0)
							tosExport << "+";
						tosExport << protectCSV(acti.studentsNames[s]);
					}
					tosExport << textquote << fieldSeparator << textquote;
					//subject
					tosExport << protectCSV(acti.subjectName);
					tosExport << textquote << fieldSeparator << textquote;
					//teachers
					for (int t = 0; t < acti.teachersNames.size(); t++)
					{
						if (t != 0)
							tosExport << "+";
						tosExport << protectCSV(acti.teachersNames[t]);
					}
					tosExport << textquote << fieldSeparator << textquote;
					//activity tags
					for (int s = 0; s < acti.activityTagsNames.size(); s++)
					{
						if (s != 0)
							tosExport << "+";
						tosExport << protectCSV(acti.activityTagsNames[s]);
					}
					tosExport << textquote << fieldSeparator;
					//total duration
					tosExport << CustomFETString.number(acti.totalDuration);
					tosExport << fieldSeparator << textquote;
					//split duration
					for (int aiNext = ai; aiNext < gt.rules.activitiesList.size(); aiNext++)
					{
						actiNext = gt.rules.activitiesList[aiNext];
						if (acti.activityGroupId != 0 && actiNext.activityGroupId == acti.activityGroupId)
						{
							if (aiNext != ai)
								tosExport << "+";
							tosExport << actiNext.duration;
						}
						else
						{
							if (acti.activityGroupId == 0 && actiNext.activityGroupId == acti.activityGroupId)
							{
								Debug.Assert(ai == aiNext);
								Debug.Assert(actiNext.duration == actiNext.totalDuration);
								if (actiNext.duration > 1)
									tosExport << actiNext.duration;
							}
							aiNext = gt.rules.activitiesList.size();
						}
					}
					tosExport << textquote << fieldSeparator;
					//min days
					//start new code, because of Liviu's detection
					bool careAboutMinDay = false;
					ConstraintMinDaysBetweenActivities tcmd = activitiesConstraints.value(acti.id, null);
					if (acti.id == acti.activityGroupId)
					{
						if (tcmd != null)
						{
							careAboutMinDay = true;
						}
					}
					//end new code
					if (careAboutMinDay)
					{
						Debug.Assert(tcmd.type == GlobalMembersTimeconstraint.CONSTRAINT_MIN_DAYS_BETWEEN_ACTIVITIES);
						tosExport << CustomFETString.number(tcmd.minDays);
					}
					tosExport << fieldSeparator;
					//min days weight
					if (careAboutMinDay)
						tosExport << CustomFETString.number(tcmd.weightPercentage);
					tosExport << fieldSeparator;
					//min days consecutive
					if (careAboutMinDay)
						tosExport << tcmd.consecutiveIfSameDay;
					tosExport << "\n";
				}
			//}
		}

		if (manuallyEdited)
		{
			QMessageBox msgBox = new QMessageBox(parent);
			msgBox.setWindowTitle(tr("FET warning"));
			msgBox.setIcon(QMessageBox.Warning);
			msgBox.setText(tr("There are subactivities which were modified separately - so the " + "components had different values for subject, activity tags, teachers, students or number of students from the representative subactivity. The export was done, but it is not very accurate."));
			msgBox.setStandardButtons(QMessageBox.Ok);
			msgBox.setDefaultButton(QMessageBox.Ok);

			msgBox.exec();
		}

		lastWarnings += Export.tr("%1 activities exported.").arg(countExportedActivities) + "\n";
		if (fileExport.error() > 0)
		{
			lastWarnings += Export.tr("FET critical. Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(file).arg(fileExport.error()) + "\n";
			return false;
		}
		fileExport.close();
		return true;
	}
	private static bool exportCSVActivitiesStatistic(QWidget parent, ref QString lastWarnings, QString textquote, QString fieldSeparator, bool head, ref QMessageBox.StandardButton msgBoxButton)
	{
		QString s2 = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1); //TODO: remove s2, because to long filenames!

		if (s2.right(4) == ".fet")
			s2 = s2.left(s2.length() - 4);
		//else if(INPUT_FILENAME_XML!="")
		//	cout<<"Minor problem - input file does not end in .fet extension - might be a problem when saving the timetables"<<" (file:"<<__FILE__<<", line:"<<__LINE__<<")"<<endl;

		QString UNDERSCORE = "_";
		if (INPUT_FILENAME_XML == "")
			UNDERSCORE = "";
		QString file = GlobalMembersExport.PREFIX_CSV + s2 + UNDERSCORE + GlobalMembersExport.CSVActivitiesStatistic;

		if (!Export.okToWrite(parent, file, ref msgBoxButton))
			return false;

		QFile fileExport = new QFile(file);
		if (!fileExport.open(QIODevice.WriteOnly))
		{
			lastWarnings += Export.tr("FET critical. Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(file) + "\n";
			return false;
			Debug.Assert(0);
		}
		QTextStream tosExport = new QTextStream(fileExport);
		tosExport.setCodec("UTF-8");
		tosExport.setGenerateByteOrderMark(true);

		if (head)
			tosExport << textquote << "Students Sets" << textquote << fieldSeparator << textquote << "Subject" << textquote << fieldSeparator << textquote << "Teachers" << textquote << fieldSeparator << textquote << "Total Duration" << textquote << "\n";



		Activity acti;
		int countExportedActivities = 0;
		QMap<QString, int> tmpIdentDuration = new QMap<QString, int>(); //not QHash, because i want a nice order of the activities
		for (int ai = 0; ai < gt.rules.activitiesList.size(); ai++)
		{
			acti = gt.rules.activitiesList[ai];
			if (acti.active)
			{
				int tmpD = acti.duration;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: QString tmpIdent=textquote;
				QString tmpIdent = new QString(textquote);
				if (acti.studentsNames.size() > 0)
				{
					for (QStringList.Iterator it = acti.studentsNames.begin(); it != acti.studentsNames.end(); it++)
					{
						tmpIdent += protectCSV(*it);
						if (it != acti.studentsNames.end() - 1)
							tmpIdent += "+";
					}
				}
				tmpIdent += textquote + fieldSeparator + textquote + protectCSV(acti.subjectName) + textquote + fieldSeparator + textquote;
				if (acti.teachersNames.size() > 0)
				{
					for (QStringList.Iterator it = acti.teachersNames.begin(); it != acti.teachersNames.end(); it++)
					{
						tmpIdent += protectCSV(*it);
						if (it != acti.teachersNames.end() - 1)
							tmpIdent += "+";
					}
				}
				tmpIdent += textquote + fieldSeparator;
				tmpD += tmpIdentDuration.value(tmpIdent);
				tmpIdentDuration.insert(tmpIdent, tmpD);
			}
		}
		QMapIterator<QString, int> it = new QMapIterator<QString, int>(tmpIdentDuration);
		while (it.hasNext())
		{
			countExportedActivities++;
			it.next();
			tosExport << it.key();
			tosExport << textquote << CustomFETString.number(it.value()) << textquote << "\n";
		}

		lastWarnings += Export.tr("%1 active activities statistics exported.").arg(countExportedActivities) + "\n";
		if (fileExport.error() > 0)
		{
			lastWarnings += Export.tr("FET critical. Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(file).arg(fileExport.error()) + "\n";
			return false;
		}
		fileExport.close();
		return true;
	}
	private static bool exportCSVActivityTags(QWidget parent, ref QString lastWarnings, QString textquote, bool head, QString setSeparator, ref QMessageBox.StandardButton msgBoxButton)
	{
		QString s2 = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1); //TODO: remove s2, because to long filenames!

		if (s2.right(4) == ".fet")
			s2 = s2.left(s2.length() - 4);
		//else if(INPUT_FILENAME_XML!="")
		//	cout<<"Minor problem - input file does not end in .fet extension - might be a problem when saving the timetables"<<" (file:"<<__FILE__<<", line:"<<__LINE__<<")"<<endl;

		QString UNDERSCORE = "_";
		if (INPUT_FILENAME_XML == "")
			UNDERSCORE = "";
		QString file = GlobalMembersExport.PREFIX_CSV + s2 + UNDERSCORE + GlobalMembersExport.CSVActivityTags;

		if (!Export.okToWrite(parent, file, ref msgBoxButton))
			return false;

		QFile fileExport = new QFile(file);
		if (!fileExport.open(QIODevice.WriteOnly))
		{
			lastWarnings += Export.tr("FET critical. Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(file) + "\n";
			return false;
			Debug.Assert(0);
		}
		QTextStream tosExport = new QTextStream(fileExport);
		tosExport.setCodec("UTF-8");
		tosExport.setGenerateByteOrderMark(true);

		if (head)
			tosExport << textquote << "Activity Tag" << textquote << "\n";

		foreach (ActivityTag * a, gt.rules.activityTagsList)
		{
			tosExport << textquote << protectCSV(a.name) << textquote << "\n";
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: if(!checkSetSeparator(a->name, setSeparator))
			if (!checkSetSeparator(a.name, new QString(setSeparator)))
				lastWarnings += Export.tr("Warning! Import of activities will fail, because %1 include set separator +.").arg(a.name) + "\n";
		}

		lastWarnings += Export.tr("%1 activity tags exported.").arg(gt.rules.activityTagsList.size()) + "\n";
		if (fileExport.error() > 0)
		{
			lastWarnings += Export.tr("FET critical. Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(file).arg(fileExport.error() + "\n");
			return false;
		}
		fileExport.close();
		return true;
	}
	private static bool exportCSVRoomsAndBuildings(QWidget parent, ref QString lastWarnings, QString textquote, QString fieldSeparator, bool head, ref QMessageBox.StandardButton msgBoxButton)
	{
		QString s2 = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1); //TODO: remove s2, because to long filenames!

		if (s2.right(4) == ".fet")
			s2 = s2.left(s2.length() - 4);
		//else if(INPUT_FILENAME_XML!="")
		//	cout<<"Minor problem - input file does not end in .fet extension - might be a problem when saving the timetables"<<" (file:"<<__FILE__<<", line:"<<__LINE__<<")"<<endl;

		QString UNDERSCORE = "_";
		if (INPUT_FILENAME_XML == "")
			UNDERSCORE = "";
		QString file = GlobalMembersExport.PREFIX_CSV + s2 + UNDERSCORE + GlobalMembersExport.CSVRoomsAndBuildings;

		if (!Export.okToWrite(parent, file, ref msgBoxButton))
			return false;

		QFile fileExport = new QFile(file);
		if (!fileExport.open(QIODevice.WriteOnly))
		{
			lastWarnings += Export.tr("FET critical. Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(file) + "\n";
			return false;
			Debug.Assert(0);
		}
		QTextStream tosExport = new QTextStream(fileExport);
		tosExport.setCodec("UTF-8");
		tosExport.setGenerateByteOrderMark(true);

		if (head)
			tosExport << textquote << "Room" << textquote << fieldSeparator << textquote << "Room Capacity" << textquote << fieldSeparator << textquote << "Building" << textquote << "\n";

		QStringList checkBuildings = new QStringList();
		foreach (Room * r, gt.rules.roomsList)
		{
			tosExport << textquote << protectCSV(r.name) << textquote << fieldSeparator << CustomFETString.number(r.capacity) << fieldSeparator << textquote << protectCSV(r.building) << textquote << "\n";
			if (!checkBuildings.contains(r.building) && !r.building.isEmpty())
				checkBuildings << r.building;
		}

		lastWarnings += Export.tr("%1 rooms (with buildings) exported.").arg(gt.rules.roomsList.size()) + "\n";
		if (gt.rules.buildingsList.size() != checkBuildings.size())
		{
			lastWarnings += Export.tr("Warning! Only %1 of %2 building names are exported, because %3 buildings don't contain any room.").arg(checkBuildings.size()).arg(gt.rules.buildingsList.size()).arg(gt.rules.buildingsList.size() - checkBuildings.size()) + "\n";
		}

		if (fileExport.error() > 0)
		{
			lastWarnings += Export.tr("FET critical. Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(file).arg(fileExport.error() + "\n");
			return false;
		}
		fileExport.close();
		return true;
	}
	private static bool exportCSVSubjects(QWidget parent, ref QString lastWarnings, QString textquote, bool head, ref QMessageBox.StandardButton msgBoxButton)
	{
		QString s2 = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1); //TODO: remove s2, because to long filenames!

		if (s2.right(4) == ".fet")
			s2 = s2.left(s2.length() - 4);
		//else if(INPUT_FILENAME_XML!="")
		//	cout<<"Minor problem - input file does not end in .fet extension - might be a problem when saving the timetables"<<" (file:"<<__FILE__<<", line:"<<__LINE__<<")"<<endl;

		QString UNDERSCORE = "_";
		if (INPUT_FILENAME_XML == "")
			UNDERSCORE = "";
		QString file = GlobalMembersExport.PREFIX_CSV + s2 + UNDERSCORE + GlobalMembersExport.CSVSubjects;

		if (!Export.okToWrite(parent, file, ref msgBoxButton))
			return false;

		QFile fileExport = new QFile(file);
		if (!fileExport.open(QIODevice.WriteOnly))
		{
			lastWarnings += Export.tr("FET critical. Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(file) + "\n";
			return false;
			Debug.Assert(0);
		}
		QTextStream tosExport = new QTextStream(fileExport);
		tosExport.setCodec("UTF-8");
		tosExport.setGenerateByteOrderMark(true);

		if (head)
			tosExport << textquote << "Subject" << textquote << "\n";

		foreach (Subject * s, gt.rules.subjectsList)
		{
			tosExport << textquote << protectCSV(s.name) << textquote << "\n";
		}

		lastWarnings += Export.tr("%1 subjects exported.").arg(gt.rules.subjectsList.size()) + "\n";
		if (fileExport.error() > 0)
		{
			lastWarnings += Export.tr("FET critical. Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(file).arg(fileExport.error() + "\n");
			return false;
		}
		fileExport.close();
		return true;
	}
	private static bool exportCSVTeachers(QWidget parent, ref QString lastWarnings, QString textquote, bool head, QString setSeparator, ref QMessageBox.StandardButton msgBoxButton)
	{
		QString s2 = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1); //TODO: remove s2, because to long filenames!

		if (s2.right(4) == ".fet")
			s2 = s2.left(s2.length() - 4);
		//else if(INPUT_FILENAME_XML!="")
		//	cout<<"Minor problem - input file does not end in .fet extension - might be a problem when saving the timetables"<<" (file:"<<__FILE__<<", line:"<<__LINE__<<")"<<endl;

		QString UNDERSCORE = "_";
		if (INPUT_FILENAME_XML == "")
			UNDERSCORE = "";
		QString file = GlobalMembersExport.PREFIX_CSV + s2 + UNDERSCORE + GlobalMembersExport.CSVTeachers;

		if (!Export.okToWrite(parent, file, ref msgBoxButton))
			return false;

		QFile fileExport = new QFile(file);
		if (!fileExport.open(QIODevice.WriteOnly))
		{
			lastWarnings += Export.tr("FET critical. Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(file) + "\n";
			return false;
			Debug.Assert(0);
		}
		QTextStream tosExport = new QTextStream(fileExport);
		tosExport.setCodec("UTF-8");
		tosExport.setGenerateByteOrderMark(true);

		if (head)
			tosExport << textquote << "Teacher" << textquote << "\n";

		foreach (Teacher * t, gt.rules.teachersList)
		{
			tosExport << textquote << protectCSV(t.name) << textquote << "\n";
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: if(!checkSetSeparator(t->name, setSeparator))
			if (!checkSetSeparator(t.name, new QString(setSeparator)))
				lastWarnings += Export.tr("Warning! Import of activities will fail, because %1 include set separator +.").arg(t.name) + "\n";
		}

		lastWarnings += Export.tr("%1 teachers exported.").arg(gt.rules.teachersList.size()) + "\n";
		if (fileExport.error() > 0)
		{
			lastWarnings += Export.tr("FET critical. Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(file).arg(fileExport.error() + "\n");
			return false;
		}
		fileExport.close();
		return true;
	}
	private static bool exportCSVStudents(QWidget parent, ref QString lastWarnings, QString textquote, QString fieldSeparator, bool head, QString setSeparator, ref QMessageBox.StandardButton msgBoxButton)
	{
		QString s2 = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1); //TODO: remove s2, because to long filenames!

		if (s2.right(4) == ".fet")
			s2 = s2.left(s2.length() - 4);
		//else if(INPUT_FILENAME_XML!="")
		//	cout<<"Minor problem - input file does not end in .fet extension - might be a problem when saving the timetables"<<" (file:"<<__FILE__<<", line:"<<__LINE__<<")"<<endl;

		QString UNDERSCORE = "_";
		if (INPUT_FILENAME_XML == "")
			UNDERSCORE = "";
		QString file = GlobalMembersExport.PREFIX_CSV + s2 + UNDERSCORE + GlobalMembersExport.CSVStudents;

		if (!Export.okToWrite(parent, file, ref msgBoxButton))
			return false;

		QFile fileExport = new QFile(file);
		if (!fileExport.open(QIODevice.WriteOnly))
		{
			lastWarnings += Export.tr("FET critical. Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(file) + "\n";
			return false;
			Debug.Assert(0);
		}
		QTextStream tosExport = new QTextStream(fileExport);
		tosExport.setCodec("UTF-8");
		tosExport.setGenerateByteOrderMark(true);

		if (head)
			tosExport << textquote << "Year" << textquote << fieldSeparator << textquote << "Number of Students per Year" << textquote << fieldSeparator << textquote << "Group" << textquote << fieldSeparator << textquote << "Number of Students per Group" << textquote << fieldSeparator << textquote << "Subgroup" << textquote << fieldSeparator << textquote << "Number of Students per Subgroup" << textquote << "\n";

		int ig = 0;
		int @is = 0;
		foreach (StudentsYear * sty, gt.rules.yearsList)
		{
			tosExport << textquote << protectCSV(sty.name) << textquote << fieldSeparator << CustomFETString.number(sty.numberOfStudents) << fieldSeparator << fieldSeparator << fieldSeparator << fieldSeparator << "\n";
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: if(!checkSetSeparator(sty->name, setSeparator))
			if (!checkSetSeparator(sty.name, new QString(setSeparator)))
				lastWarnings += Export.tr("Warning! Import of activities will fail, because %1 include set separator +.").arg(sty.name) + "\n";
			foreach (StudentsGroup * stg, sty.groupsList)
			{
				ig++;
				tosExport << textquote << protectCSV(sty.name) << textquote << fieldSeparator << CustomFETString.number(sty.numberOfStudents) << fieldSeparator << textquote << protectCSV(stg.name) << textquote << fieldSeparator << CustomFETString.number(stg.numberOfStudents) << fieldSeparator << fieldSeparator << "\n";
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: if(!checkSetSeparator(stg->name, setSeparator))
				if (!checkSetSeparator(stg.name, new QString(setSeparator)))
					lastWarnings += Export.tr("Warning! Import of activities will fail, because %1 include set separator +.").arg(stg.name) + "\n";
				foreach (StudentsSubgroup * sts, stg.subgroupsList)
				{
					@is++;
					tosExport << textquote << protectCSV(sty.name) << textquote << fieldSeparator << CustomFETString.number(sty.numberOfStudents) << fieldSeparator << textquote << protectCSV(stg.name) << textquote << fieldSeparator << CustomFETString.number(stg.numberOfStudents) << fieldSeparator << textquote << protectCSV(sts.name) << textquote << fieldSeparator << CustomFETString.number(sts.numberOfStudents) << "\n";
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: if(!checkSetSeparator(sts->name, setSeparator))
					if (!checkSetSeparator(sts.name, new QString(setSeparator)))
						lastWarnings += Export.tr("Warning! Import of activities will fail, because %1 include set separator +.").arg(sts.name) + "\n";
				}
			}
		}

		lastWarnings += Export.tr("%1 years exported.").arg(gt.rules.yearsList.size()) + "\n";
		lastWarnings += Export.tr("%1 groups exported.").arg(ig) + "\n";
		lastWarnings += Export.tr("%1 subgroups exported.").arg(@is) + "\n";
		if (fileExport.error() > 0)
		{
			lastWarnings += Export.tr("FET critical. Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(file).arg(fileExport.error() + "\n");
			return false;
		}
		fileExport.close();
		return true;
	}
	private static bool exportCSVTimetable(QWidget parent, ref QString lastWarnings, QString textquote, QString fieldSeparator, bool head, ref QMessageBox.StandardButton msgBoxButton)
	{
		QString s2 = INPUT_FILENAME_XML.right(INPUT_FILENAME_XML.length() - INPUT_FILENAME_XML.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1); //TODO: remove s2, because to long filenames!

		if (s2.right(4) == ".fet")
			s2 = s2.left(s2.length() - 4);
		//else if(INPUT_FILENAME_XML!="")
		//	cout<<"Minor problem - input file does not end in .fet extension - might be a problem when saving the timetables"<<" (file:"<<__FILE__<<", line:"<<__LINE__<<")"<<endl;

		QString UNDERSCORE = "_";
		if (INPUT_FILENAME_XML == "")
			UNDERSCORE = "";
		QString file = GlobalMembersExport.PREFIX_CSV + s2 + UNDERSCORE + GlobalMembersExport.CSVTimetable;

		if (!Export.okToWrite(parent, file, ref msgBoxButton))
			return false;

		QFile fileExport = new QFile(file);
		if (!fileExport.open(QIODevice.WriteOnly))
		{
			lastWarnings += Export.tr("FET critical. Cannot open file %1 for writing. Please check your disk's free space. Saving of %1 aborted.").arg(file) + "\n";
			return false;
			Debug.Assert(0);
		}
		QTextStream tosExport = new QTextStream(fileExport);
		tosExport.setCodec("UTF-8");
		tosExport.setGenerateByteOrderMark(true);

		//section "Activity Id" was added by Liviu Lalescu on 2010-01-26, as suggested on the forum
		if (head)
			tosExport << textquote << "Activity Id" << textquote << fieldSeparator << textquote << "Day" << textquote << fieldSeparator << textquote << "Hour" << textquote << fieldSeparator << textquote << "Students Sets" << textquote << fieldSeparator << textquote << "Subject" << textquote << fieldSeparator << textquote << "Teachers" << textquote << fieldSeparator << textquote << "Activity Tags" << textquote << fieldSeparator << textquote << "Room" << textquote << fieldSeparator << textquote << "Comments" << textquote << "\n";

		if (gt.rules.initialized && gt.rules.internalStructureComputed && students_schedule_ready && teachers_schedule_ready && rooms_schedule_ready)
		{
			Activity act;
			int exportedActivities = 0;
			for (int i = 0; i < gt.rules.nInternalActivities; i++)
			{
				if (best_solution.times[i] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				{
					exportedActivities++;
					act = gt.rules.internalActivitiesList[i];
					int hour = best_solution.times[i] / gt.rules.nDaysPerWeek;
					int day = best_solution.times[i] % gt.rules.nDaysPerWeek;
					int r = best_solution.rooms[i];
					for (int dd = 0; dd < act.duration; dd++)
					{
						Debug.Assert(hour + dd < gt.rules.nHoursPerDay);

						//Activity id - added by Liviu on 2010-01-26
						tosExport << textquote << CustomFETString.number(act.id) << textquote << fieldSeparator;

						//Day
						tosExport << textquote << protectCSV(gt.rules.daysOfTheWeek[day]) << textquote << fieldSeparator;
						//Period
						tosExport << textquote << protectCSV(gt.rules.hoursOfTheDay[hour + dd]) << textquote << fieldSeparator << textquote;
						//Students Sets
						for (int s = 0; s < act.studentsNames.size(); s++)
						{
							if (s != 0)
								tosExport << "+";
							tosExport << protectCSV(act.studentsNames[s]);
						}
						tosExport << textquote << fieldSeparator << textquote;
						//Subject
						tosExport << protectCSV(act.subjectName);
						tosExport << textquote << fieldSeparator << textquote;
						//Teachers
						for (int t = 0; t < act.teachersNames.size(); t++)
						{
							if (t != 0)
								tosExport << "+";
							tosExport << protectCSV(act.teachersNames[t]);
						}
						tosExport << textquote << fieldSeparator << textquote;
						//Activity Tags
						for (int s = 0; s < act.activityTagsNames.size(); s++)
						{
							if (s != 0)
								tosExport << "+";
							tosExport << protectCSV(act.activityTagsNames[s]);
						}
						tosExport << textquote << fieldSeparator << textquote;
						//Room
						if (best_solution.rooms[i] != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM && best_solution.rooms[i] != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
						{
							Debug.Assert(best_solution.rooms[i] >= 0 && best_solution.rooms[i] < gt.rules.nInternalRooms);
							tosExport << protectCSV(gt.rules.internalRoomsList[r].name);
						}
						tosExport << textquote << fieldSeparator << textquote;
						//Comments
						QString tmpString = protectCSV(act.comments);
						tmpString.replace("\n", " ");
						tosExport << tmpString << textquote << "\n";
					}
				}
			}
			lastWarnings += Export.tr("%1 scheduled activities exported.").arg(exportedActivities) + "\n";
		}
		else
		{
			lastWarnings += Export.tr("0 scheduled activities exported, because no timetable was generated.") + "\n";
		}
		if (fileExport.error() > 0)
		{
			lastWarnings += Export.tr("FET critical. Writing %1 gave error code %2, which means saving is compromised. Please check your disk's free space.").arg(file).arg(fileExport.error()) + "\n";
			return false;
		}
		fileExport.close();
		return true;
	}
}

public partial class LastWarningsDialogE: QDialog
{
	Q_OBJECT public: LastWarningsDialogE(QWidget * parent, QString lastWarning); //can i do that privat too?
	public void Dispose()
	{
	}
}

//C++ TO C# CONVERTER WARNING: The declaration of the following method implementation was not found:
//ORIGINAL LINE: Export::Export()



//C++ TO C# CONVERTER WARNING: The declaration of the following method implementation was not found:
//ORIGINAL LINE: LastWarningsDialogE::LastWarningsDialogE(QWidget* parent, QString lastWarning): QDialog(parent)


public partial class Export
{
	public Export()
	{
	}
}

public partial class LastWarningsDialogE
{
	public LastWarningsDialogE(QWidget parent, QString lastWarning)
	{
		QDialog = parent;
		this.setWindowTitle(tr("FET - export comment", "The comment of the exporting operation"));
		QVBoxLayout lastWarningsMainLayout = new QVBoxLayout(this);
    
		QPlainTextEdit lastWarningsText = new QPlainTextEdit();
		lastWarningsText.setMinimumWidth(500); //width
		lastWarningsText.setMinimumHeight(250);
		lastWarningsText.setReadOnly(true);
		lastWarningsText.setWordWrapMode(QTextOption.NoWrap);
		lastWarningsText.setPlainText(lastWarning);
    
		//Start Buttons
		QPushButton pb1 = new QPushButton(tr("&Ok"));
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