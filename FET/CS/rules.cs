using System.Diagnostics;
using System;

public static class GlobalMembersRules
{












	//#include <QApplication>
	#if ! FET_COMMAND_LINE
	#endif


	#if ! FET_COMMAND_LINE
	#else
	#endif
	#if FET_COMMAND_LINE
	#else
	#endif
	#if FET_COMMAND_LINE
	#endif



	//static bool toSkipTime[MAX_TIME_CONSTRAINTS];
	//static bool toSkipSpace[MAX_SPACE_CONSTRAINTS];

	//extern QApplication* pqapplication;

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern bool students_schedule_ready;
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern bool rooms_schedule_ready;
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern bool teachers_schedule_ready;
}

/*
File rules.cpp
*/

/*
Copyright 2002, 2003 Lalescu Liviu.

This file is part of FET.

FET is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

FET is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with FET; if not, write to the Free Software
Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
*/

#if NDEBUG
#endif
/*
File rules.h

Copyright 2002-2003 Lalescu Liviu.

This file is part of FET.

FET is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

FET is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with FET; if not, write to the Free Software
Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
*/







//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class QWidget;

public class FakeString
/*
fake string, so that the output log is not too large
*/
{
	public FakeString()
	{
	}

//C++ TO C# CONVERTER NOTE: This 'CopyFrom' method was converted from the original C++ copy assignment operator:
//ORIGINAL LINE: void operator =(const QString& other)
	public void CopyFrom(QString other)
	{
		Q_UNUSED(other);
	}
//C++ TO C# CONVERTER NOTE: This 'CopyFrom' method was converted from the original C++ copy assignment operator:
//ORIGINAL LINE: void operator =(string str)
	public void CopyFrom(string str)
	{
		Q_UNUSED(str);
	}
//C++ TO C# CONVERTER TODO TASK: The += operator cannot be overloaded in C#:
	public static void operator += (QString other)
	{
		Q_UNUSED(other);
	}
//C++ TO C# CONVERTER TODO TASK: The += operator cannot be overloaded in C#:
	public static void operator += (string str)
	{
		Q_UNUSED(str);
	}
}

//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class QDomElement;

/**
This class contains all the information regarding
the institution: teachers, students, activities, constraints, etc.
*/
public class Rules
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(Rules) public: bool modified;

	/**
	The name of the institution
	*/
	private QString institutionName = new QString();

	/**
	The comments
	*/
	private QString comments = new QString();

	/**
	The number of hours per day
	*/
	private int nHoursPerDay;

	/**
	The number of days per week
	*/
	private int nDaysPerWeek;

	/**
	The days of the week (names)
	*/
	private QString[] daysOfTheWeek = new QString[MAX_DAYS_PER_WEEK];

	/**
	The hours of the day (names). This includes also the last hour (+1)
	*/
	private QString[] hoursOfTheDay = new QString[MAX_HOURS_PER_DAY + 1];

	/**
	The number of hours per week
	*/
	private int nHoursPerWeek;

	/**
	The list of teachers
	*/
	private QList<Teacher> teachersList = new QList<Teacher>();

	/**
	The list of subjects
	*/
	private QList<Subject> subjectsList = new QList<Subject>();

	/**
	The list of activity tags
	*/
	private QList<ActivityTag> activityTagsList = new QList<ActivityTag>();

	/**
	The list of students (groups and subgroups included).
	Remember that every identifier (year, group or subgroup) must be UNIQUE.
	*/
	private QList<StudentsYear> yearsList = new QList<StudentsYear>();

	/**
	The list of activities
	*/
	private QList<Activity> activitiesList = new QList<Activity>();

	/**
	The list of rooms
	*/
	private QList<Room> roomsList = new QList<Room>();

	/**
	The list of buildings
	*/
	private QList<Building> buildingsList = new QList<Building>();

	/**
	The list of time constraints
	*/
	private QList<TimeConstraint> timeConstraintsList = new QList<TimeConstraint>();

	/**
	The list of space constraints
	*/
	private QList<SpaceConstraint> spaceConstraintsList = new QList<SpaceConstraint>();

	/*
	The following variables contain redundant data and are used internally
	*/
	////////////////////////////////////////////////////////////////////////
	private int nInternalTeachers;
	private Matrix1D<Teacher> internalTeachersList = new Matrix1D<Teacher>();

	private int nInternalSubjects;
	private Matrix1D<Subject> internalSubjectsList = new Matrix1D<Subject>();

	private int nInternalActivityTags;
	private Matrix1D<ActivityTag> internalActivityTagsList = new Matrix1D<ActivityTag>();

	private int nInternalSubgroups;
	private Matrix1D<StudentsSubgroup> internalSubgroupsList = new Matrix1D<StudentsSubgroup>();

	private QList<StudentsGroup> internalGroupsList = new QList<StudentsGroup>();

	private QList<StudentsYear> augmentedYearsList = new QList<StudentsYear>();

	/**
	Here will be only the active activities.
	
	For speed, I used here not pointers, but static copies.
	*/
	private int nInternalActivities;
	private Matrix1D<Activity> internalActivitiesList = new Matrix1D<Activity>();

	private QSet<int> inactiveActivities = new QSet<int>();

	private Matrix1D<QList<int>> activitiesForSubject = new Matrix1D<QList<int>>();

	private int nInternalRooms;
	private Matrix1D<Room> internalRoomsList = new Matrix1D<Room>();

	private int nInternalBuildings;
	private Matrix1D<Building> internalBuildingsList = new Matrix1D<Building>();

	private int nInternalTimeConstraints;
	private Matrix1D<TimeConstraint> internalTimeConstraintsList = new Matrix1D<TimeConstraint>();

	private int nInternalSpaceConstraints;
	private Matrix1D<SpaceConstraint> internalSpaceConstraintsList = new Matrix1D<SpaceConstraint>();

	/*
	///////////////////////////////////////////////////////////////////////
	*/

	/**
	True if the rules have been initialized in some way (new or loaded).
	*/
	private bool initialized;

	/**
	True if the internal structure was computed.
	*/
	private bool internalStructureComputed;

	/**
	Initializes the rules (empty)
	*/
	private void init()
	{
		//defaults
		this.nHoursPerDay = 12;
		this.hoursOfTheDay[0] = "08:00";
		this.hoursOfTheDay[1] = "09:00";
		this.hoursOfTheDay[2] = "10:00";
		this.hoursOfTheDay[3] = "11:00";
		this.hoursOfTheDay[4] = "12:00";
		this.hoursOfTheDay[5] = "13:00";
		this.hoursOfTheDay[6] = "14:00";
		this.hoursOfTheDay[7] = "15:00";
		this.hoursOfTheDay[8] = "16:00";
		this.hoursOfTheDay[9] = "17:00";
		this.hoursOfTheDay[10] = "18:00";
		this.hoursOfTheDay[11] = "19:00";
		this.hoursOfTheDay[12] = "20:00";

		this.nDaysPerWeek = 5;
		this.daysOfTheWeek[0] = tr("Monday");
		this.daysOfTheWeek[1] = tr("Tuesday");
		this.daysOfTheWeek[2] = tr("Wednesday");
		this.daysOfTheWeek[3] = tr("Thursday");
		this.daysOfTheWeek[4] = tr("Friday");

		this.institutionName = tr("Default institution");
		this.comments = tr("Default comments");

		this.initialized = true;
	}

	/**
	Internal structure initializer.
	<p>
	After any modification of the activities or students or teachers
	or constraints, you need to call this subroutine
	*/
	private bool computeInternalStructure(QWidget parent)
	{
		//To fix a bug reported by Frans on forum, on 7 May 2010.
		//If user generates, then changes some activities (changes teachers of them), then tries to generate but FET cannot precompute in generate_pre.cpp,
		//then if user views the timetable, the timetable of a teacher contains activities of other teacher.
		//The bug appeared because it is possible to compute internal structure, so internal activities change the teacher, but the timetables remain the same,
		//with the same activities indexes.
		teachers_schedule_ready = false;
		students_schedule_ready = false;
		rooms_schedule_ready = false;

		//The order is important - firstly the teachers, subjects, activity tags and students.
		//After that, the buildings.
		//After that, the rooms.
		//After that, the activities.
		//After that, the time constraints.
		//After that, the space constraints.

		if (this.teachersList.size() > GlobalMembersTimetable_defs.MAX_TEACHERS)
		{
			RulesImpossible.warning(parent, tr("FET information"), tr("You have too many teachers. You need to increase the variable MAX_TEACHERS (which is currently %1).").arg(GlobalMembersTimetable_defs.MAX_TEACHERS));
			return false;
		}

		//kill augmented students sets
		QList<StudentsYear> ayears = new QList<StudentsYear>();
		QList<StudentsGroup> agroups = new QList<StudentsGroup>();
		QList<StudentsSubgroup> asubgroups = new QList<StudentsSubgroup>();
		foreach (StudentsYear * year, augmentedYearsList)
		{
			if (!ayears.contains(year))
				ayears.append(year);
			foreach (StudentsGroup * group, year.groupsList)
			{
				if (!agroups.contains(group))
					agroups.append(group);
				foreach (StudentsSubgroup * subgroup, group.subgroupsList)
				{
					if (!asubgroups.contains(subgroup))
						asubgroups.append(subgroup);
				}
			}
		}
		foreach (StudentsYear * year, ayears)
		{
			Debug.Assert(year != null);
			year = null;
		}
		foreach (StudentsGroup * group, agroups)
		{
			Debug.Assert(group != null);
			group = null;
		}
		foreach (StudentsSubgroup * subgroup, asubgroups)
		{
			Debug.Assert(subgroup != null);
			subgroup = null;
		}
		augmentedYearsList.clear();
		//////////////////

		//copy list of students sets into augmented list
		QHash<QString, StudentsSet> augmentedHash = new QHash<QString, StudentsSet>();

		foreach (StudentsYear * y, yearsList)
		{
			StudentsYear ay = new StudentsYear();
			ay.name = y.name;
			ay.numberOfStudents = y.numberOfStudents;
			ay.groupsList.clear();
			augmentedYearsList << ay;

			Debug.Assert(!augmentedHash.contains(ay.name));
			augmentedHash.insert(ay.name, ay);

			foreach (StudentsGroup * g, y.groupsList)
			{
				if (augmentedHash.contains(g.name))
				{
					StudentsSet tmpg = augmentedHash.value(g.name);
					Debug.Assert(tmpg.type == GlobalMembersStudentsset.STUDENTS_GROUP);
					ay.groupsList << ((StudentsGroup)tmpg);
				}
				else
				{
					StudentsGroup ag = new StudentsGroup();
					ag.name = g.name;
					ag.numberOfStudents = g.numberOfStudents;
					ag.subgroupsList.clear();
					ay.groupsList << ag;

					Debug.Assert(!augmentedHash.contains(ag.name));
					augmentedHash.insert(ag.name, ag);

					foreach (StudentsSubgroup * s, g.subgroupsList)
					{
						if (augmentedHash.contains(s.name))
						{
							StudentsSet tmps = augmentedHash.value(s.name);
							Debug.Assert(tmps.type == GlobalMembersStudentsset.STUDENTS_SUBGROUP);
							ag.subgroupsList << ((StudentsSubgroup)tmps);
						}
						else
						{
							StudentsSubgroup @as = new StudentsSubgroup();
							@as.name = s.name;
							@as.numberOfStudents = s.numberOfStudents;
							ag.subgroupsList << @as;

							Debug.Assert(!augmentedHash.contains(@as.name));
							augmentedHash.insert(@as.name, @as);
						}
					}
				}
			}
		}

		/////////
		for (int i = 0; i < this.augmentedYearsList.size(); i++)
		{
			StudentsYear sty = this.augmentedYearsList[i];

			//if this year has no groups, insert something to simulate the whole year
			if (sty.groupsList.count() == 0)
			{
				StudentsGroup tmpGroup = new StudentsGroup();
				tmpGroup.name = sty.name + " " + tr("Automatic Group", "Please keep the translation short. It is used when a year contains no groups and an automatic group " + "is added in the year, in the timetable (when viewing the students timetable from FET and also in the html timetables for students groups or subgroups)" + ". In the empty year there will be added a group with name = yearName+a space character+your translation of 'Automatic Group'.");
				tmpGroup.numberOfStudents = sty.numberOfStudents;
				sty.groupsList << tmpGroup;
			}

			for (int j = 0; j < sty.groupsList.size(); j++)
			{
				StudentsGroup stg = sty.groupsList[j];

				//if this group has no subgroups, insert something to simulate the whole group
				if (stg.subgroupsList.size() == 0)
				{
					StudentsSubgroup tmpSubgroup = new StudentsSubgroup();
					tmpSubgroup.name = stg.name + " " + tr("Automatic Subgroup", "Please keep the translation short. It is used when a group contains no subgroups and an automatic subgroup " + "is added in the group, in the timetable (when viewing the students timetable from FET and also in the html timetables for students subgroups)" + ". In the empty group there will be added a subgroup with name = groupName+a space character+your translation of 'Automatic Subgroup'.");
					tmpSubgroup.numberOfStudents = stg.numberOfStudents;
					stg.subgroupsList << tmpSubgroup;
				}
			}
		}
		//////////

		QSet<StudentsGroup> allGroupsSet = new QSet<StudentsGroup>();
		QSet<StudentsSubgroup> allSubgroupsSet = new QSet<StudentsSubgroup>();
		QList<StudentsGroup> allGroupsList = new QList<StudentsGroup>();
		QList<StudentsSubgroup> allSubgroupsList = new QList<StudentsSubgroup>();

		for (int i = 0; i < this.augmentedYearsList.size(); i++)
		{
			StudentsYear sty = this.augmentedYearsList.at(i);
			sty.indexInAugmentedYearsList = i;

			for (int j = 0; j < sty.groupsList.size(); j++)
			{
				StudentsGroup stg = sty.groupsList.at(j);
				if (!allGroupsSet.contains(stg))
				{
					allGroupsSet.insert(stg);
					allGroupsList.append(stg);
					stg.indexInInternalGroupsList = allGroupsSet.count() - 1;
				}

				for (int k = 0; k < stg.subgroupsList.size(); k++)
					if (!allSubgroupsSet.contains(stg.subgroupsList.at(k)))
					{
						allSubgroupsSet.insert(stg.subgroupsList.at(k));
						allSubgroupsList.append(stg.subgroupsList.at(k));
						stg.subgroupsList.at(k).indexInInternalSubgroupsList = allSubgroupsSet.count() - 1;
					}
			}
		}
		int tmpNSubgroups = allSubgroupsList.count();
		if (tmpNSubgroups > GlobalMembersTimetable_defs.MAX_TOTAL_SUBGROUPS)
		{
			RulesImpossible.warning(parent, tr("FET information"), tr("You have too many total subgroups. You need to increase the variable MAX_TOTAL_SUBGROUPS (which is currently %1).").arg(GlobalMembersTimetable_defs.MAX_TOTAL_SUBGROUPS));
			return false;
		}
		this.internalSubgroupsList.resize(tmpNSubgroups);

		int counter = 0;
		for (int i = 0; i < this.activitiesList.size(); i++)
		{
			Activity act = this.activitiesList.at(i);
			if (act.active)
				counter++;
		}
		if (counter > GlobalMembersTimetable_defs.MAX_ACTIVITIES)
		{
			RulesImpossible.warning(parent, tr("FET information"), tr("You have too many active activities. You need to increase the variable MAX_ACTIVITIES (which is currently %1).").arg(GlobalMembersTimetable_defs.MAX_ACTIVITIES));
			return false;
		}

		if (this.buildingsList.size() > GlobalMembersTimetable_defs.MAX_BUILDINGS)
		{
			RulesImpossible.warning(parent, tr("FET information"), tr("You have too many buildings. You need to increase the variable MAX_BUILDINGS (which is currently %1).").arg(GlobalMembersTimetable_defs.MAX_BUILDINGS));
			return false;
		}

		if (this.roomsList.size() > GlobalMembersTimetable_defs.MAX_ROOMS)
		{
			RulesImpossible.warning(parent, tr("FET information"), tr("You have too many rooms. You need to increase the variable MAX_ROOMS (which is currently %1).").arg(GlobalMembersTimetable_defs.MAX_ROOMS));
			return false;
		}

		Debug.Assert(this.initialized);

		//days and hours
		Debug.Assert(this.nHoursPerDay > 0);
		Debug.Assert(this.nDaysPerWeek > 0);
		this.nHoursPerWeek = this.nHoursPerDay this.nDaysPerWeek;

		//teachers
		int i;
		Teacher tch;
		this.nInternalTeachers = this.teachersList.size();
		Debug.Assert(this.nInternalTeachers <= GlobalMembersTimetable_defs.MAX_TEACHERS);
		this.internalTeachersList.resize(this.nInternalTeachers);
		for (i = 0; i < this.teachersList.size(); i++)
		{
			tch = teachersList[i];
			this.internalTeachersList[i] = tch;
		}
		Debug.Assert(i == this.nInternalTeachers);

		//subjects
		Subject sbj;
		this.nInternalSubjects = this.subjectsList.size();
		this.internalSubjectsList.resize(this.nInternalSubjects);
		for (i = 0; i < this.subjectsList.size(); i++)
		{
			sbj = this.subjectsList[i];
			this.internalSubjectsList[i] = sbj;
		}
		Debug.Assert(i == this.nInternalSubjects);

		//activity tags
		ActivityTag at;
		this.nInternalActivityTags = this.activityTagsList.size();
		this.internalActivityTagsList.resize(this.nInternalActivityTags);
		for (i = 0; i < this.activityTagsList.size(); i++)
		{
			at = this.activityTagsList[i];
			this.internalActivityTagsList[i] = at;
		}
		Debug.Assert(i == this.nInternalActivityTags);

		//students
		this.nInternalSubgroups = 0;
		for (int i = 0; i < allSubgroupsList.count(); i++)
		{
			Debug.Assert(allSubgroupsList.at(i).indexInInternalSubgroupsList == i);
			this.internalSubgroupsList[this.nInternalSubgroups] = allSubgroupsList.at(i);
			this.nInternalSubgroups++;
		}

		this.internalGroupsList.clear();
		for (int i = 0; i < allGroupsList.count(); i++)
		{
			Debug.Assert(allGroupsList.at(i).indexInInternalGroupsList == i);
			this.internalGroupsList.append(allGroupsList.at(i));
		}

	/*	for(int i=0; i<this->augmentedYearsList.size(); i++){
			StudentsYear* sty=this->augmentedYearsList[i];
	
			assert(sty->groupsList.count()>0);
	
			for(int j=0; j<sty->groupsList.size(); j++){
				StudentsGroup* stg=sty->groupsList[j];
	
				assert(stg->subgroupsList.count()>0);
	
				for(int k=0; k<stg->subgroupsList.size(); k++){
					StudentsSubgroup* sts=stg->subgroupsList[k];
	
					bool existing=false;
					for(int i=0; i<this->nInternalSubgroups; i++)
						if(this->internalSubgroupsList[i]->name==sts->name){
							existing=true;
							sts->indexInInternalSubgroupsList=i;
							break;
						}
					if(!existing){
						assert(this->nInternalSubgroups<MAX_TOTAL_SUBGROUPS);
						assert(this->nInternalSubgroups<tmpNSubgroups);
						sts->indexInInternalSubgroupsList=this->nInternalSubgroups;
						this->internalSubgroupsList[this->nInternalSubgroups++]=sts;
					}
				}
			}
		}*/
		Debug.Assert(this.nInternalSubgroups == tmpNSubgroups);

		//buildings
		internalBuildingsList.resize(buildingsList.size());
		this.nInternalBuildings = 0;
		Debug.Assert(this.buildingsList.size() <= GlobalMembersTimetable_defs.MAX_BUILDINGS);
		for (int i = 0; i < this.buildingsList.size(); i++)
		{
			Building bu = this.buildingsList[i];
			bu.computeInternalStructure(this);
		}

		for (int i = 0; i < this.buildingsList.size(); i++)
		{
			Building bu = this.buildingsList[i];
			this.internalBuildingsList[this.nInternalBuildings++] = bu;
		}
		Debug.Assert(this.nInternalBuildings == this.buildingsList.size());

		//rooms
		internalRoomsList.resize(roomsList.size());
		this.nInternalRooms = 0;
		Debug.Assert(this.roomsList.size() <= GlobalMembersTimetable_defs.MAX_ROOMS);
		for (int i = 0; i < this.roomsList.size(); i++)
		{
			Room rm = this.roomsList[i];
			rm.computeInternalStructure(this);
		}

		for (int i = 0; i < this.roomsList.size(); i++)
		{
			Room rm = this.roomsList[i];
			this.internalRoomsList[this.nInternalRooms++] = rm;
		}
		Debug.Assert(this.nInternalRooms == this.roomsList.size());

		//activities
		int range = 0;
		foreach (Activity * act, this.activitiesList) if (act.active) range++;
		QProgressDialog progress = new QProgressDialog(parent);
		progress.setWindowTitle(tr("Computing internal structure", "Title of a progress dialog"));
		progress.setLabelText(tr("Processing internally the activities ... please wait"));
		progress.setRange(0, range);
		progress.setModal(true);
		int ttt = 0;

		Activity act;
		counter = 0;

		this.inactiveActivities.clear();

		for (int i = 0; i < this.activitiesList.size(); i++)
		{
			act = this.activitiesList[i];
			if (act.active)
			{
				progress.setValue(ttt);
				//pqapplication->processEvents();
				if (progress.wasCanceled())
				{
					RulesImpossible.warning(parent, tr("FET information"), tr("Canceled"));
					return false;
				}
				ttt++;

				counter++;
				act.computeInternalStructure(this);
			}
			else
				inactiveActivities.insert(act.id);
		}

		progress.setValue(range);

		for (int i = 0; i < nInternalSubgroups; i++)
			internalSubgroupsList[i].activitiesForSubgroup.clear();
		for (int i = 0; i < nInternalTeachers; i++)
			internalTeachersList[i].activitiesForTeacher.clear();

		Debug.Assert(counter <= GlobalMembersTimetable_defs.MAX_ACTIVITIES);
		this.nInternalActivities = counter;
		this.internalActivitiesList.resize(this.nInternalActivities);
		int activei = 0;
		for (int ai = 0; ai < this.activitiesList.size(); ai++)
		{
			act = this.activitiesList[ai];
			if (act.active)
			{
				this.internalActivitiesList[activei] = act;

				for (int j = 0; j < act.iSubgroupsList.count(); j++)
				{
					int k = act.iSubgroupsList.at(j);
					Debug.Assert(!internalSubgroupsList[k].activitiesForSubgroup.contains(activei));
					internalSubgroupsList[k].activitiesForSubgroup.append(activei);
				}

				for (int j = 0; j < act.iTeachersList.count(); j++)
				{
					int k = act.iTeachersList.at(j);
					Debug.Assert(!internalTeachersList[k].activitiesForTeacher.contains(activei));
					internalTeachersList[k].activitiesForTeacher.append(activei);
				}

				activei++;
			}
		}

		//activities list for each subject - used for subjects timetable - in order for students and teachers
		activitiesForSubject.resize(nInternalSubjects);
		for (int sb = 0; sb < nInternalSubjects; sb++)
			activitiesForSubject[sb].clear();

		for (int i = 0; i < this.augmentedYearsList.size(); i++)
		{
			StudentsYear sty = this.augmentedYearsList[i];

			for (int j = 0; j < sty.groupsList.size(); j++)
			{
				StudentsGroup stg = sty.groupsList[j];

				for (int k = 0; k < stg.subgroupsList.size(); k++)
				{
					StudentsSubgroup sts = stg.subgroupsList[k];

					foreach (int ai, internalSubgroupsList[sts.indexInInternalSubgroupsList].activitiesForSubgroup) if (!activitiesForSubject[internalActivitiesList[ai].subjectIndex].contains(ai)) activitiesForSubject[internalActivitiesList[ai].subjectIndex].append(ai);
				}
			}
		}

		for (int i = 0; i < nInternalTeachers; i++)
		{
			foreach (int ai, internalTeachersList[i].activitiesForTeacher) if (!activitiesForSubject[internalActivitiesList[ai].subjectIndex].contains(ai)) activitiesForSubject[internalActivitiesList[ai].subjectIndex].append(ai);
		}
		/////////////////////////////////////////////////////////////////

		bool ok = true;

		//time constraints
		//progress.reset();

		bool skipInactiveTimeConstraints = false;

		TimeConstraint tctr;

		QSet<int> toSkipTimeSet = new QSet<int>();

		int _c = 0;

		for (int tctrindex = 0; tctrindex < this.timeConstraintsList.size(); tctrindex++)
		{
			tctr = this.timeConstraintsList[tctrindex];

			if (!tctr.active)
			{
				toSkipTimeSet.insert(tctrindex);
			}
			else if (tctr.hasInactiveActivities(this))
			{
				//toSkipTime[tctrindex]=true;
				toSkipTimeSet.insert(tctrindex);

				if (!skipInactiveTimeConstraints)
				{
					QString s = tr("The following time constraint is ignored, because it refers to inactive activities:");
					s += "\n";
					s += tctr.getDetailedDescription(this);

					int t = RulesConstraintIgnored.mediumConfirmation(parent, tr("FET information"), s, tr("Skip rest"), tr("See next"), new QString(), 1, 0);

					if (t == 0)
						skipInactiveTimeConstraints = true;
				}
			}
			else
			{
				//toSkipTime[tctrindex]=false;
				_c++;
			}
		}

		internalTimeConstraintsList.resize(_c);

		progress.setLabelText(tr("Processing internally the time constraints ... please wait"));
		progress.setRange(0, timeConstraintsList.size());
		ttt = 0;

		//assert(this->timeConstraintsList.size()<=MAX_TIME_CONSTRAINTS);
		int tctri = 0;

		for (int tctrindex = 0; tctrindex < this.timeConstraintsList.size(); tctrindex++)
		{
			progress.setValue(ttt);
			//pqapplication->processEvents();
			if (progress.wasCanceled())
			{
				RulesImpossible.warning(parent, tr("FET information"), tr("Canceled"));
				return false;
			}
			ttt++;

			tctr = this.timeConstraintsList[tctrindex];

			if (toSkipTimeSet.contains(tctrindex))
				continue;

			if (!tctr.computeInternalStructure(parent, this))
			{
				//assert(0);
				ok = false;
				continue;
			}
			this.internalTimeConstraintsList[tctri++] = tctr;
		}

		progress.setValue(timeConstraintsList.size());

		this.nInternalTimeConstraints = tctri;
		Console.Write(_c);
		Console.Write(" time constraints after first pass (after removing inactive ones)");
		Console.Write("\n");
		Console.Write("  ");
		Console.Write(this.nInternalTimeConstraints);
		Console.Write(" time constraints after second pass (after removing wrong ones)");
		Console.Write("\n");
		Debug.Assert(_c >= this.nInternalTimeConstraints); //because some constraints may have toSkipTime false, but computeInternalStructure also false
		//assert(this->nInternalTimeConstraints<=MAX_TIME_CONSTRAINTS);

		//space constraints
		//progress.reset();

		bool skipInactiveSpaceConstraints = false;

		SpaceConstraint sctr;

		QSet<int> toSkipSpaceSet = new QSet<int>();

		_c = 0;

		for (int sctrindex = 0; sctrindex < this.spaceConstraintsList.size(); sctrindex++)
		{
			sctr = this.spaceConstraintsList[sctrindex];

			if (!sctr.active)
			{
				toSkipSpaceSet.insert(sctrindex);
			}
			else if (sctr.hasInactiveActivities(this))
			{
				//toSkipSpace[sctrindex]=true;
				toSkipSpaceSet.insert(sctrindex);

				if (!skipInactiveSpaceConstraints)
				{
					QString s = tr("The following space constraint is ignored, because it refers to inactive activities:");
					s += "\n";
					s += sctr.getDetailedDescription(this);

					int t = RulesConstraintIgnored.mediumConfirmation(parent, tr("FET information"), s, tr("Skip rest"), tr("See next"), new QString(), 1, 0);

					if (t == 0)
						skipInactiveSpaceConstraints = true;
				}
			}
			else
			{
				_c++;
				//toSkipSpace[sctrindex]=false;
			}
		}

		internalSpaceConstraintsList.resize(_c);

		progress.setLabelText(tr("Processing internally the space constraints ... please wait"));
		progress.setRange(0, spaceConstraintsList.size());
		ttt = 0;
		//assert(this->spaceConstraintsList.size()<=MAX_SPACE_CONSTRAINTS);

		int sctri = 0;

		for (int sctrindex = 0; sctrindex < this.spaceConstraintsList.size(); sctrindex++)
		{
			progress.setValue(ttt);
			//pqapplication->processEvents();
			if (progress.wasCanceled())
			{
				RulesImpossible.warning(parent, tr("FET information"), tr("Canceled"));
				return false;
			}
			ttt++;

			sctr = this.spaceConstraintsList[sctrindex];

			if (toSkipSpaceSet.contains(sctrindex))
				continue;

			if (!sctr.computeInternalStructure(parent, this))
			{
				//assert(0);
				ok = false;
				continue;
			}
			this.internalSpaceConstraintsList[sctri++] = sctr;
		}

		progress.setValue(spaceConstraintsList.size());

		this.nInternalSpaceConstraints = sctri;
		Console.Write(_c);
		Console.Write(" space constraints after first pass (after removing inactive ones)");
		Console.Write("\n");
		Console.Write("  ");
		Console.Write(this.nInternalSpaceConstraints);
		Console.Write(" space constraints after second pass (after removing wrong ones)");
		Console.Write("\n");
		Debug.Assert(_c >= this.nInternalSpaceConstraints); //because some constraints may have toSkipSpace false, but computeInternalStructure also false
		//assert(this->nInternalSpaceConstraints<=MAX_SPACE_CONSTRAINTS);

		//done.
		this.internalStructureComputed = ok;

		return ok;
	}

	/**
	Terminator - basically clears the memory for the constraints.
	*/
	private void kill()
	{
		//Teachers
		while (!teachersList.isEmpty())
			teachersList.takeFirst() = null;

		//Subjects
		while (!subjectsList.isEmpty())
			subjectsList.takeFirst() = null;

		//Activity tags
		while (!activityTagsList.isEmpty())
			activityTagsList.takeFirst() = null;

		//Years
		/*while(!yearsList.isEmpty())
			delete yearsList.takeFirst();*/

		//students sets
		QList<StudentsYear> iyears = new QList<StudentsYear>();
		QList<StudentsGroup> igroups = new QList<StudentsGroup>();
		QList<StudentsSubgroup> isubgroups = new QList<StudentsSubgroup>();
		foreach (StudentsYear * year, yearsList)
		{
			if (!iyears.contains(year))
				iyears.append(year);
			foreach (StudentsGroup * group, year.groupsList)
			{
				if (!igroups.contains(group))
					igroups.append(group);
				foreach (StudentsSubgroup * subgroup, group.subgroupsList)
				{
					if (!isubgroups.contains(subgroup))
						isubgroups.append(subgroup);
				}
			}
		}
		foreach (StudentsYear * year, iyears)
		{
			Debug.Assert(year != null);
			year = null;
		}
		foreach (StudentsGroup * group, igroups)
		{
			Debug.Assert(group != null);
			group = null;
		}
		foreach (StudentsSubgroup * subgroup, isubgroups)
		{
			Debug.Assert(subgroup != null);
			subgroup = null;
		}
		yearsList.clear();
		//////////////////

		//kill augmented students sets
		QList<StudentsYear> ayears = new QList<StudentsYear>();
		QList<StudentsGroup> agroups = new QList<StudentsGroup>();
		QList<StudentsSubgroup> asubgroups = new QList<StudentsSubgroup>();
		foreach (StudentsYear * year, augmentedYearsList)
		{
			if (!ayears.contains(year))
				ayears.append(year);
			foreach (StudentsGroup * group, year.groupsList)
			{
				if (!agroups.contains(group))
					agroups.append(group);
				foreach (StudentsSubgroup * subgroup, group.subgroupsList)
				{
					if (!asubgroups.contains(subgroup))
						asubgroups.append(subgroup);
				}
			}
		}
		foreach (StudentsYear * year, ayears)
		{
			Debug.Assert(year != null);
			year = null;
		}
		foreach (StudentsGroup * group, agroups)
		{
			Debug.Assert(group != null);
			group = null;
		}
		foreach (StudentsSubgroup * subgroup, asubgroups)
		{
			Debug.Assert(subgroup != null);
			subgroup = null;
		}
		augmentedYearsList.clear();
		//////////////////

		//Activities
		while (!activitiesList.isEmpty())
			activitiesList.takeFirst() = null;

		//Time constraints
		while (!timeConstraintsList.isEmpty())
			timeConstraintsList.takeFirst() = null;

		//Space constraints
		while (!spaceConstraintsList.isEmpty())
			spaceConstraintsList.takeFirst() = null;

		//Buildings
		while (!buildingsList.isEmpty())
			buildingsList.takeFirst() = null;

		//Rooms
		while (!roomsList.isEmpty())
			roomsList.takeFirst() = null;

		//done
		this.internalStructureComputed = false;
		this.initialized = false;
	}

	private Rules()
	{
		this.initialized = false;
		this.modified = false;
	}

	public void Dispose()
	{
		if (this.initialized)
			this.kill();
	}

	private void setInstitutionName(QString newInstitutionName)
	{
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->institutionName=newInstitutionName;
		this.institutionName.CopyFrom(newInstitutionName);
		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);
	}

	private void setComments(QString newComments)
	{
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->comments=newComments;
		this.comments.CopyFrom(newComments);
		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);
	}

	/**
	Adds a new teacher
	(if not already in the list).
	Returns false/true (unsuccessful/successful).
	*/
	private bool addTeacher(Teacher teacher)
	{
		for (int i = 0; i < this.teachersList.size(); i++)
		{
			Teacher tch = this.teachersList[i];
			if (tch.name == teacher.name)
				return false;
		}

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		teachers_schedule_ready = false;
		students_schedule_ready = false;
		rooms_schedule_ready = false;

		this.teachersList.append(teacher);
		return true;
	}

	/*when reading rules, faster*/
	private bool addTeacherFast(Teacher teacher)
	{
		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		teachers_schedule_ready = false;
		students_schedule_ready = false;
		rooms_schedule_ready = false;

		this.teachersList.append(teacher);
		return true;
	}

	/**
	Returns the index of this teacher in the teachersList,
	or -1 for inexistent teacher.
	*/
	private int searchTeacher(QString teacherName)
	{
		for (int i = 0; i < this.teachersList.size(); i++)
			if (this.teachersList.at(i).name == teacherName)
				return i;

		return -1;
	}

	/**
	Removes this teacher and all related activities and constraints.
	It returns false on failure. If successful, returns true.
	*/
	private bool removeTeacher(QString teacherName)
	{
		for (int i = 0; i < this.activitiesList.size();)
		{
			Activity act = this.activitiesList[i];
			bool t = act.removeTeacher(teacherName);
			if (t && act.teachersNames.size() == 0)
			{
				this.removeActivity(act.id, act.activityGroupId);
				i = 0;
				//(You have to be careful, there can be erased more activities here)
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_NOT_AVAILABLE_TIMES)
			{
				ConstraintTeacherNotAvailableTimes crt_constraint = (ConstraintTeacherNotAvailableTimes)ctr;
				if (teacherName == crt_constraint.teacher)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_MAX_GAPS_PER_WEEK)
			{
				ConstraintTeacherMaxGapsPerWeek crt_constraint = (ConstraintTeacherMaxGapsPerWeek)ctr;
				if (teacherName == crt_constraint.teacherName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_MAX_GAPS_PER_DAY)
			{
				ConstraintTeacherMaxGapsPerDay crt_constraint = (ConstraintTeacherMaxGapsPerDay)ctr;
				if (teacherName == crt_constraint.teacherName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_MAX_HOURS_DAILY)
			{
				ConstraintTeacherMaxHoursDaily crt_constraint = (ConstraintTeacherMaxHoursDaily)ctr;
				if (teacherName == crt_constraint.teacherName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_MAX_HOURS_CONTINUOUSLY)
			{
				ConstraintTeacherMaxHoursContinuously crt_constraint = (ConstraintTeacherMaxHoursContinuously)ctr;
				if (teacherName == crt_constraint.teacherName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_ACTIVITY_TAG_MAX_HOURS_CONTINUOUSLY)
			{
				ConstraintTeacherActivityTagMaxHoursContinuously crt_constraint = (ConstraintTeacherActivityTagMaxHoursContinuously)ctr;
				if (teacherName == crt_constraint.teacherName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_ACTIVITY_TAG_MAX_HOURS_DAILY)
			{
				ConstraintTeacherActivityTagMaxHoursDaily crt_constraint = (ConstraintTeacherActivityTagMaxHoursDaily)ctr;
				if (teacherName == crt_constraint.teacherName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_MIN_HOURS_DAILY)
			{
				ConstraintTeacherMinHoursDaily crt_constraint = (ConstraintTeacherMinHoursDaily)ctr;
				if (teacherName == crt_constraint.teacherName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_MAX_DAYS_PER_WEEK)
			{
				ConstraintTeacherMaxDaysPerWeek crt_constraint = (ConstraintTeacherMaxDaysPerWeek)ctr;
				if (teacherName == crt_constraint.teacherName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_MIN_DAYS_PER_WEEK)
			{
				ConstraintTeacherMinDaysPerWeek crt_constraint = (ConstraintTeacherMinDaysPerWeek)ctr;
				if (teacherName == crt_constraint.teacherName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_INTERVAL_MAX_DAYS_PER_WEEK)
			{
				ConstraintTeacherIntervalMaxDaysPerWeek crt_constraint = (ConstraintTeacherIntervalMaxDaysPerWeek)ctr;
				if (teacherName == crt_constraint.teacherName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_PREFERRED_TIME_SLOTS)
			{
				ConstraintActivitiesPreferredTimeSlots crt_constraint = (ConstraintActivitiesPreferredTimeSlots)ctr;
				if (teacherName == crt_constraint.p_teacherName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_PREFERRED_STARTING_TIMES)
			{
				ConstraintActivitiesPreferredStartingTimes crt_constraint = (ConstraintActivitiesPreferredStartingTimes)ctr;
				if (teacherName == crt_constraint.teacherName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_END_STUDENTS_DAY)
			{
				ConstraintActivitiesEndStudentsDay crt_constraint = (ConstraintActivitiesEndStudentsDay)ctr;
				if (teacherName == crt_constraint.teacherName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_SUBACTIVITIES_PREFERRED_TIME_SLOTS)
			{
				ConstraintSubactivitiesPreferredTimeSlots crt_constraint = (ConstraintSubactivitiesPreferredTimeSlots)ctr;
				if (teacherName == crt_constraint.p_teacherName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_SUBACTIVITIES_PREFERRED_STARTING_TIMES)
			{
				ConstraintSubactivitiesPreferredStartingTimes crt_constraint = (ConstraintSubactivitiesPreferredStartingTimes)ctr;
				if (teacherName == crt_constraint.teacherName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}


		for (int i = 0; i < this.spaceConstraintsList.size();)
		{
			SpaceConstraint ctr = this.spaceConstraintsList[i];
			if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_TEACHER_HOME_ROOM)
			{
				ConstraintTeacherHomeRoom crt_constraint = (ConstraintTeacherHomeRoom)ctr;
				if (teacherName == crt_constraint.teacherName)
					this.removeSpaceConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.spaceConstraintsList.size();)
		{
			SpaceConstraint ctr = this.spaceConstraintsList[i];
			if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_TEACHER_HOME_ROOMS)
			{
				ConstraintTeacherHomeRooms crt_constraint = (ConstraintTeacherHomeRooms)ctr;
				if (teacherName == crt_constraint.teacherName)
					this.removeSpaceConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.spaceConstraintsList.size();)
		{
			SpaceConstraint ctr = this.spaceConstraintsList[i];
			if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_TEACHER_MAX_BUILDING_CHANGES_PER_DAY)
			{
				ConstraintTeacherMaxBuildingChangesPerDay crt_constraint = (ConstraintTeacherMaxBuildingChangesPerDay)ctr;
				if (teacherName == crt_constraint.teacherName)
					this.removeSpaceConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}
		for (int i = 0; i < this.spaceConstraintsList.size();)
		{
			SpaceConstraint ctr = this.spaceConstraintsList[i];
			if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_TEACHER_MAX_BUILDING_CHANGES_PER_WEEK)
			{
				ConstraintTeacherMaxBuildingChangesPerWeek crt_constraint = (ConstraintTeacherMaxBuildingChangesPerWeek)ctr;
				if (teacherName == crt_constraint.teacherName)
					this.removeSpaceConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}
		for (int i = 0; i < this.spaceConstraintsList.size();)
		{
			SpaceConstraint ctr = this.spaceConstraintsList[i];
			if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_TEACHER_MIN_GAPS_BETWEEN_BUILDING_CHANGES)
			{
				ConstraintTeacherMinGapsBetweenBuildingChanges crt_constraint = (ConstraintTeacherMinGapsBetweenBuildingChanges)ctr;
				if (teacherName == crt_constraint.teacherName)
					this.removeSpaceConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}



		for (int i = 0; i < this.teachersList.size(); i++)
			if (this.teachersList.at(i).name == teacherName)
			{
				Teacher tch = this.teachersList[i];
				this.teachersList.removeAt(i);
				if (tch != null)
					tch.Dispose();
				break;
			}

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		teachers_schedule_ready = false;
		students_schedule_ready = false;
		rooms_schedule_ready = false;

		return true;
	}

	/**
	Modifies (renames) this teacher and takes care of all related activities and constraints.
	Returns true on success, false on failure (if not found)
	*/
	private bool modifyTeacher(QString initialTeacherName, QString finalTeacherName)
	{
		Debug.Assert(this.searchTeacher(finalTeacherName) == -1);
		Debug.Assert(this.searchTeacher(initialTeacherName) >= 0);

		//TODO: improve this part
		for (int i = 0; i < this.activitiesList.size(); i++)
			this.activitiesList.at(i).renameTeacher(initialTeacherName, finalTeacherName);

		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_NOT_AVAILABLE_TIMES)
			{
				ConstraintTeacherNotAvailableTimes crt_constraint = (ConstraintTeacherNotAvailableTimes)ctr;
				if (initialTeacherName == crt_constraint.teacher)
					crt_constraint.teacher = finalTeacherName;
			}
		}

		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_MAX_GAPS_PER_WEEK)
			{
				ConstraintTeacherMaxGapsPerWeek crt_constraint = (ConstraintTeacherMaxGapsPerWeek)ctr;
				if (initialTeacherName == crt_constraint.teacherName)
					crt_constraint.teacherName = finalTeacherName;
			}
		}

		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_MAX_GAPS_PER_DAY)
			{
				ConstraintTeacherMaxGapsPerDay crt_constraint = (ConstraintTeacherMaxGapsPerDay)ctr;
				if (initialTeacherName == crt_constraint.teacherName)
					crt_constraint.teacherName = finalTeacherName;
			}
		}

		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_MAX_HOURS_DAILY)
			{
				ConstraintTeacherMaxHoursDaily crt_constraint = (ConstraintTeacherMaxHoursDaily)ctr;
				if (initialTeacherName == crt_constraint.teacherName)
					crt_constraint.teacherName = finalTeacherName;
			}
		}

		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_MAX_HOURS_CONTINUOUSLY)
			{
				ConstraintTeacherMaxHoursContinuously crt_constraint = (ConstraintTeacherMaxHoursContinuously)ctr;
				if (initialTeacherName == crt_constraint.teacherName)
					crt_constraint.teacherName = finalTeacherName;
			}
		}

		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_ACTIVITY_TAG_MAX_HOURS_CONTINUOUSLY)
			{
				ConstraintTeacherActivityTagMaxHoursContinuously crt_constraint = (ConstraintTeacherActivityTagMaxHoursContinuously)ctr;
				if (initialTeacherName == crt_constraint.teacherName)
					crt_constraint.teacherName = finalTeacherName;
			}
		}

		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_ACTIVITY_TAG_MAX_HOURS_DAILY)
			{
				ConstraintTeacherActivityTagMaxHoursDaily crt_constraint = (ConstraintTeacherActivityTagMaxHoursDaily)ctr;
				if (initialTeacherName == crt_constraint.teacherName)
					crt_constraint.teacherName = finalTeacherName;
			}
		}

		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_MIN_HOURS_DAILY)
			{
				ConstraintTeacherMinHoursDaily crt_constraint = (ConstraintTeacherMinHoursDaily)ctr;
				if (initialTeacherName == crt_constraint.teacherName)
					crt_constraint.teacherName = finalTeacherName;
			}
		}

		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_MAX_DAYS_PER_WEEK)
			{
				ConstraintTeacherMaxDaysPerWeek crt_constraint = (ConstraintTeacherMaxDaysPerWeek)ctr;
				if (initialTeacherName == crt_constraint.teacherName)
					crt_constraint.teacherName = finalTeacherName;
			}
		}

		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_MIN_DAYS_PER_WEEK)
			{
				ConstraintTeacherMinDaysPerWeek crt_constraint = (ConstraintTeacherMinDaysPerWeek)ctr;
				if (initialTeacherName == crt_constraint.teacherName)
					crt_constraint.teacherName = finalTeacherName;
			}
		}

		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_INTERVAL_MAX_DAYS_PER_WEEK)
			{
				ConstraintTeacherIntervalMaxDaysPerWeek crt_constraint = (ConstraintTeacherIntervalMaxDaysPerWeek)ctr;
				if (initialTeacherName == crt_constraint.teacherName)
					crt_constraint.teacherName = finalTeacherName;
			}
		}

		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_PREFERRED_TIME_SLOTS)
			{
				ConstraintActivitiesPreferredTimeSlots crt_constraint = (ConstraintActivitiesPreferredTimeSlots)ctr;
				if (initialTeacherName == crt_constraint.p_teacherName)
					crt_constraint.p_teacherName = finalTeacherName;
			}
		}

		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_PREFERRED_STARTING_TIMES)
			{
				ConstraintActivitiesPreferredStartingTimes crt_constraint = (ConstraintActivitiesPreferredStartingTimes)ctr;
				if (initialTeacherName == crt_constraint.teacherName)
					crt_constraint.teacherName = finalTeacherName;
			}
		}

		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_END_STUDENTS_DAY)
			{
				ConstraintActivitiesEndStudentsDay crt_constraint = (ConstraintActivitiesEndStudentsDay)ctr;
				if (initialTeacherName == crt_constraint.teacherName)
					crt_constraint.teacherName = finalTeacherName;
			}
		}

		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_SUBACTIVITIES_PREFERRED_TIME_SLOTS)
			{
				ConstraintSubactivitiesPreferredTimeSlots crt_constraint = (ConstraintSubactivitiesPreferredTimeSlots)ctr;
				if (initialTeacherName == crt_constraint.p_teacherName)
					crt_constraint.p_teacherName = finalTeacherName;
			}
		}

		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_SUBACTIVITIES_PREFERRED_STARTING_TIMES)
			{
				ConstraintSubactivitiesPreferredStartingTimes crt_constraint = (ConstraintSubactivitiesPreferredStartingTimes)ctr;
				if (initialTeacherName == crt_constraint.teacherName)
					crt_constraint.teacherName = finalTeacherName;
			}
		}


		for (int i = 0; i < this.spaceConstraintsList.size(); i++)
		{
			SpaceConstraint ctr = this.spaceConstraintsList[i];

			if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_TEACHER_HOME_ROOM)
			{
				ConstraintTeacherHomeRoom crt_constraint = (ConstraintTeacherHomeRoom)ctr;
				if (initialTeacherName == crt_constraint.teacherName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: crt_constraint->teacherName=finalTeacherName;
					crt_constraint.teacherName.CopyFrom(finalTeacherName);
			}
		}

		for (int i = 0; i < this.spaceConstraintsList.size(); i++)
		{
			SpaceConstraint ctr = this.spaceConstraintsList[i];

			if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_TEACHER_HOME_ROOMS)
			{
				ConstraintTeacherHomeRooms crt_constraint = (ConstraintTeacherHomeRooms)ctr;
				if (initialTeacherName == crt_constraint.teacherName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: crt_constraint->teacherName=finalTeacherName;
					crt_constraint.teacherName.CopyFrom(finalTeacherName);
			}
		}

		for (int i = 0; i < this.spaceConstraintsList.size(); i++)
		{
			SpaceConstraint ctr = this.spaceConstraintsList[i];

			if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_TEACHER_MAX_BUILDING_CHANGES_PER_DAY)
			{
				ConstraintTeacherMaxBuildingChangesPerDay crt_constraint = (ConstraintTeacherMaxBuildingChangesPerDay)ctr;
				if (initialTeacherName == crt_constraint.teacherName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: crt_constraint->teacherName=finalTeacherName;
					crt_constraint.teacherName.CopyFrom(finalTeacherName);
			}
		}
		for (int i = 0; i < this.spaceConstraintsList.size(); i++)
		{
			SpaceConstraint ctr = this.spaceConstraintsList[i];

			if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_TEACHER_MAX_BUILDING_CHANGES_PER_WEEK)
			{
				ConstraintTeacherMaxBuildingChangesPerWeek crt_constraint = (ConstraintTeacherMaxBuildingChangesPerWeek)ctr;
				if (initialTeacherName == crt_constraint.teacherName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: crt_constraint->teacherName=finalTeacherName;
					crt_constraint.teacherName.CopyFrom(finalTeacherName);
			}
		}
		for (int i = 0; i < this.spaceConstraintsList.size(); i++)
		{
			SpaceConstraint ctr = this.spaceConstraintsList[i];

			if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_TEACHER_MIN_GAPS_BETWEEN_BUILDING_CHANGES)
			{
				ConstraintTeacherMinGapsBetweenBuildingChanges crt_constraint = (ConstraintTeacherMinGapsBetweenBuildingChanges)ctr;
				if (initialTeacherName == crt_constraint.teacherName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: crt_constraint->teacherName=finalTeacherName;
					crt_constraint.teacherName.CopyFrom(finalTeacherName);
			}
		}



		int t = 0;
		for (int i = 0; i < this.teachersList.size(); i++)
		{
			Teacher tch = this.teachersList[i];

			if (tch.name == initialTeacherName)
			{
				tch.name = finalTeacherName;
				t++;
			}
		}
		Debug.Assert(t <= 1);

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		if (t == 0)
			return false;
		else
			return true;
	}

	/**
	A function to sort the teachers alphabetically
	*/
	private void sortTeachersAlphabetically()
	{
		qSort(this.teachersList.begin(), this.teachersList.end(), GlobalMembersTeacher.teachersAscending);

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);
	}

	/**
	Adds a new subject
	(if not already in the list).
	Returns false/true (unsuccessful/successful).
	*/
	private bool addSubject(Subject subject)
	{
		for (int i = 0; i < this.subjectsList.size(); i++)
		{
			Subject sbj = this.subjectsList[i];
			if (sbj.name == subject.name)
				return false;
		}

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		teachers_schedule_ready = false;
		students_schedule_ready = false;
		rooms_schedule_ready = false;

		this.subjectsList << subject;
		return true;
	}

	/*
	When reading rules, faster
	*/
	private bool addSubjectFast(Subject subject)
	{
		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		teachers_schedule_ready = false;
		students_schedule_ready = false;
		rooms_schedule_ready = false;

		this.subjectsList << subject;
		return true;
	}

	/**
	Returns the index of this subject in the subjectsList,
	or -1 if not found.
	*/
	private int searchSubject(QString subjectName)
	{
		for (int i = 0; i < this.subjectsList.size(); i++)
			if (this.subjectsList.at(i).name == subjectName)
				return i;

		return -1;
	}

	/**
	Removes this subject and all related activities and constraints.
	It returns false on failure.
	If successful, returns true.
	*/
	private bool removeSubject(QString subjectName)
	{
		//check the activities first
		for (int i = 0; i < this.activitiesList.size();)
		{
			Activity act = this.activitiesList[i];
			if (act.subjectName == subjectName)
			{
				this.removeActivity(act.id, act.activityGroupId);
				i = 0;
				//(You have to be careful, there can be erased more activities here)
			}
			else
				i++;
		}

		//delete the time constraints related to this subject

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_PREFERRED_TIME_SLOTS)
			{
				ConstraintActivitiesPreferredTimeSlots crt_constraint = (ConstraintActivitiesPreferredTimeSlots)ctr;
				if (subjectName == crt_constraint.p_subjectName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_PREFERRED_STARTING_TIMES)
			{
				ConstraintActivitiesPreferredStartingTimes crt_constraint = (ConstraintActivitiesPreferredStartingTimes)ctr;
				if (subjectName == crt_constraint.subjectName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_END_STUDENTS_DAY)
			{
				ConstraintActivitiesEndStudentsDay crt_constraint = (ConstraintActivitiesEndStudentsDay)ctr;
				if (subjectName == crt_constraint.subjectName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_SUBACTIVITIES_PREFERRED_TIME_SLOTS)
			{
				ConstraintSubactivitiesPreferredTimeSlots crt_constraint = (ConstraintSubactivitiesPreferredTimeSlots)ctr;
				if (subjectName == crt_constraint.p_subjectName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_SUBACTIVITIES_PREFERRED_STARTING_TIMES)
			{
				ConstraintSubactivitiesPreferredStartingTimes crt_constraint = (ConstraintSubactivitiesPreferredStartingTimes)ctr;
				if (subjectName == crt_constraint.subjectName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}

		//delete the space constraints related to this subject
		for (int i = 0; i < this.spaceConstraintsList.size();)
		{
			SpaceConstraint ctr = this.spaceConstraintsList[i];

			if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_SUBJECT_PREFERRED_ROOM)
			{
				ConstraintSubjectPreferredRoom c = (ConstraintSubjectPreferredRoom)ctr;

				if (c.subjectName == subjectName)
					this.removeSpaceConstraint(ctr);
				else
					i++;
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_SUBJECT_PREFERRED_ROOMS)
			{
				ConstraintSubjectPreferredRooms c = (ConstraintSubjectPreferredRooms)ctr;

				if (c.subjectName == subjectName)
					this.removeSpaceConstraint(ctr);
				else
					i++;
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_SUBJECT_ACTIVITY_TAG_PREFERRED_ROOM)
			{
				ConstraintSubjectActivityTagPreferredRoom c = (ConstraintSubjectActivityTagPreferredRoom)ctr;

				if (c.subjectName == subjectName)
					this.removeSpaceConstraint(ctr);
				else
					i++;
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_SUBJECT_ACTIVITY_TAG_PREFERRED_ROOMS)
			{
				ConstraintSubjectActivityTagPreferredRooms c = (ConstraintSubjectActivityTagPreferredRooms)ctr;

				if (c.subjectName == subjectName)
					this.removeSpaceConstraint(ctr);
				else
					i++;
			}
			else
				i++;
		}

		//remove the subject from the list
		for (int i = 0; i < this.subjectsList.size(); i++)
			if (this.subjectsList[i].name == subjectName)
			{
				Subject sbj = this.subjectsList[i];
				this.subjectsList.removeAt(i);
				if (sbj != null)
					sbj.Dispose();
				break;
			}

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		teachers_schedule_ready = false;
		students_schedule_ready = false;
		rooms_schedule_ready = false;

		return true;
	}

	/**
	Modifies (renames) this subject and takes care of all related activities and constraints.
	Returns true on success, false on failure (if not found)
	*/
	private bool modifySubject(QString initialSubjectName, QString finalSubjectName)
	{
		Debug.Assert(this.searchSubject(finalSubjectName) == -1);
		Debug.Assert(this.searchSubject(initialSubjectName) >= 0);

		//check the activities first
		for (int i = 0; i < this.activitiesList.size(); i++)
		{
			Activity act = this.activitiesList[i];

			if (act.subjectName == initialSubjectName)
				act.subjectName = finalSubjectName;
		}

		//modify the time constraints related to this subject
		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_PREFERRED_TIME_SLOTS)
			{
				ConstraintActivitiesPreferredTimeSlots crt_constraint = (ConstraintActivitiesPreferredTimeSlots)ctr;
				if (initialSubjectName == crt_constraint.p_subjectName)
					crt_constraint.p_subjectName = finalSubjectName;
			}
		}

		//modify the time constraints related to this subject
		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_PREFERRED_STARTING_TIMES)
			{
				ConstraintActivitiesPreferredStartingTimes crt_constraint = (ConstraintActivitiesPreferredStartingTimes)ctr;
				if (initialSubjectName == crt_constraint.subjectName)
					crt_constraint.subjectName = finalSubjectName;
			}
		}

		//modify the time constraints related to this subject
		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_END_STUDENTS_DAY)
			{
				ConstraintActivitiesEndStudentsDay crt_constraint = (ConstraintActivitiesEndStudentsDay)ctr;
				if (initialSubjectName == crt_constraint.subjectName)
					crt_constraint.subjectName = finalSubjectName;
			}
		}

		//modify the time constraints related to this subject
		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_SUBACTIVITIES_PREFERRED_TIME_SLOTS)
			{
				ConstraintSubactivitiesPreferredTimeSlots crt_constraint = (ConstraintSubactivitiesPreferredTimeSlots)ctr;
				if (initialSubjectName == crt_constraint.p_subjectName)
					crt_constraint.p_subjectName = finalSubjectName;
			}
		}

		//modify the time constraints related to this subject
		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_SUBACTIVITIES_PREFERRED_STARTING_TIMES)
			{
				ConstraintSubactivitiesPreferredStartingTimes crt_constraint = (ConstraintSubactivitiesPreferredStartingTimes)ctr;
				if (initialSubjectName == crt_constraint.subjectName)
					crt_constraint.subjectName = finalSubjectName;
			}
		}

		//modify the space constraints related to this subject
		for (int i = 0; i < this.spaceConstraintsList.size(); i++)
		{
			SpaceConstraint ctr = this.spaceConstraintsList[i];

			if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_SUBJECT_PREFERRED_ROOM)
			{
				ConstraintSubjectPreferredRoom c = (ConstraintSubjectPreferredRoom)ctr;
				if (c.subjectName == initialSubjectName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: c->subjectName=finalSubjectName;
					c.subjectName.CopyFrom(finalSubjectName);
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_SUBJECT_PREFERRED_ROOMS)
			{
				ConstraintSubjectPreferredRooms c = (ConstraintSubjectPreferredRooms)ctr;
				if (c.subjectName == initialSubjectName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: c->subjectName=finalSubjectName;
					c.subjectName.CopyFrom(finalSubjectName);
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_SUBJECT_ACTIVITY_TAG_PREFERRED_ROOM)
			{
				ConstraintSubjectActivityTagPreferredRoom c = (ConstraintSubjectActivityTagPreferredRoom)ctr;
				if (c.subjectName == initialSubjectName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: c->subjectName=finalSubjectName;
					c.subjectName.CopyFrom(finalSubjectName);
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_SUBJECT_ACTIVITY_TAG_PREFERRED_ROOMS)
			{
				ConstraintSubjectActivityTagPreferredRooms c = (ConstraintSubjectActivityTagPreferredRooms)ctr;
				if (c.subjectName == initialSubjectName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: c->subjectName=finalSubjectName;
					c.subjectName.CopyFrom(finalSubjectName);
			}
		}


		//rename the subject in the list
		int t = 0;
		for (int i = 0; i < this.subjectsList.size(); i++)
		{
			Subject sbj = this.subjectsList[i];

			if (sbj.name == initialSubjectName)
			{
				t++;
				sbj.name = finalSubjectName;
			}
		}
		Debug.Assert(t <= 1);

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		return true;
	}

	/**
	A function to sort the subjects alphabetically
	*/
	private void sortSubjectsAlphabetically()
	{
		qSort(this.subjectsList.begin(), this.subjectsList.end(), GlobalMembersSubject.subjectsAscending);

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);
	}

	/**
	Adds a new activity tag to the list of activity tags
	(if not already in the list).
	Returns false/true (unsuccessful/successful).
	*/
	private bool addActivityTag(ActivityTag activityTag)
	{
		for (int i = 0; i < this.activityTagsList.size(); i++)
		{
			ActivityTag sbt = this.activityTagsList[i];

			if (sbt.name == activityTag.name)
				return false;
		}

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		teachers_schedule_ready = false;
		students_schedule_ready = false;
		rooms_schedule_ready = false;

		this.activityTagsList << activityTag;
		return true;
	}

	/*
	When reading rules, faster
	*/
	private bool addActivityTagFast(ActivityTag activityTag)
	{
		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		teachers_schedule_ready = false;
		students_schedule_ready = false;
		rooms_schedule_ready = false;

		this.activityTagsList << activityTag;
		return true;
	}

	/**
	Returns the index of this activity tag in the activityTagsList,
	or -1 if not found.
	*/
	private int searchActivityTag(QString activityTagName)
	{
		for (int i = 0; i < this.activityTagsList.size(); i++)
			if (this.activityTagsList.at(i).name == activityTagName)
				return i;

		return -1;
	}

	/**
	Removes this activity tag. In the list of activities, the activity tag will 
	be removed from all activities which posess it.
	It returns false on failure.
	If successful, returns true.
	*/
	private bool removeActivityTag(QString activityTagName)
	{
		//check the activities first
		for (int i = 0; i < this.activitiesList.size(); i++)
		{
			Activity act = this.activitiesList[i];

			//if( act->activityTagName == activityTagName)
			//	act->activityTagName="";
			if (act.activityTagsNames.contains(activityTagName))
				act.activityTagsNames.removeAll(activityTagName);
		}

		//delete the time constraints related to this activity tag
		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_ACTIVITY_TAG_MAX_HOURS_CONTINUOUSLY)
			{
				ConstraintTeacherActivityTagMaxHoursContinuously crt_constraint = (ConstraintTeacherActivityTagMaxHoursContinuously)ctr;
				if (activityTagName == crt_constraint.activityTagName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}
		//delete the time constraints related to this activity tag
		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_ACTIVITY_TAG_MAX_HOURS_DAILY)
			{
				ConstraintTeacherActivityTagMaxHoursDaily crt_constraint = (ConstraintTeacherActivityTagMaxHoursDaily)ctr;
				if (activityTagName == crt_constraint.activityTagName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}
		//delete the time constraints related to this activity tag
		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHERS_ACTIVITY_TAG_MAX_HOURS_CONTINUOUSLY)
			{
				ConstraintTeachersActivityTagMaxHoursContinuously crt_constraint = (ConstraintTeachersActivityTagMaxHoursContinuously)ctr;
				if (activityTagName == crt_constraint.activityTagName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}
		//delete the time constraints related to this activity tag
		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHERS_ACTIVITY_TAG_MAX_HOURS_DAILY)
			{
				ConstraintTeachersActivityTagMaxHoursDaily crt_constraint = (ConstraintTeachersActivityTagMaxHoursDaily)ctr;
				if (activityTagName == crt_constraint.activityTagName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}
		//delete the time constraints related to this activity tag
		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_ACTIVITY_TAG_MAX_HOURS_CONTINUOUSLY)
			{
				ConstraintStudentsActivityTagMaxHoursContinuously crt_constraint = (ConstraintStudentsActivityTagMaxHoursContinuously)ctr;
				if (activityTagName == crt_constraint.activityTagName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}
		//delete the time constraints related to this activity tag
		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_ACTIVITY_TAG_MAX_HOURS_DAILY)
			{
				ConstraintStudentsActivityTagMaxHoursDaily crt_constraint = (ConstraintStudentsActivityTagMaxHoursDaily)ctr;
				if (activityTagName == crt_constraint.activityTagName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}
		//delete the time constraints related to this activity tag
		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_ACTIVITY_TAG_MAX_HOURS_CONTINUOUSLY)
			{
				ConstraintStudentsSetActivityTagMaxHoursContinuously crt_constraint = (ConstraintStudentsSetActivityTagMaxHoursContinuously)ctr;
				if (activityTagName == crt_constraint.activityTagName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}
		//delete the time constraints related to this activity tag
		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_ACTIVITY_TAG_MAX_HOURS_DAILY)
			{
				ConstraintStudentsSetActivityTagMaxHoursDaily crt_constraint = (ConstraintStudentsSetActivityTagMaxHoursDaily)ctr;
				if (activityTagName == crt_constraint.activityTagName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}

		//delete the time constraints related to this activity tag
		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_PREFERRED_TIME_SLOTS)
			{
				ConstraintActivitiesPreferredTimeSlots crt_constraint = (ConstraintActivitiesPreferredTimeSlots)ctr;
				if (activityTagName == crt_constraint.p_activityTagName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}

		//delete the time constraints related to this activity tag
		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_PREFERRED_STARTING_TIMES)
			{
				ConstraintActivitiesPreferredStartingTimes crt_constraint = (ConstraintActivitiesPreferredStartingTimes)ctr;
				if (activityTagName == crt_constraint.activityTagName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}

		//delete the time constraints related to this activity tag
		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_END_STUDENTS_DAY)
			{
				ConstraintActivitiesEndStudentsDay crt_constraint = (ConstraintActivitiesEndStudentsDay)ctr;
				if (activityTagName == crt_constraint.activityTagName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}

		//delete the time constraints related to this activity tag
		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_SUBACTIVITIES_PREFERRED_TIME_SLOTS)
			{
				ConstraintSubactivitiesPreferredTimeSlots crt_constraint = (ConstraintSubactivitiesPreferredTimeSlots)ctr;
				if (activityTagName == crt_constraint.p_activityTagName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}

		//delete the time constraints related to this activity tag
		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_SUBACTIVITIES_PREFERRED_STARTING_TIMES)
			{
				ConstraintSubactivitiesPreferredStartingTimes crt_constraint = (ConstraintSubactivitiesPreferredStartingTimes)ctr;
				if (activityTagName == crt_constraint.activityTagName)
					this.removeTimeConstraint(ctr); //single constraint removal
				else
					i++;
			}
			else
				i++;
		}

		//delete the space constraints related to this activity tag
		for (int i = 0; i < this.spaceConstraintsList.size();)
		{
			SpaceConstraint ctr = this.spaceConstraintsList[i];

			if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_SUBJECT_ACTIVITY_TAG_PREFERRED_ROOM)
			{
				ConstraintSubjectActivityTagPreferredRoom c = (ConstraintSubjectActivityTagPreferredRoom)ctr;

				if (c.activityTagName == activityTagName)
					this.removeSpaceConstraint(ctr);
				else
					i++;
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_SUBJECT_ACTIVITY_TAG_PREFERRED_ROOMS)
			{
				ConstraintSubjectActivityTagPreferredRooms c = (ConstraintSubjectActivityTagPreferredRooms)ctr;

				if (c.activityTagName == activityTagName)
					this.removeSpaceConstraint(ctr);
				else
					i++;
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITY_TAG_PREFERRED_ROOM)
			{
				ConstraintActivityTagPreferredRoom c = (ConstraintActivityTagPreferredRoom)ctr;

				if (c.activityTagName == activityTagName)
					this.removeSpaceConstraint(ctr);
				else
					i++;
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITY_TAG_PREFERRED_ROOMS)
			{
				ConstraintActivityTagPreferredRooms c = (ConstraintActivityTagPreferredRooms)ctr;

				if (c.activityTagName == activityTagName)
					this.removeSpaceConstraint(ctr);
				else
					i++;
			}
			else
				i++;
		}

		//remove the activity tag from the list
		for (int i = 0; i < this.activityTagsList.size(); i++)
			if (this.activityTagsList[i].name == activityTagName)
			{
				ActivityTag sbt = this.activityTagsList[i];
				this.activityTagsList.removeAt(i);
				if (sbt != null)
					sbt.Dispose();
				break;
			}

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		teachers_schedule_ready = false;
		students_schedule_ready = false;
		rooms_schedule_ready = false;

		return true;
	}

	/**
	Modifies (renames) this activity tag and takes care of all related activities.
	Returns true on success, false on failure (if not found)
	*/
	private bool modifyActivityTag(QString initialActivityTagName, QString finalActivityTagName)
	{
		Debug.Assert(this.searchActivityTag(finalActivityTagName) == -1);
		Debug.Assert(this.searchActivityTag(initialActivityTagName) >= 0);

		//check the activities first
		for (int i = 0; i < this.activitiesList.size(); i++)
		{
			Activity act = this.activitiesList[i];

			//if( act->activityTagName == initialActivityTagName)
			//	act->activityTagName=finalActivityTagName;
			for (int kk = 0; kk < act.activityTagsNames.count(); kk++)
				if (act.activityTagsNames.at(kk) == initialActivityTagName)
					act.activityTagsNames[kk] = finalActivityTagName;
		}

		//modify the constraints related to this activity tag
		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_ACTIVITY_TAG_MAX_HOURS_CONTINUOUSLY)
			{
				ConstraintTeacherActivityTagMaxHoursContinuously crt_constraint = (ConstraintTeacherActivityTagMaxHoursContinuously)ctr;
				if (initialActivityTagName == crt_constraint.activityTagName)
					crt_constraint.activityTagName = finalActivityTagName;
			}
		}
		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_ACTIVITY_TAG_MAX_HOURS_DAILY)
			{
				ConstraintTeacherActivityTagMaxHoursDaily crt_constraint = (ConstraintTeacherActivityTagMaxHoursDaily)ctr;
				if (initialActivityTagName == crt_constraint.activityTagName)
					crt_constraint.activityTagName = finalActivityTagName;
			}
		}
		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHERS_ACTIVITY_TAG_MAX_HOURS_CONTINUOUSLY)
			{
				ConstraintTeachersActivityTagMaxHoursContinuously crt_constraint = (ConstraintTeachersActivityTagMaxHoursContinuously)ctr;
				if (initialActivityTagName == crt_constraint.activityTagName)
					crt_constraint.activityTagName = finalActivityTagName;
			}
		}
		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHERS_ACTIVITY_TAG_MAX_HOURS_DAILY)
			{
				ConstraintTeachersActivityTagMaxHoursDaily crt_constraint = (ConstraintTeachersActivityTagMaxHoursDaily)ctr;
				if (initialActivityTagName == crt_constraint.activityTagName)
					crt_constraint.activityTagName = finalActivityTagName;
			}
		}
		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_ACTIVITY_TAG_MAX_HOURS_CONTINUOUSLY)
			{
				ConstraintStudentsActivityTagMaxHoursContinuously crt_constraint = (ConstraintStudentsActivityTagMaxHoursContinuously)ctr;
				if (initialActivityTagName == crt_constraint.activityTagName)
					crt_constraint.activityTagName = finalActivityTagName;
			}
		}
		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_ACTIVITY_TAG_MAX_HOURS_DAILY)
			{
				ConstraintStudentsActivityTagMaxHoursDaily crt_constraint = (ConstraintStudentsActivityTagMaxHoursDaily)ctr;
				if (initialActivityTagName == crt_constraint.activityTagName)
					crt_constraint.activityTagName = finalActivityTagName;
			}
		}
		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_ACTIVITY_TAG_MAX_HOURS_CONTINUOUSLY)
			{
				ConstraintStudentsSetActivityTagMaxHoursContinuously crt_constraint = (ConstraintStudentsSetActivityTagMaxHoursContinuously)ctr;
				if (initialActivityTagName == crt_constraint.activityTagName)
					crt_constraint.activityTagName = finalActivityTagName;
			}
		}
		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_ACTIVITY_TAG_MAX_HOURS_DAILY)
			{
				ConstraintStudentsSetActivityTagMaxHoursDaily crt_constraint = (ConstraintStudentsSetActivityTagMaxHoursDaily)ctr;
				if (initialActivityTagName == crt_constraint.activityTagName)
					crt_constraint.activityTagName = finalActivityTagName;
			}
		}

		//modify the constraints related to this activity tag
		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_PREFERRED_TIME_SLOTS)
			{
				ConstraintActivitiesPreferredTimeSlots crt_constraint = (ConstraintActivitiesPreferredTimeSlots)ctr;
				if (initialActivityTagName == crt_constraint.p_activityTagName)
					crt_constraint.p_activityTagName = finalActivityTagName;
			}
		}

		//modify the constraints related to this activity tag
		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_PREFERRED_STARTING_TIMES)
			{
				ConstraintActivitiesPreferredStartingTimes crt_constraint = (ConstraintActivitiesPreferredStartingTimes)ctr;
				if (initialActivityTagName == crt_constraint.activityTagName)
					crt_constraint.activityTagName = finalActivityTagName;
			}
		}

		//modify the constraints related to this activity tag
		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_END_STUDENTS_DAY)
			{
				ConstraintActivitiesEndStudentsDay crt_constraint = (ConstraintActivitiesEndStudentsDay)ctr;
				if (initialActivityTagName == crt_constraint.activityTagName)
					crt_constraint.activityTagName = finalActivityTagName;
			}
		}

		//modify the constraints related to this activity tag
		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_SUBACTIVITIES_PREFERRED_TIME_SLOTS)
			{
				ConstraintSubactivitiesPreferredTimeSlots crt_constraint = (ConstraintSubactivitiesPreferredTimeSlots)ctr;
				if (initialActivityTagName == crt_constraint.p_activityTagName)
					crt_constraint.p_activityTagName = finalActivityTagName;
			}
		}

		//modify the constraints related to this activity tag
		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_SUBACTIVITIES_PREFERRED_STARTING_TIMES)
			{
				ConstraintSubactivitiesPreferredStartingTimes crt_constraint = (ConstraintSubactivitiesPreferredStartingTimes)ctr;
				if (initialActivityTagName == crt_constraint.activityTagName)
					crt_constraint.activityTagName = finalActivityTagName;
			}
		}

		//modify the space constraints related to this subject tag
		for (int i = 0; i < this.spaceConstraintsList.size(); i++)
		{
			SpaceConstraint ctr = this.spaceConstraintsList[i];

			if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_SUBJECT_ACTIVITY_TAG_PREFERRED_ROOM)
			{
				ConstraintSubjectActivityTagPreferredRoom c = (ConstraintSubjectActivityTagPreferredRoom)ctr;
				if (c.activityTagName == initialActivityTagName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: c->activityTagName=finalActivityTagName;
					c.activityTagName.CopyFrom(finalActivityTagName);
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_SUBJECT_ACTIVITY_TAG_PREFERRED_ROOMS)
			{
				ConstraintSubjectActivityTagPreferredRooms c = (ConstraintSubjectActivityTagPreferredRooms)ctr;
				if (c.activityTagName == initialActivityTagName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: c->activityTagName=finalActivityTagName;
					c.activityTagName.CopyFrom(finalActivityTagName);
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITY_TAG_PREFERRED_ROOM)
			{
				ConstraintActivityTagPreferredRoom c = (ConstraintActivityTagPreferredRoom)ctr;
				if (c.activityTagName == initialActivityTagName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: c->activityTagName=finalActivityTagName;
					c.activityTagName.CopyFrom(finalActivityTagName);
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITY_TAG_PREFERRED_ROOMS)
			{
				ConstraintActivityTagPreferredRooms c = (ConstraintActivityTagPreferredRooms)ctr;
				if (c.activityTagName == initialActivityTagName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: c->activityTagName=finalActivityTagName;
					c.activityTagName.CopyFrom(finalActivityTagName);
			}
		}

		//rename the activity tag in the list
		int t = 0;

		for (int i = 0; i < this.activityTagsList.size(); i++)
		{
			ActivityTag sbt = this.activityTagsList[i];

			if (sbt.name == initialActivityTagName)
			{
				t++;
				sbt.name = finalActivityTagName;
			}
		}

		Debug.Assert(t <= 1);

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		return true;
	}

	/**
	A function to sort the activity tags alphabetically
	*/
	private void sortActivityTagsAlphabetically()
	{
		qSort(this.activityTagsList.begin(), this.activityTagsList.end(), GlobalMembersActivitytag.activityTagsAscending);

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);
	}

	/**
	Returns a pointer to the structure containing this student set
	(year, group or subgroup) or NULL.
	*/
	private StudentsSet searchStudentsSet(QString setName)
	{
		for (int i = 0; i < this.yearsList.size(); i++)
		{
			StudentsYear sty = this.yearsList[i];
			if (sty.name == setName)
				return sty;
			for (int j = 0; j < sty.groupsList.size(); j++)
			{
				StudentsGroup stg = sty.groupsList[j];
				if (stg.name == setName)
					return stg;
				for (int k = 0; k < stg.subgroupsList.size(); k++)
				{
					StudentsSubgroup sts = stg.subgroupsList[k];
					if (sts.name == setName)
						return sts;
				}
			}
		}
		return null;
	}

	private StudentsSet searchAugmentedStudentsSet(QString setName)
	{
		for (int i = 0; i < this.augmentedYearsList.size(); i++)
		{
			StudentsYear sty = this.augmentedYearsList[i];
			if (sty.name == setName)
				return sty;
			for (int j = 0; j < sty.groupsList.size(); j++)
			{
				StudentsGroup stg = sty.groupsList[j];
				if (stg.name == setName)
					return stg;
				for (int k = 0; k < stg.subgroupsList.size(); k++)
				{
					StudentsSubgroup sts = stg.subgroupsList[k];
					if (sts.name == setName)
						return sts;
				}
			}
		}
		return null;
	}

	/**
	True if the students sets contain one common subgroup.
	This function is used in constraints isRelatedToStudentsSet
	*/
	private bool setsShareStudents(QString studentsSet1, QString studentsSet2)
	{
		StudentsSet s1 = this.searchStudentsSet(studentsSet1);
		StudentsSet s2 = this.searchStudentsSet(studentsSet2);
		Debug.Assert(s1 != null);
		Debug.Assert(s2 != null);

		QSet<QString> downwardSets1 = new QSet<QString>();

		if (s1.type == GlobalMembersStudentsset.STUDENTS_YEAR)
		{
			StudentsYear year1 = (StudentsYear)s1;
			downwardSets1.insert(year1.name);
			foreach (StudentsGroup * group1, year1.groupsList)
			{
				downwardSets1.insert(group1.name);
				foreach (StudentsSubgroup * subgroup1, group1.subgroupsList) downwardSets1.insert(subgroup1.name);
			}
		}
		else if (s1.type == GlobalMembersStudentsset.STUDENTS_GROUP)
		{
			StudentsGroup group1 = (StudentsGroup)s1;
			downwardSets1.insert(group1.name);
			foreach (StudentsSubgroup * subgroup1, group1.subgroupsList) downwardSets1.insert(subgroup1.name);
		}
		else if (s1.type == GlobalMembersStudentsset.STUDENTS_SUBGROUP)
		{
			StudentsSubgroup subgroup1 = (StudentsSubgroup)s1;
			downwardSets1.insert(subgroup1.name);
		}
		else
			Debug.Assert(0);

		if (s2.type == GlobalMembersStudentsset.STUDENTS_YEAR)
		{
			StudentsYear year2 = (StudentsYear)s2;
			if (downwardSets1.contains(year2.name))
				return true;
			foreach (StudentsGroup * group2, year2.groupsList)
			{
				if (downwardSets1.contains(group2.name))
					return true;
				foreach (StudentsSubgroup * subgroup2, group2.subgroupsList) if (downwardSets1.contains(subgroup2.name)) return true;
			}
		}
		else if (s2.type == GlobalMembersStudentsset.STUDENTS_GROUP)
		{
			StudentsGroup group2 = (StudentsGroup)s2;
			if (downwardSets1.contains(group2.name))
				return true;
			foreach (StudentsSubgroup * subgroup2, group2.subgroupsList) if (downwardSets1.contains(subgroup2.name)) return true;
		}
		else if (s2.type == GlobalMembersStudentsset.STUDENTS_SUBGROUP)
		{
			StudentsSubgroup subgroup2 = (StudentsSubgroup)s2;
			if (downwardSets1.contains(subgroup2.name))
				return true;
		}
		else
			Debug.Assert(0);

		return false;

	}

	/**
	Adds a new year of study to the academic structure
	*/
	private bool addYear(StudentsYear year)
	{
		//already existing?
		if (this.searchStudentsSet(year.name) != null)
			return false;
		this.yearsList << year;
		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);
		return true;
	}

	/*
	When reading rules, faster
	*/
	private bool addYearFast(StudentsYear year)
	{
		this.yearsList << year;
		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);
		return true;
	}

	private bool removeYear(QString yearName)
	{
		StudentsYear year = null;
		foreach (StudentsYear * ty, this.yearsList)
		{
			if (ty.name == yearName)
			{
				year = ty;
				break;
			}
		}

		//StudentsYear* year=(StudentsYear*)searchStudentsSet(yearName);
		Debug.Assert(year != null);
		int nStudents = year.numberOfStudents;
		while (year.groupsList.size() > 0)
		{
			QString groupName = year.groupsList[0].name;
			this.removeGroup(yearName, groupName);
		}

		for (int i = 0; i < this.activitiesList.size();)
		{
			Activity act = this.activitiesList[i];
			bool t = act.removeStudents(this, yearName, nStudents);

			if (t && act.studentsNames.count() == 0)
			{
				this.removeActivity(act.id, act.activityGroupId);
				i = 0;
				//(You have to be careful, there can be erased more activities here)
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			bool erased = false;

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_NOT_AVAILABLE_TIMES)
			{
				ConstraintStudentsSetNotAvailableTimes crt_constraint = (ConstraintStudentsSetNotAvailableTimes)ctr;
				if (yearName == crt_constraint.students)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_HOURS_DAILY)
			{
				ConstraintStudentsSetMaxHoursDaily crt_constraint = (ConstraintStudentsSetMaxHoursDaily)ctr;
				if (yearName == crt_constraint.students)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_INTERVAL_MAX_DAYS_PER_WEEK)
			{
				ConstraintStudentsSetIntervalMaxDaysPerWeek crt_constraint = (ConstraintStudentsSetIntervalMaxDaysPerWeek)ctr;
				if (yearName == crt_constraint.students)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_HOURS_CONTINUOUSLY)
			{
				ConstraintStudentsSetMaxHoursContinuously crt_constraint = (ConstraintStudentsSetMaxHoursContinuously)ctr;
				if (yearName == crt_constraint.students)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_ACTIVITY_TAG_MAX_HOURS_CONTINUOUSLY)
			{
				ConstraintStudentsSetActivityTagMaxHoursContinuously crt_constraint = (ConstraintStudentsSetActivityTagMaxHoursContinuously)ctr;
				if (yearName == crt_constraint.students)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_ACTIVITY_TAG_MAX_HOURS_DAILY)
			{
				ConstraintStudentsSetActivityTagMaxHoursDaily crt_constraint = (ConstraintStudentsSetActivityTagMaxHoursDaily)ctr;
				if (yearName == crt_constraint.students)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MIN_HOURS_DAILY)
			{
				ConstraintStudentsSetMinHoursDaily crt_constraint = (ConstraintStudentsSetMinHoursDaily)ctr;
				if (yearName == crt_constraint.students)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_EARLY_MAX_BEGINNINGS_AT_SECOND_HOUR)
			{
				ConstraintStudentsSetEarlyMaxBeginningsAtSecondHour crt_constraint = (ConstraintStudentsSetEarlyMaxBeginningsAtSecondHour)ctr;
				if (yearName == crt_constraint.students)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_GAPS_PER_WEEK)
			{
				ConstraintStudentsSetMaxGapsPerWeek crt_constraint = (ConstraintStudentsSetMaxGapsPerWeek)ctr;
				if (yearName == crt_constraint.students)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_GAPS_PER_DAY)
			{
				ConstraintStudentsSetMaxGapsPerDay crt_constraint = (ConstraintStudentsSetMaxGapsPerDay)ctr;
				if (yearName == crt_constraint.students)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_PREFERRED_TIME_SLOTS)
			{
				ConstraintActivitiesPreferredTimeSlots crt_constraint = (ConstraintActivitiesPreferredTimeSlots)ctr;
				if (yearName == crt_constraint.p_studentsName)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_PREFERRED_STARTING_TIMES)
			{
				ConstraintActivitiesPreferredStartingTimes crt_constraint = (ConstraintActivitiesPreferredStartingTimes)ctr;
				if (yearName == crt_constraint.studentsName)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_END_STUDENTS_DAY)
			{
				ConstraintActivitiesEndStudentsDay crt_constraint = (ConstraintActivitiesEndStudentsDay)ctr;
				if (yearName == crt_constraint.studentsName)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_SUBACTIVITIES_PREFERRED_TIME_SLOTS)
			{
				ConstraintSubactivitiesPreferredTimeSlots crt_constraint = (ConstraintSubactivitiesPreferredTimeSlots)ctr;
				if (yearName == crt_constraint.p_studentsName)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_SUBACTIVITIES_PREFERRED_STARTING_TIMES)
			{
				ConstraintSubactivitiesPreferredStartingTimes crt_constraint = (ConstraintSubactivitiesPreferredStartingTimes)ctr;
				if (yearName == crt_constraint.studentsName)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}

			if (!erased)
				i++;
		}

		for (int i = 0; i < this.spaceConstraintsList.size();)
		{
			SpaceConstraint ctr = this.spaceConstraintsList[i];

			bool erased = false;

			if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_HOME_ROOM)
			{
				ConstraintStudentsSetHomeRoom crt_constraint = (ConstraintStudentsSetHomeRoom)ctr;
				if (yearName == crt_constraint.studentsName)
				{
					this.removeSpaceConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_HOME_ROOMS)
			{
				ConstraintStudentsSetHomeRooms crt_constraint = (ConstraintStudentsSetHomeRooms)ctr;
				if (yearName == crt_constraint.studentsName)
				{
					this.removeSpaceConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_MAX_BUILDING_CHANGES_PER_DAY)
			{
				ConstraintStudentsSetMaxBuildingChangesPerDay crt_constraint = (ConstraintStudentsSetMaxBuildingChangesPerDay)ctr;
				if (yearName == crt_constraint.studentsName)
				{
					this.removeSpaceConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_MAX_BUILDING_CHANGES_PER_WEEK)
			{
				ConstraintStudentsSetMaxBuildingChangesPerWeek crt_constraint = (ConstraintStudentsSetMaxBuildingChangesPerWeek)ctr;
				if (yearName == crt_constraint.studentsName)
				{
					this.removeSpaceConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_MIN_GAPS_BETWEEN_BUILDING_CHANGES)
			{
				ConstraintStudentsSetMinGapsBetweenBuildingChanges crt_constraint = (ConstraintStudentsSetMinGapsBetweenBuildingChanges)ctr;
				if (yearName == crt_constraint.studentsName)
				{
					this.removeSpaceConstraint(ctr);
					erased = true;
				}
			}

			if (!erased)
				i++;
		}

		for (int i = 0; i < this.yearsList.size(); i++)
			if (this.yearsList.at(i).name == yearName)
			{
				this.yearsList[i] = null; //added in version 4.0.2
				this.yearsList.removeAt(i);
				break;
			}

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);
		return true;
	}

	/**
	Returns -1 if not found or the index of this year in the years list
	*/
	private int searchYear(QString yearName)
	{
		for (int i = 0; i < this.yearsList.size(); i++)
			if (this.yearsList[i].name == yearName)
				return i;

		return -1;
	}

	private int searchAugmentedYear(QString yearName)
	{
		for (int i = 0; i < this.augmentedYearsList.size(); i++)
			if (this.augmentedYearsList[i].name == yearName)
				return i;

		return -1;
	}

	/**
	Modifies this students year (name, number of students) and takes care of all related 
	activities and constraints.	Returns true on success, false on failure (if not found)
	*/
	private bool modifyYear(QString initialYearName, QString finalYearName, int finalNumberOfStudents)
	{
		StudentsSet _initialSet = searchStudentsSet(initialYearName);
		Debug.Assert(_initialSet != null);
		int _initialNumberOfStudents = _initialSet.numberOfStudents;

//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: QString _initialYearName=initialYearName;
		QString _initialYearName = new QString(initialYearName);

		Debug.Assert(searchYear(_initialYearName) >= 0);
//C++ TO C# CONVERTER NOTE: Segment register keywords are not supported in C#:
//ORIGINAL LINE: StudentsSet* _ss=searchStudentsSet(finalYearName);
		StudentsSet _ss = searchStudentsSet(finalYearName);
		Debug.Assert(_ss == null || _initialYearName == finalYearName);

		for (int i = 0; i < this.activitiesList.size(); i++)
		{
			Activity act = this.activitiesList[i];
			act.renameStudents(this, _initialYearName, finalYearName, _initialNumberOfStudents, finalNumberOfStudents);
		}

		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_NOT_AVAILABLE_TIMES)
			{
				ConstraintStudentsSetNotAvailableTimes crt_constraint = (ConstraintStudentsSetNotAvailableTimes)ctr;
				if (_initialYearName == crt_constraint.students)
					crt_constraint.students = finalYearName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_HOURS_DAILY)
			{
				ConstraintStudentsSetMaxHoursDaily crt_constraint = (ConstraintStudentsSetMaxHoursDaily)ctr;
				if (_initialYearName == crt_constraint.students)
					crt_constraint.students = finalYearName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_INTERVAL_MAX_DAYS_PER_WEEK)
			{
				ConstraintStudentsSetIntervalMaxDaysPerWeek crt_constraint = (ConstraintStudentsSetIntervalMaxDaysPerWeek)ctr;
				if (_initialYearName == crt_constraint.students)
					crt_constraint.students = finalYearName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_HOURS_CONTINUOUSLY)
			{
				ConstraintStudentsSetMaxHoursContinuously crt_constraint = (ConstraintStudentsSetMaxHoursContinuously)ctr;
				if (_initialYearName == crt_constraint.students)
					crt_constraint.students = finalYearName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_ACTIVITY_TAG_MAX_HOURS_CONTINUOUSLY)
			{
				ConstraintStudentsSetActivityTagMaxHoursContinuously crt_constraint = (ConstraintStudentsSetActivityTagMaxHoursContinuously)ctr;
				if (_initialYearName == crt_constraint.students)
					crt_constraint.students = finalYearName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_ACTIVITY_TAG_MAX_HOURS_DAILY)
			{
				ConstraintStudentsSetActivityTagMaxHoursDaily crt_constraint = (ConstraintStudentsSetActivityTagMaxHoursDaily)ctr;
				if (_initialYearName == crt_constraint.students)
					crt_constraint.students = finalYearName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MIN_HOURS_DAILY)
			{
				ConstraintStudentsSetMinHoursDaily crt_constraint = (ConstraintStudentsSetMinHoursDaily)ctr;
				if (_initialYearName == crt_constraint.students)
					crt_constraint.students = finalYearName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_EARLY_MAX_BEGINNINGS_AT_SECOND_HOUR)
			{
				ConstraintStudentsSetEarlyMaxBeginningsAtSecondHour crt_constraint = (ConstraintStudentsSetEarlyMaxBeginningsAtSecondHour)ctr;
				if (_initialYearName == crt_constraint.students)
					crt_constraint.students = finalYearName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_GAPS_PER_WEEK)
			{
				ConstraintStudentsSetMaxGapsPerWeek crt_constraint = (ConstraintStudentsSetMaxGapsPerWeek)ctr;
				if (_initialYearName == crt_constraint.students)
					crt_constraint.students = finalYearName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_GAPS_PER_DAY)
			{
				ConstraintStudentsSetMaxGapsPerDay crt_constraint = (ConstraintStudentsSetMaxGapsPerDay)ctr;
				if (_initialYearName == crt_constraint.students)
					crt_constraint.students = finalYearName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_PREFERRED_TIME_SLOTS)
			{
				ConstraintActivitiesPreferredTimeSlots crt_constraint = (ConstraintActivitiesPreferredTimeSlots)ctr;
				if (_initialYearName == crt_constraint.p_studentsName)
					crt_constraint.p_studentsName = finalYearName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_PREFERRED_STARTING_TIMES)
			{
				ConstraintActivitiesPreferredStartingTimes crt_constraint = (ConstraintActivitiesPreferredStartingTimes)ctr;
				if (_initialYearName == crt_constraint.studentsName)
					crt_constraint.studentsName = finalYearName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_END_STUDENTS_DAY)
			{
				ConstraintActivitiesEndStudentsDay crt_constraint = (ConstraintActivitiesEndStudentsDay)ctr;
				if (_initialYearName == crt_constraint.studentsName)
					crt_constraint.studentsName = finalYearName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_SUBACTIVITIES_PREFERRED_TIME_SLOTS)
			{
				ConstraintSubactivitiesPreferredTimeSlots crt_constraint = (ConstraintSubactivitiesPreferredTimeSlots)ctr;
				if (_initialYearName == crt_constraint.p_studentsName)
					crt_constraint.p_studentsName = finalYearName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_SUBACTIVITIES_PREFERRED_STARTING_TIMES)
			{
				ConstraintSubactivitiesPreferredStartingTimes crt_constraint = (ConstraintSubactivitiesPreferredStartingTimes)ctr;
				if (_initialYearName == crt_constraint.studentsName)
					crt_constraint.studentsName = finalYearName;
			}
		}

		for (int i = 0; i < this.spaceConstraintsList.size(); i++)
		{
			SpaceConstraint ctr = this.spaceConstraintsList[i];

			if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_HOME_ROOM)
			{
				ConstraintStudentsSetHomeRoom crt_constraint = (ConstraintStudentsSetHomeRoom)ctr;
				if (_initialYearName == crt_constraint.studentsName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: crt_constraint->studentsName=finalYearName;
					crt_constraint.studentsName.CopyFrom(finalYearName);
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_HOME_ROOMS)
			{
				ConstraintStudentsSetHomeRooms crt_constraint = (ConstraintStudentsSetHomeRooms)ctr;
				if (_initialYearName == crt_constraint.studentsName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: crt_constraint->studentsName=finalYearName;
					crt_constraint.studentsName.CopyFrom(finalYearName);
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_MAX_BUILDING_CHANGES_PER_DAY)
			{
				ConstraintStudentsSetMaxBuildingChangesPerDay crt_constraint = (ConstraintStudentsSetMaxBuildingChangesPerDay)ctr;
				if (_initialYearName == crt_constraint.studentsName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: crt_constraint->studentsName=finalYearName;
					crt_constraint.studentsName.CopyFrom(finalYearName);
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_MAX_BUILDING_CHANGES_PER_WEEK)
			{
				ConstraintStudentsSetMaxBuildingChangesPerWeek crt_constraint = (ConstraintStudentsSetMaxBuildingChangesPerWeek)ctr;
				if (_initialYearName == crt_constraint.studentsName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: crt_constraint->studentsName=finalYearName;
					crt_constraint.studentsName.CopyFrom(finalYearName);
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_MIN_GAPS_BETWEEN_BUILDING_CHANGES)
			{
				ConstraintStudentsSetMinGapsBetweenBuildingChanges crt_constraint = (ConstraintStudentsSetMinGapsBetweenBuildingChanges)ctr;
				if (_initialYearName == crt_constraint.studentsName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: crt_constraint->studentsName=finalYearName;
					crt_constraint.studentsName.CopyFrom(finalYearName);
			}
		}

		int t = 0;

		for (int i = 0; i < this.yearsList.size(); i++)
		{
			StudentsYear sty = this.yearsList[i];

			if (sty.name == _initialYearName)
			{
				sty.name = finalYearName;
				sty.numberOfStudents = finalNumberOfStudents;
				t++;

				/*for(int j=0; j<sty->groupsList.size(); j++){
					StudentsGroup* stg=sty->groupsList[j];
	
					if(stg->name.right(11)==" WHOLE YEAR" && stg->name.left(stg->name.length()-11)==_initialYearName)
						this->modifyGroup(sty->name, stg->name, sty->name+" WHOLE YEAR", stg->numberOfStudents);
				}*/
			}
		}

		Debug.Assert(t <= 1);

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		if (t == 0)
			return false;
		else
			return true;
	}

	/**
	A function to sort the years alphabetically
	*/
	private void sortYearsAlphabetically()
	{
		qSort(this.yearsList.begin(), this.yearsList.end(), GlobalMembersStudentsset.yearsAscending);

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);
	}

	/**
	Adds a new group in a certain year of study to the academic structure
	*/
	private bool addGroup(QString yearName, StudentsGroup group)
	{
		StudentsYear sty = null;
		for (int i = 0; i < this.yearsList.size(); i++)
		{
			sty = yearsList[i];
			if (sty.name == yearName)
				break;
		}
		Debug.Assert(sty);

		for (int i = 0; i < sty.groupsList.size(); i++)
		{
			StudentsGroup stg = sty.groupsList[i];
			if (stg.name == group.name)
				return false;
		}

		sty.groupsList << group; //append

		/*
		foreach(StudentsYear* y, yearsList)
			foreach(StudentsGroup* g, y->groupsList)
				if(g->name==group->name)
					g->numberOfStudents=group->numberOfStudents;*/

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);
		return true;
	}

	/*
	When reading rules, faster
	*/
	private bool addGroupFast(StudentsYear year, StudentsGroup group)
	{
		year.groupsList << group; //append

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);
		return true;
	}

	private bool removeGroup(QString yearName, QString groupName)
	{
		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		StudentsYear year = null;
		foreach (StudentsYear * ty, this.yearsList)
		{
			if (ty.name == yearName)
			{
				year = ty;
				break;
			}
		}
		Debug.Assert(year != null);

		StudentsGroup group = null;
		foreach (StudentsGroup * tg, year.groupsList)
		{
			if (tg.name == groupName)
			{
				group = tg;
				break;
			}
		}

		//StudentsGroup* group=(StudentsGroup*)searchStudentsSet(groupName);
		Debug.Assert(group != null);
		int nStudents = group.numberOfStudents;

		bool stillExistsWithSamePointer = false;
		foreach (StudentsYear * ty, this.yearsList)
		{
			if (ty.name != yearName)
			{
				foreach (StudentsGroup * tg, ty.groupsList)
				{
					if (tg == group)
					{
						stillExistsWithSamePointer = true;
						break;
					}
				}
			}
			if (stillExistsWithSamePointer)
				break;
		}

		if (!stillExistsWithSamePointer)
		{
			while (group.subgroupsList.size() > 0)
			{
				QString subgroupName = group.subgroupsList[0].name;
				this.removeSubgroup(yearName, groupName, subgroupName);
			}
		}

		StudentsYear sty = null;
		for (int i = 0; i < this.yearsList.size(); i++)
		{
			sty = yearsList[i];
			if (sty.name == yearName)
				break;
		}
		Debug.Assert(sty);
		Debug.Assert(sty == year);

		StudentsGroup stg = null;
		for (int i = 0; i < sty.groupsList.size(); i++)
		{
			stg = sty.groupsList[i];
			if (stg.name == groupName)
			{
				sty.groupsList.removeAt(i);
				break;
			}
		}

		if (this.searchStudentsSet(stg.name) != null)
		{
			//group still exists

			//with the same pointer??? (leak bug fix on 6 Jan 2010 in FET-5.12.1)
			bool foundSamePointer = false;
			foreach (StudentsYear year, yearsList)
			{
				foreach (StudentsGroup group, year.groupsList)
				{
					if (group == stg)
					{
						foundSamePointer = true;
						break;
					}
				}
				if (foundSamePointer)
					break;
			}

			if (!foundSamePointer)
				if (stg != null)
					stg.Dispose();
			/////////////////////////////////////////////////////////////////////

			return true;
		}

		if (stg != null)
			stg.Dispose();

		for (int i = 0; i < this.activitiesList.size();)
		{
			Activity act = this.activitiesList[i];

			bool t = act.removeStudents(this, groupName, nStudents);
			if (t && act.studentsNames.count() == 0)
			{
				this.removeActivity(act.id, act.activityGroupId);
				i = 0;
				//(You have to be careful, there can be erased more activities here)
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			bool erased = false;
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_NOT_AVAILABLE_TIMES)
			{
				ConstraintStudentsSetNotAvailableTimes crt_constraint = (ConstraintStudentsSetNotAvailableTimes)ctr;
				if (groupName == crt_constraint.students)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_HOURS_DAILY)
			{
				ConstraintStudentsSetMaxHoursDaily crt_constraint = (ConstraintStudentsSetMaxHoursDaily)ctr;
				if (groupName == crt_constraint.students)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_INTERVAL_MAX_DAYS_PER_WEEK)
			{
				ConstraintStudentsSetIntervalMaxDaysPerWeek crt_constraint = (ConstraintStudentsSetIntervalMaxDaysPerWeek)ctr;
				if (groupName == crt_constraint.students)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_HOURS_CONTINUOUSLY)
			{
				ConstraintStudentsSetMaxHoursContinuously crt_constraint = (ConstraintStudentsSetMaxHoursContinuously)ctr;
				if (groupName == crt_constraint.students)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_ACTIVITY_TAG_MAX_HOURS_CONTINUOUSLY)
			{
				ConstraintStudentsSetActivityTagMaxHoursContinuously crt_constraint = (ConstraintStudentsSetActivityTagMaxHoursContinuously)ctr;
				if (groupName == crt_constraint.students)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_ACTIVITY_TAG_MAX_HOURS_DAILY)
			{
				ConstraintStudentsSetActivityTagMaxHoursDaily crt_constraint = (ConstraintStudentsSetActivityTagMaxHoursDaily)ctr;
				if (groupName == crt_constraint.students)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MIN_HOURS_DAILY)
			{
				ConstraintStudentsSetMinHoursDaily crt_constraint = (ConstraintStudentsSetMinHoursDaily)ctr;
				if (groupName == crt_constraint.students)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_EARLY_MAX_BEGINNINGS_AT_SECOND_HOUR)
			{
				ConstraintStudentsSetEarlyMaxBeginningsAtSecondHour crt_constraint = (ConstraintStudentsSetEarlyMaxBeginningsAtSecondHour)ctr;
				if (groupName == crt_constraint.students)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_GAPS_PER_WEEK)
			{
				ConstraintStudentsSetMaxGapsPerWeek crt_constraint = (ConstraintStudentsSetMaxGapsPerWeek)ctr;
				if (groupName == crt_constraint.students)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_GAPS_PER_DAY)
			{
				ConstraintStudentsSetMaxGapsPerDay crt_constraint = (ConstraintStudentsSetMaxGapsPerDay)ctr;
				if (groupName == crt_constraint.students)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_PREFERRED_TIME_SLOTS)
			{
				ConstraintActivitiesPreferredTimeSlots crt_constraint = (ConstraintActivitiesPreferredTimeSlots)ctr;
				if (groupName == crt_constraint.p_studentsName)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_PREFERRED_STARTING_TIMES)
			{
				ConstraintActivitiesPreferredStartingTimes crt_constraint = (ConstraintActivitiesPreferredStartingTimes)ctr;
				if (groupName == crt_constraint.studentsName)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_END_STUDENTS_DAY)
			{
				ConstraintActivitiesEndStudentsDay crt_constraint = (ConstraintActivitiesEndStudentsDay)ctr;
				if (groupName == crt_constraint.studentsName)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_SUBACTIVITIES_PREFERRED_TIME_SLOTS)
			{
				ConstraintSubactivitiesPreferredTimeSlots crt_constraint = (ConstraintSubactivitiesPreferredTimeSlots)ctr;
				if (groupName == crt_constraint.p_studentsName)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_SUBACTIVITIES_PREFERRED_STARTING_TIMES)
			{
				ConstraintSubactivitiesPreferredStartingTimes crt_constraint = (ConstraintSubactivitiesPreferredStartingTimes)ctr;
				if (groupName == crt_constraint.studentsName)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}

			if (!erased)
				i++;
		}

		for (int i = 0; i < this.spaceConstraintsList.size();)
		{
			SpaceConstraint ctr = this.spaceConstraintsList[i];

			bool erased = false;
			if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_HOME_ROOM)
			{
				ConstraintStudentsSetHomeRoom crt_constraint = (ConstraintStudentsSetHomeRoom)ctr;
				if (groupName == crt_constraint.studentsName)
				{
					this.removeSpaceConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_HOME_ROOMS)
			{
				ConstraintStudentsSetHomeRooms crt_constraint = (ConstraintStudentsSetHomeRooms)ctr;
				if (groupName == crt_constraint.studentsName)
				{
					this.removeSpaceConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_MAX_BUILDING_CHANGES_PER_DAY)
			{
				ConstraintStudentsSetMaxBuildingChangesPerDay crt_constraint = (ConstraintStudentsSetMaxBuildingChangesPerDay)ctr;
				if (groupName == crt_constraint.studentsName)
				{
					this.removeSpaceConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_MAX_BUILDING_CHANGES_PER_WEEK)
			{
				ConstraintStudentsSetMaxBuildingChangesPerWeek crt_constraint = (ConstraintStudentsSetMaxBuildingChangesPerWeek)ctr;
				if (groupName == crt_constraint.studentsName)
				{
					this.removeSpaceConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_MIN_GAPS_BETWEEN_BUILDING_CHANGES)
			{
				ConstraintStudentsSetMinGapsBetweenBuildingChanges crt_constraint = (ConstraintStudentsSetMinGapsBetweenBuildingChanges)ctr;
				if (groupName == crt_constraint.studentsName)
				{
					this.removeSpaceConstraint(ctr);
					erased = true;
				}
			}

			if (!erased)
				i++;
		}

		return true;
	}

	/**
	Returns -1 if not found or the index of this group in the groups list
	of this year.
	*/
	private int searchGroup(QString yearName, QString groupName)
	{
		StudentsYear sty = this.yearsList[this.searchYear(yearName)];
		Debug.Assert(sty);

		for (int i = 0; i < sty.groupsList.size(); i++)
			if (sty.groupsList[i].name == groupName)
				return i;

		return -1;
	}

	private int searchAugmentedGroup(QString yearName, QString groupName)
	{
		StudentsYear sty = this.augmentedYearsList[this.searchAugmentedYear(yearName)];
		Debug.Assert(sty);

		for (int i = 0; i < sty.groupsList.size(); i++)
			if (sty.groupsList[i].name == groupName)
				return i;

		return -1;
	}

	/**
	Modifies this students group (name, number of students) and takes care of all related 
	activities and constraints.	Returns true on success, false on failure (if not found)
	*/
	private bool modifyGroup(QString yearName, QString initialGroupName, QString finalGroupName, int finalNumberOfStudents)
	{
		StudentsSet _initialSet = searchStudentsSet(initialGroupName);
		Debug.Assert(_initialSet != null);
		int _initialNumberOfStudents = _initialSet.numberOfStudents;

		//cout<<"Begin: initialGroupName=='"<<qPrintableinitialGroupName<<"'"<<endl;

//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: QString _initialGroupName=initialGroupName;
		QString _initialGroupName = new QString(initialGroupName);

		Debug.Assert(searchGroup(yearName, _initialGroupName) >= 0);
//C++ TO C# CONVERTER NOTE: Segment register keywords are not supported in C#:
//ORIGINAL LINE: StudentsSet* _ss=searchStudentsSet(finalGroupName);
		StudentsSet _ss = searchStudentsSet(finalGroupName);
		Debug.Assert(_ss == null || _initialGroupName == finalGroupName);

		StudentsYear sty = null;
		for (int i = 0; i < this.yearsList.size(); i++)
		{
			sty = this.yearsList[i];
			if (sty.name == yearName)
				break;
		}
		Debug.Assert(sty);

		StudentsGroup stg = null;
		for (int i = 0; i < sty.groupsList.size(); i++)
		{
			stg = sty.groupsList[i];
			if (stg.name == _initialGroupName)
			{
				stg.name = finalGroupName;
				stg.numberOfStudents = finalNumberOfStudents;

				break;
			}
		}
		Debug.Assert(stg);

		if (_ss != null) //In case it only changes the number of students, make the same number of students in all groups with this name
		{
			Debug.Assert(_initialGroupName == finalGroupName);
			foreach (StudentsYear * year, yearsList) foreach (StudentsGroup * group, year.groupsList) if (group.name == finalGroupName) group.numberOfStudents = finalNumberOfStudents;
		}

		for (int i = 0; i < this.activitiesList.size(); i++)
			this.activitiesList[i].renameStudents(this, _initialGroupName, finalGroupName, _initialNumberOfStudents, finalNumberOfStudents);

		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_NOT_AVAILABLE_TIMES)
			{
				ConstraintStudentsSetNotAvailableTimes crt_constraint = (ConstraintStudentsSetNotAvailableTimes)ctr;
				if (_initialGroupName == crt_constraint.students)
					crt_constraint.students = finalGroupName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_HOURS_DAILY)
			{
				ConstraintStudentsSetMaxHoursDaily crt_constraint = (ConstraintStudentsSetMaxHoursDaily)ctr;
				if (_initialGroupName == crt_constraint.students)
					crt_constraint.students = finalGroupName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_INTERVAL_MAX_DAYS_PER_WEEK)
			{
				ConstraintStudentsSetIntervalMaxDaysPerWeek crt_constraint = (ConstraintStudentsSetIntervalMaxDaysPerWeek)ctr;
				if (_initialGroupName == crt_constraint.students)
					crt_constraint.students = finalGroupName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_HOURS_CONTINUOUSLY)
			{
				ConstraintStudentsSetMaxHoursContinuously crt_constraint = (ConstraintStudentsSetMaxHoursContinuously)ctr;
				if (_initialGroupName == crt_constraint.students)
					crt_constraint.students = finalGroupName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_ACTIVITY_TAG_MAX_HOURS_CONTINUOUSLY)
			{
				ConstraintStudentsSetActivityTagMaxHoursContinuously crt_constraint = (ConstraintStudentsSetActivityTagMaxHoursContinuously)ctr;
				if (_initialGroupName == crt_constraint.students)
					crt_constraint.students = finalGroupName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_ACTIVITY_TAG_MAX_HOURS_DAILY)
			{
				ConstraintStudentsSetActivityTagMaxHoursDaily crt_constraint = (ConstraintStudentsSetActivityTagMaxHoursDaily)ctr;
				if (_initialGroupName == crt_constraint.students)
					crt_constraint.students = finalGroupName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MIN_HOURS_DAILY)
			{
				ConstraintStudentsSetMinHoursDaily crt_constraint = (ConstraintStudentsSetMinHoursDaily)ctr;
				if (_initialGroupName == crt_constraint.students)
					crt_constraint.students = finalGroupName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_EARLY_MAX_BEGINNINGS_AT_SECOND_HOUR)
			{
				ConstraintStudentsSetEarlyMaxBeginningsAtSecondHour crt_constraint = (ConstraintStudentsSetEarlyMaxBeginningsAtSecondHour)ctr;
				if (_initialGroupName == crt_constraint.students)
					crt_constraint.students = finalGroupName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_GAPS_PER_WEEK)
			{
				ConstraintStudentsSetMaxGapsPerWeek crt_constraint = (ConstraintStudentsSetMaxGapsPerWeek)ctr;
				if (_initialGroupName == crt_constraint.students)
					crt_constraint.students = finalGroupName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_GAPS_PER_DAY)
			{
				ConstraintStudentsSetMaxGapsPerDay crt_constraint = (ConstraintStudentsSetMaxGapsPerDay)ctr;
				if (_initialGroupName == crt_constraint.students)
					crt_constraint.students = finalGroupName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_PREFERRED_TIME_SLOTS)
			{
				ConstraintActivitiesPreferredTimeSlots crt_constraint = (ConstraintActivitiesPreferredTimeSlots)ctr;
				if (_initialGroupName == crt_constraint.p_studentsName)
					crt_constraint.p_studentsName = finalGroupName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_PREFERRED_STARTING_TIMES)
			{
				ConstraintActivitiesPreferredStartingTimes crt_constraint = (ConstraintActivitiesPreferredStartingTimes)ctr;
				if (_initialGroupName == crt_constraint.studentsName)
					crt_constraint.studentsName = finalGroupName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_END_STUDENTS_DAY)
			{
				ConstraintActivitiesEndStudentsDay crt_constraint = (ConstraintActivitiesEndStudentsDay)ctr;
				if (_initialGroupName == crt_constraint.studentsName)
					crt_constraint.studentsName = finalGroupName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_SUBACTIVITIES_PREFERRED_TIME_SLOTS)
			{
				ConstraintSubactivitiesPreferredTimeSlots crt_constraint = (ConstraintSubactivitiesPreferredTimeSlots)ctr;
				if (_initialGroupName == crt_constraint.p_studentsName)
					crt_constraint.p_studentsName = finalGroupName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_SUBACTIVITIES_PREFERRED_STARTING_TIMES)
			{
				ConstraintSubactivitiesPreferredStartingTimes crt_constraint = (ConstraintSubactivitiesPreferredStartingTimes)ctr;
				if (_initialGroupName == crt_constraint.studentsName)
					crt_constraint.studentsName = finalGroupName;
			}
		}

		for (int i = 0; i < this.spaceConstraintsList.size(); i++)
		{
			SpaceConstraint ctr = this.spaceConstraintsList[i];

			if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_HOME_ROOM)
			{
				ConstraintStudentsSetHomeRoom crt_constraint = (ConstraintStudentsSetHomeRoom)ctr;
				if (_initialGroupName == crt_constraint.studentsName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: crt_constraint->studentsName=finalGroupName;
					crt_constraint.studentsName.CopyFrom(finalGroupName);
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_HOME_ROOMS)
			{
				ConstraintStudentsSetHomeRooms crt_constraint = (ConstraintStudentsSetHomeRooms)ctr;
				if (_initialGroupName == crt_constraint.studentsName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: crt_constraint->studentsName=finalGroupName;
					crt_constraint.studentsName.CopyFrom(finalGroupName);
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_MAX_BUILDING_CHANGES_PER_DAY)
			{
				ConstraintStudentsSetMaxBuildingChangesPerDay crt_constraint = (ConstraintStudentsSetMaxBuildingChangesPerDay)ctr;
				if (_initialGroupName == crt_constraint.studentsName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: crt_constraint->studentsName=finalGroupName;
					crt_constraint.studentsName.CopyFrom(finalGroupName);
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_MAX_BUILDING_CHANGES_PER_WEEK)
			{
				ConstraintStudentsSetMaxBuildingChangesPerWeek crt_constraint = (ConstraintStudentsSetMaxBuildingChangesPerWeek)ctr;
				if (_initialGroupName == crt_constraint.studentsName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: crt_constraint->studentsName=finalGroupName;
					crt_constraint.studentsName.CopyFrom(finalGroupName);
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_MIN_GAPS_BETWEEN_BUILDING_CHANGES)
			{
				ConstraintStudentsSetMinGapsBetweenBuildingChanges crt_constraint = (ConstraintStudentsSetMinGapsBetweenBuildingChanges)ctr;
				if (_initialGroupName == crt_constraint.studentsName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: crt_constraint->studentsName=finalGroupName;
					crt_constraint.studentsName.CopyFrom(finalGroupName);
			}
		}

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		return true;
	}

	/**
	A function to sort the groups of this year alphabetically
	*/
	private void sortGroupsAlphabetically(QString yearName)
	{
		StudentsYear sty = this.yearsList[this.searchYear(yearName)];
		Debug.Assert(sty);

		qSort(sty.groupsList.begin(), sty.groupsList.end(), GlobalMembersStudentsset.groupsAscending);

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);
	}

	/**
	Adds a new subgroup to a certain group in a certain year of study to
	the academic structure
	*/
	private bool addSubgroup(QString yearName, QString groupName, StudentsSubgroup subgroup)
	{
		StudentsYear sty = this.yearsList.at(this.searchYear(yearName));
		Debug.Assert(sty);
		StudentsGroup stg = sty.groupsList.at(this.searchGroup(yearName, groupName));
		Debug.Assert(stg);


		for (int i = 0; i < stg.subgroupsList.size(); i++)
		{
			StudentsSubgroup sts = stg.subgroupsList[i];
			if (sts.name == subgroup.name)
				return false;
		}

		stg.subgroupsList << subgroup; //append

		/*
		foreach(StudentsYear* y, yearsList)
			foreach(StudentsGroup* g, y->groupsList)
				foreach(StudentsSubgroup* s, g->subgroupsList)
					if(s->name==subgroup->name)
						s->numberOfStudents=subgroup->numberOfStudents;*/

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);
		return true;
	}

	/*
	When reading rules, faster
	*/
	private bool addSubgroupFast(StudentsYear year, StudentsGroup group, StudentsSubgroup subgroup)
	{
		Q_UNUSED(year);

		group.subgroupsList << subgroup; //append

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);
		return true;
	}

	private bool removeSubgroup(QString yearName, QString groupName, QString subgroupName)
	{
		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		StudentsSubgroup subgroup = (StudentsSubgroup)searchStudentsSet(subgroupName);
		Debug.Assert(subgroup != null);
		int nStudents = subgroup.numberOfStudents;

		StudentsYear sty = this.yearsList.at(this.searchYear(yearName));
		Debug.Assert(sty);
		StudentsGroup stg = sty.groupsList.at(this.searchGroup(yearName, groupName));
		Debug.Assert(stg);

		StudentsSubgroup sts = null;
		for (int i = 0; i < stg.subgroupsList.size(); i++)
		{
			sts = stg.subgroupsList[i];
			if (sts.name == subgroupName)
			{
				stg.subgroupsList.removeAt(i);
				break;
			}
		}

		Debug.Assert(sts != null);

		if (this.searchStudentsSet(sts.name) != null)
		{
			//subgroup still exists, in other group

			//with the same pointer??? (leak bug fix on 6 Jan 2010 in FET-5.12.1)
			bool foundSamePointer = false;
			foreach (StudentsYear * year, yearsList)
			{
				foreach (StudentsGroup * group, year.groupsList)
				{
					foreach (StudentsSubgroup subgroup, group.subgroupsList)
					{
						if (subgroup == sts)
						{
							foundSamePointer = true;
							break;
						}
					}
					if (foundSamePointer)
						break;
				}
				if (foundSamePointer)
					break;
			}

			if (!foundSamePointer)
				if (sts != null)
					sts.Dispose();
			/////////////////////////////////////////////////////////////////////

			return true;
		}

		if (sts != null)
			sts.Dispose();

		for (int i = 0; i < this.activitiesList.size();)
		{
			Activity act = this.activitiesList[i];

			bool t = act.removeStudents(this, subgroupName, nStudents);
			if (t && act.studentsNames.count() == 0)
			{
				this.removeActivity(act.id, act.activityGroupId);
				i = 0;
				//(You have to be careful, there can be erased more activities here)
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			bool erased = false;
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_NOT_AVAILABLE_TIMES)
			{
				ConstraintStudentsSetNotAvailableTimes crt_constraint = (ConstraintStudentsSetNotAvailableTimes)ctr;
				if (subgroupName == crt_constraint.students)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_HOURS_DAILY)
			{
				ConstraintStudentsSetMaxHoursDaily crt_constraint = (ConstraintStudentsSetMaxHoursDaily)ctr;
				if (subgroupName == crt_constraint.students)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_INTERVAL_MAX_DAYS_PER_WEEK)
			{
				ConstraintStudentsSetIntervalMaxDaysPerWeek crt_constraint = (ConstraintStudentsSetIntervalMaxDaysPerWeek)ctr;
				if (subgroupName == crt_constraint.students)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_HOURS_CONTINUOUSLY)
			{
				ConstraintStudentsSetMaxHoursContinuously crt_constraint = (ConstraintStudentsSetMaxHoursContinuously)ctr;
				if (subgroupName == crt_constraint.students)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_ACTIVITY_TAG_MAX_HOURS_CONTINUOUSLY)
			{
				ConstraintStudentsSetActivityTagMaxHoursContinuously crt_constraint = (ConstraintStudentsSetActivityTagMaxHoursContinuously)ctr;
				if (subgroupName == crt_constraint.students)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_ACTIVITY_TAG_MAX_HOURS_DAILY)
			{
				ConstraintStudentsSetActivityTagMaxHoursDaily crt_constraint = (ConstraintStudentsSetActivityTagMaxHoursDaily)ctr;
				if (subgroupName == crt_constraint.students)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MIN_HOURS_DAILY)
			{
				ConstraintStudentsSetMinHoursDaily crt_constraint = (ConstraintStudentsSetMinHoursDaily)ctr;
				if (subgroupName == crt_constraint.students)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_EARLY_MAX_BEGINNINGS_AT_SECOND_HOUR)
			{
				ConstraintStudentsSetEarlyMaxBeginningsAtSecondHour crt_constraint = (ConstraintStudentsSetEarlyMaxBeginningsAtSecondHour)ctr;
				if (subgroupName == crt_constraint.students)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_GAPS_PER_WEEK)
			{
				ConstraintStudentsSetMaxGapsPerWeek crt_constraint = (ConstraintStudentsSetMaxGapsPerWeek)ctr;
				if (subgroupName == crt_constraint.students)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_GAPS_PER_DAY)
			{
				ConstraintStudentsSetMaxGapsPerDay crt_constraint = (ConstraintStudentsSetMaxGapsPerDay)ctr;
				if (subgroupName == crt_constraint.students)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_PREFERRED_TIME_SLOTS)
			{
				ConstraintActivitiesPreferredTimeSlots crt_constraint = (ConstraintActivitiesPreferredTimeSlots)ctr;
				if (subgroupName == crt_constraint.p_studentsName)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_PREFERRED_STARTING_TIMES)
			{
				ConstraintActivitiesPreferredStartingTimes crt_constraint = (ConstraintActivitiesPreferredStartingTimes)ctr;
				if (subgroupName == crt_constraint.studentsName)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_END_STUDENTS_DAY)
			{
				ConstraintActivitiesEndStudentsDay crt_constraint = (ConstraintActivitiesEndStudentsDay)ctr;
				if (subgroupName == crt_constraint.studentsName)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_SUBACTIVITIES_PREFERRED_TIME_SLOTS)
			{
				ConstraintSubactivitiesPreferredTimeSlots crt_constraint = (ConstraintSubactivitiesPreferredTimeSlots)ctr;
				if (subgroupName == crt_constraint.p_studentsName)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_SUBACTIVITIES_PREFERRED_STARTING_TIMES)
			{
				ConstraintSubactivitiesPreferredStartingTimes crt_constraint = (ConstraintSubactivitiesPreferredStartingTimes)ctr;
				if (subgroupName == crt_constraint.studentsName)
				{
					this.removeTimeConstraint(ctr);
					erased = true;
				}
			}

			if (!erased)
				i++;
		}

		for (int i = 0; i < this.spaceConstraintsList.size();)
		{
			SpaceConstraint ctr = this.spaceConstraintsList[i];

			bool erased = false;
			if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_HOME_ROOM)
			{
				ConstraintStudentsSetHomeRoom crt_constraint = (ConstraintStudentsSetHomeRoom)ctr;
				if (subgroupName == crt_constraint.studentsName)
				{
					this.removeSpaceConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_HOME_ROOMS)
			{
				ConstraintStudentsSetHomeRooms crt_constraint = (ConstraintStudentsSetHomeRooms)ctr;
				if (subgroupName == crt_constraint.studentsName)
				{
					this.removeSpaceConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_MAX_BUILDING_CHANGES_PER_DAY)
			{
				ConstraintStudentsSetMaxBuildingChangesPerDay crt_constraint = (ConstraintStudentsSetMaxBuildingChangesPerDay)ctr;
				if (subgroupName == crt_constraint.studentsName)
				{
					this.removeSpaceConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_MAX_BUILDING_CHANGES_PER_WEEK)
			{
				ConstraintStudentsSetMaxBuildingChangesPerWeek crt_constraint = (ConstraintStudentsSetMaxBuildingChangesPerWeek)ctr;
				if (subgroupName == crt_constraint.studentsName)
				{
					this.removeSpaceConstraint(ctr);
					erased = true;
				}
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_MIN_GAPS_BETWEEN_BUILDING_CHANGES)
			{
				ConstraintStudentsSetMinGapsBetweenBuildingChanges crt_constraint = (ConstraintStudentsSetMinGapsBetweenBuildingChanges)ctr;
				if (subgroupName == crt_constraint.studentsName)
				{
					this.removeSpaceConstraint(ctr);
					erased = true;
				}
			}

			if (!erased)
				i++;
		}

		return true;
	}

	/**
	Returns -1 if not found or the index of the subgroup in the list of subgroups of this group
	*/
	private int searchSubgroup(QString yearName, QString groupName, QString subgroupName)
	{
		StudentsYear sty = this.yearsList.at(this.searchYear(yearName));
		Debug.Assert(sty);
		StudentsGroup stg = sty.groupsList.at(this.searchGroup(yearName, groupName));
		Debug.Assert(stg);

		for (int i = 0; i < stg.subgroupsList.size(); i++)
			if (stg.subgroupsList[i].name == subgroupName)
				return i;

		return -1;
	}

	private int searchAugmentedSubgroup(QString yearName, QString groupName, QString subgroupName)
	{
		StudentsYear sty = this.augmentedYearsList.at(this.searchAugmentedYear(yearName));
		Debug.Assert(sty);
		StudentsGroup stg = sty.groupsList.at(this.searchAugmentedGroup(yearName, groupName));
		Debug.Assert(stg);

		for (int i = 0; i < stg.subgroupsList.size(); i++)
			if (stg.subgroupsList[i].name == subgroupName)
				return i;

		return -1;
	}

	/**
	Modifies this students subgroup (name, number of students) and takes care of all related 
	activities and constraints.	Returns true on success, false on failure (if not found)
	*/
	private bool modifySubgroup(QString yearName, QString groupName, QString initialSubgroupName, QString finalSubgroupName, int finalNumberOfStudents)
	{
		StudentsSet _initialSet = searchStudentsSet(initialSubgroupName);
		Debug.Assert(_initialSet != null);
		int _initialNumberOfStudents = _initialSet.numberOfStudents;

//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: QString _initialSubgroupName=initialSubgroupName;
		QString _initialSubgroupName = new QString(initialSubgroupName);

		Debug.Assert(searchSubgroup(yearName, groupName, _initialSubgroupName) >= 0);
//C++ TO C# CONVERTER NOTE: Segment register keywords are not supported in C#:
//ORIGINAL LINE: StudentsSet* _ss=searchStudentsSet(finalSubgroupName);
		StudentsSet _ss = searchStudentsSet(finalSubgroupName);
		Debug.Assert(_ss == null || _initialSubgroupName == finalSubgroupName);

		StudentsYear sty = this.yearsList.at(this.searchYear(yearName));
		Debug.Assert(sty);
		StudentsGroup stg = sty.groupsList.at(this.searchGroup(yearName, groupName));
		Debug.Assert(stg);

		StudentsSubgroup sts = null;
		for (int i = 0; i < stg.subgroupsList.size(); i++)
		{
			sts = stg.subgroupsList[i];

			if (sts.name == _initialSubgroupName)
			{
				sts.name = finalSubgroupName;
				sts.numberOfStudents = finalNumberOfStudents;
				break;
			}
		}
		Debug.Assert(sts);

		if (_ss != null) //In case it only changes the number of students, make the same number of students in all subgroups with this name
		{
			Debug.Assert(_initialSubgroupName == finalSubgroupName);
			foreach (StudentsYear * year, yearsList) foreach (StudentsGroup * group, year.groupsList) foreach (StudentsSubgroup * subgroup, group.subgroupsList) if (subgroup.name == finalSubgroupName) subgroup.numberOfStudents = finalNumberOfStudents;
		}

		//TODO: improve this part
		for (int i = 0; i < this.activitiesList.size(); i++)
			this.activitiesList[i].renameStudents(this, _initialSubgroupName, finalSubgroupName, _initialNumberOfStudents, finalNumberOfStudents);

		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];

			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_NOT_AVAILABLE_TIMES)
			{
				ConstraintStudentsSetNotAvailableTimes crt_constraint = (ConstraintStudentsSetNotAvailableTimes)ctr;
				if (_initialSubgroupName == crt_constraint.students)
					crt_constraint.students = finalSubgroupName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_HOURS_DAILY)
			{
				ConstraintStudentsSetMaxHoursDaily crt_constraint = (ConstraintStudentsSetMaxHoursDaily)ctr;
				if (_initialSubgroupName == crt_constraint.students)
					crt_constraint.students = finalSubgroupName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_INTERVAL_MAX_DAYS_PER_WEEK)
			{
				ConstraintStudentsSetIntervalMaxDaysPerWeek crt_constraint = (ConstraintStudentsSetIntervalMaxDaysPerWeek)ctr;
				if (_initialSubgroupName == crt_constraint.students)
					crt_constraint.students = finalSubgroupName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_HOURS_CONTINUOUSLY)
			{
				ConstraintStudentsSetMaxHoursContinuously crt_constraint = (ConstraintStudentsSetMaxHoursContinuously)ctr;
				if (_initialSubgroupName == crt_constraint.students)
					crt_constraint.students = finalSubgroupName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_ACTIVITY_TAG_MAX_HOURS_CONTINUOUSLY)
			{
				ConstraintStudentsSetActivityTagMaxHoursContinuously crt_constraint = (ConstraintStudentsSetActivityTagMaxHoursContinuously)ctr;
				if (_initialSubgroupName == crt_constraint.students)
					crt_constraint.students = finalSubgroupName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_ACTIVITY_TAG_MAX_HOURS_DAILY)
			{
				ConstraintStudentsSetActivityTagMaxHoursDaily crt_constraint = (ConstraintStudentsSetActivityTagMaxHoursDaily)ctr;
				if (_initialSubgroupName == crt_constraint.students)
					crt_constraint.students = finalSubgroupName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MIN_HOURS_DAILY)
			{
				ConstraintStudentsSetMinHoursDaily crt_constraint = (ConstraintStudentsSetMinHoursDaily)ctr;
				if (_initialSubgroupName == crt_constraint.students)
					crt_constraint.students = finalSubgroupName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_EARLY_MAX_BEGINNINGS_AT_SECOND_HOUR)
			{
				ConstraintStudentsSetEarlyMaxBeginningsAtSecondHour crt_constraint = (ConstraintStudentsSetEarlyMaxBeginningsAtSecondHour)ctr;
				if (_initialSubgroupName == crt_constraint.students)
					crt_constraint.students = finalSubgroupName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_GAPS_PER_WEEK)
			{
				ConstraintStudentsSetMaxGapsPerWeek crt_constraint = (ConstraintStudentsSetMaxGapsPerWeek)ctr;
				if (_initialSubgroupName == crt_constraint.students)
					crt_constraint.students = finalSubgroupName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_GAPS_PER_DAY)
			{
				ConstraintStudentsSetMaxGapsPerDay crt_constraint = (ConstraintStudentsSetMaxGapsPerDay)ctr;
				if (_initialSubgroupName == crt_constraint.students)
					crt_constraint.students = finalSubgroupName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_PREFERRED_TIME_SLOTS)
			{
				ConstraintActivitiesPreferredTimeSlots crt_constraint = (ConstraintActivitiesPreferredTimeSlots)ctr;
				if (_initialSubgroupName == crt_constraint.p_studentsName)
					crt_constraint.p_studentsName = finalSubgroupName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_PREFERRED_STARTING_TIMES)
			{
				ConstraintActivitiesPreferredStartingTimes crt_constraint = (ConstraintActivitiesPreferredStartingTimes)ctr;
				if (_initialSubgroupName == crt_constraint.studentsName)
					crt_constraint.studentsName = finalSubgroupName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_END_STUDENTS_DAY)
			{
				ConstraintActivitiesEndStudentsDay crt_constraint = (ConstraintActivitiesEndStudentsDay)ctr;
				if (_initialSubgroupName == crt_constraint.studentsName)
					crt_constraint.studentsName = finalSubgroupName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_SUBACTIVITIES_PREFERRED_TIME_SLOTS)
			{
				ConstraintSubactivitiesPreferredTimeSlots crt_constraint = (ConstraintSubactivitiesPreferredTimeSlots)ctr;
				if (_initialSubgroupName == crt_constraint.p_studentsName)
					crt_constraint.p_studentsName = finalSubgroupName;
			}
			else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_SUBACTIVITIES_PREFERRED_STARTING_TIMES)
			{
				ConstraintSubactivitiesPreferredStartingTimes crt_constraint = (ConstraintSubactivitiesPreferredStartingTimes)ctr;
				if (_initialSubgroupName == crt_constraint.studentsName)
					crt_constraint.studentsName = finalSubgroupName;
			}
		}

		for (int i = 0; i < this.spaceConstraintsList.size(); i++)
		{
			SpaceConstraint ctr = this.spaceConstraintsList[i];

			if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_HOME_ROOM)
			{
				ConstraintStudentsSetHomeRoom crt_constraint = (ConstraintStudentsSetHomeRoom)ctr;
				if (_initialSubgroupName == crt_constraint.studentsName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: crt_constraint->studentsName=finalSubgroupName;
					crt_constraint.studentsName.CopyFrom(finalSubgroupName);
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_HOME_ROOMS)
			{
				ConstraintStudentsSetHomeRooms crt_constraint = (ConstraintStudentsSetHomeRooms)ctr;
				if (_initialSubgroupName == crt_constraint.studentsName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: crt_constraint->studentsName=finalSubgroupName;
					crt_constraint.studentsName.CopyFrom(finalSubgroupName);
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_MAX_BUILDING_CHANGES_PER_DAY)
			{
				ConstraintStudentsSetMaxBuildingChangesPerDay crt_constraint = (ConstraintStudentsSetMaxBuildingChangesPerDay)ctr;
				if (_initialSubgroupName == crt_constraint.studentsName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: crt_constraint->studentsName=finalSubgroupName;
					crt_constraint.studentsName.CopyFrom(finalSubgroupName);
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_MAX_BUILDING_CHANGES_PER_WEEK)
			{
				ConstraintStudentsSetMaxBuildingChangesPerWeek crt_constraint = (ConstraintStudentsSetMaxBuildingChangesPerWeek)ctr;
				if (_initialSubgroupName == crt_constraint.studentsName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: crt_constraint->studentsName=finalSubgroupName;
					crt_constraint.studentsName.CopyFrom(finalSubgroupName);
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_MIN_GAPS_BETWEEN_BUILDING_CHANGES)
			{
				ConstraintStudentsSetMinGapsBetweenBuildingChanges crt_constraint = (ConstraintStudentsSetMinGapsBetweenBuildingChanges)ctr;
				if (_initialSubgroupName == crt_constraint.studentsName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: crt_constraint->studentsName=finalSubgroupName;
					crt_constraint.studentsName.CopyFrom(finalSubgroupName);
			}
		}

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		return true;
	}

	/**
	A function to sort the subgroups of this group alphabetically
	*/
	private void sortSubgroupsAlphabetically(QString yearName, QString groupName)
	{
		StudentsYear sty = this.yearsList.at(this.searchYear(yearName));
		Debug.Assert(sty);
		StudentsGroup stg = sty.groupsList.at(this.searchGroup(yearName, groupName));
		Debug.Assert(stg);

		qSort(stg.subgroupsList.begin(), stg.subgroupsList.end(), GlobalMembersStudentsset.subgroupsAscending);

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);
	}

	/**
	Adds a new indivisible activity (not split) to the list of activities.
	(It can add a subactivity of a split activity)
	Returns true if successful or false if the maximum
	number of activities was reached.
	*/
	private bool addSimpleActivity(QWidget parent, int _id, int _activityGroupId, QStringList _teachersNames, QString _subjectName, QStringList _activityTagsNames, QStringList _studentsNames, int _duration, int _totalDuration, bool _active, bool _computeNTotalStudents, int _nTotalStudents)
	{
		//check for duplicates - idea and code by Volker Dirr
		int t = QStringList(_teachersNames).removeDuplicates();
		if (t > 0)
			RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("Activity with Id=%1 contains %2 duplicate teachers - please correct that").arg(_id).arg(t));

		t = QStringList(_studentsNames).removeDuplicates();
		if (t > 0)
			RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("Activity with Id=%1 contains %2 duplicate students sets - please correct that").arg(_id).arg(t));

		t = QStringList(_activityTagsNames).removeDuplicates();
		if (t > 0)
			RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("Activity with Id=%1 contains %2 duplicate activity tags - please correct that").arg(_id).arg(t));

		Activity act = new Activity(this, _id, _activityGroupId, _teachersNames, _subjectName, _activityTagsNames, _studentsNames, _duration, _totalDuration, _active, _computeNTotalStudents, _nTotalStudents);

		this.activitiesList << act; //append

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		return true;
	}

	/*
	Faster, when reading rules (no need to recompute the number of students in activity constructor
	*/
	private bool addSimpleActivityRulesFast(QWidget parent, int _id, int _activityGroupId, QStringList _teachersNames, QString _subjectName, QStringList _activityTagsNames, QStringList _studentsNames, int _duration, int _totalDuration, bool _active, bool _computeNTotalStudents, int _nTotalStudents, int _computedNumberOfStudents)
	{
		//check for duplicates - idea and code by Volker Dirr
		int t = QStringList(_teachersNames).removeDuplicates();
		if (t > 0)
			RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("Activity with Id=%1 contains %2 duplicate teachers - please correct that").arg(_id).arg(t));

		t = QStringList(_studentsNames).removeDuplicates();
		if (t > 0)
			RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("Activity with Id=%1 contains %2 duplicate students sets - please correct that").arg(_id).arg(t));

		t = QStringList(_activityTagsNames).removeDuplicates();
		if (t > 0)
			RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("Activity with Id=%1 contains %2 duplicate activity tags - please correct that").arg(_id).arg(t));

		Activity act = new Activity(this, _id, _activityGroupId, _teachersNames, _subjectName, _activityTagsNames, _studentsNames, _duration, _totalDuration, _active, _computeNTotalStudents, _nTotalStudents, _computedNumberOfStudents);

		this.activitiesList << act; //append

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		return true;
	}

	/**
	Adds a new split activity to the list of activities.
	Returns true if successful or false if the maximum
	number of activities was reached.
	If _minDayDistance>0, there will automatically added a compulsory
	ConstraintMinDaysBetweenActivities.
	*/
	private bool addSplitActivity(QWidget parent, int _firstActivityId, int _activityGroupId, QStringList _teachersNames, QString _subjectName, QStringList _activityTagsNames, QStringList _studentsNames, int _nSplits, int _totalDuration, int[] _durations, bool[] _active, int _minDayDistance, double _weightPercentage, bool _consecutiveIfSameDay, bool _computeNTotalStudents, int _nTotalStudents)
	{
		//check for duplicates - idea and code by Volker Dirr
		int t = QStringList(_teachersNames).removeDuplicates();
		if (t > 0)
			RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("Activities with group_Id=%1 contain %2 duplicate teachers - please correct that").arg(_activityGroupId).arg(t));

		t = QStringList(_studentsNames).removeDuplicates();
		if (t > 0)
			RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("Activities with group_Id=%1 contain %2 duplicate students sets - please correct that").arg(_activityGroupId).arg(t));

		t = QStringList(_activityTagsNames).removeDuplicates();
		if (t > 0)
			RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("Activities with group_Id=%1 contain %2 duplicate activity tags - please correct that").arg(_activityGroupId).arg(t));

		Debug.Assert(_firstActivityId == _activityGroupId);

		QList<int> acts = new QList<int>();

		acts.clear();
		for (int i = 0; i < _nSplits; i++)
		{
			Activity act;
			if (i == 0)
				act = new Activity(this, _firstActivityId + i, _activityGroupId, _teachersNames, _subjectName, _activityTagsNames, _studentsNames, _durations[i], _totalDuration, _active[i], _computeNTotalStudents, _nTotalStudents);
			else
				act = new Activity(this, _firstActivityId + i, _activityGroupId, _teachersNames, _subjectName, _activityTagsNames, _studentsNames, _durations[i], _totalDuration, _active[i], _computeNTotalStudents, _nTotalStudents);

			this.activitiesList << act; //append

			acts.append(_firstActivityId + i);
		}

		if (_minDayDistance > 0)
		{
			TimeConstraint constr = new ConstraintMinDaysBetweenActivities(_weightPercentage, _consecutiveIfSameDay, _nSplits, acts, _minDayDistance);
			bool tmp = this.addTimeConstraint(constr);
			Debug.Assert(tmp);
		}

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		return true;
	}

	/**
	Removes only the activity with this id.
	*/
	private void removeActivity(int _id)
	{
		bool recomputeTime = false;
		bool recomputeSpace = false;

		for (int i = 0; i < this.activitiesList.size(); i++)
		{
			Activity act = this.activitiesList[i];
			if (_id == act.id)
			{
				//removing ConstraintActivityPreferredTime-s referring to this activity
				for (int j = 0; j < this.timeConstraintsList.size();)
				{
					TimeConstraint ctr = this.timeConstraintsList[j];
					if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITY_PREFERRED_STARTING_TIME)
					{
						ConstraintActivityPreferredStartingTime apt = (ConstraintActivityPreferredStartingTime)ctr;
						if (apt.activityId == act.id)
						{
							//cout<<"Removing constraint "<<qPrintable(apt->getDescription(*this))<<endl;
							this.removeTimeConstraint(ctr);
							recomputeTime = true;
						}
						else
							j++;
					}
					else
						j++;
				}
				//removing ConstraintTwoActivitiesConsecutive-s referring to this activity
				for (int j = 0; j < this.timeConstraintsList.size();)
				{
					TimeConstraint ctr = this.timeConstraintsList[j];
					if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TWO_ACTIVITIES_CONSECUTIVE)
					{
						ConstraintTwoActivitiesConsecutive apt = (ConstraintTwoActivitiesConsecutive)ctr;
						if (apt.firstActivityId == act.id)
						{
							//cout<<"Removing constraint "<<qPrintable(apt->getDescription(*this))<<endl;
							this.removeTimeConstraint(ctr);
						}
						else if (apt.secondActivityId == act.id)
						{
							//cout<<"Removing constraint "<<qPrintable(apt->getDescription(*this))<<endl;
							this.removeTimeConstraint(ctr);
						}
						else
							j++;
					}
					else
						j++;
				}
				//removing ConstraintTwoActivitiesGrouped-s referring to this activity
				for (int j = 0; j < this.timeConstraintsList.size();)
				{
					TimeConstraint ctr = this.timeConstraintsList[j];
					if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TWO_ACTIVITIES_GROUPED)
					{
						ConstraintTwoActivitiesGrouped apt = (ConstraintTwoActivitiesGrouped)ctr;
						if (apt.firstActivityId == act.id)
						{
							//cout<<"Removing constraint "<<qPrintable(apt->getDescription(*this))<<endl;
							this.removeTimeConstraint(ctr);
						}
						else if (apt.secondActivityId == act.id)
						{
							//cout<<"Removing constraint "<<qPrintable(apt->getDescription(*this))<<endl;
							this.removeTimeConstraint(ctr);
						}
						else
							j++;
					}
					else
						j++;
				}
				//removing ConstraintThreeActivitiesGrouped-s referring to this activity
				for (int j = 0; j < this.timeConstraintsList.size();)
				{
					TimeConstraint ctr = this.timeConstraintsList[j];
					if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_THREE_ACTIVITIES_GROUPED)
					{
						ConstraintThreeActivitiesGrouped apt = (ConstraintThreeActivitiesGrouped)ctr;
						if (apt.firstActivityId == act.id)
						{
							//cout<<"Removing constraint "<<qPrintable(apt->getDescription(*this))<<endl;
							this.removeTimeConstraint(ctr);
						}
						else if (apt.secondActivityId == act.id)
						{
							//cout<<"Removing constraint "<<qPrintable(apt->getDescription(*this))<<endl;
							this.removeTimeConstraint(ctr);
						}
						else if (apt.thirdActivityId == act.id)
						{
							//cout<<"Removing constraint "<<qPrintable(apt->getDescription(*this))<<endl;
							this.removeTimeConstraint(ctr);
						}
						else
							j++;
					}
					else
						j++;
				}
				//removing ConstraintTwoActivitiesOrdered-s referring to this activity
				for (int j = 0; j < this.timeConstraintsList.size();)
				{
					TimeConstraint ctr = this.timeConstraintsList[j];
					if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TWO_ACTIVITIES_ORDERED)
					{
						ConstraintTwoActivitiesOrdered apt = (ConstraintTwoActivitiesOrdered)ctr;
						if (apt.firstActivityId == act.id)
						{
							//cout<<"Removing constraint "<<qPrintable(apt->getDescription(*this))<<endl;
							this.removeTimeConstraint(ctr);
						}
						else if (apt.secondActivityId == act.id)
						{
							//cout<<"Removing constraint "<<qPrintable(apt->getDescription(*this))<<endl;
							this.removeTimeConstraint(ctr);
						}
						else
							j++;
					}
					else
						j++;
				}
				//removing ConstraintActivityPreferredTimes-s referring to this activity
				for (int j = 0; j < this.timeConstraintsList.size();)
				{
					TimeConstraint ctr = this.timeConstraintsList[j];
					if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITY_PREFERRED_TIME_SLOTS)
					{
						ConstraintActivityPreferredTimeSlots apt = (ConstraintActivityPreferredTimeSlots)ctr;
						if (apt.p_activityId == act.id)
						{
							//cout<<"Removing constraint "<<qPrintable(apt->getDescription(*this))<<endl;
							this.removeTimeConstraint(ctr);
						}
						else
							j++;
					}
					else
						j++;
				}
				//removing ConstraintActivityPreferredStartingTimes-s referring to this activity
				for (int j = 0; j < this.timeConstraintsList.size();)
				{
					TimeConstraint ctr = this.timeConstraintsList[j];
					if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITY_PREFERRED_STARTING_TIMES)
					{
						ConstraintActivityPreferredStartingTimes apt = (ConstraintActivityPreferredStartingTimes)ctr;
						if (apt.activityId == act.id)
						{
							//cout<<"Removing constraint "<<qPrintable(apt->getDescription(*this))<<endl;
							this.removeTimeConstraint(ctr);
						}
						else
							j++;
					}
					else
						j++;
				}
				//removing ConstraintActivityEndsStudentsDay-s referring to this activity
				for (int j = 0; j < this.timeConstraintsList.size();)
				{
					TimeConstraint ctr = this.timeConstraintsList[j];
					if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITY_ENDS_STUDENTS_DAY)
					{
						ConstraintActivityEndsStudentsDay apt = (ConstraintActivityEndsStudentsDay)ctr;
						if (apt.activityId == act.id)
						{
							//cout<<"Removing constraint "<<qPrintable(apt->getDescription(*this))<<endl;
							this.removeTimeConstraint(ctr);
						}
						else
							j++;
					}
					else
						j++;
				}

				//removing ConstraintActivityPreferredRoom-s referring to this activity
				for (int j = 0; j < this.spaceConstraintsList.size();)
				{
					SpaceConstraint ctr = this.spaceConstraintsList[j];
					if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITY_PREFERRED_ROOM)
					{
						if (((ConstraintActivityPreferredRoom)ctr).activityId == act.id)
						{
							this.removeSpaceConstraint(ctr);
							recomputeSpace = true;
						}
						else
							j++;
					}
					else
						j++;
				}
				//removing ConstraintActivityPreferredRooms-s referring to this activity
				for (int j = 0; j < this.spaceConstraintsList.size();)
				{
					SpaceConstraint ctr = this.spaceConstraintsList[j];
					if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITY_PREFERRED_ROOMS)
					{
						if (((ConstraintActivityPreferredRooms)ctr).activityId == act.id)
							this.removeSpaceConstraint(ctr);
						else
							j++;
					}
					else
						j++;
				}

				//remove the activity
				this.activitiesList[i] = null;
				this.activitiesList.removeAt(i);
				break;
			}
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_MIN_DAYS_BETWEEN_ACTIVITIES)
			{
				((ConstraintMinDaysBetweenActivities)ctr).removeUseless(this);
				if (((ConstraintMinDaysBetweenActivities)ctr).n_activities < 2)
					this.removeTimeConstraint(ctr);
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_OCCUPY_MAX_TIME_SLOTS_FROM_SELECTION)
			{
				((ConstraintActivitiesOccupyMaxTimeSlotsFromSelection)ctr).removeUseless(this);
				if (((ConstraintActivitiesOccupyMaxTimeSlotsFromSelection)ctr).activitiesIds.count() < 1)
					this.removeTimeConstraint(ctr);
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_MAX_SIMULTANEOUS_IN_SELECTED_TIME_SLOTS)
			{
				((ConstraintActivitiesMaxSimultaneousInSelectedTimeSlots)ctr).removeUseless(this);
				if (((ConstraintActivitiesMaxSimultaneousInSelectedTimeSlots)ctr).activitiesIds.count() < 1)
					this.removeTimeConstraint(ctr);
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_MAX_DAYS_BETWEEN_ACTIVITIES)
			{
				((ConstraintMaxDaysBetweenActivities)ctr).removeUseless(this);
				if (((ConstraintMaxDaysBetweenActivities)ctr).n_activities < 2)
					this.removeTimeConstraint(ctr);
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_MIN_GAPS_BETWEEN_ACTIVITIES)
			{
				((ConstraintMinGapsBetweenActivities)ctr).removeUseless(this);
				if (((ConstraintMinGapsBetweenActivities)ctr).n_activities < 2)
					this.removeTimeConstraint(ctr);
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_SAME_STARTING_TIME)
			{
				((ConstraintActivitiesSameStartingTime)ctr).removeUseless(this);
				if (((ConstraintActivitiesSameStartingTime)ctr).n_activities < 2)
					this.removeTimeConstraint(ctr);
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_SAME_STARTING_HOUR)
			{
				((ConstraintActivitiesSameStartingHour)ctr).removeUseless(this);
				if (((ConstraintActivitiesSameStartingHour)ctr).n_activities < 2)
					this.removeTimeConstraint(ctr);
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_SAME_STARTING_DAY)
			{
				((ConstraintActivitiesSameStartingDay)ctr).removeUseless(this);
				if (((ConstraintActivitiesSameStartingDay)ctr).n_activities < 2)
					this.removeTimeConstraint(ctr);
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_NOT_OVERLAPPING)
			{
				((ConstraintActivitiesNotOverlapping)ctr).removeUseless(this);
				if (((ConstraintActivitiesNotOverlapping)ctr).n_activities < 2)
					this.removeTimeConstraint(ctr);
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.spaceConstraintsList.size();)
		{
			SpaceConstraint ctr = this.spaceConstraintsList[i];
			if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITIES_OCCUPY_MAX_DIFFERENT_ROOMS)
			{
				((ConstraintActivitiesOccupyMaxDifferentRooms)ctr).removeUseless(this);
				if (((ConstraintActivitiesOccupyMaxDifferentRooms)ctr).activitiesIds.count() < 2)
					this.removeSpaceConstraint(ctr);
				else
					i++;
			}
			else
				i++;
		}

		if (recomputeTime)
		{
			LockUnlock.computeLockedUnlockedActivitiesOnlyTime();
		}
		if (recomputeSpace)
		{
			LockUnlock.computeLockedUnlockedActivitiesOnlySpace();
		}
		if (recomputeTime || recomputeSpace)
		{
			LockUnlock.increaseCommunicationSpinBox();
		}

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);
	}

	/**
	If _activityGroupId==0, then this is a non-split activity
	(if >0, then this is a single sub-activity from a split activity.
	Removes this activity from the list of activities.
	For split activities, it removes all the sub-activities that are contained in it.
	*/
	private void removeActivity(int _id, int _activityGroupId)
	{
		bool recomputeTime = false;
		bool recomputeSpace = false;

		for (int i = 0; i < this.activitiesList.size();)
		{
			Activity act = this.activitiesList[i];

			if (_id == act.id || (_activityGroupId > 0 && _activityGroupId == act.activityGroupId))
			{

				//removing ConstraintActivityPreferredTime-s referring to this activity
				for (int j = 0; j < this.timeConstraintsList.size();)
				{
					TimeConstraint ctr = this.timeConstraintsList[j];
					if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITY_PREFERRED_STARTING_TIME)
					{
						ConstraintActivityPreferredStartingTime apt = (ConstraintActivityPreferredStartingTime)ctr;
						if (apt.activityId == act.id)
						{
							//cout<<"Removing constraint "<<qPrintable(apt->getDescription(*this))<<endl;
							this.removeTimeConstraint(ctr);
							recomputeTime = true;
						}
						else
							j++;
					}
					else
						j++;
				}
				//removing ConstraintTwoActivitiesConsecutive-s referring to this activity
				for (int j = 0; j < this.timeConstraintsList.size();)
				{
					TimeConstraint ctr = this.timeConstraintsList[j];
					if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TWO_ACTIVITIES_CONSECUTIVE)
					{
						ConstraintTwoActivitiesConsecutive apt = (ConstraintTwoActivitiesConsecutive)ctr;
						if (apt.firstActivityId == act.id)
						{
							//cout<<"Removing constraint "<<qPrintable(apt->getDescription(*this))<<endl;
							this.removeTimeConstraint(ctr);
						}
						else if (apt.secondActivityId == act.id)
						{
							//cout<<"Removing constraint "<<qPrintable(apt->getDescription(*this))<<endl;
							this.removeTimeConstraint(ctr);
						}
						else
							j++;
					}
					else
						j++;
				}
				//removing ConstraintTwoActivitiesGrouped-s referring to this activity
				for (int j = 0; j < this.timeConstraintsList.size();)
				{
					TimeConstraint ctr = this.timeConstraintsList[j];
					if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TWO_ACTIVITIES_GROUPED)
					{
						ConstraintTwoActivitiesGrouped apt = (ConstraintTwoActivitiesGrouped)ctr;
						if (apt.firstActivityId == act.id)
						{
							//cout<<"Removing constraint "<<qPrintable(apt->getDescription(*this))<<endl;
							this.removeTimeConstraint(ctr);
						}
						else if (apt.secondActivityId == act.id)
						{
							//cout<<"Removing constraint "<<qPrintable(apt->getDescription(*this))<<endl;
							this.removeTimeConstraint(ctr);
						}
						else
							j++;
					}
					else
						j++;
				}
				//removing ConstraintThreeActivitiesGrouped-s referring to this activity
				for (int j = 0; j < this.timeConstraintsList.size();)
				{
					TimeConstraint ctr = this.timeConstraintsList[j];
					if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_THREE_ACTIVITIES_GROUPED)
					{
						ConstraintThreeActivitiesGrouped apt = (ConstraintThreeActivitiesGrouped)ctr;
						if (apt.firstActivityId == act.id)
						{
							//cout<<"Removing constraint "<<qPrintable(apt->getDescription(*this))<<endl;
							this.removeTimeConstraint(ctr);
						}
						else if (apt.secondActivityId == act.id)
						{
							//cout<<"Removing constraint "<<qPrintable(apt->getDescription(*this))<<endl;
							this.removeTimeConstraint(ctr);
						}
						else if (apt.thirdActivityId == act.id)
						{
							//cout<<"Removing constraint "<<qPrintable(apt->getDescription(*this))<<endl;
							this.removeTimeConstraint(ctr);
						}
						else
							j++;
					}
					else
						j++;
				}
				//removing ConstraintTwoActivitiesOrdered-s referring to this activity
				for (int j = 0; j < this.timeConstraintsList.size();)
				{
					TimeConstraint ctr = this.timeConstraintsList[j];
					if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TWO_ACTIVITIES_ORDERED)
					{
						ConstraintTwoActivitiesOrdered apt = (ConstraintTwoActivitiesOrdered)ctr;
						if (apt.firstActivityId == act.id)
						{
							//cout<<"Removing constraint "<<qPrintable(apt->getDescription(*this))<<endl;
							this.removeTimeConstraint(ctr);
						}
						else if (apt.secondActivityId == act.id)
						{
							//cout<<"Removing constraint "<<qPrintable(apt->getDescription(*this))<<endl;
							this.removeTimeConstraint(ctr);
						}
						else
							j++;
					}
					else
						j++;
				}
				//removing ConstraintActivityPreferredTimes-s referring to this activity
				for (int j = 0; j < this.timeConstraintsList.size();)
				{
					TimeConstraint ctr = this.timeConstraintsList[j];
					if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITY_PREFERRED_TIME_SLOTS)
					{
						ConstraintActivityPreferredTimeSlots apt = (ConstraintActivityPreferredTimeSlots)ctr;
						if (apt.p_activityId == act.id)
						{
							//cout<<"Removing constraint "<<qPrintable(apt->getDescription(*this))<<endl;
							this.removeTimeConstraint(ctr);
						}
						else
							j++;
					}
					else
						j++;
				}
				//removing ConstraintActivityPreferredStartingTimes-s referring to this activity
				for (int j = 0; j < this.timeConstraintsList.size();)
				{
					TimeConstraint ctr = this.timeConstraintsList[j];
					if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITY_PREFERRED_STARTING_TIMES)
					{
						ConstraintActivityPreferredStartingTimes apt = (ConstraintActivityPreferredStartingTimes)ctr;
						if (apt.activityId == act.id)
						{
							//cout<<"Removing constraint "<<qPrintable(apt->getDescription(*this))<<endl;
							this.removeTimeConstraint(ctr);
						}
						else
							j++;
					}
					else
						j++;
				}
				//removing ConstraintActivityEndsStudentsDay-s referring to this activity
				for (int j = 0; j < this.timeConstraintsList.size();)
				{
					TimeConstraint ctr = this.timeConstraintsList[j];
					if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITY_ENDS_STUDENTS_DAY)
					{
						ConstraintActivityEndsStudentsDay apt = (ConstraintActivityEndsStudentsDay)ctr;
						if (apt.activityId == act.id)
						{
							//cout<<"Removing constraint "<<qPrintable(apt->getDescription(*this))<<endl;
							this.removeTimeConstraint(ctr);
						}
						else
							j++;
					}
					else
						j++;
				}

				//removing ConstraintActivityPreferredRoom-s referring to this activity
				for (int j = 0; j < this.spaceConstraintsList.size();)
				{
					SpaceConstraint ctr = this.spaceConstraintsList[j];
					if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITY_PREFERRED_ROOM)
					{
						if (((ConstraintActivityPreferredRoom)ctr).activityId == act.id)
						{
							this.removeSpaceConstraint(ctr);
							recomputeSpace = true;
						}
						else
							j++;
					}
					else
						j++;
				}
				//removing ConstraintActivityPreferredRooms-s referring to this activity
				for (int j = 0; j < this.spaceConstraintsList.size();)
				{
					SpaceConstraint ctr = this.spaceConstraintsList[j];
					if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITY_PREFERRED_ROOMS)
					{
						if (((ConstraintActivityPreferredRooms)ctr).activityId == act.id)
							this.removeSpaceConstraint(ctr);
						else
							j++;
					}
					else
						j++;
				}

				this.activitiesList[i] = null;
				this.activitiesList.removeAt(i); //if this is the last activity, then we will make one more comparison above
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_MIN_DAYS_BETWEEN_ACTIVITIES)
			{
				((ConstraintMinDaysBetweenActivities)ctr).removeUseless(this);
				if (((ConstraintMinDaysBetweenActivities)ctr).n_activities < 2)
					this.removeTimeConstraint(ctr);
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_OCCUPY_MAX_TIME_SLOTS_FROM_SELECTION)
			{
				((ConstraintActivitiesOccupyMaxTimeSlotsFromSelection)ctr).removeUseless(this);
				if (((ConstraintActivitiesOccupyMaxTimeSlotsFromSelection)ctr).activitiesIds.count() < 1)
					this.removeTimeConstraint(ctr);
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_MAX_SIMULTANEOUS_IN_SELECTED_TIME_SLOTS)
			{
				((ConstraintActivitiesMaxSimultaneousInSelectedTimeSlots)ctr).removeUseless(this);
				if (((ConstraintActivitiesMaxSimultaneousInSelectedTimeSlots)ctr).activitiesIds.count() < 1)
					this.removeTimeConstraint(ctr);
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_MAX_DAYS_BETWEEN_ACTIVITIES)
			{
				((ConstraintMaxDaysBetweenActivities)ctr).removeUseless(this);
				if (((ConstraintMaxDaysBetweenActivities)ctr).n_activities < 2)
					this.removeTimeConstraint(ctr);
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_MIN_GAPS_BETWEEN_ACTIVITIES)
			{
				((ConstraintMinGapsBetweenActivities)ctr).removeUseless(this);
				if (((ConstraintMinGapsBetweenActivities)ctr).n_activities < 2)
					this.removeTimeConstraint(ctr);
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_SAME_STARTING_TIME)
			{
				((ConstraintActivitiesSameStartingTime)ctr).removeUseless(this);
				if (((ConstraintActivitiesSameStartingTime)ctr).n_activities < 2)
					this.removeTimeConstraint(ctr);
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_SAME_STARTING_HOUR)
			{
				((ConstraintActivitiesSameStartingHour)ctr).removeUseless(this);
				if (((ConstraintActivitiesSameStartingHour)ctr).n_activities < 2)
					this.removeTimeConstraint(ctr);
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_SAME_STARTING_DAY)
			{
				((ConstraintActivitiesSameStartingDay)ctr).removeUseless(this);
				if (((ConstraintActivitiesSameStartingDay)ctr).n_activities < 2)
					this.removeTimeConstraint(ctr);
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.timeConstraintsList.size();)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_NOT_OVERLAPPING)
			{
				((ConstraintActivitiesNotOverlapping)ctr).removeUseless(this);
				if (((ConstraintActivitiesNotOverlapping)ctr).n_activities < 2)
					this.removeTimeConstraint(ctr);
				else
					i++;
			}
			else
				i++;
		}

		for (int i = 0; i < this.spaceConstraintsList.size();)
		{
			SpaceConstraint ctr = this.spaceConstraintsList[i];
			if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITIES_OCCUPY_MAX_DIFFERENT_ROOMS)
			{
				((ConstraintActivitiesOccupyMaxDifferentRooms)ctr).removeUseless(this);
				if (((ConstraintActivitiesOccupyMaxDifferentRooms)ctr).activitiesIds.count() < 2)
					this.removeSpaceConstraint(ctr);
				else
					i++;
			}
			else
				i++;
		}

		if (recomputeTime)
		{
			LockUnlock.computeLockedUnlockedActivitiesOnlyTime();
		}
		if (recomputeSpace)
		{
			LockUnlock.computeLockedUnlockedActivitiesOnlySpace();
		}
		if (recomputeTime || recomputeSpace)
		{
			LockUnlock.increaseCommunicationSpinBox();
		}

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);
	}

	/**
	A function to modify the information of a certain activity.
	If this is a sub-activity of a split activity,
	all the sub-activities will be modified.
	*/
	private void modifyActivity(int _id, int _activityGroupId, QStringList _teachersNames, QString _subjectName, QStringList _activityTagsNames, QStringList _studentsNames, int _nSplits, int _totalDuration, int[] _durations, bool[] _active, bool _computeNTotalStudents, int _nTotalStudents)
		//int _nTotalStudents,
		//int _parities[],
	{
		int i = 0;
		for (int j = 0; j < this.activitiesList.size(); j++)
		{
			Activity act = this.activitiesList[j];
			if ((_activityGroupId == 0 && act.id == _id) || (_activityGroupId != 0 && act.activityGroupId == _activityGroupId))
			{
				act.teachersNames = _teachersNames;
				act.subjectName = _subjectName;
				act.activityTagsNames = _activityTagsNames;
				act.studentsNames = _studentsNames;
				act.duration = _durations[i];
				//act->parity=_parities[i];
				act.active = _active[i];
				act.totalDuration = _totalDuration;
				act.computeNTotalStudents = _computeNTotalStudents;
				act.nTotalStudents = _nTotalStudents;
				i++;
			}
		}

		Debug.Assert(i == _nSplits);

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);
	}

	private void modifySubactivity(int _id, int _activityGroupId, QStringList _teachersNames, QString _subjectName, QStringList _activityTagsNames, QStringList _studentsNames, int _duration, bool _active, bool _computeNTotalStudents, int _nTotalStudents)
	{
		QList<Activity> actsList = new QList<Activity>();
		Activity crtAct = null;

		foreach (Activity * act, this.activitiesList)
		{
			if (act.id == _id && act.activityGroupId == _activityGroupId)
			{
				crtAct = act;
				//actsList.append(act);
			}
			else if (act.activityGroupId != 0 && _activityGroupId != 0 && act.activityGroupId == _activityGroupId)
			{
				actsList.append(act);
			}
		}

		Debug.Assert(crtAct != null);

		int td = 0;
		foreach (Activity * act, actsList) td += act.duration;
		td += _duration; //crtAct->duration;
		foreach (Activity * act, actsList) act.totalDuration = td;

		crtAct.teachersNames = _teachersNames;
		crtAct.subjectName = _subjectName;
		crtAct.activityTagsNames = _activityTagsNames;
		crtAct.studentsNames = _studentsNames;
		crtAct.duration = _duration;
		crtAct.totalDuration = td;
		crtAct.active = _active;
		crtAct.computeNTotalStudents = _computeNTotalStudents;
		crtAct.nTotalStudents = _nTotalStudents;

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);
	}

	/**
	Adds a new room (already allocated).
	Returns true on success, false for already existing rooms (same name).
	*/
	private bool addRoom(Room rm)
	{
		if (this.searchRoom(rm.name) >= 0)
			return false;
		this.roomsList << rm; //append
		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		teachers_schedule_ready = false;
		students_schedule_ready = false;
		rooms_schedule_ready = false;

		return true;
	}

	/*
	Faster, when reading
	*/
	private bool addRoomFast(Room rm)
	{
		this.roomsList << rm; //append
		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		teachers_schedule_ready = false;
		students_schedule_ready = false;
		rooms_schedule_ready = false;

		return true;
	}

	/**
	Returns -1 if not found or the index in the rooms list if found.
	*/
	private int searchRoom(QString roomName)
	{
		for (int i = 0; i < this.roomsList.size(); i++)
			if (this.roomsList[i].name == roomName)
				return i;

		return -1;
	}

	/**
	Removes the room with this name.
	Returns true on success, false on failure (not found).
	*/
	private bool removeRoom(QWidget parent, QString roomName)
	{
		bool recomputeSpace = false;

		int i = this.searchRoom(roomName);
		if (i < 0)
			return false;

		Room searchedRoom = this.roomsList[i];
		Debug.Assert(searchedRoom.name == roomName);

		for (int j = 0; j < this.spaceConstraintsList.size();)
		{
			SpaceConstraint ctr = this.spaceConstraintsList[j];
			if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_ROOM_NOT_AVAILABLE_TIMES)
			{
				ConstraintRoomNotAvailableTimes crna = (ConstraintRoomNotAvailableTimes)ctr;
				if (crna.room == roomName)
					this.removeSpaceConstraint(ctr);
				else
					j++;
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITY_PREFERRED_ROOM)
			{
				ConstraintActivityPreferredRoom c = (ConstraintActivityPreferredRoom)ctr;
				if (c.roomName == roomName)
				{
					this.removeSpaceConstraint(ctr);

					recomputeSpace = true;
				}
				else
					j++;
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITY_PREFERRED_ROOMS)
			{
				ConstraintActivityPreferredRooms c = (ConstraintActivityPreferredRooms)ctr;
				int t = c.roomsNames.removeAll(roomName);
				Debug.Assert(t <= 1);
				if (t == 1 && c.roomsNames.count() == 0)
					this.removeSpaceConstraint(ctr);
				else if (t == 1 && c.roomsNames.count() == 1)
				{
					ConstraintActivityPreferredRoom c2 = new ConstraintActivityPreferredRoom(c.weightPercentage, c.activityId, c.roomsNames.at(0), true); //true means permanently locked

					RulesUsualInformation.information(parent, tr("FET information"), tr("The constraint\n%1 will be modified into constraint\n%2 because" + " there is only one room left in the constraint").arg(c.getDetailedDescription(this)).arg(c2.getDetailedDescription(this)));

					this.removeSpaceConstraint(ctr);
					this.addSpaceConstraint(c2);

					recomputeSpace = true;
				}
				else
					j++;
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_HOME_ROOM)
			{
				ConstraintStudentsSetHomeRoom c = (ConstraintStudentsSetHomeRoom)ctr;
				if (c.roomName == roomName)
					this.removeSpaceConstraint(ctr);
				else
					j++;
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_HOME_ROOMS)
			{
				ConstraintStudentsSetHomeRooms c = (ConstraintStudentsSetHomeRooms)ctr;
				int t = c.roomsNames.removeAll(roomName);
				Debug.Assert(t <= 1);
				if (t == 1 && c.roomsNames.count() == 0)
					this.removeSpaceConstraint(ctr);
				else if (t == 1 && c.roomsNames.count() == 1)
				{
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: ConstraintStudentsSetHomeRoom* c2 = new ConstraintStudentsSetHomeRoom(c->weightPercentage, c->studentsName, c->roomsNames.at(0));
					ConstraintStudentsSetHomeRoom c2 = new ConstraintStudentsSetHomeRoom(c.weightPercentage, new QString(c.studentsName), c.roomsNames.at(0));

					RulesUsualInformation.information(parent, tr("FET information"), tr("The constraint\n%1 will be modified into constraint\n%2 because" + " there is only one room left in the constraint").arg(c.getDetailedDescription(ref this)).arg(c2.getDetailedDescription(ref this)));

					this.removeSpaceConstraint(ctr);
					this.addSpaceConstraint(c2);
				}
				else
					j++;
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_TEACHER_HOME_ROOM)
			{
				ConstraintTeacherHomeRoom c = (ConstraintTeacherHomeRoom)ctr;
				if (c.roomName == roomName)
					this.removeSpaceConstraint(ctr);
				else
					j++;
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_TEACHER_HOME_ROOMS)
			{
				ConstraintTeacherHomeRooms c = (ConstraintTeacherHomeRooms)ctr;
				int t = c.roomsNames.removeAll(roomName);
				Debug.Assert(t <= 1);
				if (t == 1 && c.roomsNames.count() == 0)
					this.removeSpaceConstraint(ctr);
				else if (t == 1 && c.roomsNames.count() == 1)
				{
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: ConstraintTeacherHomeRoom* c2 = new ConstraintTeacherHomeRoom(c->weightPercentage, c->teacherName, c->roomsNames.at(0));
					ConstraintTeacherHomeRoom c2 = new ConstraintTeacherHomeRoom(c.weightPercentage, new QString(c.teacherName), c.roomsNames.at(0));

					RulesUsualInformation.information(parent, tr("FET information"), tr("The constraint\n%1 will be modified into constraint\n%2 because" + " there is only one room left in the constraint").arg(c.getDetailedDescription(ref this)).arg(c2.getDetailedDescription(ref this)));

					this.removeSpaceConstraint(ctr);
					this.addSpaceConstraint(c2);
				}
				else
					j++;
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_SUBJECT_PREFERRED_ROOM)
			{
				ConstraintSubjectPreferredRoom c = (ConstraintSubjectPreferredRoom)ctr;
				if (c.roomName == roomName)
					this.removeSpaceConstraint(ctr);
				else
					j++;
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_SUBJECT_PREFERRED_ROOMS)
			{
				ConstraintSubjectPreferredRooms c = (ConstraintSubjectPreferredRooms)ctr;
				int t = c.roomsNames.removeAll(roomName);
				Debug.Assert(t <= 1);
				if (t == 1 && c.roomsNames.count() == 0)
					this.removeSpaceConstraint(ctr);
				else if (t == 1 && c.roomsNames.count() == 1)
				{
					ConstraintSubjectPreferredRoom c2 = new ConstraintSubjectPreferredRoom(c.weightPercentage, c.subjectName, c.roomsNames.at(0));

					RulesUsualInformation.information(parent, tr("FET information"), tr("The constraint\n%1 will be modified into constraint\n%2 because" + " there is only one room left in the constraint").arg(c.getDetailedDescription(ref this)).arg(c2.getDetailedDescription(ref this)));

					this.removeSpaceConstraint(ctr);
					this.addSpaceConstraint(c2);
				}
				else
					j++;
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_SUBJECT_ACTIVITY_TAG_PREFERRED_ROOM)
			{
				ConstraintSubjectActivityTagPreferredRoom c = (ConstraintSubjectActivityTagPreferredRoom)ctr;
				if (c.roomName == roomName)
					this.removeSpaceConstraint(ctr);
				else
					j++;
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_SUBJECT_ACTIVITY_TAG_PREFERRED_ROOMS)
			{
				ConstraintSubjectActivityTagPreferredRooms c = (ConstraintSubjectActivityTagPreferredRooms)ctr;
				int t = c.roomsNames.removeAll(roomName);
				Debug.Assert(t <= 1);
				if (t == 1 && c.roomsNames.count() == 0)
					this.removeSpaceConstraint(ctr);
				else if (t == 1 && c.roomsNames.count() == 1)
				{
					ConstraintSubjectActivityTagPreferredRoom c2 = new ConstraintSubjectActivityTagPreferredRoom(c.weightPercentage, c.subjectName, c.activityTagName, c.roomsNames.at(0));

					RulesUsualInformation.information(parent, tr("FET information"), tr("The constraint\n%1 will be modified into constraint\n%2 because" + " there is only one room left in the constraint").arg(c.getDetailedDescription(ref this)).arg(c2.getDetailedDescription(ref this)));

					this.removeSpaceConstraint(ctr);
					this.addSpaceConstraint(c2);
				}
				else
					j++;
			}

			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITY_TAG_PREFERRED_ROOM)
			{
				ConstraintActivityTagPreferredRoom c = (ConstraintActivityTagPreferredRoom)ctr;
				if (c.roomName == roomName)
					this.removeSpaceConstraint(ctr);
				else
					j++;
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITY_TAG_PREFERRED_ROOMS)
			{
				ConstraintActivityTagPreferredRooms c = (ConstraintActivityTagPreferredRooms)ctr;
				int t = c.roomsNames.removeAll(roomName);
				Debug.Assert(t <= 1);
				if (t == 1 && c.roomsNames.count() == 0)
					this.removeSpaceConstraint(ctr);
				else if (t == 1 && c.roomsNames.count() == 1)
				{
					ConstraintActivityTagPreferredRoom c2 = new ConstraintActivityTagPreferredRoom(c.weightPercentage, c.activityTagName, c.roomsNames.at(0));

					RulesUsualInformation.information(parent, tr("FET information"), tr("The constraint\n%1 will be modified into constraint\n%2 because" + " there is only one room left in the constraint").arg(c.getDetailedDescription(ref this)).arg(c2.getDetailedDescription(ref this)));

					this.removeSpaceConstraint(ctr);
					this.addSpaceConstraint(c2);
				}
				else
					j++;
			}

			else
				j++;
		}

		this.roomsList[i] = null;
		this.roomsList.removeAt(i);

		if (recomputeSpace)
		{
			LockUnlock.computeLockedUnlockedActivitiesOnlySpace();
			LockUnlock.increaseCommunicationSpinBox();
		}

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		teachers_schedule_ready = false;
		students_schedule_ready = false;
		rooms_schedule_ready = false;

		return true;
	}

	/**
	Modifies this room and takes care of all related constraints.
	Returns true on success, false on failure (if not found)
	*/
	private bool modifyRoom(QString initialRoomName, QString finalRoomName, QString building, int capacity)
	{
		int i = this.searchRoom(initialRoomName);
		if (i < 0)
			return false;

		Room searchedRoom = this.roomsList[i];
		Debug.Assert(searchedRoom.name == initialRoomName);

		for (int j = 0; j < this.spaceConstraintsList.size();)
		{
			SpaceConstraint ctr = this.spaceConstraintsList[j];
			if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_ROOM_NOT_AVAILABLE_TIMES)
			{
				ConstraintRoomNotAvailableTimes crna = (ConstraintRoomNotAvailableTimes)ctr;
				if (crna.room == initialRoomName)
					crna.room = finalRoomName;
				j++;
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITY_PREFERRED_ROOM)
			{
				ConstraintActivityPreferredRoom c = (ConstraintActivityPreferredRoom)ctr;
				if (c.roomName == initialRoomName)
					c.roomName = finalRoomName;
				j++;
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITY_PREFERRED_ROOMS)
			{
				ConstraintActivityPreferredRooms c = (ConstraintActivityPreferredRooms)ctr;
				int t = 0;
				for (QStringList.Iterator it = c.roomsNames.begin(); it != c.roomsNames.end(); it++)
				{
					if ((*it) == initialRoomName)
					{
						*it = finalRoomName;
						t++;
					}
				}
				Debug.Assert(t <= 1);
				j++;
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_HOME_ROOM)
			{
				ConstraintStudentsSetHomeRoom c = (ConstraintStudentsSetHomeRoom)ctr;
				if (c.roomName == initialRoomName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: c->roomName=finalRoomName;
					c.roomName.CopyFrom(finalRoomName);
				j++;
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_HOME_ROOMS)
			{
				ConstraintStudentsSetHomeRooms c = (ConstraintStudentsSetHomeRooms)ctr;
				int t = 0;
				for (QStringList.Iterator it = c.roomsNames.begin(); it != c.roomsNames.end(); it++)
				{
					if ((*it) == initialRoomName)
					{
						*it = finalRoomName;
						t++;
					}
				}
				Debug.Assert(t <= 1);
				j++;
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_TEACHER_HOME_ROOM)
			{
				ConstraintTeacherHomeRoom c = (ConstraintTeacherHomeRoom)ctr;
				if (c.roomName == initialRoomName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: c->roomName=finalRoomName;
					c.roomName.CopyFrom(finalRoomName);
				j++;
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_TEACHER_HOME_ROOMS)
			{
				ConstraintTeacherHomeRooms c = (ConstraintTeacherHomeRooms)ctr;
				int t = 0;
				for (QStringList.Iterator it = c.roomsNames.begin(); it != c.roomsNames.end(); it++)
				{
					if ((*it) == initialRoomName)
					{
						*it = finalRoomName;
						t++;
					}
				}
				Debug.Assert(t <= 1);
				j++;
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_SUBJECT_PREFERRED_ROOM)
			{
				ConstraintSubjectPreferredRoom c = (ConstraintSubjectPreferredRoom)ctr;
				if (c.roomName == initialRoomName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: c->roomName=finalRoomName;
					c.roomName.CopyFrom(finalRoomName);
				j++;
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_SUBJECT_PREFERRED_ROOMS)
			{
				ConstraintSubjectPreferredRooms c = (ConstraintSubjectPreferredRooms)ctr;
				int t = 0;
				for (QStringList.Iterator it = c.roomsNames.begin(); it != c.roomsNames.end(); it++)
				{
					if ((*it) == initialRoomName)
					{
						*it = finalRoomName;
						t++;
					}
				}
				Debug.Assert(t <= 1);
				j++;
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_SUBJECT_ACTIVITY_TAG_PREFERRED_ROOM)
			{
				ConstraintSubjectActivityTagPreferredRoom c = (ConstraintSubjectActivityTagPreferredRoom)ctr;
				if (c.roomName == initialRoomName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: c->roomName=finalRoomName;
					c.roomName.CopyFrom(finalRoomName);
				j++;
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_SUBJECT_ACTIVITY_TAG_PREFERRED_ROOMS)
			{
				ConstraintSubjectActivityTagPreferredRooms c = (ConstraintSubjectActivityTagPreferredRooms)ctr;
				int t = 0;
				for (QStringList.Iterator it = c.roomsNames.begin(); it != c.roomsNames.end(); it++)
				{
					if ((*it) == initialRoomName)
					{
						*it = finalRoomName;
						t++;
					}
				}
				Debug.Assert(t <= 1);
				j++;
			}

			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITY_TAG_PREFERRED_ROOM)
			{
				ConstraintActivityTagPreferredRoom c = (ConstraintActivityTagPreferredRoom)ctr;
				if (c.roomName == initialRoomName)
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: c->roomName=finalRoomName;
					c.roomName.CopyFrom(finalRoomName);
				j++;
			}
			else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITY_TAG_PREFERRED_ROOMS)
			{
				ConstraintActivityTagPreferredRooms c = (ConstraintActivityTagPreferredRooms)ctr;
				int t = 0;
				for (QStringList.Iterator it = c.roomsNames.begin(); it != c.roomsNames.end(); it++)
				{
					if ((*it) == initialRoomName)
					{
						*it = finalRoomName;
						t++;
					}
				}
				Debug.Assert(t <= 1);
				j++;
			}

			else
				j++;
		}

		searchedRoom.name = finalRoomName;
		searchedRoom.building = building;
		searchedRoom.capacity = capacity;

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);
		return true;
	}

	/**
	A function to sort the room alphabetically, by name
	*/
	private void sortRoomsAlphabetically()
	{
		qSort(this.roomsList.begin(), this.roomsList.end(), GlobalMembersRoom.roomsAscending);

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);
	}

	/**
	Adds a new building (already allocated).
	Returns true on success, false for already existing buildings (same name).
	*/
	private bool addBuilding(Building bu)
	{
		if (this.searchBuilding(bu.name) >= 0)
			return false;
		this.buildingsList << bu; //append
		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		teachers_schedule_ready = false;
		students_schedule_ready = false;
		rooms_schedule_ready = false;

		return true;
	}

	/*
	Faster, when reading
	*/
	private bool addBuildingFast(Building bu)
	{
		this.buildingsList << bu; //append
		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		teachers_schedule_ready = false;
		students_schedule_ready = false;
		rooms_schedule_ready = false;

		return true;
	}

	/**
	Returns -1 if not found or the index in the buildings list if found.
	*/
	private int searchBuilding(QString buildingName)
	{
		for (int i = 0; i < this.buildingsList.size(); i++)
			if (this.buildingsList[i].name == buildingName)
				return i;

		return -1;
	}

	/**
	Removes the building with this name.
	Returns true on success, false on failure (not found).
	*/
	private bool removeBuilding(QString buildingName)
	{
		foreach (Room * rm, this.roomsList) if (rm.building == buildingName) rm.building = "";

		int i = this.searchBuilding(buildingName);
		if (i < 0)
			return false;

		Building searchedBuilding = this.buildingsList[i];
		Debug.Assert(searchedBuilding.name == buildingName);

		this.buildingsList[i] = null;
		this.buildingsList.removeAt(i);

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		teachers_schedule_ready = false;
		students_schedule_ready = false;
		rooms_schedule_ready = false;

		return true;
	}

	/**
	Modifies this building and takes care of all related constraints.
	Returns true on success, false on failure (if not found)
	*/
	private bool modifyBuilding(QString initialBuildingName, QString finalBuildingName)
	{
		foreach (Room * rm, roomsList) if (rm.building == initialBuildingName) rm.building = finalBuildingName;

		int i = this.searchBuilding(initialBuildingName);
		if (i < 0)
			return false;

		Building searchedBuilding = this.buildingsList[i];
		Debug.Assert(searchedBuilding.name == initialBuildingName);
		searchedBuilding.name = finalBuildingName;

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);
		return true;
	}

	/**
	A function to sort the buildings alphabetically, by name
	*/
	private void sortBuildingsAlphabetically()
	{
		qSort(this.buildingsList.begin(), this.buildingsList.end(), GlobalMembersBuilding.buildingsAscending);

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);
	}

	/**
	Adds a new time constraint (already allocated).
	Returns true on success, false for already existing constraints.
	*/
	private bool addTimeConstraint(TimeConstraint ctr)
	{
		bool ok = true;

		//TODO: improve this

		//check if this constraint is already added, for ConstraintActivityPreferredStartingTime
		if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITY_PREFERRED_STARTING_TIME)
		{
			int i;
			for (i = 0; i < this.timeConstraintsList.size(); i++)
			{
				TimeConstraint ctr2 = this.timeConstraintsList[i];
				if (ctr2.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITY_PREFERRED_STARTING_TIME)
					if ((ConstraintActivityPreferredStartingTime)ctr2 == (ConstraintActivityPreferredStartingTime)ctr)
						break;
			}

			if (i < this.timeConstraintsList.size())
				ok = false;
		}

		//check if this constraint is already added, for ConstraintMinDaysBetweenActivities
		else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_MIN_DAYS_BETWEEN_ACTIVITIES)
		{
			int i;
			for (i = 0; i < this.timeConstraintsList.size(); i++)
			{
				TimeConstraint ctr2 = this.timeConstraintsList[i];
				if (ctr2.type == GlobalMembersTimeconstraint.CONSTRAINT_MIN_DAYS_BETWEEN_ACTIVITIES)
					if ((ConstraintMinDaysBetweenActivities)ctr2 == (ConstraintMinDaysBetweenActivities)ctr)
						break;
			}

			if (i < this.timeConstraintsList.size())
				ok = false;
		}

		else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_NOT_AVAILABLE_TIMES)
		{
			int i;
			ConstraintStudentsSetNotAvailableTimes ssna = (ConstraintStudentsSetNotAvailableTimes)ctr;
			for (i = 0; i < this.timeConstraintsList.size(); i++)
			{
				TimeConstraint ctr2 = this.timeConstraintsList[i];
				if (ctr2.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_NOT_AVAILABLE_TIMES)
				{
					ConstraintStudentsSetNotAvailableTimes ssna2 = (ConstraintStudentsSetNotAvailableTimes)ctr2;
					if (ssna.students == ssna2.students)
						break;
				}
			}

			if (i < this.timeConstraintsList.size())
				ok = false;
		}

		else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_NOT_AVAILABLE_TIMES)
		{
			int i;
			ConstraintTeacherNotAvailableTimes tna = (ConstraintTeacherNotAvailableTimes)ctr;
			for (i = 0; i < this.timeConstraintsList.size(); i++)
			{
				TimeConstraint ctr2 = this.timeConstraintsList[i];
				if (ctr2.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_NOT_AVAILABLE_TIMES)
				{
					ConstraintTeacherNotAvailableTimes tna2 = (ConstraintTeacherNotAvailableTimes)ctr2;
					if (tna.teacher == tna2.teacher)
						break;
				}
			}

			if (i < this.timeConstraintsList.size())
				ok = false;
		}

		else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_BREAK_TIMES)
		{
			int i;
			for (i = 0; i < this.timeConstraintsList.size(); i++)
			{
				TimeConstraint ctr2 = this.timeConstraintsList[i];
				if (ctr2.type == GlobalMembersTimeconstraint.CONSTRAINT_BREAK_TIMES)
					break;
			}

			if (i < this.timeConstraintsList.size())
				ok = false;
		}

		else if (ctr.type == GlobalMembersTimeconstraint.CONSTRAINT_BASIC_COMPULSORY_TIME)
		{
			int i;
			for (i = 0; i < this.timeConstraintsList.size(); i++)
			{
				TimeConstraint ctr2 = this.timeConstraintsList[i];
				if (ctr2.type == GlobalMembersTimeconstraint.CONSTRAINT_BASIC_COMPULSORY_TIME)
					break;
			}

			if (i < this.timeConstraintsList.size())
				ok = false;
		}

		if (ok)
		{
			this.timeConstraintsList << ctr; //append
			this.internalStructureComputed = false;
			setRulesModifiedAndOtherThings(this);
			return true;
		}
		else
			return false;
	}

	/**
	Removes this time constraint.
	Returns true on success, false on failure (not found).
	*/
	private bool removeTimeConstraint(TimeConstraint ctr)
	{
		for (int i = 0; i < this.timeConstraintsList.size(); i++)
			if (this.timeConstraintsList[i] == ctr)
			{
				if (ctr != null)
					ctr.Dispose();
				this.timeConstraintsList.removeAt(i);
				this.internalStructureComputed = false;
				setRulesModifiedAndOtherThings(this);

				return true;
			}

		return false;
	}

	/**
	Adds a new space constraint (already allocated).
	Returns true on success, false for already existing constraints.
	*/
	private bool addSpaceConstraint(SpaceConstraint ctr)
	{
		bool ok = true;

		//TODO: check if this constraint is already added...(if any possibility of duplicates)
		if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITY_PREFERRED_ROOM)
		{
			int i;
			for (i = 0; i < this.spaceConstraintsList.size(); i++)
			{
				SpaceConstraint ctr2 = this.spaceConstraintsList[i];
				if (ctr2.type == GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITY_PREFERRED_ROOM)
					if ((ConstraintActivityPreferredRoom)ctr2 == (ConstraintActivityPreferredRoom)ctr)
						break;
			}

			if (i < this.spaceConstraintsList.size())
				ok = false;
		}
	/*	else if(ctr->type==CONSTRAINT_ROOM_NOT_AVAILABLE_TIMES){
			int i;
			ConstraintRoomNotAvailableTimes* c=(ConstraintRoomNotAvailableTimes*)ctr;
			for(i=0; i<this->spaceConstraintsList.size(); i++){
				SpaceConstraint* ctr2=this->spaceConstraintsList[i];
				if(ctr2->type==CONSTRAINT_ROOM_NOT_AVAILABLE_TIMES){
					ConstraintRoomNotAvailableTimes* c2=(ConstraintRoomNotAvailableTimes*)ctr2;
					if(c->room==c2->room)
						break;
				}
			}
	
			if(i<this->spaceConstraintsList.size())
				ok=false;
		}*/
		else if (ctr.type == GlobalMembersSpaceconstraint.CONSTRAINT_BASIC_COMPULSORY_SPACE)
		{
			int i;
			for (i = 0; i < this.spaceConstraintsList.size(); i++)
			{
				SpaceConstraint ctr2 = this.spaceConstraintsList[i];
				if (ctr2.type == GlobalMembersSpaceconstraint.CONSTRAINT_BASIC_COMPULSORY_SPACE)
					break;
			}

			if (i < this.spaceConstraintsList.size())
				ok = false;
		}

		if (ok)
		{
			this.spaceConstraintsList << ctr; //append
			this.internalStructureComputed = false;
			setRulesModifiedAndOtherThings(this);
			return true;
		}
		else
			return false;
	}

	/**
	Removes this space constraint.
	Returns true on success, false on failure (not found).
	*/
	private bool removeSpaceConstraint(SpaceConstraint ctr)
	{
		for (int i = 0; i < this.spaceConstraintsList.size(); i++)
			if (this.spaceConstraintsList[i] == ctr)
			{
				if (ctr != null)
					ctr.Dispose();
				this.spaceConstraintsList.removeAt(i);
				this.internalStructureComputed = false;
				setRulesModifiedAndOtherThings(this);

				return true;
			}

		return false;
	}

	/**
	Reads the rules from the xml input file "filename".
	Returns true on success, false on failure (inexistent file or wrong format)
	*/
	private bool read(QWidget parent, QString filename, bool commandLine)
	{
		return read(parent, filename, commandLine, new QString());
	}
	private bool read(QWidget parent, QString filename)
	{
		return read(parent, filename, false, new QString());
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: bool read(QWidget* parent, const QString& filename, bool commandLine =false, QString commandLineDirectory =QString())
	private bool read(QWidget parent, QString filename, bool commandLine, QString commandLineDirectory)
	{
		//bool reportWhole=true;

		QFile file = new QFile(filename);
		if (!file.open(QIODevice.ReadOnly))
		{
			//cout<<"Could not open file - not existing or in use\n";
			RulesIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Could not open file - not existing or in use"));
			return false;
		}
		//QDomDocument doc("xml_rules");
		QDomDocument doc = new QDomDocument();

		QString errorStr = new QString();
		int errorLine;
		int errorColumn;

		if (!doc.setContent(file, true, errorStr, errorLine, errorColumn))
		{
			RulesIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Could not read file - XML parse error at line %1, column %2:\n%3", "The error description is %3").arg(errorLine).arg(errorColumn).arg(errorStr));

			file.close();
			return false;
		}
		file.close();

		////////////////////////////////////////

		if (!commandLine)
		{
			//logging part
			QDir dir = new QDir();
			bool t = true;
			if (!dir.exists(GlobalMembersTimetable_defs.OUTPUT_DIR + GlobalMembersTimetable_defs.FILE_SEP + "logs"))
				t = dir.mkpath(GlobalMembersTimetable_defs.OUTPUT_DIR + GlobalMembersTimetable_defs.FILE_SEP + "logs");
			if (!t)
			{
				RulesIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Cannot create or use directory %1 - cannot continue").arg(QDir.toNativeSeparators(GlobalMembersTimetable_defs.OUTPUT_DIR + GlobalMembersTimetable_defs.FILE_SEP + "logs")));
				return false;
			}
			Debug.Assert(t);
		}
		else
		{
			QDir dir = new QDir();
			bool t = true;
			if (!dir.exists(commandLineDirectory + "logs"))
				t = dir.mkpath(commandLineDirectory + "logs");
			if (!t)
			{
				RulesIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Cannot create or use directory %1 - cannot continue").arg(QDir.toNativeSeparators(commandLineDirectory + "logs")));
				return false;
			}
			Debug.Assert(t);
		}

		FakeString xmlReadingLog = new FakeString();
		xmlReadingLog = "";

		QDate dat = QDate.currentDate();
		QTime tim = QTime.currentTime();
		QLocale loc = new QLocale(GlobalMembersTimetable_defs.FET_LANGUAGE);
		QString sTime = loc.toString(dat, QLocale.ShortFormat) + " " + loc.toString(tim, QLocale.ShortFormat);

		QString reducedXmlLog = "";
		reducedXmlLog += "Log generated by FET " + GlobalMembersTimetable_defs.FET_VERSION + " on " + sTime + "\n\n";
		QString shortFilename = filename.right(filename.length() - filename.lastIndexOf(GlobalMembersTimetable_defs.FILE_SEP) - 1);
		reducedXmlLog += "Reading file " + shortFilename + "\n";
		QFileInfo fileinfo = new QFileInfo(filename);
		reducedXmlLog += "Complete file name, including path: " + QDir.toNativeSeparators(fileinfo.absoluteFilePath()) + "\n";
		reducedXmlLog += "\n";

		QString tmp = new QString();
		if (commandLine)
			tmp = commandLineDirectory + "logs" + GlobalMembersTimetable_defs.FILE_SEP + GlobalMembersTimetable_defs.XML_PARSING_LOG_FILENAME;
		else
			tmp = GlobalMembersTimetable_defs.OUTPUT_DIR + GlobalMembersTimetable_defs.FILE_SEP + "logs" + GlobalMembersTimetable_defs.FILE_SEP + GlobalMembersTimetable_defs.XML_PARSING_LOG_FILENAME;
		QFile file2 = new QFile(tmp);
		bool canWriteLogFile = true;
		if (!file2.open(QIODevice.WriteOnly))
		{
			QString s = tr("FET cannot open the log file %1 for writing. This might mean that you don't" + " have write permissions in this location. You can continue operation, but you might not be able to save the generated timetables" + " as html files").arg(QDir.toNativeSeparators(tmp)) + "\n\n" + tr("A solution is to remove that file (if it exists already) or set its permissions to allow writing") + "\n\n" + tr("Please report possible bug");
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), s);
			canWriteLogFile = false;
		}
		QTextStream logStream = new QTextStream();
		if (canWriteLogFile)
		{
			logStream.setDevice(file2);
			logStream.setCodec("UTF-8");
			logStream.setGenerateByteOrderMark(true);
		}

		QDomElement elem1 = doc.documentElement();
		xmlReadingLog += " Found " + elem1.tagName() + " tag\n";
		bool okAbove3_12_17 = true;
		bool version5AndAbove = false;
		bool warning = false;

		QString file_version = new QString();

		bool okfetTag;
		if (elem1.tagName() == "fet" || elem1.tagName() == "FET") //the new tag is fet, the old tag - FET
			okfetTag = true;
		else
			okfetTag = false;

		if (!okfetTag)
			okAbove3_12_17 = false;
		else
		{
			Debug.Assert(okAbove3_12_17 == true);
			/*QDomDocumentType dt=doc.doctype();
			if(dt.isNull() || dt.name()!="FET")
				okAbove3_12_17=false;
			else*/
			int[] filev = new int[3];
			int[] fetv = new int[3];

			QDomAttr a = elem1.attributeNode("version");

			QString version = a.value();
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: file_version=version;
			file_version.CopyFrom(version);

			QRegExp fileVerReCap = new QRegExp("^(\\d+)\\.(\\d+)\\.(\\d+)(.*)$");

			int tfile = fileVerReCap.indexIn(file_version);
			filev[0] = filev[1] = filev[2] = -1;
			if (tfile != 0)
			{
				RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("File contains a version numbering scheme which" + " is not matched by v.v.va (3 numbers separated by points, followed by any string a, which may be empty). File will be opened, but you are adviced" + " to check the version of the .fet file (in the beginning of the file). If this is a FET bug, please report it") + "\n\n" + tr("If you are opening a file older than FET format version 5, it will be converted to latest FET data format"));
				Console.Write("Opened file version not matched by regexp");
				Console.Write("\n");
			}
			else
			{
				bool ok;
				filev[0] = fileVerReCap.cap(1).toInt(ok);
				Debug.Assert(ok);
				filev[1] = fileVerReCap.cap(2).toInt(ok);
				Debug.Assert(ok);
				filev[2] = fileVerReCap.cap(3).toInt(ok);
				Debug.Assert(ok);
				Console.Write("Opened file version matched by regexp: major=");
				Console.Write(filev[0]);
				Console.Write(", minor=");
				Console.Write(filev[1]);
				Console.Write(", revision=");
				Console.Write(filev[2]);
				Console.Write(", additional text=");
				Console.Write(qPrintable(fileVerReCap.cap(4)));
				Console.Write(".");
				Console.Write("\n");
			}

			QRegExp fetVerReCap = new QRegExp("^(\\d+)\\.(\\d+)\\.(\\d+)(.*)$");

			int tfet = fetVerReCap.indexIn(GlobalMembersTimetable_defs.FET_VERSION);
			fetv[0] = fetv[1] = fetv[2] = -1;
			if (tfet != 0)
			{
				RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("FET version does not respect the format v.v.va" + " (3 numbers separated by points, followed by any string a, which may be empty). This is probably a bug in FET - please report it"));
				Console.Write("FET version not matched by regexp");
				Console.Write("\n");
			}
			else
			{
				bool ok;
				fetv[0] = fetVerReCap.cap(1).toInt(ok);
				Debug.Assert(ok);
				fetv[1] = fetVerReCap.cap(2).toInt(ok);
				Debug.Assert(ok);
				fetv[2] = fetVerReCap.cap(3).toInt(ok);
				Debug.Assert(ok);
				Console.Write("FET version matched by regexp: major=");
				Console.Write(fetv[0]);
				Console.Write(", minor=");
				Console.Write(fetv[1]);
				Console.Write(", revision=");
				Console.Write(fetv[2]);
				Console.Write(", additional text=");
				Console.Write(qPrintable(fetVerReCap.cap(4)));
				Console.Write(".");
				Console.Write("\n");
			}

			if (filev[0] >= 0 && fetv[0] >= 0 && filev[1] >= 0 && fetv[1] >= 0 && filev[2] >= 0 && fetv[2] >= 0)
			{
				if (filev[0] > fetv[0] || (filev[0] == fetv[0] && filev[1] > fetv[1]) || (filev[0] == fetv[0] && filev[1] == fetv[1] && filev[2] > fetv[2]))
				{
					warning = true;
				}
			}

			if (filev[0] >= 5 || (filev[0] == -1 && filev[1] == -1 && filev[2] == -1))
			//if major is >= 5 or major cannot be read
				version5AndAbove = true;
		}
		if (!okAbove3_12_17)
		{
			Console.Write("Invalid fet 3.12.17 or above");
			Console.Write("\n");
			file2.close();
			RulesIrreconcilableMessage.warning(parent, tr("FET warning"), tr("File does not have a corresponding beginning tag - it should be %1 or %2. File is incorrect..." + "it cannot be opened").arg("fet").arg("FET"));
			return false;
		}

		if (!version5AndAbove)
		{
			RulesReconcilableMessage.warning(parent, tr("FET information"), tr("Opening older file - it will be converted to latest format, automatically " + "assigning weight percentages to constraints and dropping parity for activities. " + "You are adviced to make a backup of your old file before saving in new format.\n\n" + "Please note that the default weight percentage of constraints min days between activities " + "will be 95% (mainly satisfied, not always) and 'force consecutive if same day' will be set to true " + "(meaning that if the activities are in the same day, they will be placed continuously, in a bigger duration activity)" + "If you want, you can modify this percent to be 100%, manually in the fet input file " + "or from the interface"));
		}

		if (warning)
		{
			RulesReconcilableMessage.warning(parent, tr("FET information"), tr("Opening a file generated with a newer version than your current FET software ... file will be opened but it is recommended to update your FET software to the latest version") + "\n\n" + tr("Your FET version: %1, file version: %2").arg(GlobalMembersTimetable_defs.FET_VERSION).arg(file_version));
		}

		//Clear old rules, initialize new rules
		if (this.initialized)
			this.kill();
		this.init();

		this.nHoursPerDay = 12;
		this.hoursOfTheDay[0] = "08:00";
		this.hoursOfTheDay[1] = "09:00";
		this.hoursOfTheDay[2] = "10:00";
		this.hoursOfTheDay[3] = "11:00";
		this.hoursOfTheDay[4] = "12:00";
		this.hoursOfTheDay[5] = "13:00";
		this.hoursOfTheDay[6] = "14:00";
		this.hoursOfTheDay[7] = "15:00";
		this.hoursOfTheDay[8] = "16:00";
		this.hoursOfTheDay[9] = "17:00";
		this.hoursOfTheDay[10] = "18:00";
		this.hoursOfTheDay[11] = "19:00";
		//this->hoursOfTheDay[12]="20:00";

		this.nDaysPerWeek = 5;
		this.daysOfTheWeek[0] = tr("Monday");
		this.daysOfTheWeek[1] = tr("Tuesday");
		this.daysOfTheWeek[2] = tr("Wednesday");
		this.daysOfTheWeek[3] = tr("Thursday");
		this.daysOfTheWeek[4] = tr("Friday");

		this.institutionName = tr("Default institution");
		this.comments = tr("Default comments");

		bool skipDeprecatedConstraints = false;

		bool skipDuplicatedStudentsSets = false;

		for (QDomNode node2 = elem1.firstChild(); !node2.isNull(); node2 = node2.nextSibling())
		{
			QDomElement elem2 = node2.toElement();
			if (elem2.isNull())
			{
				xmlReadingLog += "  Null node here\n";
				continue;
			}
			xmlReadingLog += "  Found " + elem2.tagName() + " tag\n";
			if (elem2.tagName() == "Institution_Name")
			{
				this.institutionName = elem2.text();
				xmlReadingLog += "  Found institution name=" + this.institutionName + "\n";
				reducedXmlLog += "Read institution name=" + this.institutionName + "\n";
			}
			else if (elem2.tagName() == "Comments")
			{
				this.comments = elem2.text();
				xmlReadingLog += "  Found comments=" + this.comments + "\n";
				reducedXmlLog += "Read comments=" + this.comments + "\n";
			}
			else if (elem2.tagName() == "Hours_List")
			{
				int tmp = 0;
				for (QDomNode node3 = elem2.firstChild(); !node3.isNull(); node3 = node3.nextSibling())
				{
					QDomElement elem3 = node3.toElement();
					if (elem3.isNull())
					{
						xmlReadingLog += "   Null node here\n";
						continue;
					}
					xmlReadingLog += "   Found " + elem3.tagName() + " tag\n";
					if (elem3.tagName() == "Number")
					{
						this.nHoursPerDay = elem3.text().toInt();
						xmlReadingLog += "   Found the number of hours per day = " + CustomFETString.number(this.nHoursPerDay) + "\n";
						reducedXmlLog += "Added " + CustomFETString.number(this.nHoursPerDay) + " hours per day\n";
						Debug.Assert(this.nHoursPerDay > 0);
					}
					else if (elem3.tagName() == "Name")
					{
						this.hoursOfTheDay[tmp] = elem3.text();
						xmlReadingLog += "   Found hour " + this.hoursOfTheDay[tmp] + "\n";
						tmp++;
					}
				}
				//don't do assert tmp == nHoursPerDay, because some older files contain also the end of day hour, so tmp==nHoursPerDay+1 in this case
			}
			else if (elem2.tagName() == "Days_List")
			{
				int tmp = 0;
				for (QDomNode node3 = elem2.firstChild(); !node3.isNull(); node3 = node3.nextSibling())
				{
					QDomElement elem3 = node3.toElement();
					if (elem3.isNull())
					{
						xmlReadingLog += "   Null node here\n";
						continue;
					}
					xmlReadingLog += "   Found " + elem3.tagName() + " tag\n";
					if (elem3.tagName() == "Number")
					{
						this.nDaysPerWeek = elem3.text().toInt();
						xmlReadingLog += "   Found the number of days per week = " + CustomFETString.number(this.nDaysPerWeek) + "\n";
						reducedXmlLog += "Added " + CustomFETString.number(this.nDaysPerWeek) + " days per week\n";
						Debug.Assert(this.nDaysPerWeek > 0);
					}
					else if (elem3.tagName() == "Name")
					{
						this.daysOfTheWeek[tmp] = elem3.text();
						xmlReadingLog += "   Found day " + this.daysOfTheWeek[tmp] + "\n";
						tmp++;
					}
				}
				Debug.Assert(tmp == this.nDaysPerWeek);
			}
			else if (elem2.tagName() == "Teachers_List")
			{
				QSet<QString> teachersRead = new QSet<QString>();

				int tmp = 0;
				for (QDomNode node3 = elem2.firstChild(); !node3.isNull(); node3 = node3.nextSibling())
				{
					QDomElement elem3 = node3.toElement();
					if (elem3.isNull())
					{
						xmlReadingLog += "   Null node here\n";
						continue;
					}
					xmlReadingLog += "   Found " + elem3.tagName() + " tag\n";
					if (elem3.tagName() == "Teacher")
					{
						Teacher teacher = new Teacher();
						for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
						{
							QDomElement elem4 = node4.toElement();
							if (elem4.isNull())
							{
								xmlReadingLog += "    Null node here\n";
								continue;
							}
							xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
							if (elem4.tagName() == "Name")
							{
								teacher.name = elem4.text();
								xmlReadingLog += "    Read teacher name: " + teacher.name + "\n";
							}
						}
						bool tmp2 = teachersRead.contains(teacher.name);
						if (tmp2)
						{
							RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("Duplicate teacher %1 found - ignoring").arg(teacher.name));
							xmlReadingLog += "   Teacher not added - duplicate\n";
						}
						else
						{
							teachersRead.insert(teacher.name);
							this.addTeacherFast(teacher);
							tmp++;
							xmlReadingLog += "   Teacher added\n";
						}
					}
				}
				Debug.Assert(tmp == this.teachersList.size());
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: xmlReadingLog+="  Added "+CustomFETString::number(tmp)+" teachers\n";
				xmlReadingLog += "  Added " + CustomFETString.number(new QString(tmp)) + " teachers\n";
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: reducedXmlLog+="Added "+CustomFETString::number(tmp)+" teachers\n";
				reducedXmlLog += "Added " + CustomFETString.number(new QString(tmp)) + " teachers\n";
			}
			else if (elem2.tagName() == "Subjects_List")
			{
				QSet<QString> subjectsRead = new QSet<QString>();

				int tmp = 0;
				for (QDomNode node3 = elem2.firstChild(); !node3.isNull(); node3 = node3.nextSibling())
				{
					QDomElement elem3 = node3.toElement();
					if (elem3.isNull())
					{
						xmlReadingLog += "   Null node here\n";
						continue;
					}
					xmlReadingLog += "   Found " + elem3.tagName() + " tag\n";
					if (elem3.tagName() == "Subject")
					{
						Subject subject = new Subject();
						for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
						{
							QDomElement elem4 = node4.toElement();
							if (elem4.isNull())
							{
								xmlReadingLog += "    Null node here\n";
								continue;
							}
							xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
							if (elem4.tagName() == "Name")
							{
								subject.name = elem4.text();
								xmlReadingLog += "    Read subject name: " + subject.name + "\n";
							}
						}
						bool tmp2 = subjectsRead.contains(subject.name);
						if (tmp2)
						{
							RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("Duplicate subject %1 found - ignoring").arg(subject.name));
							xmlReadingLog += "   Subject not added - duplicate\n";
						}
						else
						{
							subjectsRead.insert(subject.name);
							this.addSubjectFast(subject);
							tmp++;
							xmlReadingLog += "   Subject inserted\n";
						}
					}
				}
				Debug.Assert(tmp == this.subjectsList.size());
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: xmlReadingLog+="  Added "+CustomFETString::number(tmp)+" subjects\n";
				xmlReadingLog += "  Added " + CustomFETString.number(new QString(tmp)) + " subjects\n";
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: reducedXmlLog+="Added "+CustomFETString::number(tmp)+" subjects\n";
				reducedXmlLog += "Added " + CustomFETString.number(new QString(tmp)) + " subjects\n";
			}
			else if (elem2.tagName() == "Subject_Tags_List")
			{
				QSet<QString> activityTagsRead = new QSet<QString>();

				RulesReconcilableMessage.information(parent, tr("FET information"), tr("Your file contains subject tags list" + ", which is named in versions>=5.5.0 activity tags list"));

				int tmp = 0;
				for (QDomNode node3 = elem2.firstChild(); !node3.isNull(); node3 = node3.nextSibling())
				{
					QDomElement elem3 = node3.toElement();
					if (elem3.isNull())
					{
						xmlReadingLog += "   Null node here\n";
						continue;
					}
					xmlReadingLog += "   Found " + elem3.tagName() + " tag\n";
					if (elem3.tagName() == "Subject_Tag")
					{
						ActivityTag activityTag = new ActivityTag();
						for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
						{
							QDomElement elem4 = node4.toElement();
							if (elem4.isNull())
							{
								xmlReadingLog += "    Null node here\n";
								continue;
							}
							xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
							if (elem4.tagName() == "Name")
							{
								activityTag.name = elem4.text();
								xmlReadingLog += "    Read activity tag name: " + activityTag.name + "\n";
							}
						}
						bool tmp2 = activityTagsRead.contains(activityTag.name);
						if (tmp2)
						{
							RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("Duplicate activity tag %1 found - ignoring").arg(activityTag.name));
							xmlReadingLog += "   Activity tag not added - duplicate\n";
						}
						else
						{
							activityTagsRead.insert(activityTag.name);
							addActivityTagFast(activityTag);
							tmp++;
							xmlReadingLog += "   Activity tag inserted\n";
						}
					}
				}
				Debug.Assert(tmp == this.activityTagsList.size());
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: xmlReadingLog+="  Added "+CustomFETString::number(tmp)+" activity tags\n";
				xmlReadingLog += "  Added " + CustomFETString.number(new QString(tmp)) + " activity tags\n";
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: reducedXmlLog+="Added "+CustomFETString::number(tmp)+" activity tags\n";
				reducedXmlLog += "Added " + CustomFETString.number(new QString(tmp)) + " activity tags\n";
			}
			else if (elem2.tagName() == "Activity_Tags_List")
			{
				QSet<QString> activityTagsRead = new QSet<QString>();

				int tmp = 0;
				for (QDomNode node3 = elem2.firstChild(); !node3.isNull(); node3 = node3.nextSibling())
				{
					QDomElement elem3 = node3.toElement();
					if (elem3.isNull())
					{
						xmlReadingLog += "   Null node here\n";
						continue;
					}
					xmlReadingLog += "   Found " + elem3.tagName() + " tag\n";
					if (elem3.tagName() == "Activity_Tag")
					{
						ActivityTag activityTag = new ActivityTag();
						for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
						{
							QDomElement elem4 = node4.toElement();
							if (elem4.isNull())
							{
								xmlReadingLog += "    Null node here\n";
								continue;
							}
							xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
							if (elem4.tagName() == "Name")
							{
								activityTag.name = elem4.text();
								xmlReadingLog += "    Read activity tag name: " + activityTag.name + "\n";
							}
						}
						bool tmp2 = activityTagsRead.contains(activityTag.name);
						if (tmp2)
						{
							RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("Duplicate activity tag %1 found - ignoring").arg(activityTag.name));
							xmlReadingLog += "   Activity tag not added - duplicate\n";
						}
						else
						{
							activityTagsRead.insert(activityTag.name);
							addActivityTagFast(activityTag);
							tmp++;
							xmlReadingLog += "   Activity tag inserted\n";
						}
					}
				}
				Debug.Assert(tmp == this.activityTagsList.size());
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: xmlReadingLog+="  Added "+CustomFETString::number(tmp)+" activity tags\n";
				xmlReadingLog += "  Added " + CustomFETString.number(new QString(tmp)) + " activity tags\n";
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: reducedXmlLog+="Added "+CustomFETString::number(tmp)+" activity tags\n";
				reducedXmlLog += "Added " + CustomFETString.number(new QString(tmp)) + " activity tags\n";
			}
			else if (elem2.tagName() == "Students_List")
			{
				QHash<QString, StudentsSet> studentsHash = new QHash<QString, StudentsSet>();

				int tsgr = 0;
				int tgr = 0;

				int ny = 0;
				for (QDomNode node3 = elem2.firstChild(); !node3.isNull(); node3 = node3.nextSibling())
				{
					QDomElement elem3 = node3.toElement();
					if (elem3.isNull())
					{
						xmlReadingLog += "   Null node here\n";
						continue;
					}
					xmlReadingLog += "   Found " + elem3.tagName() + " tag\n";
					if (elem3.tagName() == "Year")
					{
						StudentsYear sty = new StudentsYear();
						int ng = 0;

						QSet<QString> groupsInYear = new QSet<QString>();

						bool tmp2 = this.addYearFast(sty);
						Debug.Assert(tmp2 == true);
						ny++;

						for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
						{
							QDomElement elem4 = node4.toElement();
							if (elem4.isNull())
							{
								xmlReadingLog += "    Null node here\n";
								continue;
							}
							xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
							if (elem4.tagName() == "Name")
							{
								if (!skipDuplicatedStudentsSets)
								{
									QString nn = elem4.text();
									//StudentsSet* ss=this->searchStudentsSet(nn);
									StudentsSet ss = studentsHash.value(nn, null);
									if (ss != null)
									{
										QString str = new QString();

										if (ss.type == GlobalMembersStudentsset.STUDENTS_YEAR)
											str = tr("Trying to add year %1, which is already added as another year - your file will be loaded but probably contains errors, please correct them after loading").arg(nn);
										else if (ss.type == GlobalMembersStudentsset.STUDENTS_GROUP)
											str = tr("Trying to add year %1, which is already added as another group - your file will be loaded but probably contains errors, please correct them after loading").arg(nn);
										else if (ss.type == GlobalMembersStudentsset.STUDENTS_SUBGROUP)
											str = tr("Trying to add year %1, which is already added as another subgroup - your file will be loaded but probably contains errors, please correct them after loading").arg(nn);

										int t = RulesReconcilableMessage.warning(parent, tr("FET warning"), str, tr("Skip rest"), tr("See next"), new QString(), 1, 0);

										if (t == 0)
											skipDuplicatedStudentsSets = true;
									}
								}

								sty.name = elem4.text();
								if (!studentsHash.contains(sty.name))
									studentsHash.insert(sty.name, sty);
								xmlReadingLog += "    Read year name: " + sty.name + "\n";
							}
							else if (elem4.tagName() == "Number_of_Students")
							{
								sty.numberOfStudents = elem4.text().toInt();
								xmlReadingLog += "    Read year number of students: " + CustomFETString.number(sty.numberOfStudents) + "\n";
							}
							else if (elem4.tagName() == "Group")
							{
								StudentsGroup stg = new StudentsGroup();
								int ns = 0;

								QSet<QString> subgroupsInGroup = new QSet<QString>();

								/*bool tmp4=this->addGroupFast(sty, stg);
								assert(tmp4==true);
								ng++;*/

								for (QDomNode node5 = elem4.firstChild(); !node5.isNull(); node5 = node5.nextSibling())
								{
									QDomElement elem5 = node5.toElement();
									if (elem5.isNull())
									{
										xmlReadingLog += "     Null node here\n";
										continue;
									}
									xmlReadingLog += "     Found " + elem5.tagName() + " tag\n";
									if (elem5.tagName() == "Name")
									{
										if (!skipDuplicatedStudentsSets)
										{
											QString nn = elem5.text();
											StudentsSet ss = studentsHash.value(nn, null);
											if (ss != null)
											{
												QString str = new QString();

												if (ss.type == GlobalMembersStudentsset.STUDENTS_YEAR)
													str = tr("Trying to add group %1, which is already added as another year - your file will be loaded but probably contains errors, please correct them after loading").arg(nn);
												else if (ss.type == GlobalMembersStudentsset.STUDENTS_GROUP)
												{
													if (groupsInYear.contains(nn))
													{
														str = tr("Trying to add group %1 in year %2 but it is already added - your file will be loaded but probably contains errors, please correct them after loading").arg(nn).arg(sty.name);
													}
													else
														str = "";
												}
												else if (ss.type == GlobalMembersStudentsset.STUDENTS_SUBGROUP)
													str = tr("Trying to add group %1, which is already added as another subgroup - your file will be loaded but probably contains errors, please correct them after loading").arg(nn);

												int t = 1;
												if (str != "")
												{
													t = RulesReconcilableMessage.warning(parent, tr("FET warning"), str, tr("Skip rest"), tr("See next"), new QString(), 1, 0);
												}

												if (t == 0)
													skipDuplicatedStudentsSets = true;
											}
										}

										groupsInYear.insert(elem5.text());

										if (studentsHash.contains(elem5.text()))
										{
											if (stg != null)
												stg.Dispose();
											stg = (StudentsGroup)(studentsHash.value(elem5.text()));

											bool tmp4 = this.addGroupFast(sty, stg);
											Debug.Assert(tmp4 == true);
											//ng++;
											break;
										}

										bool tmp4 = this.addGroupFast(sty, stg);
										Debug.Assert(tmp4 == true);
										ng++;

										stg.name = elem5.text();
										if (!studentsHash.contains(stg.name))
											studentsHash.insert(stg.name, stg);
										xmlReadingLog += "     Read group name: " + stg.name + "\n";
									}
									else if (elem5.tagName() == "Number_of_Students")
									{
										stg.numberOfStudents = elem5.text().toInt();
										xmlReadingLog += "     Read group number of students: " + CustomFETString.number(stg.numberOfStudents) + "\n";
									}
									else if (elem5.tagName() == "Subgroup")
									{
										StudentsSubgroup sts = new StudentsSubgroup();

										/*bool tmp6=this->addSubgroupFast(sty, stg, sts);
										assert(tmp6==true);
										ns++;*/

										for (QDomNode node6 = elem5.firstChild(); !node6.isNull(); node6 = node6.nextSibling())
										{
											QDomElement elem6 = node6.toElement();
											if (elem6.isNull())
											{
												xmlReadingLog += "     Null node here\n";
												continue;
											}
											xmlReadingLog += "     Found " + elem6.tagName() + " tag\n";
											if (elem6.tagName() == "Name")
											{
												if (!skipDuplicatedStudentsSets)
												{
													QString nn = elem6.text();
													StudentsSet ss = studentsHash.value(nn, null);
													if (ss != null)
													{
														QString str = new QString();

														if (ss.type == GlobalMembersStudentsset.STUDENTS_YEAR)
															str = tr("Trying to add subgroup %1, which is already added as another year - your file will be loaded but probably contains errors, please correct them after loading").arg(nn);
														else if (ss.type == GlobalMembersStudentsset.STUDENTS_GROUP)
															str = tr("Trying to add subgroup %1, which is already added as another group - your file will be loaded but probably contains errors, please correct them after loading").arg(nn);
														else if (ss.type == GlobalMembersStudentsset.STUDENTS_SUBGROUP)
														{
															if (subgroupsInGroup.contains(nn))
															{
																str = tr("Trying to add subgroup %1 in year %2, group %3 but it is already added - your file will be loaded but probably contains errors, please correct them after loading").arg(nn).arg(sty.name).arg(stg.name);
															}
															else
																str = "";
														}

														int t = 1;
														if (str != "")
														{
															t = RulesReconcilableMessage.warning(parent, tr("FET warning"), str, tr("Skip rest"), tr("See next"), new QString(), 1, 0);
														}

														if (t == 0)
															skipDuplicatedStudentsSets = true;
													}
												}

												subgroupsInGroup.insert(elem6.text());

												if (studentsHash.contains(elem6.text()))
												{
													if (sts != null)
														sts.Dispose();
													sts = (StudentsSubgroup)(studentsHash.value(elem6.text()));

													bool tmp6 = this.addSubgroupFast(sty, stg, sts);
													Debug.Assert(tmp6 == true);
													//ns++;
													break;
												}

												bool tmp6 = this.addSubgroupFast(sty, stg, sts);
												Debug.Assert(tmp6 == true);
												ns++;

												sts.name = elem6.text();
												if (!studentsHash.contains(sts.name))
													studentsHash.insert(sts.name, sts);
												xmlReadingLog += "     Read subgroup name: " + sts.name + "\n";
											}
											else if (elem6.tagName() == "Number_of_Students")
											{
												sts.numberOfStudents = elem6.text().toInt();
												xmlReadingLog += "     Read subgroup number of students: " + CustomFETString.number(sts.numberOfStudents) + "\n";
											}
										}
									}
								}
								if (ns == stg.subgroupsList.size())
								{
									xmlReadingLog += "    Added " + CustomFETString.number(ns) + " subgroups\n";
									tsgr += ns;
								//reducedXmlLog+="		Added "+CustomFETString::number(ns)+" subgroups\n";
								}
							}
						}
						if (ng == sty.groupsList.size())
						{
							xmlReadingLog += "   Added " + CustomFETString.number(ng) + " groups\n";
							tgr += ng;
							//reducedXmlLog+="	Added "+CustomFETString::number(ng)+" groups\n";
						}
					}
				}
				xmlReadingLog += "  Added " + CustomFETString.number(ny) + " years\n";
				reducedXmlLog += "Added " + CustomFETString.number(ny) + " students years\n";
				//reducedXmlLog+="Added "+CustomFETString::number(tgr)+" students groups (see note below)\n";
				reducedXmlLog += "Added " + CustomFETString.number(tgr) + " students groups\n";
				//reducedXmlLog+="Added "+CustomFETString::number(tsgr)+" students subgroups (see note below)\n";
				reducedXmlLog += "Added " + CustomFETString.number(tsgr) + " students subgroups\n";
				Debug.Assert(this.yearsList.size() == ny);

				//BEGIN test for number of students is the same in all sets with the same name
				bool reportWrongNumberOfStudents = true;
				foreach (StudentsYear * year, yearsList)
				{
					Debug.Assert(studentsHash.contains(year.name));
					StudentsSet sy = studentsHash.value(year.name);
					if (sy.numberOfStudents != year.numberOfStudents)
					{
						if (reportWrongNumberOfStudents)
						{
							QString str = tr("Minor problem found and corrected: year %1 has different number of students in two places (%2 and %3)", "%2 and %3 are number of students").arg(year.name).arg(sy.numberOfStudents).arg(year.numberOfStudents) + "\n\n" + tr("Explanation: this is a minor problem, which appears if using overlapping students set, due to a bug in FET previous to version %1." + " FET will now correct this problem by setting the number of students for this year, in all places where it appears," + " to the number that was found in the first appearance (%2). It is advisable to check the number of students for this year.").arg("5.12.1").arg(sy.numberOfStudents);
							int t = RulesReconcilableMessage.warning(parent, tr("FET warning"), str, tr("Skip rest"), tr("See next"), new QString(), 1, 0);

							if (t == 0)
								reportWrongNumberOfStudents = false;
						}
						year.numberOfStudents = sy.numberOfStudents;
					}

					foreach (StudentsGroup * group, year.groupsList)
					{
						Debug.Assert(studentsHash.contains(group.name));
						StudentsSet sg = studentsHash.value(group.name);
						if (sg.numberOfStudents != group.numberOfStudents)
						{
							if (reportWrongNumberOfStudents)
							{
								QString str = tr("Minor problem found and corrected: group %1 has different number of students in two places (%2 and %3)", "%2 and %3 are number of students").arg(group.name).arg(sg.numberOfStudents).arg(group.numberOfStudents) + "\n\n" + tr("Explanation: this is a minor problem, which appears if using overlapping students set, due to a bug in FET previous to version %1." + " FET will now correct this problem by setting the number of students for this group, in all places where it appears," + " to the number that was found in the first appearance (%2). It is advisable to check the number of students for this group.").arg("5.12.1").arg(sg.numberOfStudents);
								int t = RulesReconcilableMessage.warning(parent, tr("FET warning"), str, tr("Skip rest"), tr("See next"), new QString(), 1, 0);

								if (t == 0)
									reportWrongNumberOfStudents = false;
							}
							group.numberOfStudents = sg.numberOfStudents;
						}

						foreach (StudentsSubgroup * subgroup, group.subgroupsList)
						{
							Debug.Assert(studentsHash.contains(subgroup.name));
							StudentsSet ss = studentsHash.value(subgroup.name);
							if (ss.numberOfStudents != subgroup.numberOfStudents)
							{
								if (reportWrongNumberOfStudents)
								{
									QString str = tr("Minor problem found and corrected: subgroup %1 has different number of students in two places (%2 and %3)", "%2 and %3 are number of students").arg(subgroup.name).arg(ss.numberOfStudents).arg(subgroup.numberOfStudents) + "\n\n" + tr("Explanation: this is a minor problem, which appears if using overlapping students set, due to a bug in FET previous to version %1." + " FET will now correct this problem by setting the number of students for this subgroup, in all places where it appears," + " to the number that was found in the first appearance (%2). It is advisable to check the number of students for this subgroup.").arg("5.12.1").arg(ss.numberOfStudents);
									int t = RulesReconcilableMessage.warning(parent, tr("FET warning"), str, tr("Skip rest"), tr("See next"), new QString(), 1, 0);

									if (t == 0)
										reportWrongNumberOfStudents = false;
								}
								subgroup.numberOfStudents = ss.numberOfStudents;
							}
						}
					}
				}
				//END test for number of students is the same in all sets with the same name
			}
			else if (elem2.tagName() == "Activities_List")
			{
				QSet<QString> allTeachers = new QSet<QString>();
				QHash<QString, int> studentsSetsCount = new QHash<QString, int>();
				QSet<QString> allSubjects = new QSet<QString>();
				QSet<QString> allActivityTags = new QSet<QString>();

				foreach (Teacher * tch, this.teachersList) allTeachers.insert(tch.name);

				foreach (Subject * sbj, this.subjectsList) allSubjects.insert(sbj.name);

				foreach (ActivityTag * at, this.activityTagsList) allActivityTags.insert(at.name);

				foreach (StudentsYear * year, this.yearsList)
				{
					if (!studentsSetsCount.contains(year.name))
						studentsSetsCount.insert(year.name, year.numberOfStudents);
					else if (studentsSetsCount.value(year.name) != year.numberOfStudents)
					{
						//cout<<"Mistake: year "<<qPrintable(year->name)<<" appears in more places with different number of students"<<endl;
					}

					foreach (StudentsGroup * group, year.groupsList)
					{
						if (!studentsSetsCount.contains(group.name))
							studentsSetsCount.insert(group.name, group.numberOfStudents);
						else if (studentsSetsCount.value(group.name) != group.numberOfStudents)
						{
							//cout<<"Mistake: group "<<qPrintable(group->name)<<" appears in more places with different number of students"<<endl;
						}

						foreach (StudentsSubgroup * subgroup, group.subgroupsList)
						{
							if (!studentsSetsCount.contains(subgroup.name))
								studentsSetsCount.insert(subgroup.name, subgroup.numberOfStudents);
							else if (studentsSetsCount.value(subgroup.name) != subgroup.numberOfStudents)
							{
								//cout<<"Mistake: subgroup "<<qPrintable(subgroup->name)<<" appears in more places with different number of students"<<endl;
							}
						}
					}
				}

				//int nchildrennodes=elem2.childNodes().length();

				/*QProgressDialog progress(parent);
				progress.setLabelText(tr("Loading activities ... please wait"));
				progress.setRange(0, nchildrennodes);
				progress.setModal(true);*/
				//progress.setCancelButton(parent);

				//int ttt=0;

				int na = 0;
				for (QDomNode node3 = elem2.firstChild(); !node3.isNull(); node3 = node3.nextSibling())
				{

					/*progress.setValue(ttt);
					pqapplication->processEvents();
					if(progress.wasCanceled()){
						QMessageBox::information(parent, tr("FET information"), tr("Interrupted - only partial file was loaded"));
						return true;
					}
					
					ttt++;*/

					QDomElement elem3 = node3.toElement();
					if (elem3.isNull())
					{
						xmlReadingLog += "   Null node here\n";
						continue;
					}
					xmlReadingLog += "   Found " + elem3.tagName() + " tag\n";
					if (elem3.tagName() == "Activity")
					{
						bool correct = true;

						QString cm = new QString(""); //comments
						QString tn = "";
						QStringList tl = new QStringList();
						QString sjn = "";
						QString atn = "";
						QStringList atl = new QStringList();
						QString stn = "";
						QStringList stl = new QStringList();
						//int p=PARITY_NOT_INITIALIZED;
						int td = -1;
						int d = -1;
						int id = -1;
						int gid = -1;
						bool ac = true;
						int nos = -1;
						bool cnos = true;
						for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
						{
							QDomElement elem4 = node4.toElement();
							if (elem4.isNull())
							{
								xmlReadingLog += "   Null node here\n";
								continue;
							}
							xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
							if (elem4.tagName() == "Weekly")
							{
								xmlReadingLog += "    Current activity is weekly - ignoring tag\n";
								//assert(p==PARITY_NOT_INITIALIZED);
								//p=PARITY_WEEKLY;
							}
							//old tag
							else if (elem4.tagName() == "Biweekly")
							{
								xmlReadingLog += "    Current activity is fortnightly - ignoring tag\n";
								//assert(p==PARITY_NOT_INITIALIZED);
								//p=PARITY_FORTNIGHTLY;
							}
							else if (elem4.tagName() == "Fortnightly")
							{
								xmlReadingLog += "    Current activity is fortnightly - ignoring tag\n";
								//assert(p==PARITY_NOT_INITIALIZED);
								//p=PARITY_FORTNIGHTLY;
							}
							else if (elem4.tagName() == "Active")
							{
								if (elem4.text() == "yes" || elem4.text() == "true" || elem4.text() == "1")
								{
									ac = true;
									xmlReadingLog += "	Current activity is active\n";
								}
								else
								{
									if (!(elem4.text() == "no" || elem4.text() == "false" || elem4.text() == "0"))
									{
										RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("Found activity active tag which is not 'true', 'false', 'yes', 'no', '1' or '0'." + " The activity will be considered not active", "Instructions for translators: please leave the 'true', 'false', 'yes' and 'no' fields untranslated, as they are in English"));
									}
									//assert(elem4.text()=="no" || elem4.text()=="false" || elem4.text()=="0");
									ac = false;
									xmlReadingLog += "	Current activity is not active\n";
								}
							}
							else if (elem4.tagName() == "Comments")
							{
								cm = elem4.text();
								xmlReadingLog += "    Crt. activity comments=" + cm + "\n";
							}
							else if (elem4.tagName() == "Teacher")
							{
								tn = elem4.text();
								xmlReadingLog += "    Crt. activity teacher=" + tn + "\n";
								tl.append(tn);
								if (!allTeachers.contains(tn))
								//if(this->searchTeacher(tn)<0)
									correct = false;
							}
							else if (elem4.tagName() == "Subject")
							{
								sjn = elem4.text();
								xmlReadingLog += "    Crt. activity subject=" + sjn + "\n";
								if (!allSubjects.contains(sjn))
								//if(this->searchSubject(sjn)<0)
									correct = false;
							}
							else if (elem4.tagName() == "Subject_Tag")
							{
								atn = elem4.text();
								xmlReadingLog += "    Crt. activity activity_tag=" + atn + "\n";
								if (atn != "")
									atl.append(atn);
								if (atn != "" && !allActivityTags.contains(atn))
								//if(atn!="" && this->searchActivityTag(atn)<0)
									correct = false;
							}
							else if (elem4.tagName() == "Activity_Tag")
							{
								atn = elem4.text();
								xmlReadingLog += "    Crt. activity activity_tag=" + atn + "\n";
								if (atn != "")
									atl.append(atn);
								if (atn != "" && !allActivityTags.contains(atn))
								//if(atn!="" && this->searchActivityTag(atn)<0)
									correct = false;
							}
							else if (elem4.tagName() == "Students")
							{
								stn = elem4.text();
								xmlReadingLog += "    Crt. activity students+=" + stn + "\n";
								stl.append(stn);
								if (!studentsSetsCount.contains(stn))
								//if(this->searchStudentsSet(stn)==NULL)
									correct = false;
							}
							else if (elem4.tagName() == "Duration")
							{
								d = elem4.text().toInt();
								xmlReadingLog += "    Crt. activity duration=" + CustomFETString.number(d) + "\n";
							}
							else if (elem4.tagName() == "Total_Duration")
							{
								td = elem4.text().toInt();
								xmlReadingLog += "    Crt. activity total duration=" + CustomFETString.number(td) + "\n";
							}
							else if (elem4.tagName() == "Id")
							{
								id = elem4.text().toInt();
								xmlReadingLog += "    Crt. activity id=" + CustomFETString.number(id) + "\n";
							}
							else if (elem4.tagName() == "Activity_Group_Id")
							{
								gid = elem4.text().toInt();
								xmlReadingLog += "    Crt. activity group id=" + CustomFETString.number(gid) + "\n";
							}
							else if (elem4.tagName() == "Number_Of_Students")
							{
								cnos = false;
								nos = elem4.text().toInt();
								xmlReadingLog += "    Crt. activity number of students=" + CustomFETString.number(nos) + "\n";
							}
						}
						if (correct)
						{
							Debug.Assert(id >= 0 && gid >= 0);
							Debug.Assert(d > 0);
							if (td < 0)
								td = d;

							if (cnos == true)
							{
								Debug.Assert(nos == -1);
								int _ns = 0;
								foreach (QString _s, stl)
								{
									Debug.Assert(studentsSetsCount.contains(_s));
									_ns += studentsSetsCount.value(_s);
								}
								this.addSimpleActivityRulesFast(parent, id, gid, tl, sjn, atl, stl, d, td, ac, cnos, nos, _ns);
							}
							else
							{
								this.addSimpleActivity(parent, id, gid, tl, sjn, atl, stl, d, td, ac, cnos, nos);
							}

							this.activitiesList[this.activitiesList.count() - 1].comments = cm;

							na++;
							xmlReadingLog += "   Added the activity\n";
						}
						else
						{
							xmlReadingLog += "   Activity with id =" + CustomFETString.number(id) + " contains invalid data - skipping\n";
							RulesReconcilableMessage.warning(parent, tr("FET information"), tr("Activity with id=%1 contains invalid data - skipping").arg(id));
						}
					}
				}
				xmlReadingLog += "  Added " + CustomFETString.number(na) + " activities\n";
				reducedXmlLog += "Added " + CustomFETString.number(na) + " activities\n";
			}
			else if (elem2.tagName() == "Equipments_List")
			{
				 RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("File contains deprecated equipments list - will be ignored\n"));
			}
			else if (elem2.tagName() == "Buildings_List")
			{
				QSet<QString> buildingsRead = new QSet<QString>();

				int tmp = 0;
				for (QDomNode node3 = elem2.firstChild(); !node3.isNull(); node3 = node3.nextSibling())
				{
					QDomElement elem3 = node3.toElement();
					if (elem3.isNull())
					{
						xmlReadingLog += "   Null node here\n";
						continue;
					}
					xmlReadingLog += "   Found " + elem3.tagName() + " tag\n";
					if (elem3.tagName() == "Building")
					{
						Building bu = new Building();
						bu.name = "";

						for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
						{
							QDomElement elem4 = node4.toElement();
							if (elem4.isNull())
							{
								xmlReadingLog += "    Null node here\n";
								continue;
							}
							xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
							if (elem4.tagName() == "Name")
							{
								bu.name = elem4.text();
								xmlReadingLog += "    Read building name: " + bu.name + "\n";
							}
						}

						bool tmp2 = buildingsRead.contains(bu.name);
						if (tmp2)
						{
							RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("Duplicate building %1 found - ignoring").arg(bu.name));
							xmlReadingLog += "   Building not added - duplicate\n";
						}
						else
						{
							buildingsRead.insert(bu.name);
							addBuildingFast(bu);
							tmp++;
							xmlReadingLog += "   Building inserted\n";
						}
					}
				}
				Debug.Assert(tmp == this.buildingsList.size());
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: xmlReadingLog+="  Added "+CustomFETString::number(tmp)+" buildings\n";
				xmlReadingLog += "  Added " + CustomFETString.number(new QString(tmp)) + " buildings\n";
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: reducedXmlLog+="Added "+CustomFETString::number(tmp)+" buildings\n";
				reducedXmlLog += "Added " + CustomFETString.number(new QString(tmp)) + " buildings\n";
			}
			else if (elem2.tagName() == "Rooms_List")
			{
				QSet<QString> roomsRead = new QSet<QString>();

				int tmp = 0;
				for (QDomNode node3 = elem2.firstChild(); !node3.isNull(); node3 = node3.nextSibling())
				{
					QDomElement elem3 = node3.toElement();
					if (elem3.isNull())
					{
						xmlReadingLog += "   Null node here\n";
						continue;
					}
					xmlReadingLog += "   Found " + elem3.tagName() + " tag\n";
					if (elem3.tagName() == "Room")
					{
						Room rm = new Room();
						rm.name = "";
						rm.capacity = GlobalMembersTimetable_defs.MAX_ROOM_CAPACITY; //infinite, if not specified
						rm.building = "";
						for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
						{
							QDomElement elem4 = node4.toElement();
							if (elem4.isNull())
							{
								xmlReadingLog += "    Null node here\n";
								continue;
							}
							xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
							if (elem4.tagName() == "Name")
							{
								rm.name = elem4.text();
								xmlReadingLog += "    Read room name: " + rm.name + "\n";
							}
							else if (elem4.tagName() == "Type")
							{
								//rm->type=elem4.text();
								xmlReadingLog += "    Ignoring old tag room type:\n";
							}
							else if (elem4.tagName() == "Capacity")
							{
								rm.capacity = elem4.text().toInt();
								xmlReadingLog += "    Read room capacity: " + CustomFETString.number(rm.capacity) + "\n";
							}
							else if (elem4.tagName() == "Equipment")
							{
								//rm->addEquipment(elem4.text());
								xmlReadingLog += "    Ignoring old tag - room equipment:\n";
							}
							else if (elem4.tagName() == "Building")
							{
								rm.building = elem4.text();
								xmlReadingLog += "    Read room building:\n" + rm.building;
							}
						}
						bool tmp2 = roomsRead.contains(rm.name);
						if (tmp2)
						{
							RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("Duplicate room %1 found - ignoring").arg(rm.name));
							xmlReadingLog += "   Room not added - duplicate\n";
						}
						else
						{
							roomsRead.insert(rm.name);
							addRoomFast(rm);
							tmp++;
							xmlReadingLog += "   Room inserted\n";
						}
					}
				}
				Debug.Assert(tmp == this.roomsList.size());
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: xmlReadingLog+="  Added "+CustomFETString::number(tmp)+" rooms\n";
				xmlReadingLog += "  Added " + CustomFETString.number(new QString(tmp)) + " rooms\n";
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: reducedXmlLog+="Added "+CustomFETString::number(tmp)+" rooms\n";
				reducedXmlLog += "Added " + CustomFETString.number(new QString(tmp)) + " rooms\n";
			}
			else if (elem2.tagName() == "Time_Constraints_List")
			{
				bool reportMaxBeginningsAtSecondHourChange = true;
				bool reportMaxGapsChange = true;
				bool reportStudentsSetNotAvailableChange = true;
				bool reportTeacherNotAvailableChange = true;
				bool reportBreakChange = true;

				bool reportActivityPreferredTimeChange = true;

				bool reportActivityPreferredTimesChange = true;
				bool reportActivitiesPreferredTimesChange = true;

				bool reportUnspecifiedPermanentlyLockedTime = true;

				bool reportUnspecifiedDayOrHourPreferredStartingTime = true;

#if false
	//			bool reportIncorrectMinDays=true;
#endif

				int nc = 0;
				TimeConstraint crt_constraint;
				for (QDomNode node3 = elem2.firstChild(); !node3.isNull(); node3 = node3.nextSibling())
				{
					crt_constraint = null;
					QDomElement elem3 = node3.toElement();
					if (elem3.isNull())
					{
						xmlReadingLog += "   Null node here\n";
						continue;
					}
					xmlReadingLog += "   Found " + elem3.tagName() + " tag\n";
					if (elem3.tagName() == "ConstraintBasicCompulsoryTime")
					{
						crt_constraint = readBasicCompulsoryTime(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintTeacherNotAvailable")
					{
						if (reportTeacherNotAvailableChange)
						{
							int t = RulesReconcilableMessage.information(parent, tr("FET information"), tr("File contains constraint teacher not available, which is old (it was improved in FET 5.5.0), and will be converted" + " to the similar constraint of this type, constraint teacher not available times (a matrix)."), tr("Skip rest"), tr("See next"), new QString(), 1, 0);
							if (t == 0)
								reportTeacherNotAvailableChange = false;
						}

						crt_constraint = readTeacherNotAvailable(parent, elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintTeacherNotAvailableTimes")
					{
						crt_constraint = readTeacherNotAvailableTimes(parent, elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintTeacherMaxDaysPerWeek")
					{
						crt_constraint = readTeacherMaxDaysPerWeek(parent, elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintTeachersMaxDaysPerWeek")
					{
						crt_constraint = readTeachersMaxDaysPerWeek(parent, elem3, ref xmlReadingLog);
					}

					else if (elem3.tagName() == "ConstraintTeacherMinDaysPerWeek")
					{
						crt_constraint = readTeacherMinDaysPerWeek(parent, elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintTeachersMinDaysPerWeek")
					{
						crt_constraint = readTeachersMinDaysPerWeek(parent, elem3, ref xmlReadingLog);
					}

					else if (elem3.tagName() == "ConstraintTeacherIntervalMaxDaysPerWeek")
					{
						crt_constraint = readTeacherIntervalMaxDaysPerWeek(parent, elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintTeachersIntervalMaxDaysPerWeek")
					{
						crt_constraint = readTeachersIntervalMaxDaysPerWeek(parent, elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintStudentsSetIntervalMaxDaysPerWeek")
					{
						crt_constraint = readStudentsSetIntervalMaxDaysPerWeek(parent, elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintStudentsIntervalMaxDaysPerWeek")
					{
						crt_constraint = readStudentsIntervalMaxDaysPerWeek(parent, elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintStudentsSetNotAvailable")
					{
						if (reportStudentsSetNotAvailableChange)
						{
							int t = RulesReconcilableMessage.information(parent, tr("FET information"), tr("File contains constraint students set not available, which is old (it was improved in FET 5.5.0), and will be converted" + " to the similar constraint of this type, constraint students set not available times (a matrix)."), tr("Skip rest"), tr("See next"), new QString(), 1, 0);
							if (t == 0)
								reportStudentsSetNotAvailableChange = false;
						}

						crt_constraint = readStudentsSetNotAvailable(parent, elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintStudentsSetNotAvailableTimes")
					{
						crt_constraint = readStudentsSetNotAvailableTimes(parent, elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintMinNDaysBetweenActivities")
					{
						crt_constraint = readMinNDaysBetweenActivities(parent, elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintMinDaysBetweenActivities")
					{
						crt_constraint = readMinDaysBetweenActivities(parent, elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintMaxDaysBetweenActivities")
					{
						crt_constraint = readMaxDaysBetweenActivities(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintMinGapsBetweenActivities")
					{
						crt_constraint = readMinGapsBetweenActivities(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintActivitiesNotOverlapping")
					{
						crt_constraint = readActivitiesNotOverlapping(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintActivitiesSameStartingTime")
					{
						crt_constraint = readActivitiesSameStartingTime(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintActivitiesSameStartingHour")
					{
						crt_constraint = readActivitiesSameStartingHour(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintActivitiesSameStartingDay")
					{
						crt_constraint = readActivitiesSameStartingDay(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintTeachersMaxHoursDaily")
					{
						crt_constraint = readTeachersMaxHoursDaily(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintTeacherMaxHoursDaily")
					{
						crt_constraint = readTeacherMaxHoursDaily(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintTeachersMaxHoursContinuously")
					{
						crt_constraint = readTeachersMaxHoursContinuously(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintTeacherMaxHoursContinuously")
					{
						crt_constraint = readTeacherMaxHoursContinuously(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintTeacherActivityTagMaxHoursContinuously")
					{
						crt_constraint = readTeacherActivityTagMaxHoursContinuously(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintTeachersActivityTagMaxHoursContinuously")
					{
						crt_constraint = readTeachersActivityTagMaxHoursContinuously(elem3, ref xmlReadingLog);
					}

					else if (elem3.tagName() == "ConstraintTeacherActivityTagMaxHoursDaily")
					{
						crt_constraint = readTeacherActivityTagMaxHoursDaily(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintTeachersActivityTagMaxHoursDaily")
					{
						crt_constraint = readTeachersActivityTagMaxHoursDaily(elem3, ref xmlReadingLog);
					}

					else if (elem3.tagName() == "ConstraintTeachersMinHoursDaily")
					{
						crt_constraint = readTeachersMinHoursDaily(parent, elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintTeacherMinHoursDaily")
					{
						crt_constraint = readTeacherMinHoursDaily(parent, elem3, ref xmlReadingLog);
					}
					else if ((elem3.tagName() == "ConstraintTeachersSubgroupsMaxHoursDaily" || elem3.tagName() == "ConstraintTeachersSubgroupsNoMoreThanXHoursDaily") && !skipDeprecatedConstraints)
					 //TODO: erase the line below. It is only kept for compatibility with older versions
					{
						int t = RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("File contains deprecated constraint teachers subgroups max hours daily - will be ignored\n"), tr("Skip rest"), tr("See next"), new QString(), 1, 0);

						if (t == 0)
							skipDeprecatedConstraints = true;
						crt_constraint = null;
					}
					else if (elem3.tagName() == "ConstraintStudentsNHoursDaily" && !skipDeprecatedConstraints)
					{
						int t = RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("File contains deprecated constraint students n hours daily - will be ignored\n"), tr("Skip rest"), tr("See next"), new QString(), 1, 0);

						if (t == 0)
							skipDeprecatedConstraints = true;
						crt_constraint = null;
					}
					else if (elem3.tagName() == "ConstraintStudentsSetNHoursDaily" && !skipDeprecatedConstraints)
					{
						int t = RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("File contains deprecated constraint students set n hours daily - will be ignored\n"), tr("Skip rest"), tr("See next"), new QString(), 1, 0);

						if (t == 0)
							skipDeprecatedConstraints = true;
						crt_constraint = null;
					}
					else if (elem3.tagName() == "ConstraintStudentsMaxHoursDaily")
					{
						crt_constraint = readStudentsMaxHoursDaily(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintStudentsSetMaxHoursDaily")
					{
						crt_constraint = readStudentsSetMaxHoursDaily(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintStudentsMaxHoursContinuously")
					{
						crt_constraint = readStudentsMaxHoursContinuously(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintStudentsSetMaxHoursContinuously")
					{
						crt_constraint = readStudentsSetMaxHoursContinuously(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintStudentsSetActivityTagMaxHoursContinuously")
					{
						crt_constraint = readStudentsSetActivityTagMaxHoursContinuously(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintStudentsActivityTagMaxHoursContinuously")
					{
						crt_constraint = readStudentsActivityTagMaxHoursContinuously(elem3, ref xmlReadingLog);
					}

					else if (elem3.tagName() == "ConstraintStudentsSetActivityTagMaxHoursDaily")
					{
						crt_constraint = readStudentsSetActivityTagMaxHoursDaily(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintStudentsActivityTagMaxHoursDaily")
					{
						crt_constraint = readStudentsActivityTagMaxHoursDaily(elem3, ref xmlReadingLog);
					}

					else if (elem3.tagName() == "ConstraintStudentsMinHoursDaily")
					{
						crt_constraint = readStudentsMinHoursDaily(parent, elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintStudentsSetMinHoursDaily")
					{
						crt_constraint = readStudentsSetMinHoursDaily(parent, elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintActivityPreferredTime")
					{
						if (reportActivityPreferredTimeChange)
						{
							int t = RulesReconcilableMessage.information(parent, tr("FET information"), tr("File contains old constraint type activity preferred time, which will be converted" + " to the newer similar constraint of this type, constraint activity preferred STARTING time." + " This improvement is done in versions 5.5.9 and above"), tr("Skip rest"), tr("See next"), new QString(), 1, 0);
							if (t == 0)
								reportActivityPreferredTimeChange = false;
						}

						crt_constraint = readActivityPreferredTime(parent, elem3, ref xmlReadingLog, ref reportUnspecifiedPermanentlyLockedTime, ref reportUnspecifiedDayOrHourPreferredStartingTime);
					}

					else if (elem3.tagName() == "ConstraintActivityPreferredStartingTime")
					{
						crt_constraint = readActivityPreferredStartingTime(parent, elem3, ref xmlReadingLog, ref reportUnspecifiedPermanentlyLockedTime, ref reportUnspecifiedDayOrHourPreferredStartingTime);
					}
					else if (elem3.tagName() == "ConstraintActivityEndsStudentsDay")
					{
						crt_constraint = readActivityEndsStudentsDay(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintActivitiesEndStudentsDay")
					{
						crt_constraint = readActivitiesEndStudentsDay(elem3, ref xmlReadingLog);
					}
					//old, with 2 and 3
					else if (elem3.tagName() == "Constraint2ActivitiesConsecutive")
					{
						crt_constraint = read2ActivitiesConsecutive(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "Constraint2ActivitiesGrouped")
					{
						crt_constraint = read2ActivitiesGrouped(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "Constraint3ActivitiesGrouped")
					{
						crt_constraint = read3ActivitiesGrouped(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "Constraint2ActivitiesOrdered")
					{
						crt_constraint = read2ActivitiesOrdered(elem3, ref xmlReadingLog);
					}
					//end old
					else if (elem3.tagName() == "ConstraintTwoActivitiesConsecutive")
					{
						crt_constraint = readTwoActivitiesConsecutive(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintTwoActivitiesGrouped")
					{
						crt_constraint = readTwoActivitiesGrouped(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintThreeActivitiesGrouped")
					{
						crt_constraint = readThreeActivitiesGrouped(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintTwoActivitiesOrdered")
					{
						crt_constraint = readTwoActivitiesOrdered(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintActivityEndsDay" && !skipDeprecatedConstraints)
					{
						int t = RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("File contains deprecated constraint activity ends day - will be ignored\n"), tr("Skip rest"), tr("See next"), new QString(), 1, 0);

						if (t == 0)
							skipDeprecatedConstraints = true;
						crt_constraint = null;
					}
					else if (elem3.tagName() == "ConstraintActivityPreferredTimes")
					{
						if (reportActivityPreferredTimesChange)
						{
							int t = RulesReconcilableMessage.information(parent, tr("FET information"), tr("Your file contains old constraint activity preferred times, which will be converted to" + " new equivalent constraint activity preferred starting times. Beginning with FET-5.5.9 it is possible" + " to specify: 1. the starting times of an activity (constraint activity preferred starting times)" + " or: 2. the accepted time slots (constraint activity preferred time slots)." + " If what you need is type 2 of this constraint, you will have to add it by yourself from the interface."), tr("Skip rest"), tr("See next"), new QString(), 1, 0);
							if (t == 0)
								reportActivityPreferredTimesChange = false;
						}

						crt_constraint = readActivityPreferredTimes(parent, elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintActivityPreferredTimeSlots")
					{
						crt_constraint = readActivityPreferredTimeSlots(parent, elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintActivityPreferredStartingTimes")
					{
						crt_constraint = readActivityPreferredStartingTimes(parent, elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintBreak")
					{
						if (reportBreakChange)
						{
							int t = RulesReconcilableMessage.information(parent, tr("FET information"), tr("File contains constraint break, which is old (it was improved in FET 5.5.0), and will be converted" + " to the similar constraint of this type, constraint break times (a matrix)."), tr("Skip rest"), tr("See next"), new QString(), 1, 0);
							if (t == 0)
								reportBreakChange = false;
						}

						crt_constraint = readBreak(parent, elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintBreakTimes")
					{
						crt_constraint = readBreakTimes(parent, elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintTeachersNoGaps")
					{
						crt_constraint = readTeachersNoGaps(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintTeachersMaxGapsPerWeek")
					{
						crt_constraint = readTeachersMaxGapsPerWeek(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintTeacherMaxGapsPerWeek")
					{
						crt_constraint = readTeacherMaxGapsPerWeek(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintTeachersMaxGapsPerDay")
					{
						crt_constraint = readTeachersMaxGapsPerDay(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintTeacherMaxGapsPerDay")
					{
						crt_constraint = readTeacherMaxGapsPerDay(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintStudentsNoGaps")
					{
						if (reportMaxGapsChange)
						{
							int t = RulesReconcilableMessage.information(parent, tr("FET information"), tr("File contains constraint students no gaps, which is old (it was improved in FET 5.5.0), and will be converted" + " to the similar constraint of this type, constraint students max gaps per week," + " with max gaps=0. If you like, you can modify this constraint to allow" + " more gaps per week (normally not accepted in schools)"), tr("Skip rest"), tr("See next"), new QString(), 1, 0);
							if (t == 0)
								reportMaxGapsChange = false;
						}

						crt_constraint = readStudentsNoGaps(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintStudentsSetNoGaps")
					{
						if (reportMaxGapsChange)
						{
							int t = RulesReconcilableMessage.information(parent, tr("FET information"), tr("File contains constraint students set no gaps, which is old (it was improved in FET 5.5.0), and will be converted" + " to the similar constraint of this type, constraint students set max gaps per week," + " with max gaps=0. If you like, you can modify this constraint to allow" + " more gaps per week (normally not accepted in schools)"), tr("Skip rest"), tr("See next"), new QString(), 1, 0);
							if (t == 0)
								reportMaxGapsChange = false;
						}

						crt_constraint = readStudentsSetNoGaps(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintStudentsMaxGapsPerWeek")
					{
						crt_constraint = readStudentsMaxGapsPerWeek(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintStudentsSetMaxGapsPerWeek")
					{
						crt_constraint = readStudentsSetMaxGapsPerWeek(elem3, ref xmlReadingLog);
					}

					else if (elem3.tagName() == "ConstraintStudentsMaxGapsPerDay")
					{
						crt_constraint = readStudentsMaxGapsPerDay(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintStudentsSetMaxGapsPerDay")
					{
						crt_constraint = readStudentsSetMaxGapsPerDay(elem3, ref xmlReadingLog);
					}

					else if (elem3.tagName() == "ConstraintStudentsEarly")
					{
						if (reportMaxBeginningsAtSecondHourChange)
						{
							int t = RulesReconcilableMessage.information(parent, tr("FET information"), tr("File contains constraint students early, which is old (it was improved in FET 5.5.0), and will be converted" + " to the similar constraint of this type, constraint students early max beginnings at second hour," + " with max beginnings=0. If you like, you can modify this constraint to allow" + " more beginnings at second available hour (above 0 - this will make the timetable easier)"), tr("Skip rest"), tr("See next"), new QString(), 1, 0);
							 if (t == 0)
								reportMaxBeginningsAtSecondHourChange = false;
						}

						crt_constraint = readStudentsEarly(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintStudentsEarlyMaxBeginningsAtSecondHour")
					{
						crt_constraint = readStudentsEarlyMaxBeginningsAtSecondHour(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintStudentsSetEarly")
					{
						if (reportMaxBeginningsAtSecondHourChange)
						{
							int t = RulesReconcilableMessage.information(parent, tr("FET information"), tr("File contains constraint students set early, which is old (it was improved in FET 5.5.0), and will be converted" + " to the similar constraint of this type, constraint students set early max beginnings at second hour," + " with max beginnings=0. If you like, you can modify this constraint to allow" + " more beginnings at second available hour (above 0 - this will make the timetable easier)"), tr("Skip rest"), tr("See next"), new QString(), 1, 0);
							if (t == 0)
								reportMaxBeginningsAtSecondHourChange = false;
						}

						crt_constraint = readStudentsSetEarly(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintStudentsSetEarlyMaxBeginningsAtSecondHour")
					{
						crt_constraint = readStudentsSetEarlyMaxBeginningsAtSecondHour(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintActivitiesPreferredTimes")
					{
						if (reportActivitiesPreferredTimesChange)
						{
							int t = RulesReconcilableMessage.information(parent, tr("FET information"), tr("Your file contains old constraint activities preferred times, which will be converted to" + " new equivalent constraint activities preferred starting times. Beginning with FET-5.5.9 it is possible" + " to specify: 1. the starting times of several activities (constraint activities preferred starting times)" + " or: 2. the accepted time slots (constraint activities preferred time slots)." + " If what you need is type 2 of this constraint, you will have to add it by yourself from the interface."), tr("Skip rest"), tr("See next"), new QString(), 1, 0);
							if (t == 0)
								reportActivitiesPreferredTimesChange = false;
						}

						crt_constraint = readActivitiesPreferredTimes(parent, elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintActivitiesPreferredTimeSlots")
					{
						crt_constraint = readActivitiesPreferredTimeSlots(parent, elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintActivitiesPreferredStartingTimes")
					{
						crt_constraint = readActivitiesPreferredStartingTimes(parent, elem3, ref xmlReadingLog);
					}
	////////////////
					else if (elem3.tagName() == "ConstraintSubactivitiesPreferredTimeSlots")
					{
						crt_constraint = readSubactivitiesPreferredTimeSlots(parent, elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintSubactivitiesPreferredStartingTimes")
					{
						crt_constraint = readSubactivitiesPreferredStartingTimes(parent, elem3, ref xmlReadingLog);
					}
	////////////////2011-09-25
					else if (elem3.tagName() == "ConstraintActivitiesOccupyMaxTimeSlotsFromSelection")
					{
						crt_constraint = readActivitiesOccupyMaxTimeSlotsFromSelection(parent, elem3, ref xmlReadingLog);
					}
	////////////////
	////////////////2011-09-30
					else if (elem3.tagName() == "ConstraintActivitiesMaxSimultaneousInSelectedTimeSlots")
					{
						crt_constraint = readActivitiesMaxSimultaneousInSelectedTimeSlots(parent, elem3, ref xmlReadingLog);
					}
	////////////////

					else if (elem3.tagName() == "ConstraintTeachersSubjectTagsMaxHoursContinuously" && !skipDeprecatedConstraints)
					{
						int t = RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("File contains deprecated constraint teachers subject tags max hours continuously - will be ignored\n"), tr("Skip rest"), tr("See next"), new QString(), 1, 0);

						if (t == 0)
							skipDeprecatedConstraints = true;
						crt_constraint = null;
					}
					else if (elem3.tagName() == "ConstraintTeachersSubjectTagMaxHoursContinuously" && !skipDeprecatedConstraints)
					{
						int t = RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("File contains deprecated constraint teachers subject tag max hours continuously - will be ignored\n"), tr("Skip rest"), tr("See next"), new QString(), 1, 0);

						if (t == 0)
							skipDeprecatedConstraints = true;
						crt_constraint = null;
					}

	//corruptConstraintTime:
					//here we skip invalid constraint or add valid one
					if (crt_constraint != null)
					{
						Debug.Assert(crt_constraint != null);
						bool tmp = this.addTimeConstraint(crt_constraint);
						if (tmp == null)
						{
							RulesReconcilableMessage.warning(parent, tr("FET information"), tr("Constraint\n%1\nnot added - must be a duplicate").arg(crt_constraint.getDetailedDescription(this)));
							if (crt_constraint != null)
								crt_constraint.Dispose();
						}
						else
							nc++;
					}
				}
				xmlReadingLog += "  Added " + CustomFETString.number(nc) + " time constraints\n";
				reducedXmlLog += "Added " + CustomFETString.number(nc) + " time constraints\n";
			}
			else if (elem2.tagName() == "Space_Constraints_List")
			{
				bool reportRoomNotAvailableChange = true;

				bool reportUnspecifiedPermanentlyLockedSpace = true;

				int nc = 0;
				SpaceConstraint crt_constraint;

				for (QDomNode node3 = elem2.firstChild(); !node3.isNull(); node3 = node3.nextSibling())
				{
					crt_constraint = null;
					QDomElement elem3 = node3.toElement();
					if (elem3.isNull())
					{
						xmlReadingLog += "   Null node here\n";
						continue;
					}
					xmlReadingLog += "   Found " + elem3.tagName() + " tag\n";
					if (elem3.tagName() == "ConstraintBasicCompulsorySpace")
					{
						crt_constraint = readBasicCompulsorySpace(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintRoomNotAvailable")
					{
						if (reportRoomNotAvailableChange)
						{
							int t = RulesReconcilableMessage.information(parent, tr("FET information"), tr("File contains constraint room not available, which is old (it was improved in FET 5.5.0), and will be converted" + " to the similar constraint of this type, constraint room not available times (a matrix)."), tr("Skip rest"), tr("See next"), new QString(), 1, 0);
							if (t == 0)
								reportRoomNotAvailableChange = false;
						}

						crt_constraint = readRoomNotAvailable(parent, elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintRoomNotAvailableTimes")
					{
						crt_constraint = readRoomNotAvailableTimes(parent, elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintRoomTypeNotAllowedSubjects" && !skipDeprecatedConstraints)
					{

						int t = RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("File contains deprecated constraint room type not allowed subjects - will be ignored\n"), tr("Skip rest"), tr("See next"), new QString(), 1, 0);

						if (t == 0)
							skipDeprecatedConstraints = true;
						crt_constraint = null;
					}
					else if (elem3.tagName() == "ConstraintSubjectRequiresEquipments" && !skipDeprecatedConstraints)
					{

						int t = RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("File contains deprecated constraint subject requires equipments - will be ignored\n"), tr("Skip rest"), tr("See next"), new QString(), 1, 0);

						if (t == 0)
							skipDeprecatedConstraints = true;

						crt_constraint = null;
					}
					else if (elem3.tagName() == "ConstraintSubjectSubjectTagRequireEquipments" && !skipDeprecatedConstraints)
					{

						int t = RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("File contains deprecated constraint subject tag requires equipments - will be ignored\n"), tr("Skip rest"), tr("See next"), new QString(), 1, 0);

						if (t == 0)
							skipDeprecatedConstraints = true;
						crt_constraint = null;
					}
					else if (elem3.tagName() == "ConstraintTeacherRequiresRoom" && !skipDeprecatedConstraints)
					{

						int t = RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("File contains deprecated constraint teacher requires room - will be ignored\n"), tr("Skip rest"), tr("See next"), new QString(), 1, 0);

						if (t == 0)
							skipDeprecatedConstraints = true;
						crt_constraint = null;
					}
					else if (elem3.tagName() == "ConstraintTeacherSubjectRequireRoom" && !skipDeprecatedConstraints)
					{

						int t = RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("File contains deprecated constraint teacher subject require room - will be ignored\n"), tr("Skip rest"), tr("See next"), new QString(), 1, 0);

						if (t == 0)
							skipDeprecatedConstraints = true;
						crt_constraint = null;
					}
					else if (elem3.tagName() == "ConstraintMinimizeNumberOfRoomsForStudents" && !skipDeprecatedConstraints)
					{

						int t = RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("File contains deprecated constraint minimize number of rooms for students - will be ignored\n"), tr("Skip rest"), tr("See next"), new QString(), 1, 0);

						if (t == 0)
							skipDeprecatedConstraints = true;
						crt_constraint = null;
					}
					else if (elem3.tagName() == "ConstraintMinimizeNumberOfRoomsForTeachers" && !skipDeprecatedConstraints)
					{

						int t = RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("File contains deprecated constraint minimize number of rooms for teachers - will be ignored\n"), tr("Skip rest"), tr("See next"), new QString(), 1, 0);

						if (t == 0)
							skipDeprecatedConstraints = true;
						crt_constraint = null;
					}
					else if (elem3.tagName() == "ConstraintActivityPreferredRoom")
					{
						crt_constraint = readActivityPreferredRoom(parent, elem3, ref xmlReadingLog, ref reportUnspecifiedPermanentlyLockedSpace);
					}
					else if (elem3.tagName() == "ConstraintActivityPreferredRooms")
					{
						crt_constraint = readActivityPreferredRooms(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintActivitiesSameRoom" && !skipDeprecatedConstraints)
					{

						int t = RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("File contains deprecated constraint activities same room - will be ignored\n"), tr("Skip rest"), tr("See next"), new QString(), 1, 0);

						if (t == 0)
							skipDeprecatedConstraints = true;
						crt_constraint = null;
					}
					else if (elem3.tagName() == "ConstraintSubjectPreferredRoom")
					{
						crt_constraint = readSubjectPreferredRoom(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintSubjectPreferredRooms")
					{
						crt_constraint = readSubjectPreferredRooms(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintSubjectSubjectTagPreferredRoom")
					{
						crt_constraint = readSubjectSubjectTagPreferredRoom(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintSubjectSubjectTagPreferredRooms")
					{
						crt_constraint = readSubjectSubjectTagPreferredRooms(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintSubjectActivityTagPreferredRoom")
					{
						crt_constraint = readSubjectActivityTagPreferredRoom(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintSubjectActivityTagPreferredRooms")
					{
						crt_constraint = readSubjectActivityTagPreferredRooms(elem3, ref xmlReadingLog);
					}
					//added 6 apr 2009
					else if (elem3.tagName() == "ConstraintActivityTagPreferredRoom")
					{
						crt_constraint = readActivityTagPreferredRoom(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintActivityTagPreferredRooms")
					{
						crt_constraint = readActivityTagPreferredRooms(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintStudentsSetHomeRoom")
					{
						crt_constraint = readStudentsSetHomeRoom(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintStudentsSetHomeRooms")
					{
						crt_constraint = readStudentsSetHomeRooms(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintTeacherHomeRoom")
					{
						crt_constraint = readTeacherHomeRoom(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintTeacherHomeRooms")
					{
						crt_constraint = readTeacherHomeRooms(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintMaxBuildingChangesPerDayForTeachers" && !skipDeprecatedConstraints)
					{

						int t = RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("File contains deprecated constraint max building changes per day for teachers - will be ignored\n"), tr("Skip rest"), tr("See next"), new QString(), 1, 0);

						if (t == 0)
							skipDeprecatedConstraints = true;
						crt_constraint = null;
					}
					else if (elem3.tagName() == "ConstraintMaxBuildingChangesPerDayForStudents" && !skipDeprecatedConstraints)
					{

						int t = RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("File contains deprecated constraint max building changes per day for students - will be ignored\n"), tr("Skip rest"), tr("See next"), new QString(), 1, 0);

						if (t == 0)
							skipDeprecatedConstraints = true;
						crt_constraint = null;
					}
					else if (elem3.tagName() == "ConstraintMaxRoomChangesPerDayForTeachers" && !skipDeprecatedConstraints)
					{

						int t = RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("File contains deprecated constraint max room changes per day for teachers - will be ignored\n"), tr("Skip rest"), tr("See next"), new QString(), 1, 0);

						if (t == 0)
							skipDeprecatedConstraints = true;
						crt_constraint = null;
					}
					else if (elem3.tagName() == "ConstraintMaxRoomChangesPerDayForStudents" && !skipDeprecatedConstraints)
					{

						int t = RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("File contains deprecated constraint max room changes per day for students - will be ignored\n"), tr("Skip rest"), tr("See next"), new QString(), 1, 0);

						if (t == 0)
							skipDeprecatedConstraints = true;

						crt_constraint = null;
					}
					else if (elem3.tagName() == "ConstraintTeacherMaxBuildingChangesPerDay")
					{
						crt_constraint = readTeacherMaxBuildingChangesPerDay(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintTeachersMaxBuildingChangesPerDay")
					{
						crt_constraint = readTeachersMaxBuildingChangesPerDay(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintTeacherMaxBuildingChangesPerWeek")
					{
						crt_constraint = readTeacherMaxBuildingChangesPerWeek(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintTeachersMaxBuildingChangesPerWeek")
					{
						crt_constraint = readTeachersMaxBuildingChangesPerWeek(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintTeacherMinGapsBetweenBuildingChanges")
					{
						crt_constraint = readTeacherMinGapsBetweenBuildingChanges(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintTeachersMinGapsBetweenBuildingChanges")
					{
						crt_constraint = readTeachersMinGapsBetweenBuildingChanges(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintStudentsSetMaxBuildingChangesPerDay")
					{
						crt_constraint = readStudentsSetMaxBuildingChangesPerDay(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintStudentsMaxBuildingChangesPerDay")
					{
						crt_constraint = readStudentsMaxBuildingChangesPerDay(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintStudentsSetMaxBuildingChangesPerWeek")
					{
						crt_constraint = readStudentsSetMaxBuildingChangesPerWeek(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintStudentsMaxBuildingChangesPerWeek")
					{
						crt_constraint = readStudentsMaxBuildingChangesPerWeek(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintStudentsSetMinGapsBetweenBuildingChanges")
					{
						crt_constraint = readStudentsSetMinGapsBetweenBuildingChanges(elem3, ref xmlReadingLog);
					}
					else if (elem3.tagName() == "ConstraintStudentsMinGapsBetweenBuildingChanges")
					{
						crt_constraint = readStudentsMinGapsBetweenBuildingChanges(elem3, ref xmlReadingLog);
					}
	////////////////2012-04-29
					else if (elem3.tagName() == "ConstraintActivitiesOccupyMaxDifferentRooms")
					{
						crt_constraint = readActivitiesOccupyMaxDifferentRooms(elem3, ref xmlReadingLog);
					}
	////////////////

	//corruptConstraintSpace:
					//here we skip invalid constraint or add valid one
					if (crt_constraint != null)
					{
						Debug.Assert(crt_constraint != null);

						bool tmp = this.addSpaceConstraint(crt_constraint);
						if (tmp == null)
						{
							RulesReconcilableMessage.warning(parent, tr("FET information"), tr("Constraint\n%1\nnot added - must be a duplicate").arg(crt_constraint.getDetailedDescription(this)));
							if (crt_constraint != null)
								crt_constraint.Dispose();
						}
						else
							nc++;
					}
				}
				xmlReadingLog += "  Added " + CustomFETString.number(nc) + " space constraints\n";
				reducedXmlLog += "Added " + CustomFETString.number(nc) + " space constraints\n";
			}
		}

		this.internalStructureComputed = false;

		/*reducedXmlLog+="\n";
		reducedXmlLog+="Note: if you have overlapping students sets (years or groups), a group or a subgroup may be counted more than once. "
			"A unique group name is counted once for each year it belongs to and a unique subgroup name is counted once for each year+group it belongs to.\n";*/

		if (canWriteLogFile)
		{
			//logStream<<xmlReadingLog;
			logStream << reducedXmlLog;
		}

		if (file2.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), tr("Saving of logging gave error code %1, which means you cannot see the log of reading the file. Please check your disk free space").arg(file2.error()));
		}

		if (canWriteLogFile)
			file2.close();

		////////////////////////////////////////

		return true;
	}

	/**
	Write the rules to the xml input file "inputfile".
	*/
	private bool write(QWidget parent, QString filename)
	{
		Debug.Assert(this.initialized);

		QString s = new QString();

		bool exists = false;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: QString filenameTmp=filename;
		QString filenameTmp = new QString(filename);
		if (QFile.exists(filenameTmp))
		{
			exists = true;

			filenameTmp.append(new QString(".tmp"));

			if (QFile.exists(filenameTmp))
			{
				int i = 1;
				for (;;)
				{
					QString t2 = filenameTmp + CustomFETString.number(i);
					if (!QFile.exists(t2))
					{
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: filenameTmp=t2;
						filenameTmp.CopyFrom(t2);
						break;
					}
					i++;
				}
			}
		}

		Debug.Assert(!QFile.exists(filenameTmp));

		QFile file = new QFile(filenameTmp);
		if (!file.open(QIODevice.WriteOnly | QIODevice.Truncate))
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), tr("Cannot open %1 for writing ... please check write permissions of the selected directory or your disk free space. Saving of file aborted").arg(QFileInfo(filenameTmp).fileName()));

			return false;
		}

		QTextStream tos = new QTextStream(file);

		tos.setCodec("UTF-8");
		tos.setGenerateByteOrderMark(true);
		//tos.setEncoding(QTextStream::UnicodeUTF8);

		s += "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n\n";

	//	s+="<!DOCTYPE FET><FET version=\""+FET_VERSION+"\">\n\n";
		s += "<fet version=\"" + GlobalMembersTimetable_defs.FET_VERSION + "\">\n\n";

		//the institution name and comments
		s += "<Institution_Name>" + GlobalMembersTimetable_defs.protect(this.institutionName) + "</Institution_Name>\n\n";
		s += "<Comments>" + GlobalMembersTimetable_defs.protect(this.comments) + "</Comments>\n\n";

		//the hours and days
		s += "<Hours_List>\n	<Number>" + CustomFETString.number(this.nHoursPerDay) + "</Number>\n";
		for (int i = 0; i < this.nHoursPerDay; i++)
			s += "	<Name>" + GlobalMembersTimetable_defs.protect(this.hoursOfTheDay[i]) + "</Name>\n";
		s += "</Hours_List>\n\n";
		s += "<Days_List>\n	<Number>" + CustomFETString.number(this.nDaysPerWeek) + "</Number>\n";
		for (int i = 0; i < this.nDaysPerWeek; i++)
			s += "	<Name>" + GlobalMembersTimetable_defs.protect(this.daysOfTheWeek[i]) + "</Name>\n";
		s += "</Days_List>\n\n";

		//students list
		s += "<Students_List>\n";
		for (int i = 0; i < this.yearsList.size(); i++)
		{
			StudentsYear sty = this.yearsList[i];
			s += sty.getXmlDescription();
		}
		s += "</Students_List>\n\n";

		//teachers list
		s += "<Teachers_List>\n";
		for (int i = 0; i < this.teachersList.size(); i++)
		{
			Teacher tch = this.teachersList[i];
			s += tch.getXmlDescription();
		}
		s += "</Teachers_List>\n\n";

		//subjects list
		s += "<Subjects_List>\n";
		for (int i = 0; i < this.subjectsList.size(); i++)
		{
			Subject sbj = this.subjectsList[i];
			s += sbj.getXmlDescription();
		}
		s += "</Subjects_List>\n\n";

		//activity tags list
		s += "<Activity_Tags_List>\n";
		for (int i = 0; i < this.activityTagsList.size(); i++)
		{
			ActivityTag stg = this.activityTagsList[i];
			s += stg.getXmlDescription();
		}
		s += "</Activity_Tags_List>\n\n";

		//activities list
		s += "<Activities_List>\n";
		for (int i = 0; i < this.activitiesList.size(); i++)
		{
			Activity act = this.activitiesList[i];
			s += act.getXmlDescription(this);
			s += "\n";
		}
		s += "</Activities_List>\n\n";

		//buildings list
		s += "<Buildings_List>\n";
		for (int i = 0; i < this.buildingsList.size(); i++)
		{
			Building bu = this.buildingsList[i];
			s += bu.getXmlDescription();
		}
		s += "</Buildings_List>\n\n";

		//rooms list
		s += "<Rooms_List>\n";
		for (int i = 0; i < this.roomsList.size(); i++)
		{
			Room rm = this.roomsList[i];
			s += rm.getXmlDescription();
		}
		s += "</Rooms_List>\n\n";

		//time constraints list
		s += "<Time_Constraints_List>\n";
		for (int i = 0; i < this.timeConstraintsList.size(); i++)
		{
			TimeConstraint ctr = this.timeConstraintsList[i];
			s += ctr.getXmlDescription(this);
		}
		s += "</Time_Constraints_List>\n\n";

		//constraints list
		s += "<Space_Constraints_List>\n";
		for (int i = 0; i < this.spaceConstraintsList.size(); i++)
		{
			SpaceConstraint ctr = this.spaceConstraintsList[i];
			s += ctr.getXmlDescription(this);
		}
		s += "</Space_Constraints_List>\n\n";

	//	s+="</FET>\n";
		s += "</fet>\n";

		tos << s;

		if (file.error() > 0)
		{
			IrreconcilableCriticalMessage.critical(parent, tr("FET critical"), tr("Saved file gave error code %1, which means saving is compromised. Please check your disk free space").arg(file.error()));

			file.close();
			return false;
		}

		file.close();

		if (exists)
		{
			bool tf = QFile.remove(filename);
			Debug.Assert(tf);
			tf = QFile.rename(filenameTmp, filename);
			Debug.Assert(tf);
		}

		return true;
	}

	private int activateTeacher(QString teacherName)
	{
		int count = 0;
		for (int i = 0; i < this.activitiesList.size(); i++)
		{
			Activity act = this.activitiesList[i];
			if (act.searchTeacher(teacherName))
			{
				if (!act.active)
					count++;
				act.active = true;
			}
		}

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		return count;
	}

	private int activateStudents(QString studentsName)
	{
		QSet<QString> allSets = new QSet<QString>();

		StudentsSet set = this.searchStudentsSet(studentsName);
		if (set.type == GlobalMembersStudentsset.STUDENTS_SUBGROUP)
			allSets.insert(studentsName);
		else if (set.type == GlobalMembersStudentsset.STUDENTS_GROUP)
		{
			allSets.insert(studentsName);
			StudentsGroup g = (StudentsGroup)set;
			foreach (StudentsSubgroup * s, g.subgroupsList) allSets.insert(s.name);
		}
		else if (set.type == GlobalMembersStudentsset.STUDENTS_YEAR)
		{
			allSets.insert(studentsName);
			StudentsYear y = (StudentsYear)set;
			foreach (StudentsGroup * g, y.groupsList)
			{
				allSets.insert(g.name);
				foreach (StudentsSubgroup * s, g.subgroupsList) allSets.insert(s.name);
			}
		}

		int count = 0;
		for (int i = 0; i < this.activitiesList.size(); i++)
		{
			Activity act = this.activitiesList[i];
			if (!act.active)
			{
				foreach (QString set, act.studentsNames)
				{
					if (allSets.contains(set))
					{
						count++;
						act.active = true;
						break;
					}
				}
			}
		}

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		return count;
	}

	private int activateSubject(QString subjectName)
	{
		int count = 0;
		for (int i = 0; i < this.activitiesList.size(); i++)
		{
			Activity act = this.activitiesList[i];
			if (act.subjectName == subjectName)
			{
				if (!act.active)
					count++;
				act.active = true;
			}
		}

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		return count;
	}

	private int activateActivityTag(QString activityTagName)
	{
		int count = 0;
		for (int i = 0; i < this.activitiesList.size(); i++)
		{
			Activity act = this.activitiesList[i];
			if (act.activityTagsNames.contains(activityTagName))
			{
				if (!act.active)
					count++;
				act.active = true;
			}
		}

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		return count;
	}

	private int deactivateTeacher(QString teacherName)
	{
		int count = 0;
		for (int i = 0; i < this.activitiesList.size(); i++)
		{
			Activity act = this.activitiesList[i];
			if (act.searchTeacher(teacherName))
			{
				if (act.active)
					count++;
				act.active = false;
			}
		}

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		return count;
	}

	private int deactivateStudents(QString studentsName)
	{
		QSet<QString> allSets = new QSet<QString>();

		StudentsSet set = this.searchStudentsSet(studentsName);
		if (set.type == GlobalMembersStudentsset.STUDENTS_SUBGROUP)
			allSets.insert(studentsName);
		else if (set.type == GlobalMembersStudentsset.STUDENTS_GROUP)
		{
			allSets.insert(studentsName);
			StudentsGroup g = (StudentsGroup)set;
			foreach (StudentsSubgroup * s, g.subgroupsList) allSets.insert(s.name);
		}
		else if (set.type == GlobalMembersStudentsset.STUDENTS_YEAR)
		{
			allSets.insert(studentsName);
			StudentsYear y = (StudentsYear)set;
			foreach (StudentsGroup * g, y.groupsList)
			{
				allSets.insert(g.name);
				foreach (StudentsSubgroup * s, g.subgroupsList) allSets.insert(s.name);
			}
		}

		int count = 0;
		for (int i = 0; i < this.activitiesList.size(); i++)
		{
			Activity act = this.activitiesList[i];
			if (act.active)
			{
				foreach (QString set, act.studentsNames)
				{
					if (allSets.contains(set))
					{
						count++;
						act.active = false;
						break;
					}
				}
			}
		}

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		return count;
	}

	private int deactivateSubject(QString subjectName)
	{
		int count = 0;
		for (int i = 0; i < this.activitiesList.size(); i++)
		{
			Activity act = this.activitiesList[i];
			if (act.subjectName == subjectName)
			{
				if (act.active)
					count++;
				act.active = false;
			}
		}

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		return count;
	}

	private int deactivateActivityTag(QString activityTagName)
	{
		int count = 0;
		for (int i = 0; i < this.activitiesList.size(); i++)
		{
			Activity act = this.activitiesList[i];
			if (act.activityTagsNames.contains(activityTagName))
			{
				if (act.active)
					count++;
				act.active = false;
			}
		}

		this.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(this);

		return count;
	}

	private TimeConstraint readBasicCompulsoryTime(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintBasicCompulsoryTime");
		ConstraintBasicCompulsoryTime cn = new ConstraintBasicCompulsoryTime();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - generating automatic 100% weight percentage\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
		}
		return cn;
	}
	private TimeConstraint readTeacherNotAvailable(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTeacherNotAvailable");

		QList<int> days = new QList<int>();
		QList<int> hours = new QList<int>();
		QString teacher = new QString();
		double weightPercentage = 100;
		int d = -1;
		int h1 = -1;
		int h2 = -1;
		bool active = true;
		QString comments = new QString("");
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Read weight percentage=" + CustomFETString.number(weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				comments = elem4.text();
			}
			else if (elem4.tagName() == "Day")
			{
				for (d = 0; d < this.nDaysPerWeek; d++)
					if (this.daysOfTheWeek[d] == elem4.text())
						break;
				if (d >= this.nDaysPerWeek)
				{
					RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint TeacherNotAvailable day corrupt for teacher %1, day %2 is inexistent ... ignoring constraint").arg(teacher).arg(elem4.text()));
					//cn=NULL;

					return null;
					//goto corruptConstraintTime;
				}
				Debug.Assert(d < this.nDaysPerWeek);
				xmlReadingLog += "    Crt. day=" + this.daysOfTheWeek[d] + "\n";
			}
			else if (elem4.tagName() == "Start_Hour")
			{
				for (h1 = 0; h1 < this.nHoursPerDay; h1++)
					if (this.hoursOfTheDay[h1] == elem4.text())
						break;
				if (h1 >= this.nHoursPerDay)
				{
					RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint TeacherNotAvailable start hour corrupt for teacher %1, hour %2 is inexistent ... ignoring constraint").arg(teacher).arg(elem4.text()));
					//cn=NULL;

					return null;
					//goto corruptConstraintTime;
				}
				Debug.Assert(h1 >= 0 && h1 < this.nHoursPerDay);
				xmlReadingLog += "    Start hour=" + this.hoursOfTheDay[h1] + "\n";
			}
			else if (elem4.tagName() == "End_Hour")
			{
				for (h2 = 0; h2 < this.nHoursPerDay; h2++)
					if (this.hoursOfTheDay[h2] == elem4.text())
						break;
				if (h2 <= 0 || h2>this.nHoursPerDay)
				{
					RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint TeacherNotAvailable end hour corrupt for teacher %1, hour %2 is inexistent ... ignoring constraint").arg(teacher).arg(elem4.text()));

					return null;
					//goto corruptConstraintTime;
				}
				Debug.Assert(h2 > 0 && h2 <= this.nHoursPerDay);
				xmlReadingLog += "    End hour=" + this.hoursOfTheDay[h2] + "\n";
			}
			else if (elem4.tagName() == "Teacher_Name")
			{
				teacher = elem4.text();
				xmlReadingLog += "    Read teacher name=" + teacher + "\n";
			}
		}

		Debug.Assert(weightPercentage >= 0);
		Debug.Assert(d >= 0 && h1 >= 0 && h2 >= 0);

		ConstraintTeacherNotAvailableTimes cn = null;

		bool found = false;
		foreach (TimeConstraint * c, this.timeConstraintsList) if (c.type == GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_NOT_AVAILABLE_TIMES)
		{
				ConstraintTeacherNotAvailableTimes tna = (ConstraintTeacherNotAvailableTimes) c;
				if (tna.teacher == teacher)
				{
					found = true;

					for (int hh = h1; hh < h2; hh++)
					{
						int k;
						for (k = 0; k < tna.days.count(); k++)
							if (tna.days.at(k) == d && tna.hours.at(k) == hh)
								break;
						if (k == tna.days.count())
						{
							tna.days.append(d);
							tna.hours.append(hh);
						}
					}

					Debug.Assert(tna.days.count() == tna.hours.count());
				}
		}
		if (!found)
		{
			days.clear();
			hours.clear();
			for (int hh = h1; hh < h2; hh++)
			{
				days.append(d);
				hours.append(hh);
			}

			cn = new ConstraintTeacherNotAvailableTimes(weightPercentage, teacher, days, hours);
			cn.active = active;
			cn.comments = comments;

			return cn;
		}
		else
			return null;
	}
	private TimeConstraint readTeacherNotAvailableTimes(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTeacherNotAvailableTimes");

		ConstraintTeacherNotAvailableTimes cn = new ConstraintTeacherNotAvailableTimes();
		int nNotAvailableSlots = -1;
		int i = 0;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Read weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}

			else if (elem4.tagName() == "Number_of_Not_Available_Times")
			{
				nNotAvailableSlots = elem4.text().toInt();
				xmlReadingLog += "    Read number of not available times=" + CustomFETString.number(nNotAvailableSlots) + "\n";
			}

			else if (elem4.tagName() == "Not_Available_Time")
			{
				xmlReadingLog += "    Read: not available time\n";

				int d = -1;
				int h = -1;

				for (QDomNode node5 = elem4.firstChild(); !node5.isNull(); node5 = node5.nextSibling())
				{
					QDomElement elem5 = node5.toElement();
					if (elem5.isNull())
					{
						xmlReadingLog += "    Null node here\n";
						continue;
					}
					xmlReadingLog += "    Found " + elem5.tagName() + " tag\n";
					if (elem5.tagName() == "Day")
					{
						for (d = 0; d < this.nDaysPerWeek; d++)
							if (this.daysOfTheWeek[d] == elem5.text())
								break;

						if (d >= this.nDaysPerWeek)
						{
							RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint TeacherNotAvailableTimes day corrupt for teacher %1, day %2 is inexistent ... ignoring constraint").arg(cn.teacher).arg(elem5.text()));
							if (cn != null)
								cn.Dispose();
							cn = null;
							//goto corruptConstraintTime;
							return null;
						}

						Debug.Assert(d < this.nDaysPerWeek);
						xmlReadingLog += "    Day=" + this.daysOfTheWeek[d] + "(" + CustomFETString.number(i) + ")" + "\n";
					}
					else if (elem5.tagName() == "Hour")
					{
						for (h = 0; h < this.nHoursPerDay; h++)
							if (this.hoursOfTheDay[h] == elem5.text())
								break;

						if (h >= this.nHoursPerDay)
						{
							RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint TeacherNotAvailableTimes hour corrupt for teacher %1, hour %2 is inexistent ... ignoring constraint").arg(cn.teacher).arg(elem5.text()));
							if (cn != null)
								cn.Dispose();
							cn = null;
							//goto corruptConstraintTime;
							return null;
						}

						Debug.Assert(h >= 0 && h < this.nHoursPerDay);
						xmlReadingLog += "    Hour=" + this.hoursOfTheDay[h] + "\n";
					}
				}
				i++;

				cn.days.append(d);
				cn.hours.append(h);
			}
			else if (elem4.tagName() == "Teacher")
			{
				cn.teacher = elem4.text();
				xmlReadingLog += "    Read teacher name=" + cn.teacher + "\n";
			}
		}
		Debug.Assert(i == cn.days.count() && i == cn.hours.count());
		Debug.Assert(i == nNotAvailableSlots);
		return cn;
	}
	private TimeConstraint readTeacherMaxDaysPerWeek(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTeacherMaxDaysPerWeek");

		ConstraintTeacherMaxDaysPerWeek cn = new ConstraintTeacherMaxDaysPerWeek();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - generating 100% weight percentage\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Teacher_Name")
			{
				cn.teacherName = elem4.text();
				xmlReadingLog += "    Read teacher name=" + cn.teacherName + "\n";
			}
			else if (elem4.tagName() == "Max_Days_Per_Week")
			{
				cn.maxDaysPerWeek = elem4.text().toInt();
				if (cn.maxDaysPerWeek <= 0 || cn.maxDaysPerWeek>this.nDaysPerWeek)
				{
					RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint TeacherMaxDaysPerWeek day corrupt for teacher %1, max days %2 <= 0 or >nDaysPerWeek, ignoring constraint").arg(cn.teacherName).arg(elem4.text()));
					if (cn != null)
						cn.Dispose();
					cn = null;
					return null;
				}
				Debug.Assert(cn.maxDaysPerWeek > 0 && cn.maxDaysPerWeek <= this.nDaysPerWeek);
				xmlReadingLog += "    Max. days per week=" + CustomFETString.number(cn.maxDaysPerWeek) + "\n";
			}
		}
		return cn;
	}
	private TimeConstraint readTeachersMaxDaysPerWeek(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTeachersMaxDaysPerWeek");

		ConstraintTeachersMaxDaysPerWeek cn = new ConstraintTeachersMaxDaysPerWeek();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Max_Days_Per_Week")
			{
				cn.maxDaysPerWeek = elem4.text().toInt();
				if (cn.maxDaysPerWeek <= 0 || cn.maxDaysPerWeek>this.nDaysPerWeek)
				{
					RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint TeachersMaxDaysPerWeek day corrupt, max days %1 <= 0 or >nDaysPerWeek, ignoring constraint").arg(elem4.text()));
					if (cn != null)
						cn.Dispose();
					cn = null;
					return null;
				}
				Debug.Assert(cn.maxDaysPerWeek > 0 && cn.maxDaysPerWeek <= this.nDaysPerWeek);
				xmlReadingLog += "    Max. days per week=" + CustomFETString.number(cn.maxDaysPerWeek) + "\n";
			}
		}
		return cn;
	}

	private TimeConstraint readTeacherMinDaysPerWeek(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTeacherMinDaysPerWeek");

		ConstraintTeacherMinDaysPerWeek cn = new ConstraintTeacherMinDaysPerWeek();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Teacher_Name")
			{
				cn.teacherName = elem4.text();
				xmlReadingLog += "    Read teacher name=" + cn.teacherName + "\n";
			}
			else if (elem4.tagName() == "Minimum_Days_Per_Week")
			{
				cn.minDaysPerWeek = elem4.text().toInt();
				if (cn.minDaysPerWeek <= 0 || cn.minDaysPerWeek>this.nDaysPerWeek)
				{
					RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint TeacherMinDaysPerWeek day corrupt for teacher %1, min days %2 <= 0 or >nDaysPerWeek, ignoring constraint").arg(cn.teacherName).arg(elem4.text()));
					if (cn != null)
						cn.Dispose();
					cn = null;
					return null;
				}
				Debug.Assert(cn.minDaysPerWeek > 0 && cn.minDaysPerWeek <= this.nDaysPerWeek);
				xmlReadingLog += "    Min. days per week=" + CustomFETString.number(cn.minDaysPerWeek) + "\n";
			}
		}
		return cn;
	}
	private TimeConstraint readTeachersMinDaysPerWeek(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTeachersMinDaysPerWeek");

		ConstraintTeachersMinDaysPerWeek cn = new ConstraintTeachersMinDaysPerWeek();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Minimum_Days_Per_Week")
			{
				cn.minDaysPerWeek = elem4.text().toInt();
				if (cn.minDaysPerWeek <= 0 || cn.minDaysPerWeek>this.nDaysPerWeek)
				{
					RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint TeachersMinDaysPerWeek day corrupt, min days %1 <= 0 or >nDaysPerWeek, ignoring constraint").arg(elem4.text()));
					if (cn != null)
						cn.Dispose();
					cn = null;
					return null;
				}
				Debug.Assert(cn.minDaysPerWeek > 0 && cn.minDaysPerWeek <= this.nDaysPerWeek);
				xmlReadingLog += "    Min. days per week=" + CustomFETString.number(cn.minDaysPerWeek) + "\n";
			}
		}
		return cn;
	}

	private TimeConstraint readTeacherIntervalMaxDaysPerWeek(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTeacherIntervalMaxDaysPerWeek");
		ConstraintTeacherIntervalMaxDaysPerWeek cn = new ConstraintTeacherIntervalMaxDaysPerWeek();
		cn.maxDaysPerWeek = this.nDaysPerWeek;
		cn.startHour = this.nHoursPerDay;
		cn.endHour = this.nHoursPerDay;
		int h1;
		int h2;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - generating 100% weight percentage\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Teacher_Name")
			{
				cn.teacherName = elem4.text();
				xmlReadingLog += "    Read teacher name=" + cn.teacherName + "\n";
			}
			else if (elem4.tagName() == "Max_Days_Per_Week")
			{
				cn.maxDaysPerWeek = elem4.text().toInt();
				if (cn.maxDaysPerWeek > this.nDaysPerWeek)
				{
					RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint TeacherIntervalMaxDaysPerWeek max days corrupt for teacher %1, max days %2 >nDaysPerWeek, constraint added, please correct constraint").arg(cn.teacherName).arg(elem4.text()));
					/*delete cn;
					cn=NULL;
					goto corruptConstraintTime;*/
				}
				//assert(cn->maxDaysPerWeek>0 && cn->maxDaysPerWeek <= this->nDaysPerWeek);
				xmlReadingLog += "    Max. days per week=" + CustomFETString.number(cn.maxDaysPerWeek) + "\n";
			}
			else if (elem4.tagName() == "Interval_Start_Hour")
			{
				for (h1 = 0; h1 < this.nHoursPerDay; h1++)
					if (this.hoursOfTheDay[h1] == elem4.text())
						break;
				if (h1 >= this.nHoursPerDay)
				{
					RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint Teacher interval max days per week start hour corrupt for teacher %1, hour %2 is inexistent ... ignoring constraint").arg(cn.teacherName).arg(elem4.text()));
					if (cn != null)
						cn.Dispose();
					//cn=NULL;
					//goto corruptConstraintTime;
					return null;
				}
				Debug.Assert(h1 >= 0 && h1 < this.nHoursPerDay);
				xmlReadingLog += "    Interval start hour=" + this.hoursOfTheDay[h1] + "\n";
				cn.startHour = h1;
			}
			else if (elem4.tagName() == "Interval_End_Hour")
			{
				if (elem4.text() == "")
				{
					xmlReadingLog += "    Interval end hour void, meaning end of day\n";
					cn.endHour = this.nHoursPerDay;
				}
				else
				{
					for (h2 = 0; h2 < this.nHoursPerDay; h2++)
						if (this.hoursOfTheDay[h2] == elem4.text())
							break;
					if (h2 >= this.nHoursPerDay)
					{
						RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint Teacher interval max days per week end hour corrupt for teacher %1, hour %2 is inexistent (it is also not void, to specify end of the day) ... ignoring constraint").arg(cn.teacherName).arg(elem4.text()));
						if (cn != null)
							cn.Dispose();
						//cn=NULL;
						//goto corruptConstraintTime;
						return null;
					}
					Debug.Assert(h2 >= 0 && h2 < this.nHoursPerDay);
					xmlReadingLog += "    Interval end hour=" + this.hoursOfTheDay[h2] + "\n";
					cn.endHour = h2;
				}
			}
		}
		return cn;
	}
	private TimeConstraint readTeachersIntervalMaxDaysPerWeek(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTeachersIntervalMaxDaysPerWeek");
		ConstraintTeachersIntervalMaxDaysPerWeek cn = new ConstraintTeachersIntervalMaxDaysPerWeek();
		cn.maxDaysPerWeek = this.nDaysPerWeek;
		cn.startHour = this.nHoursPerDay;
		cn.endHour = this.nHoursPerDay;
		int h1;
		int h2;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - generating 100% weight percentage\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			/*else if(elem4.tagName()=="Teacher_Name"){
				cn->teacherName=elem4.text();
				xmlReadingLog+="    Read teacher name="+cn->teacherName+"\n";
			}*/
			else if (elem4.tagName() == "Max_Days_Per_Week")
			{
				cn.maxDaysPerWeek = elem4.text().toInt();
				if (cn.maxDaysPerWeek > this.nDaysPerWeek)
				{
					RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint TeachersIntervalMaxDaysPerWeek max days corrupt, max days %2 >nDaysPerWeek, constraint added, please correct constraint").arg(elem4.text()));
						//.arg(cn->teacherName)
					/*delete cn;
					cn=NULL;
					goto corruptConstraintTime;*/
				}
				//assert(cn->maxDaysPerWeek>0 && cn->maxDaysPerWeek <= this->nDaysPerWeek);
				xmlReadingLog += "    Max. days per week=" + CustomFETString.number(cn.maxDaysPerWeek) + "\n";
			}
			else if (elem4.tagName() == "Interval_Start_Hour")
			{
				for (h1 = 0; h1 < this.nHoursPerDay; h1++)
					if (this.hoursOfTheDay[h1] == elem4.text())
						break;
				if (h1 >= this.nHoursPerDay)
				{
					RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint Teachers interval max days per week start hour corrupt because hour %2 is inexistent ... ignoring constraint").arg(elem4.text()));
						//.arg(cn->teacherName)
					if (cn != null)
						cn.Dispose();
					//cn=NULL;
					//goto corruptConstraintTime;
					return null;
				}
				Debug.Assert(h1 >= 0 && h1 < this.nHoursPerDay);
				xmlReadingLog += "    Interval start hour=" + this.hoursOfTheDay[h1] + "\n";
				cn.startHour = h1;
			}
			else if (elem4.tagName() == "Interval_End_Hour")
			{
				if (elem4.text() == "")
				{
					xmlReadingLog += "    Interval end hour void, meaning end of day\n";
					cn.endHour = this.nHoursPerDay;
				}
				else
				{
					for (h2 = 0; h2 < this.nHoursPerDay; h2++)
						if (this.hoursOfTheDay[h2] == elem4.text())
							break;
					if (h2 >= this.nHoursPerDay)
					{
						RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint Teachers interval max days per week end hour corrupt because hour %2 is inexistent (it is also not void, to specify end of the day) ... ignoring constraint").arg(elem4.text()));
							//.arg(cn->teacherName)
						if (cn != null)
							cn.Dispose();
						//cn=NULL;
						//goto corruptConstraintTime;
						return null;
					}
					Debug.Assert(h2 >= 0 && h2 < this.nHoursPerDay);
					xmlReadingLog += "    Interval end hour=" + this.hoursOfTheDay[h2] + "\n";
					cn.endHour = h2;
				}
			}
		}
		return cn;
	}
	private TimeConstraint readStudentsSetIntervalMaxDaysPerWeek(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsSetIntervalMaxDaysPerWeek");
		ConstraintStudentsSetIntervalMaxDaysPerWeek cn = new ConstraintStudentsSetIntervalMaxDaysPerWeek();
		cn.maxDaysPerWeek = this.nDaysPerWeek;
		cn.startHour = this.nHoursPerDay;
		cn.endHour = this.nHoursPerDay;
		int h1;
		int h2;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - generating 100% weight percentage\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Students")
			{
				cn.students = elem4.text();
				xmlReadingLog += "    Read students set name=" + cn.students + "\n";
			}
			else if (elem4.tagName() == "Max_Days_Per_Week")
			{
				cn.maxDaysPerWeek = elem4.text().toInt();
				if (cn.maxDaysPerWeek > this.nDaysPerWeek)
				{
					RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint StudentsSetIntervalMaxDaysPerWeek max days corrupt for students set %1, max days %2 >nDaysPerWeek, constraint added, please correct constraint").arg(cn.students).arg(elem4.text()));
					/*delete cn;
					cn=NULL;
					goto corruptConstraintTime;*/
				}
				//assert(cn->maxDaysPerWeek>0 && cn->maxDaysPerWeek <= this->nDaysPerWeek);
				xmlReadingLog += "    Max. days per week=" + CustomFETString.number(cn.maxDaysPerWeek) + "\n";
			}
			else if (elem4.tagName() == "Interval_Start_Hour")
			{
				for (h1 = 0; h1 < this.nHoursPerDay; h1++)
					if (this.hoursOfTheDay[h1] == elem4.text())
						break;
				if (h1 >= this.nHoursPerDay)
				{
					RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint Students set interval max days per week start hour corrupt for students %1, hour %2 is inexistent ... ignoring constraint").arg(cn.students).arg(elem4.text()));
					if (cn != null)
						cn.Dispose();
					//cn=NULL;
					//goto corruptConstraintTime;
					return null;
				}
				Debug.Assert(h1 >= 0 && h1 < this.nHoursPerDay);
				xmlReadingLog += "    Interval start hour=" + this.hoursOfTheDay[h1] + "\n";
				cn.startHour = h1;
			}
			else if (elem4.tagName() == "Interval_End_Hour")
			{
				if (elem4.text() == "")
				{
					xmlReadingLog += "    Interval end hour void, meaning end of day\n";
					cn.endHour = this.nHoursPerDay;
				}
				else
				{
					for (h2 = 0; h2 < this.nHoursPerDay; h2++)
						if (this.hoursOfTheDay[h2] == elem4.text())
							break;
					if (h2 >= this.nHoursPerDay)
					{
						RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint Students set interval max days per week end hour corrupt for students %1, hour %2 is inexistent (it is also not void, to specify end of the day) ... ignoring constraint").arg(cn.students).arg(elem4.text()));
						if (cn != null)
							cn.Dispose();
						//cn=NULL;
						//goto corruptConstraintTime;
						return null;
					}
					Debug.Assert(h2 >= 0 && h2 < this.nHoursPerDay);
					xmlReadingLog += "    Interval end hour=" + this.hoursOfTheDay[h2] + "\n";
					cn.endHour = h2;
				}
			}
		}
		return cn;
	}
	private TimeConstraint readStudentsIntervalMaxDaysPerWeek(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsIntervalMaxDaysPerWeek");
		ConstraintStudentsIntervalMaxDaysPerWeek cn = new ConstraintStudentsIntervalMaxDaysPerWeek();
		cn.maxDaysPerWeek = this.nDaysPerWeek;
		cn.startHour = this.nHoursPerDay;
		cn.endHour = this.nHoursPerDay;
		int h1;
		int h2;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - generating 100% weight percentage\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			/*else if(elem4.tagName()=="Students"){
				cn->students=elem4.text();
				xmlReadingLog+="    Read students set name="+cn->students+"\n";
			}*/
			else if (elem4.tagName() == "Max_Days_Per_Week")
			{
				cn.maxDaysPerWeek = elem4.text().toInt();
				if (cn.maxDaysPerWeek > this.nDaysPerWeek)
				{
					RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint StudentsIntervalMaxDaysPerWeek max days corrupt: max days %2 >nDaysPerWeek, constraint added, please correct constraint").arg(elem4.text()));
					/*delete cn;
					cn=NULL;
					goto corruptConstraintTime;*/
				}
				//assert(cn->maxDaysPerWeek>0 && cn->maxDaysPerWeek <= this->nDaysPerWeek);
				xmlReadingLog += "    Max. days per week=" + CustomFETString.number(cn.maxDaysPerWeek) + "\n";
			}
			else if (elem4.tagName() == "Interval_Start_Hour")
			{
				for (h1 = 0; h1 < this.nHoursPerDay; h1++)
					if (this.hoursOfTheDay[h1] == elem4.text())
						break;
				if (h1 >= this.nHoursPerDay)
				{
					RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint Students interval max days per week start hour corrupt: hour %2 is inexistent ... ignoring constraint").arg(elem4.text()));
						//.arg(cn->students)
					if (cn != null)
						cn.Dispose();
					//cn=NULL;
					//goto corruptConstraintTime;
					return null;
				}
				Debug.Assert(h1 >= 0 && h1 < this.nHoursPerDay);
				xmlReadingLog += "    Interval start hour=" + this.hoursOfTheDay[h1] + "\n";
				cn.startHour = h1;
			}
			else if (elem4.tagName() == "Interval_End_Hour")
			{
				if (elem4.text() == "")
				{
					xmlReadingLog += "    Interval end hour void, meaning end of day\n";
					cn.endHour = this.nHoursPerDay;
				}
				else
				{
					for (h2 = 0; h2 < this.nHoursPerDay; h2++)
						if (this.hoursOfTheDay[h2] == elem4.text())
							break;
					if (h2 >= this.nHoursPerDay)
					{
						RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint Students interval max days per week end hour corrupt: hour %2 is inexistent (it is also not void, to specify end of the day) ... ignoring constraint").arg(elem4.text()));
							//.arg(cn->students)
						if (cn != null)
							cn.Dispose();
						//cn=NULL;
						//goto corruptConstraintTime;
						return null;
					}
					Debug.Assert(h2 >= 0 && h2 < this.nHoursPerDay);
					xmlReadingLog += "    Interval end hour=" + this.hoursOfTheDay[h2] + "\n";
					cn.endHour = h2;
				}
			}
		}
		return cn;
	}
	private TimeConstraint readStudentsSetNotAvailable(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsSetNotAvailable");

		//ConstraintStudentsSetNotAvailableTimes* cn=new ConstraintStudentsSetNotAvailableTimes();
		QList<int> days = new QList<int>();
		QList<int> hours = new QList<int>();
		QString students = new QString();
		double weightPercentage = 100;
		int d = -1;
		int h1 = -1;
		int h2 = -1;
		bool active = true;
		QString comments = new QString("");
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Read weight percentage=" + CustomFETString.number(weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				comments = elem4.text();
			}
			else if (elem4.tagName() == "Day")
			{
				for (d = 0; d < this.nDaysPerWeek; d++)
					if (this.daysOfTheWeek[d] == elem4.text())
						break;
				if (d >= this.nDaysPerWeek)
				{
					RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint StudentsSetNotAvailable day corrupt for students %1, day %2 is inexistent ... ignoring constraint").arg(students).arg(elem4.text()));
					//cn=NULL;
					//goto corruptConstraintTime;
					return null;
				}
				Debug.Assert(d < this.nDaysPerWeek);
				xmlReadingLog += "    Crt. day=" + this.daysOfTheWeek[d] + "\n";
			}
			else if (elem4.tagName() == "Start_Hour")
			{
				for (h1 = 0; h1 < this.nHoursPerDay; h1++)
					if (this.hoursOfTheDay[h1] == elem4.text())
						break;
				if (h1 >= this.nHoursPerDay)
				{
					RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint StudentsSetNotAvailable start hour corrupt for students set %1, hour %2 is inexistent ... ignoring constraint").arg(students).arg(elem4.text()));
					//cn=NULL;
					//goto corruptConstraintTime;
					return null;
				}
				Debug.Assert(h1 >= 0 && h1 < this.nHoursPerDay);
				xmlReadingLog += "    Start hour=" + this.hoursOfTheDay[h1] + "\n";
			}
			else if (elem4.tagName() == "End_Hour")
			{
				for (h2 = 0; h2 < this.nHoursPerDay; h2++)
					if (this.hoursOfTheDay[h2] == elem4.text())
						break;
				if (h2 <= 0 || h2>this.nHoursPerDay)
				{
					RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint StudentsSetNotAvailable end hour corrupt for students %1, hour %2 is inexistent ... ignoring constraint").arg(students).arg(elem4.text()));
					//goto corruptConstraintTime;
					return null;
				}
				Debug.Assert(h2 > 0 && h2 <= this.nHoursPerDay);
				xmlReadingLog += "    End hour=" + this.hoursOfTheDay[h2] + "\n";
			}
			else if (elem4.tagName() == "Students")
			{
				students = elem4.text();
				xmlReadingLog += "    Read students name=" + students + "\n";
			}
		}

		Debug.Assert(weightPercentage >= 0);
		Debug.Assert(d >= 0 && h1 >= 0 && h2 >= 0);

		ConstraintStudentsSetNotAvailableTimes cn = null;

		bool found = false;
		foreach (TimeConstraint * c, this.timeConstraintsList) if (c.type == GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_NOT_AVAILABLE_TIMES)
		{
				ConstraintStudentsSetNotAvailableTimes ssna = (ConstraintStudentsSetNotAvailableTimes) c;
				if (ssna.students == students)
				{
					found = true;

					for (int hh = h1; hh < h2; hh++)
					{
						int k;
						for (k = 0; k < ssna.days.count(); k++)
							if (ssna.days.at(k) == d && ssna.hours.at(k) == hh)
								break;
						if (k == ssna.days.count())
						{
							ssna.days.append(d);
							ssna.hours.append(hh);
						}
					}

					Debug.Assert(ssna.days.count() == ssna.hours.count());
				}
		}
		if (!found)
		{
			days.clear();
			hours.clear();
			for (int hh = h1; hh < h2; hh++)
			{
				days.append(d);
				hours.append(hh);
			}

			cn = new ConstraintStudentsSetNotAvailableTimes(weightPercentage, students, days, hours);
			cn.active = active;
			cn.comments = comments;

			//crt_constraint=cn;
			return cn;
		}
		else
			return null;
	}
	private TimeConstraint readStudentsSetNotAvailableTimes(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsSetNotAvailableTimes");

		ConstraintStudentsSetNotAvailableTimes cn = new ConstraintStudentsSetNotAvailableTimes();
		int nNotAvailableSlots = 0;
		int i = 0;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Read weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}

			else if (elem4.tagName() == "Number_of_Not_Available_Times")
			{
				nNotAvailableSlots = elem4.text().toInt();
				xmlReadingLog += "    Read number of not available times=" + CustomFETString.number(nNotAvailableSlots) + "\n";
			}

			else if (elem4.tagName() == "Not_Available_Time")
			{
				xmlReadingLog += "    Read: not available time\n";

				int d = -1;
				int h = -1;

				for (QDomNode node5 = elem4.firstChild(); !node5.isNull(); node5 = node5.nextSibling())
				{
					QDomElement elem5 = node5.toElement();
					if (elem5.isNull())
					{
						xmlReadingLog += "    Null node here\n";
						continue;
					}
					xmlReadingLog += "    Found " + elem5.tagName() + " tag\n";
					if (elem5.tagName() == "Day")
					{
						for (d = 0; d < this.nDaysPerWeek; d++)
							if (this.daysOfTheWeek[d] == elem5.text())
								break;

						if (d >= this.nDaysPerWeek)
						{
							RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint StudentsSetNotAvailableTimes day corrupt for students %1, day %2 is inexistent ... ignoring constraint").arg(cn.students).arg(elem5.text()));
							if (cn != null)
								cn.Dispose();
							cn = null;
							//goto corruptConstraintTime;
							return null;
						}

						Debug.Assert(d < this.nDaysPerWeek);
						xmlReadingLog += "    Day=" + this.daysOfTheWeek[d] + "(" + CustomFETString.number(i) + ")" + "\n";
					}
					else if (elem5.tagName() == "Hour")
					{
						for (h = 0; h < this.nHoursPerDay; h++)
							if (this.hoursOfTheDay[h] == elem5.text())
								break;

						if (h >= this.nHoursPerDay)
						{
							RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint StudentsSetNotAvailableTimes hour corrupt for students %1, hour %2 is inexistent ... ignoring constraint").arg(cn.students).arg(elem5.text()));
							if (cn != null)
								cn.Dispose();
							cn = null;
							//goto corruptConstraintTime;
							return null;
						}

						Debug.Assert(h >= 0 && h < this.nHoursPerDay);
						xmlReadingLog += "    Hour=" + this.hoursOfTheDay[h] + "\n";
					}
				}
				i++;

				cn.days.append(d);
				cn.hours.append(h);
			}
			else if (elem4.tagName() == "Students")
			{
				cn.students = elem4.text();
				xmlReadingLog += "    Read students name=" + cn.students + "\n";
			}
		}
		Debug.Assert(i == cn.days.count() && i == cn.hours.count());
		Debug.Assert(i == nNotAvailableSlots);
		return cn;
	}
	private TimeConstraint readMinNDaysBetweenActivities(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintMinNDaysBetweenActivities");

		ConstraintMinDaysBetweenActivities cn = new ConstraintMinDaysBetweenActivities();
		bool foundCISD = false;
		int n_act = 0;
		cn.activitiesId.clear();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - generating weightPercentage=95%\n";
				cn.weightPercentage = 95;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weightPercentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Consecutive_If_Same_Day" || elem4.tagName() == "Adjacent_If_Broken")
			{
				if (elem4.text() == "yes" || elem4.text() == "true" || elem4.text() == "1")
				{
					cn.consecutiveIfSameDay = true;
					foundCISD = true;
					xmlReadingLog += "    Current constraint has consecutive if same day=true\n";
				}
				else
				{
					if (!(elem4.text() == "no" || elem4.text() == "false" || elem4.text() == "0"))
					{
						RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("Found constraint min days between activities with tag consecutive if same day" + " which is not 'true', 'false', 'yes', 'no', '1' or '0'." + " The tag will be considered false", "Instructions for translators: please leave the 'true', 'false', 'yes' and 'no' fields untranslated, as they are in English"));
					}
					//assert(elem4.text()=="no" || elem4.text()=="false" || elem4.text()=="0");
					cn.consecutiveIfSameDay = false;
					foundCISD = true;
					xmlReadingLog += "    Current constraint has consecutive if same day=false\n";
				}
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 95;
					cn.consecutiveIfSameDay = true;
					foundCISD = true;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
					cn.consecutiveIfSameDay = false;
					foundCISD = true;
				}
			}
			else if (elem4.tagName() == "Number_of_Activities")
			{
				cn.n_activities = elem4.text().toInt();
				xmlReadingLog += "    Read n_activities=" + CustomFETString.number(cn.n_activities) + "\n";
			}
			else if (elem4.tagName() == "Activity_Id")
			{
				//cn->activitiesId[n_act]=elem4.text().toInt();
				cn.activitiesId.append(elem4.text().toInt());
				Debug.Assert(n_act == cn.activitiesId.count() - 1);
				xmlReadingLog += "    Read activity id=" + CustomFETString.number(cn.activitiesId[n_act]) + "\n";
				n_act++;
			}
			else if (elem4.tagName() == "MinDays")
			{
				cn.minDays = elem4.text().toInt();
				xmlReadingLog += "    Read MinDays=" + CustomFETString.number(cn.minDays) + "\n";
			}
		}
		if (!foundCISD)
		{
			xmlReadingLog += "    Could not find consecutive if same day information - making it true\n";
			cn.consecutiveIfSameDay = true;
		}
		Debug.Assert(n_act == cn.n_activities);
		return cn;
	/*
	#if 0
		if(0 && reportIncorrectMinDays && cn->n_activities > this->nDaysPerWeek){
			QString s=tr("You have a constraint min days between activities with more activities than the number of days per week.");
			s+=" ";
			s+=tr("Constraint is:");
			s+="\n";
			s+=crt_constraint->getDescription(*this);
			s+="\n";
			s+=tr("This is a very bad practice from the way the algorithm of generation works (it slows down the generation and makes it harder to find a solution).");
			s+="\n\n";
			s+=tr("To improve your file, you are advised to remove the corresponding activities and constraint and add activities again, respecting the following rules:");
			s+="\n\n";
			s+=tr("1. If you add 'force consecutive if same day', then couple extra activities in pairs to obtain a number of activities equal to the number of days per week"
				". Example: 7 activities with duration 1 in a 5 days week, then transform into 5 activities with durations: 2,2,1,1,1 and add a single container activity with these 5 components"
				" (possibly raising the weight of added constraint min days between activities up to 100%)");
			s+="\n\n";
	
			s+=tr("2. If you don't add 'force consecutive if same day', then add a larger activity splitted into a number of"
				" activities equal with the number of days per week and the remaining components into other larger splitted activity."
				" For example, suppose you need to add 7 activities with duration 1 in a 5 days week. Add 2 larger container activities,"
				" first one splitted into 5 activities with duration 1 and second one splitted into 2 activities with duration 1"
				" (possibly raising the weight of added constraints min days between activities for each of the 2 containers up to 100%)");
	
			int t=QMessageBox::warning(parent, tr("FET warning"), s,
				tr("Skip rest"), tr("See next"), QString(),
				1, 0 );
	
			if(t==0)
				reportIncorrectMinDays=false;
		}
	#endif
	*/
	}
	private TimeConstraint readMinDaysBetweenActivities(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintMinDaysBetweenActivities");

		ConstraintMinDaysBetweenActivities cn = new ConstraintMinDaysBetweenActivities();
		bool foundCISD = false;
		int n_act = 0;
		cn.activitiesId.clear();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - generating weightPercentage=95%\n";
				cn.weightPercentage = 95;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weightPercentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Consecutive_If_Same_Day" || elem4.tagName() == "Adjacent_If_Broken")
			{
				if (elem4.text() == "yes" || elem4.text() == "true" || elem4.text() == "1")
				{
					cn.consecutiveIfSameDay = true;
					foundCISD = true;
					xmlReadingLog += "    Current constraint has consecutive if same day=true\n";
				}
				else
				{
					if (!(elem4.text() == "no" || elem4.text() == "false" || elem4.text() == "0"))
					{
						RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("Found constraint min days between activities with tag consecutive if same day" + " which is not 'true', 'false', 'yes', 'no', '1' or '0'." + " The tag will be considered false", "Instructions for translators: please leave the 'true', 'false', 'yes' and 'no' fields untranslated, as they are in English"));
					}
					//assert(elem4.text()=="no" || elem4.text()=="false" || elem4.text()=="0");
					cn.consecutiveIfSameDay = false;
					foundCISD = true;
					xmlReadingLog += "    Current constraint has consecutive if same day=false\n";
				}
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 95;
					cn.consecutiveIfSameDay = true;
					foundCISD = true;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
					cn.consecutiveIfSameDay = false;
					foundCISD = true;
				}
			}
			else if (elem4.tagName() == "Number_of_Activities")
			{
				cn.n_activities = elem4.text().toInt();
				xmlReadingLog += "    Read n_activities=" + CustomFETString.number(cn.n_activities) + "\n";
			}
			else if (elem4.tagName() == "Activity_Id")
			{
				//cn->activitiesId[n_act]=elem4.text().toInt();
				cn.activitiesId.append(elem4.text().toInt());
				Debug.Assert(n_act == cn.activitiesId.count() - 1);
				xmlReadingLog += "    Read activity id=" + CustomFETString.number(cn.activitiesId[n_act]) + "\n";
				n_act++;
			}
			else if (elem4.tagName() == "MinDays")
			{
				cn.minDays = elem4.text().toInt();
				xmlReadingLog += "    Read MinDays=" + CustomFETString.number(cn.minDays) + "\n";
			}
		}
		if (!foundCISD)
		{
			xmlReadingLog += "    Could not find consecutive if same day information - making it true\n";
			cn.consecutiveIfSameDay = true;
		}
		Debug.Assert(n_act == cn.n_activities);
		return cn;
	/*
	#if 0
		if(0 && reportIncorrectMinDays && cn->n_activities > this->nDaysPerWeek){
			QString s=tr("You have a constraint min days between activities with more activities than the number of days per week.");
			s+=" ";
			s+=tr("Constraint is:");
			s+="\n";
			s+=crt_constraint->getDescription(*this);
			s+="\n";
			s+=tr("This is a very bad practice from the way the algorithm of generation works (it slows down the generation and makes it harder to find a solution).");
			s+="\n\n";
			s+=tr("To improve your file, you are advised to remove the corresponding activities and constraint and add activities again, respecting the following rules:");
			s+="\n\n";
			s+=tr("1. If you add 'force consecutive if same day', then couple extra activities in pairs to obtain a number of activities equal to the number of days per week"
				". Example: 7 activities with duration 1 in a 5 days week, then transform into 5 activities with durations: 2,2,1,1,1 and add a single container activity with these 5 components"
				" (possibly raising the weight of added constraint min days between activities up to 100%)");
			s+="\n\n";
	
			s+=tr("2. If you don't add 'force consecutive if same day', then add a larger activity splitted into a number of"
				" activities equal with the number of days per week and the remaining components into other larger splitted activity."
				" For example, suppose you need to add 7 activities with duration 1 in a 5 days week. Add 2 larger container activities,"
				" first one splitted into 5 activities with duration 1 and second one splitted into 2 activities with duration 1"
				" (possibly raising the weight of added constraints min days between activities for each of the 2 containers up to 100%)");
	
			int t=QMessageBox::warning(parent, tr("FET warning"), s,
				tr("Skip rest"), tr("See next"), QString(),
				1, 0 );
	
			if(t==0)
				reportIncorrectMinDays=false;
		}
	#endif
	*/
	}
	private TimeConstraint readMaxDaysBetweenActivities(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintMaxDaysBetweenActivities");

		ConstraintMaxDaysBetweenActivities cn = new ConstraintMaxDaysBetweenActivities();
		int n_act = 0;
		cn.activitiesId.clear();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weightPercentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Number_of_Activities")
			{
				cn.n_activities = elem4.text().toInt();
				xmlReadingLog += "    Read n_activities=" + CustomFETString.number(cn.n_activities) + "\n";
			}
			else if (elem4.tagName() == "Activity_Id")
			{
				cn.activitiesId.append(elem4.text().toInt());
				Debug.Assert(n_act == cn.activitiesId.count() - 1);
				//cn->activitiesId[n_act]=elem4.text().toInt();
				xmlReadingLog += "    Read activity id=" + CustomFETString.number(cn.activitiesId[n_act]) + "\n";
				n_act++;
			}
			else if (elem4.tagName() == "MaxDays")
			{
				cn.maxDays = elem4.text().toInt();
				xmlReadingLog += "    Read MaxDays=" + CustomFETString.number(cn.maxDays) + "\n";
			}
		}
		Debug.Assert(n_act == cn.n_activities);
		return cn;
	}
	private TimeConstraint readMinGapsBetweenActivities(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintMinGapsBetweenActivities");
		ConstraintMinGapsBetweenActivities cn = new ConstraintMinGapsBetweenActivities();
		int n_act = 0;
		cn.activitiesId.clear();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weightPercentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Number_of_Activities")
			{
				cn.n_activities = elem4.text().toInt();
				xmlReadingLog += "    Read n_activities=" + CustomFETString.number(cn.n_activities) + "\n";
			}
			else if (elem4.tagName() == "Activity_Id")
			{
				cn.activitiesId.append(elem4.text().toInt());
				Debug.Assert(n_act == cn.activitiesId.count() - 1);
				xmlReadingLog += "    Read activity id=" + CustomFETString.number(cn.activitiesId[n_act]) + "\n";
				n_act++;
			}
			else if (elem4.tagName() == "MinGaps")
			{
				cn.minGaps = elem4.text().toInt();
				xmlReadingLog += "    Read MinGaps=" + CustomFETString.number(cn.minGaps) + "\n";
			}
		}
		Debug.Assert(n_act == cn.n_activities);
		Debug.Assert(n_act == cn.activitiesId.count());
		return cn;
	}
	private TimeConstraint readActivitiesNotOverlapping(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintActivitiesNotOverlapping");
		ConstraintActivitiesNotOverlapping cn = new ConstraintActivitiesNotOverlapping();
		int n_act = 0;
		cn.activitiesId.clear();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Number_of_Activities")
			{
				cn.n_activities = elem4.text().toInt();
				xmlReadingLog += "    Read n_activities=" + CustomFETString.number(cn.n_activities) + "\n";
			}
			else if (elem4.tagName() == "Activity_Id")
			{
				//cn->activitiesId[n_act]=elem4.text().toInt();
				cn.activitiesId.append(elem4.text().toInt());
				Debug.Assert(n_act == cn.activitiesId.count() - 1);
				xmlReadingLog += "    Read activity id=" + CustomFETString.number(cn.activitiesId[n_act]) + "\n";
				n_act++;
			}
		}
		Debug.Assert(n_act == cn.n_activities);
		return cn;
	}
	private TimeConstraint readActivitiesSameStartingTime(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintActivitiesSameStartingTime");
		ConstraintActivitiesSameStartingTime cn = new ConstraintActivitiesSameStartingTime();
		int n_act = 0;
		cn.activitiesId.clear();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Number_of_Activities")
			{
				cn.n_activities = elem4.text().toInt();
				xmlReadingLog += "    Read n_activities=" + CustomFETString.number(cn.n_activities) + "\n";
			}
			else if (elem4.tagName() == "Activity_Id")
			{
				//cn->activitiesId[n_act]=elem4.text().toInt();
				cn.activitiesId.append(elem4.text().toInt());
				Debug.Assert(n_act == cn.activitiesId.count() - 1);
				xmlReadingLog += "    Read activity id=" + CustomFETString.number(cn.activitiesId[n_act]) + "\n";
				n_act++;
			}
		}
		Debug.Assert(cn.n_activities == n_act);
		return cn;
	}
	private TimeConstraint readActivitiesSameStartingHour(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintActivitiesSameStartingHour");
		ConstraintActivitiesSameStartingHour cn = new ConstraintActivitiesSameStartingHour();
		int n_act = 0;
		cn.activitiesId.clear();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Number_of_Activities")
			{
				cn.n_activities = elem4.text().toInt();
				xmlReadingLog += "    Read n_activities=" + CustomFETString.number(cn.n_activities) + "\n";
			}
			else if (elem4.tagName() == "Activity_Id")
			{
				//cn->activitiesId[n_act]=elem4.text().toInt();
				cn.activitiesId.append(elem4.text().toInt());
				Debug.Assert(n_act == cn.activitiesId.count() - 1);
				xmlReadingLog += "    Read activity id=" + CustomFETString.number(cn.activitiesId[n_act]) + "\n";
				n_act++;
			}
		}
		Debug.Assert(cn.n_activities == n_act);
		return cn;
	}
	private TimeConstraint readActivitiesSameStartingDay(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintActivitiesSameStartingDay");
		ConstraintActivitiesSameStartingDay cn = new ConstraintActivitiesSameStartingDay();
		int n_act = 0;
		cn.activitiesId.clear();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Number_of_Activities")
			{
				cn.n_activities = elem4.text().toInt();
				xmlReadingLog += "    Read n_activities=" + CustomFETString.number(cn.n_activities) + "\n";
			}
			else if (elem4.tagName() == "Activity_Id")
			{
				//cn->activitiesId[n_act]=elem4.text().toInt();
				cn.activitiesId.append(elem4.text().toInt());
				Debug.Assert(n_act == cn.activitiesId.count() - 1);
				xmlReadingLog += "    Read activity id=" + CustomFETString.number(cn.activitiesId[n_act]) + "\n";
				n_act++;
			}
		}
		Debug.Assert(cn.n_activities == n_act);
		return cn;
	}
	private TimeConstraint readTeachersMaxHoursDaily(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTeachersMaxHoursDaily");
		ConstraintTeachersMaxHoursDaily cn = new ConstraintTeachersMaxHoursDaily();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Maximum_Hours_Daily")
			{
				cn.maxHoursDaily = elem4.text().toInt();
				xmlReadingLog += "    Read maxHoursDaily=" + CustomFETString.number(cn.maxHoursDaily) + "\n";
			}
		}
		return cn;
	}
	private TimeConstraint readTeacherMaxHoursDaily(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTeacherMaxHoursDaily");
		ConstraintTeacherMaxHoursDaily cn = new ConstraintTeacherMaxHoursDaily();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Maximum_Hours_Daily")
			{
				cn.maxHoursDaily = elem4.text().toInt();
				xmlReadingLog += "    Read maxHoursDaily=" + CustomFETString.number(cn.maxHoursDaily) + "\n";
			}
			else if (elem4.tagName() == "Teacher_Name")
			{
				cn.teacherName = elem4.text();
				xmlReadingLog += "    Read teacher name=" + cn.teacherName + "\n";
			}
		}
		return cn;
	}
	private TimeConstraint readTeachersMaxHoursContinuously(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTeachersMaxHoursContinuously");
		ConstraintTeachersMaxHoursContinuously cn = new ConstraintTeachersMaxHoursContinuously();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Maximum_Hours_Continuously")
			{
				cn.maxHoursContinuously = elem4.text().toInt();
				xmlReadingLog += "    Read maxHoursContinuously=" + CustomFETString.number(cn.maxHoursContinuously) + "\n";
			}
		}
		return cn;
	}
	private TimeConstraint readTeacherMaxHoursContinuously(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTeacherMaxHoursContinuously");
		ConstraintTeacherMaxHoursContinuously cn = new ConstraintTeacherMaxHoursContinuously();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Maximum_Hours_Continuously")
			{
				cn.maxHoursContinuously = elem4.text().toInt();
				xmlReadingLog += "    Read maxHoursContinuously=" + CustomFETString.number(cn.maxHoursContinuously) + "\n";
			}
			else if (elem4.tagName() == "Teacher_Name")
			{
				cn.teacherName = elem4.text();
				xmlReadingLog += "    Read teacher name=" + cn.teacherName + "\n";
			}
		}
		return cn;
	}
	private TimeConstraint readTeacherActivityTagMaxHoursContinuously(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTeacherActivityTagMaxHoursContinuously");
		ConstraintTeacherActivityTagMaxHoursContinuously cn = new ConstraintTeacherActivityTagMaxHoursContinuously();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Maximum_Hours_Continuously")
			{
				cn.maxHoursContinuously = elem4.text().toInt();
				xmlReadingLog += "    Read maxHoursContinuously=" + CustomFETString.number(cn.maxHoursContinuously) + "\n";
			}
			else if (elem4.tagName() == "Teacher_Name")
			{
				cn.teacherName = elem4.text();
				xmlReadingLog += "    Read teacher name=" + cn.teacherName + "\n";
			}
			else if (elem4.tagName() == "Activity_Tag_Name")
			{
				cn.activityTagName = elem4.text();
				xmlReadingLog += "    Read activity tag name=" + cn.activityTagName + "\n";
			}
		}
		return cn;
	}
	private TimeConstraint readTeachersActivityTagMaxHoursContinuously(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTeachersActivityTagMaxHoursContinuously");
		ConstraintTeachersActivityTagMaxHoursContinuously cn = new ConstraintTeachersActivityTagMaxHoursContinuously();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Maximum_Hours_Continuously")
			{
				cn.maxHoursContinuously = elem4.text().toInt();
				xmlReadingLog += "    Read maxHoursContinuously=" + CustomFETString.number(cn.maxHoursContinuously) + "\n";
			}
			else if (elem4.tagName() == "Activity_Tag_Name")
			{
				cn.activityTagName = elem4.text();
				xmlReadingLog += "    Read activity tag name=" + cn.activityTagName + "\n";
			}
		}
		return cn;
	}

	private TimeConstraint readTeacherActivityTagMaxHoursDaily(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTeacherActivityTagMaxHoursDaily");
		ConstraintTeacherActivityTagMaxHoursDaily cn = new ConstraintTeacherActivityTagMaxHoursDaily();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Maximum_Hours_Daily")
			{
				cn.maxHoursDaily = elem4.text().toInt();
				xmlReadingLog += "    Read maxHoursDaily=" + CustomFETString.number(cn.maxHoursDaily) + "\n";
			}
			else if (elem4.tagName() == "Teacher_Name")
			{
				cn.teacherName = elem4.text();
				xmlReadingLog += "    Read teacher name=" + cn.teacherName + "\n";
			}
			else if (elem4.tagName() == "Activity_Tag_Name")
			{
				cn.activityTagName = elem4.text();
				xmlReadingLog += "    Read activity tag name=" + cn.activityTagName + "\n";
			}
		}
		return cn;
	}
	private TimeConstraint readTeachersActivityTagMaxHoursDaily(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTeachersActivityTagMaxHoursDaily");
		ConstraintTeachersActivityTagMaxHoursDaily cn = new ConstraintTeachersActivityTagMaxHoursDaily();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Maximum_Hours_Daily")
			{
				cn.maxHoursDaily = elem4.text().toInt();
				xmlReadingLog += "    Read maxHoursDaily=" + CustomFETString.number(cn.maxHoursDaily) + "\n";
			}
			else if (elem4.tagName() == "Activity_Tag_Name")
			{
				cn.activityTagName = elem4.text();
				xmlReadingLog += "    Read activity tag name=" + cn.activityTagName + "\n";
			}
		}
		return cn;
	}

	private TimeConstraint readTeachersMinHoursDaily(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTeachersMinHoursDaily");
		ConstraintTeachersMinHoursDaily cn = new ConstraintTeachersMinHoursDaily();
		cn.allowEmptyDays = true;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Minimum_Hours_Daily")
			{
				cn.minHoursDaily = elem4.text().toInt();
				xmlReadingLog += "    Read minHoursDaily=" + CustomFETString.number(cn.minHoursDaily) + "\n";
			}
			else if (elem4.tagName() == "Allow_Empty_Days")
			{
				if (elem4.text() == "true" || elem4.text() == "1" || elem4.text() == "yes")
				{
					xmlReadingLog += "    Read allow empty days=true\n";
					cn.allowEmptyDays = true;
				}
				else
				{
					if (!(elem4.text() == "no" || elem4.text() == "false" || elem4.text() == "0"))
					{
						RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("Found constraint teachers min hours daily with tag allow empty days" + " which is not 'true', 'false', 'yes', 'no', '1' or '0'." + " The tag will be considered false", "Instructions for translators: please leave the 'true', 'false', 'yes' and 'no' fields untranslated, as they are in English"));
					}
					//assert(elem4.text()=="false" || elem4.text()=="0" || elem4.text()=="no");
					xmlReadingLog += "    Read allow empty days=false\n";
					cn.allowEmptyDays = false;
				}
			}
		}
		return cn;
	}
	private TimeConstraint readTeacherMinHoursDaily(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTeacherMinHoursDaily");
		ConstraintTeacherMinHoursDaily cn = new ConstraintTeacherMinHoursDaily();
		cn.allowEmptyDays = true;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Minimum_Hours_Daily")
			{
				cn.minHoursDaily = elem4.text().toInt();
				xmlReadingLog += "    Read minHoursDaily=" + CustomFETString.number(cn.minHoursDaily) + "\n";
			}
			else if (elem4.tagName() == "Teacher_Name")
			{
				cn.teacherName = elem4.text();
				xmlReadingLog += "    Read teacher name=" + cn.teacherName + "\n";
			}
			else if (elem4.tagName() == "Allow_Empty_Days")
			{
				if (elem4.text() == "true" || elem4.text() == "1" || elem4.text() == "yes")
				{
					xmlReadingLog += "    Read allow empty days=true\n";
					cn.allowEmptyDays = true;
				}
				else
				{
					if (!(elem4.text() == "no" || elem4.text() == "false" || elem4.text() == "0"))
					{
						RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("Found constraint teacher min hours daily with tag allow empty days" + " which is not 'true', 'false', 'yes', 'no', '1' or '0'." + " The tag will be considered false", "Instructions for translators: please leave the 'true', 'false', 'yes' and 'no' fields untranslated, as they are in English"));
					}
					//assert(elem4.text()=="false" || elem4.text()=="0" || elem4.text()=="no");
					xmlReadingLog += "    Read allow empty days=false\n";
					cn.allowEmptyDays = false;
				}
			}
		}
		return cn;
	}
	private TimeConstraint readStudentsMaxHoursDaily(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsMaxHoursDaily");
		ConstraintStudentsMaxHoursDaily cn = new ConstraintStudentsMaxHoursDaily();
		cn.maxHoursDaily = -1;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Maximum_Hours_Daily")
			{
				cn.maxHoursDaily = elem4.text().toInt();
				xmlReadingLog += "    Read maxHoursDaily=" + CustomFETString.number(cn.maxHoursDaily) + "\n";
			}
		}
		Debug.Assert(cn.maxHoursDaily >= 0);
		return cn;
	}
	private TimeConstraint readStudentsSetMaxHoursDaily(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsSetMaxHoursDaily");
		ConstraintStudentsSetMaxHoursDaily cn = new ConstraintStudentsSetMaxHoursDaily();
		cn.maxHoursDaily = -1;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Maximum_Hours_Daily")
			{
				cn.maxHoursDaily = elem4.text().toInt();
				xmlReadingLog += "    Read maxHoursDaily=" + CustomFETString.number(cn.maxHoursDaily) + "\n";
			}
			else if (elem4.tagName() == "Students")
			{
				cn.students = elem4.text();
				xmlReadingLog += "    Read students name=" + cn.students + "\n";
			}
		}
		Debug.Assert(cn.maxHoursDaily >= 0);
		return cn;
	}
	private TimeConstraint readStudentsMaxHoursContinuously(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsMaxHoursContinuously");
		ConstraintStudentsMaxHoursContinuously cn = new ConstraintStudentsMaxHoursContinuously();
		cn.maxHoursContinuously = -1;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Maximum_Hours_Continuously")
			{
				cn.maxHoursContinuously = elem4.text().toInt();
				xmlReadingLog += "    Read maxHoursContinuously=" + CustomFETString.number(cn.maxHoursContinuously) + "\n";
			}
		}
		Debug.Assert(cn.maxHoursContinuously >= 0);
		return cn;
	}
	private TimeConstraint readStudentsSetMaxHoursContinuously(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsSetMaxHoursContinuously");
		ConstraintStudentsSetMaxHoursContinuously cn = new ConstraintStudentsSetMaxHoursContinuously();
		cn.maxHoursContinuously = -1;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Maximum_Hours_Continuously")
			{
				cn.maxHoursContinuously = elem4.text().toInt();
				xmlReadingLog += "    Read maxHoursContinuously=" + CustomFETString.number(cn.maxHoursContinuously) + "\n";
			}
			else if (elem4.tagName() == "Students")
			{
				cn.students = elem4.text();
				xmlReadingLog += "    Read students name=" + cn.students + "\n";
			}
		}
		Debug.Assert(cn.maxHoursContinuously >= 0);
		return cn;
	}
	private TimeConstraint readStudentsSetActivityTagMaxHoursContinuously(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsSetActivityTagMaxHoursContinuously");
		ConstraintStudentsSetActivityTagMaxHoursContinuously cn = new ConstraintStudentsSetActivityTagMaxHoursContinuously();
		cn.maxHoursContinuously = -1;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Maximum_Hours_Continuously")
			{
				cn.maxHoursContinuously = elem4.text().toInt();
				xmlReadingLog += "    Read maxHoursContinuously=" + CustomFETString.number(cn.maxHoursContinuously) + "\n";
			}
			else if (elem4.tagName() == "Students")
			{
				cn.students = elem4.text();
				xmlReadingLog += "    Read students name=" + cn.students + "\n";
			}
			else if (elem4.tagName() == "Activity_Tag")
			{
				cn.activityTagName = elem4.text();
				xmlReadingLog += "    Read activity tag name=" + cn.activityTagName + "\n";
			}
		}
		Debug.Assert(cn.maxHoursContinuously >= 0);
		return cn;
	}
	private TimeConstraint readStudentsActivityTagMaxHoursContinuously(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsActivityTagMaxHoursContinuously");
		ConstraintStudentsActivityTagMaxHoursContinuously cn = new ConstraintStudentsActivityTagMaxHoursContinuously();
		cn.maxHoursContinuously = -1;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Maximum_Hours_Continuously")
			{
				cn.maxHoursContinuously = elem4.text().toInt();
				xmlReadingLog += "    Read maxHoursContinuously=" + CustomFETString.number(cn.maxHoursContinuously) + "\n";
			}
			else if (elem4.tagName() == "Activity_Tag")
			{
				cn.activityTagName = elem4.text();
				xmlReadingLog += "    Read activity tag name=" + cn.activityTagName + "\n";
			}
		}
		Debug.Assert(cn.maxHoursContinuously >= 0);
		return cn;
	}

	private TimeConstraint readStudentsSetActivityTagMaxHoursDaily(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsSetActivityTagMaxHoursDaily");
		ConstraintStudentsSetActivityTagMaxHoursDaily cn = new ConstraintStudentsSetActivityTagMaxHoursDaily();
		cn.maxHoursDaily = -1;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Maximum_Hours_Daily")
			{
				cn.maxHoursDaily = elem4.text().toInt();
				xmlReadingLog += "    Read maxHoursDaily=" + CustomFETString.number(cn.maxHoursDaily) + "\n";
			}
			else if (elem4.tagName() == "Students")
			{
				cn.students = elem4.text();
				xmlReadingLog += "    Read students name=" + cn.students + "\n";
			}
			else if (elem4.tagName() == "Activity_Tag")
			{
				cn.activityTagName = elem4.text();
				xmlReadingLog += "    Read activity tag name=" + cn.activityTagName + "\n";
			}
		}
		Debug.Assert(cn.maxHoursDaily >= 0);
		return cn;
	}
	private TimeConstraint readStudentsActivityTagMaxHoursDaily(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsActivityTagMaxHoursDaily");
		ConstraintStudentsActivityTagMaxHoursDaily cn = new ConstraintStudentsActivityTagMaxHoursDaily();
		cn.maxHoursDaily = -1;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Maximum_Hours_Daily")
			{
				cn.maxHoursDaily = elem4.text().toInt();
				xmlReadingLog += "    Read maxHoursDaily=" + CustomFETString.number(cn.maxHoursDaily) + "\n";
			}
			else if (elem4.tagName() == "Activity_Tag")
			{
				cn.activityTagName = elem4.text();
				xmlReadingLog += "    Read activity tag name=" + cn.activityTagName + "\n";
			}
		}
		Debug.Assert(cn.maxHoursDaily >= 0);
		return cn;
	}

	private TimeConstraint readStudentsMinHoursDaily(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsMinHoursDaily");
		ConstraintStudentsMinHoursDaily cn = new ConstraintStudentsMinHoursDaily();
		cn.minHoursDaily = -1;
		cn.allowEmptyDays = false;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Minimum_Hours_Daily")
			{
				cn.minHoursDaily = elem4.text().toInt();
				xmlReadingLog += "    Read minHoursDaily=" + CustomFETString.number(cn.minHoursDaily) + "\n";
			}
			else if (elem4.tagName() == "Allow_Empty_Days")
			{
				if (elem4.text() == "true" || elem4.text() == "1" || elem4.text() == "yes")
				{
					xmlReadingLog += "    Read allow empty days=true\n";
					cn.allowEmptyDays = true;
				}
				else
				{
					if (!(elem4.text() == "no" || elem4.text() == "false" || elem4.text() == "0"))
					{
						RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("Found constraint students min hours daily with tag allow empty days" + " which is not 'true', 'false', 'yes', 'no', '1' or '0'." + " The tag will be considered false", "Instructions for translators: please leave the 'true', 'false', 'yes' and 'no' fields untranslated, as they are in English"));
					}
					//assert(elem4.text()=="false" || elem4.text()=="0" || elem4.text()=="no");
					xmlReadingLog += "    Read allow empty days=false\n";
					cn.allowEmptyDays = false;
				}
			}
		}
		Debug.Assert(cn.minHoursDaily >= 0);
		return cn;
	}
	private TimeConstraint readStudentsSetMinHoursDaily(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsSetMinHoursDaily");
		ConstraintStudentsSetMinHoursDaily cn = new ConstraintStudentsSetMinHoursDaily();
		cn.minHoursDaily = -1;
		cn.allowEmptyDays = false;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Minimum_Hours_Daily")
			{
				cn.minHoursDaily = elem4.text().toInt();
				xmlReadingLog += "    Read minHoursDaily=" + CustomFETString.number(cn.minHoursDaily) + "\n";
			}
			else if (elem4.tagName() == "Students")
			{
				cn.students = elem4.text();
				xmlReadingLog += "    Read students name=" + cn.students + "\n";
			}
			else if (elem4.tagName() == "Allow_Empty_Days")
			{
				if (elem4.text() == "true" || elem4.text() == "1" || elem4.text() == "yes")
				{
					xmlReadingLog += "    Read allow empty days=true\n";
					cn.allowEmptyDays = true;
				}
				else
				{
					if (!(elem4.text() == "no" || elem4.text() == "false" || elem4.text() == "0"))
					{
						RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("Found constraint students set min hours daily with tag allow empty days" + " which is not 'true', 'false', 'yes', 'no', '1' or '0'." + " The tag will be considered false", "Instructions for translators: please leave the 'true', 'false', 'yes' and 'no' fields untranslated, as they are in English"));
					}
					//assert(elem4.text()=="false" || elem4.text()=="0" || elem4.text()=="no");
					xmlReadingLog += "    Read allow empty days=false\n";
					cn.allowEmptyDays = false;
				}
			}
		}
		Debug.Assert(cn.minHoursDaily >= 0);
		return cn;
	}

	private TimeConstraint readActivityPreferredTime(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog, ref bool reportUnspecifiedPermanentlyLockedTime, ref bool reportUnspecifiedDayOrHourPreferredStartingTime)
	{
		Debug.Assert(elem3.tagName() == "ConstraintActivityPreferredTime");

		ConstraintActivityPreferredStartingTime cn = new ConstraintActivityPreferredStartingTime();
		cn.day = cn.hour = -1;
		cn.permanentlyLocked = false; //default not locked
		bool foundLocked = false;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Permanently_Locked")
			{
				if (elem4.text() == "true" || elem4.text() == "1" || elem4.text() == "yes")
				{
					xmlReadingLog += "    Permanently locked\n";
					cn.permanentlyLocked = true;
				}
				else
				{
					if (!(elem4.text() == "no" || elem4.text() == "false" || elem4.text() == "0"))
					{
						RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("Found constraint activity preferred starting time with tag permanently locked" + " which is not 'true', 'false', 'yes', 'no', '1' or '0'." + " The tag will be considered false", "Instructions for translators: please leave the 'true', 'false', 'yes' and 'no' fields untranslated, as they are in English"));
					}
					//assert(elem4.text()=="false" || elem4.text()=="0" || elem4.text()=="no");
					xmlReadingLog += "    Not permanently locked\n";
					cn.permanentlyLocked = false;
				}
				foundLocked = true;
			}
			else if (elem4.tagName() == "Activity_Id")
			{
				cn.activityId = elem4.text().toInt();
				xmlReadingLog += "    Read activity id=" + CustomFETString.number(cn.activityId) + "\n";
			}
			else if (elem4.tagName() == "Preferred_Day")
			{
				for (cn.day = 0; cn.day < this.nDaysPerWeek; cn.day++)
					if (this.daysOfTheWeek[cn.day] == elem4.text())
						break;
				if (cn.day >= this.nDaysPerWeek)
				{
					RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint ActivityPreferredTime day corrupt for activity with id %1, day %2 is inexistent ... ignoring constraint").arg(cn.activityId).arg(elem4.text()));
					if (cn != null)
						cn.Dispose();
					cn = null;
					//goto corruptConstraintTime;
					return null;
				}
				Debug.Assert(cn.day < this.nDaysPerWeek);
				xmlReadingLog += "    Preferred day=" + this.daysOfTheWeek[cn.day] + "\n";
			}
			else if (elem4.tagName() == "Preferred_Hour")
			{
				for (cn.hour = 0; cn.hour < this.nHoursPerDay; cn.hour++)
					if (this.hoursOfTheDay[cn.hour] == elem4.text())
						break;
				if (cn.hour >= this.nHoursPerDay)
				{
					RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint ActivityPreferredTime hour corrupt for activity with id %1, hour %2 is inexistent ... ignoring constraint").arg(cn.activityId).arg(elem4.text()));
					if (cn != null)
						cn.Dispose();
					cn = null;
					//goto corruptConstraintTime;
					return null;
				}
				Debug.Assert(cn.hour >= 0 && cn.hour < this.nHoursPerDay);
				xmlReadingLog += "    Preferred hour=" + this.hoursOfTheDay[cn.hour] + "\n";
			}
		}
		//crt_constraint=cn;

		if (cn.hour >= 0 && cn.day >= 0 && !foundLocked && reportUnspecifiedPermanentlyLockedTime)
		{
			int t = RulesReconcilableMessage.information(parent, tr("FET information"), tr("Found constraint activity preferred starting time, with unspecified tag" + " 'permanently locked' - this tag will be set to 'false' by default. You can always modify it" + " by editing the constraint in the 'Data' menu") + "\n\n" + tr("Explanation: starting with version 5.8.0 (January 2009), the constraint" + " activity preferred starting time has" + " a new tag, 'permanently locked' (true or false)." + " It is recommended to make the tag 'permanently locked' true for the constraints you" + " need to be not modifiable from the 'Timetable' menu" + " and leave this tag false for the constraints you need to be modifiable from the 'Timetable' menu" + " (the 'permanently locked' tag can be modified by editing the constraint from the 'Data' menu)." + " This way, when viewing the timetable" + " and locking/unlocking some activities, you will not unlock the constraints which" + " need to be locked all the time."), tr("Skip rest"), tr("See next"), new QString(), 1, 0);
			if (t == 0)
				reportUnspecifiedPermanentlyLockedTime = false;
		}

		if (cn.hour == -1 || cn.day == -1)
		{
			if (reportUnspecifiedDayOrHourPreferredStartingTime)
			{
				int t = RulesReconcilableMessage.information(parent, tr("FET information"), tr("Found constraint activity preferred starting time, with unspecified day or hour." + " This constraint will be transformed into constraint activity preferred starting times (a set of times, not only one)." + " This change is done in FET versions 5.8.1 and higher."), tr("Skip rest"), tr("See next"), new QString(), 1, 0);
				if (t == 0)
					reportUnspecifiedDayOrHourPreferredStartingTime = false;
			}

			ConstraintActivityPreferredStartingTimes cgood = new ConstraintActivityPreferredStartingTimes();
			if (cn.day == -1)
			{
				cgood.activityId = cn.activityId;
				cgood.weightPercentage = cn.weightPercentage;
				cgood.nPreferredStartingTimes_L = this.nDaysPerWeek;
				for (int i = 0; i < cgood.nPreferredStartingTimes_L; i++)
				{
					/*cgood->days[i]=i;
					cgood->hours[i]=cn->hour;*/
					cgood.days_L.append(i);
					cgood.hours_L.append(cn.hour);
				}
			}
			else
			{
				Debug.Assert(cn.hour == -1);
				cgood.activityId = cn.activityId;
				cgood.weightPercentage = cn.weightPercentage;
				cgood.nPreferredStartingTimes_L = this.nHoursPerDay;
				for (int i = 0; i < cgood.nPreferredStartingTimes_L; i++)
				{
					/*cgood->days[i]=cn->day;
					cgood->hours[i]=i;*/
					cgood.days_L.append(cn.day);
					cgood.hours_L.append(i);
				}
			}

			if (cn != null)
				cn.Dispose();
			return cgood;
		}

		return cn;
	}
	private TimeConstraint readActivityPreferredStartingTime(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog, ref bool reportUnspecifiedPermanentlyLockedTime, ref bool reportUnspecifiedDayOrHourPreferredStartingTime)
	{
		Debug.Assert(elem3.tagName() == "ConstraintActivityPreferredStartingTime");
		ConstraintActivityPreferredStartingTime cn = new ConstraintActivityPreferredStartingTime();
		cn.day = cn.hour = -1;
		cn.permanentlyLocked = false; //default false
		bool foundLocked = false;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Permanently_Locked")
			{
				if (elem4.text() == "true" || elem4.text() == "1" || elem4.text() == "yes")
				{
					xmlReadingLog += "    Permanently locked\n";
					cn.permanentlyLocked = true;
				}
				else
				{
					if (!(elem4.text() == "no" || elem4.text() == "false" || elem4.text() == "0"))
					{
						RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("Found constraint activity preferred starting time with tag permanently locked" + " which is not 'true', 'false', 'yes', 'no', '1' or '0'." + " The tag will be considered false", "Instructions for translators: please leave the 'true', 'false', 'yes' and 'no' fields untranslated, as they are in English"));
					}
					//assert(elem4.text()=="false" || elem4.text()=="0" || elem4.text()=="no");
					xmlReadingLog += "    Not permanently locked\n";
					cn.permanentlyLocked = false;
				}
				foundLocked = true;
			}
			else if (elem4.tagName() == "Activity_Id")
			{
				cn.activityId = elem4.text().toInt();
				xmlReadingLog += "    Read activity id=" + CustomFETString.number(cn.activityId) + "\n";
			}
			else if (elem4.tagName() == "Preferred_Day")
			{
				for (cn.day = 0; cn.day < this.nDaysPerWeek; cn.day++)
					if (this.daysOfTheWeek[cn.day] == elem4.text())
						break;
				if (cn.day >= this.nDaysPerWeek)
				{
					RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint ActivityPreferredStartingTime day corrupt for activity with id %1, day %2 is inexistent ... ignoring constraint").arg(cn.activityId).arg(elem4.text()));
					if (cn != null)
						cn.Dispose();
					cn = null;
					//goto corruptConstraintTime;
					return null;
				}
				Debug.Assert(cn.day < this.nDaysPerWeek);
				xmlReadingLog += "    Preferred day=" + this.daysOfTheWeek[cn.day] + "\n";
			}
			else if (elem4.tagName() == "Preferred_Hour")
			{
				for (cn.hour = 0; cn.hour < this.nHoursPerDay; cn.hour++)
					if (this.hoursOfTheDay[cn.hour] == elem4.text())
						break;
				if (cn.hour >= this.nHoursPerDay)
				{
					RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint ActivityPreferredStartingTime hour corrupt for activity with id %1, hour %2 is inexistent ... ignoring constraint").arg(cn.activityId).arg(elem4.text()));
					if (cn != null)
						cn.Dispose();
					cn = null;
					//goto corruptConstraintTime;
					return null;
				}
				Debug.Assert(cn.hour >= 0 && cn.hour < this.nHoursPerDay);
				xmlReadingLog += "    Preferred hour=" + this.hoursOfTheDay[cn.hour] + "\n";
			}
		}
		//crt_constraint=cn;

		if (cn.hour >= 0 && cn.day >= 0 && !foundLocked && reportUnspecifiedPermanentlyLockedTime)
		{
			int t = RulesReconcilableMessage.information(parent, tr("FET information"), tr("Found constraint activity preferred starting time, with unspecified tag" + " 'permanently locked' - this tag will be set to 'false' by default. You can always modify it" + " by editing the constraint in the 'Data' menu") + "\n\n" + tr("Explanation: starting with version 5.8.0 (January 2009), the constraint" + " activity preferred starting time has" + " a new tag, 'permanently locked' (true or false)." + " It is recommended to make the tag 'permanently locked' true for the constraints you" + " need to be not modifiable from the 'Timetable' menu" + " and leave this tag false for the constraints you need to be modifiable from the 'Timetable' menu" + " (the 'permanently locked' tag can be modified by editing the constraint from the 'Data' menu)." + " This way, when viewing the timetable" + " and locking/unlocking some activities, you will not unlock the constraints which" + " need to be locked all the time."), tr("Skip rest"), tr("See next"), new QString(), 1, 0);
			if (t == 0)
				reportUnspecifiedPermanentlyLockedTime = false;
		}

		if (cn.hour == -1 || cn.day == -1)
		{
			if (reportUnspecifiedDayOrHourPreferredStartingTime)
			{
				int t = RulesReconcilableMessage.information(parent, tr("FET information"), tr("Found constraint activity preferred starting time, with unspecified day or hour." + " This constraint will be transformed into constraint activity preferred starting times (a set of times, not only one)." + " This change is done in FET versions 5.8.1 and higher."), tr("Skip rest"), tr("See next"), new QString(), 1, 0);
				if (t == 0)
					reportUnspecifiedDayOrHourPreferredStartingTime = false;
			}

			ConstraintActivityPreferredStartingTimes cgood = new ConstraintActivityPreferredStartingTimes();
			if (cn.day == -1)
			{
				cgood.activityId = cn.activityId;
				cgood.weightPercentage = cn.weightPercentage;
				cgood.nPreferredStartingTimes_L = this.nDaysPerWeek;
				for (int i = 0; i < cgood.nPreferredStartingTimes_L; i++)
				{
					/*cgood->days[i]=i;
					cgood->hours[i]=cn->hour;*/
					cgood.days_L.append(i);
					cgood.hours_L.append(cn.hour);
				}
			}
			else
			{
				Debug.Assert(cn.hour == -1);
				cgood.activityId = cn.activityId;
				cgood.weightPercentage = cn.weightPercentage;
				cgood.nPreferredStartingTimes_L = this.nHoursPerDay;
				for (int i = 0; i < cgood.nPreferredStartingTimes_L; i++)
				{
					/*cgood->days[i]=cn->day;
					cgood->hours[i]=i;*/
					cgood.days_L.append(cn.day);
					cgood.hours_L.append(i);
				}
			}

			if (cn != null)
				cn.Dispose();
			return cgood;
		}

		return cn;
	}

	private TimeConstraint readActivityEndsStudentsDay(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintActivityEndsStudentsDay");
		ConstraintActivityEndsStudentsDay cn = new ConstraintActivityEndsStudentsDay();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Activity_Id")
			{
				cn.activityId = elem4.text().toInt();
				xmlReadingLog += "    Read activity id=" + CustomFETString.number(cn.activityId) + "\n";
			}
		}
		return cn;
	}
	private TimeConstraint readActivitiesEndStudentsDay(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintActivitiesEndStudentsDay");
		ConstraintActivitiesEndStudentsDay cn = new ConstraintActivitiesEndStudentsDay();
		cn.teacherName = "";
		cn.studentsName = "";
		cn.subjectName = "";
		cn.activityTagName = "";

		//i=0;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Teacher_Name")
			{
				cn.teacherName = elem4.text();
				xmlReadingLog += "    Read teacher name=" + cn.teacherName + "\n";
			}
			else if (elem4.tagName() == "Students_Name")
			{
				cn.studentsName = elem4.text();
				xmlReadingLog += "    Read students name=" + cn.studentsName + "\n";
			}
			else if (elem4.tagName() == "Subject_Name")
			{
				cn.subjectName = elem4.text();
				xmlReadingLog += "    Read subject name=" + cn.subjectName + "\n";
			}
			else if (elem4.tagName() == "Subject_Tag_Name")
			{
				cn.activityTagName = elem4.text();
				xmlReadingLog += "    Read activity tag name=" + cn.activityTagName + "\n";
			}
			else if (elem4.tagName() == "Activity_Tag_Name")
			{
				cn.activityTagName = elem4.text();
				xmlReadingLog += "    Read activity tag name=" + cn.activityTagName + "\n";
			}
		}
		return cn;
	}

	/*old, with 2 and 3*/
	private TimeConstraint read2ActivitiesConsecutive(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "Constraint2ActivitiesConsecutive");
		ConstraintTwoActivitiesConsecutive cn = new ConstraintTwoActivitiesConsecutive();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "First_Activity_Id")
			{
				cn.firstActivityId = elem4.text().toInt();
				xmlReadingLog += "    Read first activity id=" + CustomFETString.number(cn.firstActivityId) + "\n";
			}
			else if (elem4.tagName() == "Second_Activity_Id")
			{
				cn.secondActivityId = elem4.text().toInt();
				xmlReadingLog += "    Read second activity id=" + CustomFETString.number(cn.secondActivityId) + "\n";
			}
		}
		return cn;
	}
	private TimeConstraint read2ActivitiesGrouped(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "Constraint2ActivitiesGrouped");
		ConstraintTwoActivitiesGrouped cn = new ConstraintTwoActivitiesGrouped();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "First_Activity_Id")
			{
				cn.firstActivityId = elem4.text().toInt();
				xmlReadingLog += "    Read first activity id=" + CustomFETString.number(cn.firstActivityId) + "\n";
			}
			else if (elem4.tagName() == "Second_Activity_Id")
			{
				cn.secondActivityId = elem4.text().toInt();
				xmlReadingLog += "    Read second activity id=" + CustomFETString.number(cn.secondActivityId) + "\n";
			}
		}
		return cn;
	}
	private TimeConstraint read3ActivitiesGrouped(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "Constraint3ActivitiesGrouped");
		ConstraintThreeActivitiesGrouped cn = new ConstraintThreeActivitiesGrouped();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "First_Activity_Id")
			{
				cn.firstActivityId = elem4.text().toInt();
				xmlReadingLog += "    Read first activity id=" + CustomFETString.number(cn.firstActivityId) + "\n";
			}
			else if (elem4.tagName() == "Second_Activity_Id")
			{
				cn.secondActivityId = elem4.text().toInt();
				xmlReadingLog += "    Read second activity id=" + CustomFETString.number(cn.secondActivityId) + "\n";
			}
			else if (elem4.tagName() == "Third_Activity_Id")
			{
				cn.thirdActivityId = elem4.text().toInt();
				xmlReadingLog += "    Read third activity id=" + CustomFETString.number(cn.thirdActivityId) + "\n";
			}
		}
		return cn;
	}
	private TimeConstraint read2ActivitiesOrdered(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "Constraint2ActivitiesOrdered");
		ConstraintTwoActivitiesOrdered cn = new ConstraintTwoActivitiesOrdered();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "First_Activity_Id")
			{
				cn.firstActivityId = elem4.text().toInt();
				xmlReadingLog += "    Read first activity id=" + CustomFETString.number(cn.firstActivityId) + "\n";
			}
			else if (elem4.tagName() == "Second_Activity_Id")
			{
				cn.secondActivityId = elem4.text().toInt();
				xmlReadingLog += "    Read second activity id=" + CustomFETString.number(cn.secondActivityId) + "\n";
			}
		}
		return cn;
	}
	/*end old*/

	private TimeConstraint readTwoActivitiesConsecutive(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTwoActivitiesConsecutive");
		ConstraintTwoActivitiesConsecutive cn = new ConstraintTwoActivitiesConsecutive();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "First_Activity_Id")
			{
				cn.firstActivityId = elem4.text().toInt();
				xmlReadingLog += "    Read first activity id=" + CustomFETString.number(cn.firstActivityId) + "\n";
			}
			else if (elem4.tagName() == "Second_Activity_Id")
			{
				cn.secondActivityId = elem4.text().toInt();
				xmlReadingLog += "    Read second activity id=" + CustomFETString.number(cn.secondActivityId) + "\n";
			}
		}
		return cn;
	}
	private TimeConstraint readTwoActivitiesGrouped(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTwoActivitiesGrouped");
		ConstraintTwoActivitiesGrouped cn = new ConstraintTwoActivitiesGrouped();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "First_Activity_Id")
			{
				cn.firstActivityId = elem4.text().toInt();
				xmlReadingLog += "    Read first activity id=" + CustomFETString.number(cn.firstActivityId) + "\n";
			}
			else if (elem4.tagName() == "Second_Activity_Id")
			{
				cn.secondActivityId = elem4.text().toInt();
				xmlReadingLog += "    Read second activity id=" + CustomFETString.number(cn.secondActivityId) + "\n";
			}
		}
		return cn;
	}
	private TimeConstraint readThreeActivitiesGrouped(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintThreeActivitiesGrouped");
		ConstraintThreeActivitiesGrouped cn = new ConstraintThreeActivitiesGrouped();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "First_Activity_Id")
			{
				cn.firstActivityId = elem4.text().toInt();
				xmlReadingLog += "    Read first activity id=" + CustomFETString.number(cn.firstActivityId) + "\n";
			}
			else if (elem4.tagName() == "Second_Activity_Id")
			{
				cn.secondActivityId = elem4.text().toInt();
				xmlReadingLog += "    Read second activity id=" + CustomFETString.number(cn.secondActivityId) + "\n";
			}
			else if (elem4.tagName() == "Third_Activity_Id")
			{
				cn.thirdActivityId = elem4.text().toInt();
				xmlReadingLog += "    Read third activity id=" + CustomFETString.number(cn.thirdActivityId) + "\n";
			}
		}
		return cn;
	}
	private TimeConstraint readTwoActivitiesOrdered(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTwoActivitiesOrdered");
		ConstraintTwoActivitiesOrdered cn = new ConstraintTwoActivitiesOrdered();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "First_Activity_Id")
			{
				cn.firstActivityId = elem4.text().toInt();
				xmlReadingLog += "    Read first activity id=" + CustomFETString.number(cn.firstActivityId) + "\n";
			}
			else if (elem4.tagName() == "Second_Activity_Id")
			{
				cn.secondActivityId = elem4.text().toInt();
				xmlReadingLog += "    Read second activity id=" + CustomFETString.number(cn.secondActivityId) + "\n";
			}
		}
		return cn;
	}

	private TimeConstraint readActivityPreferredTimes(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintActivityPreferredTimes");

		ConstraintActivityPreferredStartingTimes cn = new ConstraintActivityPreferredStartingTimes();
		cn.nPreferredStartingTimes_L = 0;
		int i;
		/*for(i=0; i<MAX_N_CONSTRAINT_ACTIVITY_PREFERRED_STARTING_TIMES; i++){
			cn->days[i] = cn->hours[i] = -1;
		}*/
		i = 0;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Activity_Id")
			{
				cn.activityId = elem4.text().toInt();
				xmlReadingLog += "    Read activity id=" + CustomFETString.number(cn.activityId) + "\n";
			}
			else if (elem4.tagName() == "Number_of_Preferred_Times")
			{
				cn.nPreferredStartingTimes_L = elem4.text().toInt();
				xmlReadingLog += "    Read number of preferred times=" + CustomFETString.number(cn.nPreferredStartingTimes_L) + "\n";
			}
			else if (elem4.tagName() == "Preferred_Time")
			{
				xmlReadingLog += "    Read: preferred time\n";

				for (QDomNode node5 = elem4.firstChild(); !node5.isNull(); node5 = node5.nextSibling())
				{
					QDomElement elem5 = node5.toElement();
					if (elem5.isNull())
					{
						xmlReadingLog += "    Null node here\n";
						continue;
					}
					xmlReadingLog += "    Found " + elem5.tagName() + " tag\n";
					if (elem5.tagName() == "Preferred_Day")
					{
						cn.days_L.append(0);
						Debug.Assert(cn.days_L.count() - 1 == i);
						for (cn.days_L[i] = 0; cn.days_L[i] < this.nDaysPerWeek; cn.days_L[i]++)
							if (this.daysOfTheWeek[cn.days_L[i]] == elem5.text())
								break;

						if (cn.days_L[i] >= this.nDaysPerWeek)
						{
							RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint ActivityPreferredTimes day corrupt for activity with id %1, day %2 is inexistent ... ignoring constraint").arg(cn.activityId).arg(elem5.text()));
							if (cn != null)
								cn.Dispose();
							cn = null;
							//goto corruptConstraintTime;
							return null;
						}

						Debug.Assert(cn.days_L[i] < this.nDaysPerWeek);
						xmlReadingLog += "    Preferred day=" + this.daysOfTheWeek[cn.days_L[i]] + "(" + CustomFETString.number(i) + ")" + "\n";
					}
					else if (elem5.tagName() == "Preferred_Hour")
					{
						cn.hours_L.append(0);
						Debug.Assert(cn.hours_L.count() - 1 == i);
						for (cn.hours_L[i] = 0; cn.hours_L[i] < this.nHoursPerDay; cn.hours_L[i]++)
							if (this.hoursOfTheDay[cn.hours_L[i]] == elem5.text())
								break;

						if (cn.hours_L[i] >= this.nHoursPerDay)
						{
							RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint ActivityPreferredTimes hour corrupt for activity with id %1, hour %2 is inexistent ... ignoring constraint").arg(cn.activityId).arg(elem5.text()));
							if (cn != null)
								cn.Dispose();
							cn = null;
							//goto corruptConstraintTime;
							return null;
						}

						Debug.Assert(cn.hours_L[i] >= 0 && cn.hours_L[i] < this.nHoursPerDay);
						xmlReadingLog += "    Preferred hour=" + this.hoursOfTheDay[cn.hours_L[i]] + "\n";
					}
				}

				i++;
			}
		}
		Debug.Assert(i == cn.nPreferredStartingTimes_L);
		return cn;
	}
	private TimeConstraint readActivityPreferredTimeSlots(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintActivityPreferredTimeSlots");
		ConstraintActivityPreferredTimeSlots cn = new ConstraintActivityPreferredTimeSlots();
		cn.p_nPreferredTimeSlots_L = 0;
		int i;
		/*for(i=0; i<MAX_N_CONSTRAINT_ACTIVITY_PREFERRED_TIME_SLOTS; i++){
			cn->p_days[i] = cn->p_hours[i] = -1;
		}*/
		i = 0;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Activity_Id")
			{
				cn.p_activityId = elem4.text().toInt();
				xmlReadingLog += "    Read activity id=" + CustomFETString.number(cn.p_activityId) + "\n";
			}
			else if (elem4.tagName() == "Number_of_Preferred_Time_Slots")
			{
				cn.p_nPreferredTimeSlots_L = elem4.text().toInt();
				xmlReadingLog += "    Read number of preferred times=" + CustomFETString.number(cn.p_nPreferredTimeSlots_L) + "\n";
			}
			else if (elem4.tagName() == "Preferred_Time_Slot")
			{
				xmlReadingLog += "    Read: preferred time slot\n";

				for (QDomNode node5 = elem4.firstChild(); !node5.isNull(); node5 = node5.nextSibling())
				{
					QDomElement elem5 = node5.toElement();
					if (elem5.isNull())
					{
						xmlReadingLog += "    Null node here\n";
						continue;
					}
					xmlReadingLog += "    Found " + elem5.tagName() + " tag\n";
					if (elem5.tagName() == "Preferred_Day")
					{
						cn.p_days_L.append(0);
						Debug.Assert(cn.p_days_L.count() - 1 == i);
						for (cn.p_days_L[i] = 0; cn.p_days_L[i] < this.nDaysPerWeek; cn.p_days_L[i]++)
							if (this.daysOfTheWeek[cn.p_days_L[i]] == elem5.text())
								break;

						if (cn.p_days_L[i] >= this.nDaysPerWeek)
						{
							RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint ActivityPreferredTimeSlots day corrupt for activity with id %1, day %2 is inexistent ... ignoring constraint").arg(cn.p_activityId).arg(elem5.text()));
							if (cn != null)
								cn.Dispose();
							cn = null;
							//goto corruptConstraintTime;
							return null;
						}

						Debug.Assert(cn.p_days_L[i] < this.nDaysPerWeek);
						xmlReadingLog += "    Preferred day=" + this.daysOfTheWeek[cn.p_days_L[i]] + "(" + CustomFETString.number(i) + ")" + "\n";
					}
					else if (elem5.tagName() == "Preferred_Hour")
					{
						cn.p_hours_L.append(0);
						Debug.Assert(cn.p_hours_L.count() - 1 == i);
						for (cn.p_hours_L[i] = 0; cn.p_hours_L[i] < this.nHoursPerDay; cn.p_hours_L[i]++)
							if (this.hoursOfTheDay[cn.p_hours_L[i]] == elem5.text())
								break;

						if (cn.p_hours_L[i] >= this.nHoursPerDay)
						{
							RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint ActivityPreferredTimeSlots hour corrupt for activity with id %1, hour %2 is inexistent ... ignoring constraint").arg(cn.p_activityId).arg(elem5.text()));
							if (cn != null)
								cn.Dispose();
							cn = null;
							//goto corruptConstraintTime;
							return null;
						}

						Debug.Assert(cn.p_hours_L[i] >= 0 && cn.p_hours_L[i] < this.nHoursPerDay);
						xmlReadingLog += "    Preferred hour=" + this.hoursOfTheDay[cn.p_hours_L[i]] + "\n";
					}
				}

				i++;
			}
		}
		Debug.Assert(i == cn.p_nPreferredTimeSlots_L);
		return cn;
	}
	private TimeConstraint readActivityPreferredStartingTimes(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintActivityPreferredStartingTimes");
		ConstraintActivityPreferredStartingTimes cn = new ConstraintActivityPreferredStartingTimes();
		cn.nPreferredStartingTimes_L = 0;
		int i;
		/*for(i=0; i<MAX_N_CONSTRAINT_ACTIVITY_PREFERRED_STARTING_TIMES; i++){
			cn->days[i] = cn->hours[i] = -1;
		}*/
		i = 0;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Activity_Id")
			{
				cn.activityId = elem4.text().toInt();
				xmlReadingLog += "    Read activity id=" + CustomFETString.number(cn.activityId) + "\n";
			}
			else if (elem4.tagName() == "Number_of_Preferred_Starting_Times")
			{
				cn.nPreferredStartingTimes_L = elem4.text().toInt();
				xmlReadingLog += "    Read number of preferred starting times=" + CustomFETString.number(cn.nPreferredStartingTimes_L) + "\n";
			}
			else if (elem4.tagName() == "Preferred_Starting_Time")
			{
				xmlReadingLog += "    Read: preferred starting time\n";

				for (QDomNode node5 = elem4.firstChild(); !node5.isNull(); node5 = node5.nextSibling())
				{
					QDomElement elem5 = node5.toElement();
					if (elem5.isNull())
					{
						xmlReadingLog += "    Null node here\n";
						continue;
					}
					xmlReadingLog += "    Found " + elem5.tagName() + " tag\n";
					if (elem5.tagName() == "Preferred_Starting_Day")
					{
						cn.days_L.append(0);
						Debug.Assert(cn.days_L.count() - 1 == i);
						for (cn.days_L[i] = 0; cn.days_L[i] < this.nDaysPerWeek; cn.days_L[i]++)
							if (this.daysOfTheWeek[cn.days_L[i]] == elem5.text())
								break;

						if (cn.days_L[i] >= this.nDaysPerWeek)
						{
							RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint ActivityPreferredStartingTimes day corrupt for activity with id %1, day %2 is inexistent ... ignoring constraint").arg(cn.activityId).arg(elem5.text()));
							if (cn != null)
								cn.Dispose();
							cn = null;
							//goto corruptConstraintTime;
							return null;
						}

						Debug.Assert(cn.days_L[i] < this.nDaysPerWeek);
						xmlReadingLog += "    Preferred starting day=" + this.daysOfTheWeek[cn.days_L[i]] + "(" + CustomFETString.number(i) + ")" + "\n";
					}
					else if (elem5.tagName() == "Preferred_Starting_Hour")
					{
						cn.hours_L.append(0);
						Debug.Assert(cn.hours_L.count() - 1 == i);
						for (cn.hours_L[i] = 0; cn.hours_L[i] < this.nHoursPerDay; cn.hours_L[i]++)
							if (this.hoursOfTheDay[cn.hours_L[i]] == elem5.text())
								break;

						if (cn.hours_L[i] >= this.nHoursPerDay)
						{
							RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint ActivityPreferredStartingTimes hour corrupt for activity with id %1, hour %2 is inexistent ... ignoring constraint").arg(cn.activityId).arg(elem5.text()));
							if (cn != null)
								cn.Dispose();
							cn = null;
							//goto corruptConstraintTime;
							return null;
						}

						Debug.Assert(cn.hours_L[i] >= 0 && cn.hours_L[i] < this.nHoursPerDay);
						xmlReadingLog += "    Preferred starting hour=" + this.hoursOfTheDay[cn.hours_L[i]] + "\n";
					}
				}

				i++;
			}
		}
		Debug.Assert(i == cn.nPreferredStartingTimes_L);
		return cn;
	}

	private TimeConstraint readBreak(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintBreak");

		QList<int> days = new QList<int>();
		QList<int> hours = new QList<int>();
		double weightPercentage = 100;
		int d = -1;
		int h1 = -1;
		int h2 = -1;
		bool active = true;
		QString comments = new QString("");
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Read weight percentage=" + CustomFETString.number(weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				comments = elem4.text();
			}
			else if (elem4.tagName() == "Day")
			{
				for (d = 0; d < this.nDaysPerWeek; d++)
					if (this.daysOfTheWeek[d] == elem4.text())
						break;
				if (d >= this.nDaysPerWeek)
				{
					RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint Break day corrupt for day %1 is inexistent ... ignoring constraint").arg(elem4.text()));
					//cn=NULL;
					//goto corruptConstraintTime;
					return null;
				}
				Debug.Assert(d < this.nDaysPerWeek);
				xmlReadingLog += "    Crt. day=" + this.daysOfTheWeek[d] + "\n";
			}
			else if (elem4.tagName() == "Start_Hour")
			{
				for (h1 = 0; h1 < this.nHoursPerDay; h1++)
					if (this.hoursOfTheDay[h1] == elem4.text())
						break;
				if (h1 >= this.nHoursPerDay)
				{
					RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint Break start hour corrupt for hour %1 is inexistent ... ignoring constraint").arg(elem4.text()));
					//cn=NULL;
					//goto corruptConstraintTime;
					return null;
				}
				Debug.Assert(h1 >= 0 && h1 < this.nHoursPerDay);
				xmlReadingLog += "    Start hour=" + this.hoursOfTheDay[h1] + "\n";
			}
			else if (elem4.tagName() == "End_Hour")
			{
				for (h2 = 0; h2 < this.nHoursPerDay; h2++)
					if (this.hoursOfTheDay[h2] == elem4.text())
						break;
				if (h2 <= 0 || h2>this.nHoursPerDay)
				{
					RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint Break end hour corrupt for hour %1 is inexistent ... ignoring constraint").arg(elem4.text()));
					//goto corruptConstraintTime;
					return null;
				}
				Debug.Assert(h2 > 0 && h2 <= this.nHoursPerDay);
				xmlReadingLog += "    End hour=" + this.hoursOfTheDay[h2] + "\n";
			}
		}

		Debug.Assert(weightPercentage >= 0);
		Debug.Assert(d >= 0 && h1 >= 0 && h2 >= 0);

		ConstraintBreakTimes cn = null;

		bool found = false;
		foreach (TimeConstraint * c, this.timeConstraintsList) if (c.type == GlobalMembersTimeconstraint.CONSTRAINT_BREAK_TIMES)
		{
				ConstraintBreakTimes tna = (ConstraintBreakTimes) c;
				if (true)
				{
					found = true;

					for (int hh = h1; hh < h2; hh++)
					{
						int k;
						for (k = 0; k < tna.days.count(); k++)
							if (tna.days.at(k) == d && tna.hours.at(k) == hh)
								break;
						if (k == tna.days.count())
						{
							tna.days.append(d);
							tna.hours.append(hh);
						}
					}

					Debug.Assert(tna.days.count() == tna.hours.count());
				}
		}
		if (!found)
		{
			days.clear();
			hours.clear();
			for (int hh = h1; hh < h2; hh++)
			{
				days.append(d);
				hours.append(hh);
			}

			cn = new ConstraintBreakTimes(weightPercentage, days, hours);
			cn.active = active;
			cn.comments = comments;

			return cn;
		}
		else
			return null;
	}
	private TimeConstraint readBreakTimes(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintBreakTimes");
		ConstraintBreakTimes cn = new ConstraintBreakTimes();
		int nNotAvailableSlots = -1;
		int i = 0;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Read weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}

			else if (elem4.tagName() == "Number_of_Break_Times")
			{
				nNotAvailableSlots = elem4.text().toInt();
				xmlReadingLog += "    Read number of break times=" + CustomFETString.number(nNotAvailableSlots) + "\n";
			}

			else if (elem4.tagName() == "Break_Time")
			{
				xmlReadingLog += "    Read: not available time\n";

				int d = -1;
				int h = -1;

				for (QDomNode node5 = elem4.firstChild(); !node5.isNull(); node5 = node5.nextSibling())
				{
					QDomElement elem5 = node5.toElement();
					if (elem5.isNull())
					{
						xmlReadingLog += "    Null node here\n";
						continue;
					}
					xmlReadingLog += "    Found " + elem5.tagName() + " tag\n";
					if (elem5.tagName() == "Day")
					{
						for (d = 0; d < this.nDaysPerWeek; d++)
							if (this.daysOfTheWeek[d] == elem5.text())
								break;

						if (d >= this.nDaysPerWeek)
						{
							RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint BreakTimes day corrupt for day %1 is inexistent ... ignoring constraint").arg(elem5.text()));
							if (cn != null)
								cn.Dispose();
							cn = null;
							//goto corruptConstraintTime;
							return null;
						}

						Debug.Assert(d < this.nDaysPerWeek);
						xmlReadingLog += "    Day=" + this.daysOfTheWeek[d] + "(" + CustomFETString.number(i) + ")" + "\n";
					}
					else if (elem5.tagName() == "Hour")
					{
						for (h = 0; h < this.nHoursPerDay; h++)
							if (this.hoursOfTheDay[h] == elem5.text())
								break;

						if (h >= this.nHoursPerDay)
						{
							RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint BreakTimes hour corrupt for hour %1 is inexistent ... ignoring constraint").arg(elem5.text()));
							if (cn != null)
								cn.Dispose();
							cn = null;
							//goto corruptConstraintTime;
							return null;
						}

						Debug.Assert(h >= 0 && h < this.nHoursPerDay);
						xmlReadingLog += "    Hour=" + this.hoursOfTheDay[h] + "\n";
					}
				}
				i++;

				cn.days.append(d);
				cn.hours.append(h);
			}
		}
		Debug.Assert(i == cn.days.count() && i == cn.hours.count());
		Debug.Assert(i == nNotAvailableSlots);
		return cn;
	}

	private TimeConstraint readTeachersNoGaps(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTeachersNoGaps");
		ConstraintTeachersMaxGapsPerWeek cn = new ConstraintTeachersMaxGapsPerWeek();
		cn.maxGaps = 0;
		//ConstraintTeachersNoGaps* cn=new ConstraintTeachersNoGaps();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
		}
		return cn;
	}
	private TimeConstraint readTeachersMaxGapsPerWeek(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTeachersMaxGapsPerWeek");
		ConstraintTeachersMaxGapsPerWeek cn = new ConstraintTeachersMaxGapsPerWeek();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Max_Gaps")
			{
				cn.maxGaps = elem4.text().toInt();
				xmlReadingLog += "    Adding max gaps=" + CustomFETString.number(cn.maxGaps) + "\n";
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
		}
		return cn;
	}
	private TimeConstraint readTeacherMaxGapsPerWeek(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTeacherMaxGapsPerWeek");
		ConstraintTeacherMaxGapsPerWeek cn = new ConstraintTeacherMaxGapsPerWeek();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Teacher_Name")
			{
				cn.teacherName = elem4.text();
				xmlReadingLog += "    Read teacher name=" + cn.teacherName + "\n";
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Max_Gaps")
			{
				cn.maxGaps = elem4.text().toInt();
				xmlReadingLog += "    Adding max gaps=" + CustomFETString.number(cn.maxGaps) + "\n";
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
		}
		return cn;
	}
	private TimeConstraint readTeachersMaxGapsPerDay(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTeachersMaxGapsPerDay");
		ConstraintTeachersMaxGapsPerDay cn = new ConstraintTeachersMaxGapsPerDay();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Max_Gaps")
			{
				cn.maxGaps = elem4.text().toInt();
				xmlReadingLog += "    Adding max gaps=" + CustomFETString.number(cn.maxGaps) + "\n";
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
		}
		return cn;
	}
	private TimeConstraint readTeacherMaxGapsPerDay(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTeacherMaxGapsPerDay");
		ConstraintTeacherMaxGapsPerDay cn = new ConstraintTeacherMaxGapsPerDay();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Teacher_Name")
			{
				cn.teacherName = elem4.text();
				xmlReadingLog += "    Read teacher name=" + cn.teacherName + "\n";
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Max_Gaps")
			{
				cn.maxGaps = elem4.text().toInt();
				xmlReadingLog += "    Adding max gaps=" + CustomFETString.number(cn.maxGaps) + "\n";
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
		}
		return cn;
	}

	private TimeConstraint readStudentsNoGaps(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsNoGaps");

		ConstraintStudentsMaxGapsPerWeek cn = new ConstraintStudentsMaxGapsPerWeek();

		cn.maxGaps = 0;

		//bool compulsory_read=false;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
				//compulsory_read=true;
			}
		}
		return cn;
	}
	private TimeConstraint readStudentsSetNoGaps(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsSetNoGaps");

		ConstraintStudentsSetMaxGapsPerWeek cn = new ConstraintStudentsSetMaxGapsPerWeek();

		cn.maxGaps = 0;

		//bool compulsory_read=false;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
				//compulsory_read=true;
			}
			else if (elem4.tagName() == "Students")
			{
				cn.students = elem4.text();
				xmlReadingLog += "    Read students name=" + cn.students + "\n";
			}
		}
		return cn;
	}
	private TimeConstraint readStudentsMaxGapsPerWeek(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsMaxGapsPerWeek");
		ConstraintStudentsMaxGapsPerWeek cn = new ConstraintStudentsMaxGapsPerWeek();

		//bool compulsory_read=false;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Max_Gaps")
			{
				cn.maxGaps = elem4.text().toInt();
				xmlReadingLog += "    Adding max gaps=" + CustomFETString.number(cn.maxGaps) + "\n";
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
				//compulsory_read=true;
			}
		}
		return cn;
	}
	private TimeConstraint readStudentsSetMaxGapsPerWeek(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsSetMaxGapsPerWeek");
		ConstraintStudentsSetMaxGapsPerWeek cn = new ConstraintStudentsSetMaxGapsPerWeek();

		//bool compulsory_read=false;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Max_Gaps")
			{
				cn.maxGaps = elem4.text().toInt();
				xmlReadingLog += "    Adding max gaps=" + CustomFETString.number(cn.maxGaps) + "\n";
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
				//compulsory_read=true;
			}
			else if (elem4.tagName() == "Students")
			{
				cn.students = elem4.text();
				xmlReadingLog += "    Read students name=" + cn.students + "\n";
			}
		}
		return cn;
	}

	private TimeConstraint readStudentsMaxGapsPerDay(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsMaxGapsPerDay");
		ConstraintStudentsMaxGapsPerDay cn = new ConstraintStudentsMaxGapsPerDay();

		//bool compulsory_read=false;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Max_Gaps")
			{
				cn.maxGaps = elem4.text().toInt();
				xmlReadingLog += "    Adding max gaps=" + CustomFETString.number(cn.maxGaps) + "\n";
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
				//compulsory_read=true;
			}
		}
		return cn;
	}
	private TimeConstraint readStudentsSetMaxGapsPerDay(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsSetMaxGapsPerDay");
		ConstraintStudentsSetMaxGapsPerDay cn = new ConstraintStudentsSetMaxGapsPerDay();

		//bool compulsory_read=false;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Max_Gaps")
			{
				cn.maxGaps = elem4.text().toInt();
				xmlReadingLog += "    Adding max gaps=" + CustomFETString.number(cn.maxGaps) + "\n";
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
				//compulsory_read=true;
			}
			else if (elem4.tagName() == "Students")
			{
				cn.students = elem4.text();
				xmlReadingLog += "    Read students name=" + cn.students + "\n";
			}
		}
		return cn;
	}

	private TimeConstraint readStudentsEarly(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsEarly");
		ConstraintStudentsEarlyMaxBeginningsAtSecondHour cn = new ConstraintStudentsEarlyMaxBeginningsAtSecondHour();

		cn.maxBeginningsAtSecondHour = 0;

		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
		}
		return cn;
	}
	private TimeConstraint readStudentsEarlyMaxBeginningsAtSecondHour(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsEarlyMaxBeginningsAtSecondHour");
		ConstraintStudentsEarlyMaxBeginningsAtSecondHour cn = new ConstraintStudentsEarlyMaxBeginningsAtSecondHour();
		cn.maxBeginningsAtSecondHour = -1;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Max_Beginnings_At_Second_Hour")
			{
				cn.maxBeginningsAtSecondHour = elem4.text().toInt();
				xmlReadingLog += "    Adding max beginnings at second hour=" + CustomFETString.number(cn.maxBeginningsAtSecondHour) + "\n";
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
		}
		Debug.Assert(cn.maxBeginningsAtSecondHour >= 0);
		return cn;
	}
	private TimeConstraint readStudentsSetEarly(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsSetEarly");
		ConstraintStudentsSetEarlyMaxBeginningsAtSecondHour cn = new ConstraintStudentsSetEarlyMaxBeginningsAtSecondHour();

		cn.maxBeginningsAtSecondHour = 0;

		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Students")
			{
				cn.students = elem4.text();
				xmlReadingLog += "    Read students name=" + cn.students + "\n";
			}
		}
		return cn;
	}
	private TimeConstraint readStudentsSetEarlyMaxBeginningsAtSecondHour(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsSetEarlyMaxBeginningsAtSecondHour");
		ConstraintStudentsSetEarlyMaxBeginningsAtSecondHour cn = new ConstraintStudentsSetEarlyMaxBeginningsAtSecondHour();
		cn.maxBeginningsAtSecondHour = -1;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Max_Beginnings_At_Second_Hour")
			{
				cn.maxBeginningsAtSecondHour = elem4.text().toInt();
				xmlReadingLog += "    Adding max beginnings at second hour=" + CustomFETString.number(cn.maxBeginningsAtSecondHour) + "\n";
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Students")
			{
				cn.students = elem4.text();
				xmlReadingLog += "    Read students name=" + cn.students + "\n";
			}
		}
		Debug.Assert(cn.maxBeginningsAtSecondHour >= 0);
		return cn;
	}

	private TimeConstraint readActivitiesPreferredTimes(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintActivitiesPreferredTimes");

		ConstraintActivitiesPreferredStartingTimes cn = new ConstraintActivitiesPreferredStartingTimes();
		cn.nPreferredStartingTimes_L = 0;
		int i;
		/*for(i=0; i<MAX_N_CONSTRAINT_ACTIVITIES_PREFERRED_STARTING_TIMES; i++){
			cn->days[i] = cn->hours[i] = -1;
		}*/
		cn.teacherName = "";
		cn.studentsName = "";
		cn.subjectName = "";
		cn.activityTagName = "";

		i = 0;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Teacher_Name")
			{
				cn.teacherName = elem4.text();
				xmlReadingLog += "    Read teacher name=" + cn.teacherName + "\n";
			}
			else if (elem4.tagName() == "Students_Name")
			{
				cn.studentsName = elem4.text();
				xmlReadingLog += "    Read students name=" + cn.studentsName + "\n";
			}
			else if (elem4.tagName() == "Subject_Name")
			{
				cn.subjectName = elem4.text();
				xmlReadingLog += "    Read subject name=" + cn.subjectName + "\n";
			}
			else if (elem4.tagName() == "Subject_Tag_Name")
			{
				cn.activityTagName = elem4.text();
				xmlReadingLog += "    Read activity tag name=" + cn.activityTagName + "\n";
			}
			else if (elem4.tagName() == "Activity_Tag_Name")
			{
				cn.activityTagName = elem4.text();
				xmlReadingLog += "    Read activity tag name=" + cn.activityTagName + "\n";
			}
			else if (elem4.tagName() == "Number_of_Preferred_Times")
			{
				cn.nPreferredStartingTimes_L = elem4.text().toInt();
				xmlReadingLog += "    Read number of preferred times=" + CustomFETString.number(cn.nPreferredStartingTimes_L) + "\n";
			}
			else if (elem4.tagName() == "Preferred_Time")
			{
				xmlReadingLog += "    Read: preferred time\n";

				for (QDomNode node5 = elem4.firstChild(); !node5.isNull(); node5 = node5.nextSibling())
				{
					QDomElement elem5 = node5.toElement();
					if (elem5.isNull())
					{
						xmlReadingLog += "    Null node here\n";
						continue;
					}
					xmlReadingLog += "    Found " + elem5.tagName() + " tag\n";
					if (elem5.tagName() == "Preferred_Day")
					{
						cn.days_L.append(0);
						Debug.Assert(cn.days_L.count() - 1 == i);
						for (cn.days_L[i] = 0; cn.days_L[i] < this.nDaysPerWeek; cn.days_L[i]++)
							if (this.daysOfTheWeek[cn.days_L[i]] == elem5.text())
								break;

						if (cn.days_L[i] >= this.nDaysPerWeek)
						{
							RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint ActivitiesPreferredTimes day corrupt for teacher name=%1, students names=%2, subject name=%3, activity tag name=%4, day %5 is inexistent ... ignoring constraint").arg(cn.teacherName).arg(cn.studentsName).arg(cn.subjectName).arg(cn.activityTagName).arg(elem5.text()));
							if (cn != null)
								cn.Dispose();
							cn = null;
							//goto corruptConstraintTime;
							return null;
						}

						Debug.Assert(cn.days_L[i] < this.nDaysPerWeek);
						xmlReadingLog += "    Preferred day=" + this.daysOfTheWeek[cn.days_L[i]] + "(" + CustomFETString.number(i) + ")" + "\n";
					}
					else if (elem5.tagName() == "Preferred_Hour")
					{
						cn.hours_L.append(0);
						Debug.Assert(cn.hours_L.count() - 1 == i);
						for (cn.hours_L[i] = 0; cn.hours_L[i] < this.nHoursPerDay; cn.hours_L[i]++)
							if (this.hoursOfTheDay[cn.hours_L[i]] == elem5.text())
								break;

						if (cn.hours_L[i] >= this.nHoursPerDay)
						{
							RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint ActivitiesPreferredTimes hour corrupt for teacher name=%1, students names=%2, subject name=%3, activity tag name=%4, hour %5 is inexistent ... ignoring constraint").arg(cn.teacherName).arg(cn.studentsName).arg(cn.subjectName).arg(cn.activityTagName).arg(elem5.text()));
							if (cn != null)
								cn.Dispose();
							cn = null;
							//goto corruptConstraintTime;
							return null;
						}

						Debug.Assert(cn.hours_L[i] >= 0 && cn.hours_L[i] < this.nHoursPerDay);
						xmlReadingLog += "    Preferred hour=" + this.hoursOfTheDay[cn.hours_L[i]] + "\n";
					}
				}

				i++;
			}
		}
		Debug.Assert(i == cn.nPreferredStartingTimes_L);
		return cn;
	}
	private TimeConstraint readActivitiesPreferredTimeSlots(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintActivitiesPreferredTimeSlots");
		ConstraintActivitiesPreferredTimeSlots cn = new ConstraintActivitiesPreferredTimeSlots();
		cn.p_nPreferredTimeSlots_L = 0;
		int i;
		/*for(i=0; i<MAX_N_CONSTRAINT_ACTIVITIES_PREFERRED_TIME_SLOTS; i++){
			cn->p_days[i] = cn->p_hours[i] = -1;
		}*/
		cn.p_teacherName = "";
		cn.p_studentsName = "";
		cn.p_subjectName = "";
		cn.p_activityTagName = "";

		i = 0;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Teacher_Name")
			{
				cn.p_teacherName = elem4.text();
				xmlReadingLog += "    Read teacher name=" + cn.p_teacherName + "\n";
			}
			else if (elem4.tagName() == "Students_Name")
			{
				cn.p_studentsName = elem4.text();
				xmlReadingLog += "    Read students name=" + cn.p_studentsName + "\n";
			}
			else if (elem4.tagName() == "Subject_Name")
			{
				cn.p_subjectName = elem4.text();
				xmlReadingLog += "    Read subject name=" + cn.p_subjectName + "\n";
			}
			else if (elem4.tagName() == "Subject_Tag_Name")
			{
				cn.p_activityTagName = elem4.text();
				xmlReadingLog += "    Read activity tag name=" + cn.p_activityTagName + "\n";
			}
			else if (elem4.tagName() == "Activity_Tag_Name")
			{
				cn.p_activityTagName = elem4.text();
				xmlReadingLog += "    Read activity tag name=" + cn.p_activityTagName + "\n";
			}
			else if (elem4.tagName() == "Number_of_Preferred_Time_Slots")
			{
				cn.p_nPreferredTimeSlots_L = elem4.text().toInt();
				xmlReadingLog += "    Read number of preferred times=" + CustomFETString.number(cn.p_nPreferredTimeSlots_L) + "\n";
			}
			else if (elem4.tagName() == "Preferred_Time_Slot")
			{
				xmlReadingLog += "    Read: preferred time slot\n";

				for (QDomNode node5 = elem4.firstChild(); !node5.isNull(); node5 = node5.nextSibling())
				{
					QDomElement elem5 = node5.toElement();
					if (elem5.isNull())
					{
						xmlReadingLog += "    Null node here\n";
						continue;
					}
					xmlReadingLog += "    Found " + elem5.tagName() + " tag\n";
					if (elem5.tagName() == "Preferred_Day")
					{
						cn.p_days_L.append(0);
						Debug.Assert(cn.p_days_L.count() - 1 == i);
						for (cn.p_days_L[i] = 0; cn.p_days_L[i] < this.nDaysPerWeek; cn.p_days_L[i]++)
							if (this.daysOfTheWeek[cn.p_days_L[i]] == elem5.text())
								break;

						if (cn.p_days_L[i] >= this.nDaysPerWeek)
						{
							RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint ActivitiesPreferredTimeSlots day corrupt for teacher name=%1, students names=%2, subject name=%3, activity tag name=%4, day %5 is inexistent ... ignoring constraint").arg(cn.p_teacherName).arg(cn.p_studentsName).arg(cn.p_subjectName).arg(cn.p_activityTagName).arg(elem5.text()));
							if (cn != null)
								cn.Dispose();
							cn = null;
							//goto corruptConstraintTime;
							return null;
						}

						Debug.Assert(cn.p_days_L[i] < this.nDaysPerWeek);
						xmlReadingLog += "    Preferred day=" + this.daysOfTheWeek[cn.p_days_L[i]] + "(" + CustomFETString.number(i) + ")" + "\n";
					}
					else if (elem5.tagName() == "Preferred_Hour")
					{
						cn.p_hours_L.append(0);
						Debug.Assert(cn.p_hours_L.count() - 1 == i);
						for (cn.p_hours_L[i] = 0; cn.p_hours_L[i] < this.nHoursPerDay; cn.p_hours_L[i]++)
							if (this.hoursOfTheDay[cn.p_hours_L[i]] == elem5.text())
								break;

						if (cn.p_hours_L[i] >= this.nHoursPerDay)
						{
							RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint ActivitiesPreferredTimeSlots hour corrupt for teacher name=%1, students names=%2, subject name=%3, activity tag name=%4, hour %5 is inexistent ... ignoring constraint").arg(cn.p_teacherName).arg(cn.p_studentsName).arg(cn.p_subjectName).arg(cn.p_activityTagName).arg(elem5.text()));
							if (cn != null)
								cn.Dispose();
							cn = null;
							//goto corruptConstraintTime;
							return null;
						}

						Debug.Assert(cn.p_hours_L[i] >= 0 && cn.p_hours_L[i] < this.nHoursPerDay);
						xmlReadingLog += "    Preferred hour=" + this.hoursOfTheDay[cn.p_hours_L[i]] + "\n";
					}
				}

				i++;
			}
		}
		Debug.Assert(i == cn.p_nPreferredTimeSlots_L);
		return cn;
	}
	private TimeConstraint readActivitiesPreferredStartingTimes(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintActivitiesPreferredStartingTimes");
		ConstraintActivitiesPreferredStartingTimes cn = new ConstraintActivitiesPreferredStartingTimes();
		cn.nPreferredStartingTimes_L = 0;
		int i;
		/*for(i=0; i<MAX_N_CONSTRAINT_ACTIVITIES_PREFERRED_STARTING_TIMES; i++){
			cn->days[i] = cn->hours[i] = -1;
		}*/
		cn.teacherName = "";
		cn.studentsName = "";
		cn.subjectName = "";
		cn.activityTagName = "";

		i = 0;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Teacher_Name")
			{
				cn.teacherName = elem4.text();
				xmlReadingLog += "    Read teacher name=" + cn.teacherName + "\n";
			}
			else if (elem4.tagName() == "Students_Name")
			{
				cn.studentsName = elem4.text();
				xmlReadingLog += "    Read students name=" + cn.studentsName + "\n";
			}
			else if (elem4.tagName() == "Subject_Name")
			{
				cn.subjectName = elem4.text();
				xmlReadingLog += "    Read subject name=" + cn.subjectName + "\n";
			}
			else if (elem4.tagName() == "Subject_Tag_Name")
			{
				cn.activityTagName = elem4.text();
				xmlReadingLog += "    Read activity tag name=" + cn.activityTagName + "\n";
			}
			else if (elem4.tagName() == "Activity_Tag_Name")
			{
				cn.activityTagName = elem4.text();
				xmlReadingLog += "    Read activity tag name=" + cn.activityTagName + "\n";
			}
			else if (elem4.tagName() == "Number_of_Preferred_Starting_Times")
			{
				cn.nPreferredStartingTimes_L = elem4.text().toInt();
				xmlReadingLog += "    Read number of preferred starting times=" + CustomFETString.number(cn.nPreferredStartingTimes_L) + "\n";
			}
			else if (elem4.tagName() == "Preferred_Starting_Time")
			{
				xmlReadingLog += "    Read: preferred starting time\n";

				for (QDomNode node5 = elem4.firstChild(); !node5.isNull(); node5 = node5.nextSibling())
				{
					QDomElement elem5 = node5.toElement();
					if (elem5.isNull())
					{
						xmlReadingLog += "    Null node here\n";
						continue;
					}
					xmlReadingLog += "    Found " + elem5.tagName() + " tag\n";
					if (elem5.tagName() == "Preferred_Starting_Day")
					{
						cn.days_L.append(0);
						Debug.Assert(cn.days_L.count() - 1 == i);
						for (cn.days_L[i] = 0; cn.days_L[i] < this.nDaysPerWeek; cn.days_L[i]++)
							if (this.daysOfTheWeek[cn.days_L[i]] == elem5.text())
								break;

						if (cn.days_L[i] >= this.nDaysPerWeek)
						{
							RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint ActivitiesPreferredStartingTimes day corrupt for teacher name=%1, students names=%2, subject name=%3, activity tag name=%4, day %5 is inexistent ... ignoring constraint").arg(cn.teacherName).arg(cn.studentsName).arg(cn.subjectName).arg(cn.activityTagName).arg(elem5.text()));
							if (cn != null)
								cn.Dispose();
							cn = null;
							//goto corruptConstraintTime;
							return null;
						}

						Debug.Assert(cn.days_L[i] < this.nDaysPerWeek);
						xmlReadingLog += "    Preferred starting day=" + this.daysOfTheWeek[cn.days_L[i]] + "(" + CustomFETString.number(i) + ")" + "\n";
					}
					else if (elem5.tagName() == "Preferred_Starting_Hour")
					{
						cn.hours_L.append(0);
						Debug.Assert(cn.hours_L.count() - 1 == i);
						for (cn.hours_L[i] = 0; cn.hours_L[i] < this.nHoursPerDay; cn.hours_L[i]++)
							if (this.hoursOfTheDay[cn.hours_L[i]] == elem5.text())
								break;

						if (cn.hours_L[i] >= this.nHoursPerDay)
						{
							RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint ActivitiesPreferredStartingTimes hour corrupt for teacher name=%1, students names=%2, subject name=%3, activity tag name=%4, hour %5 is inexistent ... ignoring constraint").arg(cn.teacherName).arg(cn.studentsName).arg(cn.subjectName).arg(cn.activityTagName).arg(elem5.text()));
							if (cn != null)
								cn.Dispose();
							cn = null;
							//goto corruptConstraintTime;
							return null;
						}

						Debug.Assert(cn.hours_L[i] >= 0 && cn.hours_L[i] < this.nHoursPerDay);
						xmlReadingLog += "    Preferred starting hour=" + this.hoursOfTheDay[cn.hours_L[i]] + "\n";
					}
				}

				i++;
			}
		}
		Debug.Assert(i == cn.nPreferredStartingTimes_L);
		return cn;
	}


	////////////////
	private TimeConstraint readSubactivitiesPreferredTimeSlots(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintSubactivitiesPreferredTimeSlots");
		ConstraintSubactivitiesPreferredTimeSlots cn = new ConstraintSubactivitiesPreferredTimeSlots();
		cn.p_nPreferredTimeSlots_L = 0;
		cn.componentNumber = 0;
		int i;
		/*for(i=0; i<MAX_N_CONSTRAINT_SUBACTIVITIES_PREFERRED_TIME_SLOTS; i++){
			cn->p_days[i] = cn->p_hours[i] = -1;
		}*/
		cn.p_teacherName = "";
		cn.p_studentsName = "";
		cn.p_subjectName = "";
		cn.p_activityTagName = "";

		i = 0;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Component_Number")
			{
				cn.componentNumber = elem4.text().toInt();
				xmlReadingLog += "    Adding component number=" + CustomFETString.number(cn.componentNumber) + "\n";
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Teacher_Name")
			{
				cn.p_teacherName = elem4.text();
				xmlReadingLog += "    Read teacher name=" + cn.p_teacherName + "\n";
			}
			else if (elem4.tagName() == "Students_Name")
			{
				cn.p_studentsName = elem4.text();
				xmlReadingLog += "    Read students name=" + cn.p_studentsName + "\n";
			}
			else if (elem4.tagName() == "Subject_Name")
			{
				cn.p_subjectName = elem4.text();
				xmlReadingLog += "    Read subject name=" + cn.p_subjectName + "\n";
			}
			else if (elem4.tagName() == "Subject_Tag_Name")
			{
				cn.p_activityTagName = elem4.text();
				xmlReadingLog += "    Read activity tag name=" + cn.p_activityTagName + "\n";
			}
			else if (elem4.tagName() == "Activity_Tag_Name")
			{
				cn.p_activityTagName = elem4.text();
				xmlReadingLog += "    Read activity tag name=" + cn.p_activityTagName + "\n";
			}
			else if (elem4.tagName() == "Number_of_Preferred_Time_Slots")
			{
				cn.p_nPreferredTimeSlots_L = elem4.text().toInt();
				xmlReadingLog += "    Read number of preferred times=" + CustomFETString.number(cn.p_nPreferredTimeSlots_L) + "\n";
			}
			else if (elem4.tagName() == "Preferred_Time_Slot")
			{
				xmlReadingLog += "    Read: preferred time slot\n";

				for (QDomNode node5 = elem4.firstChild(); !node5.isNull(); node5 = node5.nextSibling())
				{
					QDomElement elem5 = node5.toElement();
					if (elem5.isNull())
					{
						xmlReadingLog += "    Null node here\n";
						continue;
					}
					xmlReadingLog += "    Found " + elem5.tagName() + " tag\n";
					if (elem5.tagName() == "Preferred_Day")
					{
						cn.p_days_L.append(0);
						Debug.Assert(cn.p_days_L.count() - 1 == i);
						for (cn.p_days_L[i] = 0; cn.p_days_L[i] < this.nDaysPerWeek; cn.p_days_L[i]++)
							if (this.daysOfTheWeek[cn.p_days_L[i]] == elem5.text())
								break;

						if (cn.p_days_L[i] >= this.nDaysPerWeek)
						{
							RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint ActivitiesPreferredTimeSlots day corrupt for teacher name=%1, students names=%2, subject name=%3, activity tag name=%4, day %5 is inexistent ... ignoring constraint").arg(cn.p_teacherName).arg(cn.p_studentsName).arg(cn.p_subjectName).arg(cn.p_activityTagName).arg(elem5.text()));
							if (cn != null)
								cn.Dispose();
							cn = null;
							//goto corruptConstraintTime;
							return null;
						}

						Debug.Assert(cn.p_days_L[i] < this.nDaysPerWeek);
						xmlReadingLog += "    Preferred day=" + this.daysOfTheWeek[cn.p_days_L[i]] + "(" + CustomFETString.number(i) + ")" + "\n";
					}
					else if (elem5.tagName() == "Preferred_Hour")
					{
						cn.p_hours_L.append(0);
						Debug.Assert(cn.p_hours_L.count() - 1 == i);
						for (cn.p_hours_L[i] = 0; cn.p_hours_L[i] < this.nHoursPerDay; cn.p_hours_L[i]++)
							if (this.hoursOfTheDay[cn.p_hours_L[i]] == elem5.text())
								break;

						if (cn.p_hours_L[i] >= this.nHoursPerDay)
						{
							RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint ActivitiesPreferredTimeSlots hour corrupt for teacher name=%1, students names=%2, subject name=%3, activity tag name=%4, hour %5 is inexistent ... ignoring constraint").arg(cn.p_teacherName).arg(cn.p_studentsName).arg(cn.p_subjectName).arg(cn.p_activityTagName).arg(elem5.text()));
							if (cn != null)
								cn.Dispose();
							cn = null;
							//goto corruptConstraintTime;
							return null;
						}

						Debug.Assert(cn.p_hours_L[i] >= 0 && cn.p_hours_L[i] < this.nHoursPerDay);
						xmlReadingLog += "    Preferred hour=" + this.hoursOfTheDay[cn.p_hours_L[i]] + "\n";
					}
				}

				i++;
			}
		}
		Debug.Assert(i == cn.p_nPreferredTimeSlots_L);
		return cn;
	}
	private TimeConstraint readSubactivitiesPreferredStartingTimes(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintSubactivitiesPreferredStartingTimes");
		ConstraintSubactivitiesPreferredStartingTimes cn = new ConstraintSubactivitiesPreferredStartingTimes();
		cn.nPreferredStartingTimes_L = 0;
		cn.componentNumber = 0;
		int i;
		/*for(i=0; i<MAX_N_CONSTRAINT_SUBACTIVITIES_PREFERRED_STARTING_TIMES; i++){
			cn->days[i] = cn->hours[i] = -1;
		}*/
		cn.teacherName = "";
		cn.studentsName = "";
		cn.subjectName = "";
		cn.activityTagName = "";

		i = 0;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Component_Number")
			{
				cn.componentNumber = elem4.text().toInt();
				xmlReadingLog += "    Adding component number=" + CustomFETString.number(cn.componentNumber) + "\n";
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Teacher_Name")
			{
				cn.teacherName = elem4.text();
				xmlReadingLog += "    Read teacher name=" + cn.teacherName + "\n";
			}
			else if (elem4.tagName() == "Students_Name")
			{
				cn.studentsName = elem4.text();
				xmlReadingLog += "    Read students name=" + cn.studentsName + "\n";
			}
			else if (elem4.tagName() == "Subject_Name")
			{
				cn.subjectName = elem4.text();
				xmlReadingLog += "    Read subject name=" + cn.subjectName + "\n";
			}
			else if (elem4.tagName() == "Subject_Tag_Name")
			{
				cn.activityTagName = elem4.text();
				xmlReadingLog += "    Read activity tag name=" + cn.activityTagName + "\n";
			}
			else if (elem4.tagName() == "Activity_Tag_Name")
			{
				cn.activityTagName = elem4.text();
				xmlReadingLog += "    Read activity tag name=" + cn.activityTagName + "\n";
			}
			else if (elem4.tagName() == "Number_of_Preferred_Starting_Times")
			{
				cn.nPreferredStartingTimes_L = elem4.text().toInt();
				xmlReadingLog += "    Read number of preferred starting times=" + CustomFETString.number(cn.nPreferredStartingTimes_L) + "\n";
			}
			else if (elem4.tagName() == "Preferred_Starting_Time")
			{
				xmlReadingLog += "    Read: preferred starting time\n";

				for (QDomNode node5 = elem4.firstChild(); !node5.isNull(); node5 = node5.nextSibling())
				{
					QDomElement elem5 = node5.toElement();
					if (elem5.isNull())
					{
						xmlReadingLog += "    Null node here\n";
						continue;
					}
					xmlReadingLog += "    Found " + elem5.tagName() + " tag\n";
					if (elem5.tagName() == "Preferred_Starting_Day")
					{
						cn.days_L.append(0);
						Debug.Assert(cn.days_L.count() - 1 == i);
						for (cn.days_L[i] = 0; cn.days_L[i] < this.nDaysPerWeek; cn.days_L[i]++)
							if (this.daysOfTheWeek[cn.days_L[i]] == elem5.text())
								break;

						if (cn.days_L[i] >= this.nDaysPerWeek)
						{
							RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint ActivitiesPreferredStartingTimes day corrupt for teacher name=%1, students names=%2, subject name=%3, activity tag name=%4, day %5 is inexistent ... ignoring constraint").arg(cn.teacherName).arg(cn.studentsName).arg(cn.subjectName).arg(cn.activityTagName).arg(elem5.text()));
							if (cn != null)
								cn.Dispose();
							cn = null;
							//goto corruptConstraintTime;
							return null;
						}

						Debug.Assert(cn.days_L[i] < this.nDaysPerWeek);
						xmlReadingLog += "    Preferred starting day=" + this.daysOfTheWeek[cn.days_L[i]] + "(" + CustomFETString.number(i) + ")" + "\n";
					}
					else if (elem5.tagName() == "Preferred_Starting_Hour")
					{
						cn.hours_L.append(0);
						Debug.Assert(cn.hours_L.count() - 1 == i);
						for (cn.hours_L[i] = 0; cn.hours_L[i] < this.nHoursPerDay; cn.hours_L[i]++)
							if (this.hoursOfTheDay[cn.hours_L[i]] == elem5.text())
								break;

						if (cn.hours_L[i] >= this.nHoursPerDay)
						{
							RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint ActivitiesPreferredStartingTimes hour corrupt for teacher name=%1, students names=%2, subject name=%3, activity tag name=%4, hour %5 is inexistent ... ignoring constraint").arg(cn.teacherName).arg(cn.studentsName).arg(cn.subjectName).arg(cn.activityTagName).arg(elem5.text()));
							if (cn != null)
								cn.Dispose();
							cn = null;
							//goto corruptConstraintTime;
							return null;
						}

						Debug.Assert(cn.hours_L[i] >= 0 && cn.hours_L[i] < this.nHoursPerDay);
						xmlReadingLog += "    Preferred starting hour=" + this.hoursOfTheDay[cn.hours_L[i]] + "\n";
					}
				}

				i++;
			}
		}
		Debug.Assert(i == cn.nPreferredStartingTimes_L);
		return cn;
	}


	//2011-09-25
	private TimeConstraint readActivitiesOccupyMaxTimeSlotsFromSelection(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintActivitiesOccupyMaxTimeSlotsFromSelection");
		ConstraintActivitiesOccupyMaxTimeSlotsFromSelection cn = new ConstraintActivitiesOccupyMaxTimeSlotsFromSelection();

		int ac = 0;
		int tsc = 0;
		int i = 0;

		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";

			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Number_of_Activities")
			{
				ac = elem4.text().toInt();
				xmlReadingLog += "    Read number of activities=" + CustomFETString.number(ac) + "\n";
			}
			else if (elem4.tagName() == "Activity_Id")
			{
				cn.activitiesIds.append(elem4.text().toInt());
				xmlReadingLog += "    Read activity id=" + CustomFETString.number(cn.activitiesIds[cn.activitiesIds.count() - 1]) + "\n";
			}
			else if (elem4.tagName() == "Number_of_Selected_Time_Slots")
			{
				tsc = elem4.text().toInt();
				xmlReadingLog += "    Read number of selected time slots=" + CustomFETString.number(tsc) + "\n";
			}
			else if (elem4.tagName() == "Selected_Time_Slot")
			{
				xmlReadingLog += "    Read: selected time slot\n";

				for (QDomNode node5 = elem4.firstChild(); !node5.isNull(); node5 = node5.nextSibling())
				{
					QDomElement elem5 = node5.toElement();
					if (elem5.isNull())
					{
						xmlReadingLog += "    Null node here\n";
						continue;
					}
					xmlReadingLog += "    Found " + elem5.tagName() + " tag\n";
					if (elem5.tagName() == "Selected_Day")
					{
						cn.selectedDays.append(0);
						Debug.Assert(cn.selectedDays.count() - 1 == i);
						for (cn.selectedDays[i] = 0; cn.selectedDays[i] < this.nDaysPerWeek; cn.selectedDays[i]++)
							if (this.daysOfTheWeek[cn.selectedDays[i]] == elem5.text())
								break;

						if (cn.selectedDays[i] >= this.nDaysPerWeek)
						{
							RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint ActivitiesOccupyMaxTimeSlotsFromSelection day corrupt, day %1 is inexistent ... ignoring constraint").arg(elem5.text()));
							if (cn != null)
								cn.Dispose();
							cn = null;
							//goto corruptConstraintTime;
							return null;
						}

						Debug.Assert(cn.selectedDays[i] < this.nDaysPerWeek);
						xmlReadingLog += "    Selected day=" + this.daysOfTheWeek[cn.selectedDays[i]] + "(" + CustomFETString.number(i) + ")" + "\n";
					}
					else if (elem5.tagName() == "Selected_Hour")
					{
						cn.selectedHours.append(0);
						Debug.Assert(cn.selectedHours.count() - 1 == i);
						for (cn.selectedHours[i] = 0; cn.selectedHours[i] < this.nHoursPerDay; cn.selectedHours[i]++)
							if (this.hoursOfTheDay[cn.selectedHours[i]] == elem5.text())
								break;

						if (cn.selectedHours[i] >= this.nHoursPerDay)
						{
							RulesReconcilableMessage.information(parent, tr("FET information"), tr(" Constraint ActivitiesOccupyMaxTimeSlotsFromSelection hour corrupt, hour %1 is inexistent ... ignoring constraint").arg(elem5.text()));
							if (cn != null)
								cn.Dispose();
							cn = null;
							//goto corruptConstraintTime;
							return null;
						}

						Debug.Assert(cn.selectedHours[i] >= 0 && cn.selectedHours[i] < this.nHoursPerDay);
						xmlReadingLog += "    Selected hour=" + this.hoursOfTheDay[cn.selectedHours[i]] + "\n";
					}
				}

				i++;
			}
			else if (elem4.tagName() == "Max_Number_of_Occupied_Time_Slots")
			{
				cn.maxOccupiedTimeSlots = elem4.text().toInt();
				xmlReadingLog += "    Read max number of occupied time slots=" + CustomFETString.number(cn.maxOccupiedTimeSlots) + "\n";
			}
		}

		Debug.Assert(ac == cn.activitiesIds.count());

		Debug.Assert(i == tsc);
		Debug.Assert(i == cn.selectedDays.count());
		Debug.Assert(i == cn.selectedHours.count());
		return cn;
	}
	////////////////

	//2011-09-30
	private TimeConstraint readActivitiesMaxSimultaneousInSelectedTimeSlots(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintActivitiesMaxSimultaneousInSelectedTimeSlots");
		ConstraintActivitiesMaxSimultaneousInSelectedTimeSlots cn = new ConstraintActivitiesMaxSimultaneousInSelectedTimeSlots();

		int ac = 0;
		int tsc = 0;
		int i = 0;

		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";

			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Number_of_Activities")
			{
				ac = elem4.text().toInt();
				xmlReadingLog += "    Read number of activities=" + CustomFETString.number(ac) + "\n";
			}
			else if (elem4.tagName() == "Activity_Id")
			{
				cn.activitiesIds.append(elem4.text().toInt());
				xmlReadingLog += "    Read activity id=" + CustomFETString.number(cn.activitiesIds[cn.activitiesIds.count() - 1]) + "\n";
			}
			else if (elem4.tagName() == "Number_of_Selected_Time_Slots")
			{
				tsc = elem4.text().toInt();
				xmlReadingLog += "    Read number of selected time slots=" + CustomFETString.number(tsc) + "\n";
			}
			else if (elem4.tagName() == "Selected_Time_Slot")
			{
				xmlReadingLog += "    Read: selected time slot\n";

				for (QDomNode node5 = elem4.firstChild(); !node5.isNull(); node5 = node5.nextSibling())
				{
					QDomElement elem5 = node5.toElement();
					if (elem5.isNull())
					{
						xmlReadingLog += "    Null node here\n";
						continue;
					}
					xmlReadingLog += "    Found " + elem5.tagName() + " tag\n";
					if (elem5.tagName() == "Selected_Day")
					{
						cn.selectedDays.append(0);
						Debug.Assert(cn.selectedDays.count() - 1 == i);
						for (cn.selectedDays[i] = 0; cn.selectedDays[i] < this.nDaysPerWeek; cn.selectedDays[i]++)
							if (this.daysOfTheWeek[cn.selectedDays[i]] == elem5.text())
								break;

						if (cn.selectedDays[i] >= this.nDaysPerWeek)
						{
							RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint ActivitiesMaxSimultaneousInSelectedTimeSlots day corrupt, day %1 is inexistent ... ignoring constraint").arg(elem5.text()));
							if (cn != null)
								cn.Dispose();
							cn = null;
							//goto corruptConstraintTime;
							return null;
						}

						Debug.Assert(cn.selectedDays[i] < this.nDaysPerWeek);
						xmlReadingLog += "    Selected day=" + this.daysOfTheWeek[cn.selectedDays[i]] + "(" + CustomFETString.number(i) + ")" + "\n";
					}
					else if (elem5.tagName() == "Selected_Hour")
					{
						cn.selectedHours.append(0);
						Debug.Assert(cn.selectedHours.count() - 1 == i);
						for (cn.selectedHours[i] = 0; cn.selectedHours[i] < this.nHoursPerDay; cn.selectedHours[i]++)
							if (this.hoursOfTheDay[cn.selectedHours[i]] == elem5.text())
								break;

						if (cn.selectedHours[i] >= this.nHoursPerDay)
						{
							RulesReconcilableMessage.information(parent, tr("FET information"), tr(" Constraint ActivitiesMaxSimultaneousInSelectedTimeSlots hour corrupt, hour %1 is inexistent ... ignoring constraint").arg(elem5.text()));
							if (cn != null)
								cn.Dispose();
							cn = null;
							//goto corruptConstraintTime;
							return null;
						}

						Debug.Assert(cn.selectedHours[i] >= 0 && cn.selectedHours[i] < this.nHoursPerDay);
						xmlReadingLog += "    Selected hour=" + this.hoursOfTheDay[cn.selectedHours[i]] + "\n";
					}
				}

				i++;
			}
			else if (elem4.tagName() == "Max_Number_of_Simultaneous_Activities")
			{
				cn.maxSimultaneous = elem4.text().toInt();
				xmlReadingLog += "    Read max number of simultaneous activities=" + CustomFETString.number(cn.maxSimultaneous) + "\n";
			}
		}

		Debug.Assert(ac == cn.activitiesIds.count());

		Debug.Assert(i == tsc);
		Debug.Assert(i == cn.selectedDays.count());
		Debug.Assert(i == cn.selectedHours.count());
		return cn;
	}

	////////////////

	///space constraints reading routines
	private SpaceConstraint readBasicCompulsorySpace(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintBasicCompulsorySpace");
		ConstraintBasicCompulsorySpace cn = new ConstraintBasicCompulsorySpace();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}

			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";

			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			/*if(elem4.tagName()=="Weight"){
				cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog+="    Adding weight="+CustomFETString::number(cn->weight)+"\n";
			}
			else if(elem4.tagName()=="Compulsory"){
				if(elem4.text()=="yes"){
					cn->compulsory=true;
					xmlReadingLog+="    Current constraint is compulsory\n";
				}
				else{
					cn->compulsory=false;
					xmlReadingLog+="    Current constraint is not compulsory\n";
				}
			}*/
		}
		return cn;
	}
	private SpaceConstraint readRoomNotAvailable(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintRoomNotAvailable");

		QList<int> days = new QList<int>();
		QList<int> hours = new QList<int>();
		QString room = new QString();
		double weightPercentage = 100;
		int d = -1;
		int h1 = -1;
		int h2 = -1;
		bool active = true;
		QString comments = new QString("");
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Read weight percentage=" + CustomFETString.number(weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				comments = elem4.text();
			}
			else if (elem4.tagName() == "Day")
			{
				for (d = 0; d < this.nDaysPerWeek; d++)
					if (this.daysOfTheWeek[d] == elem4.text())
						break;
				if (d >= this.nDaysPerWeek)
				{
					RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint RoomNotAvailable day corrupt for room %1, day %2 is inexistent ... ignoring constraint").arg(room).arg(elem4.text()));
					//cn=NULL;
					//goto corruptConstraintSpace;
					return null;
				}
				Debug.Assert(d < this.nDaysPerWeek);
				xmlReadingLog += "    Crt. day=" + this.daysOfTheWeek[d] + "\n";
			}
			else if (elem4.tagName() == "Start_Hour")
			{
				for (h1 = 0; h1 < this.nHoursPerDay; h1++)
					if (this.hoursOfTheDay[h1] == elem4.text())
						break;
				if (h1 >= this.nHoursPerDay)
				{
					RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint RoomNotAvailable start hour corrupt for room %1, hour %2 is inexistent ... ignoring constraint").arg(room).arg(elem4.text()));
					//cn=NULL;
					//goto corruptConstraintSpace;
					return null;
				}
				Debug.Assert(h1 >= 0 && h1 < this.nHoursPerDay);
				xmlReadingLog += "    Start hour=" + this.hoursOfTheDay[h1] + "\n";
			}
			else if (elem4.tagName() == "End_Hour")
			{
				for (h2 = 0; h2 < this.nHoursPerDay; h2++)
					if (this.hoursOfTheDay[h2] == elem4.text())
						break;
				if (h2 <= 0 || h2>this.nHoursPerDay)
				{
					RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint RoomNotAvailable end hour corrupt for room %1, hour %2 is inexistent ... ignoring constraint").arg(room).arg(elem4.text()));
					//goto corruptConstraintSpace;
					return null;
				}
				Debug.Assert(h2 > 0 && h2 <= this.nHoursPerDay);
				xmlReadingLog += "    End hour=" + this.hoursOfTheDay[h2] + "\n";
			}
			else if (elem4.tagName() == "Room_Name")
			{
				room = elem4.text();
				xmlReadingLog += "    Read room name=" + room + "\n";
			}
		}

		Debug.Assert(weightPercentage >= 0);
		Debug.Assert(d >= 0 && h1 >= 0 && h2 >= 0);

		ConstraintRoomNotAvailableTimes cn = null;

		bool found = false;
		foreach (SpaceConstraint * c, this.spaceConstraintsList) if (c.type == GlobalMembersSpaceconstraint.CONSTRAINT_ROOM_NOT_AVAILABLE_TIMES)
		{
				ConstraintRoomNotAvailableTimes tna = (ConstraintRoomNotAvailableTimes) c;
				if (tna.room == room)
				{
					found = true;

					for (int hh = h1; hh < h2; hh++)
					{
						int k;
						for (k = 0; k < tna.days.count(); k++)
							if (tna.days.at(k) == d && tna.hours.at(k) == hh)
								break;
						if (k == tna.days.count())
						{
							tna.days.append(d);
							tna.hours.append(hh);
						}
					}

					Debug.Assert(tna.days.count() == tna.hours.count());
				}
		}
		if (!found)
		{
			days.clear();
			hours.clear();
			for (int hh = h1; hh < h2; hh++)
			{
				days.append(d);
				hours.append(hh);
			}

			cn = new ConstraintRoomNotAvailableTimes(weightPercentage, room, days, hours);
			cn.active = active;
			cn.comments = comments;

			return cn;
		}
		else
			return null;
	}
	private SpaceConstraint readRoomNotAvailableTimes(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintRoomNotAvailableTimes");
		ConstraintRoomNotAvailableTimes cn = new ConstraintRoomNotAvailableTimes();
		int nNotAvailableSlots = -1;
		int i = 0;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Read weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}

			else if (elem4.tagName() == "Number_of_Not_Available_Times")
			{
				nNotAvailableSlots = elem4.text().toInt();
				xmlReadingLog += "    Read number of not available times=" + CustomFETString.number(nNotAvailableSlots) + "\n";
			}

			else if (elem4.tagName() == "Not_Available_Time")
			{
				xmlReadingLog += "    Read: not available time\n";

				int d = -1;
				int h = -1;

				for (QDomNode node5 = elem4.firstChild(); !node5.isNull(); node5 = node5.nextSibling())
				{
					QDomElement elem5 = node5.toElement();
					if (elem5.isNull())
					{
						xmlReadingLog += "    Null node here\n";
						continue;
					}
					xmlReadingLog += "    Found " + elem5.tagName() + " tag\n";
					if (elem5.tagName() == "Day")
					{
						for (d = 0; d < this.nDaysPerWeek; d++)
							if (this.daysOfTheWeek[d] == elem5.text())
								break;

						if (d >= this.nDaysPerWeek)
						{
							RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint RoomNotAvailableTimes day corrupt for room %1, day %2 is inexistent ... ignoring constraint").arg(cn.room).arg(elem5.text()));
							if (cn != null)
								cn.Dispose();
							cn = null;
							return null;
							//goto corruptConstraintSpace;
						}

						Debug.Assert(d < this.nDaysPerWeek);
						xmlReadingLog += "    Day=" + this.daysOfTheWeek[d] + "(" + CustomFETString.number(i) + ")" + "\n";
					}
					else if (elem5.tagName() == "Hour")
					{
						for (h = 0; h < this.nHoursPerDay; h++)
							if (this.hoursOfTheDay[h] == elem5.text())
								break;

						if (h >= this.nHoursPerDay)
						{
							RulesReconcilableMessage.information(parent, tr("FET information"), tr("Constraint RoomNotAvailableTimes hour corrupt for room %1, hour %2 is inexistent ... ignoring constraint").arg(cn.room).arg(elem5.text()));
							if (cn != null)
								cn.Dispose();
							cn = null;
							//goto corruptConstraintSpace;
							return null;
						}

						Debug.Assert(h >= 0 && h < this.nHoursPerDay);
						xmlReadingLog += "    Hour=" + this.hoursOfTheDay[h] + "\n";
					}
				}
				i++;

				cn.days.append(d);
				cn.hours.append(h);
			}
			else if (elem4.tagName() == "Room")
			{
				cn.room = elem4.text();
				xmlReadingLog += "    Read room name=" + cn.room + "\n";
			}
		}
		Debug.Assert(i == cn.days.count() && i == cn.hours.count());
		Debug.Assert(i == nNotAvailableSlots);
		return cn;
	}
	private SpaceConstraint readActivityPreferredRoom(QWidget parent, QDomElement elem3, ref FakeString xmlReadingLog, ref bool reportUnspecifiedPermanentlyLockedSpace)
	{
		Debug.Assert(elem3.tagName() == "ConstraintActivityPreferredRoom");
		ConstraintActivityPreferredRoom cn = new ConstraintActivityPreferredRoom();
		cn.permanentlyLocked = false; //default
		bool foundLocked = false;
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Permanently_Locked")
			{
				if (elem4.text() == "true" || elem4.text() == "1" || elem4.text() == "yes")
				{
					xmlReadingLog += "    Permanently locked\n";
					cn.permanentlyLocked = true;
				}
				else
				{
					if (!(elem4.text() == "no" || elem4.text() == "false" || elem4.text() == "0"))
					{
						RulesReconcilableMessage.warning(parent, tr("FET warning"), tr("Found constraint activity preferred room with tag permanently locked" + " which is not 'true', 'false', 'yes', 'no', '1' or '0'." + " The tag will be considered false", "Instructions for translators: please leave the 'true', 'false', 'yes' and 'no' fields untranslated, as they are in English"));
					}
					//assert(elem4.text()=="false" || elem4.text()=="0" || elem4.text()=="no");
					xmlReadingLog += "    Not permanently locked\n";
					cn.permanentlyLocked = false;
				}
				foundLocked = true;
			}

			/*if(elem4.tagName()=="Weight"){
				cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog+="    Adding weight="+CustomFETString::number(cn->weight)+"\n";
			}
			else if(elem4.tagName()=="Compulsory"){
				if(elem4.text()=="yes"){
					cn->compulsory=true;
					xmlReadingLog+="    Current constraint is compulsory\n";
				}
				else{
					cn->compulsory=false;
					xmlReadingLog+="    Current constraint is not compulsory\n";
				}
			}*/
			else if (elem4.tagName() == "Activity_Id")
			{
				cn.activityId = elem4.text().toInt();
				xmlReadingLog += "    Read activity id=" + CustomFETString.number(cn.activityId) + "\n";
			}
			else if (elem4.tagName() == "Room")
			{
				cn.roomName = elem4.text();
				xmlReadingLog += "    Read room=" + elem4.text() + "\n";
			}
		}
		if (!foundLocked && reportUnspecifiedPermanentlyLockedSpace)
		{
			int t = RulesReconcilableMessage.information(parent, tr("FET information"), tr("Found constraint activity preferred room, with unspecified tag" + " 'permanently locked' - this tag will be set to 'false' by default. You can always modify it" + " by editing the constraint in the 'Data' menu") + "\n\n" + tr("Explanation: starting with version 5.8.0 (January 2009), the constraint" + " activity preferred room has" + " a new tag, 'permanently locked' (true or false)." + " It is recommended to make the tag 'permanently locked' true for the constraints you" + " need to be not modifiable from the 'Timetable' menu" + " and leave this tag false for the constraints you need to be modifiable from the 'Timetable' menu" + " (the 'permanently locked' tag can be modified by editing the constraint from the 'Data' menu)." + " This way, when viewing the timetable" + " and locking/unlocking some activities, you will not unlock the constraints which" + " need to be locked all the time."), tr("Skip rest"), tr("See next"), new QString(), 1, 0);
			if (t == 0)
				reportUnspecifiedPermanentlyLockedSpace = false;
		}

		return cn;
	}
	private SpaceConstraint readActivityPreferredRooms(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintActivityPreferredRooms");
		int _n_preferred_rooms = 0;
		ConstraintActivityPreferredRooms cn = new ConstraintActivityPreferredRooms();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			/*if(elem4.tagName()=="Weight"){
				cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog+="    Adding weight="+CustomFETString::number(cn->weight)+"\n";
			}
			else if(elem4.tagName()=="Compulsory"){
				if(elem4.text()=="yes"){
					cn->compulsory=true;
					xmlReadingLog+="    Current constraint is compulsory\n";
				}
				else{
					cn->compulsory=false;
					xmlReadingLog+="    Current constraint is not compulsory\n";
				}
			}*/
			else if (elem4.tagName() == "Activity_Id")
			{
				cn.activityId = elem4.text().toInt();
				xmlReadingLog += "    Read activity id=" + CustomFETString.number(cn.activityId) + "\n";
			}
			else if (elem4.tagName() == "Number_of_Preferred_Rooms")
			{
				_n_preferred_rooms = elem4.text().toInt();
				xmlReadingLog += "    Read number of preferred rooms: " + CustomFETString.number(_n_preferred_rooms) + "\n";
				Debug.Assert(_n_preferred_rooms >= 2);
			}
			else if (elem4.tagName() == "Preferred_Room")
			{
				cn.roomsNames.append(elem4.text());
				xmlReadingLog += "    Read room=" + elem4.text() + "\n";
			}
		}
		Debug.Assert(_n_preferred_rooms == cn.roomsNames.count());
		return cn;
	}
	private SpaceConstraint readSubjectPreferredRoom(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintSubjectPreferredRoom");
		ConstraintSubjectPreferredRoom cn = new ConstraintSubjectPreferredRoom();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Subject")
			{
				cn.subjectName = elem4.text();
				xmlReadingLog += "    Read subject=" + cn.subjectName + "\n";
			}
			else if (elem4.tagName() == "Room")
			{
				cn.roomName = elem4.text();
				xmlReadingLog += "    Read room=" + cn.roomName + "\n";
			}
		}
		return cn;
	}
	private SpaceConstraint readSubjectPreferredRooms(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintSubjectPreferredRooms");
		int _n_preferred_rooms = 0;
		ConstraintSubjectPreferredRooms cn = new ConstraintSubjectPreferredRooms();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Subject")
			{
				cn.subjectName = elem4.text();
				xmlReadingLog += "    Read subject=" + cn.subjectName + "\n";
			}
			else if (elem4.tagName() == "Number_of_Preferred_Rooms")
			{
				_n_preferred_rooms = elem4.text().toInt();
				xmlReadingLog += "    Read number of preferred rooms: " + CustomFETString.number(_n_preferred_rooms) + "\n";
				Debug.Assert(_n_preferred_rooms >= 2);
			}
			else if (elem4.tagName() == "Preferred_Room")
			{
				cn.roomsNames.append(elem4.text());
				xmlReadingLog += "    Read room=" + elem4.text() + "\n";
			}
		}
		Debug.Assert(_n_preferred_rooms == cn.roomsNames.count());
		return cn;
	}
	private SpaceConstraint readSubjectSubjectTagPreferredRoom(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintSubjectSubjectTagPreferredRoom");
		ConstraintSubjectActivityTagPreferredRoom cn = new ConstraintSubjectActivityTagPreferredRoom();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Subject")
			{
				cn.subjectName = elem4.text();
				xmlReadingLog += "    Read subject=" + cn.subjectName + "\n";
			}
			else if (elem4.tagName() == "Subject_Tag")
			{
				cn.activityTagName = elem4.text();
				xmlReadingLog += "    Read activity tag=" + cn.activityTagName + "\n";
			}
			else if (elem4.tagName() == "Room")
			{
				cn.roomName = elem4.text();
				xmlReadingLog += "    Read room=" + cn.roomName + "\n";
			}
		}
		return cn;
	}
	private SpaceConstraint readSubjectSubjectTagPreferredRooms(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintSubjectSubjectTagPreferredRooms");
		int _n_preferred_rooms = 0;
		ConstraintSubjectActivityTagPreferredRooms cn = new ConstraintSubjectActivityTagPreferredRooms();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Subject")
			{
				cn.subjectName = elem4.text();
				xmlReadingLog += "    Read subject=" + cn.subjectName + "\n";
			}
			else if (elem4.tagName() == "Subject_Tag")
			{
				cn.activityTagName = elem4.text();
				xmlReadingLog += "    Read activity tag=" + cn.activityTagName + "\n";
			}
			else if (elem4.tagName() == "Number_of_Preferred_Rooms")
			{
				_n_preferred_rooms = elem4.text().toInt();
				xmlReadingLog += "    Read number of preferred rooms: " + CustomFETString.number(_n_preferred_rooms) + "\n";
				Debug.Assert(_n_preferred_rooms >= 2);
			}
			else if (elem4.tagName() == "Preferred_Room")
			{
				cn.roomsNames.append(elem4.text());
				xmlReadingLog += "    Read room=" + elem4.text() + "\n";
			}
		}
		Debug.Assert(_n_preferred_rooms == cn.roomsNames.count());
		return cn;
	}
	private SpaceConstraint readSubjectActivityTagPreferredRoom(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintSubjectActivityTagPreferredRoom");
		ConstraintSubjectActivityTagPreferredRoom cn = new ConstraintSubjectActivityTagPreferredRoom();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Subject")
			{
				cn.subjectName = elem4.text();
				xmlReadingLog += "    Read subject=" + cn.subjectName + "\n";
			}
			else if (elem4.tagName() == "Activity_Tag")
			{
				cn.activityTagName = elem4.text();
				xmlReadingLog += "    Read activity tag=" + cn.activityTagName + "\n";
			}
			else if (elem4.tagName() == "Room")
			{
				cn.roomName = elem4.text();
				xmlReadingLog += "    Read room=" + cn.roomName + "\n";
			}
		}
		return cn;
	}
	private SpaceConstraint readSubjectActivityTagPreferredRooms(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintSubjectActivityTagPreferredRooms");
		int _n_preferred_rooms = 0;
		ConstraintSubjectActivityTagPreferredRooms cn = new ConstraintSubjectActivityTagPreferredRooms();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight")
			{
				//cn->weight=customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Ignoring old tag - weight - making weight percentage=100\n";
				cn.weightPercentage = 100;
			}
			else if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Compulsory")
			{
				if (elem4.text() == "yes")
				{
					//cn->compulsory=true;
					xmlReadingLog += "    Ignoring old tag - Current constraint is compulsory\n";
					cn.weightPercentage = 100;
				}
				else
				{
					//cn->compulsory=false;
					xmlReadingLog += "    Old tag - current constraint is not compulsory - making weightPercentage=0%\n";
					cn.weightPercentage = 0;
				}
			}
			else if (elem4.tagName() == "Subject")
			{
				cn.subjectName = elem4.text();
				xmlReadingLog += "    Read subject=" + cn.subjectName + "\n";
			}
			else if (elem4.tagName() == "Activity_Tag")
			{
				cn.activityTagName = elem4.text();
				xmlReadingLog += "    Read activity tag=" + cn.activityTagName + "\n";
			}
			else if (elem4.tagName() == "Number_of_Preferred_Rooms")
			{
				_n_preferred_rooms = elem4.text().toInt();
				xmlReadingLog += "    Read number of preferred rooms: " + CustomFETString.number(_n_preferred_rooms) + "\n";
				Debug.Assert(_n_preferred_rooms >= 2);
			}
			else if (elem4.tagName() == "Preferred_Room")
			{
				cn.roomsNames.append(elem4.text());
				xmlReadingLog += "    Read room=" + elem4.text() + "\n";
			}
		}
		Debug.Assert(_n_preferred_rooms == cn.roomsNames.count());
		return cn;
	}
	private SpaceConstraint readActivityTagPreferredRoom(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		//added 6 apr 2009
		Debug.Assert(elem3.tagName() == "ConstraintActivityTagPreferredRoom");
		ConstraintActivityTagPreferredRoom cn = new ConstraintActivityTagPreferredRoom();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Activity_Tag")
			{
				cn.activityTagName = elem4.text();
				xmlReadingLog += "    Read activity tag=" + cn.activityTagName + "\n";
			}
			else if (elem4.tagName() == "Room")
			{
				cn.roomName = elem4.text();
				xmlReadingLog += "    Read room=" + cn.roomName + "\n";
			}
		}
		return cn;
	}
	private SpaceConstraint readActivityTagPreferredRooms(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintActivityTagPreferredRooms");
		int _n_preferred_rooms = 0;
		ConstraintActivityTagPreferredRooms cn = new ConstraintActivityTagPreferredRooms();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Activity_Tag")
			{
				cn.activityTagName = elem4.text();
				xmlReadingLog += "    Read activity tag=" + cn.activityTagName + "\n";
			}
			else if (elem4.tagName() == "Number_of_Preferred_Rooms")
			{
				_n_preferred_rooms = elem4.text().toInt();
				xmlReadingLog += "    Read number of preferred rooms: " + CustomFETString.number(_n_preferred_rooms) + "\n";
				Debug.Assert(_n_preferred_rooms >= 2);
			}
			else if (elem4.tagName() == "Preferred_Room")
			{
				cn.roomsNames.append(elem4.text());
				xmlReadingLog += "    Read room=" + elem4.text() + "\n";
			}
		}
		Debug.Assert(_n_preferred_rooms == cn.roomsNames.count());
		return cn;
	}

	private SpaceConstraint readStudentsSetHomeRoom(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsSetHomeRoom");
		ConstraintStudentsSetHomeRoom cn = new ConstraintStudentsSetHomeRoom();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Students")
			{
				cn.studentsName = elem4.text();
				xmlReadingLog += "    Read students=" + cn.studentsName + "\n";
			}
			else if (elem4.tagName() == "Room")
			{
				cn.roomName = elem4.text();
				xmlReadingLog += "    Read room=" + cn.roomName + "\n";
			}
		}
		return cn;
	}
	private SpaceConstraint readStudentsSetHomeRooms(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsSetHomeRooms");
		int _n_preferred_rooms = 0;
		ConstraintStudentsSetHomeRooms cn = new ConstraintStudentsSetHomeRooms();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Students")
			{
				cn.studentsName = elem4.text();
				xmlReadingLog += "    Read students=" + cn.studentsName + "\n";
			}
			else if (elem4.tagName() == "Number_of_Preferred_Rooms")
			{
				_n_preferred_rooms = elem4.text().toInt();
				xmlReadingLog += "    Read number of preferred rooms: " + CustomFETString.number(_n_preferred_rooms) + "\n";
				Debug.Assert(_n_preferred_rooms >= 2);
			}
			else if (elem4.tagName() == "Preferred_Room")
			{
				cn.roomsNames.append(elem4.text());
				xmlReadingLog += "    Read room=" + elem4.text() + "\n";
			}
		}
		Debug.Assert(_n_preferred_rooms == cn.roomsNames.count());
		return cn;
	}
	private SpaceConstraint readTeacherHomeRoom(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTeacherHomeRoom");
		ConstraintTeacherHomeRoom cn = new ConstraintTeacherHomeRoom();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Teacher")
			{
				cn.teacherName = elem4.text();
				xmlReadingLog += "    Read teacher=" + cn.teacherName + "\n";
			}
			else if (elem4.tagName() == "Room")
			{
				cn.roomName = elem4.text();
				xmlReadingLog += "    Read room=" + cn.roomName + "\n";
			}
		}
		return cn;
	}
	private SpaceConstraint readTeacherHomeRooms(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTeacherHomeRooms");
		int _n_preferred_rooms = 0;
		ConstraintTeacherHomeRooms cn = new ConstraintTeacherHomeRooms();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Teacher")
			{
				cn.teacherName = elem4.text();
				xmlReadingLog += "    Read teacher=" + cn.teacherName + "\n";
			}
			else if (elem4.tagName() == "Number_of_Preferred_Rooms")
			{
				_n_preferred_rooms = elem4.text().toInt();
				xmlReadingLog += "    Read number of preferred rooms: " + CustomFETString.number(_n_preferred_rooms) + "\n";
				Debug.Assert(_n_preferred_rooms >= 2);
			}
			else if (elem4.tagName() == "Preferred_Room")
			{
				cn.roomsNames.append(elem4.text());
				xmlReadingLog += "    Read room=" + elem4.text() + "\n";
			}
		}
		Debug.Assert(_n_preferred_rooms == cn.roomsNames.count());
		return cn;
	}

	private SpaceConstraint readTeacherMaxBuildingChangesPerDay(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTeacherMaxBuildingChangesPerDay");
		ConstraintTeacherMaxBuildingChangesPerDay cn = new ConstraintTeacherMaxBuildingChangesPerDay();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Teacher")
			{
				cn.teacherName = elem4.text();
				xmlReadingLog += "    Read teacher name=" + cn.teacherName + "\n";
			}
			else if (elem4.tagName() == "Max_Building_Changes_Per_Day")
			{
				cn.maxBuildingChangesPerDay = elem4.text().toInt();
				xmlReadingLog += "    Max. building changes per day=" + CustomFETString.number(cn.maxBuildingChangesPerDay) + "\n";
			}
		}
		return cn;
	}
	private SpaceConstraint readTeachersMaxBuildingChangesPerDay(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTeachersMaxBuildingChangesPerDay");
		ConstraintTeachersMaxBuildingChangesPerDay cn = new ConstraintTeachersMaxBuildingChangesPerDay();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Max_Building_Changes_Per_Day")
			{
				cn.maxBuildingChangesPerDay = elem4.text().toInt();
				xmlReadingLog += "    Max. building changes per day=" + CustomFETString.number(cn.maxBuildingChangesPerDay) + "\n";
			}
		}
		return cn;
	}
	private SpaceConstraint readTeacherMaxBuildingChangesPerWeek(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTeacherMaxBuildingChangesPerWeek");
		ConstraintTeacherMaxBuildingChangesPerWeek cn = new ConstraintTeacherMaxBuildingChangesPerWeek();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Teacher")
			{
				cn.teacherName = elem4.text();
				xmlReadingLog += "    Read teacher name=" + cn.teacherName + "\n";
			}
			else if (elem4.tagName() == "Max_Building_Changes_Per_Week")
			{
				cn.maxBuildingChangesPerWeek = elem4.text().toInt();
				xmlReadingLog += "    Max. building changes per week=" + CustomFETString.number(cn.maxBuildingChangesPerWeek) + "\n";
			}
		}
		return cn;
	}
	private SpaceConstraint readTeachersMaxBuildingChangesPerWeek(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTeachersMaxBuildingChangesPerWeek");
		ConstraintTeachersMaxBuildingChangesPerWeek cn = new ConstraintTeachersMaxBuildingChangesPerWeek();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Max_Building_Changes_Per_Week")
			{
				cn.maxBuildingChangesPerWeek = elem4.text().toInt();
				xmlReadingLog += "    Max. building changes per week=" + CustomFETString.number(cn.maxBuildingChangesPerWeek) + "\n";
			}
		}
		return cn;
	}
	private SpaceConstraint readTeacherMinGapsBetweenBuildingChanges(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTeacherMinGapsBetweenBuildingChanges");
		ConstraintTeacherMinGapsBetweenBuildingChanges cn = new ConstraintTeacherMinGapsBetweenBuildingChanges();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Teacher")
			{
				cn.teacherName = elem4.text();
				xmlReadingLog += "    Read teacher name=" + cn.teacherName + "\n";
			}
			else if (elem4.tagName() == "Min_Gaps_Between_Building_Changes")
			{
				cn.minGapsBetweenBuildingChanges = elem4.text().toInt();
				xmlReadingLog += "    Min gaps between building changes=" + CustomFETString.number(cn.minGapsBetweenBuildingChanges) + "\n";
			}
		}
		return cn;
	}
	private SpaceConstraint readTeachersMinGapsBetweenBuildingChanges(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintTeachersMinGapsBetweenBuildingChanges");
		ConstraintTeachersMinGapsBetweenBuildingChanges cn = new ConstraintTeachersMinGapsBetweenBuildingChanges();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Min_Gaps_Between_Building_Changes")
			{
				cn.minGapsBetweenBuildingChanges = elem4.text().toInt();
				xmlReadingLog += "    Min gaps between building changes=" + CustomFETString.number(cn.minGapsBetweenBuildingChanges) + "\n";
			}
		}
		return cn;
	}

	private SpaceConstraint readStudentsSetMaxBuildingChangesPerDay(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsSetMaxBuildingChangesPerDay");
		ConstraintStudentsSetMaxBuildingChangesPerDay cn = new ConstraintStudentsSetMaxBuildingChangesPerDay();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Students")
			{
				cn.studentsName = elem4.text();
				xmlReadingLog += "    Read students name=" + cn.studentsName + "\n";
			}
			else if (elem4.tagName() == "Max_Building_Changes_Per_Day")
			{
				cn.maxBuildingChangesPerDay = elem4.text().toInt();
				xmlReadingLog += "    Max. building changes per day=" + CustomFETString.number(cn.maxBuildingChangesPerDay) + "\n";
			}
		}
		return cn;
	}
	private SpaceConstraint readStudentsMaxBuildingChangesPerDay(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsMaxBuildingChangesPerDay");
		ConstraintStudentsMaxBuildingChangesPerDay cn = new ConstraintStudentsMaxBuildingChangesPerDay();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Max_Building_Changes_Per_Day")
			{
				cn.maxBuildingChangesPerDay = elem4.text().toInt();
				xmlReadingLog += "    Max. building changes per day=" + CustomFETString.number(cn.maxBuildingChangesPerDay) + "\n";
			}
		}
		return cn;
	}
	private SpaceConstraint readStudentsSetMaxBuildingChangesPerWeek(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsSetMaxBuildingChangesPerWeek");
		ConstraintStudentsSetMaxBuildingChangesPerWeek cn = new ConstraintStudentsSetMaxBuildingChangesPerWeek();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Students")
			{
				cn.studentsName = elem4.text();
				xmlReadingLog += "    Read students name=" + cn.studentsName + "\n";
			}
			else if (elem4.tagName() == "Max_Building_Changes_Per_Week")
			{
				cn.maxBuildingChangesPerWeek = elem4.text().toInt();
				xmlReadingLog += "    Max. building changes per week=" + CustomFETString.number(cn.maxBuildingChangesPerWeek) + "\n";
			}
		}
		return cn;
	}
	private SpaceConstraint readStudentsMaxBuildingChangesPerWeek(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsMaxBuildingChangesPerWeek");
		ConstraintStudentsMaxBuildingChangesPerWeek cn = new ConstraintStudentsMaxBuildingChangesPerWeek();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Max_Building_Changes_Per_Week")
			{
				cn.maxBuildingChangesPerWeek = elem4.text().toInt();
				xmlReadingLog += "    Max. building changes per week=" + CustomFETString.number(cn.maxBuildingChangesPerWeek) + "\n";
			}
		}
		return cn;
	}
	private SpaceConstraint readStudentsSetMinGapsBetweenBuildingChanges(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsSetMinGapsBetweenBuildingChanges");
		ConstraintStudentsSetMinGapsBetweenBuildingChanges cn = new ConstraintStudentsSetMinGapsBetweenBuildingChanges();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Students")
			{
				cn.studentsName = elem4.text();
				xmlReadingLog += "    Read students name=" + cn.studentsName + "\n";
			}
			else if (elem4.tagName() == "Min_Gaps_Between_Building_Changes")
			{
				cn.minGapsBetweenBuildingChanges = elem4.text().toInt();
				xmlReadingLog += "    min gaps between building changes=" + CustomFETString.number(cn.minGapsBetweenBuildingChanges) + "\n";
			}
		}
		return cn;
	}
	private SpaceConstraint readStudentsMinGapsBetweenBuildingChanges(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintStudentsMinGapsBetweenBuildingChanges");
		ConstraintStudentsMinGapsBetweenBuildingChanges cn = new ConstraintStudentsMinGapsBetweenBuildingChanges();
		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";
			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Min_Gaps_Between_Building_Changes")
			{
				cn.minGapsBetweenBuildingChanges = elem4.text().toInt();
				xmlReadingLog += "    min gaps between building changes=" + CustomFETString.number(cn.minGapsBetweenBuildingChanges) + "\n";
			}
		}
		return cn;
	}


	//2012-04-29
	private SpaceConstraint readActivitiesOccupyMaxDifferentRooms(QDomElement elem3, ref FakeString xmlReadingLog)
	{
		Debug.Assert(elem3.tagName() == "ConstraintActivitiesOccupyMaxDifferentRooms");
		ConstraintActivitiesOccupyMaxDifferentRooms cn = new ConstraintActivitiesOccupyMaxDifferentRooms();

		int ac = 0;

		for (QDomNode node4 = elem3.firstChild(); !node4.isNull(); node4 = node4.nextSibling())
		{
			QDomElement elem4 = node4.toElement();
			if (elem4.isNull())
			{
				xmlReadingLog += "    Null node here\n";
				continue;
			}
			xmlReadingLog += "    Found " + elem4.tagName() + " tag\n";

			if (elem4.tagName() == "Weight_Percentage")
			{
				cn.weightPercentage = GlobalMembersTimetable_defs.customFETStrToDouble(elem4.text());
				xmlReadingLog += "    Adding weight percentage=" + CustomFETString.number(cn.weightPercentage) + "\n";
			}
			else if (elem4.tagName() == "Active")
			{
				if (elem4.text() == "false")
				{
					cn.active = false;
				}
			}
			else if (elem4.tagName() == "Comments")
			{
				cn.comments = elem4.text();
			}
			else if (elem4.tagName() == "Number_of_Activities")
			{
				ac = elem4.text().toInt();
				xmlReadingLog += "    Read number of activities=" + CustomFETString.number(ac) + "\n";
			}
			else if (elem4.tagName() == "Activity_Id")
			{
				cn.activitiesIds.append(elem4.text().toInt());
				xmlReadingLog += "    Read activity id=" + CustomFETString.number(cn.activitiesIds[cn.activitiesIds.count() - 1]) + "\n";
			}
			else if (elem4.tagName() == "Max_Number_of_Different_Rooms")
			{
				cn.maxDifferentRooms = elem4.text().toInt();
				xmlReadingLog += "    Read max number of different rooms=" + CustomFETString.number(cn.maxDifferentRooms) + "\n";
			}
		}

		Debug.Assert(ac == cn.activitiesIds.count());

		return cn;
	}
}

////////////////
